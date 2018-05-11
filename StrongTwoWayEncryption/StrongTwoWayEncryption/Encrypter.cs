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

namespace StrongTwoWayEncryption
{
    public partial class SimpleEncryptor : Form
    {
        private string extenstion = "";
        public SimpleEncryptor()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text == tbPasswordCheck.Text)
            {
                disableButtons();
                tbOuput.Text = TwoWayAES.SimpleEncryptWithPassword(tbInput.Text, tbPassword.Text);
                enableButtons();
            }
            else
            {
                MessageBox.Show("Passwords don't match!");
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text == tbPasswordCheck.Text)
            {
                disableButtons();
                tbOuput.Text = TwoWayAES.SimpleDecryptWithPassword(tbInput.Text, tbPassword.Text);
                enableButtons();
            }
            else
            {
                MessageBox.Show("Passwords don't match!");
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    tbFileUrl.Text = File.ReadAllText(file);
                }
                catch (IOException)
                {
                }
            }
        }

        private string readFileAsBase64(string path)
        {
            extenstion = Path.GetExtension(path);
            Byte[] bytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(bytes);
        }

        private string writeFileFromBase64(string base64, string path)
        {
            Byte[] bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(path, bytes);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "unknown.txt";
            // set filters - this can be done in properties as well
            savefile.Filter = "EncryptedFile.txt  Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                    sw.WriteLine("Hello World!");
            }
        }
    }
}
