using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace Blackjack.View
{

    public partial class DealerHit21View : Page
    {
        Frame Main;
        public DealerHit21View(Frame main)
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
