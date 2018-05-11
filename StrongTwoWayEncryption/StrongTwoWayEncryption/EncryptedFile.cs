using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongTwoWayEncryption
{
    class EncryptedFile
    {
        public string FileBase64 { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }

        public EncryptedFile(string fileBase64, string fileName, string extension)
        {
            FileBase64 = fileBase64;
            FileName = fileName;
            Extension = extension;
        }

        public EncryptedFile()
        {
        }
    }
}
