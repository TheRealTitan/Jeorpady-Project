using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
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
		static BrushConverter converter = new BrushConverter();
		static Brush blueBrush = (Brush)converter.ConvertFromString("#0e1684");
		static Brush yellowBrush = (Brush)converter.ConvertFromString("#d6aa4c");

		public Board()
		{
			InitializeComponent();

			#region built shit
			DockPanel mainPanel = new DockPanel();
			mainPanel.Background = blueBrush;
			mainPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
			mainPanel.VerticalAlignment = VerticalAlignment.Stretch;

			UniformGrid grid = new UniformGrid();
			grid.Rows = 1;
			grid.Columns = 0;
			grid.SetValue(DockPanel.DockProperty, Dock.Top);

			foreach (JeopardyCategory cat in JeopardyBoard.Categories)
			{
				grid.Columns++;
				Border borderCat = GenerateBorder(0, 0);
				Label category = GenerateCategory(cat);

				borderCat.Child = category;
				grid.Children.Add(borderCat);
			}

			for(int i = 0; true; i++)
			{
				if (JeopardyBoard.Categories.Where(x => x.Items.Count() > i).Count() == 0)
				{
					break;
				}

				grid.Rows++;
				foreach (JeopardyCategory cat in JeopardyBoard.Categories)
				{
					if (cat.Items.Length > i && cat.Items[i] != null && cat.Items[i].HasBeenAnswered == false)
					{
						Border border = GenerateBorder(0, 0);
						Button button = GenerateItem(cat.Items[i], i + 1);
						button.Click += Button_Click;
						border.Child = button;
						grid.Children.Add(border);
					}
					else
					{
						Border border = GenerateBorder(0, 0);
						Label label = GenerateEmptyItem();
						border.Child = label;
						grid.Children.Add(border);
					}
				}
			}

			StackPanel scorePanel = new StackPanel();
			scorePanel.Orientation = Orientation.Horizontal;
			scorePanel.MaxHeight = 80;
			scorePanel.SetValue(DockPanel.DockProperty, Dock.Bottom);
			foreach (JeopardyPlayer player in JeopardyBoard.Players)
			{
				Viewbox viewbox = HelpingMethods.GenerateViewBox(player.Name + ": " + player.Points, Brushes.White, false);
				viewbox.Margin = new Thickness(20, 5, 20, 5);
				scorePanel.Children.Add(viewbox);
			}

			mainPanel.Children.Add(grid);
			mainPanel.Children.Add(scorePanel);

			this.Content = mainPanel;
			
			#endregion
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			JeopardyItem item = (JeopardyItem)((Button)sender).Tag;
			item.HasBeenAnswered = true;

			if (item.ItemType == Categories.TEXT)
			{
				((BoardWindow)HelpingMethods.GetBoardWindow()).Board.Content = new BoardItemDisplay(item);
				((MainWindow)Application.Current.MainWindow).Main.Content = new ItemDisplay(item);
			}
			else
			{
				((BoardWindow)HelpingMethods.GetBoardWindow()).Board.Content = new PreBoardItemDisplay(item);
				((MainWindow)Application.Current.MainWindow).Main.Content = new PreItemDisplay(item);
			}
		}

		private static Label GenerateCategory(JeopardyCategory category)
		{
			Label label = new Label();
			label.Background = blueBrush;
			label.Content = HelpingMethods.GenerateViewBox(category.CategoryName.ToUpper(), Brushes.White, false);
			label.Background = blueBrush;
			label.HorizontalAlignment = HorizontalAlignment.Stretch;
			label.VerticalAlignment = VerticalAlignment.Stretch;

			return label;
		}

		private static Label GenerateEmptyItem()
		{
			Label label = new Label();
			label.Background = blueBrush;
			label.HorizontalAlignment = HorizontalAlignment.Stretch;
			label.VerticalAlignment = VerticalAlignment.Stretch;

			return label;
		}

		private static Button GenerateItem(JeopardyItem item, int xCord)
		{
			Button button = new Button();
			button.Background = blueBrush;
			item.Points = xCord * JeopardyBoard.DefaultPoints;
			button.Content = HelpingMethods.GenerateViewBox(item.Points.ToString(), yellowBrush, true);
			
			button.Tag = item;

			return button;
		}

		private static Border GenerateBorder(int xCord, int yCord)
		{
			Border border = new Border();
			border.BorderThickness = new Thickness(5);
			border.BorderBrush = Brushes.Black;
			//border.SetValue(Grid.ColumnProperty, xCord);
			//border.SetValue(Grid.RowProperty, yCord);

			return border;
		}
	}
}
