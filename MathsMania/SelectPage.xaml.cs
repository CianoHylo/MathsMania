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
    public sealed partial class SelectPage : Page
    {

        //to mainpage
        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        //to mainpage
        private void HomeClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        //to easy page
        private void EasyClick(object sender, RoutedEventArgs e)
        {
          
            this.Frame.Navigate(typeof(EasyPage), null);
        }

        //to regular page
        private void RegularClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegularPage), null);
        }

        //to hard page
        private void HardClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HardPage), null);
        }

        //to select page
        public SelectPage()
        {
            
            this.InitializeComponent();
        }

        //to highscore page
        private void HighScoreClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings), null);
        }

        //to info page
        private void info_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(info), null);
        }
    }
}
