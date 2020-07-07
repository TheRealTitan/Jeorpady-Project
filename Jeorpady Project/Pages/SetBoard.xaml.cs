using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jeorpady_Project
{
    /// <summary>
    /// Interaction logic for SetBoard.xaml
    /// </summary>
    public partial class SetBoard : Page
    {
        public SetBoard()
        {
            InitializeComponent();
        }

		private void FromFileBtn(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

			fileDialog.DefaultExt = ".json";
			fileDialog.Filter = "JSON (JSON)|*.json|(Text)|*.txt|All|*";

			Nullable<bool> result = fileDialog.ShowDialog();

			if(result == true)
			{
				string fileName = fileDialog.FileName;

				try
				{
					JObject json = JObject.Parse(File.ReadAllText(fileName));

					JeopardyBoard.MaxNumberOfRows = (int)json["Board"]["MaxNumberOfRows"];
					JeopardyBoard.DefaultPoints = (int)json["Board"]["DefaultPoints"];
					JeopardyBoard.Categories = JsonConvert.DeserializeObject<JeopardyCategory[]>(json["Board"]["Categories"].ToString());
					JeopardyBoard.Players = JsonConvert.DeserializeObject<List<JeopardyPlayer>>(json["Board"]["Players"].ToString());
					JeopardyBoard.FinalQuestion = JsonConvert.DeserializeObject<JeopardyItem>(json["Board"]["FinalQuestion"].ToString());

					MessageBox.Show("Board successfully setup.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				catch(Exception eee)
				{
					MessageBox.Show("Alert: " + eee.ToString(), "Error occurred!", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void BackToBoardMenuBtn(object sender, RoutedEventArgs e)
		{
			((MainWindow)Application.Current.MainWindow).Main.Content = new BoardMenu();
		}
	}
}
