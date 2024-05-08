using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaseballScorekeeper
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Loop through to make sure that all text boxes are filled out.
            for(int i = 0; i < VisualTreeHelper.GetChildrenCount(this.MainGrid); i++)
            {
                Object o = (Object)VisualTreeHelper.GetChild(this.MainGrid, i);
                if (o.GetType() == typeof(TextBox))
                {
                    TextBox textBox = (TextBox)o;
                    if(textBox.Text.Length == 0)
                    {
                        MessageBox.Show("All players must be filled out. Please try again.");
                        return;
                    }
                }
            }
            //If all fields filled out, put all players into the arrays to be shipped off to the game window.
            string[] awayPlayers = new string[10];
            string[] homePlayers = new string[10];
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(this.MainGrid); i++)
            {
                Object o = (Object)VisualTreeHelper.GetChild(this.MainGrid, i);
                if (o.GetType() == typeof(TextBox))
                {
                    TextBox textBox = (TextBox)o;
                    if(i < 10)
                    {
                        awayPlayers[i] = textBox.Text;
                    }
                    else
                    {
                        homePlayers[i-10] = textBox.Text;
                    }
                }
            }
            GameWindow page = new GameWindow(awayPlayers, homePlayers);
            page.Show();
            Application.Current.MainWindow = page;
            Close(); //Starting Lineup no longer needed.
        }
    }
}