using Blackjack.Model;
using Blackjack.ViewModel.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Blackjack.ViewModel
{

    class PlayViewModel : ViewModelBase
    {

        private ObservableCollection<Card> _dealerRevealedCards;
        private ObservableCollection<Card> _dealerHiddenCard;
        private ObservableCollection<Card> _playerCards;
        public PlayerViewModel _playerViewModel;
        public DealerViewModel _dealerViewModel;
        private Visibility _hitVisibility;
        private Visibility _standVisibility;
        private Visibility _nextVisibility;

        private Deck Deck { get; }

        public ObservableCollection<Card> DealerRevealedCards { get { return _dealerRevealedCards; } set { _dealerRevealedCards = value; } }
        public ObservableCollection<Card> DealerHiddenCard { get { return _dealerHiddenCard; } set { _dealerHiddenCard = value; } }
        public ObservableCollection<Card> PlayerCards { get { return _playerCards; } set { _playerCards = value; } }
        public PlayerViewModel PlayerViewModel { get { return _playerViewModel; } set { _playerViewModel = value; } }
        public DealerViewModel DealerViewModel { get { return _dealerViewModel; } set { _dealerViewModel = value; } }

        public Visibility HitVisibility { get { return _hitVisibility; } set { _hitVisibility = value; OnPropertyChanged("HitVisibility"); } }
        public Visibility StandVisibility { get { return _standVisibility; } set { _standVisibility = value; OnPropertyChanged("StandVisibility"); } }
        public Visibility NextVisibility { get { return _nextVisibility; } set { _nextVisibility = value; OnPropertyChanged("NextVisibility"); } }


        public HitCommand HitCommand { get; private set; }
        public StandCommand StandCommand { get; private set; }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public PlayViewModel ()
        {
            Deck = new Deck();
            DealerRevealedCards = new ObservableCollection<Card>();
            DealerHiddenCard = new ObservableCollection<Card>();
            PlayerCards = new ObservableCollection<Card>();
            PlayerViewModel = new PlayerViewModel();
            DealerViewModel = new DealerViewModel();
            HitCommand = new HitCommand(Hit);
            StandCommand = new StandCommand(Stand);
            HitVisibility = Visibility.Visible;
            StandVisibility = Visibility.Visible;
            NextVisibility = Visibility.Hidden;


            Card card = Deck.Cards.Dequeue();
            PlayerCards.Add(card);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, card));
            card = Deck.Cards.Dequeue();
            DealerRevealedCards.Add(card);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, card));
            card = Deck.Cards.Dequeue();
            PlayerCards.Add(card);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, card));
            card = Deck.Cards.Dequeue();
            DealerHiddenCard.Add(card);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, card));
        }

        public void Hit()
        {
            Card card = Deck.Cards.Dequeue();
            PlayerCards.Add(card);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, card));
            Has21(PlayerViewModel, PlayerCards);
            DidPlayerBust();
            DidPlayerHit21();
        }

        public void Stand()
        {
            HitVisibility = Visibility.Hidden;
            StandVisibility = Visibility.Hidden;
            NextVisibility = Visibility.Visible;
            Debug.WriteLine("\nPlayer Stand!");
            Has21(PlayerViewModel, PlayerCards);
            FlipDealerHiddenCard();
            DealerDecideAction();
        }
        
        public void DidPlayerHit21()
        {
            List<Card> aces = new List<Card>();
            int sum = 0;
            bool result = false;
            //Get Sum of Non-Ace Cards
            for (var i = 0; i < PlayerCards.Count; i++)
            {
                if (PlayerCards[i].Face != Faces.Ace)
                {
                    sum += PlayerCards[i].Value;
                }

                else
                {
                    aces.Add(PlayerCards[i]);
                }


            }
            if (sum == 21)
            {
                result = true;
            }

            //check all possibilities to find one way to add to 21
            if (aces.Count == 1)
            {
                result |= Is21(aces[0], sum);
            }

            if (aces.Count == 2)
            {
                aces[0].Value = 11;
                result |= Is21(aces[1], sum + aces[0].Value);
                aces[0].Value = 1;
                result |= Is21(aces[1], sum + aces[0].Value);
            }

            if (aces.Count == 3)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
            }

            if (aces.Count == 4)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);

            }


            PlayerViewModel.Hit21 = result;

            if (PlayerViewModel.Hit21)
            {
                HitVisibility = Visibility.Hidden;
                StandVisibility = Visibility.Hidden;
                NextVisibility = Visibility.Visible;
                Debug.WriteLine("\nPlayer Hit 21!");
            }
        }

        public bool Is21(Card ace, int sum)
        {
            int possibleSum = sum + ace.Value;
            if (possibleSum == 21)
                return true;
            else
            {
                ace.Value = 1;
                possibleSum = sum + ace.Value;
                if (possibleSum == 21)
                    return true;
            }
            return false;
        }

        public void DidPlayerBust()
        {
            bool result = false;
            int sum = 0;
            List<Card> aces = new List<Card>();

            //Get Sum of Non-Ace Cards
            for (var i = 0; i < PlayerCards.Count; i++)
            {
                if (PlayerCards[i].Face != Faces.Ace)
                {
                    sum += PlayerCards[i].Value;
                }
                else
                {
                    aces.Add(PlayerCards[i]);
                }
            }
            if (sum > 21)
            {
                result = true;
            }
            //check all possibile combinations of players cards if they are greater than 21
            if (aces.Count == 1)
            {
                result = IsOver21(aces[0], sum);
            }
            if (aces.Count == 2)
            {
                aces[0].Value = 11;
                result &= IsOver21(aces[1], sum + aces[0].Value);
                aces[0].Value = 1;
                result &= IsOver21(aces[1], sum + aces[0].Value);
            }
            if (aces.Count == 3)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
            }
            if (aces.Count == 4)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
            }

            PlayerViewModel.Busted = result;

            if (PlayerViewModel.Busted)
            {
                HitVisibility = Visibility.Hidden;
                StandVisibility = Visibility.Hidden;
                NextVisibility = Visibility.Visible;
                Debug.WriteLine("\nPlayer Busted!");
            }
        }

        public bool IsOver21(Card ace, int sum)
        {
            int possibleSum = sum + ace.Value;
            if (possibleSum > 21)
                return true;
            else
            {
                ace.Value = 1;
                possibleSum = sum + ace.Value;
                if (possibleSum > 21)
                    return true;
            }
            return false;
        }

        public void FlipDealerHiddenCard()
        {
            Card hiddenCard = DealerHiddenCard[0];
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, hiddenCard));
            DealerHiddenCard.Clear();
            DealerRevealedCards.Add(hiddenCard);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, hiddenCard));
        }

        public bool IsUnder17(Card ace, int sum)
        {
            int possibleSum = sum + ace.Value;
            if (possibleSum < 17)
                return true;
            else
            {
                ace.Value = 1;
                possibleSum = sum + ace.Value;
                if (possibleSum < 17)
                    return true;
            }
            return false;
        }

        public void DealerDecideAction()
        {

            if (Has21(DealerViewModel, DealerRevealedCards) || !DealerUnder17() )
            {

                //Dealer Stand - But this action doesnt do anything besides check the Player and Dealer's Card for the result of the game.
                CheckScores(PlayerViewModel, PlayerCards);
                CheckScores(DealerViewModel, DealerRevealedCards);
            }

            else
            {
                DealerHit();
                DidDealerBust();
                DidDealerHit21();
                Has21(DealerViewModel, DealerRevealedCards);
                CheckScores(PlayerViewModel, PlayerCards);
                CheckScores(DealerViewModel, DealerRevealedCards);
            }

            HitVisibility = Visibility.Hidden;
            StandVisibility = Visibility.Hidden;
            NextVisibility = Visibility.Visible;
        }

        public void DealerHit()
        {
            while (DealerUnder17())
            {
                Card card = Deck.Cards.Dequeue();
                DealerRevealedCards.Add(card);
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, card));
            }
        }

        public bool DealerUnder17()
        {
            bool result = false;
            int sum = 0;
            List<Card> aces = new List<Card>();

            //Get Sum of Non-Ace Cards
            for (var i = 0; i < DealerRevealedCards.Count; i++)
            {
                if (DealerRevealedCards[i].Face != Faces.Ace)
                {
                    sum += DealerRevealedCards[i].Value;
                }

                else
                {
                    aces.Add(DealerRevealedCards[i]);
                }


            }
            if (sum < 17)
            {
                result = true;
            }

            //check all possibilities to find one way under 17
            if (aces.Count == 1)
            {
                result = IsUnder17(aces[0], sum);
            }

            if (aces.Count == 2)
            {
                aces[0].Value = 11;
                result |= IsUnder17(aces[1], sum + aces[0].Value);
                aces[0].Value = 1;
                result |= IsUnder17(aces[1], sum + aces[0].Value);
            }

            if (aces.Count == 3)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value);
            }

            if (aces.Count == 4)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
            }

            return result;  
        }

        public void DidDealerBust()
        {
            bool result = false;
            int sum = 0;
            List<Card> aces = new List<Card>();

            //Get Sum of Non-Ace Cards
            for (var i = 0; i < DealerRevealedCards.Count; i++)
            {
                if (DealerRevealedCards[i].Face != Faces.Ace)
                {
                    sum += DealerRevealedCards[i].Value;
                }
                else
                {
                    aces.Add(DealerRevealedCards[i]);
                }
            }
            if (sum > 21)
            {
                result = true;
            }
            //check all possibilities to find if all combination of cards are greater than 21
            if (aces.Count == 1)
            {
                result = IsOver21(aces[0], sum);
            }
            if (aces.Count == 2)
            {
                aces[0].Value = 11;
                result &= IsOver21(aces[1], sum + aces[0].Value);
                aces[0].Value = 1;
                result &= IsOver21(aces[1], sum + aces[0].Value);
            }
            if (aces.Count == 3)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
            }
            if (aces.Count == 4)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
            }

            DealerViewModel.Busted = result;

            if (DealerViewModel.Busted)
            {
                Debug.WriteLine("\nDealer Busted!");
            }
        }

        public void DidDealerHit21()
        {
            List<Card> aces = new List<Card>();
            int sum = 0;
            bool result = false;
            //Get Sum of Non-Ace Cards
            for (var i = 0; i < DealerRevealedCards.Count; i++)
            {
                if (DealerRevealedCards[i].Face != Faces.Ace)
                {
                    sum += DealerRevealedCards[i].Value;
                }

                else
                {
                    aces.Add(DealerRevealedCards[i]);
                }


            }
            if (sum == 21)
            {
                result = true;
            }

            //check all possibilities to find one way to add to 21
            if (aces.Count == 1)
            {
                result |= Is21(aces[0], sum);
            }

            if (aces.Count == 2)
            {
                aces[0].Value = 11;
                result |= Is21(aces[1], sum + aces[0].Value);
                aces[0].Value = 1;
                result |= Is21(aces[1], sum + aces[0].Value);
            }

            if (aces.Count == 3)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
            }

            if (aces.Count == 4)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);

            }


            DealerViewModel.Hit21 = result;

            if (DealerViewModel.Hit21)
            {
                Debug.WriteLine("\nDealer Hit 21!");
            }
        }

        public bool Has21(object obj, ObservableCollection<Card> hand)
        {
            List<Card> aces = new List<Card>();
            int sum = 0;
            bool result = false;
            //Get Sum of Non-Ace Cards
            for (var i = 0; i < hand.Count; i++)
            {
                if (hand[i].Face != Faces.Ace)
                {
                    sum += hand[i].Value;
                }
                else
                {
                    aces.Add(hand[i]);
                }
            }
            if (sum == 21)
            {
                result = true;
            }
            //check all possibilities to find one way to add to 21
            if (aces.Count == 1)
            {
                result = Is21(aces[0], sum);
            }
            if (aces.Count == 2)
            {
                aces[0].Value = 11;
                result |= Is21(aces[1], sum + aces[0].Value);
                aces[0].Value = 1;
                result |= Is21(aces[1], sum + aces[0].Value);
            }
            if (aces.Count == 3)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
            }
            if (aces.Count == 4)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);

            }


            if (obj.GetType() == PlayerViewModel.GetType())
            {
                PlayerViewModel.Has21 = result;
                if (PlayerViewModel.Has21)
                {
                    Debug.WriteLine("\nPlayer Has 21!");

                }
            }

            if(obj.GetType() == DealerViewModel.GetType())
            {
                DealerViewModel.Has21 = result;
                if (DealerViewModel.Has21)
                {
                    Debug.WriteLine("\nDealer Has 21!");

                }
            }

            return result;
        }

        public void CheckScores(object obj, ObservableCollection<Card> hand)
        {
            List<Card> aces = new List<Card>();
            List<int> scores = new List<int>();
            int sum = 0;
            for (var i = 0; i < hand.Count; i++)
            {
                if (hand[i].Face != Faces.Ace)
                {
                    sum += hand[i].Value;
                    scores.Add(sum);

                }
                else
                {
                    aces.Add(hand[i]);
                }
            }

            //check all possibilities to find one way to add to 21
            if (aces.Count == 1)
            {
                aces[0].Value = 1;
                scores.Add(sum + aces[0].Value);
                aces[0].Value = 11;
                scores.Add(sum + aces[0].Value);
            }

            if (aces.Count == 2)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value);
            }

            if (aces.Count == 3)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);

            }

            if (aces.Count == 4)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
            }
            scores = scores.OrderBy(number => number).ToList();
            //find index of first score greater than 21
            int stopIndex = -1;
            for (var i = 0; i < scores.Count; i++)
            {
                if (scores[i] > 21)
                {
                    stopIndex = i;
                    break;
                }

            }
            if (stopIndex >= 0 && stopIndex <= scores.Count - 1)
            {
                //remove all scores that are greter than 21
                scores.RemoveRange(stopIndex, scores.Count - stopIndex);
                scores.TrimExcess();
            }
            //sort scores to be in descending order(greatest at the beginning (21 ..20...19)
            scores.Reverse();



            //return closest to 21

            if (obj.GetType() == PlayerViewModel.GetType())
            {
                PlayerViewModel.Score = scores[0];
                Debug.Write("\nPlayer's Score: \n" + PlayerViewModel.Score);

            }

            if (obj.GetType() == DealerViewModel.GetType())
            {
                DealerViewModel.Score = scores[0];
                Debug.Write("\nDealer's Score: \n" +  DealerViewModel.Score);

            }
        }

    }
}
