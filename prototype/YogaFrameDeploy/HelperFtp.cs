using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Net;
using System.IO;

namespace YogaFrameDeploy
{
    class HelperFtp
    {
        public static bool UploadFile(string ftpUri, string ftpUserName, string ftpPassword, DeploymentFile deploymentFile)
        {
            bool fResult = false;
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

                //
                // If we got this far, the entire method succeeded:
                //
                fResult = true;
            }
            catch (Exception ex)
            {
                fResult = false;
                Trace.WriteLine("FtpUploadFile() failed: " + ex.Message);
            }

            return fResult;
        }
    }
}
