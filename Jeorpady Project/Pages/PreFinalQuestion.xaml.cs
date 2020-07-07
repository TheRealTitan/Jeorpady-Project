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
	/// Interaction logic for PreFinalQuestion.xaml
	/// </summary>
	public partial class PreFinalQuestion : Page
	{
		static Grid playerGrid;

		public PreFinalQuestion()
		{
			InitializeComponent();

			Grid grid = new Grid();

			
			grid.RowDefinitions.Add(new RowDefinition());
			grid.RowDefinitions.Add(new RowDefinition());

			playerGrid = new Grid();

			int counter = 0;
			foreach (JeopardyPlayer player in JeopardyBoard.Players)
			{
				TextBox textBox = new TextBox();
				playerGrid.ColumnDefinitions.Add(new ColumnDefinition());
				textBox.SetValue(Grid.ColumnProperty, counter);
			}

			this.Content = grid;
		}

		private void FinalizePoints (object sender, RoutedEventArgs e)
		{
			
		}
	}

	
}
