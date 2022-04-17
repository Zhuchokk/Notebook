using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;

namespace testApp
{

    public class Settings
    {
        public string[] used_files;
        public string theme;
        public float zoom;
        public Font font;
        public bool numbar;
        public bool statusstrip;
        public bool wordwrap;
        public bool autocomplete_enabled;
        public bool auto_popup;
        public int appear_interval;
        public int minlen_fragment;
        public string dictionary;

        public Settings()
        {
            used_files = new string[0];
            theme = "black";
            zoom = 1;
            font = new Font(FontFamily.GenericSansSerif, 8);
            numbar = true;
            statusstrip = true;
            wordwrap = true;
            autocomplete_enabled = true;
            auto_popup = true;
            appear_interval = 400;
            minlen_fragment = 2;
            dictionary = "User-English";
        }
    }
    class SettingsJson
    {
        public Settings fromJson(string path)
        {
            string text;
            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }
            Settings settings = JsonConvert.DeserializeObject<Settings>(text);
            return settings;
        }
        public void toJson(string path, Settings settings)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(JsonConvert.SerializeObject(settings));
            }
        }
    }
}
