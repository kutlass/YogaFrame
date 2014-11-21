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
using Newtonsoft.Json;

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

        #region DatabaseConnect method
        public void DatabaseConnect()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                Trace.WriteLine("DatabaseConnect: Connecting to MySQL. MySqlConnection()...");
                conn.Open();
                
                //
                // Perform database operations
                //
                Trace.WriteLine("DatabaseConnect: MySqlConnection() succeeded.");
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            conn.Close();
            Trace.WriteLine("Done.");
        }
        #endregion

        public static void ExecuteQuery()
        {
            string strMySqlConnection = Deployment.LocalGetConnectionString();
            string strMySqlCommand = "SELECT * FROM tbl_Characters";
            Deployment.ExecuteQuery(strMySqlConnection, strMySqlCommand);
        }
        
        public static void ExecuteQuery(string strMySqlConnection, string strMySqlCommand)
        {
            Trace.WriteLine("ExecuteQuery: Query string to execute = " + strMySqlCommand);
            MySqlConnection mySqlConnection = new MySqlConnection(strMySqlConnection);
            try
            {
                Trace.WriteLine("ExecuteQuery: Calling mySqlConnection.Open()...");
                mySqlConnection.Open();

                MySqlCommand mySqlCommand = new MySqlCommand(strMySqlConnection, mySqlConnection);
                Trace.WriteLine("ExecuteQuery: Calling mySqlCommand.ExecuteReader()...");
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Trace.WriteLine("ExecuteQuery: " + mySqlDataReader[0] + " -- " + mySqlDataReader[1] + " -- " + mySqlDataReader[2]);
                }
                mySqlDataReader.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            mySqlConnection.Close();
            Trace.WriteLine("ExecuteQuery: Done.");
        }

        #region Stub methods
        public static void DatabaseDeploy()
        {
            
        }

        public static void DatabaseBackup()
        {

        }
        #endregion

        public static void ExecuteNonQuery(string strMySqlConnection, string strMySqlCommand)
        {
            Trace.WriteLine("ExecuteNonQuery: Nonquery string to execute = " + strMySqlCommand);
            MySqlConnection mySqlConnection = new MySqlConnection(strMySqlConnection);
            try
            {
                Trace.WriteLine("ExecuteNonQuery: Calling mySqlConnection.Open()...");
                mySqlConnection.Open();
                
                MySqlCommand mySqlCommand = new MySqlCommand(strMySqlCommand, mySqlConnection);
                Trace.WriteLine("ExecuteNonQuery: Calling mySqlCommand.ExecuteNonQuery()...");
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            mySqlConnection.Close();
            Trace.WriteLine("ExecuteNonQuery: Done.");
        }

        public static void ExecuteNonQuery()
        {
            string strMySqlConnection = Deployment.LocalGetConnectionString();

            string[] rg_strMySqlCommands = new string[]
            {
                Deployment.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_drop.txt"),
                Deployment.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_create.txt"),                
                Deployment.GenerateQueryString(@".\Scripts.MySQL\tbl_Characters_drop.txt"),
                Deployment.GenerateQueryString(@".\Scripts.MySQL\tbl_Characters_create.txt"),
                Deployment.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_drop.txt"),
                Deployment.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_create.txt"),
                Deployment.GenerateQueryString(@".\Scripts.MySQL\procedure_GetGames_drop.txt"),
                Deployment.GenerateQueryString(@".\Scripts.MySQL\procedure_GetGames_create.txt"),
                "INSERT INTO tbl_Characters (colName, colDescription) VALUES ('Dhalsim', 'Stretchy limb dood. Enjoys meditation and fighting.')",
                "INSERT INTO tbl_Characters (colName, colDescription) VALUES ('Guile', 'In the wrong hands, turtles to no end.')",
                "INSERT INTO tbl_Characters (colName, colDescription) VALUES ('Ryu', 'Rare character.')",
                "INSERT INTO tbl_Characters (colName, colDescription) VALUES ('Ken', 'Underpowered dragon punch. Loves dining.')",
                "INSERT INTO tbl_Characters (colName, colDescription) VALUES ('Blanka', 'Shocker. Baller. Troller.')",
                "INSERT INTO tbl_Characters (colName, colDescription) VALUES ('Bison', 'Boots. Roundhouse. Scissors.')",
                "INSERT INTO tbl_Games (colName, colDeveloper, colDeveloperURL, colPublisher, colPublisherURL, colDescription) VALUES ('Ultra Street Fighter IV', 'Capcom', 'www.capcom.com', 'Capcom', 'www.capcom.com', 'Best game EVAR!! tee hee hee')"
            };

            foreach (string strMySqlCommand in rg_strMySqlCommands)
            {
                Deployment.ExecuteNonQuery(strMySqlConnection, strMySqlCommand);
            }
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
        // Upload PHP scripts to web host via ftp
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
            // Test out Newtonsoft json.NET
            //
            HelperJson.DoThangs();

            //
            // Test out the various deployment methods
            //
            Deployment deployment = new Deployment();
            deployment.DatabaseConnect();
            Deployment.ExecuteNonQuery();
            Deployment.ExecuteQuery();
            Deployment.procedure_GetCharacters_call();
            Deployment.DeployFiles();
            Deployment.CallPhpScriptMulti();
        }

        public static void CallPhpScriptMulti()
        {
            const string uriGetCharacters = "https://www.yogaframe.net/YogaFrame/GetCharacters.php";
            const string uriGetGames = "https://www.yogaframe.net/YogaFrame/GetGames.php";

            string deserializedGetCharacters = Deployment.CallPhpScriptSingle(uriGetCharacters);
            string deserializedGetGames = Deployment.CallPhpScriptSingle(uriGetGames);

            YogaFrame.Characters characters = Deployment.JsonDeserialize1(deserializedGetCharacters);
            YogaFrame.Games games = Deployment.JsonDeserialize2(deserializedGetGames);
        }

        //
        // Test - Calling PHP script from .NET client WebRequest
        //
        public static string CallPhpScriptSingle(string URI)
        {
            Trace.WriteLine("CallPhpScriptSingle: Attempting WebRequest to " + URI);
            WebRequest webRequest = WebRequest.Create(URI);
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.Method = "GET";
            string strJsonResponse = string.Empty;
            try
            {
                WebResponse webResponse = webRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                strJsonResponse = streamReader.ReadToEnd();
                Trace.WriteLine("CallPhpScriptSingle: OUTPUT from streamReader.ReadToEnd(): " + strJsonResponse);
                
                streamReader.Close();
                webResponse.Close();
            }
            catch (WebException webException)
            {
                Trace.WriteLine("CallPhpScriptSingle.WebException.Message: " + webException.Message);
                Trace.WriteLine("CallPhpScriptSingle.WebException.Response: " + webException.Response);
            }

            return strJsonResponse;
        }

        public static void JsonSerialize()
        {

        }

        public static YogaFrame.Characters JsonDeserialize1(string strJson)
        {
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            YogaFrame.Characters characters = JsonConvert.DeserializeObject<YogaFrame.Characters>(strJson);

            return characters;
        }

        public static YogaFrame.Games JsonDeserialize2(string strJson)
        {
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            YogaFrame.Games games = JsonConvert.DeserializeObject<YogaFrame.Games>(strJson);

            return games;
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
}
