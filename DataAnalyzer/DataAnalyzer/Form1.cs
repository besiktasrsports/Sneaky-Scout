using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }

    }

    
}
