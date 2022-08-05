using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAnalyzer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utils.runPython(Config.SCRIPTS_DIR + "\\match.py", "-tn " + Int32.Parse(comboBox1.SelectedItem.ToString()) + " -mt " + comboBox2.SelectedItem.ToString().ToLower() + " -mn " + Int32.Parse(comboBox3.SelectedItem.ToString()) + " -d " + Config.DATA_DIR);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem != null)
                {
                    if (comboBox1.SelectedItem.ToString() != String.Empty)
                    {
                        try
                        {
                            comboBox3.Items.Clear();
                            foreach (string file in Directory.GetFiles(Config.DATA_DIR + "\\" + this.comboBox2.SelectedItem.ToString().ToLower()))
                            {
                                if (file.Contains(comboBox1.SelectedItem.ToString()))
                                {
                                    string matchNum = Parse.JSON(File.ReadAllText(file), "m").First();
                                    if (!comboBox3.Items.Contains(matchNum))
                                    {
                                        comboBox3.Items.Add(matchNum);
                                    }
                                }
                            }
                        }
                        catch
                        {
                            comboBox3.Items.Clear();
                        }
                    }
                }
            }
            catch
            {

            }
                
        }
    }
}
