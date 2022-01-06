using Blackjack.View;
using System.Windows;
namespace Blackjack
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new MainMenuView(Main);
        }
    }
}