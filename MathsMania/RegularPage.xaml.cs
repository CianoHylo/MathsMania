using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MathsMania
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegularPage : Page
    {
        //Declare Variables
        DispatcherTimer timer = new DispatcherTimer();
        MediaPlayer correctMp3 = new MediaPlayer();
        MediaPlayer gameoverMp3 = new MediaPlayer();
        public static ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        public int increment;
        public int num1;
        public int num2;
        public int char1;
        public int answer;
        char[] symbol1 = "+-*".ToCharArray(); //create a character array so random class can randomly pick plus or minus
        String symbol2 = "=";

        //initialize variables.
        public int score = 0;
        public int timerCounter = 0;
        public int correctCounter = 0;
        public int miliseconds = 2000;

        public RegularPage()
        {
            this.InitializeComponent();
        }

        //Navigate back to the main page
        private void HomeClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
            timer.Stop();
        }

        //navigate back to the select page
        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectPage), null);
            timer.Stop();
        }

        //fuction for when the go button is clicked.
        private void Go_Click(object sender, RoutedEventArgs e)
        {
            //add one the timer counter
            timerCounter++;

            //reset everything when correct/ game over
            finalScore1.Text = "";
            gameover.Text = "";
            answerBox.Text = "";
            Done.Content = "Done";
            Done.FontSize = 30;
            Go.Content = "Go";

            Done.IsEnabled = true;
            Go.IsEnabled = false;
            answerBox.IsEnabled = true;

            //start timer and set interval to 1 second
            timer.Start();
            timer.Interval = TimeSpan.FromSeconds(1);

            //set timer to tick on the first click of the go button
            if (timerCounter == 1)
            {
                timer.Tick += Timer_Tick;
            }

            // else if statement to lower clock as more correct answer are given     
            if (correctCounter >= 25)
            {
                increment = 6;
            }

            else if (correctCounter >= 20)
            {
                increment = 7;
            }

            else if (correctCounter >= 15)
            {
                increment = 8;
            }

            else if (correctCounter >= 10)
            {
                increment = 9;
            }

            else if (correctCounter >= 5)
            {
                increment = 10;
            }

            else
            {
                increment = 11;
            }

            // create a random object and pull plus or minus from array.
            Random ran1 = new Random();
            char1 = ran1.Next(symbol1.Length);
            firstSymbol.Text = symbol1[char1].ToString();

            //if statement to dictate what range of numbers we want from the random class.
            if (firstSymbol.Text == "+")
            {
                num1 = ran1.Next(48) + 1;// plus one so we dont get 0.
                num2 = ran1.Next(48) + 1;
            }

            // make sure number 2 isnt bigger than number 1 so we dont get minus answers
            else if (firstSymbol.Text == "-")
            {
                num1 = ran1.Next(48) + 1;
                num2 = ran1.Next(0, num1) + 1;
            }

            else
            {
                num1 = ran1.Next(12) + 1;
                num2 = ran1.Next(12) + 1;
            }
            // set numbers to text boxes.
            firstNum.Text = num1.ToString();
            secondNum.Text = num2.ToString();

            equals.Text = symbol2;
        }//Go_Click end

        // Timer tick for increment to count down from set number and print to screen. (async for media)
        private async void Timer_Tick(object sender, object e)
        {
            if (increment > 0)
            {
                increment--;
                timertext.Text = "    " + increment.ToString();
            }

            // game over if timer ticks to 0.
            if (increment == 0)
            {
                // reset variables and texts and print out final score and game over.
                Done.IsEnabled = false;
                Go.IsEnabled = true;
                timer.Stop();
                Go.Content = "Try Again";
                gameover.Text = "   GAME OVER";
                gameover.Foreground = new SolidColorBrush(Colors.Red);
                finalScore1.Text = "SCORE: " + score.ToString();
                finalScore1.Foreground = new SolidColorBrush(Colors.Red);
                answerBox.IsEnabled = false;
                correctCounter = 0;
                

                //if statement to get the answer and to print out the correct answer to the user.
                if (firstSymbol.Text == "+")
                {
                    answer = num1 + num2;
                }

                else if (firstSymbol.Text == "-")
                {
                    answer = num1 - num2;
                }

                else
                {
                    answer = num1 * num2;
                }
                Done.Content = ("Correct Answer = " + answer.ToString());
                Done.FontSize = 18;

                // play game over sound and make sure autoplay doesnt occur
                Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
                Windows.Storage.StorageFile file = await folder.GetFileAsync("game-over.mp3");
                gameoverMp3.AutoPlay = false;
                gameoverMp3.Source = MediaSource.CreateFromStorageFile(file);
                gameoverMp3.Play();

                //use try catch method to store highscore into local settings
                try
                {
                    int temp = Convert.ToInt32(localSettings.Values["reghighScore"]);
                    if (temp < score)
                    {
                        localSettings.Values["reghighScore"] = score.ToString();

                    }
                }
                catch
                {
                    // doesn't exist, just set the value
                    localSettings.Values["reghighScore"] = score.ToString();
                }

                score = 0;
                score1.Text = "";

            }
        }//timer_tick end

        //function for when done button is click
        public async void Done_Click(object sender, RoutedEventArgs e)
        {
            //reset text and variables
            Done.IsEnabled = false;
            Go.IsEnabled = true;
            timer.Stop();
            timertext.Text = "";

            //calculate answer depending on the symbol
            if (firstSymbol.Text == "+")
            {
                answer = num1 + num2;
            }

            else if (firstSymbol.Text == "-")
            {
                answer = num1 - num2;
            }

            else
            {
                answer = num1 * num2;
            }


            if (answerBox.Text == answer.ToString())
            {
                //reset boxes and variables and print correct to screen and update score
                answerBox.Text = "";
                timer.Stop();
                gameover.Text = "      Correct!";
                gameover.Foreground = new SolidColorBrush(Colors.Green);
                score++;
                score1.Text = "SCORE: " + score.ToString();
                score1.Foreground = new SolidColorBrush(Colors.Yellow);
                correctCounter++;

                //play correct sound
                Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
                Windows.Storage.StorageFile file = await folder.GetFileAsync("Correct-answer.mp3");
                correctMp3.AutoPlay = false;
                correctMp3.Source = MediaSource.CreateFromStorageFile(file);
                correctMp3.Play();

                //this second timer is a timer to delay the go_click function for a second after the user click done or presses enter on their device
                var timer2 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
                timer2.Start();
                timer2.Tick += (sender1, args) =>
                {
                    timer2.Stop();
                    Go_Click(this, new RoutedEventArgs());

                };

            }

            //else incorrect answer
            else
            {
                //reset variables, print final score and Game over to screen
                gameover.Text = "   GAME OVER";
                gameover.Foreground = new SolidColorBrush(Colors.Red);
                finalScore1.Text = "SCORE: " + score.ToString();
                finalScore1.Foreground = new SolidColorBrush(Colors.Red);

                //use try catch method to store highscore into local settings
                try
                {
                    int temp = Convert.ToInt32(localSettings.Values["reghighScore"]);
                    if (temp < score)
                    {
                        localSettings.Values["reghighScore"] = score.ToString();

                    }
                }
                catch
                {
                    // doesn't exist, just set the value
                    localSettings.Values["reghighScore"] = score.ToString();
                }

                answerBox.IsEnabled = false;
                Go.Content = "Try Again";
                correctCounter = 0;
                score = 0;
                score1.Text = "";
                Done.Content = ("Correct Answer = " + answer.ToString());
                Done.FontSize = 18;

                //play game over mp3
                Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
                Windows.Storage.StorageFile file = await folder.GetFileAsync("game-over.mp3");
                gameoverMp3.AutoPlay = false;
                gameoverMp3.Source = MediaSource.CreateFromStorageFile(file);
                gameoverMp3.Play();
            }

        }//end of done_click

        //if the user presses enter accept answer in answer box, then runs done clicked event.
        public void answerBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {

                Done_Click(this, new RoutedEventArgs());

                e.Handled = true;

            }
        }//end of key down


    }//end of class

}//end of namespace


