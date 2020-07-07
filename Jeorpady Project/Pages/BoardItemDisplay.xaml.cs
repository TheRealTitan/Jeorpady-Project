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
	/// Interaction logic for BoardItemDisplay.xaml
	/// </summary>
	public partial class BoardItemDisplay : Page
	{
		static BrushConverter converter = new BrushConverter();
		static Brush blueBrush = (Brush)converter.ConvertFromString("#0e1684");

		public BoardItemDisplay()
		{
			InitializeComponent();
		}

		public BoardItemDisplay(JeopardyItem item)
		{
			InitializeComponent();

			Grid grid = new Grid();
			grid.Background = blueBrush;

			Viewbox viewbox = HelpingMethods.GenerateViewBox(item.Question, Brushes.White, false);

			grid.Children.Add(viewbox);
			this.Content = grid;
		}
	}
}
