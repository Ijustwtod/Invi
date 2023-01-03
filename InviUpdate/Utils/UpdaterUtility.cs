using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InviUpdate.Utils
{
    internal class UpdaterUtility
    {
        public static string GetLastBuilds()
        {
            var prop = Properties.Settings.Default;
            var request = (FtpWebRequest)WebRequest.Create(prop.ftpUrl);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(prop.ftpLogin, prop.ftpPassword);
            request.UsePassive = false;
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                var responseStream = response.GetResponseStream();
                using (var streamReader = new StreamReader(responseStream))
                {
                    var builds = new List<string>();
                    string line = streamReader.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        builds.Add(line);
                        line = streamReader.ReadLine();
                    }
                    if (builds.Count > 0)
                        return builds.Max();
                    else return "nope";
                }
            }
        }

        public static void DownloadLastVersion(string fileName)
        {
            try
            {
                var prop = Properties.Settings.Default;
                var request = (FtpWebRequest)WebRequest.Create(prop.ftpUrl + fileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(prop.ftpLogin, prop.ftpPassword);
                request.UsePassive = false;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                if (Directory.Exists("bufer"))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo("bufer");
                    foreach (var file in directoryInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }
                Directory.CreateDirectory("bufer");
                FileStream fs = new FileStream($"bufer/{fileName}", FileMode.Create);
                byte[] buffer = new byte[64];
                int size = 0;
                while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, size);
                }
                fs.Close();
                response.Close();
            }
            catch (Exception)
            {
                throw;
            }


        }

        public static void ZipExtract(string fileName)
        {
            try
            {
                ZipFile.ExtractToDirectory($"bufer/{fileName}", "bufer/");
                FileInfo fileInf = new FileInfo($"bufer/{fileName}");
                if (fileInf.Exists)
                {
                    fileInf.Delete();
                }
            }
            catch (Exception)
            {

            }
        }

        public static void MoveFiles()
        {
            try
            {
                var mainDir = new DirectoryInfo(Directory.GetCurrentDirectory());
                var mainFiles = mainDir.GetFiles().ToList();
                var newDir = new DirectoryInfo(mainDir.FullName + "/bufer");
                var newFiles = newDir.GetFiles().ToList();

                foreach (var file in newFiles)
                {
                    var ff = mainFiles.SingleOrDefault(f => f.Name == file.Name);
                    if (file.Name == "InviUpdate.exe"
                        || file.Name == "InviUpdate.exe.config"
                        || file.Name == "InviUpdate.pdb"
                        || file.Name == "Invi 2.0.exe.config")
                        file.Delete();
                    continue;
                    if (ff != null)
                    {
                        ff.Delete();
                    }
                    file.MoveTo(mainDir.FullName + "\\" + file.Name);

                    newDir.Delete();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void RemoverBuferFies()
        {
            try
            {
                var mainDir = new DirectoryInfo(Directory.GetCurrentDirectory());
                var newDir = new DirectoryInfo(mainDir.FullName + "/bufer");
                var newFiles = newDir.GetFiles().ToList();

                foreach (var file in newFiles)
                {
                    file.Delete();
                }
                newDir.Delete();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
