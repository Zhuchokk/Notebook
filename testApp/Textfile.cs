using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace testApp
{
	public class Textfile
	{
		public string path = "";
		public string text = "";
		public bool selected = true;
		public bool changed = false;
        public MenuStrip strip;
        public ToolStripMenuItem close; 
        public ToolStripMenuItem item;
		public RichTextBox textBox;

		public Textfile(ref RichTextBox box, ref MenuStrip s, ref ToolStripMenuItem i, ref ToolStripMenuItem c,string p, string t)
		{
            close = c;
			textBox = box;
            strip = s;
            item = i;
			path = p;
			text = t;
		}
		public Textfile(ref RichTextBox box, ref MenuStrip s, ref ToolStripMenuItem i, ref ToolStripMenuItem c)
		{
            close = c;
            item = i;
            strip = s;
			textBox = box;
		}
        /*~Textfile()
        {
            strip.Items.Remove(item);
            item.Visible = false;
            item.Dispose();
            item = null;
        }*/

        //functions
        public string get_extension(string file) {
            string ext = "";
            for(int i=file.Length - 1; file[i] != '.'; i--)
            {
                ext = file[i] + ext;
            }
            return ext;
        }
        public void change(bool new_value)
        {
            changed = new_value;
            if (changed && item.Text[item.Text.Length - 1] != '*') { item.Text += '*'; }
            else if(!changed && item.Text[item.Text.Length - 1] == '*') { item.Text = getname(); }
        }
        public string getname()
        {
            if (path.Length == 0)
            {
                return "Untitled";
            }

            string name = "";
            for (int i = path.Length - 1; i >= 0; i--)
            {
                if (path[i] == '/' || path[i] == '\\')
                {
                    break;
                }
                else
                {
                    name = path[i] + name;
                }
            }
            return name;
        }

        public string correct_path(string extension)
        {
            int j = extension.Length - 1;
            if (path.Length < 2 + extension.Length)
            {
                return path + "." + extension;
            }
            for(int i=path.Length - 1; i > path.Length - 1 - extension.Length; i--)
            {
                if(path[i] != extension[j]) { return path + "." + extension; }
                j -= 1;
            }
            if (path[path.Length - 1 - extension.Length] != '.')
            {
                 return path + "." + extension;
            }
            return path;
        }

        public void save()
		{
            text = textBox.Text;
            if (path == "")
            {
                save_as();
            }
            else
            {
                change(false);
                File.WriteAllText(path, text, Encoding.Default);
            }
        }
        public void save_as()
        {
            bool flag = false;
            string new_path = path;

            text = textBox.Text;
            FileDialog dialog = new SaveFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt|py files (*.py)|*.py|js files (*.js)|*.js|cpp files (*.cpp)|*.cpp|json files (*.json)|*.json|All files (*.*)|*.*";
            dialog.ShowDialog();
            if(path == "") { flag = true; }
            path = dialog.FileName;
            if (path == "") { return; }
            
            switch (dialog.FilterIndex)
            {
                case 1:
                    path = correct_path("txt");
                    break;
                case 2:
                    path = correct_path("py");
                    break;
                case 3:
                    path = correct_path("js");
                    break;
                case 4:
                    path = correct_path("cpp");
                    break;
                case 5:
                    path = correct_path("json");
                    break;
            }

            File.WriteAllText(path, text, Encoding.Default);
            if (flag) { item.Text = getname(); item.Tag = path; change(false); } else {
                path = new_path;
            }
        }
	}
}
