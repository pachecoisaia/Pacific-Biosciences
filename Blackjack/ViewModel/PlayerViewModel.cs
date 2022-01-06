using System.ComponentModel;

namespace Blackjack.ViewModel
{
    class PlayerViewModel : INotifyPropertyChanged
    {
        private bool busted;
        private bool hit21;
        private bool has21;
        private int score;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool Busted { get { return busted; } set { busted = value; OnPropertyChanged("Busted"); } }
        public bool Hit21 { get { return hit21; } set { hit21 = value; OnPropertyChanged("Hit21"); } }

        public bool Has21 { get { return has21; } set { has21 = value; OnPropertyChanged("Has21"); } }

        public int Score { get { return score; } set { score = value; OnPropertyChanged("Score"); } }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public PlayerViewModel()
        {
            Busted = false;
            Hit21 = false;
            Has21 = false;
            score = -1;
        }
    }
}
