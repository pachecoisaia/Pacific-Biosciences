using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Blackjack.View
{
    public partial class PlayerBustedView : Page
    {
        Frame Main;
        public PlayerBustedView(Frame main)
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
