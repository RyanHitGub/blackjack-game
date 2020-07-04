using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackjackLibrary;


namespace Task2_Blackjack
{
    public partial class BlackjackForm : Form
    {
        Card[] cards;

        Deck deck = new Deck();
        House house = new House();
        Player[] players;

        int count = 0;
        int playerCount;
        int betCounter = 0;

        List<Panel> playerPanelList = new List<Panel>();
        List<Panel> activePlayerPanelList = new List<Panel>();

        List<Label> scoreLabelPlayerList = new List<Label>();
        List<Label> outcomeLabelPlayerList = new List<Label>();

        public BlackjackForm()
        {
            InitializeComponent();

            //hide all panels
            panelAddName.Hide();

            playerPanelList.Add(panelPlayer1);
            playerPanelList.Add(panelPlayer2);
            playerPanelList.Add(panelPlayer3);
            playerPanelList.Add(panelPlayer4);
            playerPanelList.Add(panelPlayer5);
            playerPanelList.Add(panelPlayer6);
            playerPanelList.Add(panelPlayer7);
        }

        //Panel how many players
        private void btnOK_Click(object sender, EventArgs e)
        {
            cards = deck.PopulateDeck();
            cards = deck.ShuffleDeck(cards);

            playerCount = Convert.ToInt32(playerNumberSelector.Value);
            players = new Player[playerCount];
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Player();
            }

            panelWelcome.Hide();

            //show 2nd panel
            panelAddName.Show();
            labelPlayerTotal2.Text = players.Count().ToString();
            labelPlayerCount2.Text = (count + 1).ToString();
        }

        //Panel enter names
        private void btnOK2_Click(object sender, EventArgs e)
        {
            //Set player name
            if (count < playerCount)
            {
                players[count].Name = txtPlayerName.Text;

                txtPlayerName.Clear();

                count++;
                if (count < playerCount)
                {
                    labelPlayerCount2.Text = (count + 1).ToString();
                    players[count].Name = txtPlayerName.Text;
                }
            }

            //All players are named
            if (count >= playerCount)
            {
                panelAddName.Hide();

                cards = deck.DealDeck(cards, players, house);

                //Display player hands
                panelPlayerHands.Show();
                for (int i = 0; i < players.Length; i++)
                {
                    playerPanelList[i].Show();
                }
                panelHouse.Show();

                if (players.Length == 1)
                {
                    display1Player();
                }
                else if (players.Length == 2)
                {
                    display2Player();
                }
                else if(players.Length == 3)
                {
                    display3Player();
                }
                else if(players.Length == 4)
                {
                    display4Player();
                }
                else if(players.Length == 5)
                {
                    display5Player();
                }
                else if(players.Length == 6)
                {
                    display6Player();
                }
                else
                {
                    display7Player();
                }

                //Display House hand
                string houseCards = "";
                int houseTotal = TotalCalculator.CalculateTotal(house.GetHand());
                for (int i = 0; i < house.GetHand().Length; i++)
                {
                    if (i == 0 && houseTotal < 21)
                    {
                        houseCards += "XX\n";
                        i++;
                    }
                    houseCards += house.GetHand()[i].GetSuit().ToString() + 
                                  house.GetHand()[i].GetFace();
                }
                labelHouseCards.Text = houseCards;
                if (houseTotal == 21)
                {
                    labelHouseTotal.Text = TotalDisplayer.DisplayTotal(TotalCalculator.CalculateTotal(house.GetHand()));
                }

                panelBet.Show();
                labelPlayerTurnName.Text = players[betCounter].Name;
            }
        }

        private void display1Player()
        {
            displayHand(players[0], labelPlayer1Name, labelPlayer1Cards, labelPlayer1Total);
        }
        private void display2Player()
        {
            displayHand(players[0], labelPlayer1Name, labelPlayer1Cards, labelPlayer1Total);
            displayHand(players[1], labelPlayer2Name, labelPlayer2Cards, labelPlayer2Total);
        }
        private void display3Player()
        {
            displayHand(players[0], labelPlayer1Name, labelPlayer1Cards, labelPlayer1Total);
            displayHand(players[1], labelPlayer2Name, labelPlayer2Cards, labelPlayer2Total);
            displayHand(players[2], labelPlayer3Name, labelPlayer3Cards, labelPlayer3Total);
        }
        private void display4Player()
        {
            displayHand(players[0], labelPlayer1Name, labelPlayer1Cards, labelPlayer1Total);
            displayHand(players[1], labelPlayer2Name, labelPlayer2Cards, labelPlayer2Total);
            displayHand(players[2], labelPlayer3Name, labelPlayer3Cards, labelPlayer3Total);
            displayHand(players[3], labelPlayer4Name, labelPlayer4Cards, labelPlayer4Total);
        }
        private void display5Player()
        {
            displayHand(players[0], labelPlayer1Name, labelPlayer1Cards, labelPlayer1Total);
            displayHand(players[1], labelPlayer2Name, labelPlayer2Cards, labelPlayer2Total);
            displayHand(players[2], labelPlayer3Name, labelPlayer3Cards, labelPlayer3Total);
            displayHand(players[3], labelPlayer4Name, labelPlayer4Cards, labelPlayer4Total);
            displayHand(players[4], labelPlayer5Name, labelPlayer5Cards, labelPlayer5Total);
        }
        private void display6Player()
        {
            displayHand(players[0], labelPlayer1Name, labelPlayer1Cards, labelPlayer1Total);
            displayHand(players[1], labelPlayer2Name, labelPlayer2Cards, labelPlayer2Total);
            displayHand(players[2], labelPlayer3Name, labelPlayer3Cards, labelPlayer3Total);
            displayHand(players[3], labelPlayer4Name, labelPlayer4Cards, labelPlayer4Total);
            displayHand(players[4], labelPlayer5Name, labelPlayer5Cards, labelPlayer5Total);
            displayHand(players[5], labelPlayer6Name, labelPlayer6Cards, labelPlayer6Total);
        }
        private void display7Player()
        {
            displayHand(players[0], labelPlayer1Name, labelPlayer1Cards, labelPlayer1Total);
            displayHand(players[1], labelPlayer2Name, labelPlayer2Cards, labelPlayer2Total);
            displayHand(players[2], labelPlayer3Name, labelPlayer3Cards, labelPlayer3Total);
            displayHand(players[3], labelPlayer4Name, labelPlayer4Cards, labelPlayer4Total);
            displayHand(players[4], labelPlayer5Name, labelPlayer5Cards, labelPlayer5Total);
            displayHand(players[5], labelPlayer6Name, labelPlayer6Cards, labelPlayer6Total);
            displayHand(players[6], labelPlayer7Name, labelPlayer7Cards, labelPlayer7Total);
        }

        //Setting label texts for players and house
        private void displayCards(Player player, Label labelCards)
        {
            string temp = "";
            for (int i = 0; i < player.GetHand().Length; i++)
            {
                temp += player.GetHand()[i].GetSuit().ToString() +
                        player.GetHand()[i].GetFace().ToString() +
                        "\n";
            }
            labelCards.Text = temp;
        }
        private void displayHouseCards(House house, Label labelCards)
        {
            string temp = "";
            for (int i = 0; i < house.GetHand().Length; i++)
            {
                temp += house.GetHand()[i].GetSuit().ToString() +
                        house.GetHand()[i].GetFace().ToString() +
                        "\n";
            }
            labelCards.Text = temp;
        }        
        private void displayHand(Player player, Label labelName, Label labelCards, Label labelTotal)
        {
            labelName.Text = player.Name;
            displayCards(player, labelCards);
            labelTotal.Text = TotalDisplayer.DisplayTotal(TotalCalculator.CalculateTotal(player.GetHand()));
        }
        private void displayHouseHand(House house, Label labelName, Label labelCards, Label labelTotal)
        {
            labelName.Text = house.Name;
            displayHouseCards(house, labelCards);
            labelTotal.Text = TotalDisplayer.DisplayTotal(TotalCalculator.CalculateTotal(house.GetHand()));
        }

        //Panel hit or stay
        private void btnHit_Click(object sender, EventArgs e)
        {
            //Not bust or blackjack, your turn
            if (TotalCalculator.CalculateTotal(players[betCounter].GetHand()) < 21)
            {
                players[betCounter].SetHand(players[betCounter].TakeHit(cards, players[betCounter].GetHand()));
                cards = Resizer.ResizeDeck(cards, 1);

                if (players.Length == 1)
                {
                    display1Player();
                }
                else if (players.Length == 2)
                {
                    display2Player();
                }
                else if (players.Length == 3)
                {
                    display3Player();
                }
                else if (players.Length == 4)
                {
                    display4Player();
                }
                else if (players.Length == 5)
                {
                    display5Player();
                }
                else if (players.Length == 6)
                {
                    display6Player();
                }
                else
                {
                    display7Player();
                }

                //blackjack or bust, next players turn
                if (TotalCalculator.CalculateTotal(players[betCounter].GetHand()) >= 21)
                {
                    //Any players left? No, house turn
                    if (betCounter < players.Length - 1)
                    {
                        betCounter++;
                        labelPlayerTurnName.Text = players[betCounter].Name;
                    }
                    else
                        houseTurn();
                }
            }
            //blackjack or bust, next players turn
            else
            {
                //Any players left? No, house turn
                if (betCounter < players.Length - 1)
                {
                    betCounter++;
                    labelPlayerTurnName.Text = players[betCounter].Name;
                }
                else
                    houseTurn();
            }
        }

        //Panel hit or stay
        private void btnStay_Click(object sender, EventArgs e)
        {
            //Any players left? No, house turn
            if (betCounter < players.Length - 1)
            {
                betCounter++;
                labelPlayerTurnName.Text = players[betCounter].Name;
            }
            else
                houseTurn();
        }

        //Automatic draw for house turn
        private void houseTurn()
        {
            while (TotalCalculator.CalculateTotal(house.GetHand()) <= 16)
            {
                house.SetHand(house.TakeHit(cards, house.GetHand()));
                cards = Resizer.ResizeDeck(cards, 1);
            }
            displayHouseHand(house, labelHouseName, labelHouseCards, labelHouseTotal);

            panelBet.Hide();
            panelGameOver.Show();
            panelScore.Show();
            displayResults();
        }

        //display the results in the score panel
        private void displayResults()
        {
            scoreLabelPlayerList.Add(labelScorePlayer1);
            scoreLabelPlayerList.Add(labelScorePlayer2);
            scoreLabelPlayerList.Add(labelScorePlayer3);
            scoreLabelPlayerList.Add(labelScorePlayer4);
            scoreLabelPlayerList.Add(labelScorePlayer5);
            scoreLabelPlayerList.Add(labelScorePlayer6);
            scoreLabelPlayerList.Add(labelScorePlayer7);

            outcomeLabelPlayerList.Add(outcomePlayer1);
            outcomeLabelPlayerList.Add(outcomePlayer2);
            outcomeLabelPlayerList.Add(outcomePlayer3);
            outcomeLabelPlayerList.Add(outcomePlayer4);
            outcomeLabelPlayerList.Add(outcomePlayer5);
            outcomeLabelPlayerList.Add(outcomePlayer6);
            outcomeLabelPlayerList.Add(outcomePlayer7);

            //Find players' highest score
            int highScore = 0;
            for (int i = 0; i < players.Length; i++)
            {
                if (TotalCalculator.CalculateTotal(players[i].GetHand()) > highScore && TotalCalculator.CalculateTotal(players[i].GetHand()) < 22)
                {
                    highScore = TotalCalculator.CalculateTotal(players[i].GetHand());
                }
            }

            //Player outcome
            for (int i = 0; i < players.Length; i++)
            {
                scoreLabelPlayerList[i].Show();
                scoreLabelPlayerList[i].Text = players[i].Name;

                outcomeLabelPlayerList[i].Show();
                if (TotalCalculator.CalculateTotal(players[i].GetHand()) < 22)
                {
                    if (TotalCalculator.CalculateTotal(house.GetHand()) > 21)
                    {
                        outcomeLabelPlayerList[i].Text =  "Wins!";
                    }
                    else if (TotalCalculator.CalculateTotal(players[i].GetHand()) > TotalCalculator.CalculateTotal(house.GetHand()))
                    {
                        outcomeLabelPlayerList[i].Text = "Wins!";
                    }
                    else if (TotalCalculator.CalculateTotal(players[i].GetHand()) == TotalCalculator.CalculateTotal(house.GetHand()) &&
                             TotalCalculator.CalculateTotal(players[i].GetHand()) == highScore)
                    {
                        outcomeLabelPlayerList[i].Text = "Tie!";
                    }
                    else
                    {
                        outcomeLabelPlayerList[i].Text = "Loses!";
                    }
                }
                else
                {
                    outcomeLabelPlayerList[i].Text = "Loses!";
                }
            }

            //House outcome
            labelScoreHouse.Show();
            outcomeHouse.Show();
            labelScoreHouse.Text = house.Name;
            if (TotalCalculator.CalculateTotal(house.GetHand()) == highScore)
            {
                outcomeHouse.Text = "Tie!";
            }
            else if (TotalCalculator.CalculateTotal(house.GetHand()) > highScore && TotalCalculator.CalculateTotal(house.GetHand()) < 22)
            {
                outcomeHouse.Text = "Wins!";
            }
            else
            {
                outcomeHouse.Text = "Loses!";
            }
        }

        //Panel Game Over
        private void btnYes_Click(object sender, EventArgs e)
        {
            panelWelcome.Show();

            panelHouse.Hide();
            panelScore.Hide();
            panelGameOver.Hide();
            panelPlayerHands.Hide();
            for (int i = 0; i < players.Length; i++)
            {
                playerPanelList[i].Hide();
                scoreLabelPlayerList[i].Text = "";
                scoreLabelPlayerList[i].Hide();
                outcomeLabelPlayerList[i].Text = "";
                outcomeLabelPlayerList[i].Hide();
            }

            labelHouseTotal.Text = "??";

            deck = new Deck();
            house = new House();

            count = 0;
            betCounter = 0;
        }

        //Panel Game Over
        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
