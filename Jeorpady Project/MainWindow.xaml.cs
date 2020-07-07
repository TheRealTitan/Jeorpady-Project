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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	///
	public partial class MainWindow : Window
	{
		static BrushConverter converter = new BrushConverter();
		static Brush blueBrush = (Brush)converter.ConvertFromString("#0e1684");

		public MainWindow()
		{
			InitializeComponent();

			new BoardWindow();
			Main.Content = new MainMenu();
		}

		private void EscapeWindowHandler(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Escape)
			{
				Application.Current.Shutdown();
			}

			if(e.Key == Key.Enter)
			{
				Main.Content = new MainMenu();
			}

			if (e.Key == Key.End)
			{
				Main.Content = new ScoreBoard();
			}
		}

		private void DisplayMenu()
		{		
			Grid grid = new Grid();

			grid.Children.Clear();
			grid.Background = blueBrush;

			this.Content = grid;
		}
	}
}
