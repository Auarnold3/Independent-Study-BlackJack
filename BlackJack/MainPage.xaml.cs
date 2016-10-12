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
        int[] cardArrayH = new int[12];
        int[] cardArrayD = new int[12];
        int[] cardArrayS = new int[12];
        int[] cardArrayC = new int[12];
        Random suit = new Random();      //Random generator for the suit (1,5)
        Random card = new Random();      //Random generator for the card (1,14)
        Boolean gameStarted = false;

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

        private void startGame()
        {
            if (gameStarted == false)
            {
                int suitChosen = suit.Next(1, 5); //1 is inclusive, 5 is upper-bound EXCLUSIVE
                int cardChosen = chooseCard(suitChosen); //Card number being returned by the random integer value
                gameStarted = true;                                         //chipTotal.Text = chipAmt.ToString();
            }
        }
        public int chooseCard(int suit)
        {
            int result = 0;
            int cardChosen = card.Next(1, 14);
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
            startGame();
        }
    }
}
