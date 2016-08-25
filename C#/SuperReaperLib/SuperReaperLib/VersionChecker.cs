using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace SuperReaperLib
{

    public class VersionChecker
    {
        /// <summary>
        /// Version Format = Major.Minor.Revision.Build.
        /// </summary>
        private string currentVersion;
        private string mostRecentVersion;
        private string remoteVersionNumberLink;
        private VersionCheckerCallback callback;

        /// <summary>
        /// Sets the remote version link for the version checker and sets the current version to check against then checks the version.
        /// </summary>
        /// <param name="remoteVersionNumberLink"> A link to a text file where the Most recent version number is stored. </param>
        /// <param name="currentVersion"> The current version of the program. </param>
        public VersionChecker(string remoteVersionNumberLink, string currentVersion, VersionCheckerCallback cb)
        {
            callback = cb;
            this.remoteVersionNumberLink = remoteVersionNumberLink;
            this.currentVersion = currentVersion;
        }

        public void CheckVersion()
        {
            WebClient web = new WebClient();
            try
            {
                mostRecentVersion = web.DownloadString(remoteVersionNumberLink);
            }
            catch (WebException) { mostRecentVersion = currentVersion; }
            finally
            {
                web.Dispose();
            }
            callback.OnVersionChecked(mostRecentVersion == currentVersion);
        }

        public string GetCurrentVersion() { return currentVersion; }
        public string GetMostRecentVersion() { return mostRecentVersion; }
    }
}
