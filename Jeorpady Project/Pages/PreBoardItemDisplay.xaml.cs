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
	/// Interaction logic for PreBoardItemDisplay.xaml
	/// </summary>
	public partial class PreBoardItemDisplay : Page
	{
		public PreBoardItemDisplay()
		{
			InitializeComponent();
		}

		public PreBoardItemDisplay(JeopardyItem item)
		{
			InitializeComponent();
			
			if (item.ItemType == Categories.IMAGE)
			{
				Grid grid = new Grid();
				Image image = new Image();
				string filepath = System.IO.Path.GetFullPath(item.MediaUrl);
				Uri uri = new Uri(filepath);
				image.Source = new BitmapImage(uri);
				grid.Children.Add(image);
				this.Content = grid;
			}
			else
			{
				throw new Exception("Another wrong turn");
			}
		}
	}
}
