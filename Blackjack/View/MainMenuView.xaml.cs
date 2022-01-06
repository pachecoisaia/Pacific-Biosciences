using System.Windows;
using System.Windows.Controls;

namespace Blackjack.View
{
    public partial class MainMenuView : Page
    {
        Frame Main;
        public MainMenuView(Frame main)
        {
            InitializeComponent();
            this.Main = main;
        }
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PlayView(Main);
        }
        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
