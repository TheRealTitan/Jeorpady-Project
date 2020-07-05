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

			#region Initialize shit
			JeopardyItemText text1 = new JeopardyItemText();
			text1.Answer = "Elsker at vinde højere end sine børn.";
			text1.Question = "";
			text1.HasBeenAnswered = false;

			JeopardyItemText text2 = new JeopardyItemText();
			text2.Answer = "Siger ofte dette: Christian, nej Martin, nej, nej Cecilia, nej, Sebastian, nej Rasmus - har du hentet";
			text2.Question = "";
			text2.HasBeenAnswered = false;

			JeopardyItemText text3 = new JeopardyItemText();
			text3.Answer = "Mikkel og Cecilia har fyldt forkert brændstof på. Og far";
			text3.Question = "";
			text3.HasBeenAnswered = false;

			JeopardyItemText text4 = new JeopardyItemText();
			text4.Answer = "Lave videoklip: far der går ind i døren (hvad blev far sur over)";
			text4.Question = "";
			text4.HasBeenAnswered = false;

			JeopardyItemText text5 = new JeopardyItemText();
			text5.Answer = "Cecilia blev væk i lanzarote lufthavn og mikkel og Seb måtte lokke personalet til at holde flyet, imens far løb rasende rundt og ledte.";
			text5.Question = "";
			text5.HasBeenAnswered = false;

			JeopardyItemText text6 = new JeopardyItemText();
			text6.Answer = "iiiiiiiih";
			text6.Question = "";
			text6.HasBeenAnswered = false;

			JeopardyCategory cat1 = new JeopardyCategory();
			cat1.CategoryName = "Hey";
			JeopardyCategory cat2 = new JeopardyCategory();
			cat2.CategoryName = "you";
			JeopardyCategory cat3 = new JeopardyCategory();
			cat3.CategoryName = "What is up!?";

			cat1.Items = new IJeopardyItem[] { text1, text2 };
			cat2.Items = new IJeopardyItem[] { text3, text4 };
			cat3.Items = new IJeopardyItem[] { text5, text6 };

			JeopardyPlayer player1 = new JeopardyPlayer();
			JeopardyPlayer player2 = new JeopardyPlayer();
			JeopardyPlayer player3 = new JeopardyPlayer();

			JeopardyBoard.Players.Add(player1);
			JeopardyBoard.Players.Add(player2);
			JeopardyBoard.Players.Add(player3);

			JeopardyBoard.Categories = new JeopardyCategory[] { cat1, cat2, cat3 };
			JeopardyBoard.MaxNumberOfRows = 3;
			JeopardyBoard.DefaultPoints = 200;
			#endregion
		}

		private void StartGame(object sender, RoutedEventArgs e)
		{
			((MainWindow)Application.Current.MainWindow).Main.Content = new Board();
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
