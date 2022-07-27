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
    public class Helpers
    {

        public static void runPython(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";//"my/full/path/to/python.exe";
            start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                
            }
        }

        public static string getTBADataFromEndpoint(string endpoint)
        {
            using (HttpRequest httpReq = new HttpRequest())
            {
                httpReq.AddHeader("X-TBA-Auth-Key", "DV7ILacUNlmvVF126hDVNwINg15LpvwZ004JxrwpE49ftCmlD8XdeZCItp92JoYL");
                httpReq.IgnoreProtocolErrors = true;
                httpReq.ConnectTimeout = 5000;

                try
                {
                    string response = httpReq.Get("https://www.thebluealliance.com/api/v3" + endpoint).ToString();
                    return response;
                }
                catch
                {
                    MessageBox.Show("Could not get data from TBA!");
                    return "";
                }
            }   
        }
    }
}
