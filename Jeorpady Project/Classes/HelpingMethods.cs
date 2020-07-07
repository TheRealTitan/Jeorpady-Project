using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Jeorpady_Project
{
    public static class HelpingMethods
    {
		private static BrushConverter converter = new BrushConverter();
		public static Brush blueBrush = (Brush)converter.ConvertFromString("#0e1684");
		public static Brush yellowBrush = (Brush)converter.ConvertFromString("#d6aa4c");

		public static Window GetBoardWindow()
		{
			foreach(Window win in App.Current.Windows)
			{
				if (win.Name == "BoardWindowName")
				{
					return win;
				}
			}
			return null;
		}

		public static Viewbox GenerateViewBox(string label, Brush textColor, bool hasShadow)
		{
			Viewbox viewbox = new Viewbox();

			TextBlock text = new TextBlock();
			Label outerLabel = new Label();
			text.Foreground = textColor;
			text.Text = label;
			text.TextWrapping = TextWrapping.WrapWithOverflow;
			text.FontFamily = new FontFamily("Berlin Sans FB");
			text.FontWeight = FontWeights.ExtraBold;

			if (hasShadow)
			{
				DropShadowEffect effect = new DropShadowEffect();
				effect.ShadowDepth = 0.7;
				effect.Color = Colors.Black;
				effect.Direction = 330;
				effect.Opacity = 1;
				effect.BlurRadius = 0.0;
				text.Effect = effect;
			}

			outerLabel.Content = text;
			viewbox.Child = outerLabel;

			return viewbox;
		}
	}
}
