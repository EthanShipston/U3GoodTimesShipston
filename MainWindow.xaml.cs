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

namespace GoodTimesShipston
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int[] timeValues = new int[6];

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(txtInput.Text, out int input); //converts input to interger

            for (int i = 0; i <= 5; i++)
            {
                int tempTimeValue = input + 200 - 100 * i; //created value for the highest common timezone to begin the loop.

                if (i == 0) //Loop that corrects invalid time in the St. John's timezone
                {
                    tempTimeValue = tempTimeValue - 70;
                    string tempString = tempTimeValue.ToString();
                    tempString = tempString.Substring(0, tempString.Length - 2); //Isolates the minute values of St. Johns time to check for invalid time
                    int tempI;
                    int.TryParse(tempString, out tempI); //checks for a valid minute time and corrects it if necessary
                    if (tempI > 59)
                    {
                        tempTimeValue = tempTimeValue + 70;
                    }
                }

                if (tempTimeValue < 0) //checks to see if time will be in the previous day
                {
                    tempTimeValue = 2400 + tempTimeValue; //sets tempValue to a valid time
                    timeValues[i] = tempTimeValue; //places tempValue in the Values array
                }
                else if (tempTimeValue >= 2400) //checks to see if the time will be in the next day
                {
                    tempTimeValue = tempTimeValue - 2400; //sets tempValue to a valid time
                    timeValues[i] = tempTimeValue; //places tempValue in the Values array
                }
                else //if neither of the above statements are true, sets the time values normally.
                {
                    timeValues[i] = tempTimeValue; //places tempValue in the Values array
                }

                lblOutput.Content = timeValues[2] + " in Ottawa" + System.Environment.NewLine +
                    timeValues[5] + " in Victoria" + System.Environment.NewLine +
                    timeValues[4] + " in Edmonton" + System.Environment.NewLine +
                    timeValues[3] + " in Winnipeg" + System.Environment.NewLine +
                    timeValues[2] + " in Toronto" + System.Environment.NewLine +
                    timeValues[1] + " in Halifax" + System.Environment.NewLine +
                    timeValues[0] + " in St. John's"; //outputs all of the Time Values
            }
        }
    }
}
