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
	/// Interaction logic for BoardMenu.xaml
	/// </summary>
	public partial class BoardMenu : Page
	{
		public BoardMenu()
		{
			InitializeComponent();
		}

		private void StartGame(object sender, RoutedEventArgs e)
		{
			if (JeopardyBoard.Categories != null && JeopardyBoard.Categories.Count() > 0 && JeopardyBoard.Players.Count > 0)
			{
				HelpingMethods.GetBoardWindow().Show();
				((BoardWindow)HelpingMethods.GetBoardWindow()).Board.Content = new Board();
				((MainWindow)Application.Current.MainWindow).Main.Content = new Board();
				
			}
			else
			{
				MessageBox.Show("No board generated", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}

		}

		private void GoToSetPlayers(object sender, RoutedEventArgs e)
		{
			((MainWindow)Application.Current.MainWindow).Main.Content = new SetPlayers();
		}

		private void GoToSetBoard(object sender, RoutedEventArgs e)
		{
			((MainWindow)Application.Current.MainWindow).Main.Content = new SetBoard();
		}

		private void BackToainMenuBtn(object sender, RoutedEventArgs e)
		{
			((MainWindow)Application.Current.MainWindow).Main.Content = new MainMenu();
		}
	}
}
