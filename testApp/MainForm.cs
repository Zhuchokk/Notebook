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
		public Settings settings = new Settings();
		string Jsonfile = Application.StartupPath + @"\settings.json";
		int index = 0;
		bool open = false;


		public MainForm()
		{
			
			InitializeComponent();
			settings = new SettingsJson().fromJson(Jsonfile);
			preparing();
			if(settings.theme.ToLower() == "black")
            {
				menuStrip2.Renderer = new ToolStripProfessionalRenderer(new Black_CustomProfessionalColors());
				menuStrip1.Renderer = new ToolStripProfessionalRenderer(new Black_CustomProfessionalColors_files());
			}
            else
            {

				menuStrip2.Renderer = new ToolStripProfessionalRenderer(new White_CustomProfessionalColors());
				menuStrip1.Renderer = new ToolStripProfessionalRenderer(new White_CustomProfessionalColors_files());
			}
			

		}

		public void install_theme_mainform()
		{
			
			if (settings.theme.ToLower() == "black")
			{
				BlackTheme theme = new BlackTheme();
				richTextBox1.BackColor = theme.richbox_back;
				richTextBox1.ForeColor = theme.richbox_text;

				lineNumbers_For_RichTextBox1.BackColor = theme.numbar_back;
				lineNumbers_For_RichTextBox1.ForeColor = theme.numbar_text;

				menuStrip1.BackColor = theme.filestrip_back;
				menuStrip1.ForeColor = theme.filestrip_text;
				Etalon_close.ForeColor = theme.filestrip_close;

				statusStrip1.BackColor = theme.statusstrip_back;
				statusStrip1.ForeColor = theme.statusstrip_text;

				menuStrip2.BackColor = theme.menustrip_back;
				menuStrip2.ForeColor = theme.menustrip_text;

				toolStripStatusLabel2.BackColor = theme.menustrip_sepator;
				toolStripStatusLabel2.ForeColor = theme.menustrip_sepator;

				Etalon_close.Image = Image.FromFile("krestik_black.png");
				BackColor = theme.filestrip_back;

				autocompleteMenu1.Colors.BackColor = theme.complete_back;
				autocompleteMenu1.Colors.ForeColor = theme.complete_text;
				autocompleteMenu1.Colors.HighlightingColor = theme.highlight_complete;
				autocompleteMenu1.Colors.SelectedBackColor = theme.complete_selected_back;
				autocompleteMenu1.Colors.SelectedForeColor = theme.complete_selected_text;

                foreach (ToolStripMenuItem i in menuStrip2.Items)
                {
					i.BackColor = theme.menustrip_item_back;
					i.ForeColor = theme.menustrip_item_text;
					for(int j=0; j < i.DropDownItems.Count; j++)
                    {
						
						i.DropDownItems[j].BackColor = theme.menustrip_item_back;
						i.DropDownItems[j].ForeColor = theme.menustrip_item_text;
                        try
                        {
							var s = (ToolStripMenuItem)i.DropDownItems[j];
							foreach (ToolStripMenuItem z in s.DropDownItems)
							{
								z.BackColor = theme.menustrip_item_back;
								z.ForeColor = theme.menustrip_item_text;
							}
						}
                        catch { }
					}
                }
				
			}
			else
			{
				WhiteTheme theme = new WhiteTheme();
				richTextBox1.BackColor = theme.richbox_back;
				richTextBox1.ForeColor = theme.richbox_text;

				lineNumbers_For_RichTextBox1.BackColor = theme.numbar_back;
				lineNumbers_For_RichTextBox1.ForeColor = theme.numbar_text;

				menuStrip1.BackColor = theme.filestrip_back;
				menuStrip1.ForeColor = theme.filestrip_text;
				Etalon_close.ForeColor = theme.filestrip_close;

				statusStrip1.BackColor = theme.statusstrip_back;
				statusStrip1.ForeColor = theme.statusstrip_text;

				menuStrip2.BackColor = theme.menustrip_back;
				menuStrip2.ForeColor = theme.menustrip_text;

				toolStripStatusLabel2.BackColor = theme.menustrip_sepator;
				toolStripStatusLabel2.ForeColor = theme.menustrip_sepator;

				Etalon_close.Image = Image.FromFile("krestik_white.png");
				BackColor = theme.filestrip_back;

				autocompleteMenu1.Colors.BackColor = theme.complete_back;
				autocompleteMenu1.Colors.ForeColor = theme.complete_text;
				autocompleteMenu1.Colors.HighlightingColor = theme.highlight_complete;
				autocompleteMenu1.Colors.SelectedBackColor = theme.complete_selected_back;
				autocompleteMenu1.Colors.SelectedForeColor = theme.complete_selected_text;

				foreach (ToolStripMenuItem i in menuStrip2.Items)
				{
					i.BackColor = theme.menustrip_item_back;
					i.ForeColor = theme.menustrip_item_text;
					for (int j = 0; j < i.DropDownItems.Count; j++)
					{

						i.DropDownItems[j].BackColor = theme.menustrip_item_back;
						i.DropDownItems[j].ForeColor = theme.menustrip_item_text;
						try
						{
							var s = (ToolStripMenuItem)i.DropDownItems[j];
							foreach (ToolStripMenuItem z in s.DropDownItems)
							{
								z.BackColor = theme.menustrip_item_back;
								z.ForeColor = theme.menustrip_item_text;
							}
						}
						catch { }
					}
				}
			}

		}
		public Color get_selected_file_color()
        {
			if(settings.theme.ToLower() == "black")
            {
				BlackTheme btheme = new BlackTheme();
				return btheme.filestrip_selected;
            }
			WhiteTheme theme = new WhiteTheme();
            return theme.filestrip_selected;
        }
		public Color get_unselected_file_color()
		{
			if (settings.theme.ToLower() == "black")
			{
				BlackTheme btheme = new BlackTheme();
				return btheme.filestrip_back;
			}
			WhiteTheme theme = new WhiteTheme();

            return theme.filestrip_back;
        }

		private void preparing()
        {
			install_theme_mainform();

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
				open = false;
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
			

			richTextBox1.ZoomFactor = settings.zoom;
			richTextBox1.Font = settings.font;
			zoom();

			lineNumbers_For_RichTextBox1.Visible = settings.numbar;
			lineNumbers_For_RichTextBox1.Enabled = settings.numbar;
			numbarToolStripMenuItem.Checked = settings.numbar;

			statusStrip1.Visible = settings.statusstrip;
			statusStripToolStripMenuItem.Checked = settings.statusstrip;

			EventArgs e = new EventArgs();
			object sender = new object();
			placer(sender, e);

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
                if (i == ind) { textfiles[i].selected = true; open = true; richTextBox1.Text = textfiles[i].text; index = i; textfiles[i].item.BackColor = get_selected_file_color(); textfiles[i].close.BackColor = get_selected_file_color(); } 
				else { textfiles[i].selected = false; textfiles[i].item.BackColor = get_unselected_file_color(); textfiles[i].close.BackColor = get_unselected_file_color(); }
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

					open = true;
					if (textfiles.Length == 0)
                    {
						
						richTextBox1.Text = "";
						richTextBox1.ReadOnly = true;
                    }
                    else
                    {
						richTextBox1.ReadOnly = false;
						select_file(0);
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
			richTextBox1.ReadOnly = false;
			position();
		}

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if(textfiles.Length == 0) { return; }
			textfiles[index].text = richTextBox1.Text;
			textfiles[index].save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if(textfiles.Length == 0) { return; }
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
			richTextBox1.ReadOnly = false;
			position();
		}
		private void menuitem_clicked(object sender, EventArgs e)
        {
			/*open = true;*/
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
			bool changes = false;
			for (int i=0; i < textfiles.Length; i++)
            {
                if (textfiles[i].changed) { changes = true; break; }
            }
            if (changes)
            {
				DialogResult res =  MessageBox.Show("You have unsaved changes. Do you want to exit? All unsaved changes will be deleted", "Notebook", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (res == DialogResult.No) { return; }
            }
			settings.used_files = new string[0];
			for(int i=0; i < textfiles.Length; i++)
            {
				if(textfiles[i].path.Length > 1)
                {
					Array.Resize(ref settings.used_files, settings.used_files.Length + 1);
					settings.used_files[settings.used_files.Length - 1] = textfiles[i].path;
				}
            }

			SettingsJson json = new SettingsJson();
			json.toJson(Jsonfile, settings);

			Application.Exit();
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
			ZoomLabel.Text = Convert.ToString((int)(richTextBox1.ZoomFactor * 100)) + "%";
			Font font = new Font(lineNumbers_For_RichTextBox1.Font.FontFamily, (float)(richTextBox1.Font.Size * richTextBox1.ZoomFactor));

			lineNumbers_For_RichTextBox1.Font = font;
			settings.zoom = richTextBox1.ZoomFactor;

		}
        private void restoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
			richTextBox1.ZoomFactor = 1;
			zoom();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FontDialog fontDialog = new FontDialog();
			fontDialog.ShowDialog();
			Font font = fontDialog.Font;
			richTextBox1.Font = font;
			lineNumbers_For_RichTextBox1.Font = font;
			settings.font = font;

		} 

		private void placer(object sender, EventArgs e)
        {
			if (statusStripToolStripMenuItem.Checked && numbarToolStripMenuItem.Checked)
			{
				lineNumbers_For_RichTextBox1.Dock = DockStyle.None;
				statusStrip1.Dock = DockStyle.Bottom;
				richTextBox1.Dock = DockStyle.Right;
                lineNumbers_For_RichTextBox1.Dock = DockStyle.Left;
				lineNumbers_For_RichTextBox1_Resize(sender, e);

			}
			else if (statusStripToolStripMenuItem.Checked)
			{
				statusStrip1.Dock = DockStyle.Bottom;
                richTextBox1.Dock = DockStyle.Fill;
				lineNumbers_For_RichTextBox1_Resize(sender, e);
            }
			else if (numbarToolStripMenuItem.Checked)
			{
                lineNumbers_For_RichTextBox1.Dock = DockStyle.Left;
				richTextBox1.Dock = DockStyle.Right;
				lineNumbers_For_RichTextBox1_Resize(sender, e);
			}
			else
			{
				richTextBox1.Dock = DockStyle.Fill;
			}
		}

        private void numbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
			bool delete = false;
			lineNumbers_For_RichTextBox1.Visible = !numbarToolStripMenuItem.Checked;
			lineNumbers_For_RichTextBox1.Enabled = !numbarToolStripMenuItem.Checked;
			settings.numbar = !numbarToolStripMenuItem.Checked;
			numbarToolStripMenuItem.Checked = !numbarToolStripMenuItem.Checked;

			if (richTextBox1.TextLength <= 1)
			{
				open = true;
				richTextBox1.Text += " ";
				delete = true;
			}

			placer(sender, e);

			if (delete)
			{
				open = true;
				richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
			}

        } 

        private void toolStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
			statusStrip1.Visible = !statusStripToolStripMenuItem.Checked;
			settings.statusstrip = !statusStripToolStripMenuItem.Checked;
			statusStripToolStripMenuItem.Checked = !statusStripToolStripMenuItem.Checked;

			placer(sender, e);

        } 

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
			settings.wordwrap = !wordWrapToolStripMenuItem.Checked;
			richTextBox1.WordWrap = !wordWrapToolStripMenuItem.Checked;
			wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
			
        } 

        private void autocompleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Form autocomplete = new AutocompleteForm(ref settings, ref autocompleteMenu1);
			autocomplete.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
			Form recognition = new RecognitionForm(settings);
			recognition.Show();
        }

        private void readTheTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Form synthesizer = new SynthesizerForm(settings);
			synthesizer.Show();
        }

        private void textFromFotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
			ImageForm ocr = new ImageForm(settings);
			ocr.Show();
        }

        private void puntoSwitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Active func;
			func = this.Activate;
			SwitchForm switchForm = new SwitchForm(ref richTextBox1, func, settings);
			switchForm.Show();
        }

        private void translatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
			TranslationForm translation = new TranslationForm(settings);
			translation.Show();
		}

        private void lineNumbers_For_RichTextBox1_Resize(object sender, EventArgs e)
        {
			if(lineNumbers_For_RichTextBox1.Size.Width + lineNumbers_For_RichTextBox1.Location.X == richTextBox1.Location.X) { return; }
			Point tmp = new Point(lineNumbers_For_RichTextBox1.Size.Width + lineNumbers_For_RichTextBox1.Location.X, 51);
			Size size = new Size(richTextBox1.Size.Width - (tmp.X + richTextBox1.Size.Width - this.Width+ 15), richTextBox1.Size.Height);
			richTextBox1.Location = tmp;
			richTextBox1.Size = size;

        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if(settings.theme.ToLower() == "black") { return; }
			settings.theme = "black";
			SettingsJson json = new SettingsJson();
			json.toJson(Jsonfile, settings);
			restart_themes();
        } 

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (settings.theme.ToLower() == "white") { return; }
			settings.theme = "white";
			SettingsJson json = new SettingsJson();
			json.toJson(Jsonfile, settings);
			restart_themes();
		} 

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (e.CloseReason == CloseReason.UserClosing)
            {
				e.Cancel = true;
				exit(sender, e);
			}	
        }
		private void restart_themes()
        {
			bool changes = false;
			for (int i = 0; i < textfiles.Length; i++)
			{
				if (textfiles[i].changed) { changes = true; break; }
			}
			if (changes)
			{
				DialogResult res = MessageBox.Show("You have unsaved changes. Do you want to restart and change the theme? All unsaved changes will be deleted", "Notebook", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (res == DialogResult.No) { return; }
			}
			settings.used_files = new string[0];
			for (int i = 0; i < textfiles.Length; i++)
			{
				if (textfiles[i].path.Length > 1)
				{
					Array.Resize(ref settings.used_files, settings.used_files.Length + 1);
					settings.used_files[settings.used_files.Length - 1] = textfiles[i].path;
				}
			}

			SettingsJson json = new SettingsJson();
			json.toJson(Jsonfile, settings);

			Application.Restart();
		}
    }
	
}
