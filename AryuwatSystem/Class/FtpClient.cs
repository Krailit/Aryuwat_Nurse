using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AryuwatSystem.DerClass
{
    public class FtpClient
    {
        private static Encoding ASCII = Encoding.ASCII;
        private static int BUFFER_SIZE = 512;

        private bool binMode = false;

        private Byte[] buffer = new Byte[BUFFER_SIZE];
        private int bytes = 0;
        private Socket clientSocket = null;
        private bool loggedin = false;
        private string message = null;
        private string password = "anonymous@anonymous.net";
        private int port = 21;
        private string remotePath = ".";
        private string result = null;
        private int resultCode = 0;
        private string server = "localhost";

        private int timeoutSeconds = 10;
        private string username = "anonymous";
        private bool verboseDebugging = false;

        /// <summary>
        /// Default contructor
        /// </summary>
        public FtpClient()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public FtpClient(string server, string username, string password)
        {
            this.server = server;
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="timeoutSeconds"></param>
        /// <param name="port"></param>
        public FtpClient(string server, string username, string password, int timeoutSeconds, int port)
        {
            this.server = server;
            this.username = username;
            this.password = password;
            this.timeoutSeconds = timeoutSeconds;
            this.port = port;
        }

        /// <summary>
        /// Display all communications to the debug log
        /// </summary>
        public bool VerboseDebugging
        {
            get { return verboseDebugging; }
            set { verboseDebugging = value; }
        }

        /// <summary>
        /// Remote server port. Typically TCP 21
        /// </summary>
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        /// <summary>
        /// Timeout waiting for a response from server, in seconds.
        /// </summary>
        public int Timeout
        {
            get { return timeoutSeconds; }
            set { timeoutSeconds = value; }
        }

        /// <summary>
        /// Gets and Sets the name of the FTP server.
        /// </summary>
        /// <returns></returns>
        public string Server
        {
            get { return server; }
            set { server = value; }
        }

        /// <summary>
        /// Gets and Sets the port number.
        /// </summary>
        /// <returns></returns>
        public int RemotePort
        {
            get { return port; }
            set { port = value; }
        }

        /// <summary>
        /// GetS and Sets the remote directory.
        /// </summary>
        public string RemotePath
        {
            get { return remotePath; }
            set { remotePath = value; }
        }

        /// <summary>
        /// Gets and Sets the username.
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        /// <summary>
        /// Gets and Set the password.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// If the value of mode is true, set binary mode for downloads, else, Ascii mode.
        /// </summary>
        public bool BinaryMode
        {
            get { return binMode; }
            set
            {
                if (binMode == value) return;

                if (value)
                    sendCommand("TYPE I");

                else
                    sendCommand("TYPE A");

                if (resultCode != 200) throw new FtpException(result.Substring(4));
            }
        }

        /// <summary>
        /// Login to the remote server.
        /// </summary>
        public void Login()
        {
            if (loggedin) Close();

            Debug.WriteLine("Opening connection to " + server, "FtpClient");

            IPAddress addr = null;
            IPEndPoint ep = null;

            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                addr = Dns.Resolve(server).AddressList[0];
                ep = new IPEndPoint(addr, port);
                clientSocket.Connect(ep);
            }
            catch (Exception ex)
            {
                // doubtfull
                if (clientSocket != null && clientSocket.Connected) clientSocket.Close();

                throw new FtpException("Couldn't connect to remote server", ex);
            }

            readResponse();

            if (resultCode != 220)
            {
                Close();
                throw new FtpException(result.Substring(4));
            }

            sendCommand("USER " + username);

            if (!(resultCode == 331 || resultCode == 230))
            {
                cleanup();
                throw new FtpException(result.Substring(4));
            }

            if (resultCode != 230)
            {
                sendCommand("PASS " + password);

                if (!(resultCode == 230 || resultCode == 202))
                {
                    cleanup();
                    throw new FtpException(result.Substring(4));
                }
            }

            loggedin = true;

            Debug.WriteLine("Connected to " + server, "FtpClient");

            ChangeDir(remotePath);
        }

        /// <summary>
        /// Close the FTP connection.
        /// </summary>
        public void Close()
        {
            Debug.WriteLine("Closing connection to " + server, "FtpClient");

            if (clientSocket != null)
            {
                sendCommand("QUIT");
            }

            cleanup();
        }

        /// <summary>
        /// Return a string array containing the remote directory's file list.
        /// </summary>
        /// <returns></returns>
        public string[] GetFileList()
        {
            return GetFileList("*.*");
        }

        /// <summary>
        /// Return a string array containing the remote directory's file list.
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        public string[] GetFileList(string mask)
        {
            if (!loggedin) Login();

            Socket cSocket = createDataSocket();

            sendCommand("NLST " + mask);

            if (!(resultCode == 150 || resultCode == 125)) throw new FtpException(result.Substring(4));

            message = "";

            DateTime timeout = DateTime.Now.AddSeconds(timeoutSeconds);

            while (timeout > DateTime.Now)
            {
                int bytes = cSocket.Receive(buffer, buffer.Length, 0);
                message += ASCII.GetString(buffer, 0, bytes);

                if (bytes < buffer.Length) break;
            }

            string[] msg = message.Replace("\r", "").Split('\n');

            cSocket.Close();

            if (message.IndexOf("No such file or directory") != -1)
                msg = new string[] {};

            readResponse();

            if (resultCode != 226)
                msg = new string[] {};
            //	throw new FtpException(result.Substring(4));

            return msg;
        }

        /// <summary>
        /// Return the size of a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public long GetFileSize(string fileName)
        {
            if (!loggedin) Login();

            sendCommand("SIZE " + fileName);
            long size = 0;

            if (resultCode == 213)
                size = long.Parse(result.Substring(4));

            else
                throw new FtpException(result.Substring(4));

            return size;
        }


        /// <summary>
        /// Download a file to the Assembly's local directory,
        /// keeping the same file name.
        /// </summary>
        /// <param name="remFileName"></param>
        public void Download(string remFileName)
        {
            Download(remFileName, "", false);
        }

        /// <summary>
        /// Download a remote file to the Assembly's local directory,
        /// keeping the same file name, and set the resume flag.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="resume"></param>
        public void Download(string remFileName, Boolean resume)
        {
            Download(remFileName, "", resume);
        }

        /// <summary>
        /// Download a remote file to a local file name which can include
        /// a path. The local file name will be created or overwritten,
        /// but the path must exist.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="locFileName"></param>
        public void Download(string remFileName, string locFileName)
        {
            Download(remFileName, locFileName, false);
        }

        /// <summary>
        /// Download a remote file to a local file name which can include
        /// a path, and set the resume flag. The local file name will be
        /// created or overwritten, but the path must exist.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="locFileName"></param>
        /// <param name="resume"></param>
        public void Download(string remFileName, string locFileName, Boolean resume)
        {
            if (!loggedin) Login();

            BinaryMode = true;

            Debug.WriteLine("Downloading file " + remFileName + " from " + server + "/" + remotePath, "FtpClient");

            if (locFileName.Equals(""))
            {
                locFileName = remFileName;
            }

            FileStream output = null;

            if (!File.Exists(locFileName))
                output = File.Create(locFileName);

            else
                output = new FileStream(locFileName, FileMode.Open);

            Socket cSocket = createDataSocket();

            long offset = 0;

            if (resume)
            {
                offset = output.Length;

                if (offset > 0)
                {
                    sendCommand("REST " + offset);
                    if (resultCode != 350)
                    {
                        //Server dosnt support resuming
                        offset = 0;
                        Debug.WriteLine("Resuming not supported:" + result.Substring(4), "FtpClient");
                    }
                    else
                    {
                        Debug.WriteLine("Resuming at offset " + offset, "FtpClient");
                        output.Seek(offset, SeekOrigin.Begin);
                    }
                }
            }

            sendCommand("RETR " + remFileName);

            if (resultCode != 150 && resultCode != 125)
            {
                throw new FtpException(result.Substring(4));
            }

            DateTime timeout = DateTime.Now.AddSeconds(timeoutSeconds);

            while (timeout > DateTime.Now)
            {
                bytes = cSocket.Receive(buffer, buffer.Length, 0);
                output.Write(buffer, 0, bytes);

                if (bytes <= 0)
                {
                    break;
                }
            }

            output.Close();

            if (cSocket.Connected) cSocket.Close();

            readResponse();

            if (resultCode != 226 && resultCode != 250)
                throw new FtpException(result.Substring(4));
        }


        /// <summary>
        /// Upload a file.
        /// </summary>
        /// <param name="fileName"></param>
        public void Upload(string fileName)
        {
            Upload(fileName, false);
        }


        /// <summary>
        /// Upload ��� Server ���� path ��� ���� file �������ͧ��úѹ�֡
        /// ������ tu_cs
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="nameNew"></param>
        public void Upload(string fileName, string nameNew)
        {
            bool resume = false;
            if (!loggedin) Login();

            Socket cSocket = null;
            long offset = 0;

            if (resume)
            {
                try
                {
                    BinaryMode = true;

                    offset = GetFileSize(Path.GetFileName(fileName));
                }
                catch (Exception)
                {
                    // file not exist
                    offset = 0;
                }
            }

            // open stream to read file
            var input = new FileStream(fileName, FileMode.Open);

            if (resume && input.Length < offset)
            {
                // different file size
                Debug.WriteLine("Overwriting " + fileName, "FtpClient");
                offset = 0;
            }
            else if (resume && input.Length == offset)
            {
                // file done
                input.Close();
                Debug.WriteLine("Skipping completed " + fileName + " - turn resume off to not detect.", "FtpClient");
                return;
            }

            // dont create untill we know that we need it
            cSocket = createDataSocket();

            if (offset > 0)
            {
                sendCommand("REST " + offset);
                if (resultCode != 350)
                {
                    Debug.WriteLine("Resuming not supported", "FtpClient");
                    offset = 0;
                }
            }

            if (!string.IsNullOrEmpty(nameNew))
            {
                sendCommand("STOR " + nameNew);
            }
            else sendCommand("STOR " + Path.GetFileName(fileName));

            if (resultCode != 125 && resultCode != 150) throw new FtpException(result.Substring(4));

            if (offset != 0)
            {
                Debug.WriteLine("Resuming at offset " + offset, "FtpClient");

                input.Seek(offset, SeekOrigin.Begin);
            }

            Debug.WriteLine("Uploading file " + fileName + " to " + remotePath, "FtpClient");

            while ((bytes = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                cSocket.Send(buffer, bytes, 0);
            }

            input.Close();

            if (cSocket.Connected)
            {
                cSocket.Close();
            }

            readResponse();

            if (resultCode != 226 && resultCode != 250) throw new FtpException(result.Substring(4));
        }

        /// <summary>
        /// Upload a file and set the resume flag.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="resume"></param>
        public void Upload(string fileName, bool resume)
        {
            if (!loggedin) Login();

            Socket cSocket = null;
            long offset = 0;

            if (resume)
            {
                try
                {
                    BinaryMode = true;

                    offset = GetFileSize(Path.GetFileName(fileName));
                }
                catch (Exception)
                {
                    // file not exist
                    offset = 0;
                }
            }

            // open stream to read file
            var input = new FileStream(fileName, FileMode.Open);

            if (resume && input.Length < offset)
            {
                // different file size
                Debug.WriteLine("Overwriting " + fileName, "FtpClient");
                offset = 0;
            }
            else if (resume && input.Length == offset)
            {
                // file done
                input.Close();
                Debug.WriteLine("Skipping completed " + fileName + " - turn resume off to not detect.", "FtpClient");
                return;
            }

            // dont create untill we know that we need it
            cSocket = createDataSocket();

            if (offset > 0)
            {
                sendCommand("REST " + offset);
                if (resultCode != 350)
                {
                    Debug.WriteLine("Resuming not supported", "FtpClient");
                    offset = 0;
                }
            }

            sendCommand("STOR " + Path.GetFileName(fileName));
            //this.sendCommand("STOR " + "JJ.jpg");

            if (resultCode != 125 && resultCode != 150) throw new FtpException(result.Substring(4));

            if (offset != 0)
            {
                Debug.WriteLine("Resuming at offset " + offset, "FtpClient");

                input.Seek(offset, SeekOrigin.Begin);
            }

            Debug.WriteLine("Uploading file " + fileName + " to " + remotePath, "FtpClient");

            while ((bytes = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                cSocket.Send(buffer, bytes, 0);
            }

            input.Close();

            if (cSocket.Connected)
            {
                cSocket.Close();
            }

            readResponse();

            if (resultCode != 226 && resultCode != 250) throw new FtpException(result.Substring(4));
        }

        /// <summary>
        /// Upload a directory and its file contents
        /// </summary>
        /// <param name="path"></param>
        /// <param name="recurse">Whether to recurse sub directories</param>
        public void UploadDirectory(string path, bool recurse)
        {
            UploadDirectory(path, recurse, "*.*");
        }

        /// <summary>
        /// Upload a directory and its file contents
        /// </summary>
        /// <param name="path"></param>
        /// <param name="recurse">Whether to recurse sub directories</param>
        /// <param name="mask">Only upload files of the given mask - everything is '*.*'</param>
        public void UploadDirectory(string path, bool recurse, string mask)
        {
            string[] dirs = path.Replace("/", @"\").Split('\\');
            string rootDir = dirs[dirs.Length - 1];

            // make the root dir if it doed not exist
            if (GetFileList(rootDir).Length < 1) MakeDir(rootDir);

            ChangeDir(rootDir);

            foreach (string file in Directory.GetFiles(path, mask))
            {
                Upload(file, true);
            }
            if (recurse)
            {
                foreach (string directory in Directory.GetDirectories(path))
                {
                    UploadDirectory(directory, recurse, mask);
                }
            }

            ChangeDir("..");
        }

        /// <summary>
        /// Delete a file from the remote FTP server.
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteFile(string fileName)
        {
            if (!loggedin) Login();

            sendCommand("DELE " + fileName);

            if (resultCode != 250) throw new FtpException(result.Substring(4));

            Debug.WriteLine("Deleted file " + fileName, "FtpClient");
        }

        /// <summary>
        /// Rename a file on the remote FTP server.
        /// </summary>
        /// <param name="oldFileName"></param>
        /// <param name="newFileName"></param>
        /// <param name="overwrite">setting to false will throw exception if it exists</param>
        public void RenameFile(string oldFileName, string newFileName, bool overwrite)
        {
            if (!loggedin) Login();

            sendCommand("RNFR " + oldFileName);

            if (resultCode != 350) throw new FtpException(result.Substring(4));

            if (!overwrite && GetFileList(newFileName).Length > 0) throw new FtpException("File already exists");

            sendCommand("RNTO " + newFileName);

            if (resultCode != 250) throw new FtpException(result.Substring(4));

            Debug.WriteLine("Renamed file " + oldFileName + " to " + newFileName, "FtpClient");
        }

        /// <summary>
        /// Create a directory on the remote FTP server.
        /// </summary>
        /// <param name="dirName"></param>
        public void MakeDir(string dirName)
        {
            if (!loggedin) Login();

            sendCommand("MKD " + dirName);

            if (resultCode != 250 && resultCode != 257) throw new FtpException(result.Substring(4));

            Debug.WriteLine("Created directory " + dirName, "FtpClient");
        }

        /// <summary>
        /// Delete a directory on the remote FTP server.
        /// </summary>
        /// <param name="dirName"></param>
        public void RemoveDir(string dirName)
        {
            if (!loggedin) Login();

            sendCommand("RMD " + dirName);

            if (resultCode != 250) throw new FtpException(result.Substring(4));

            Debug.WriteLine("Removed directory " + dirName, "FtpClient");
        }

        /// <summary>
        /// Change the current working directory on the remote FTP server.
        /// </summary>
        /// <param name="dirName"></param>
        public void ChangeDir(string dirName)
        {
            if (dirName == null || dirName.Equals(".") || dirName.Length == 0)
            {
                return;
            }

            if (!loggedin) Login();

            sendCommand("CWD " + dirName);

            if (resultCode != 250) throw new FtpException(result.Substring(4));

            sendCommand("PWD");

            if (resultCode != 257) throw new FtpException(result.Substring(4));

            // gonna have to do better than this....
            remotePath = message.Split('"')[1];

            Debug.WriteLine("Current directory is " + remotePath, "FtpClient");
        }

        /// <summary>
        /// 
        /// </summary>
        private void readResponse()
        {
            message = "";
            result = readLine();

            if (result.Length > 3)
                resultCode = int.Parse(result.Substring(0, 3));
            else
                result = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string readLine()
        {
            while (true)
            {
                bytes = clientSocket.Receive(buffer, buffer.Length, 0);
                message += ASCII.GetString(buffer, 0, bytes);

                if (bytes < buffer.Length)
                {
                    break;
                }
            }

            string[] msg = message.Split('\n');

            if (message.Length > 2)
                message = msg[msg.Length - 2];

            else
                message = msg[0];


            if (message.Length > 4 && !message.Substring(3, 1).Equals(" ")) return readLine();

            if (verboseDebugging)
            {
                for (int i = 0; i < msg.Length - 1; i++)
                {
                    Debug.Write(msg[i], "FtpClient");
                }
            }

            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        private void sendCommand(String command)
        {
            if (verboseDebugging) Debug.WriteLine(command, "FtpClient");

            Byte[] cmdBytes = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());
            clientSocket.Send(cmdBytes, cmdBytes.Length, 0);
            readResponse();
        }

        /// <summary>
        /// when doing data transfers, we need to open another socket for it.
        /// </summary>
        /// <returns>Connected socket</returns>
        private Socket createDataSocket()
        {
            sendCommand("PASV");

            if (resultCode != 227) throw new FtpException(result.Substring(4));

            int index1 = result.IndexOf('(');
            int index2 = result.IndexOf(')');

            string ipData = result.Substring(index1 + 1, index2 - index1 - 1);

            var parts = new int[6];

            int len = ipData.Length;
            int partCount = 0;
            string buf = "";

            for (int i = 0; i < len && partCount <= 6; i++)
            {
                char ch = char.Parse(ipData.Substring(i, 1));

                if (char.IsDigit(ch))
                    buf += ch;

                else if (ch != ',')
                    throw new FtpException("Malformed PASV result: " + result);

                if (ch == ',' || i + 1 == len)
                {
                    try
                    {
                        parts[partCount++] = int.Parse(buf);
                        buf = "";
                    }
                    catch (Exception ex)
                    {
                        throw new FtpException("Malformed PASV result (not supported?): " + result, ex);
                    }
                }
            }

            string ipAddress = parts[0] + "." + parts[1] + "." + parts[2] + "." + parts[3];

            int port = (parts[4] << 8) + parts[5];

            Socket socket = null;
            IPEndPoint ep = null;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ep = new IPEndPoint(Dns.Resolve(ipAddress).AddressList[0], port);
                socket.Connect(ep);
            }
            catch (Exception ex)
            {
                // doubtfull....
                if (socket != null && socket.Connected) socket.Close();

                throw new FtpException("Can't connect to remote server", ex);
            }

            return socket;
        }

        /// <summary>
        /// Always release those sockets.
        /// </summary>
        private void cleanup()
        {
            if (clientSocket != null)
            {
                clientSocket.Close();
                clientSocket = null;
            }
            loggedin = false;
        }

        /// <summary>
        /// Destuctor
        /// </summary>
        ~FtpClient()
        {
            cleanup();
        }

        #region Async methods (auto generated)

/*
				WinInetApi.FtpClient ftp = new WinInetApi.FtpClient();

				MethodInfo[] methods = ftp.GetType().GetMethods(BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public);

				foreach ( MethodInfo method in methods )
				{
					string param = "";
					string values = "";
					foreach ( ParameterInfo i in  method.GetParameters() )
					{
						param += i.ParameterType.Name + " " + i.Name + ",";
						values += i.Name + ",";
					}
					

					Debug.WriteLine("private delegate " + method.ReturnType.Name + " " + method.Name + "Callback(" + param.TrimEnd(',') + ");");

					Debug.WriteLine("public System.IAsyncResult Begin" + method.Name + "( " + param + " System.AsyncCallback callback )");
					Debug.WriteLine("{");
					Debug.WriteLine("" + method.Name + "Callback ftpCallback = new " + method.Name + "Callback(" + values + " this." + method.Name + ");");
					Debug.WriteLine("return ftpCallback.BeginInvoke(callback, null);");
					Debug.WriteLine("}");
					Debug.WriteLine("public void End" + method.Name + "(System.IAsyncResult asyncResult)");
					Debug.WriteLine("{");
					Debug.WriteLine(method.Name + "Callback fc = (" + method.Name + "Callback) ((AsyncResult)asyncResult).AsyncDelegate;");
					Debug.WriteLine("fc.EndInvoke(asyncResult);");
					Debug.WriteLine("}");
					//Debug.WriteLine(method);
				}
*/


        public IAsyncResult BeginLogin(AsyncCallback callback)
        {
            var ftpCallback = new LoginCallback(Login);
            return ftpCallback.BeginInvoke(callback, null);
        }

        public IAsyncResult BeginClose(AsyncCallback callback)
        {
            var ftpCallback = new CloseCallback(Close);
            return ftpCallback.BeginInvoke(callback, null);
        }

        public IAsyncResult BeginGetFileList(AsyncCallback callback)
        {
            var ftpCallback = new GetFileListCallback(GetFileList);
            return ftpCallback.BeginInvoke(callback, null);
        }

        public IAsyncResult BeginGetFileList(String mask, AsyncCallback callback)
        {
            var ftpCallback = new GetFileListMaskCallback(GetFileList);
            return ftpCallback.BeginInvoke(mask, callback, null);
        }

        public IAsyncResult BeginGetFileSize(String fileName, AsyncCallback callback)
        {
            var ftpCallback = new GetFileSizeCallback(GetFileSize);
            return ftpCallback.BeginInvoke(fileName, callback, null);
        }

        public IAsyncResult BeginDownload(String remFileName, AsyncCallback callback)
        {
            var ftpCallback = new DownloadCallback(Download);
            return ftpCallback.BeginInvoke(remFileName, callback, null);
        }

        public IAsyncResult BeginDownload(String remFileName, Boolean resume, AsyncCallback callback)
        {
            var ftpCallback = new DownloadFileNameResumeCallback(Download);
            return ftpCallback.BeginInvoke(remFileName, resume, callback, null);
        }

        public IAsyncResult BeginDownload(String remFileName, String locFileName, AsyncCallback callback)
        {
            var ftpCallback = new DownloadFileNameFileNameCallback(Download);
            return ftpCallback.BeginInvoke(remFileName, locFileName, callback, null);
        }

        public IAsyncResult BeginDownload(String remFileName, String locFileName, Boolean resume, AsyncCallback callback)
        {
            var ftpCallback = new DownloadFileNameFileNameResumeCallback(Download);
            return ftpCallback.BeginInvoke(remFileName, locFileName, resume, callback, null);
        }

        public IAsyncResult BeginUpload(String fileName, AsyncCallback callback)
        {
            var ftpCallback = new UploadCallback(Upload);
            return ftpCallback.BeginInvoke(fileName, callback, null);
        }

        public IAsyncResult BeginUpload(String fileName, Boolean resume, AsyncCallback callback)
        {
            var ftpCallback = new UploadFileNameResumeCallback(Upload);
            return ftpCallback.BeginInvoke(fileName, resume, callback, null);
        }

        //Add by tu_cs

        public IAsyncResult BeginUpload(String fileName, string fileNameNew, AsyncCallback callback)
        {
            var ftpCallback = new UploadFileNameNewCallback(Upload);
            return ftpCallback.BeginInvoke(fileName, fileNameNew, callback, null);
        }

        //End Add

        public IAsyncResult BeginUploadDirectory(String path, Boolean recurse, AsyncCallback callback)
        {
            var ftpCallback = new UploadDirectoryCallback(UploadDirectory);
            return ftpCallback.BeginInvoke(path, recurse, callback, null);
        }

        public IAsyncResult BeginUploadDirectory(String path, Boolean recurse, String mask, AsyncCallback callback)
        {
            var ftpCallback = new UploadDirectoryPathRecurseMaskCallback(UploadDirectory);
            return ftpCallback.BeginInvoke(path, recurse, mask, callback, null);
        }

        public IAsyncResult BeginDeleteFile(String fileName, AsyncCallback callback)
        {
            var ftpCallback = new DeleteFileCallback(DeleteFile);
            return ftpCallback.BeginInvoke(fileName, callback, null);
        }

        public IAsyncResult BeginRenameFile(String oldFileName, String newFileName, Boolean overwrite,
                                            AsyncCallback callback)
        {
            var ftpCallback = new RenameFileCallback(RenameFile);
            return ftpCallback.BeginInvoke(oldFileName, newFileName, overwrite, callback, null);
        }

        public IAsyncResult BeginMakeDir(String dirName, AsyncCallback callback)
        {
            var ftpCallback = new MakeDirCallback(MakeDir);
            return ftpCallback.BeginInvoke(dirName, callback, null);
        }

        public IAsyncResult BeginRemoveDir(String dirName, AsyncCallback callback)
        {
            var ftpCallback = new RemoveDirCallback(RemoveDir);
            return ftpCallback.BeginInvoke(dirName, callback, null);
        }

        public IAsyncResult BeginChangeDir(String dirName, AsyncCallback callback)
        {
            var ftpCallback = new ChangeDirCallback(ChangeDir);
            return ftpCallback.BeginInvoke(dirName, callback, null);
        }

        #region Nested type: ChangeDirCallback

        private delegate void ChangeDirCallback(String dirName);

        #endregion

        #region Nested type: CloseCallback

        private delegate void CloseCallback();

        #endregion

        #region Nested type: DeleteFileCallback

        private delegate void DeleteFileCallback(String fileName);

        #endregion

        #region Nested type: DownloadCallback

        private delegate void DownloadCallback(String remFileName);

        #endregion

        #region Nested type: DownloadFileNameFileNameCallback

        private delegate void DownloadFileNameFileNameCallback(String remFileName, String locFileName);

        #endregion

        #region Nested type: DownloadFileNameFileNameResumeCallback

        private delegate void DownloadFileNameFileNameResumeCallback(
            String remFileName, String locFileName, Boolean resume);

        #endregion

        #region Nested type: DownloadFileNameResumeCallback

        private delegate void DownloadFileNameResumeCallback(String remFileName, Boolean resume);

        #endregion

        #region Nested type: GetFileListCallback

        private delegate String[] GetFileListCallback();

        #endregion

        #region Nested type: GetFileListMaskCallback

        private delegate String[] GetFileListMaskCallback(String mask);

        #endregion

        #region Nested type: GetFileSizeCallback

        private delegate Int64 GetFileSizeCallback(String fileName);

        #endregion

        #region Nested type: LoginCallback

        private delegate void LoginCallback();

        #endregion

        #region Nested type: MakeDirCallback

        private delegate void MakeDirCallback(String dirName);

        #endregion

        #region Nested type: RemoveDirCallback

        private delegate void RemoveDirCallback(String dirName);

        #endregion

        #region Nested type: RenameFileCallback

        private delegate void RenameFileCallback(String oldFileName, String newFileName, Boolean overwrite);

        #endregion

        #region Nested type: UploadCallback

        private delegate void UploadCallback(String fileName);

        #endregion

        #region Nested type: UploadDirectoryCallback

        private delegate void UploadDirectoryCallback(String path, Boolean recurse);

        #endregion

        #region Nested type: UploadDirectoryPathRecurseMaskCallback

        private delegate void UploadDirectoryPathRecurseMaskCallback(String path, Boolean recurse, String mask);

        #endregion

        #region Nested type: UploadFileNameNewCallback

        private delegate void UploadFileNameNewCallback(String fileName, string fileNameNew);

        #endregion

        #region Nested type: UploadFileNameResumeCallback

        private delegate void UploadFileNameResumeCallback(String fileName, Boolean resume);

        #endregion

        #endregion

        #region Nested type: FtpException

        public class FtpException : Exception
        {
            public FtpException(string message) : base(message)
            {
            }

            public FtpException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }

        #endregion

        /**************************************************************************************************************/
    }
}