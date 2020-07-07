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
	/// Interaction logic for PreItemDisplay.xaml
	/// </summary>
	public partial class PreItemDisplay : Page
	{
		public PreItemDisplay()
		{
			InitializeComponent();
		}

		public PreItemDisplay(JeopardyItem item)
		{
			if (item.ItemType == Categories.TEXT)
			{
				throw new Exception("Wrong turn!");
			}
			else
			{
				Button button = new Button();
				button.Click += NextBtn;
				button.Tag = item;

				Viewbox viewbox = new Viewbox();
				TextBlock text = new TextBlock();
				text.Text = "NEXT";
				text.TextWrapping = TextWrapping.Wrap;

				viewbox.Child = text;
				button.Content = viewbox;

				this.Content = button;
			}
		}

		private void NextBtn(object sender, RoutedEventArgs e)
		{
			Button button = ((Button)sender);
			JeopardyItem item = (JeopardyItem)button.Tag;

			((MainWindow)Application.Current.MainWindow).Main.Content = new ItemDisplay(item);
			((BoardWindow)HelpingMethods.GetBoardWindow()).Board.Content = new BoardItemDisplay(item);
		}
	}
}
