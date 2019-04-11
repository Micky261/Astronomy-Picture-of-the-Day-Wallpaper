using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows.Forms;

namespace APoD_Wallpaper {
    public enum Style : int {
        Tiled,
        Centered,
        Stretched
    }

    static class Program {
        static string picText;
        static string picPath;
        static APoDMainForm form;
        static DateTime lastDownload;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new APoDMainForm();

            startBackgroundTasks();
            setWallpaper();

            Application.Run(form);
        }

        private static void startBackgroundTasks() {
            System.Timers.Timer timer = new System.Timers.Timer(TimeSpan.FromHours(1).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(setWallpaper);
            timer.Start();
        }

        public static void setWallpaper(object sender, ElapsedEventArgs e) {
            setWallpaper();
        }

        public static void setWallpaper() {
            string today = DateTime.Today.ToString("yyyy MMMM d", new CultureInfo("en-US"));

            //Process webpage, download image and extract text
            tryDownload(DateTime.Today);

            //Set Wallpaper in Windows
            Style s;

            switch (Properties.Settings.Default.BackgroundFilling) {
                case "Tiled": s = Style.Tiled; break;
                case "Centered": s = Style.Centered; break;
                default: s = Style.Stretched; break;
            }

            Wallpaper.set(picPath, s);

            //Set explanation in Tray Icon
            form.changeExplanation(today, picText);
        }

        private static void tryDownload(DateTime today) {
            try {
                string day = today.ToString("yyyy MMMM d", new CultureInfo("en-US"));

                string webContent = getWebpage(today);
                string pictureURL = getPictureURL(webContent, day);
                picText = Utilities.tidyUpNewLines(Utilities.removeHTMLTags(getPictureText(webContent)));

                using (WebClient webClient = new WebClient()) {
                    picPath = Properties.Settings.Default.FilePath + "\\" + day + pictureURL.Substring(pictureURL.LastIndexOf("."));
                    if (DateTime.Compare(lastDownload, today) < 0)
                        webClient.DownloadFile(pictureURL, picPath);
                }

                lastDownload = today;
                //## Add text
                //if (Properties.Settings.Default.TextOnImages)
            } catch (Exception ex) {
                tryDownload(today.AddDays(-1));
            }
        }

        private static string getPictureText(string webContent) {
            int indexOfExplanation = webContent.IndexOf("<b> Explanation: </b>") + "<b> Explanation: </b>\n".Length;
            int indexOfTextEnd = indexOfExplanation + Regex.Match(webContent.Substring(indexOfExplanation), @"<p>[ ]*<center>").Index /*webContent.Substring(indexOfExplanation).IndexOf("<p> <center>")*/;

            string expl = webContent.Substring(indexOfExplanation, indexOfTextEnd - indexOfExplanation);

            return expl;
        }

        private static string getPictureURL(string webContent, string today) {
            int indexOfDate = webContent.Substring(100).IndexOf(today) + 100;
            int indexOfLink = indexOfDate + webContent.Substring(indexOfDate).IndexOf("href") + 6; //6 for \\ href=" //
            int indexOfClosingApostrophe = indexOfLink + webContent.Substring(indexOfLink).IndexOf("\"");

            string url = webContent.Substring(indexOfLink, indexOfClosingApostrophe - indexOfLink);

            if (url.StartsWith("ftp") || url.StartsWith("http"))
                return url;
            else
                return "https://apod.nasa.gov/apod/" + url;
        }

        private static string getWebpage(DateTime today) {
            string day = today.ToString("yMMdd", new CultureInfo("en-US"));
            string urlAddress = "https://apod.nasa.gov/apod/ap" + day + ".html";

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();

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

    static class Wallpaper {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public static void set(string filePath, Style style) {
            string tempPath = "";

            using (System.Drawing.Image img = System.Drawing.Image.FromFile(Path.GetFullPath(filePath))) {
                tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
                img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            if (style == Style.Stretched) {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Centered) {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Tiled) {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                tempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);

        }
    }
}