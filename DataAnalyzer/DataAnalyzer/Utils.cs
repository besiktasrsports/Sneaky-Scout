using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAnalyzer
{
    public class Utils
    {

        public static void runPython(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";//"my/full/path/to/python.exe";
            start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardInput = true;
            using (Process process = Process.Start(start))
            {
                Console.WriteLine(process.StartInfo.Arguments);
            }
        }

        public static string getTBADataFromEndpoint(string endpoint)
        {
            if (!String.IsNullOrEmpty(Config.TBA_API_KEY))
            {
                using (HttpRequest httpReq = new HttpRequest())
                {
                    httpReq.AddHeader("X-TBA-Auth-Key", Config.TBA_API_KEY);
                    httpReq.IgnoreProtocolErrors = true;
                    httpReq.ConnectTimeout = 5000;

                    try
                    {

                        string response = httpReq.Get("https://www.thebluealliance.com/api/v3" + endpoint).ToString();

                        if (response == String.Empty || response == null)
                        {
                            MessageBox.Show("Could not get data from TBA!");
                            return String.Empty;
                        }
                        
                        return response;

                        
                    }
                    catch
                    {
                        MessageBox.Show("Could not get data from TBA!");
                        return String.Empty;
                    }
                }
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Please set your TBA API key in config.yml!","",MessageBoxButtons.OK,icon:MessageBoxIcon.Error);
                return String.Empty;
            }
        }

        public static string FormatMatchKey(string matchKey)
        {
            //2022tuis2_f1m1

            string matchType = matchKey.TrimStart(Config.EVENT_ID.ToCharArray());
            if(matchType.Contains("_") || matchType.Contains("\""))
            {
                matchType = matchType.Trim('_','"');
            }

            return matchType;
            
        }
        
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public static string getBetween(string strSource, string strStart,
                                         string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }
    }
}
