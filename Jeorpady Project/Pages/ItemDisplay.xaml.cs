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
	/// Interaction logic for ItemText.xaml
	/// </summary>
	public partial class ItemDisplay : Page
	{
		public static JeopardyPlayer chosenPlayer;
		public static Button nextButton;

		public ItemDisplay()
		{
			InitializeComponent();
		}

		private void KeyHandler(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
			{
				((MainWindow)Application.Current.MainWindow).Main.Content = new Board();
			}
		}

		public ItemDisplay(JeopardyItem item)
		{
			BrushConverter converter = new BrushConverter();
			Brush blueBrush = (Brush)converter.ConvertFromString("#0e1684");

			InitializeComponent();

			Grid grid = new Grid();
			grid.Background = blueBrush;
			grid.RowDefinitions.Add(new RowDefinition());
			grid.RowDefinitions.Add(new RowDefinition());
			grid.RowDefinitions.Add(new RowDefinition());

			TextBlock textBlock = new TextBlock();
			textBlock.Text = item.Answer;
			textBlock.HorizontalAlignment = HorizontalAlignment.Center;
			textBlock.VerticalAlignment = VerticalAlignment.Center;
			textBlock.FontStretch = FontStretches.UltraExpanded;
			textBlock.Foreground = Brushes.White;
			textBlock.FontSize = 22;
			textBlock.FontFamily = new FontFamily("Verdana");
			textBlock.TextWrapping = TextWrapping.Wrap;
			textBlock.SetValue(Grid.RowProperty, 0);

			
			Grid playerGrid = new Grid();
			playerGrid.SetValue(Grid.RowProperty, 1);

			int counter = 0;
			foreach (JeopardyPlayer player in JeopardyBoard.Players)
			{
				playerGrid.ColumnDefinitions.Add(new ColumnDefinition());

				Button choosePlayerButton = new Button();
				choosePlayerButton.Content = player.Name;
				choosePlayerButton.Click += ChoosePlayer;
				choosePlayerButton.SetValue(Grid.ColumnProperty, counter);
				choosePlayerButton.Tag = player;

				playerGrid.Children.Add(choosePlayerButton);

				counter++;
			}

			nextButton = new Button();
			nextButton.Tag = item;
			nextButton.SetValue(Grid.RowProperty, 2);
			nextButton.Click += MoveNext;


			grid.Children.Add(textBlock);
			grid.Children.Add(nextButton);
			grid.Children.Add(playerGrid);

			this.Content = grid;
		}

		private void MoveNext(object sender, RoutedEventArgs e)
		{
			if (chosenPlayer != null)
			{
				chosenPlayer.Points += ((JeopardyItem)((Button)sender).Tag).Points;
			}

			if (JeopardyBoard.Categories.FirstOrDefault(x => x.Items.Count(y => y.HasBeenAnswered == false) > 0) == null)
			{
				Console.WriteLine("Done");
				if (JeopardyBoard.HasFinalQuestion())
				{
					((MainWindow)Application.Current.MainWindow).Main.Content = new FinalQuestion(); //TODO: Final Question
				}
				else
				{
					((MainWindow)Application.Current.MainWindow).Main.Content = new ScoreBoard(); //Game Over Page (ScoreBoard)
				}
			}
			else
			{
				((MainWindow)Application.Current.MainWindow).Main.Content = new Board();
			}

		}

		private void ChoosePlayer(object sender, RoutedEventArgs e)
		{
			
			Button button = ((Button)sender);

			if (button.Tag == chosenPlayer)
			{
				chosenPlayer = null;
				nextButton.Content = null;
			}
			else
			{
				chosenPlayer = (JeopardyPlayer)button.Tag;
				nextButton.Content = chosenPlayer.Name;
			}
		}
	}
}
