using System.Windows;
using System.Windows.Controls;

namespace Blackjack.View
{
    public partial class LoseView : Page
    {
        Frame Main;
        public LoseView(Frame main)
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
