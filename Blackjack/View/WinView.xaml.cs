using System.Windows;
using System.Windows.Controls;

namespace Blackjack.View
{
    public partial class WinView : Page
    {
        Frame Main;
        public WinView(Frame main)
        {
            this.Main = main;
            InitializeComponent();
        }


        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MainMenuView(Main);
        }
    }
}
