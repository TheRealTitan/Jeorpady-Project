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
	/// Interaction logic for Menu.xaml
	/// </summary>
	public partial class MainMenu : Page
	{
		public MainMenu()
		{
			InitializeComponent();
		}

		private void BtnStart(object sender, RoutedEventArgs e)
		{
			((MainWindow)Application.Current.MainWindow).Main.Content = new BoardMenu();
		}

		private void BtnExit(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
