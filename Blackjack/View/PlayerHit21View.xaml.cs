using System.Windows;
using System.Windows.Controls;

namespace Blackjack.View
{
    public partial class PlayerHit21View : Page
    {
        Frame Main;
        public PlayerHit21View(Frame main)
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
