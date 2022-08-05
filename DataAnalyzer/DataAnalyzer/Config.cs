using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.RepresentationModel;

namespace DataAnalyzer
{
    public static class Config
    {
        public static void Load()
        {
            try
            {
                StringReader input =
                       new StringReader(new StreamReader("config.yml").ReadToEnd());
                YamlStream yamlStream = new YamlStream();
                yamlStream.Load(input);
                YamlMappingNode yamlMappingNode =
                    (YamlMappingNode)yamlStream.Documents[0].RootNode;

                Config.TBA_API_KEY = yamlMappingNode["tba_api_key"].ToString();
                Config.EVENT_ID = yamlMappingNode["event_id"].ToString();
                Config.HIGHLIGHTED_TEAM = yamlMappingNode["highlighted_team"].ToString();
                Config.DATA_DIR = yamlMappingNode["data_dir"].ToString();
                Config.SCRIPTS_DIR = yamlMappingNode["scripts_dir"].ToString();
            }
            catch
            {
                MessageBox.Show("Invalid / Missing Config.");
                Environment.Exit(0);
            }
        }

        public static string TBA_API_KEY;

        public static string EVENT_ID;

        public static string HIGHLIGHTED_TEAM;

        public static string DATA_DIR;

        public static string SCRIPTS_DIR;
    }
}
