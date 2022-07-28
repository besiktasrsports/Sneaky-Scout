using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;

namespace DataAnalyzer
{
    public static class Config
    {
        public static void Load()
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
        }

        public static string TBA_API_KEY;

        public static string EVENT_ID;

        public static string HIGHLIGHTED_TEAM;
    }
}
