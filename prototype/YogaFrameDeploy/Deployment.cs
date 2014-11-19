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
            // Test out Newtonsoft json.NE
            //
            HelperJson.DoThangs();

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

                // hack: dump json response to text file to avoid escape chars
                System.IO.File.WriteAllText(@"C:\scratch\jsonoutput.txt", strJsonResponse);

                string line = "";
                // now open that text file and see what we get
                try
                {
                    using (StreamReader sr = new StreamReader(@"C:\scratch\jsonoutput.txt"))
                    {                        
                        line = sr.ReadToEnd();
                        Console.WriteLine(line);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
                Trace.WriteLine("YogaWebRequest: OUTPUT from streamReader.ReadToEnd(): " + strJsonResponse);  

                // {"tbl_Characters":[{"idtbl_Characters":"1","colName":"Dhalsim","colDescription":"Stretchy limb dood."},{"idtbl_Characters":"2","colName":"Guile","colDescription":"turtleer"},{"idtbl_Characters":"3","colName":"Ryu","colDescription":"Rare character."},{"idtbl_Characters":"4","colName":"Ken","colDescription":"Underpowered dragon punch."},{"idtbl_Characters":"5","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"6","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"7","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"8","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"9","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"10","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"11","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"12","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"13","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"14","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"15","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"16","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"17","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"18","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"19","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"20","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"21","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"22","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"23","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"24","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"25","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"26","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"27","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"28","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"29","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"30","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"31","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"32","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"33","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"34","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"35","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"36","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"37","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"38","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"39","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"40","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"41","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"42","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"43","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"44","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"45","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"46","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"47","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"48","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"49","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"50","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"51","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"52","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"53","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"54","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"55","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"56","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"57","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"58","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"59","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"60","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"61","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"62","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"63","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"64","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"65","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"66","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"67","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"68","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"69","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"70","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"71","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"72","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"73","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"74","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"75","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"76","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"77","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"78","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"79","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"80","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"81","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"82","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"83","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"84","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"85","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"86","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"87","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"88","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"89","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"90","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"91","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"92","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"93","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"94","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"95","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"96","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"97","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"98","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"99","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"100","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"101","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"102","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"103","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"104","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"105","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"106","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"107","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"108","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"109","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"110","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"111","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"112","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"113","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"114","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"115","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"116","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"117","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"118","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"119","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"120","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"121","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"122","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"123","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"124","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"125","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"126","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"127","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"128","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"129","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"130","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"131","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"132","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"133","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"134","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"135","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"136","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"137","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"138","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"139","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"140","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"141","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"142","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"143","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"144","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"145","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"146","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"147","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"148","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"149","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"150","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"151","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"152","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"153","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"154","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"155","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"156","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"157","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"158","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"159","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"160","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"161","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"162","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"163","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"164","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"165","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"166","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"167","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"168","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"169","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"170","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"171","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"172","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"173","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"174","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"175","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"176","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"177","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"178","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"179","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"180","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"181","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"182","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"183","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"184","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"185","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"186","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"187","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"188","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"189","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"190","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"191","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"192","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"193","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"194","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"195","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"196","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"197","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"198","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"199","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"200","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"201","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"202","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"203","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"204","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"205","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"206","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"207","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"208","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"209","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"210","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"211","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"212","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"213","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"214","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"215","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"216","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"217","colName":"Blanka","colDescription":"Shocker"},{"idtbl_Characters":"218","colName":"Blanka","colDescription":"Shocker"}]} "";
                Deployment.JsonDeserialize(line);

                //Replace(Environment.NewLine, " ");

                //
                // convert string to stream
                //
                byte[] byteArray = Encoding.UTF8.GetBytes(strJsonResponse);
                MemoryStream streamJsonResponse = new MemoryStream(byteArray);

                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(tbl_Characters));
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

        public static void JsonSerialize()
        {

        }

        public static void JsonDeserialize(string strJson)
        {
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            
            tbl_Characters _tblCharacters = JsonConvert.DeserializeObject<tbl_Characters>(strJson);
            
            Trace.WriteLine( "JsonDeserialize: _tblCharacters.listCharacters.Count = " + _tblCharacters.listCharacters.Count.ToString() );
        }
    }
    
    public class tbl_Characters
    {
        public IList<Character> listCharacters { get; set; }
    }

    public class Character
    {
        public int idtbl_Characters { get; set; }
        public string colName { get; set; }
        public string colDescription { get; set; }
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
