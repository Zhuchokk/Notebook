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
        public Color menustrip_sepator = Color.FromArgb(81, 81, 81);

        public Color child_form_back = Color.FromArgb(60, 63, 65);
        public Color child_form_text = Color.FromArgb(187, 187, 187);
        public Color child_form_close = Color.FromArgb(168, 168, 169);
        public Color child_form_but_back = Color.FromArgb(76, 80, 82);
        public Color child_form_but_text = Color.FromArgb(187, 187, 187);
        public Color child_form_but_clicked = Color.FromArgb(70, 109, 148);
        public Color child_form_entry_back = Color.FromArgb(69, 73, 74);

        // дописать остальное. И написать класс WhiteTheme эндетичный этому. Эти классы будут выполнять роль словаря


    }
    class WhiteTheme
    {

    }
}
