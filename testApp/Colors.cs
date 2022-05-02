using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace testApp
{
	class Black_CustomProfessionalColors : ProfessionalColorTable
	{
		public override Color MenuItemSelected
		{ get { return Color.FromArgb(51, 51, 52); } }

		public override Color ImageMarginGradientBegin => Color.FromArgb(60, 63, 65);
		public override Color ImageMarginGradientEnd => Color.FromArgb(60, 63, 65);


		public override Color MenuBorder
		{ get { return Color.Transparent; } }

		public override Color MenuItemSelectedGradientBegin
		{ get { return Color.FromArgb(64, 64, 66); } }

		public override Color MenuItemSelectedGradientEnd
		{ get { return Color.FromArgb(64, 64, 66); } }

		public override Color MenuItemBorder
		{ get { return Color.FromArgb(51, 51, 52); } }

		public override Color MenuItemPressedGradientBegin
		{ get { return Color.FromArgb(27, 27, 28); } }

		public override Color MenuItemPressedGradientEnd
		{ get { return Color.FromArgb(27, 27, 28); } }

		public override Color MenuStripGradientBegin
		{ get { return Color.FromArgb(51, 51, 52); } }

		public override Color MenuStripGradientEnd
		{ get { return Color.FromArgb(51, 51, 52); } }

		public override Color ToolStripDropDownBackground
		{
			get { return Color.FromArgb(60, 63, 65); }
		}
	}
	class Black_CustomProfessionalColors_files : Black_CustomProfessionalColors
	{
		public override Color MenuItemSelectedGradientBegin
		{ get { return Color.FromArgb(78, 82, 84); } }

		public override Color MenuItemSelectedGradientEnd
		{ get { return Color.FromArgb(78, 82, 84); } }

	}
	class White_CustomProfessionalColors : ProfessionalColorTable
	{
		public override Color MenuItemSelected
		{ get { return Color.FromArgb(204, 204, 203); } }

		public override Color ImageMarginGradientBegin => Color.FromArgb(195, 192, 190);
		public override Color ImageMarginGradientEnd => Color.FromArgb(195, 192, 190);

		public override Color MenuBorder
		{ get { return Color.Transparent; } }

		public override Color MenuItemSelectedGradientBegin
		{ get { return Color.FromArgb(191, 191, 189); } }

		public override Color MenuItemSelectedGradientEnd
		{ get { return Color.FromArgb(191, 191, 189); } }

		public override Color MenuItemBorder
		{ get { return Color.FromArgb(204, 204, 203); } }

		public override Color MenuItemPressedGradientBegin
		{ get { return Color.FromArgb(228, 228, 227); } }

		public override Color MenuItemPressedGradientEnd
		{ get { return Color.FromArgb(228, 228, 227); } }

		public override Color MenuStripGradientBegin
		{ get { return Color.FromArgb(204, 204, 203); } }

		public override Color MenuStripGradientEnd
		{ get { return Color.FromArgb(204, 204, 203); } }

		public override Color ToolStripDropDownBackground
		{
			get { return Color.FromArgb(195, 192, 190); }
		}
	}
	class White_CustomProfessionalColors_files : White_CustomProfessionalColors
	{
		public override Color MenuItemSelectedGradientBegin
		{ get { return Color.FromArgb(250, 250, 250); } }

		public override Color MenuItemSelectedGradientEnd
		{ get { return Color.FromArgb(250, 250, 250); } }

	}
}
