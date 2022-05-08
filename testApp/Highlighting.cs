using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace testApp
{
    public class Highlighting
    {
        public string pykeys;
        public string cppkeys;
        public string jskeys;

        public Highlighting()
        {
            using (StreamReader reader = new StreamReader(Application.StartupPath + @"\dictionaries\py.txt"))
            {
                pykeys = "(" + reader.ReadToEnd().Replace("\r\n", "|");

                Console.WriteLine(pykeys);
            }
            using (StreamReader reader = new StreamReader(Application.StartupPath + @"\dictionaries\cpp.txt"))
            {
                cppkeys = "(" + reader.ReadToEnd().Replace("\r\n", "|");
            }
            using (StreamReader reader = new StreamReader(Application.StartupPath + @"\dictionaries\js.txt"))
            {
                jskeys = "(" + reader.ReadToEnd().Replace("\r\n", "|");
            }
        }
        public void some_strings_highlight(ref RichTextBox textBox, int index_str, Textfile selected_file)
        {
            int[] strings = { index_str};
            string keywords;


            if(textBox.Lines.Length - 1 > index_str)
            {
                Array.Resize(ref strings, strings.Length + 1);
                strings[strings.Length - 1] = index_str + 1;
            }
            if(index_str > 0)
            {
                Array.Resize(ref strings, strings.Length + 1);
                strings[strings.Length - 1] = index_str - 1;
            }

            if (selected_file.get_extension(selected_file.path) == "py")
            {
                keywords = pykeys;
            } else if(selected_file.get_extension(selected_file.path) == "cpp")
            {
                keywords = cppkeys;
            } else if(selected_file.get_extension(selected_file.path) == "js")
            {
                keywords = jskeys;
            }
            else
            {
                return;
            }

            keywords += @"|\([^()]*\)|";
            keywords += "[" + @"\" + "\"'][^" + @"\" + "\"']*[" + @"\" + "\"']|";
            keywords += @" [^() ]*\(.{0,}\) |";
            keywords += ")";
            // for (this text) \([^()]*\)
            // for 'this' or "this" text [\"'][^\"']*[\"']
            //  for titles [^() ]*\(.{0,}\)
            Console.WriteLine("Indexes:" + strings.Length + " Index str " + index_str + " lines " + textBox.Lines.Length);
            int start_index = textBox.SelectionStart;


            foreach(int ln_index in strings)
            {
                foreach(Match match in Regex.Matches(textBox.Lines[ln_index], keywords))
                {
                    if (match.Success)
                    {
                        Console.WriteLine("Value:" + match.Value + " index " + match.Index + " 123 ");
                        textBox.Select(textBox.GetFirstCharIndexFromLine(ln_index)  + match.Index, match.Value.Length);
                        textBox.SelectionColor = Color.Aqua;
                        textBox.Select(start_index, 0);
                        
                    }
                    
                }
            }
        }
    }
}
