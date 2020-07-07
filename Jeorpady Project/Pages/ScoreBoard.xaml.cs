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
		static BrushConverter converter = new BrushConverter();
		static Brush blueBrush = (Brush)converter.ConvertFromString("#0e1684");
		static Brush yellowBrush = (Brush)converter.ConvertFromString("#d6aa4c");

		public ScoreBoard()
        {
            InitializeComponent();

			Grid grid = new Grid();
			grid.Background = blueBrush;

			JeopardyPlayer winner = null;

			foreach(JeopardyPlayer player in JeopardyBoard.Players)
			{
				if(winner == null || winner.Points < player.Points)
				{
					winner = player;
				}
			}

			Viewbox viewbox = HelpingMethods.GenerateViewBox("Vinderen er: " + winner.Name + "." + Environment.NewLine + "Score: " + winner.Points, yellowBrush, false);

			grid.Children.Add(viewbox);
			this.Content = grid;
        }
    }
}
