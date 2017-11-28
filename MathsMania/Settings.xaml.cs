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

        public Settings()
        {
            this.InitializeComponent();

        }

        // use radio button to display high score depending on selected level
        //use the tags to decide which button is checked and which score to display
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton current = (RadioButton)sender;
            int tag = Convert.ToInt32(current.Tag);
            if (tag == 6)
            {
                scoreText.Text = EasyPage.localSettings.Values["easyHighScore"].ToString(); 
            }

            else if (tag == 7)
            {                
                scoreText.Text = RegularPage.localSettings.Values["reghighScore"].ToString();
            }

            else if (tag == 8)
            {             
                scoreText.Text = HardPage.localSettings.Values["hardHighScore"].ToString();
            }
            
        }

        //navigation
        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectPage), null);
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }
    }
}
