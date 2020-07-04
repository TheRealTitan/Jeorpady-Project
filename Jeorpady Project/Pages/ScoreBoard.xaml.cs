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
    /// Interaction logic for ScoreBoard.xaml
    /// </summary>
    public partial class ScoreBoard : Page
    {
        public ScoreBoard()
        {
            InitializeComponent();

			Grid grid = new Grid();
			grid.Background = Brushes.White;

			JeopardyPlayer winner = null;

			foreach(JeopardyPlayer player in JeopardyBoard.Players)
			{
				if(winner == null || winner.Points < player.Points)
				{
					winner = player;
				}
			}

			Border border = new Border();
			border.BorderBrush = Brushes.Blue;
			border.BorderThickness = new Thickness(5);

			TextBlock textBlock = new TextBlock();
			textBlock.VerticalAlignment = VerticalAlignment.Center;
			textBlock.HorizontalAlignment = HorizontalAlignment.Center;
			textBlock.Text = "The winner is " + winner.Name;
			textBlock.FontStretch = FontStretches.UltraExpanded;
			

			border.Child = textBlock;
			grid.Children.Add(border);
			this.Content = grid;
        }
    }
}
