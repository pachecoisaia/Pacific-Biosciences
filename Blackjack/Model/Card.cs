using System;
using System.Windows.Media.Imaging;
namespace Blackjack.Model
{
    public class Card
    {

        private int value;
        private readonly char symbol;
        private readonly Faces face;
        private readonly Suits suit;
        private readonly BitmapImage front;
        private readonly BitmapImage back;

        public int Value { get { return value; } set { this.value = value; } }
        public char Symbol { get { return symbol; } }
        public Faces Face { get { return face; } }
        public Suits Suit { get { return suit; } }
        public BitmapImage Front { get { return front; } }
        public BitmapImage Back { get { return back; } }

        public Card(Faces face, Suits suit)
        {
            this.face = face;
            this.suit = suit;
            switch (Suit)
            {
                case Suits.Spade:
                    symbol = '♠';
                switch (Face)
                {
                    case Faces.Ace:
                        Value = 11;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/A.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Two:
                        Value = 2;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/2.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Three:
                        Value = 3;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/3.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Four:
                        Value = 4;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/4.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Five:
                        Value = 5;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/5.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Six:
                        Value = 6;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/6.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Seven:
                        Value = 7;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/7.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Eight:
                        Value = 8;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/8.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Nine:
                        Value = 9;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/9.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Ten:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/10.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Jack:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/J.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Queen:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/Q.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.King:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/K.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Spade/S.png", UriKind.RelativeOrAbsolute));
                        break;
                }
                break;
                case Suits.Club:
                    symbol = '♣';
                switch (Face)
                {
                    case Faces.Ace:
                        Value = 11;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/A.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Two:
                        Value = 2;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/2.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Three:
                        Value = 3;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/3.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Four:
                        Value = 4;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/4.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Five:
                        Value = 5;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/5.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Six:
                        Value = 6;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/6.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Seven:
                        Value = 7;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/7.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Eight:
                        Value = 8;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/8.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Nine:
                        Value = 9;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/9.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Ten:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/10.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Jack:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/J.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Queen:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/Q.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.King:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/K.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Club/S.png", UriKind.RelativeOrAbsolute));
                        break;
                }
                break;
                case Suits.Heart:
                    symbol = '♥';
                switch (Face)
                {
                    case Faces.Ace:
                        Value = 11;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/A.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Two:
                        Value = 2;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/2.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Three:
                        Value = 3;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/3.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Four:
                        Value = 4;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/4.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Five:
                        Value = 5;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/5.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Six:
                        Value = 6;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/6.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Seven:
                        Value = 7;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/7.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Eight:
                        Value = 8;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/8.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Nine:
                        Value = 9;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/9.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Ten:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/10.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Jack:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/J.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Queen:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/Q.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.King:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/K.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Heart/S.png", UriKind.RelativeOrAbsolute));
                        break;
                }
                break;
                case Suits.Diamond:
                    symbol = '♦';
                switch (Face)
                {
                    case Faces.Ace:
                        Value = 11;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/A.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Two:
                        Value = 2;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/2.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Three:
                        Value = 3;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/3.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Four:
                        Value = 4;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/4.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Five:
                        Value = 5;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/5.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Six:
                        Value = 6;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/6.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Seven:
                        Value = 7;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/7.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Eight:
                        Value = 8;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/8.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Nine:
                        Value = 9;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/9.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Ten:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/10.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Jack:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/J.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.Queen:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/Q.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                    case Faces.King:
                        Value = 10;
                        front = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/K.png", UriKind.RelativeOrAbsolute));
                        back = new BitmapImage(new Uri("/Blackjack;component/Model/Images/Diamond/S.png", UriKind.RelativeOrAbsolute));
                        break;
                }
                break;
            }
        }
    }
}