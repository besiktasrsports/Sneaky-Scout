using CefSharp;
using CefSharp.WinForms;
using Leaf.xNet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
namespace DataAnalyzer
{
    public partial class Form1 : Form
    {
        string upcomingMatchesStr = "";
        Thread UIUpdateTh;
        public Form1()
        {
            InitializeComponent();
            
        }

        ChromiumWebBrowser chrome;
       
        private void Form1_Load(object sender, EventArgs e)
        {
            Config.Load();
            CefSettings settings = new CefSettings();
            Cef.EnableHighDPISupport();
            Cef.Initialize(settings);
            chrome = new ChromiumWebBrowser("https://www.thebluealliance.com/event/" + Config.EVENT_ID + "#rankings");
            this.panel1.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            if (!String.IsNullOrEmpty(Config.HIGHLIGHTED_TEAM))
            {
                if (HighlightedTeamLbl.InvokeRequired)
                {
                    HighlightedTeamLbl.Invoke(new MethodInvoker(delegate () { HighlightedTeamLbl.Text = "Team #" + Config.HIGHLIGHTED_TEAM; }));
                }
                else
                {
                    HighlightedTeamLbl.Text = "Team #" + Config.HIGHLIGHTED_TEAM;
                }
            }
            UIUpdateTh = 
            new Thread(new ThreadStart( delegate ()
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                while (true)
                {
                    UpdateUI();
                    Thread.Sleep(30000);
                }
            }));

            UIUpdateTh.Start();

        }

        private void QRButton_Click(object sender, EventArgs e)
        {
            Utils.runPython("QR-Reader\\main.py","" );
        }

        private void OpenDataFolderButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "QR-Reader\\ScoutDatas");
        }

        private void UpdateUI()
        {
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadString("https://google.com");
                Variables.isOnline = true;
            }
            catch
            {
                Variables.isOnline = false;
                Variables.isTBAConnected = false;
            }

            if (Variables.isOnline)
            {
                this.OnlineLbl.ForeColor = Color.Green;
                // Check TBA out here
                using(HttpRequest httpReq = new HttpRequest())
                {
                    httpReq.IgnoreProtocolErrors = true;
                    httpReq.ConnectTimeout = 5000;
                    httpReq.AddHeader("X-TBA-Auth-Key", Config.TBA_API_KEY);
                    try
                    {
                        if (httpReq.Get("https://www.thebluealliance.com/api/v3/status").StatusCode.ToString() == "OK")
                        {
                            Variables.isTBAConnected = true;
                            this.TBAConnectedLbl.ForeColor = Color.Green;
                            
                        }
                        else
                        {
                            Variables.isTBAConnected = false;
                            this.TBAConnectedLbl.ForeColor = Color.Red;
                        }
                    }
                    catch
                    {
                        Variables.isTBAConnected = false;
                        this.TBAConnectedLbl.ForeColor = Color.Red;
                    }

                }
            }
            else
            {
                this.OnlineLbl.ForeColor = Color.Red;
                this.TBAConnectedLbl.ForeColor = Color.Red;
            }

            // Get Highlighted Team's Upcoming Matches
            
            if (!String.IsNullOrEmpty(Config.HIGHLIGHTED_TEAM) && !String.IsNullOrEmpty(Config.EVENT_ID))
            {
                string matchJson = Utils.getTBADataFromEndpoint("/team/frc" + Config.HIGHLIGHTED_TEAM + "/event/" + Config.EVENT_ID + "/matches/simple");
                var matchList = new List<string>();
                matchList = Parse.JSON(matchJson, "actual_time", true, false).ToList();

                foreach(string time in matchList)
                {
                    if(time == null || time == String.Empty)
                    {
                        int index = matchList.IndexOf(time);
                        string matchKey = Parse.JSON(matchJson, "key", true, false).ToList()[index];
                        if (!upcomingMatchesStr.Contains(matchKey))
                        {
                            upcomingMatchesStr += matchKey + "\n";
                        }
                    }
                }

                if (String.IsNullOrEmpty(upcomingMatchesStr))
                {
                    upcomingMatchesStr = "No upcoming matches found.";
                }
                if (UpcomingMatchLbl.InvokeRequired)
                {
                    UpcomingMatchLbl.Invoke(new MethodInvoker(delegate {
                        UpcomingMatchLbl.Text = "Upcoming Matches:\n" + Utils.FormatMatchKey(upcomingMatchesStr);
                    }));
                    
                }
                


            }

            // Update played matches and check last match
            try
            {
                DirectoryInfo dataDir = new DirectoryInfo("QR-Reader\\ScoutDatas");
                if (MatchesPlayedSDLbl.InvokeRequired)
                {
                    MatchesPlayedSDLbl.Invoke(new MethodInvoker(delegate () { MatchesPlayedSDLbl.Text = (dataDir.GetFiles().Length / 6).ToString(); }));
                    
                }
                else
                {
                    MatchesPlayedSDLbl.Text = (dataDir.GetFiles().Length / 6).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Data directory not found.");
                MatchesPlayedSDLbl.Text = "0";

            }

            if (!String.IsNullOrEmpty(Config.EVENT_ID))
            {

                string matchJson = Utils.getTBADataFromEndpoint("/event/" + Config.EVENT_ID + "/matches/keys");
                if (MatchesPlayedTBALbl.InvokeRequired)
                {
                    MatchesPlayedTBALbl.Invoke(new MethodInvoker(delegate () { MatchesPlayedTBALbl.Text = matchJson.Split(',').Length.ToString(); }));

                }
                else
                {
                    MatchesPlayedTBALbl.Text = matchJson.Split(',').Length.ToString();
                }

                matchJson = Utils.getTBADataFromEndpoint("/event/" + Config.EVENT_ID + "/matches/simple");

                var matchList = new List<string>();
                matchList = Parse.JSON(matchJson, "actual_time", true, false).ToList();
                var parsedList = new List<DateTime>();
                foreach (string time in matchList)
                {
                    if (time != null && time != String.Empty)
                    {
                        parsedList.Add(Utils.UnixTimeStampToDateTime(double.Parse(time)));
                    }
                }

                int index = parsedList.IndexOf(parsedList.OrderBy(a => a.Date).ThenBy(e => e.TimeOfDay).Last());
                string latestMatch = Parse.JSON(Utils.getTBADataFromEndpoint("/event/" + Config.EVENT_ID + "/matches/simple"), "key", true, false).ToList()[index];

                if (LastMatchTBALbl.InvokeRequired)
                {
                    LastMatchTBALbl.Invoke(new MethodInvoker(delegate () { LastMatchTBALbl.Text = Utils.FormatMatchKey(latestMatch); }));
                }
                else
                {
                    LastMatchTBALbl.Text = Utils.FormatMatchKey(latestMatch);
                }
            }

           
        }

        private void RefreshTBAButton_Click(object sender, EventArgs e)
        {
            if (Variables.isOnline)
            {
                this.chrome.Load("https://www.thebluealliance.com/event/"+Config.EVENT_ID+"#rankings"); //TODO: Change this url according to the event ID
            }
            
        }

        private void RefreshLocalDataBtn_Click(object sender, EventArgs e)
        {
            if (RefreshLocalDataBtn.InvokeRequired)
            {
               RefreshLocalDataBtn.Invoke(new MethodInvoker(delegate () { UpdateUI(); }));
           }
            else
            {
                UpdateUI();
            }
        }
    }

    
}
