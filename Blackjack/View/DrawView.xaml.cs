using System.Windows;
using System.Windows.Controls;

namespace Blackjack.View
{

    public partial class DrawView : Page
    {
        Frame Main;
        public DrawView(Frame main)
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
