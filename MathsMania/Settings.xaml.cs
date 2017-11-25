using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MathsMania
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class Settings : Page
    {
        public static int easyHighscore;

        public Settings()
        {
            this.InitializeComponent();

        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton current = (RadioButton)sender;
            int tag = Convert.ToInt32(current.Tag);
            if (tag == 6)
            {
                scoreText.Text = EasyPage.localSettings.Values["highScore"].ToString();
              
            }

            else if (tag == 7)
            {
                scoreText.Text = 6.ToString();
            }

            else
            {
                scoreText.Text = 7.ToString();
            }
            
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectPage), null);
        }
    }
}
