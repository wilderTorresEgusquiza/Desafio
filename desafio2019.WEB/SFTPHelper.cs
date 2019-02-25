﻿using System;
using System.Collections;
using Tamir.SharpSsh.jsch;

namespace desafio2019.WEB
{
    public class SFTPHelper
    {
        private Session m_session;
        private Channel m_channel;
        private ChannelSftp m_sftp;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="host">SFTP address</param>
        /// <param name="user">username</param>
        /// <param name="pwd">password</param>
        public SFTPHelper(string host, string user, string pwd)
        {
            string[] arr = host.Split(':');
            string ip = arr[0];
            int port = 22;
            if (arr.Length > 1) port = Int32.Parse(arr[1]);

            JSch jsch = new JSch();
            m_session = jsch.getSession(user, ip, port);
            MyUserInfo ui = new MyUserInfo();
            ui.setPassword(pwd);
            m_session.setUserInfo(ui);

        }

        /// <summary>
        /// get SFTP connection status
        /// </summary>
        public bool Connected { get { return m_session.isConnected(); } }

        /// <summary>
        /// connect to SFTP
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            try
            {
                if (!Connected)
                {
                    m_session.connect();
                    m_channel = m_session.openChannel("sftp");
                    m_channel.connect();
                    m_sftp = (ChannelSftp)m_channel;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// disconnect the connection to SFTP
        /// </summary>
        public void Disconnect()
        {
            if (Connected)
            {
                m_channel.disconnect();
                m_session.disconnect();
            }
        }

        /// <summary>
        /// put local file to SFTP
        /// </summary>
        /// <param name="localPath">local path</param>
        /// <param name="remotePath">remote path</param>
        /// <returns></returns>
        public bool Put(string localPath, string remotePath)
        {
            try
            {
                Tamir.SharpSsh.java.String src = new Tamir.SharpSsh.java.String(localPath);
                Tamir.SharpSsh.java.String dst = new Tamir.SharpSsh.java.String(remotePath);
                m_sftp.put(src, dst);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// get remote file from SFTP
        /// </summary>
        /// <param name="remotePath">remote path</param>
        /// <param name="localPath">local path</param>
        /// <returns></returns>
        public bool Get(string remotePath, string localPath)
        {
            try
            {
                Tamir.SharpSsh.java.String src = new Tamir.SharpSsh.java.String(remotePath);
                Tamir.SharpSsh.java.String dst = new Tamir.SharpSsh.java.String(localPath);
                m_sftp.get(src, dst);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// delete file on sftp 
        /// </summary>
        /// <param name="remoteFile">remote path</param>
        /// <returns></returns>
        public bool Delete(string remoteFile)
        {
            try
            {
                m_sftp.rm(remoteFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// get file list from SFTP
        /// </summary>
        /// <param name="remotePath">remote path</param>
        /// <param name="fileType">file type</param>
        /// <returns></returns>
        public ArrayList GetFileList(string remotePath, string fileType)
        {
            try
            {
                Tamir.SharpSsh.java.util.Vector vvv = m_sftp.ls(remotePath);
                ArrayList objList = new ArrayList();
                foreach (Tamir.SharpSsh.jsch.ChannelSftp.LsEntry qqq in vvv)
                {
                    string sss = qqq.getFilename();
                    if (sss.Length > (fileType.Length + 1) && fileType == sss.Substring(sss.Length - fileType.Length))
                    { objList.Add(sss); }
                    else { continue; }
                }

                return objList;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// SFTP login user info
        /// </summary>
        public class MyUserInfo : UserInfo
        {
            String passwd;
            public String getPassword() { return passwd; }
            public void setPassword(String passwd) { this.passwd = passwd; }

            public String getPassphrase() { return null; }
            public bool promptPassphrase(String message) { return true; }

            public bool promptPassword(String message) { return true; }
            public bool promptYesNo(String message) { return true; }
            public void showMessage(String message) { }
        }

    }
}