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

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random r = new Random();

        enum Hand
        {
            Fist,
            Rock,
            Paper,
            Scissors
        };

        public MainWindow()
        {
            InitializeComponent();
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
            Countdown.Text = "Ready?";
            Countdown.Visibility = Visibility.Visible;
            await Wait(1000);
            Countdown.Text = "Rock!";
            await Wait(1000);
            Countdown.Text = "Paper!";
            await Wait(1000);
            Countdown.Text = "Scissors!";
            await Wait(1000);
            Countdown.Text = "SHOOT!";
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartCountdown();
        }
    }
}
