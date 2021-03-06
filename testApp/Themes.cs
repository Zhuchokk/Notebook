using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace testApp
{
    class ThemeFunctions
    {
        public static void install_theme_mainform(string choosed_theme,  ref MainForm mainform)
        {
            /*ref RichTextBox richtextbox, ref LineNumbers.LineNumbers_For_RichTextBox numbar, ref MenuStrip filestrip,*/
            if (choosed_theme.ToLower() == "black")
            {
                BlackTheme theme = new BlackTheme();
                mainform.richTextBox1.BackColor = theme.richbox_back;
                mainform.richTextBox1.ForeColor = theme.richbox_text;
            }
            else
            {
                WhiteTheme theme = new WhiteTheme();
            }
            
        }
    }

    class BlackTheme
    {
        public Color richbox_back = Color.FromArgb(43, 43, 43);
        public Color richbox_text = Color.FromArgb(169, 183, 198);

        public Color numbar_back = Color.FromArgb(49, 51, 53);
        public Color numbar_text = Color.FromArgb(96, 99, 102);

        public Color filestrip_back = Color.FromArgb(60, 63, 65);
        public Color filestrip_selected = Color.FromArgb(78, 82, 84);
        public Color filestrip_close = Color.FromArgb(102, 110, 114);
        public Color filestrip_text = Color.FromArgb(187, 187, 187);

        public Color statusstrip_back = Color.FromArgb(60, 63, 65);
        public Color statusstrip_text = Color.FromArgb(175, 177, 179);

        public Color menustrip_back = Color.FromArgb(60, 63, 65);
        public Color menustrip_text = Color.FromArgb(187, 187, 187);
        public Color menustrip_item_back = Color.FromArgb(60, 63, 65);
        public Color menustrip_item_text = Color.FromArgb(187, 187, 187);
        public Color menustrip_sepator = Color.FromArgb(81, 81, 81); //located in renders

        public Color child_form_back = Color.FromArgb(60, 63, 65);
        public Color child_form_text = Color.FromArgb(187, 187, 187);
        public Color child_form_close = Color.FromArgb(168, 168, 169);
        public Color child_form_but_back = Color.FromArgb(76, 80, 82);
        public Color child_form_but_text = Color.FromArgb(187, 187, 187);
        public Color child_form_but_clicked = Color.FromArgb(70, 109, 148);
        public Color child_form_entry_back = Color.FromArgb(69, 73, 74);


        public Color complete_back = Color.FromArgb(70, 72, 74);
        public Color complete_text = Color.FromArgb(187, 187, 187);
        public Color complete_selected_text = Color.FromArgb(71, 86, 81);
        public Color complete_selected_back = Color.FromArgb(181, 184, 187);
        public Color highlight_complete = Color.FromArgb(68, 186, 239);


    }
    class WhiteTheme
    {
        public Color richbox_back = Color.FromArgb(255, 255, 255);
        public Color richbox_text = Color.FromArgb(0, 0, 0);

        public Color numbar_back = Color.FromArgb(240, 240, 240);
        public Color numbar_text = Color.FromArgb(153, 153, 153);

        public Color filestrip_back = Color.FromArgb(242, 242, 242);
        public Color filestrip_selected = Color.FromArgb(250, 250, 250);
        public Color filestrip_close = Color.FromArgb(189, 195, 198);
        public Color filestrip_text = Color.FromArgb(0, 0, 0);

        public Color statusstrip_back = Color.FromArgb(242,242, 242);
        public Color statusstrip_text = Color.FromArgb(0, 0, 0);

        public Color menustrip_back = Color.FromArgb(242, 242, 242);
        public Color menustrip_text = Color.FromArgb(0, 0, 0);
        public Color menustrip_item_back = Color.FromArgb(242, 242,242);
        public Color menustrip_item_text = Color.FromArgb(0, 0, 0);
        public Color menustrip_sepator = Color.FromArgb(205, 205, 205); //located in renders

        public Color child_form_back = Color.FromArgb(242, 242, 242);
        public Color child_form_text = Color.FromArgb(0, 0, 0);
        public Color child_form_close = Color.FromArgb(7, 9, 10);
        public Color child_form_but_back = Color.FromArgb(227, 227, 227);
        public Color child_form_but_text = Color.FromArgb(0, 0, 0);
        public Color child_form_but_clicked = Color.FromArgb(7, 132, 222);
        public Color child_form_entry_back = Color.FromArgb(255, 255, 255);

        public Color complete_back = Color.FromArgb(247, 247, 247);
        public Color complete_text = Color.FromArgb(0, 0, 0);
        public Color complete_selected_text = Color.FromArgb(0, 0, 0);
        public Color complete_selected_back = Color.FromArgb(224, 224, 224);
        public Color highlight_complete = Color.FromArgb(68, 186, 239);
    }
}
