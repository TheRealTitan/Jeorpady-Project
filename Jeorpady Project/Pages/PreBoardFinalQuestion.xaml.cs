using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jeorpady_Project
{
	/// <summary>
	/// Interaction logic for PreBoardFinalQuestion.xaml
	/// </summary>
	public partial class PreBoardFinalQuestion : Page
	{
		static BrushConverter converter = new BrushConverter();
		static Brush blueBrush = (Brush)converter.ConvertFromString("#0e1684");
		static Brush yellowBrush = (Brush)converter.ConvertFromString("#d6aa4c");

		public PreBoardFinalQuestion()
		{
			InitializeComponent();

			Grid grid = new Grid();
			grid.Background = blueBrush;

			grid.Children.Add(HelpingMethods.GenerateViewBox("Sats...", Brushes.White, false));

			this.Content = grid;
		}
	}
}
