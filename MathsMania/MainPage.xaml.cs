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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MathsMania
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        private void ClickedPlay(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectPage), null);
        }

        public MainPage()
        {
            this.InitializeComponent();
        }
        ///if ((firstsymbol.Text= "+") && (secondSymbol.Text= "+))
        ///{
        /// num1 = ran1.Next(48) + 1;
        ///num2 = ran1.Next(48) + 1;
        ///num3= ran1.Next(48) + 1;
        ///}
        ///else if ((firstSymbol.Text= "+") && (secondSymbol.Text= "*"))
        ///{
        /// num1 = ran1.Next(48) + 1;
        ///num2 = ran1.Next(10) + 1;
        ///num3= ran1.Next(10) + 1;
        ///}
        ///else if ((firstSymbol.Text= "*") && (secondSymbol.Text= "+"))
        ///{
        /// num1 = ran1.Next(10) + 1;
        ///num2 = ran1.Next(10) + 1;
        ///num3= ran1.Next(48) + 1;
        ///}
        ///else if ((firstSymbol.Text= "*") && (secondSymbol.Text= "*"))
        ///{
        /// num1 = ran1.Next(10) + 1;
        ///num2 = ran1.Next(10) + 1;
        ///num3= ran1.Next(10) + 1;
        ///}
        ///else if ((firstSymbol.Text= "*") && (secondSymbol.Text= "-"))
        ///{
        /// num1 = ran1.Next(10) + 1;
        ///num2 = ran1.Next(10) + 1;
        ///num4= num1*num2;
        ///num3= ran1.Next(0, num4) + 1;
        ///}
        ///else if ((firstSymbol.Text= "+") && (secondSymbol.Text= "-"))
        ///{
        /// num1 = ran1.Next(48) + 1;
        ///num2 = ran1.Next(48) + 1;
        ///num4= num1+num2;
        ///num3= ran1.Next(0, num4) + 1;
        ///}
        ///else if ((firstSymbol.Text= "-") && (secondSymbol.Text= "*"))
        ///{
        /// num1 = ran1.Next(48) + 1;
        ///num2 = ran1.Next(0, num1) + 1;
        ///num3= ran1.Next(10) + 1;
        ///}
        ///else if ((firstSymbol.Text= "-") && (secondSymbol.Text= "+"))
        ///{
        /// num1 = ran1.Next(48) + 1;
        ///num2 = ran1.Next(0, num1) + 1;
        ///num3= ran1.Next(48) + 1;
        ///}
        ///else 
        ///{
        /// num1 = ran1.Next(48) + 1;
        ///num2 = ran1.Next(0, num1) + 1;
        ///num4= num1-num2;
        ///num3= ran1.Next(0, num4) + 1;
        ///}

        ///if ((firstsymbol.Text= "+") && (secondSymbol.Text= "+))
        ///{
        /// answer= num1 + num2 + num3;
        ///}
        ///else if ((firstSymbol.Text= "+") && (secondSymbol.Text= "*"))
        ///{
        /// answer = num1 + (num2*num3);
        ///}
        ///else if ((firstSymbol.Text= "*") && (secondSymbol.Text= "+"))
        ///{
        /// answer = (num1 * num2) + num3;
        ///}
        ///else if ((firstSymbol.Text= "*") && (secondSymbol.Text= "*"))
        ///{
        /// answer = num1 * num2 * num3;
        ///}
        ///else if ((firstSymbol.Text= "*") && (secondSymbol.Text= "-"))
        ///{
        /// answer = (num1 * num2) - num3;
        ///}
        ///else if ((firstSymbol.Text= "+") && (secondSymbol.Text= "-"))
        ///{
        ///  answer = num1 + num2 - num3;
        ///}
        ///else if ((firstSymbol.Text= "-") && (secondSymbol.Text= "*"))
        ///{
        /// answer = num1 - (num2 * num3);
        ///}
        ///else if ((firstSymbol.Text= "-") && (secondSymbol.Text= "+"))
        ///{
        /// answer = num1 - num2 + num3;
        ///}
        ///else 
        ///{
        /// answer = num1 - num2 - num3;
        ///}

    }
}
