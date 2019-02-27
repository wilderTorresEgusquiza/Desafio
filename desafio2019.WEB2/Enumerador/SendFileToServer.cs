using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace desafio2019.WEB.Enumerador
{
    public static class SendFileToServer
    {
        // Enter your host name or IP here
        private static string host = "104.248.211.185";
        // Enter your sftp username here
        private static string username = "root";
        // Enter your sftp password here
        private static string password = "iota2019123";
        public static int Send(string fileName)
        {
            var connectionInfo = new ConnectionInfo(host, "sftp", new PasswordAuthenticationMethod(username, password));
            // Upload File
            using (var sftp = new SftpClient(connectionInfo))
            {

                sftp.Connect();
                sftp.ChangeDirectory("/opt/prueba/");
                using (var uplfileStream = System.IO.File.OpenRead(fileName))
                {
                    sftp.UploadFile(uplfileStream, fileName, true);
                }
                sftp.Disconnect();
            }
            return 0;
        }

    }
}