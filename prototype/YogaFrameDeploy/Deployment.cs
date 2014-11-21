using System.Collections.Generic;

namespace YogaFrameDeploy
{
    public class Deployment
    {
        #region Stub methods
        public static void DatabaseDeploy()
        {
            
        }

        public static void DatabaseBackup()
        {

        }
        #endregion

        public static void ExecuteNonQuery()
        {
            string strMySqlConnection = HelperMySql.LocalGetConnectionString();

            string[] rg_strMySqlCommands = new string[]
            {
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Members_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Members_create.txt"),                
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Dapplers_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Dapplers_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_create.txt"),                
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Characters_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Characters_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetGames_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetGames_create.txt"),
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
                HelperMySql.ExecuteNonQuery(strMySqlConnection, strMySqlCommand);
            }
        }

        public static void ExecuteQuery()
        {
            string strMySqlConnection = HelperMySql.LocalGetConnectionString();
            string strMySqlCommand = "SELECT * FROM tbl_Characters";
            HelperMySql.ExecuteQuery(strMySqlConnection, strMySqlCommand);
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
                HelperFtp.UploadFile(ftpUri, ftpUserName, ftpPassword, deploymentFile);
            }            
        }

        public static void DeployFullService()
        {
            //
            // Test out the various deployment methods
            //
            Deployment deployment = new Deployment();
            Deployment.ExecuteNonQuery();
            Deployment.ExecuteQuery();
            Deployment.DeployFiles();            
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
