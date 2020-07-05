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

			BrushConverter converter = new BrushConverter();
			Brush blueBrush = (Brush)converter.ConvertFromString("#0e1684");
			grid.Background = blueBrush;

			Console.WriteLine("Categories: " + JeopardyBoard.Categories.Count());
			
			int counter = 0;

			foreach(JeopardyCategory c in JeopardyBoard.Categories)
			{
				grid.ColumnDefinitions.Add(new ColumnDefinition());

				Label category = GenerateCategory(c, counter);
				
				grid.Children.Add(category);

				for (int i = 0; i < c.Items.Length; i++)
				{
					if (grid.RowDefinitions.Count - 1 <= i)
					{
						grid.RowDefinitions.Add(new RowDefinition());
					}
					if(c.Items[i] != null && c.Items[i].HasBeenAnswered == false)
					{
						Button button = GenerateItem(c.Items[i], counter, i + 1);
						button.Click += Button_Click;
						grid.Children.Add(button);
					}
					else
					{
						Label label = GenerateEmptyItem(counter, i + 1);
						grid.Children.Add(label);
					}

					Console.WriteLine(i + ", "+ counter);
				}
				counter++;
			}
			Console.WriteLine(grid.Children.Count);

			this.Content = grid;
			#endregion
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			JeopardyItem item = (JeopardyItem)((Button)sender).Tag;
			item.HasBeenAnswered = true;

			((MainWindow)Application.Current.MainWindow).Main.Content = new ItemDisplay(item);
		}

		private static Label GenerateCategory(JeopardyCategory category, int yCord)
		{
			BrushConverter converter = new BrushConverter();
			Brush blueBrush = (Brush)converter.ConvertFromString("#0e1684");

			Label label = new Label();
			label.SetValue(Grid.ColumnProperty, yCord);
			label.SetValue(Grid.RowProperty, 0);
			label.FontStretch = FontStretches.Expanded;
			label.Content = category.CategoryName;
			label.Background = blueBrush;
			label.HorizontalAlignment = HorizontalAlignment.Center;
			label.VerticalAlignment = VerticalAlignment.Center;

			return label;
		}

		private static Label GenerateEmptyItem(int yCord, int xCord)
		{
			Label label = new Label();
			label.Margin = new Thickness(5, 5, 5, 5);
			label.SetValue(Grid.ColumnProperty, yCord);
			label.SetValue(Grid.RowProperty, xCord);

			return label;
		}

		private static Button GenerateItem(JeopardyItem item, int yCord, int xCord)
		{
			Button button = new Button();
			item.Points = xCord * JeopardyBoard.DefaultPoints;
			button.Content = item.Points;
			button.Margin = new Thickness(5, 5, 5, 5);
			button.SetValue(Grid.ColumnProperty, yCord);
			button.SetValue(Grid.RowProperty, xCord);
			button.Tag = item;

			return button;
		}
	}
}
