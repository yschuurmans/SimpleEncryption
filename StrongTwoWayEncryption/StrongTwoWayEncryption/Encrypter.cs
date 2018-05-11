using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StrongTwoWayEncryption
{
    public partial class SimpleEncryptor : Form
    {
        public SimpleEncryptor()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            disableButtons();
            tbOuput.Text = TwoWayAES.SimpleEncryptWithPassword(tbInput.Text, tbPassword.Text);
            enableButtons();

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            disableButtons();
            tbOuput.Text = TwoWayAES.SimpleDecryptWithPassword(tbInput.Text, tbPassword.Text);
            enableButtons();

        }

        private void disableButtons()
        {
            btnDecrypt.Enabled = false;
            btnEncrypt.Enabled = false;
        }

        private void enableButtons()
        {
            btnDecrypt.Enabled = true;
            btnEncrypt.Enabled = true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (tbFileUrl.Text.Length > 0 && File.Exists(tbFileUrl.Text))
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(tbFileUrl.Text);

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    tbFileUrl.Text = openFileDialog1.FileName;
                }
                catch (IOException)
                {
                }
            }
        }

        private bool CheckInput()
        {
            if (tbPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters");
                return false;
            }
            if (tbPassword.Text != tbPasswordCheck.Text)
            {
                MessageBox.Show("Passwords don't match!");
                return false;
            }
            return true;
        }

        private bool CheckFileInput()
        {
            if (tbFilePassword1.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters");
                return false;
            }
            if (tbFilePassword1.Text != tbFilePassword2.Text)
            {
                MessageBox.Show("Passwords don't match!");
                return false;
            }
            return true;
        }

        private string ReadFileAsBase64(string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(bytes);
        }

        private void WriteFileFromBase64(string base64, string path)
        {
            Byte[] bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(path, bytes);
        }

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            if (!CheckFileInput()) return;

            if (File.Exists(tbFileUrl.Text))
            {
                string readFile = ReadFileAsBase64(tbFileUrl.Text);
                string encryptedFile = EncryptBase64File(readFile, Path.GetFileName(tbFileUrl.Text), Path.GetExtension(tbFileUrl.Text));
                SaveFileFromBase64(encryptedFile, Path.GetFileName(tbFileUrl.Text) + ".enc", "Encrypted File (.enc)|*.enc");
            }
        }

        private void btnDecryptFile_Click(object sender, EventArgs e)
        {
            if (!CheckFileInput()) return;

            if (File.Exists(tbFileUrl.Text))
            {
                string extension = "";
                string filename = "";

                string readFile = ReadFileAsBase64(tbFileUrl.Text);
                string decryptedFile = DecryptBase64File(readFile, out filename, out extension);
                SaveFileFromBase64(decryptedFile, filename, "Original File Format|*"+extension);
            }
        }

        private void SaveFileFromBase64(string base64, string defaultFilename, string extensionFilter)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = defaultFilename;
            // set filters - this can be done in properties as well
            savefile.Filter = extensionFilter;


            if (tbFileUrl.Text.Length > 0 && File.Exists(tbFileUrl.Text))
                savefile.InitialDirectory = Path.GetDirectoryName(tbFileUrl.Text);

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                WriteFileFromBase64(base64, savefile.FileName);
            }
        }

        private string EncryptBase64File(string base64String, string filename, string extension)
        {
            string encBase64String = TwoWayAES.SimpleEncryptWithPassword(base64String, tbFilePassword1.Text);
            EncryptedFile encFile = new EncryptedFile(encBase64String, filename, extension);
            string jsonEncFile = JsonConvert.SerializeObject(encFile);
            return TwoWayAES.SimpleEncryptWithPassword(jsonEncFile, tbFilePassword1.Text);
        }

        private string DecryptBase64File(string encryptedFileString, out string fileName, out string extension)
        {
            string jsonEncFile = TwoWayAES.SimpleDecryptWithPassword(encryptedFileString, tbFilePassword1.Text);
            EncryptedFile encFile = JsonConvert.DeserializeObject<EncryptedFile>(jsonEncFile);
            fileName = encFile.FileName;
            extension = encFile.Extension;
            return TwoWayAES.SimpleDecryptWithPassword(encFile.FileBase64, tbFilePassword1.Text);
        }
    }
}
