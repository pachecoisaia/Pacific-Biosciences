using Blackjack.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Blackjack.View
{
    public partial class PlayView : Page
    {
        private readonly PlayViewModel PlayViewModel;
        Frame Main;
        public PlayView(Frame main)
        {
            InitializeComponent();
            this.Main = main;
            this.PlayViewModel = new PlayViewModel();
            this.DataContext = PlayViewModel;
        }
        private void BtnHit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnStand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (PlayViewModel.PlayerViewModel.Busted == true)
            {
                Main.Content = new PlayerBustedView(Main);
            }

            else if (PlayViewModel.PlayerViewModel.Hit21 == true)
            {
                Main.Content = new PlayerHit21View(Main);
            }

            else if(PlayViewModel.DealerViewModel.Busted == true)
            {
                Main.Content = new DealerBustedView(Main);
            }

            else if(PlayViewModel.DealerViewModel.Hit21 == true && PlayViewModel.PlayerViewModel.Score < 21)
            {
                Main.Content = new DealerHit21View(Main);
            }

            else if(PlayViewModel.PlayerViewModel.Has21 == true && PlayViewModel.DealerViewModel.Has21 == true)
            {
                Main.Content = new DrawView(Main);
            }

            else if(PlayViewModel.PlayerViewModel.Score > PlayViewModel.DealerViewModel.Score)
            {
                Main.Content = new WinView(Main);
            }

            else if (PlayViewModel.PlayerViewModel.Score < PlayViewModel.DealerViewModel.Score)
            {
                Main.Content = new LoseView(Main);
            }

            else
            {
                Main.Content = new DrawView(Main);
            }

        }
    }
}
