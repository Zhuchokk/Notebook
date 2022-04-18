using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace testApp
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public delegate void Active();

	public partial class MainForm : Form
	{
		public Textfile[] textfiles = { };
		Settings settings = new Settings();
		string Jsonfile = Application.StartupPath + @"\settings.json";
		int index = 0;
		bool open = false;


		public MainForm()
		{
			InitializeComponent();
			settings = new SettingsJson().fromJson(Jsonfile);
			preparing();
		}

		private void preparing()
        {
			for (int i = 0; i < settings.used_files.Length; i++)
			{
				if (!File.Exists(settings.used_files[i])) { continue; }
				ToolStripMenuItem s = new ToolStripMenuItem();
				ToolStripMenuItem close = get_close_item();
				close.Click += new EventHandler(close_clicked);
				s.Click += new EventHandler(menuitem_clicked);
				menuStrip1.Items.Add(s);
				menuStrip1.Items.Add(close);
				Array.Resize(ref textfiles, textfiles.Length + 1);
				textfiles[textfiles.Length - 1] = new Textfile(ref richTextBox1, ref menuStrip1, ref s, ref close);
				textfiles[textfiles.Length - 1].path = settings.used_files[i];
				textfiles[textfiles.Length - 1].text = File.ReadAllText(textfiles[textfiles.Length - 1].path, System.Text.Encoding.Default);

				s.Text = textfiles[textfiles.Length - 1].getname();
				s.Tag = textfiles[textfiles.Length - 1].path;
				close.Tag = textfiles[textfiles.Length - 1].path;
			}
			if(textfiles.Length > 0)
            {
				select_file(0);
            }
            else
            {
				ToolStripMenuItem s = new ToolStripMenuItem();
				ToolStripMenuItem close = get_close_item();
				close.Click += new EventHandler(close_clicked);
				s.Click += new EventHandler(menuitem_clicked);
				menuStrip1.Items.Add(s);
				menuStrip1.Items.Add(close);
				Array.Resize(ref textfiles, textfiles.Length + 1);
				textfiles[textfiles.Length - 1] = new Textfile(ref richTextBox1, ref menuStrip1, ref s, ref close);
				textfiles[textfiles.Length - 1].path = "";
				textfiles[textfiles.Length - 1].text = "";

				s.Text = "Untitled";
				s.Tag = 1;
				close.Tag = 1;
				select_file(0);
			}

			//тема
			richTextBox1.ZoomFactor = settings.zoom;
			richTextBox1.Font = settings.font;
			lineNumbers_For_RichTextBox1.Visible = settings.numbar;
			statusStrip1.Visible = settings.statusstrip;
			richTextBox1.WordWrap = settings.wordwrap;
			autocompleteMenu1.Enabled = settings.autocomplete_enabled;
			autocompleteMenu1.AutoPopup = settings.auto_popup;
			autocompleteMenu1.AppearInterval = settings.appear_interval;
			autocompleteMenu1.MinFragmentLength = settings.minlen_fragment;
            if (settings.dictionary == "User-All")
            {
                autocompleteMenu1.Items = split(File.ReadAllText(Application.StartupPath + @"\dictionaries\" + "user-russian.txt", System.Text.Encoding.Default) + "\n" + File.ReadAllText(Application.StartupPath + @"\dictionaries\" + "user-english.txt", System.Text.Encoding.Default));
            }
            else
            {
                autocompleteMenu1.Items = split(File.ReadAllText(Application.StartupPath + @"\dictionaries\" + settings.dictionary + ".txt", System.Text.Encoding.Default));
            }

            Console.WriteLine(autocompleteMenu1.Items[0] + autocompleteMenu1.Items[1]);
		}

		public string[] split(string text)
		{
			string[] words = { };
			string word = "";

			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '\n')
				{
					Array.Resize(ref words, words.Length + 1);
					word = word.Replace("\r", String.Empty);
					words[words.Length - 1] = word;
					word = "";
				}
				else
				{
					
					word += text[i];
				}
			}
			return words;
		}
		public static Textfile[] RemoveElementDefAt(object[] oldList, int removeIndex)
		{
			Textfile[] newElementDefList = new Textfile[oldList.Length - 1];

			int offset = 0;
			for (int index = 0; index < oldList.Length; index++)
			{
				Textfile elementDef = oldList[index] as Textfile;
				if (index == removeIndex)
				{
					//  This is the one we want to remove, so we won't copy it.  But 
					//  every subsequent elementDef will by shifted down by one.
					offset = -1;
				}
				else
				{
					newElementDefList[index + offset] = elementDef;
				}
			}
			return newElementDefList;
		}

		private void select_file(int ind)
        {
			for(int i=0; i < textfiles.Length; i++)
            {
                if (i == ind) { textfiles[i].selected = true; open = true; richTextBox1.Text = textfiles[i].text; index = i; textfiles[i].item.BackColor = SystemColors.ControlDark; textfiles[i].close.BackColor = SystemColors.ControlDark; } 
				else { textfiles[i].selected = false; textfiles[i].item.BackColor = SystemColors.Control; textfiles[i].close.BackColor = SystemColors.Control; }
            }
			
        }
		private void close_clicked(object sender, EventArgs e)
        {
			Console.WriteLine("Close!");
			ToolStripMenuItem current = (ToolStripMenuItem)sender;
			for(int i=0; i < textfiles.Length; i++)
            {
				if(current.Tag == textfiles[i].close.Tag)
                {
                    if (textfiles[i].changed)
                    {
						Console.WriteLine("Yep close");
						DialogResult result = MessageBox.Show("Do you want to save changes ?", "Notebook", MessageBoxButtons.YesNoCancel);
						if(result == DialogResult.Yes)
                        {
							textfiles[i].save();
                        } else if(result == DialogResult.Cancel)
                        {
							return;
                        }
					}
					

					textfiles[i].item.Dispose();
					textfiles[i].close.Dispose();
					textfiles[i] = null;
					textfiles =  RemoveElementDefAt(textfiles, i);
					/*Array.Clear(textfiles, i, 1);*/
					open = true;
					if (textfiles.Length == 0)
                    {
						
						richTextBox1.Text = "";
						richTextBox1.Enabled = false;
                    }
                    else
                    {
						richTextBox1.Enabled = true;
						select_file(0);
						/*richTextBox1.Text = textfiles[0].text;*/
                    }
                }
            }
			
        }
		private ToolStripMenuItem get_close_item()
        {
			ToolStripMenuItem Etalon = new ToolStripMenuItem();
			Etalon.AutoSize = false;
			Etalon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			Etalon.Image = Etalon_close.Image;
			Etalon.Name = "close";
			Etalon.Padding = new System.Windows.Forms.Padding(0);
			Etalon.Size = new System.Drawing.Size(20, 20);
			return Etalon;
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (textfiles.Length > 0) { textfiles[index].text = richTextBox1.Text; }
			ToolStripMenuItem s = new ToolStripMenuItem();
			ToolStripMenuItem close = get_close_item();

			menuStrip1.Items.Add(s);
			menuStrip1.Items.Add(close);
			close.Click += new EventHandler(close_clicked);
			s.Click += new EventHandler(menuitem_clicked);
			int free = 1;
			foreach (ToolStripMenuItem i in menuStrip1.Items)
            {
				if(i.Tag == Convert.ToString(free))
                {
					free += 1;
                }
            }
			s.Tag = Convert.ToString(free);
			close.Tag = Convert.ToString(free); 
			s.Text = "Untitled";
			Array.Resize(ref textfiles, textfiles.Length + 1);
			textfiles[textfiles.Length - 1] = new Textfile(ref richTextBox1,ref menuStrip1, ref s, ref close);
			select_file(textfiles.Length - 1);
			richTextBox1.Enabled = true;
			position();
		}

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
			textfiles[index].text = richTextBox1.Text;
			textfiles[index].save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
			textfiles[index].text = richTextBox1.Text;
			textfiles[index].save_as();
		}

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (open) { open = false; return; }
			textfiles[index].change(true);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
			open = true;
			if(textfiles.Length > 0) { textfiles[index].text = richTextBox1.Text; }
			
			openFileDialog1.ShowDialog();
            if (!File.Exists(openFileDialog1.FileName)) { return; }
			ToolStripMenuItem s = new ToolStripMenuItem();
			ToolStripMenuItem close = get_close_item();
			close.Click += new EventHandler(close_clicked);
			s.Click += new EventHandler(menuitem_clicked);
			menuStrip1.Items.Add(s);
			menuStrip1.Items.Add(close);
			Array.Resize(ref textfiles, textfiles.Length + 1);
			textfiles[textfiles.Length - 1] = new Textfile(ref richTextBox1, ref menuStrip1, ref s, ref close);
			select_file(textfiles.Length - 1);
			textfiles[index].path = openFileDialog1.FileName;
			textfiles[index].text = File.ReadAllText(textfiles[index].path, System.Text.Encoding.Default);
            
			s.Text = textfiles[index].getname();
			s.Tag = textfiles[index].path;
			close.Tag = textfiles[index].path;
			richTextBox1.Text = textfiles[index].text;
			textfiles[index].change(false);
			richTextBox1.Enabled = true;
			position();
		}
		private void menuitem_clicked(object sender, EventArgs e)
        {
			open = true;
			ToolStripMenuItem s = (ToolStripMenuItem)sender;
			Console.WriteLine(s.Tag);
			textfiles[index].text = richTextBox1.Text;
			for(int i=0; i < textfiles.Length; i++)
            {
				if(s.Tag == textfiles[i].item.Tag)
                {

					select_file(i);
					open = true;
					richTextBox1.Text = textfiles[i].text;
					break;
                }
            }
			position();
		}
		private void exit(object sender, EventArgs e)
        {
			// НАДО ДОДЕЛАТЬ(например добавить файл .json)
			Console.WriteLine("Exit");
			Application.Exit();
        } // доделать

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
			exit(sender, e);
        }

		private void position()
        {
			string col = Convert.ToString(richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine() + 1);
			string ln = Convert.ToString(richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1);
			NumLabel.Text = "Ln " + ln + ", Col " + col;
		}

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
			position();
			zoom();
        }  

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
			position();
			zoom();
        } 

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
			richTextBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
			richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
			richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
			richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
			richTextBox1.SelectedText = "";
        }

        private void searchWithGoogleToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if(richTextBox1.SelectedText.Length == 0) { return; }
			string current = "";
			string forbidden_symbols = "?!";
			for(int i=0; i<richTextBox1.SelectedText.Length; i++)
            {
				if(richTextBox1.SelectedText[i] == ' ')
                {
					current += "+";
                } else if( !forbidden_symbols.Contains(Convert.ToString( richTextBox1.SelectedText[i])))
                {
					current += richTextBox1.SelectedText[i];
                }
            }

			Process testing = Process.Start("https://www.google.com/search?q=" + current);

		}

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
			
			Active func;
			func = this.Activate;
			Form find = new FindForm(ref richTextBox1, func);
			find.Show();
			
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Active func;
			func = this.Activate;
			Form replace = new ReplaceForm(ref richTextBox1, func);
			replace.Show();
		}

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
			richTextBox1.SelectAll();
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
			DateTime date = DateTime.Now;
			richTextBox1.Text += date.ToShortDateString();
		}

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
			position();
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if(richTextBox1.ZoomFactor + 0.1 <= 5)
            {
				richTextBox1.ZoomFactor = (float)(richTextBox1.ZoomFactor + 0.1);
				zoom();
			}
			
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (richTextBox1.ZoomFactor - 0.1 >= 0.1)
			{
				richTextBox1.ZoomFactor = (float)(richTextBox1.ZoomFactor - 0.1);
				zoom();
			}
		}
		private void zoom()
        {
			ZoomLabel.Text = Convert.ToString(richTextBox1.ZoomFactor * 100) + "%";
        }
        private void restoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
			richTextBox1.ZoomFactor = 1;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FontDialog fontDialog = new FontDialog();
			fontDialog.ShowDialog();
			Font font = fontDialog.Font;

		} //закончить

        private void numbarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        } //закончить

        private void toolStripToolStripMenuItem_Click(object sender, EventArgs e)
        {

        } //закончить

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {

        } //закончить

        private void autocompleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Form autocomplete = new AutocompleteForm(ref settings, ref autocompleteMenu1);
			autocomplete.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
			Form recognition = new RecognitionForm();
			recognition.Show();
        }

        private void readTheTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Form synthesizer = new SynthesizerForm();
			synthesizer.Show();
        }
    }
    
}
