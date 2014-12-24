﻿using System.Collections.Generic;
using System.Diagnostics;

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

        public static bool ExecuteNonQuery()
        {
            string strMySqlConnection = HelperMySql.LocalGetConnectionString();

            string[] rg_strMySqlCommands = new string[]
            {
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_InputSequences_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_InputSequences_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Members_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Members_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Moves_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Moves_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Dapplers_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Dapplers_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_create.txt"),                
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Characters_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Characters_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetInputSequences_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetInputSequences_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetMembers_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetMembers_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetMoves_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetMoves_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetDapplers_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetDapplers_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetGames_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetGames_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostCharacter_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostCharacter_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostDappler_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostDappler_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostGame_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostGame_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostInputSequence_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostInputSequence_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostMember_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostMember_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostMove_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostMove_create.txt"),
            };

            bool fResult = true;
            foreach (string strMySqlCommand in rg_strMySqlCommands)
            {
                bool fResultExecuteNonQuery = HelperMySql.ExecuteNonQuery(strMySqlConnection, strMySqlCommand);
                if (false == fResultExecuteNonQuery)
                {
                    fResult = false;
                    Trace.WriteLine("Deployment.ExecuteNonQuery: An ExecuteNonQuery job failed. Fail and bail...");
                    break;
                }
            }

            return fResult;
        }

        public static bool ExecuteQuery()
        {
            string strMySqlConnection = HelperMySql.LocalGetConnectionString();
            string strMySqlCommand = "SELECT * FROM tbl_Characters";
            bool fResult = false;
            fResult = HelperMySql.ExecuteQuery(strMySqlConnection, strMySqlCommand);

            return fResult;
        }

        //
        // Upload PHP scripts to web host via ftp
        //
        public static bool DeployFiles()
        {
            //
            // Grab ftp connection info from local settings file
            //
            string ftpUri = Properties.Settings.Default.FtpUri;
            string ftpUserName = Properties.Settings.Default.FtpUserName;
            string ftpPassword = Properties.Settings.Default.FtpPassword;
            
            List<DeploymentFile> listDeploymentFiles = new List<DeploymentFile>();

            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetMembers.php",
                "//public_html//YogaFrame//GetMembers.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetMoves.php",
                "//public_html//YogaFrame//GetMoves.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetInputSequences.php",
                "//public_html//YogaFrame//GetInputSequences.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetDapplers.php",
                "//public_html//YogaFrame//GetDapplers.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\PostDappler.php",
                "//public_html//YogaFrame//PostDappler.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Util.php",
                "//public_html//YogaFrame//Util.php")
                );
            listDeploymentFiles.Add( new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetCharacters.php",
                "//public_html//YogaFrame//GetCharacters.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\PostCharacter.php",
                "//public_html//YogaFrame//PostCharacter.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\PostGame.php",
                "//public_html//YogaFrame//PostGame.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\PostInputSequence.php",
                "//public_html//YogaFrame//PostInputSequence.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\PostMember.php",
                "//public_html//YogaFrame//PostMember.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                 ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\PostMove.php",
                 "//public_html//YogaFrame//PostMove.php")
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

            bool fResult = true;
            foreach (DeploymentFile deploymentFile in listDeploymentFiles)
            {
                bool fResultUploadFile = HelperFtp.UploadFile(ftpUri, ftpUserName, ftpPassword, deploymentFile);
                if (false == fResultUploadFile)
                {
                    fResult = false;
                    Trace.WriteLine("DeployFiles: A file deployment job failed. Fail and bail...");
                    break;
                }
            }

            return fResult;
        }

        public static bool DeployFullService()
        {
            //
            // Execute the full batch of deployment jobs
            //
            bool fResult = false;
            fResult = Deployment.ExecuteNonQuery();
            if (true == fResult)
            {
                fResult = Deployment.ExecuteQuery();
                if (true == fResult)
                {
                    fResult = Deployment.DeployFiles();
                }
            }

            return fResult;
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
