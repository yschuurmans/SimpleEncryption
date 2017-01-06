using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
