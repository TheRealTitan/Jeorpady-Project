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
	/// Interaction logic for Board.xaml
	/// </summary>
	public partial class Board : Page
	{
		public Board()
		{
			InitializeComponent();

			#region built shit
			Grid grid = new Grid();
			//grid.VerticalAlignment = VerticalAlignment.Stretch;
			//grid.HorizontalAlignment = HorizontalAlignment.Stretch;

			BrushConverter converter = new BrushConverter();
			Brush blueBrush = (Brush)converter.ConvertFromString("#0e1684");
			grid.Background = blueBrush;

			Console.WriteLine("Categories: " + JeopardyBoard.Categories.Count());
			
			int counter = 0;

			foreach(JeopardyCategory c in JeopardyBoard.Categories)
			{
				grid.ColumnDefinitions.Add(new ColumnDefinition());

				Label category = new Label();
				category.SetValue(Grid.ColumnProperty, counter);
				category.SetValue(Grid.RowProperty, 0);
				category.Content = c.CategoryName;
				category.Background = blueBrush;
				category.HorizontalAlignment = HorizontalAlignment.Center;
				category.VerticalAlignment = VerticalAlignment.Center;
				
				grid.Children.Add(category);

				for (int i = 0; i < c.Items.Length; i++)
				{
					if (grid.RowDefinitions.Count - 1 <= i)
					{
						grid.RowDefinitions.Add(new RowDefinition());
					}
					if(c.Items[i] != null && c.Items[i].HasBeenAnswered == false)
					{
						Button button = new Button();
						c.Items[i].Points = (i + 1) * JeopardyBoard.DefaultPoints;
						button.Content = c.Items[i].Points;
						button.Margin = new Thickness(5, 5, 5, 5);
						button.SetValue(Grid.ColumnProperty, counter);
						button.SetValue(Grid.RowProperty, i + 1);
						button.Tag = c.Items[i];
						button.Click += Button_Click;
						grid.Children.Add(button);
					}
					else
					{
						Label label = new Label();
						label.Margin = new Thickness(5, 5, 5, 5);
						label.SetValue(Grid.ColumnProperty, counter);
						label.SetValue(Grid.RowProperty, i + 1);
						grid.Children.Add(label);
					}

					Console.WriteLine(i + ", "+ counter);
				}
				counter++;
			}
			Console.WriteLine(grid.Children.Count);

			this.Content = grid;

			if (JeopardyBoard.Categories.FirstOrDefault(x => x.Items.Count(y => y.HasBeenAnswered == false) > 0) == null)
			{
				Console.WriteLine("Done");
				if (JeopardyBoard.HasFinalQuestion())
				{
					((MainWindow)Application.Current.MainWindow).Main.Content = ""; //TODO: Final Question
				}
				else
				{
					((MainWindow)Application.Current.MainWindow).Main.Content = new ScoreBoard(); //Game Over Page (ScoreBoard)
				}
			}
			#endregion

			foreach(JeopardyPlayer player in JeopardyBoard.Players)
			{
				Console.WriteLine(player.Name + ": " + player.Points);
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			IJeopardyItem item = (IJeopardyItem)((Button)sender).Tag;
			item.HasBeenAnswered = true;

			((MainWindow)Application.Current.MainWindow).Main.Content = new ItemDisplay(item);
		}
	}
}
