using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BlackJack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int[] cardArrayH = new int[13];
        int[] cardArrayD = new int[13];
        int[] cardArrayS = new int[13];
        int[] cardArrayC = new int[13];
        Random suit = new Random();      //Random generator for the suit (1,5)
        Random card = new Random();      //Random generator for the card (1,14)
        Boolean card1Chosen = false;
        Boolean card2Chosen = false;

        public MainPage()
        {
            this.InitializeComponent();
            for(int i = 0; i < cardArrayC.Length; i++) //initialize all the card arrays to zero or "unpicked"
            {
                cardArrayH[i] = 0;
                cardArrayD[i] = 0;
                cardArrayS[i] = 0;
                cardArrayC[i] = 0;
            }
        }

        private void drawFirstCard()
        {
            if (card1Chosen == false)
            {
                int suitChosen = suit.Next(1, 5); //1 is inclusive, 5 is upper-bound EXCLUSIVE
                int playerCard = chooseCard(suitChosen); //Card number being returned by the random integer value
                card1Chosen = true;
                if (playerCard > 1 || playerCard < 11)
                {
                    randP1.Text = playerCard.ToString();
                }
                else if (playerCard == 1)
                {
                    randP1.Text = "Ace";
                }
                else if (playerCard == 11)
                {
                    randP1.Text = "Jack";
                }
                else if (playerCard == 12)
                {
                    randP1.Text = "Queen";
                }
                else if (playerCard == 13)
                {
                    randP1.Text = "King";
                }

                suitChosen = suit.Next(1, 5);     //Re-do the proces for the dealer's card
                int dealerCard = chooseCard(suitChosen);  //pick another card for the dealer//chipTotal.Text = chipAmt.ToString();
                if(dealerCard > 1 || dealerCard < 11)
                {
                    randD1.Text = dealerCard.ToString();
                }else if(dealerCard == 1)
                {
                    randD1.Text = "Ace";
                }else if(dealerCard == 11)
                {
                    randD1.Text = "Jack";
                }else if(dealerCard == 12)
                {
                    randD1.Text = "Queen";
                }else if(dealerCard == 13)
                {
                    randD1.Text = "King";
                }
            }
        }
        private void drawSecondCard()
        {
            if (card2Chosen == false)
            {
                int suitChosen = suit.Next(1, 5); //1 is inclusive, 5 is upper-bound EXCLUSIVE
                int playerCard = chooseCard(suitChosen); //Card number being returned by the random integer value
                if (playerCard > 1 || playerCard < 11)
                {
                    randP2.Text = playerCard.ToString();
                }
                else if (playerCard == 1)
                {
                    randP2.Text = "Ace";
                }
                else if (playerCard == 11)
                {
                    randP2.Text = "Jack";
                }
                else if (playerCard == 12)
                {
                    randP2.Text = "Queen";
                }
                else if (playerCard == 13)
                {
                    randP2.Text = "King";
                }
                suitChosen = suit.Next(1, 5);     //Re-do the proces for the dealer's card
                int dealerCard = chooseCard(suitChosen);  //pick another card for the dealer
                card2Chosen = true;
                if (dealerCard > 1 || dealerCard < 11)
                {
                    randD2.Text = dealerCard.ToString();
                }
                else if (dealerCard == 1)
                {
                    randD2.Text = "Ace";
                }
                else if (dealerCard == 11)
                {
                    randD2.Text = "Jack";
                }
                else if (dealerCard == 12)
                {
                    randD2.Text = "Queen";
                }
                else if (dealerCard == 13)
                {
                    randD2.Text = "King";
                }
            }
        }
        public int chooseCard(int suit)
        {
            int result = 0;
            int cardChosen = card.Next(0, 13);
            if(suit == 1) //Hearts cardArrayH
            {
                if(cardArrayH[cardChosen] == 1) // 1 means the card has already been drawn
                {
                    while(cardArrayH[cardChosen] == 1) // automatically will run once
                    {
                        cardChosen = card.Next(1, 14); //Choose another card and then check the condition
                    }
                }else
                {
                    result = cardChosen;
                    cardArrayH[cardChosen] = 1; // Make the card "chosen" in the array
                }
            }else if(suit == 2) //Diamonds cardArrayD
            {
                if (cardArrayD[cardChosen] == 1) // 1 means the card has already been drawn
                {
                    while (cardArrayD[cardChosen] == 1) // automatically will run once
                    {
                        cardChosen = card.Next(1, 14); //Choose another card and then check the condition
                    }
                }
                else
                {
                    result = cardChosen;
                    cardArrayD[cardChosen] = 1; // Make the card "chosen" in the array
                }
            }
            else if(suit == 3) //Spades cardArrayS
            {
                if (cardArrayS[cardChosen] == 1) // 1 means the card has already been drawn
                {
                    while (cardArrayS[cardChosen] == 1) // automatically will run once
                    {
                        cardChosen = card.Next(1, 14); //Choose another card and then check the condition
                    }
                }
                else
                {
                    result = cardChosen;
                    cardArrayS[cardChosen] = 1; // Make the card "chosen" in the array
                }
            }
            else if(suit == 4) //Clubs cardArrayC
            {
                if (cardArrayC[cardChosen] == 1) // 1 means the card has already been drawn
                {
                    while (cardArrayC[cardChosen] == 1) // automatically will run once
                    {
                        cardChosen = card.Next(1, 14); //Choose another card and then check the condition
                    }
                }
                else
                {
                    result = cardChosen;
                    cardArrayC[cardChosen] = 1; // Make the card "chosen" in the array
                }
            }
            return result;
        }

        private void okClick(object sender, RoutedEventArgs e)
        {
            drawFirstCard();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            drawSecondCard();
        }
    }
}
