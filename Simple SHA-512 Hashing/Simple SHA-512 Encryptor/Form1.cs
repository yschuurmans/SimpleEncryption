using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Simple_SHA_512_Encryptor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {

            if(tbLimit.Text == "") tbResult.Text = Encrypt(tbPass.Text, tbSalt.Text);
            else tbResult.Text = Encrypt(tbPass.Text, tbSalt.Text).Substring(0,Convert.ToInt32(tbLimit.Text));
        }

        public static string Encrypt(string Password, string salt)
        {
            byte[] MessageBytes = Encoding.UTF8.GetBytes(string.Concat(Password, salt));
            SHA512Managed SHhash = new SHA512Managed();
            byte[] HashValue = SHhash.ComputeHash(MessageBytes);
            string strHex = "";
            foreach (byte b in HashValue) { strHex += String.Format("{0:x2}", b); }
            return strHex;
        }
    }
}
