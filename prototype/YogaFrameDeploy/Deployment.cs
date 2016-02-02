using System.Collections.Generic;
using System.Diagnostics;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.TemplateEmailsJsonTypes;

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
            #region MySQL deployment script list
            string[] rg_strMySqlCommands = new string[]
            {
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_InputSequences_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_InputSequences_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Members_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Members_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Moves_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Moves_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Pulses_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Pulses_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Sessions_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Sessions_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Dapplers_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Dapplers_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Characters_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_Characters_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_TemplateEmails_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\tbl_TemplateEmails_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\function_MemberExistsEmailAddress_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\function_MemberExistsEmailAddress_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\function_MemberExistsAlias_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\function_MemberExistsAlias_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\function_MemberValidateCredentials_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\function_MemberValidateCredentials_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetInputSequences_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetInputSequences_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetMemberByAlias_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetMemberByAlias_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetMembers_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetMembers_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetPulses_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetPulses_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetSessionByMemberId_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetSessionByMemberId_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetSessions_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetSessions_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetMoves_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetMoves_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetDapplers_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetDapplers_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetGames_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetGames_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetTemplateEmails_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_GetTemplateEmails_create.txt"),
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
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostPulse_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostPulse_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostSession_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostSession_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostTemplateEmail_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_PostTemplateEmail_create.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_UpdateMember_drop.txt"),
                HelperMySql.GenerateQueryString(@".\Scripts.MySQL\procedure_UpdateMember_create.txt"),
            };
            #endregion
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
            #region PHP deployment script list
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GandalfBridge.php",
                "//public_html//YogaFrame//GandalfBridge.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetMembers.php",
                "//public_html//YogaFrame//GetMembers.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetMoves.php",
                "//public_html//YogaFrame//GetMoves.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetPulses.php",
                "//public_html//YogaFrame//GetPulses.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetTemplateEmails.php",
                "//public_html//YogaFrame//GetTemplateEmails.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetSessions.php",
                "//public_html//YogaFrame//GetSessions.php")
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
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\JSession.php",
                "//public_html//YogaFrame//JSession.php")
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
                 ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\PostPulse.php",
                 "//public_html//YogaFrame//PostPulse.php")
                 );
            listDeploymentFiles.Add(new DeploymentFile(
                 ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\PostSession.php",
                 "//public_html//YogaFrame//PostSession.php")
                 );
            listDeploymentFiles.Add(new DeploymentFile(
                 ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\PostTemplateEmail.php",
                 "//public_html//YogaFrame//PostTemplateEmail.php")
                 );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetGames.php",
                "//public_html//YogaFrame//GetGames.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Dispatch.php",
                "//public_html//YogaFrame//Dispatch.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Session.php",
                "//public_html//YogaFrame//Session.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Dapplers.php",
                "//public_html//YogaFrame//Dapplers.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Characters.php",
                "//public_html//YogaFrame//Characters.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Games.php",
                "//public_html//YogaFrame//Games.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\InputSequences.php",
                "//public_html//YogaFrame//InputSequences.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Members.php",
                "//public_html//YogaFrame//Members.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Moves.php",
                "//public_html//YogaFrame//Moves.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Pulses.php",
                "//public_html//YogaFrame//Pulses.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Sessions.php",
                "//public_html//YogaFrame//Sessions.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\TemplateEmails.php",
                "//public_html//YogaFrame//TemplateEmails.php")
                );
            listDeploymentFiles.Add(new DeploymentFile(
                ".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\Trace.php",
                "//public_html//YogaFrame//Trace.php")
                );
            #endregion
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
        public static string DeployTemplateEmails()
        {
            string strResult = string.Empty;

            //
            // Post the "Verify your account" template email
            // to the web service. This is an administrative task.
            //
            DeploymentSettings deploymentSettings = new DeploymentSettings();
            TblTemplateEmail[] rgTblTemplateEmail = new TblTemplateEmail[1];
            rgTblTemplateEmail[0] = new TblTemplateEmail();
            rgTblTemplateEmail[0].ColHeaders = deploymentSettings.TemplateEmail_VerifyYourAccount_Headers;
            rgTblTemplateEmail[0].ColSubject = deploymentSettings.TemplateEmail_VerifyYourAccount_Subject;
            rgTblTemplateEmail[0].ColMessage = deploymentSettings.TemplateEmail_VerifyYourAccount_Message;
            TemplateEmails templateEmails = new TemplateEmails();
            templateEmails.TblTemplateEmails = rgTblTemplateEmail;
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostTemplateEmail(ref templateEmails);

            //
            // Copy the response code from WebPostTemplateEmail into
            // this method's return string.
            //
            strResult = jSessionWebResponse.Dispatch.Message;

            return strResult;
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
                    if (true == fResult)
                    {
                        string strResult = Deployment.DeployTemplateEmails();
                        const string SUCCESS = "S_OK";
                        if (SUCCESS != strResult)
                        {
                            fResult = false;
                        }
                    }
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

    public class DeploymentSettings
    {
        //
        // Constructor
        //
        public DeploymentSettings()
        {
            m_strConnectionString                        = Properties.Settings.Default.ConnectionString;
            m_strFtpUri                                  = Properties.Settings.Default.FtpUri;
            m_strFtpUserName                             = Properties.Settings.Default.FtpUserName;
            m_strFtpPassword                             = Properties.Settings.Default.FtpPassword;
            m_strTemplateEmail_VerifyYourAccount_Headers = Properties.Settings.Default.TemplateEmail_VerifyYourAccount_Headers;
            m_strTemplateEmail_VerifyYourAccount_Subject = Properties.Settings.Default.TemplateEmail_VerifyYourAccount_Subject;
            m_strTemplateEmail_VerifyYourAccount_Message = Properties.Settings.Default.TemplateEmail_VerifyYourAccount_Message;
        }   

        //
        // Private member variables
        //
        private string m_strConnectionString;
        private string m_strFtpUri;
        private string m_strFtpUserName;
        private string m_strFtpPassword;
        private string m_strTemplateEmail_VerifyYourAccount_Headers;
        private string m_strTemplateEmail_VerifyYourAccount_Subject;
        private string m_strTemplateEmail_VerifyYourAccount_Message;

        //
        // Public Property accessors
        //
        public string ConnectionString                        { get { return m_strConnectionString; } }
        public string FtpUri                                  { get { return m_strFtpUri; } }
        public string FtpUserName                             { get { return m_strFtpUserName; } }
        public string FtpPassword                             { get { return m_strFtpPassword; } }
        public string TemplateEmail_VerifyYourAccount_Headers { get { return m_strTemplateEmail_VerifyYourAccount_Headers; } }
        public string TemplateEmail_VerifyYourAccount_Subject { get { return m_strTemplateEmail_VerifyYourAccount_Subject; } }
        public string TemplateEmail_VerifyYourAccount_Message { get { return m_strTemplateEmail_VerifyYourAccount_Message; } }
    }
}
