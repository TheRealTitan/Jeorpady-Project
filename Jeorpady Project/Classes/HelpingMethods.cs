using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Jeorpady_Project
{
    public static class HelpingMethods
    {
		public static Window GetBoardWindow()
		{
			foreach(Window win in App.Current.Windows)
			{
				if (win.Name == "BoardWindow")
				{
					return win;
				}
			}
			return null;
		}
    }
}
