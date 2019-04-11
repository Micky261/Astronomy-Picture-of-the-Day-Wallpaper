using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace APoD_Wallpaper
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            startBackgroundTasks();
            setWallpaper(null, null);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new APoDMainForm());
        }

        static void startBackgroundTasks() {
            System.Timers.Timer timer = new System.Timers.Timer(TimeSpan.FromHours(1).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(setWallpaper);
            timer.Start();
        }

        private static void setWallpaper(object sender, ElapsedEventArgs e) {
            tryDownload();
        }

        private static void tryDownload() {
            string today = DateTime.Today.ToString("yyyy MMMM d", new CultureInfo("en-US"));

            string webContent = getWebpage();
            string pictureURL = getPictureURL(webContent, today);
            string pictureText = null;

            if (Properties.Settings.Default.TextOnImages)
                pictureText = tidyUpNewLines(removeLinks(getPictureText(webContent)));
            
            using (WebClient webClient = new WebClient()) {
                string filename = Properties.Settings.Default.FilePath + "\\" + today + pictureURL.Substring(pictureURL.LastIndexOf("."));
                webClient.DownloadFile(pictureURL, filename);
            }
            //## Add text
        }

        private static string tidyUpNewLines(string text) {
            return Regex.Replace(text, "([^\r\n])\u000D\u000A|[\u000A\u000B\u000C\u000D\u0085\u2028\u2029](?=[^\r\n])", "$1 ").Replace("\n ", "\n");
        }

        private static string removeLinks(string text) {
            return Regex.Replace(text, @"<[^>]*>", "");
        }

        private static string getPictureText(string webContent) {
            int indexOfExplanation = webContent.IndexOf("<b> Explanation: </b>") + "<b> Explanation: </b>\n\n".Length;
            int indexOfTextEnd = indexOfExplanation + webContent.Substring(indexOfExplanation).IndexOf("<p><center>");

            string expl = webContent.Substring(indexOfExplanation, indexOfTextEnd - indexOfExplanation);

            return expl;
        }

        private static string getPictureURL(string webContent, string today) {
            int indexOfDate                 = webContent.IndexOf(today);
            int indexOfLink                 = indexOfDate + webContent.Substring(indexOfDate).IndexOf("href") + 6; //6 for \\ href=" //
            int indexOfClosingApostrophe    = indexOfLink + webContent.Substring(indexOfLink).IndexOf("\"");

            string url                      = webContent.Substring(indexOfLink, indexOfClosingApostrophe - indexOfLink);

            if (url.StartsWith("ftp") || url.StartsWith("http"))
                return url;
            else
                return "https://apod.nasa.gov/apod/" + url;
        }

        private static string getWebpage() {
            string urlAddress = "https://apod.nasa.gov/apod/astropix.html";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string data = null;

            if (response.StatusCode == HttpStatusCode.OK) {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return data;
        }
    }

    static class Utilities {
        public static string tidyUpNewLines(string text) {
            return Regex.Replace(text, "([^\r\n])\u000D\u000A|[\u000A\u000B\u000C\u000D\u0085\u2028\u2029](?=[^\r\n])", "$1 ").Replace("\n ", "\n").Replace("  ", " ");
            ;
        }

        public static string removeHTMLTags(string text) {
            return Regex.Replace(text, @"<[^>]*>", "");
        }
    }
}