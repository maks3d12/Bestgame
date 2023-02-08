using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace Krestic_and_zero
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool Player;
        private bool Start;
        private bool Bot;

        int[] Board = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[,] Wins = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Start == false)
            {
                return;
            }
            Button bt = sender as Button;
            
            string[] NumberButton = bt.Name.Split("_");
            int number = Convert.ToInt32(NumberButton[1]);
            int index =  number - 1;
            if (Board[index] == 0) 
            {
                if (Player)
                {
                    Board[index] = 2;
                    bt.Content= "0";
                    Player = false;
                    Label1.Content = "Ход второго игрока";
                }
                else
                {
                    Board[index] = 1;
                    bt.Content = "X";
                    Label1.Content = "Ход первого игрока";
                    Player = true;
                }


            }
            for (int i = 0; i <= 7; i++) 
            {
                if (Board[Wins[i, 0]] == Board[Wins[i, 1]] && Board[Wins[i, 1]] == Board[Wins[i, 2]] && Board[Wins[i, 1]] != 0)
                {
                    if (Player) 
                    {
                        
                        MessageBox.Show("X победили!");
                        ExitToolStripMenuItem();
                        Board = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }
                    else
                    {
                        MessageBox.Show("O победили!");
                        ExitToolStripMenuItem();
                        Board = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                }
                

            }
            for (int i = 0; i <= 8; i++) 
            {
                if (Board[i] == 0) 
                    break;   

                if (i == 8) 
                {
                    MessageBox.Show("Ничья!");
                    Player = true;
                    Board = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    ExitToolStripMenuItem();
                }
            }

        }
        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            Start = true;
            Button[] buttons = new Button[] { But_1, But_2, But_3, But_4, But_5, But_6, But_7, But_8, But_9 };
            foreach (Button button in buttons)
            {
                button.IsEnabled = true;
            }
        }
        private void ExitToolStripMenuItem()
        {
            Start = false;
            Button[] buttons = new Button[] { But_1, But_2, But_3, But_4, But_5, But_6, But_7, But_8, But_9 };
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
                button.Content = "";
            }
            Label1.Content = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bot = true;
            Button[] buttons = new Button[] { But_1, But_2, But_3, But_4, But_5, But_6, But_7, But_8, But_9 };
            Random random = new Random();
            int randomchoose = random.Next(0, 9);
            Button button = buttons[randomchoose];
            button.Content
        }
    }

}

