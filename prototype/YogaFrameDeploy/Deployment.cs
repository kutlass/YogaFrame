using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace YogaFrameDeploy
{
    public class Deployment
    {
        //
        // GenerateQueryString - Takes MySQL <script>.txt 
        //
        public static string GenerateQueryString(string sourceTextFile)
        {
            string scriptLineSingle = null;
            try
            {
                string scriptLineMulti = System.IO.File.ReadAllText(sourceTextFile);
                scriptLineSingle = scriptLineMulti.Replace(Environment.NewLine, " ");                
            }
            catch (Exception ex)
            {
                Trace.WriteLine("System.IO.File.ReadAllText() exception: " + ex.Message);
            }

            return scriptLineSingle;
        }

        public static string LocalGetConnectionString()
        {
            return Properties.Settings.Default.ConnectionString;
        }

        public static void LocalSetConnectionString(string connectionString)
        {
            Properties.Settings.Default.ConnectionString = connectionString;
            Properties.Settings.Default.Save();
        }

        public void DatabaseConnect()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                Trace.WriteLine("Connecting to MySQL...");
                conn.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            conn.Close();
            Trace.WriteLine("Done.");
        }

        public void DatabaseCommand()
        {
            //
            // PLACEHOLDER TUTORIAL CODE - Constructing a MySQL command
            //        
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql = "SELECT * FROM tbl_Characters";
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();                
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Trace.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }
        
        public static void DatabaseDeploy()
        {
            
        }

        public static void DatabaseBackup()
        {

        }
        
        public static void DatabaseRestore()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql = "INSERT INTO tbl_Characters (colName, colDescription) VALUES ('Blanka', 'Shocker')";
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }        

        //
        // tbl_Games_drop.txt
        //
        public static void DatabaseRestore1()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql = Deployment.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_drop.txt");
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }
        
        //
        // tbl_Games_create.txt
        //
        public static void DatabaseRestore2()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);            
            try
            {
                string sql = Deployment.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_create.txt");
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }

        //
        // procedure_GetCharacters_drop.txt
        //
        public static void procedure_GetCharacters_drop()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql = Deployment.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_drop.txt");
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }

        //
        // procedure_GetCharacters_create.txt
        //
        public static void procedure_GetCharacters_create()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql = Deployment.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_create.txt");
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }

        //
        // Call GetCharacters stored procedure
        //
        public static void procedure_GetCharacters_call()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GetCharacters";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

                MySqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    Trace.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                }
                rdr.Close();
                
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }

        //
        // Test - Calling PHP script from .NET client WebRequest
        //
        public static void YogaWebRequest()
        {
            const string URI = "https://www.yogaframe.net/YogaFrame/GetCharacters.php";
            Trace.WriteLine("Attempting WebRequest to " + URI);
            WebRequest webRequest = WebRequest.Create(URI);
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.Method = "GET";            
            try
            {
                WebResponse webResponse = webRequest.GetResponse();                
                Stream stream = webResponse.GetResponseStream();       
                StreamReader streamReader = new StreamReader(stream);                
                string strJsonResponse = streamReader.ReadToEnd();
                Trace.WriteLine("YogaWebRequest: OUTPUT from streamReader.ReadToEnd(): " + strJsonResponse);

                //
                // convert string to stream
                //
                byte[] byteArray = Encoding.UTF8.GetBytes(strJsonResponse);
                MemoryStream streamJsonResponse = new MemoryStream(byteArray);
                
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer( typeof(tbl_Characters) );                
                streamJsonResponse.Position = 0;
                tbl_Characters obj_tbl_Characters = (tbl_Characters)dataContractJsonSerializer.ReadObject(streamJsonResponse);
                
                streamReader.Close();
                webResponse.Close();
            }
            catch (WebException webException)
            {
                Trace.WriteLine("YogaWebRequest.WebException.Message: " + webException.Message);
                Trace.WriteLine("YogaWebRequest.WebException.Response: " + webException.Response);
            }
        }
        
        //
        // Upload GetCharacters.php to web host via ftp
        //
        public static void DeployFiles()
        {
            //
            // Grab ftp connection info from local settings file
            //
            string ftpUri = Properties.Settings.Default.FtpUri;
            string ftpUserName = Properties.Settings.Default.FtpUserName;
            string ftpPassword = Properties.Settings.Default.FtpPassword;
            
            List<DeploymentFile> listDeploymentFiles = new List<DeploymentFile>();

            listDeploymentFiles.Add( new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetCharacters.php",
                "//public_html//YogaFrame//GetCharacters.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetGames.php",
                "//public_html//YogaFrame//GetGames.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\FetchDataWebService.php",
                "//public_html//YogaFrame//FetchDataWebService.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Connect.php",
                "//public_html//YogaFrame//Connect.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Trace.php",
                "//public_html//YogaFrame//Trace.php")
                );

            foreach (DeploymentFile deploymentFile in listDeploymentFiles)
            {
                Deployment.FtpUploadFile(ftpUri, ftpUserName, ftpPassword, deploymentFile);
            }            
        }

        public static void FtpUploadFile(string ftpUri, string ftpUserName, string ftpPassword, DeploymentFile deploymentFile)
        {
            Trace.WriteLine("FtpUploadFile: " + deploymentFile.m_fileSource);
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUri + @"/" + deploymentFile.m_fileTarget);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                
                // fpt user credentials
                request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);

                // Copy the contents of the file to the request stream.
                StreamReader sourceStream = new StreamReader(deploymentFile.m_fileSource);
                byte[] fileContents = System.Text.Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Trace.WriteLine("FtpWebResponse.StatusDescription = " + response.StatusDescription);

                response.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("FtpUploadFile() failed: " + ex.Message);
            }            
        }

        public static void DeployFullService()
        {
            //
            // Test out the various deployment methods
            //
            Deployment deployment = new Deployment();
            deployment.DatabaseConnect();
            Deployment.DatabaseRestore();
            Deployment.DatabaseRestore1();
            Deployment.DatabaseRestore2();
            //deployment.DatabaseCommand();

            Deployment.procedure_GetCharacters_drop();
            Deployment.procedure_GetCharacters_create();
            Deployment.procedure_GetCharacters_call();
                        
            Deployment.DeployFiles();
            Deployment.YogaWebRequest();
        }
    }

    public class DeploymentFile
    {
        public string m_fileSource;
        public string m_fileTarget;

        //
        // Constructor
        //
        public DeploymentFile(string fileSource, string fileTarget)
        {
            m_fileSource = fileSource;
            m_fileTarget = fileTarget;
        }
    }

    [DataContract(Name = "tbl_Characters")]
    public class tbl_Characters
    {
        [DataMember]
        public List<Character> listCharacters;
    }

    [DataContract(Name = "Character")]
    public class Character
    {
        [DataMember]
        public int idtbl_Characters;

        [DataMember]
        public string colName;        
        
        [DataMember]
        public string colDescription;
    }
}
