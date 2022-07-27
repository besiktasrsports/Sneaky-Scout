using CefSharp;
using CefSharp.WinForms;
using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HttpStatusCode = Leaf.xNet.HttpStatusCode;

namespace DataAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        ChromiumWebBrowser chrome;
       
        private void Form1_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.EnableHighDPISupport();
            Cef.Initialize(settings);
            chrome = new ChromiumWebBrowser("https://www.thebluealliance.com/event/2022hop#rankings");
            this.panel1.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                while (true)
                {
                    UpdateUI();
                }
            }).Start();

        }

        private void QRButton_Click(object sender, EventArgs e)
        {
            Helpers.runPython("QR-Reader\\main.py","" );
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
                    httpReq.AddHeader("X-TBA-Auth-Key", "DV7ILacUNlmvVF126hDVNwINg15LpvwZ004JxrwpE49ftCmlD8XdeZCItp92JoYL");
                    httpReq.IgnoreProtocolErrors = true;
                    httpReq.ConnectTimeout = 5000;
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

            Thread.Sleep(30000);
        }

        private void RefreshTBAButton_Click(object sender, EventArgs e)
        {
            this.chrome.Load("https://www.thebluealliance.com/event/2022hop#rankings"); //TODO: Change this url according to the event ID
        }
    }

    
}
