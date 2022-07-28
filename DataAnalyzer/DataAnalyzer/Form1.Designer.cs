namespace DataAnalyzer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.OpenDataFolderButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MatchesPlayedTxt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MatchesPlayedTBALbl = new System.Windows.Forms.Label();
            this.MatchesPlayedSDLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LastMatchSDLbl = new System.Windows.Forms.Label();
            this.LastMatchTBALbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.RefreshLocalDataBtn = new System.Windows.Forms.Button();
            this.RefreshTBAButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.TBAConnectedLbl = new System.Windows.Forms.Label();
            this.OnlineLbl = new System.Windows.Forms.Label();
            this.HighlightedTeamLbl = new System.Windows.Forms.Label();
            this.UpcomingMatchLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1100, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 187);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.QRButton_Click);
            // 
            // OpenDataFolderButton
            // 
            this.OpenDataFolderButton.Location = new System.Drawing.Point(1100, 209);
            this.OpenDataFolderButton.Name = "OpenDataFolderButton";
            this.OpenDataFolderButton.Size = new System.Drawing.Size(207, 57);
            this.OpenDataFolderButton.TabIndex = 5;
            this.OpenDataFolderButton.Text = "Open Data Folder";
            this.OpenDataFolderButton.UseVisualStyleBackColor = true;
            this.OpenDataFolderButton.Click += new System.EventHandler(this.OpenDataFolderButton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(288, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 680);
            this.panel1.TabIndex = 6;
            // 
            // MatchesPlayedTxt
            // 
            this.MatchesPlayedTxt.Location = new System.Drawing.Point(1100, 284);
            this.MatchesPlayedTxt.Name = "MatchesPlayedTxt";
            this.MatchesPlayedTxt.Size = new System.Drawing.Size(206, 36);
            this.MatchesPlayedTxt.TabIndex = 7;
            this.MatchesPlayedTxt.Text = "Matches Played:";
            this.MatchesPlayedTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1097, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "TBA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1203, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Scout Data:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MatchesPlayedTBALbl
            // 
            this.MatchesPlayedTBALbl.Location = new System.Drawing.Point(1100, 349);
            this.MatchesPlayedTBALbl.Name = "MatchesPlayedTBALbl";
            this.MatchesPlayedTBALbl.Size = new System.Drawing.Size(103, 17);
            this.MatchesPlayedTBALbl.TabIndex = 11;
            this.MatchesPlayedTBALbl.Text = "0";
            this.MatchesPlayedTBALbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MatchesPlayedSDLbl
            // 
            this.MatchesPlayedSDLbl.Location = new System.Drawing.Point(1227, 349);
            this.MatchesPlayedSDLbl.Name = "MatchesPlayedSDLbl";
            this.MatchesPlayedSDLbl.Size = new System.Drawing.Size(103, 17);
            this.MatchesPlayedSDLbl.TabIndex = 12;
            this.MatchesPlayedSDLbl.Text = "0";
            this.MatchesPlayedSDLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1103, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Last Match:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LastMatchSDLbl
            // 
            this.LastMatchSDLbl.Location = new System.Drawing.Point(1204, 435);
            this.LastMatchSDLbl.Name = "LastMatchSDLbl";
            this.LastMatchSDLbl.Size = new System.Drawing.Size(103, 17);
            this.LastMatchSDLbl.TabIndex = 17;
            this.LastMatchSDLbl.Text = "0";
            this.LastMatchSDLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LastMatchTBALbl
            // 
            this.LastMatchTBALbl.Location = new System.Drawing.Point(1100, 435);
            this.LastMatchTBALbl.Name = "LastMatchTBALbl";
            this.LastMatchTBALbl.Size = new System.Drawing.Size(103, 17);
            this.LastMatchTBALbl.TabIndex = 16;
            this.LastMatchTBALbl.Text = "0";
            this.LastMatchTBALbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(1203, 406);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Scout Data:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(1097, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "TBA:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RefreshLocalDataBtn
            // 
            this.RefreshLocalDataBtn.Location = new System.Drawing.Point(1100, 472);
            this.RefreshLocalDataBtn.Name = "RefreshLocalDataBtn";
            this.RefreshLocalDataBtn.Size = new System.Drawing.Size(206, 48);
            this.RefreshLocalDataBtn.TabIndex = 18;
            this.RefreshLocalDataBtn.Text = "Refresh Local Data";
            this.RefreshLocalDataBtn.UseVisualStyleBackColor = true;
            this.RefreshLocalDataBtn.Click += new System.EventHandler(this.RefreshLocalDataBtn_Click);
            // 
            // RefreshTBAButton
            // 
            this.RefreshTBAButton.Location = new System.Drawing.Point(1100, 526);
            this.RefreshTBAButton.Name = "RefreshTBAButton";
            this.RefreshTBAButton.Size = new System.Drawing.Size(207, 48);
            this.RefreshTBAButton.TabIndex = 19;
            this.RefreshTBAButton.Text = "Refresh TBA";
            this.RefreshTBAButton.UseVisualStyleBackColor = true;
            this.RefreshTBAButton.Click += new System.EventHandler(this.RefreshTBAButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(26, 41);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(222, 62);
            this.button5.TabIndex = 20;
            this.button5.Text = "View Teams";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(26, 123);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(222, 62);
            this.button6.TabIndex = 21;
            this.button6.Text = "Compare";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(26, 209);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(222, 62);
            this.button7.TabIndex = 22;
            this.button7.Text = "View Matches";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // TBAConnectedLbl
            // 
            this.TBAConnectedLbl.ForeColor = System.Drawing.Color.Red;
            this.TBAConnectedLbl.Location = new System.Drawing.Point(23, 624);
            this.TBAConnectedLbl.Name = "TBAConnectedLbl";
            this.TBAConnectedLbl.Size = new System.Drawing.Size(225, 17);
            this.TBAConnectedLbl.TabIndex = 24;
            this.TBAConnectedLbl.Text = "TBA Connected ";
            this.TBAConnectedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OnlineLbl
            // 
            this.OnlineLbl.ForeColor = System.Drawing.Color.Red;
            this.OnlineLbl.Location = new System.Drawing.Point(23, 654);
            this.OnlineLbl.Name = "OnlineLbl";
            this.OnlineLbl.Size = new System.Drawing.Size(225, 17);
            this.OnlineLbl.TabIndex = 25;
            this.OnlineLbl.Text = "Online";
            this.OnlineLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HighlightedTeamLbl
            // 
            this.HighlightedTeamLbl.Location = new System.Drawing.Point(23, 349);
            this.HighlightedTeamLbl.Name = "HighlightedTeamLbl";
            this.HighlightedTeamLbl.Size = new System.Drawing.Size(225, 17);
            this.HighlightedTeamLbl.TabIndex = 26;
            this.HighlightedTeamLbl.Text = "Team #";
            this.HighlightedTeamLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpcomingMatchLbl
            // 
            this.UpcomingMatchLbl.Location = new System.Drawing.Point(23, 378);
            this.UpcomingMatchLbl.Name = "UpcomingMatchLbl";
            this.UpcomingMatchLbl.Size = new System.Drawing.Size(225, 228);
            this.UpcomingMatchLbl.TabIndex = 27;
            this.UpcomingMatchLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 726);
            this.Controls.Add(this.UpcomingMatchLbl);
            this.Controls.Add(this.HighlightedTeamLbl);
            this.Controls.Add(this.OnlineLbl);
            this.Controls.Add(this.TBAConnectedLbl);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.RefreshTBAButton);
            this.Controls.Add(this.RefreshLocalDataBtn);
            this.Controls.Add(this.LastMatchSDLbl);
            this.Controls.Add(this.LastMatchTBALbl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MatchesPlayedSDLbl);
            this.Controls.Add(this.MatchesPlayedTBALbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MatchesPlayedTxt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OpenDataFolderButton);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sneaky Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button OpenDataFolderButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label MatchesPlayedTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MatchesPlayedTBALbl;
        private System.Windows.Forms.Label MatchesPlayedSDLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LastMatchSDLbl;
        private System.Windows.Forms.Label LastMatchTBALbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button RefreshLocalDataBtn;
        private System.Windows.Forms.Button RefreshTBAButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label TBAConnectedLbl;
        private System.Windows.Forms.Label OnlineLbl;
        private System.Windows.Forms.Label HighlightedTeamLbl;
        private System.Windows.Forms.Label UpcomingMatchLbl;
    }
}

