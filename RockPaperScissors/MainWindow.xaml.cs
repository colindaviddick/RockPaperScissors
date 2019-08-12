using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int wins = 0;
        int losses = 0;
        int draws = 0;
        static Random r = new Random();

        enum Hand
        {
            Fist,
            Rock,
            Paper,
            Scissors
        };

        //Hand p1 = new Hand();
        Hand p2 = new Hand();

        public MainWindow()
        {
            InitializeComponent();
            UpdateStatistics();
        }

        public async Task Wait(int milliseconds)
        {
            Timer timer1 = new Timer();
            if (milliseconds == 0 || milliseconds < 0)
            {
                return;
            }
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };
            while(timer1.Enabled)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        async Task StartCountdown()
        {
            PlayExitButtons.Visibility = Visibility.Collapsed;
            GetCPUHand();

            CountdownText.Text = "Ready?";
            Countdown.Visibility = Visibility.Visible;
            await Wait(1000);
            Player1Image.Source = new BitmapImage(new Uri((@"images/fistdown.png"), UriKind.RelativeOrAbsolute));
            Player2Image.Source = new BitmapImage(new Uri((@"images/fistdown.png"), UriKind.RelativeOrAbsolute));
            CountdownText.Text = "Rock!";
            await Wait(500);
            Player1Image.Source = new BitmapImage(new Uri((@"images/fist.png"), UriKind.RelativeOrAbsolute));
            Player2Image.Source = new BitmapImage(new Uri((@"images/fist.png"), UriKind.RelativeOrAbsolute));
            await Wait(500);
            Player1Image.Source = new BitmapImage(new Uri((@"images/fistdown.png"), UriKind.RelativeOrAbsolute));
            Player2Image.Source = new BitmapImage(new Uri((@"images/fistdown.png"), UriKind.RelativeOrAbsolute));
            CountdownText.Text = "Paper!";
            await Wait(500);
            Player1Image.Source = new BitmapImage(new Uri((@"images/fist.png"), UriKind.RelativeOrAbsolute));
            Player2Image.Source = new BitmapImage(new Uri((@"images/fist.png"), UriKind.RelativeOrAbsolute));
            await Wait(500);
            Player1Image.Source = new BitmapImage(new Uri((@"images/fistdown.png"), UriKind.RelativeOrAbsolute));
            Player2Image.Source = new BitmapImage(new Uri((@"images/fistdown.png"), UriKind.RelativeOrAbsolute));
            CountdownText.Text = "Scissors!";
            await Wait(500);
            Player1Image.Source = new BitmapImage(new Uri((@"images/fist.png"), UriKind.RelativeOrAbsolute));
            Player2Image.Source = new BitmapImage(new Uri((@"images/fist.png"), UriKind.RelativeOrAbsolute));
            await Wait(500); 
            CountdownText.Text = "SHOOT!";
            UserSelection.Visibility = Visibility.Visible;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Player1Image.Source = new BitmapImage(new Uri((@"images/fist.png"), UriKind.RelativeOrAbsolute));
            Player2Image.Source = new BitmapImage(new Uri((@"images/fist.png"), UriKind.RelativeOrAbsolute));
            
            StartCountdown();
        }

        private void GetCPUHand()
        {
            
            int rInt = r.Next(1, 3);

            switch (rInt)
            {
                case 1:
                    p2 = Hand.Paper;
                    break;
                case 2:
                    p2 = Hand.Rock;
                    break;
                case 3:
                    p2 = Hand.Scissors;
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show("Mistakes were made...");
                    break;

            }
        }

        private void P1PlaysRock_Click(object sender, RoutedEventArgs e)
        {
            Player1Image.Source = new BitmapImage(new Uri((@"images/rock.png"), UriKind.RelativeOrAbsolute));
            P2HandDisplay();
            UserSelection.Visibility = Visibility.Collapsed;
            switch (p2)
            {
                case Hand.Paper:
                    CountdownText.Text = "Paper covers rock! \nYou lose!";
                    losses++;
                    break;
                case Hand.Rock:
                    CountdownText.Text = "A draw!";
                    draws++;
                    break;
                case Hand.Scissors:
                    CountdownText.Text = "Rock smashes scissors! \nYou win!";
                    wins++;
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show("Mistakes were made...");
                    break;
            }
            PlayExitButtons.Visibility = Visibility.Visible;
            UpdateStatistics();
        }

        private void P1PlaysPaper_Click(object sender, RoutedEventArgs e)
        {
            Player1Image.Source = new BitmapImage(new Uri((@"images/paper.png"), UriKind.RelativeOrAbsolute));
            P2HandDisplay();
            UserSelection.Visibility = Visibility.Collapsed;
            switch (p2)
            {
                case Hand.Paper:
                    CountdownText.Text = "A draw!";
                    draws++;
                    break;
                case Hand.Rock:
                    CountdownText.Text = "Paper covers rock! \nYou win!";
                    wins++;
                    break;
                case Hand.Scissors:
                    CountdownText.Text = "Scissors cut paper! \nYou lose!";
                    losses++;
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show("Mistakes were made...");
                    break;
            }
            PlayExitButtons.Visibility = Visibility.Visible;
            UpdateStatistics();
        }

        private void P1PlaysScissors_Click(object sender, RoutedEventArgs e)
        {
            Player1Image.Source = new BitmapImage(new Uri((@"images/scissors.png"), UriKind.RelativeOrAbsolute));
            P2HandDisplay();
            UserSelection.Visibility = Visibility.Collapsed;
            switch (p2)
            {
                case Hand.Paper:
                    CountdownText.Text = "Scissors cut paper! \nYou win!";
                    wins++;
                    break;
                case Hand.Rock:
                    CountdownText.Text = "Rock smashes scissors! \nYou lose!";
                    losses++;
                    break;
                case Hand.Scissors:
                    CountdownText.Text = "A draw!";
                    draws++;
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show("Mistakes were made...");
                    break;
            }
            PlayExitButtons.Visibility = Visibility.Visible;
            UpdateStatistics();
        }

        private void P2HandDisplay()
        {
            switch (p2)
            {
                case Hand.Paper:
                    Player2Image.Source = new BitmapImage(new Uri((@"images/paper.png"), UriKind.RelativeOrAbsolute));
                    break;
                case Hand.Rock:
                    Player2Image.Source = new BitmapImage(new Uri((@"images/rock.png"), UriKind.RelativeOrAbsolute));
                    break;
                case Hand.Scissors:
                    Player2Image.Source = new BitmapImage(new Uri((@"images/scissors.png"), UriKind.RelativeOrAbsolute));
                    break;
                default:
                    MessageBox.Show("Mistakes were made...");
                    break;
            }
        }

        private void UpdateStatistics()
        {
            if (wins == 0 && draws == 0 && losses == 0)
                Stats.Text = "You haven't played any games yet.";
            else
            {
                Stats.Text = "You have won " + wins + " games, drawn " + draws + " and lost " + losses + " games.";
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void MaxMin_Click(object sender, RoutedEventArgs e)
        {
            if(MainGameWindow.WindowState == WindowState.Normal)
            {
                MainGameWindow.WindowState = WindowState.Maximized;
                ColourOne.Color = Color.FromArgb(255, 128, 85, 18);
                ColourTwo.Color = Color.FromArgb(255, 72, 9, 128);
                WindowShadow.Opacity = 0.8;
            }
            else
            {
                MainGameWindow.WindowState = WindowState.Normal;
                ColourOne.Color = Color.FromArgb(0, 0, 0, 0);
                ColourTwo.Color = Color.FromArgb(0, 0, 0, 0);
                WindowShadow.Opacity = 0;
            }
        }
    }
}
