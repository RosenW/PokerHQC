using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Poker
{

    public partial class Form1 : Form
    {
        #region Variables
        ProgressBar progressBar = new ProgressBar();

        Panel playerPanel = new Panel();
        Panel botOnePanel = new Panel();
        Panel botTwoPanel = new Panel();
        Panel botThreePanel = new Panel();
        Panel botFourPanel = new Panel();
        Panel botFivePanel = new Panel();

        private int call = 500;
        private int foldedPlayers = 5;


        private int Chips = 10000;
        private int botOneChips = 10000;
        private int botTwoChips = 10000;
        private int botThreeChips = 10000;
        private int botFourChips = 10000;
        private int botFiveChips = 10000;


        private double type;
        private double rounds = 0;


        private double botOnePower;
        private double botTwoPower;
        private double botThreePower;
        private double botFourPower;
        private double botFivePower;
        private double playerPower = 0;


        private double playerType = -1;
        private double Raise = 0;
        private double botOneType = -1;
        private double botTwoType = -1;
        private double botThreeType = -1;
        private double botFourType = -1;
        private double botFiveType = -1;


        private bool botOneTurn = false;
        private bool botTwoTurn = false;
        private bool botThreeTurn = false;
        private bool botFourTurn = false;
        private bool botFiveTurn = false;


        private bool botOneFinishedTurn = false;
        private bool botTwoFinishedTurn = false;
        private bool botThreeFinishedTurn = false;
        private bool botFourFinishedTurn = false;
        private bool botFiveFinishedTurn = false;


        private bool playerFolded;
        private bool botOneFolded;
        private bool botTwoFolded;
        private bool botThreeFolded;
        private bool botFourFolded;
        private bool botFiveFolded;


        private bool intsadded;
        private bool changed;


        private int playerCall = 0;
        private int botOneCall = 0;
        private int botTwoCall = 0;
        private int botThreeCall = 0;
        private int botFourCall = 0;
        private int botFiveCall = 0;


        private int playerRaise = 0;
        private int botOneRaise = 0;
        private int botTwoRaise = 0;
        private int botThreeRaise = 0;
        private int botFourRaise = 0;
        private int botFiveRaise = 0;


        private int height;
        private int width;
        private int winners = 0;
        private int Flop = 1;
        private int Turn = 2;
        private int River = 3;
        private int End = 4;
        private int maxLeft = 6;
        private int lastPlayerPlayed = -1;
        private int raisedTurn = 1;

        List<bool?> bools = new List<bool?>();
        List<Type> Win = new List<Type>();
        List<string> CheckWinners = new List<string>();
        List<int> ints = new List<int>();

        private bool playerFinishedTurn = false;
        private bool playerTurn = true;
        private bool restart = false;
        private bool raising = false;
        Poker.Type sorted;
        string[] ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
        /*string[] ImgLocation ={
                   "Assets\\Cards\\33.png","Assets\\Cards\\22.png",
                    "Assets\\Cards\\29.png","Assets\\Cards\\21.png",
                    "Assets\\Cards\\36.png","Assets\\Cards\\17.png",
                    "Assets\\Cards\\40.png","Assets\\Cards\\16.png",
                    "Assets\\Cards\\5.png","Assets\\Cards\\47.png",
                    "Assets\\Cards\\37.png","Assets\\Cards\\13.png",
                    
                    "Assets\\Cards\\12.png",
                    "Assets\\Cards\\8.png","Assets\\Cards\\18.png",
                    "Assets\\Cards\\15.png","Assets\\Cards\\27.png"};*/
        int[] reserve = new int[17];
        Image[] deck = new Image[52];
        PictureBox[] cardHolder = new PictureBox[52];
        Timer timer = new Timer();
        Timer updates = new Timer();

        private int turnTimer = 60;
        private int index;
        private int bigBlind = 500;
        private int smallBlind = 250;
        private int up = 10000000;
        private int turnCount = 0;

        #endregion
        public Form1()
        {
            //bools.Add(playerFinishedHisTurn); bools.Add(botOneFinishedTurn); bools.Add(botTwoFinishedTurn); bools.Add(botThreeFinishedTurn); bools.Add(botFourFinishedTurn); bools.Add(botFiveFinishedTurn);
            call = bigBlind;
            MaximizeBox = false;
            MinimizeBox = false;
            updates.Start();
            InitializeComponent();
            width = this.Width;
            height = this.Height;

            Shuffle();

            EnableChips();


            tbPlayerChips.Text = "Chips : " + Chips.ToString();
            tbBotOneChips.Text = "Chips : " + botOneChips.ToString();
            tbBotTwoChips.Text = "Chips : " + botTwoChips.ToString();
            tbBotThreeChips.Text = "Chips : " + botThreeChips.ToString();
            tbBotFourChips.Text = "Chips : " + botFourChips.ToString();
            tbBotFiveChips.Text = "Chips : " + botFiveChips.ToString();

            timer.Interval = (1000);
            timer.Tick += timer_Tick;
            updates.Interval = (100);
            updates.Tick += Update_Tick;

            SetupBlinds();

            tbRaise.Text = (bigBlind * 2).ToString();
        }

        async Task Shuffle()
        {
            bools.Add(playerFinishedTurn);
            bools.Add(botOneFinishedTurn);
            bools.Add(botTwoFinishedTurn);
            bools.Add(botThreeFinishedTurn);
            bools.Add(botFourFinishedTurn);
            bools.Add(botFiveFinishedTurn);

            bCall.Enabled = false;
            bRaise.Enabled = false;
            bFold.Enabled = false;
            bCheck.Enabled = false;
            MaximizeBox = false;
            MinimizeBox = false;
            bool check = false;

            Bitmap backImage = new Bitmap("Assets\\Back\\Back.png");

            int playerCardsHorizontalPosition = 580;
            int playerCardsVerticalPosition = 480;

            Random rand = new Random();
            for (index = ImgLocation.Length; index > 0; index--)
            {
                int j = rand.Next(index);
                SwitchingImageLocation(j);
            }
            for (index = 0; index < 17; index++)
            {
                deck[index] = Image.FromFile(ImgLocation[index]);
                string[] charsToRemove = new string[] { "Assets\\Cards\\", ".png" };
                foreach (string str in charsToRemove)
                {
                    ImgLocation[index] = ImgLocation[index].Replace(str, string.Empty);
                }
                reserve[index] = int.Parse(ImgLocation[index]) - 1;
                cardHolder[index] = new PictureBox();
                cardHolder[index].SizeMode = PictureBoxSizeMode.StretchImage;
                cardHolder[index].Height = 130;
                cardHolder[index].Width = 80;
                this.Controls.Add(cardHolder[index]);
                cardHolder[index].Name = "pb" + index.ToString();
                await Task.Delay(200);
                #region Throwing Cards
                if (index < 2)
                {
                    if (cardHolder[0].Tag != null)
                    {
                        cardHolder[1].Tag = reserve[1];
                    }
                    cardHolder[0].Tag = reserve[0];
                    cardHolder[index].Image = deck[index];
                    cardHolder[index].Anchor = (AnchorStyles.Bottom);
                    //cardHolder[i].Dock = DockStyle.Top;
                    cardHolder[index].Location = new Point(playerCardsHorizontalPosition, playerCardsVerticalPosition);
                    playerCardsHorizontalPosition += cardHolder[index].Width;
                    this.Controls.Add(playerPanel);
                    playerPanel.Location = new Point(cardHolder[0].Left - 10, cardHolder[0].Top - 10);
                    playerPanel.BackColor = Color.DarkBlue;
                    playerPanel.Height = 150;
                    playerPanel.Width = 180;
                    playerPanel.Visible = false;
                }
                if (botOneChips > 0)
                {
                    foldedPlayers--;
                    if (index >= 2 && index < 4)
                    {
                        if (cardHolder[2].Tag != null)
                        {
                            cardHolder[3].Tag = reserve[3];
                        }
                        cardHolder[2].Tag = reserve[2];
                        if (!check)
                        {
                            playerCardsHorizontalPosition = 15;
                            playerCardsVerticalPosition = 420;
                        }
                        check = true;
                        cardHolder[index].Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                        cardHolder[index].Image = backImage;
                        //cardHolder[i].Image = deck[i];
                        cardHolder[index].Location = new Point(playerCardsHorizontalPosition, playerCardsVerticalPosition);
                        playerCardsHorizontalPosition += cardHolder[index].Width;
                        cardHolder[index].Visible = true;
                        this.Controls.Add(botOnePanel);
                        botOnePanel.Location = new Point(cardHolder[2].Left - 10, cardHolder[2].Top - 10);
                        botOnePanel.BackColor = Color.DarkBlue;
                        botOnePanel.Height = 150;
                        botOnePanel.Width = 180;
                        botOnePanel.Visible = false;
                        if (index == 3)
                        {
                            check = false;
                        }
                    }
                }
                if (botTwoChips > 0)
                {
                    foldedPlayers--;
                    if (index >= 4 && index < 6)
                    {
                        if (cardHolder[4].Tag != null)
                        {
                            cardHolder[5].Tag = reserve[5];
                        }
                        cardHolder[4].Tag = reserve[4];
                        if (!check)
                        {
                            playerCardsHorizontalPosition = 75;
                            playerCardsVerticalPosition = 65;
                        }
                        check = true;
                        cardHolder[index].Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                        cardHolder[index].Image = backImage;
                        //cardHolder[i].Image = deck[i];
                        cardHolder[index].Location = new Point(playerCardsHorizontalPosition, playerCardsVerticalPosition);
                        playerCardsHorizontalPosition += cardHolder[index].Width;
                        cardHolder[index].Visible = true;
                        this.Controls.Add(botTwoPanel);
                        botTwoPanel.Location = new Point(cardHolder[4].Left - 10, cardHolder[4].Top - 10);
                        botTwoPanel.BackColor = Color.DarkBlue;
                        botTwoPanel.Height = 150;
                        botTwoPanel.Width = 180;
                        botTwoPanel.Visible = false;
                        if (index == 5)
                        {
                            check = false;
                        }
                    }
                }
                if (botThreeChips > 0)
                {
                    foldedPlayers--;
                    if (index >= 6 && index < 8)
                    {
                        if (cardHolder[6].Tag != null)
                        {
                            cardHolder[7].Tag = reserve[7];
                        }
                        cardHolder[6].Tag = reserve[6];
                        if (!check)
                        {
                            playerCardsHorizontalPosition = 590;
                            playerCardsVerticalPosition = 25;
                        }
                        check = true;
                        cardHolder[index].Anchor = (AnchorStyles.Top);
                        cardHolder[index].Image = backImage;
                        //cardHolder[i].Image = deck[i];
                        cardHolder[index].Location = new Point(playerCardsHorizontalPosition, playerCardsVerticalPosition);
                        playerCardsHorizontalPosition += cardHolder[index].Width;
                        cardHolder[index].Visible = true;
                        this.Controls.Add(botThreePanel);
                        botThreePanel.Location = new Point(cardHolder[6].Left - 10, cardHolder[6].Top - 10);
                        botThreePanel.BackColor = Color.DarkBlue;
                        botThreePanel.Height = 150;
                        botThreePanel.Width = 180;
                        botThreePanel.Visible = false;
                        if (index == 7)
                        {
                            check = false;
                        }
                    }
                }
                if (botFourChips > 0)
                {
                    foldedPlayers--;
                    if (index >= 8 && index < 10)
                    {
                        if (cardHolder[8].Tag != null)
                        {
                            cardHolder[9].Tag = reserve[9];
                        }
                        cardHolder[8].Tag = reserve[8];
                        if (!check)
                        {
                            playerCardsHorizontalPosition = 1115;
                            playerCardsVerticalPosition = 65;
                        }
                        check = true;
                        cardHolder[index].Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                        cardHolder[index].Image = backImage;
                        //cardHolder[i].Image = deck[i];
                        cardHolder[index].Location = new Point(playerCardsHorizontalPosition, playerCardsVerticalPosition);
                        playerCardsHorizontalPosition += cardHolder[index].Width;
                        cardHolder[index].Visible = true;
                        this.Controls.Add(botFourPanel);
                        botFourPanel.Location = new Point(cardHolder[8].Left - 10, cardHolder[8].Top - 10);
                        botFourPanel.BackColor = Color.DarkBlue;
                        botFourPanel.Height = 150;
                        botFourPanel.Width = 180;
                        botFourPanel.Visible = false;
                        if (index == 9)
                        {
                            check = false;
                        }
                    }
                }
                if (botFiveChips > 0)
                {
                    foldedPlayers--;
                    if (index >= 10 && index < 12)
                    {
                        if (cardHolder[10].Tag != null)
                        {
                            cardHolder[11].Tag = reserve[11];
                        }
                        cardHolder[10].Tag = reserve[10];
                        if (!check)
                        {
                            playerCardsHorizontalPosition = 1160;
                            playerCardsVerticalPosition = 420;
                        }
                        check = true;
                        cardHolder[index].Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                        cardHolder[index].Image = backImage;
                        //cardHolder[i].Image = deck[i];
                        cardHolder[index].Location = new Point(playerCardsHorizontalPosition, playerCardsVerticalPosition);
                        playerCardsHorizontalPosition += cardHolder[index].Width;
                        cardHolder[index].Visible = true;
                        this.Controls.Add(botFivePanel);
                        botFivePanel.Location = new Point(cardHolder[10].Left - 10, cardHolder[10].Top - 10);
                        botFivePanel.BackColor = Color.DarkBlue;
                        botFivePanel.Height = 150;
                        botFivePanel.Width = 180;
                        botFivePanel.Visible = false;
                        if (index == 11)
                        {
                            check = false;
                        }
                    }
                }
                if (index >= 12)
                {
                    cardHolder[12].Tag = reserve[12];
                    if (index > 12) cardHolder[13].Tag = reserve[13];
                    if (index > 13) cardHolder[14].Tag = reserve[14];
                    if (index > 14) cardHolder[15].Tag = reserve[15];
                    if (index > 15)
                    {
                        cardHolder[16].Tag = reserve[16];

                    }
                    if (!check)
                    {
                        playerCardsHorizontalPosition = 410;
                        playerCardsVerticalPosition = 265;
                    }
                    check = true;
                    if (cardHolder[index] != null)
                    {
                        cardHolder[index].Anchor = AnchorStyles.None;
                        cardHolder[index].Image = backImage;
                        //cardHolder[i].Image = deck[i];
                        cardHolder[index].Location = new Point(playerCardsHorizontalPosition, playerCardsVerticalPosition);
                        playerCardsHorizontalPosition += 110;
                    }
                }
                #endregion
                if (botOneChips <= 0)
                {
                    BotChipsVisible(ref botOneFinishedTurn, 2);
                }
                else
                {
                    ElseBotChipsVisible(ref botOneFinishedTurn, 2);
                }
                if (botTwoChips <= 0)
                {
                    BotChipsVisible(ref botTwoFinishedTurn, 4);
                }
                else
                {
                    ElseBotChipsVisible(ref botTwoFinishedTurn, 4);
                }
                if (botThreeChips <= 0)
                {
                    BotChipsVisible(ref botThreeFinishedTurn, 6);
                }
                else
                {
                    ElseBotChipsVisible(ref botThreeFinishedTurn, 6);
                }
                if (botFourChips <= 0)
                {
                    BotChipsVisible(ref botFourFinishedTurn, 8);
                }
                else
                {
                    ElseBotChipsVisible(ref botFourFinishedTurn, 8);
                }
                if (botFiveChips <= 0)
                {
                    BotChipsVisible(ref botFiveFinishedTurn, 10);
                }
                else
                {
                    ElseBotChipsVisible(ref botFiveFinishedTurn, 10);
                }
                if (index == 16 && !restart)
                {
                    MaximizeBox = true;
                    MinimizeBox = true;
                    timer.Start();
                }
            }
            if (foldedPlayers == 5)
            {
                DialogResult dialogResult = MessageBox.Show("Would You Like To Play Again ?", "You Won , Congratulations ! ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else
            {
                foldedPlayers = 5;
            }
            if (index == 17)
            {
                bRaise.Enabled = true;
                bCall.Enabled = true;
                bRaise.Enabled = true;
                bRaise.Enabled = true;
                bFold.Enabled = true;
            }
        }

        private void ElseBotChipsVisible(ref bool botFinishedTurn, int cardIndex)
        {
            botFinishedTurn = false;
            if (index == cardIndex + 1 && cardHolder[cardIndex + 1] != null)
            {
                cardHolder[cardIndex].Visible = true;
                cardHolder[cardIndex + 1].Visible = true;
            }
        }

        private void BotChipsVisible(ref bool botNumberFinishedTurn, int cardIndex)
        {
            botNumberFinishedTurn = true;
            cardHolder[cardIndex].Visible = false;
            cardHolder[cardIndex + 1].Visible = false;
        }

        private void SwitchingImageLocation(int j)
        {
            string newImageLocation = ImgLocation[j];
            ImgLocation[j] = ImgLocation[index - 1];
            ImgLocation[index - 1] = newImageLocation;
        }

        async Task Turns()
        {
            #region Rotating
            
                if (playerTurn)
                {
                    FixCall(pStatus, ref playerCall, ref playerRaise, 1);
                    //MessageBox.Show("Player's Turn");
                    pbTimer.Visible = true;
                    pbTimer.Value = 1000;
                    turnTimer = 60;
                    up = 10000000;
                    timer.Start();
                    bRaise.Enabled = true;
                    bCall.Enabled = true;
                    bRaise.Enabled = true;
                    bRaise.Enabled = true;
                    bFold.Enabled = true;
                    turnCount++;
                    FixCall(pStatus, ref playerCall, ref playerRaise, 2);
                }
            
            if (playerFinishedTurn || !playerTurn)
            {
                await AllIn();
                if (playerFinishedTurn && !playerFolded)
                {
                    if (bCall.Text.Contains("All in") == false || bRaise.Text.Contains("All in") == false)
                    {
                        bools.RemoveAt(0);
                        bools.Insert(0, null);
                        maxLeft--;
                        playerFolded = true;
                    }
                }
                await CheckRaise(0, 0);
                pbTimer.Visible = false;
                bRaise.Enabled = false;
                bCall.Enabled = false;
                bRaise.Enabled = false;
                bRaise.Enabled = false;
                bFold.Enabled = false;
                timer.Stop();
                botOneTurn = true;
                
                    if (botOneTurn)
                    {
                        FixCall(b1Status, ref botOneCall, ref botOneRaise, 1);
                        FixCall(b1Status, ref botOneCall, ref botOneRaise, 2);
                        Rules(2, 3, "Bot 1", ref botOneType, ref botOnePower, botOneFinishedTurn);
                        MessageBox.Show("Bot 1's Turn");
                        AI(2, 3, ref botOneChips, ref botOneTurn, ref botOneFinishedTurn, b1Status, 0, botOnePower, botOneType);
                        turnCount++;
                        lastPlayerPlayed = 1;
                        botOneTurn = false;
                        botTwoTurn = true;
                    }
                
                if (botOneFinishedTurn && !botOneFolded)
                {
                    bools.RemoveAt(1);
                    bools.Insert(1, null);
                    maxLeft--;
                    botOneFolded = true;
                }
                if (botOneFinishedTurn || !botOneTurn)
                {
                    await CheckRaise(1, 1);
                    botTwoTurn = true;
                }
               
                    if (botTwoTurn)
                    {
                        FixCall(b2Status, ref botTwoCall, ref botTwoRaise, 1);
                        FixCall(b2Status, ref botTwoCall, ref botTwoRaise, 2);
                        Rules(4, 5, "Bot 2", ref botTwoType, ref botTwoPower, botTwoFinishedTurn);
                        MessageBox.Show("Bot 2's Turn");
                        AI(4, 5, ref botTwoChips, ref botTwoTurn, ref botTwoFinishedTurn, b2Status, 1, botTwoPower, botTwoType);
                        turnCount++;
                        lastPlayerPlayed = 2;
                        botTwoTurn = false;
                        botThreeTurn = true;
                    }
                
                if (botTwoFinishedTurn && !botTwoFolded)
                {
                    bools.RemoveAt(2);
                    bools.Insert(2, null);
                    maxLeft--;
                    botTwoFolded = true;
                }
                if (botTwoFinishedTurn || !botTwoTurn)
                {
                    await CheckRaise(2, 2);
                    botThreeTurn = true;
                }
               
                    if (botThreeTurn)
                    {
                        FixCall(b3Status, ref botThreeCall, ref botThreeRaise, 1);
                        FixCall(b3Status, ref botThreeCall, ref botThreeRaise, 2);
                        Rules(6, 7, "Bot 3", ref botThreeType, ref botThreePower, botThreeFinishedTurn);
                        MessageBox.Show("Bot 3's Turn");
                        AI(6, 7, ref botThreeChips, ref botThreeTurn, ref botThreeFinishedTurn, b3Status, 2, botThreePower, botThreeType);
                        turnCount++;
                        lastPlayerPlayed = 3;
                        botThreeTurn = false;
                        botFourTurn = true;
                    }
                
                if (botThreeFinishedTurn && !botThreeFolded)
                {
                    bools.RemoveAt(3);
                    bools.Insert(3, null);
                    maxLeft--;
                    botThreeFolded = true;
                }
                if (botThreeFinishedTurn || !botThreeTurn)
                {
                    await CheckRaise(3, 3);
                    botFourTurn = true;
                }
                
                    if (botFourTurn)
                    {
                        FixCall(b4Status, ref botFourCall, ref botFourRaise, 1);
                        FixCall(b4Status, ref botFourCall, ref botFourRaise, 2);
                        Rules(8, 9, "Bot 4", ref botFourType, ref botFourPower, botFourFinishedTurn);
                        MessageBox.Show("Bot 4's Turn");
                        AI(8, 9, ref botFourChips, ref botFourTurn, ref botFourFinishedTurn, b4Status, 3, botFourPower, botFourType);
                        turnCount++;
                        lastPlayerPlayed = 4;
                        botFourTurn = false;
                        botFiveTurn = true;
                    }
                
                if (botFourFinishedTurn && !botFourFolded)
                {
                    bools.RemoveAt(4);
                    bools.Insert(4, null);
                    maxLeft--;
                    botFourFolded = true;
                }
                if (botFourFinishedTurn || !botFourTurn)
                {
                    await CheckRaise(4, 4);
                    botFiveTurn = true;
                }
                
                    if (botFiveTurn)
                    {
                        FixCall(b5Status, ref botFiveCall, ref botFiveRaise, 1);
                        FixCall(b5Status, ref botFiveCall, ref botFiveRaise, 2);
                        Rules(10, 11, "Bot 5", ref botFiveType, ref botFivePower, botFiveFinishedTurn);
                        MessageBox.Show("Bot 5's Turn");
                        AI(10, 11, ref botFiveChips, ref botFiveTurn, ref botFiveFinishedTurn, b5Status, 4, botFivePower, botFiveType);
                        turnCount++;
                        lastPlayerPlayed = 5;
                        botFiveTurn = false;
                    }
                
                if (botFiveFinishedTurn && !botFiveFolded)
                {
                    bools.RemoveAt(5);
                    bools.Insert(5, null);
                    maxLeft--;
                    botFiveFolded = true;
                }
                if (botFiveFinishedTurn || !botFiveTurn)
                {
                    await CheckRaise(5, 5);
                    playerTurn = true;
                }
                if (playerFinishedTurn && !playerFolded)
                {
                    if (bCall.Text.Contains("All in") == false || bRaise.Text.Contains("All in") == false)
                    {
                        bools.RemoveAt(0);
                        bools.Insert(0, null);
                        maxLeft--;
                        playerFolded = true;
                    }
                }
                #endregion
                await AllIn();
                if (!restart)
                {
                    await Turns();
                }
                restart = false;
            }
        }

        void Rules(int cardOne, int cardTwo, string currentText, ref double currentHand, ref double power, bool foldedTurn)
        {
            if (cardOne == 0 && cardTwo == 1)
            {
            }
            if (!foldedTurn || cardOne == 0 && cardTwo == 1 && pStatus.Text.Contains("Fold") == false)
            {
                #region Variables
                bool done = false, vf = false;
                int[] Straight1 = new int[5];
                int[] Straight = new int[7];
                Straight[0] = reserve[cardOne];
                Straight[1] = reserve[cardTwo];
                Straight1[0] = Straight[2] = reserve[12];
                Straight1[1] = Straight[3] = reserve[13];
                Straight1[2] = Straight[4] = reserve[14];
                Straight1[3] = Straight[5] = reserve[15];
                Straight1[4] = Straight[6] = reserve[16];
                var a = Straight.Where(o => o % 4 == 0).ToArray();
                var b = Straight.Where(o => o % 4 == 1).ToArray();
                var c = Straight.Where(o => o % 4 == 2).ToArray();
                var d = Straight.Where(o => o % 4 == 3).ToArray();
                var st1 = a.Select(o => o / 4).Distinct().ToArray();
                var st2 = b.Select(o => o / 4).Distinct().ToArray();
                var st3 = c.Select(o => o / 4).Distinct().ToArray();
                var st4 = d.Select(o => o / 4).Distinct().ToArray();
                Array.Sort(Straight); Array.Sort(st1); Array.Sort(st2); Array.Sort(st3); Array.Sort(st4);
                #endregion
                for (index = 0; index < 16; index++)
                {
                    if (reserve[index] == int.Parse(cardHolder[cardOne].Tag.ToString()) && reserve[index + 1] == int.Parse(cardHolder[cardTwo].Tag.ToString()))
                    {
                        //Pair from Hand current = 1

                        RPairFromHand(ref currentHand, ref power);

                        #region Pair or Two Pair from Table current = 2 || 0
                        RPairTwoPair(ref currentHand, ref power);
                        #endregion

                        #region Two Pair current = 2
                        RTwoPair(ref currentHand, ref power);
                        #endregion

                        #region Three of a kind current = 3
                        RThreeOfAKind(ref currentHand, ref power, Straight);
                        #endregion

                        #region Straight current = 4
                        RStraight(ref currentHand, ref power, Straight);
                        #endregion

                        #region Flush current = 5 || 5.5
                        RFlush(ref currentHand, ref power, ref vf, Straight1);
                        #endregion

                        #region Full House current = 6
                        RFullHouse(ref currentHand, ref power, ref done, Straight);
                        #endregion

                        #region Four of a Kind current = 7
                        RFourOfAKind(ref currentHand, ref power, Straight);
                        #endregion

                        #region Straight Flush current = 8 || 9
                        rStraightFlush(ref currentHand, ref power, st1, st2, st3, st4);
                        #endregion

                        #region High Card current = -1
                        RHighCard(ref currentHand, ref power);
                        #endregion
                    }
                }
            }
        }
        private void rStraightFlush(ref double current, ref double Power, int[] st1, int[] st2, int[] st3, int[] st4)
        {
            if (current >= -1)
            {
                if (st1.Length >= 5)
                {
                    if (st1[0] + 4 == st1[4])
                    {
                        CalculatePower(out Power, ref st1, 8);
                    }
                    if (st1[0] == 0 && st1[1] == 9 && st1[2] == 10 && st1[3] == 11 && st1[0] + 12 == st1[4])
                    {
                        CalculatePower(out Power, ref st1, 9);
                    }
                }
                if (st2.Length >= 5)
                {
                    if (st2[0] + 4 == st2[4])
                    {
                        CalculatePower(out Power, ref st2, 8);
                    }
                    if (st2[0] == 0 && st2[1] == 9 && st2[2] == 10 && st2[3] == 11 && st2[0] + 12 == st2[4])
                    {
                        CalculatePower(out Power, ref st2, 9);
                    }
                }
                if (st3.Length >= 5)
                {
                    if (st3[0] + 4 == st3[4])
                    {
                        CalculatePower(out Power, ref st3, 8);
                    }
                    if (st3[0] == 0 && st3[1] == 9 && st3[2] == 10 && st3[3] == 11 && st3[0] + 12 == st3[4])
                    {
                        CalculatePower(out Power, ref st3, 9);
                    }
                }
                if (st4.Length >= 5)
                {
                    if (st4[0] + 4 == st4[4])
                    {
                        CalculatePower(out Power, ref st4, 8);
                    }
                    if (st4[0] == 0 && st4[1] == 9 && st4[2] == 10 && st4[3] == 11 && st4[0] + 12 == st4[4])
                    {
                        CalculatePower(out Power, ref st4, 9);
                    }
                }
            }
        }

        private void CalculatePower(out double Power, ref int[] st1, int currentIndex)
        {
            Power = (st1.Max()) / 4 + currentIndex * 100;
            Win.Add(new Type() { Power = Power, Current = currentIndex });
            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
        }

        private void RFourOfAKind(ref double current, ref double Power, int[] Straight)
        {
            if (current >= -1)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (Straight[j] / 4 == Straight[j + 1] / 4 && Straight[j] / 4 == Straight[j + 2] / 4 &&
                        Straight[j] / 4 == Straight[j + 3] / 4)
                    {
                        current = 7;
                        Power = (Straight[j] / 4) * 4 + current * 100;
                        Win.Add(new Type() { Power = Power, Current = 7 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (Straight[j] / 4 == 0 && Straight[j + 1] / 4 == 0 && Straight[j + 2] / 4 == 0 && Straight[j + 3] / 4 == 0)
                    {
                        current = 7;
                        Power = 13 * 4 + current * 100;
                        Win.Add(new Type() { Power = Power, Current = 7 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
            }
        }
        private void RFullHouse(ref double current, ref double Power, ref bool done, int[] Straight)
        {
            if (current >= -1)
            {
                type = Power;
                for (int j = 0; j <= 12; j++)
                {
                    var fh = Straight.Where(o => o / 4 == j).ToArray();
                    if (fh.Length == 3 || done && fh.Length == 2)
                    {
                        if (fh.Max() / 4 == 0)
                        {
                            current = 6;
                            Power = 13 * 2 + current * 100;
                            Win.Add(new Type() { Power = Power, Current = 6 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            break;
                        }
                        if (fh.Max() / 4 > 0)
                        {
                            current = 6;
                            Power = fh.Max() / 4 * 2 + current * 100;
                            Win.Add(new Type() { Power = Power, Current = 6 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            break;
                        }
                        if (!done)
                        {
                            if (fh.Max() / 4 == 0)
                            {
                                Power = 13;
                                done = true;
                                j = -1;
                            }
                            else
                            {
                                Power = fh.Max() / 4;
                                done = true;
                                j = -1;
                            }
                        }
                    }
                }
                if (current != 6)
                {
                    Power = type;
                }
            }
        }
        private void RFlush(ref double current, ref double power, ref bool vf, int[] straight1)
        {
            if (current >= -1)
            {
                var f1 = straight1.Where(o => o % 4 == 0).ToArray();
                var f2 = straight1.Where(o => o % 4 == 1).ToArray();
                var f3 = straight1.Where(o => o % 4 == 2).ToArray();
                var f4 = straight1.Where(o => o % 4 == 3).ToArray();
                if (f1.Length == 3 || f1.Length == 4)
                {
                    if (reserve[index] % 4 == reserve[index + 1] % 4 && reserve[index] % 4 == f1[0] % 4)
                    {
                        if (reserve[index] / 4 > f1.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        if (reserve[index + 1] / 4 > f1.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index + 1] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else if (reserve[index] / 4 < f1.Max() / 4 && reserve[index + 1] / 4 < f1.Max() / 4)
                        {
                            current = 5;
                            power = f1.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f1.Length == 4)//different cards in hand
                {
                    if (reserve[index] % 4 != reserve[index + 1] % 4 && reserve[index] % 4 == f1[0] % 4)
                    {
                        if (reserve[index] / 4 > f1.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            power = f1.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                    if (reserve[index + 1] % 4 != reserve[index] % 4 && reserve[index + 1] % 4 == f1[0] % 4)
                    {
                        if (reserve[index + 1] / 4 > f1.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index + 1] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            power = f1.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f1.Length == 5)
                {
                    if (reserve[index] % 4 == f1[0] % 4 && reserve[index] / 4 > f1.Min() / 4)
                    {
                        current = 5;
                        power = reserve[index] + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    if (reserve[index + 1] % 4 == f1[0] % 4 && reserve[index + 1] / 4 > f1.Min() / 4)
                    {
                        current = 5;
                        power = reserve[index + 1] + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    else if (reserve[index] / 4 < f1.Min() / 4 && reserve[index + 1] / 4 < f1.Min())
                    {
                        current = 5;
                        power = f1.Max() + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                }

                if (f2.Length == 3 || f2.Length == 4)
                {
                    if (reserve[index] % 4 == reserve[index + 1] % 4 && reserve[index] % 4 == f2[0] % 4)
                    {
                        if (reserve[index] / 4 > f2.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        if (reserve[index + 1] / 4 > f2.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index + 1] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else if (reserve[index] / 4 < f2.Max() / 4 && reserve[index + 1] / 4 < f2.Max() / 4)
                        {
                            current = 5;
                            power = f2.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f2.Length == 4)//different cards in hand
                {
                    if (reserve[index] % 4 != reserve[index + 1] % 4 && reserve[index] % 4 == f2[0] % 4)
                    {
                        if (reserve[index] / 4 > f2.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            power = f2.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                    if (reserve[index + 1] % 4 != reserve[index] % 4 && reserve[index + 1] % 4 == f2[0] % 4)
                    {
                        if (reserve[index + 1] / 4 > f2.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index + 1] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            power = f2.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f2.Length == 5)
                {
                    if (reserve[index] % 4 == f2[0] % 4 && reserve[index] / 4 > f2.Min() / 4)
                    {
                        current = 5;
                        power = reserve[index] + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    if (reserve[index + 1] % 4 == f2[0] % 4 && reserve[index + 1] / 4 > f2.Min() / 4)
                    {
                        current = 5;
                        power = reserve[index + 1] + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    else if (reserve[index] / 4 < f2.Min() / 4 && reserve[index + 1] / 4 < f2.Min())
                    {
                        current = 5;
                        power = f2.Max() + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                }

                if (f3.Length == 3 || f3.Length == 4)
                {
                    if (reserve[index] % 4 == reserve[index + 1] % 4 && reserve[index] % 4 == f3[0] % 4)
                    {
                        if (reserve[index] / 4 > f3.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        if (reserve[index + 1] / 4 > f3.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index + 1] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else if (reserve[index] / 4 < f3.Max() / 4 && reserve[index + 1] / 4 < f3.Max() / 4)
                        {
                            current = 5;
                            power = f3.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f3.Length == 4)//different cards in hand
                {
                    if (reserve[index] % 4 != reserve[index + 1] % 4 && reserve[index] % 4 == f3[0] % 4)
                    {
                        if (reserve[index] / 4 > f3.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            power = f3.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                    if (reserve[index + 1] % 4 != reserve[index] % 4 && reserve[index + 1] % 4 == f3[0] % 4)
                    {
                        if (reserve[index + 1] / 4 > f3.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index + 1] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            power = f3.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f3.Length == 5)
                {
                    if (reserve[index] % 4 == f3[0] % 4 && reserve[index] / 4 > f3.Min() / 4)
                    {
                        current = 5;
                        power = reserve[index] + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    if (reserve[index + 1] % 4 == f3[0] % 4 && reserve[index + 1] / 4 > f3.Min() / 4)
                    {
                        current = 5;
                        power = reserve[index + 1] + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    else if (reserve[index] / 4 < f3.Min() / 4 && reserve[index + 1] / 4 < f3.Min())
                    {
                        current = 5;
                        power = f3.Max() + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                }

                if (f4.Length == 3 || f4.Length == 4)
                {
                    if (reserve[index] % 4 == reserve[index + 1] % 4 && reserve[index] % 4 == f4[0] % 4)
                    {
                        if (reserve[index] / 4 > f4.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        if (reserve[index + 1] / 4 > f4.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index + 1] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else if (reserve[index] / 4 < f4.Max() / 4 && reserve[index + 1] / 4 < f4.Max() / 4)
                        {
                            current = 5;
                            power = f4.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f4.Length == 4)//different cards in hand
                {
                    if (reserve[index] % 4 != reserve[index + 1] % 4 && reserve[index] % 4 == f4[0] % 4)
                    {
                        if (reserve[index] / 4 > f4.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            power = f4.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                    if (reserve[index + 1] % 4 != reserve[index] % 4 && reserve[index + 1] % 4 == f4[0] % 4)
                    {
                        if (reserve[index + 1] / 4 > f4.Max() / 4)
                        {
                            current = 5;
                            power = reserve[index + 1] + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                        else
                        {
                            current = 5;
                            power = f4.Max() + current * 100;
                            Win.Add(new Type() { Power = power, Current = 5 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                            vf = true;
                        }
                    }
                }
                if (f4.Length == 5)
                {
                    if (reserve[index] % 4 == f4[0] % 4 && reserve[index] / 4 > f4.Min() / 4)
                    {
                        current = 5;
                        power = reserve[index] + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    if (reserve[index + 1] % 4 == f4[0] % 4 && reserve[index + 1] / 4 > f4.Min() / 4)
                    {
                        current = 5;
                        power = reserve[index + 1] + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                    else if (reserve[index] / 4 < f4.Min() / 4 && reserve[index + 1] / 4 < f4.Min())
                    {
                        current = 5;
                        power = f4.Max() + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        vf = true;
                    }
                }
                //ace
                if (f1.Length > 0)
                {
                    if (reserve[index] / 4 == 0 && reserve[index] % 4 == f1[0] % 4 && vf && f1.Length > 0)
                    {
                        current = 5.5;
                        power = 13 + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (reserve[index + 1] / 4 == 0 && reserve[index + 1] % 4 == f1[0] % 4 && vf && f1.Length > 0)
                    {
                        current = 5.5;
                        power = 13 + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
                if (f2.Length > 0)
                {
                    if (reserve[index] / 4 == 0 && reserve[index] % 4 == f2[0] % 4 && vf && f2.Length > 0)
                    {
                        current = 5.5;
                        power = 13 + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (reserve[index + 1] / 4 == 0 && reserve[index + 1] % 4 == f2[0] % 4 && vf && f2.Length > 0)
                    {
                        current = 5.5;
                        power = 13 + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
                if (f3.Length > 0)
                {
                    if (reserve[index] / 4 == 0 && reserve[index] % 4 == f3[0] % 4 && vf && f3.Length > 0)
                    {
                        current = 5.5;
                        power = 13 + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (reserve[index + 1] / 4 == 0 && reserve[index + 1] % 4 == f3[0] % 4 && vf && f3.Length > 0)
                    {
                        current = 5.5;
                        power = 13 + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
                if (f4.Length > 0)
                {
                    if (reserve[index] / 4 == 0 && reserve[index] % 4 == f4[0] % 4 && vf && f4.Length > 0)
                    {
                        current = 5.5;
                        power = 13 + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                    if (reserve[index + 1] / 4 == 0 && reserve[index + 1] % 4 == f4[0] % 4 && vf)
                    {
                        current = 5.5;
                        power = 13 + current * 100;
                        Win.Add(new Type() { Power = power, Current = 5.5 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
            }
        }
        private void RStraight(ref double current, ref double Power, int[] Straight)
        {
            if (current >= -1)
            {
                var op = Straight.Select(o => o / 4).Distinct().ToArray();
                for (int j = 0; j < op.Length - 4; j++)
                {
                    if (op[j] + 4 == op[j + 4])
                    {
                        if (op.Max() - 4 == op[j])
                        {
                            current = 4;
                            Power = op.Max() + current * 100;
                            Win.Add(new Type() { Power = Power, Current = 4 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        }
                        else
                        {
                            current = 4;
                            Power = op[j + 4] + current * 100;
                            Win.Add(new Type() { Power = Power, Current = 4 });
                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                        }
                    }
                    if (op[j] == 0 && op[j + 1] == 9 && op[j + 2] == 10 && op[j + 3] == 11 && op[j + 4] == 12)
                    {
                        current = 4;
                        Power = 13 + current * 100;
                        Win.Add(new Type() { Power = Power, Current = 4 });
                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                    }
                }
            }
        }
        private void RThreeOfAKind(ref double current, ref double Power, int[] Straight)
        {
            if (current >= -1)
            {
                for (int j = 0; j <= 12; j++)
                {
                    var fh = Straight.Where(o => o / 4 == j).ToArray();
                    if (fh.Length == 3)
                    {
                        if (fh.Max() / 4 == 0)
                        {
                            current = 3;
                            Power = 13 * 3 + current * 100;
                            Win.Add(new Type() { Power = Power, Current = 3 });
                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                        }
                        else
                        {
                            current = 3;
                            Power = fh[0] / 4 + fh[1] / 4 + fh[2] / 4 + current * 100;
                            Win.Add(new Type() { Power = Power, Current = 3 });
                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                        }
                    }
                }
            }
        }
        private void RTwoPair(ref double current, ref double Power)
        {
            if (current >= -1)
            {
                bool msgbox = false;
                for (int tc = 16; tc >= 12; tc--)
                {
                    int max = tc - 12;
                    if (reserve[index] / 4 != reserve[index + 1] / 4)
                    {
                        for (int k = 1; k <= max; k++)
                        {
                            if (tc - k < 12)
                            {
                                max--;
                            }
                            if (tc - k >= 12)
                            {
                                if (reserve[index] / 4 == reserve[tc] / 4 && reserve[index + 1] / 4 == reserve[tc - k] / 4 ||
                                    reserve[index + 1] / 4 == reserve[tc] / 4 && reserve[index] / 4 == reserve[tc - k] / 4)
                                {
                                    if (!msgbox)
                                    {
                                        if (reserve[index] / 4 == 0)
                                        {
                                            current = 2;
                                            Power = 13 * 4 + (reserve[index + 1] / 4) * 2 + current * 100;
                                            Win.Add(new Type() { Power = Power, Current = 2 });
                                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                                        }
                                        if (reserve[index + 1] / 4 == 0)
                                        {
                                            current = 2;
                                            Power = 13 * 4 + (reserve[index] / 4) * 2 + current * 100;
                                            Win.Add(new Type() { Power = Power, Current = 2 });
                                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                                        }
                                        if (reserve[index + 1] / 4 != 0 && reserve[index] / 4 != 0)
                                        {
                                            current = 2;
                                            Power = (reserve[index] / 4) * 2 + (reserve[index + 1] / 4) * 2 + current * 100;
                                            Win.Add(new Type() { Power = Power, Current = 2 });
                                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                                        }
                                    }
                                    msgbox = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void RPairTwoPair(ref double current, ref double Power)
        {
            if (current >= -1)
            {
                bool msgbox = false;
                bool msgbox1 = false;
                for (int tc = 16; tc >= 12; tc--)
                {
                    int max = tc - 12;
                    for (int k = 1; k <= max; k++)
                    {
                        if (tc - k < 12)
                        {
                            max--;
                        }
                        if (tc - k >= 12)
                        {
                            if (reserve[tc] / 4 == reserve[tc - k] / 4)
                            {
                                if (reserve[tc] / 4 != reserve[index] / 4 && reserve[tc] / 4 != reserve[index + 1] / 4 && current == 1)
                                {
                                    if (!msgbox)
                                    {
                                        if (reserve[index + 1] / 4 == 0)
                                        {
                                            current = 2;
                                            Power = (reserve[index] / 4) * 2 + 13 * 4 + current * 100;
                                            Win.Add(new Type() { Power = Power, Current = 2 });
                                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                                        }
                                        if (reserve[index] / 4 == 0)
                                        {
                                            current = 2;
                                            Power = (reserve[index + 1] / 4) * 2 + 13 * 4 + current * 100;
                                            Win.Add(new Type() { Power = Power, Current = 2 });
                                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                                        }
                                        if (reserve[index + 1] / 4 != 0)
                                        {
                                            current = 2;
                                            Power = (reserve[tc] / 4) * 2 + (reserve[index + 1] / 4) * 2 + current * 100;
                                            Win.Add(new Type() { Power = Power, Current = 2 });
                                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                                        }
                                        if (reserve[index] / 4 != 0)
                                        {
                                            current = 2;
                                            Power = (reserve[tc] / 4) * 2 + (reserve[index] / 4) * 2 + current * 100;
                                            Win.Add(new Type() { Power = Power, Current = 2 });
                                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                                        }
                                    }
                                    msgbox = true;
                                }
                                if (current == -1)
                                {
                                    if (!msgbox1)
                                    {
                                        if (reserve[index] / 4 > reserve[index + 1] / 4)
                                        {
                                            if (reserve[tc] / 4 == 0)
                                            {
                                                current = 0;
                                                Power = 13 + reserve[index] / 4 + current * 100;
                                                Win.Add(new Type() { Power = Power, Current = 1 });
                                                sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                                            }
                                            else
                                            {
                                                current = 0;
                                                Power = reserve[tc] / 4 + reserve[index] / 4 + current * 100;
                                                Win.Add(new Type() { Power = Power, Current = 1 });
                                                sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                                            }
                                        }
                                        else
                                        {
                                            if (reserve[tc] / 4 == 0)
                                            {
                                                current = 0;
                                                Power = 13 + reserve[index + 1] + current * 100;
                                                Win.Add(new Type() { Power = Power, Current = 1 });
                                                sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                                            }
                                            else
                                            {
                                                current = 0;
                                                Power = reserve[tc] / 4 + reserve[index + 1] / 4 + current * 100;
                                                Win.Add(new Type() { Power = Power, Current = 1 });
                                                sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                                            }
                                        }
                                    }
                                    msgbox1 = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void RPairFromHand(ref double current, ref double Power)
        {
            if (current >= -1)
            {
                bool msgbox = false;
                if (reserve[index] / 4 == reserve[index + 1] / 4)
                {
                    if (!msgbox)
                    {
                        if (reserve[index] / 4 == 0)
                        {
                            current = 1;
                            Power = 13 * 4 + current * 100;
                            Win.Add(new Type() { Power = Power, Current = 1 });
                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                        }
                        else
                        {
                            current = 1;
                            Power = (reserve[index + 1] / 4) * 4 + current * 100;
                            Win.Add(new Type() { Power = Power, Current = 1 });
                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                        }
                    }
                    msgbox = true;
                }
                for (int tc = 16; tc >= 12; tc--)
                {
                    if (reserve[index + 1] / 4 == reserve[tc] / 4)
                    {
                        if (!msgbox)
                        {
                            if (reserve[index + 1] / 4 == 0)
                            {
                                current = 1;
                                Power = 13 * 4 + reserve[index] / 4 + current * 100;
                                Win.Add(new Type() { Power = Power, Current = 1 });
                                sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                            }
                            else
                            {
                                current = 1;
                                Power = (reserve[index + 1] / 4) * 4 + reserve[index] / 4 + current * 100;
                                Win.Add(new Type() { Power = Power, Current = 1 });
                                sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                            }
                        }
                        msgbox = true;
                    }
                    if (reserve[index] / 4 == reserve[tc] / 4)
                    {
                        if (!msgbox)
                        {
                            if (reserve[index] / 4 == 0)
                            {
                                current = 1;
                                Power = 13 * 4 + reserve[index + 1] / 4 + current * 100;
                                Win.Add(new Type() { Power = Power, Current = 1 });
                                sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                            }
                            else
                            {
                                current = 1;
                                Power = (reserve[tc] / 4) * 4 + reserve[index + 1] / 4 + current * 100;
                                Win.Add(new Type() { Power = Power, Current = 1 });
                                sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
                            }
                        }
                        msgbox = true;
                    }
                }
            }
        }
        private void RHighCard(ref double current, ref double Power)
        {
            if (current == -1)
            {
                if (reserve[index] / 4 > reserve[index + 1] / 4)
                {
                    current = -1;
                    Power = reserve[index] / 4;
                    Win.Add(new Type() { Power = Power, Current = -1 });
                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                }
                else
                {
                    current = -1;
                    Power = reserve[index + 1] / 4;
                    Win.Add(new Type() { Power = Power, Current = -1 });
                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                }
                if (reserve[index] / 4 == 0 || reserve[index + 1] / 4 == 0)
                {
                    current = -1;
                    Power = 13;
                    Win.Add(new Type() { Power = Power, Current = -1 });
                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
                }
            }
        }

        void Winner(double current, double power, string currentText, int chips, string lastly)
        {
            if (lastly == " ")
            {
                lastly = "Bot 5";
            }
            for (int j = 0; j <= 16; j++)
            {
                //await Task.Delay(5);
                if (cardHolder[j].Visible)
                    cardHolder[j].Image = deck[j];
            }
            if (current == sorted.Current)
            {
                if (power == sorted.Power)
                {
                    winners++;
                    CheckWinners.Add(currentText);
                    if (current == -1)
                    {
                        MessageBox.Show(currentText + " High Card ");
                    }
                    if (current == 1 || current == 0)
                    {
                        MessageBox.Show(currentText + " Pair ");
                    }
                    if (current == 2)
                    {
                        MessageBox.Show(currentText + " Two Pair ");
                    }
                    if (current == 3)
                    {
                        MessageBox.Show(currentText + " Three of a Kind ");
                    }
                    if (current == 4)
                    {
                        MessageBox.Show(currentText + " straight ");
                    }
                    if (current == 5 || current == 5.5)
                    {
                        MessageBox.Show(currentText + " Flush ");
                    }
                    if (current == 6)
                    {
                        MessageBox.Show(currentText + " Full House ");
                    }
                    if (current == 7)
                    {
                        MessageBox.Show(currentText + " Four of a Kind ");
                    }
                    if (current == 8)
                    {
                        MessageBox.Show(currentText + " straight Flush ");
                    }
                    if (current == 9)
                    {
                        MessageBox.Show(currentText + " Royal Flush ! ");
                    }
                }
            }
            if (currentText == lastly)//lastfixed
            {
                if (winners > 1)
                {
                    if (CheckWinners.Contains("Player"))
                    {
                        Chips += int.Parse(tbPot.Text) / winners;
                        tbPlayerChips.Text = Chips.ToString();
                        //playerPanel.Visible = true;

                    }
                    if (CheckWinners.Contains("Bot 1"))
                    {
                        botOneChips += int.Parse(tbPot.Text) / winners;
                        tbBotOneChips.Text = botOneChips.ToString();
                        //botOnePanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 2"))
                    {
                        botTwoChips += int.Parse(tbPot.Text) / winners;
                        tbBotTwoChips.Text = botTwoChips.ToString();
                        //botTwoPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 3"))
                    {
                        botThreeChips += int.Parse(tbPot.Text) / winners;
                        tbBotThreeChips.Text = botThreeChips.ToString();
                        //botThreePanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 4"))
                    {
                        botFourChips += int.Parse(tbPot.Text) / winners;
                        tbBotFourChips.Text = botFourChips.ToString();
                        //botFourPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 5"))
                    {
                        botFiveChips += int.Parse(tbPot.Text) / winners;
                        tbBotFiveChips.Text = botFiveChips.ToString();
                        //botFivePanel.Visible = true;
                    }
                    //await Finish(1);
                }
                if (winners == 1)
                {
                    if (CheckWinners.Contains("Player"))
                    {
                        Chips += int.Parse(tbPot.Text);
                        //await Finish(1);
                        //playerPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 1"))
                    {
                        botOneChips += int.Parse(tbPot.Text);
                        //await Finish(1);
                        //botOnePanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 2"))
                    {
                        botTwoChips += int.Parse(tbPot.Text);
                        //await Finish(1);
                        //botTwoPanel.Visible = true;

                    }
                    if (CheckWinners.Contains("Bot 3"))
                    {
                        botThreeChips += int.Parse(tbPot.Text);
                        //await Finish(1);
                        //botThreePanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 4"))
                    {
                        botFourChips += int.Parse(tbPot.Text);
                        //await Finish(1);
                        //botFourPanel.Visible = true;
                    }
                    if (CheckWinners.Contains("Bot 5"))
                    {
                        botFiveChips += int.Parse(tbPot.Text);
                        //await Finish(1);
                        //botFivePanel.Visible = true;
                    }
                }
            }
        }
        async Task CheckRaise(int currentTurn, int raiseTurn)
        {
            if (raising)
            {
                turnCount = 0;
                raising = false;
                raisedTurn = currentTurn;
                changed = true;
            }
            else
            {
                if (turnCount >= maxLeft - 1 || !changed && turnCount == maxLeft)
                {
                    if (currentTurn == raisedTurn - 1 || !changed && turnCount == maxLeft || raisedTurn == 0 && currentTurn == 5)
                    {
                        changed = false;
                        turnCount = 0;
                        Raise = 0;
                        call = 0;
                        raisedTurn = 123;
                        rounds++;
                        if (!playerFinishedTurn)
                            pStatus.Text = "";
                        if (!botOneFinishedTurn)
                            b1Status.Text = "";
                        if (!botTwoFinishedTurn)
                            b2Status.Text = "";
                        if (!botThreeFinishedTurn)
                            b3Status.Text = "";
                        if (!botFourFinishedTurn)
                            b4Status.Text = "";
                        if (!botFiveFinishedTurn)
                            b5Status.Text = "";
                    }
                }
            }
            if (rounds == Flop)
            {
                for (int j = 12; j <= 14; j++)
                {
                    if (cardHolder[j].Image != deck[j])
                    {
                        cardHolder[j].Image = deck[j];
                        playerCall = 0; playerRaise = 0;
                        botOneCall = 0; botOneRaise = 0;
                        botTwoCall = 0; botTwoRaise = 0;
                        botThreeCall = 0; botThreeRaise = 0;
                        botFourCall = 0; botFourRaise = 0;
                        botFiveCall = 0; botFiveRaise = 0;
                    }
                }
            }
            if (rounds == Turn)
            {
                for (int j = 14; j <= 15; j++)
                {
                    if (cardHolder[j].Image != deck[j])
                    {
                        cardHolder[j].Image = deck[j];
                        playerCall = 0; playerRaise = 0;
                        botOneCall = 0; botOneRaise = 0;
                        botTwoCall = 0; botTwoRaise = 0;
                        botThreeCall = 0; botThreeRaise = 0;
                        botFourCall = 0; botFourRaise = 0;
                        botFiveCall = 0; botFiveRaise = 0;
                    }
                }
            }
            if (rounds == River)
            {
                for (int j = 15; j <= 16; j++)
                {
                    if (cardHolder[j].Image != deck[j])
                    {
                        cardHolder[j].Image = deck[j];
                        playerCall = 0; playerRaise = 0;
                        botOneCall = 0; botOneRaise = 0;
                        botTwoCall = 0; botTwoRaise = 0;
                        botThreeCall = 0; botThreeRaise = 0;
                        botFourCall = 0; botFourRaise = 0;
                        botFiveCall = 0; botFiveRaise = 0;
                    }
                }
            }
            if (rounds == End && maxLeft == 6)
            {
                string fixedLast = "qwerty";
                if (!pStatus.Text.Contains("Fold"))
                {
                    fixedLast = "Player";
                    Rules(0, 1, "Player", ref playerType, ref playerPower, playerFinishedTurn);
                }
                if (!b1Status.Text.Contains("Fold"))
                {
                    fixedLast = "Bot 1";
                    Rules(2, 3, "Bot 1", ref botOneType, ref botOnePower, botOneFinishedTurn);
                }
                if (!b2Status.Text.Contains("Fold"))
                {
                    fixedLast = "Bot 2";
                    Rules(4, 5, "Bot 2", ref botTwoType, ref botTwoPower, botTwoFinishedTurn);
                }
                if (!b3Status.Text.Contains("Fold"))
                {
                    fixedLast = "Bot 3";
                    Rules(6, 7, "Bot 3", ref botThreeType, ref botThreePower, botThreeFinishedTurn);
                }
                if (!b4Status.Text.Contains("Fold"))
                {
                    fixedLast = "Bot 4";
                    Rules(8, 9, "Bot 4", ref botFourType, ref botFourPower, botFourFinishedTurn);
                }
                if (!b5Status.Text.Contains("Fold"))
                {
                    fixedLast = "Bot 5";
                    Rules(10, 11, "Bot 5", ref botFiveType, ref botFivePower, botFiveFinishedTurn);
                }
                Winner(playerType, playerPower, "Player", Chips, fixedLast);
                Winner(botOneType, botOnePower, "Bot 1", botOneChips, fixedLast);
                Winner(botTwoType, botTwoPower, "Bot 2", botTwoChips, fixedLast);
                Winner(botThreeType, botThreePower, "Bot 3", botThreeChips, fixedLast);
                Winner(botFourType, botFourPower, "Bot 4", botFourChips, fixedLast);
                Winner(botFiveType, botFivePower, "Bot 5", botFiveChips, fixedLast);
                restart = true;
                playerTurn = true;
                playerFinishedTurn = false;
                botOneFinishedTurn = false;
                botTwoFinishedTurn = false;
                botThreeFinishedTurn = false;
                botFourFinishedTurn = false;
                botFiveFinishedTurn = false;
                if (Chips <= 0)
                {
                    AddChips f2 = new AddChips();
                    f2.ShowDialog();
                    if (f2.chips != 0)
                    {
                        Chips = f2.chips;
                        botOneChips += f2.chips;
                        botTwoChips += f2.chips;
                        botThreeChips += f2.chips;
                        botFourChips += f2.chips;
                        botFiveChips += f2.chips;
                        playerFinishedTurn = false;
                        playerTurn = true;
                        bRaise.Enabled = true;
                        bFold.Enabled = true;
                        bCheck.Enabled = true;
                        bRaise.Text = "Raise";
                    }
                }
                DisablePanels();
                playerCall = 0; playerRaise = 0;
                botOneCall = 0; botOneRaise = 0;
                botTwoCall = 0; botTwoRaise = 0;
                botThreeCall = 0; botThreeRaise = 0;
                botFourCall = 0; botFourRaise = 0;
                botFiveCall = 0; botFiveRaise = 0;
                lastPlayerPlayed = 0;
                call = bigBlind;
                Raise = 0;
                ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
                bools.Clear();
                rounds = 0;
                playerPower = 0; playerType = -1;
                type = 0; botOnePower = 0; botTwoPower = 0; botThreePower = 0; botFourPower = 0; botFivePower = 0;
                botOneType = -1; botTwoType = -1; botThreeType = -1; botFourType = -1; botFiveType = -1;
                ints.Clear();
                CheckWinners.Clear();
                winners = 0;
                Win.Clear();
                sorted.Current = 0;
                sorted.Power = 0;
                for (int os = 0; os < 17; os++)
                {
                    cardHolder[os].Image = null;
                    cardHolder[os].Invalidate();
                    cardHolder[os].Visible = false;
                }
                tbPot.Text = "0";
                pStatus.Text = "";
                await Shuffle();
                await Turns();
            }
        }

        void FixCall(Label status, ref int cCall, ref int cRaise, int options)
        {
            if (rounds != 4)
            {
                if (options == 1)
                {
                    if (status.Text.Contains("Raise"))
                    {
                        var changeRaise = status.Text.Substring(6);
                        cRaise = int.Parse(changeRaise);
                    }
                    if (status.Text.Contains("Call"))
                    {
                        var changeCall = status.Text.Substring(5);
                        cCall = int.Parse(changeCall);
                    }
                    if (status.Text.Contains("Check"))
                    {
                        cRaise = 0;
                        cCall = 0;
                    }
                }
                if (options == 2)
                {
                    if (cRaise != Raise && cRaise <= Raise)
                    {
                        call = Convert.ToInt32(Raise) - cRaise;
                    }
                    if (cCall != call || cCall <= call)
                    {
                        call = call - cCall;
                    }
                    if (cRaise == Raise && Raise > 0)
                    {
                        call = 0;
                        bCall.Enabled = false;
                        bCall.Text = "Callisfuckedup";
                    }
                }
            }
        }
        async Task AllIn()
        {
            #region All in
            if (Chips <= 0 && !intsadded)
            {
                if (pStatus.Text.Contains("Raise"))
                {
                    ints.Add(Chips);
                    intsadded = true;
                }
                if (pStatus.Text.Contains("Call"))
                {
                    ints.Add(Chips);
                    intsadded = true;
                }
            }
            intsadded = false;
            if (botOneChips <= 0 && !botOneFinishedTurn)
            {
                if (!intsadded)
                {
                    ints.Add(botOneChips);
                    intsadded = true;
                }
                intsadded = false;
            }
            if (botTwoChips <= 0 && !botTwoFinishedTurn)
            {
                if (!intsadded)
                {
                    ints.Add(botTwoChips);
                    intsadded = true;
                }
                intsadded = false;
            }
            if (botThreeChips <= 0 && !botThreeFinishedTurn)
            {
                if (!intsadded)
                {
                    ints.Add(botThreeChips);
                    intsadded = true;
                }
                intsadded = false;
            }
            if (botFourChips <= 0 && !botFourFinishedTurn)
            {
                if (!intsadded)
                {
                    ints.Add(botFourChips);
                    intsadded = true;
                }
                intsadded = false;
            }
            if (botFiveChips <= 0 && !botFiveFinishedTurn)
            {
                if (!intsadded)
                {
                    ints.Add(botFiveChips);
                    intsadded = true;
                }
            }
            if (ints.ToArray().Length == maxLeft)
            {
                await Finish(2);
            }
            else
            {
                ints.Clear();
            }
            #endregion

            var abc = bools.Count(x => x == false);

            #region LastManStanding
            if (abc == 1)
            {
                int index = bools.IndexOf(false);
                if (index == 0)
                {
                    Chips += int.Parse(tbPot.Text);
                    tbPlayerChips.Text = Chips.ToString();
                    playerPanel.Visible = true;
                    MessageBox.Show("Player Wins");
                }
                if (index == 1)
                {
                    botOneChips += int.Parse(tbPot.Text);
                    tbPlayerChips.Text = botOneChips.ToString();
                    botOnePanel.Visible = true;
                    MessageBox.Show("Bot 1 Wins");
                }
                if (index == 2)
                {
                    botTwoChips += int.Parse(tbPot.Text);
                    tbPlayerChips.Text = botTwoChips.ToString();
                    botTwoPanel.Visible = true;
                    MessageBox.Show("Bot 2 Wins");
                }
                if (index == 3)
                {
                    botThreeChips += int.Parse(tbPot.Text);
                    tbPlayerChips.Text = botThreeChips.ToString();
                    botThreePanel.Visible = true;
                    MessageBox.Show("Bot 3 Wins");
                }
                if (index == 4)
                {
                    botFourChips += int.Parse(tbPot.Text);
                    tbPlayerChips.Text = botFourChips.ToString();
                    botFourPanel.Visible = true;
                    MessageBox.Show("Bot 4 Wins");
                }
                if (index == 5)
                {
                    botFiveChips += int.Parse(tbPot.Text);
                    tbPlayerChips.Text = botFiveChips.ToString();
                    botFivePanel.Visible = true;
                    MessageBox.Show("Bot 5 Wins");
                }
                for (int j = 0; j <= 16; j++)
                {
                    cardHolder[j].Visible = false;
                }
                await Finish(1);
            }
            intsadded = false;
            #endregion

            #region FiveOrLessLeft
            if (abc < 6 && abc > 1 && rounds >= End)
            {
                await Finish(2);
            }
            #endregion


        }
        async Task Finish(int n)
        {
            if (n == 2)
            {
                FixWinners();
            }
            playerPanel.Visible = false; botOnePanel.Visible = false; botTwoPanel.Visible = false; botThreePanel.Visible = false; botFourPanel.Visible = false; botFivePanel.Visible = false;
            call = bigBlind; Raise = 0;
            foldedPlayers = 5;
            type = 0;
            rounds = 0;
            botOnePower = 0;
            botTwoPower = 0;
            botThreePower = 0;
            botFourPower = 0;
            botFivePower = 0;
            playerPower = 0;
            playerType = -1;
            Raise = 0;
            botOneType = -1;
            botTwoType = -1;
            botThreeType = -1;
            botFourType = -1;
            botFiveType = -1;

            botOneTurn = false;
            botTwoTurn = false;
            botThreeTurn = false;
            botFourTurn = false;
            botFiveTurn = false;

            botOneFinishedTurn = false;
            botTwoFinishedTurn = false;
            botThreeFinishedTurn = false;
            botFourFinishedTurn = false;
            botFiveFinishedTurn = false;

            playerFolded = false;
            botOneFolded = false;
            botTwoFolded = false;
            botThreeFolded = false;
            botFourFolded = false;
            botFiveFolded = false;

            playerFinishedTurn = false;
            playerTurn = true;
            restart = false;
            raising = false;

            playerCall = 0;
            botOneCall = 0;
            botTwoCall = 0;
            botThreeCall = 0;
            botFourCall = 0;
            botFiveCall = 0;

            playerRaise = 0;
            botOneRaise = 0;
            botTwoRaise = 0;
            botThreeRaise = 0;
            botFourRaise = 0;
            botFiveRaise = 0;

            height = 0;
            width = 0;
            winners = 0;
            Flop = 1;
            Turn = 2;
            River = 3;
            End = 4;
            maxLeft = 6;

            lastPlayerPlayed = -1;
            raisedTurn = 1;

            bools.Clear();
            CheckWinners.Clear();
            ints.Clear();
            Win.Clear();
            sorted.Current = 0;
            sorted.Power = 0;
            tbPot.Text = "0";
            turnTimer = 60;
            up = 10000000;
            turnCount = 0;
            pStatus.Text = "";
            b1Status.Text = "";
            b2Status.Text = "";
            b3Status.Text = "";
            b4Status.Text = "";
            b5Status.Text = "";
            if (Chips <= 0)
            {
                AddChips AddChipsWindow = new AddChips();
                AddChipsWindow.ShowDialog();
                if (AddChipsWindow.chips != 0)
                {
                    Chips = AddChipsWindow.chips;
                    botOneChips += AddChipsWindow.chips;
                    botTwoChips += AddChipsWindow.chips;
                    botThreeChips += AddChipsWindow.chips;
                    botFourChips += AddChipsWindow.chips;
                    botFiveChips += AddChipsWindow.chips;

                    playerFinishedTurn = false;
                    playerTurn = true;
                    bRaise.Enabled = true;
                    bFold.Enabled = true;
                    bCheck.Enabled = true;

                    bRaise.Text = "Raise";
                }
            }
            ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
            for (int os = 0; os < 17; os++)
            {
                cardHolder[os].Image = null;
                cardHolder[os].Invalidate();
                cardHolder[os].Visible = false;
            }
            await Shuffle();
            //await Turns();
        }
        void FixWinners()
        {
            Win.Clear();
            sorted.Current = 0;
            sorted.Power = 0;
            string fixedLast = "qwerty";
            if (!pStatus.Text.Contains("Fold"))
            {
                fixedLast = "Player";
                Rules(0, 1, "Player", ref playerType, ref playerPower, playerFinishedTurn);
            }
            if (!b1Status.Text.Contains("Fold"))
            {
                fixedLast = "Bot 1";
                Rules(2, 3, "Bot 1", ref botOneType, ref botOnePower, botOneFinishedTurn);
            }
            if (!b2Status.Text.Contains("Fold"))
            {
                fixedLast = "Bot 2";
                Rules(4, 5, "Bot 2", ref botTwoType, ref botTwoPower, botTwoFinishedTurn);
            }
            if (!b3Status.Text.Contains("Fold"))
            {
                fixedLast = "Bot 3";
                Rules(6, 7, "Bot 3", ref botThreeType, ref botThreePower, botThreeFinishedTurn);
            }
            if (!b4Status.Text.Contains("Fold"))
            {
                fixedLast = "Bot 4";
                Rules(8, 9, "Bot 4", ref botFourType, ref botFourPower, botFourFinishedTurn);
            }
            if (!b5Status.Text.Contains("Fold"))
            {
                fixedLast = "Bot 5";
                Rules(10, 11, "Bot 5", ref botFiveType, ref botFivePower, botFiveFinishedTurn);
            }
            Winner(playerType, playerPower, "Player", Chips, fixedLast);
            Winner(botOneType, botOnePower, "Bot 1", botOneChips, fixedLast);
            Winner(botTwoType, botTwoPower, "Bot 2", botTwoChips, fixedLast);
            Winner(botThreeType, botThreePower, "Bot 3", botThreeChips, fixedLast);
            Winner(botFourType, botFourPower, "Bot 4", botFourChips, fixedLast);
            Winner(botFiveType, botFivePower, "Bot 5", botFiveChips, fixedLast);
        }
        void AI(int c1, int c2, ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower, double botCurrentHand)
        {
            if (!sFTurn)
            {
                if (botCurrentHand == -1)
                {
                    HighCard(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
                }
                if (botCurrentHand == 0)
                {
                    PairTable(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
                }
                if (botCurrentHand == 1)
                {
                    PairHand(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
                }
                if (botCurrentHand == 2)
                {
                    TwoPair(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
                }
                if (botCurrentHand == 3)
                {
                    ThreeOfAKind(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
                if (botCurrentHand == 4)
                {
                    Straight(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
                if (botCurrentHand == 5 || botCurrentHand == 5.5)
                {
                    Flush(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
                if (botCurrentHand == 6)
                {
                    FullHouse(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
                if (botCurrentHand == 7)
                {
                    FourOfAKind(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
                if (botCurrentHand == 8 || botCurrentHand == 9)
                {
                    StraightFlush(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
                }
            }
            if (sFTurn)
            {
                cardHolder[c1].Visible = false;
                cardHolder[c2].Visible = false;
            }
        }
        private void HighCard(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
        {
            HP(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower, 20, 25);
        }
        private void PairTable(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
        {
            HP(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower, 16, 25);
        }
        private void PairHand(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
        {
            Random rPair = new Random();
            int rCall = rPair.Next(10, 16);
            int rRaise = rPair.Next(10, 13);
            if (botPower <= 199 && botPower >= 140)
            {
                PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 6, rRaise);
            }
            if (botPower <= 139 && botPower >= 128)
            {
                PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 7, rRaise);
            }
            if (botPower < 128 && botPower >= 101)
            {
                PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 9, rRaise);
            }
        }
        private void TwoPair(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
        {
            Random rPair = new Random();
            int rCall = rPair.Next(6, 11);
            int rRaise = rPair.Next(6, 11);
            if (botPower <= 290 && botPower >= 246)
            {
                PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 3, rRaise);
            }
            if (botPower <= 244 && botPower >= 234)
            {
                PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 4, rRaise);
            }
            if (botPower < 234 && botPower >= 201)
            {
                PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 4, rRaise);
            }
        }
        private void ThreeOfAKind(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
        {
            Random tk = new Random();
            int tCall = tk.Next(3, 7);
            int tRaise = tk.Next(4, 8);
            if (botPower <= 390 && botPower >= 330)
            {
                Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, tCall, tRaise);
            }
            if (botPower <= 327 && botPower >= 321)//10  8
            {
                Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, tCall, tRaise);
            }
            if (botPower < 321 && botPower >= 303)//7 2
            {
                Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, tCall, tRaise);
            }
        }
        private void Straight(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
        {
            Random str = new Random();
            int sCall = str.Next(3, 6);
            int sRaise = str.Next(3, 8);
            if (botPower <= 480 && botPower >= 410)
            {
                Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, sCall, sRaise);
            }
            if (botPower <= 409 && botPower >= 407)//10  8
            {
                Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, sCall, sRaise);
            }
            if (botPower < 407 && botPower >= 404)
            {
                Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, sCall, sRaise);
            }
        }
        private void Flush(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
        {
            Random fsh = new Random();
            int fCall = fsh.Next(2, 6);
            int fRaise = fsh.Next(3, 7);
            Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, fCall, fRaise);
        }
        private void FullHouse(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
        {
            Random flh = new Random();
            int fhCall = flh.Next(1, 5);
            int fhRaise = flh.Next(2, 6);
            if (botPower <= 626 && botPower >= 620)
            {
                Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, fhCall, fhRaise);
            }
            if (botPower < 620 && botPower >= 602)
            {
                Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, fhCall, fhRaise);
            }
        }
        private void FourOfAKind(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
        {
            Random fk = new Random();
            int fkCall = fk.Next(1, 4);
            int fkRaise = fk.Next(2, 5);
            if (botPower <= 752 && botPower >= 704)
            {
                Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, fkCall, fkRaise);
            }
        }
        private void StraightFlush(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
        {
            Random sf = new Random();
            int sfCall = sf.Next(1, 3);
            int sfRaise = sf.Next(1, 3);
            if (botPower <= 913 && botPower >= 804)
            {
                Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, sfCall, sfRaise);
            }
        }

        private void Fold(ref bool sTurn, ref bool sFTurn, Label sStatus)
        {
            raising = false;
            sStatus.Text = "Fold";
            sTurn = false;
            sFTurn = true;
        }
        private void Check(ref bool cTurn, Label cStatus)
        {
            cStatus.Text = "Check";
            cTurn = false;
            raising = false;
        }
        private void Call(ref int sChips, ref bool sTurn, Label sStatus)
        {
            raising = false;
            sTurn = false;
            sChips -= call;
            sStatus.Text = "Call " + call;
            tbPot.Text = (int.Parse(tbPot.Text) + call).ToString();
        }
        private void Raised(ref int sChips, ref bool sTurn, Label sStatus)
        {
            sChips -= Convert.ToInt32(Raise);
            sStatus.Text = "Raise " + Raise;
            tbPot.Text = (int.Parse(tbPot.Text) + Convert.ToInt32(Raise)).ToString();
            call = Convert.ToInt32(Raise);
            raising = true;
            sTurn = false;
        }
        private static double RoundN(int sChips, int n)
        {
            double a = Math.Round((sChips / n) / 100d, 0) * 100;
            return a;
        }
        private void HP(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower, int n, int n1)
        {
            Random rand = new Random();
            int rnd = rand.Next(1, 4);
            if (call <= 0)
            {
                Check(ref sTurn, sStatus);
            }
            if (call > 0)
            {
                if (rnd == 1)
                {
                    if (call <= RoundN(sChips, n))
                    {
                        Call(ref sChips, ref sTurn, sStatus);
                    }
                    else
                    {
                        Fold(ref sTurn, ref sFTurn, sStatus);
                    }
                }
                if (rnd == 2)
                {
                    if (call <= RoundN(sChips, n1))
                    {
                        Call(ref sChips, ref sTurn, sStatus);
                    }
                    else
                    {
                        Fold(ref sTurn, ref sFTurn, sStatus);
                    }
                }
            }
            if (rnd == 3)
            {
                if (Raise == 0)
                {
                    Raise = call * 2;
                    Raised(ref sChips, ref sTurn, sStatus);
                }
                else
                {
                    if (Raise <= RoundN(sChips, n))
                    {
                        Raise = call * 2;
                        Raised(ref sChips, ref sTurn, sStatus);
                    }
                    else
                    {
                        Fold(ref sTurn, ref sFTurn, sStatus);
                    }
                }
            }
            if (sChips <= 0)
            {
                sFTurn = true;
            }
        }
        private void PH(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int n, int n1, int r)
        {
            Random rand = new Random();
            int rnd = rand.Next(1, 3);
            if (rounds < 2)
            {
                if (call <= 0)
                {
                    Check(ref sTurn, sStatus);
                }
                if (call > 0)
                {
                    if (call >= RoundN(sChips, n1))
                    {
                        Fold(ref sTurn, ref sFTurn, sStatus);
                    }
                    if (Raise > RoundN(sChips, n))
                    {
                        Fold(ref sTurn, ref sFTurn, sStatus);
                    }
                    if (!sFTurn)
                    {
                        if (call >= RoundN(sChips, n) && call <= RoundN(sChips, n1))
                        {
                            Call(ref sChips, ref sTurn, sStatus);
                        }
                        if (Raise <= RoundN(sChips, n) && Raise >= (RoundN(sChips, n)) / 2)
                        {
                            Call(ref sChips, ref sTurn, sStatus);
                        }
                        if (Raise <= (RoundN(sChips, n)) / 2)
                        {
                            if (Raise > 0)
                            {
                                Raise = RoundN(sChips, n);
                                Raised(ref sChips, ref sTurn, sStatus);
                            }
                            else
                            {
                                Raise = call * 2;
                                Raised(ref sChips, ref sTurn, sStatus);
                            }
                        }

                    }
                }
            }
            if (rounds >= 2)
            {
                if (call > 0)
                {
                    if (call >= RoundN(sChips, n1 - rnd))
                    {
                        Fold(ref sTurn, ref sFTurn, sStatus);
                    }
                    if (Raise > RoundN(sChips, n - rnd))
                    {
                        Fold(ref sTurn, ref sFTurn, sStatus);
                    }
                    if (!sFTurn)
                    {
                        if (call >= RoundN(sChips, n - rnd) && call <= RoundN(sChips, n1 - rnd))
                        {
                            Call(ref sChips, ref sTurn, sStatus);
                        }
                        if (Raise <= RoundN(sChips, n - rnd) && Raise >= (RoundN(sChips, n - rnd)) / 2)
                        {
                            Call(ref sChips, ref sTurn, sStatus);
                        }
                        if (Raise <= (RoundN(sChips, n - rnd)) / 2)
                        {
                            if (Raise > 0)
                            {
                                Raise = RoundN(sChips, n - rnd);
                                Raised(ref sChips, ref sTurn, sStatus);
                            }
                            else
                            {
                                Raise = call * 2;
                                Raised(ref sChips, ref sTurn, sStatus);
                            }
                        }
                    }
                }
                if (call <= 0)
                {
                    Raise = RoundN(sChips, r - rnd);
                    Raised(ref sChips, ref sTurn, sStatus);
                }
            }
            if (sChips <= 0)
            {
                sFTurn = true;
            }
        }
        void Smooth(ref int botChips, ref bool botTurn, ref bool botFTurn, Label botStatus, int name, int n, int r)
        {
            Random rand = new Random();
            int rnd = rand.Next(1, 3);
            if (call <= 0)
            {
                Check(ref botTurn, botStatus);
            }
            else
            {
                if (call >= RoundN(botChips, n))
                {
                    if (botChips > call)
                    {
                        Call(ref botChips, ref botTurn, botStatus);
                    }
                    else if (botChips <= call)
                    {
                        raising = false;
                        botTurn = false;
                        botChips = 0;
                        botStatus.Text = "Call " + botChips;
                        tbPot.Text = (int.Parse(tbPot.Text) + botChips).ToString();
                    }
                }
                else
                {
                    if (Raise > 0)
                    {
                        if (botChips >= Raise * 2)
                        {
                            Raise *= 2;
                            Raised(ref botChips, ref botTurn, botStatus);
                        }
                        else
                        {
                            Call(ref botChips, ref botTurn, botStatus);
                        }
                    }
                    else
                    {
                        Raise = call * 2;
                        Raised(ref botChips, ref botTurn, botStatus);
                    }
                }
            }
            if (botChips <= 0)
            {
                botFTurn = true;
            }
        }

        #region UI
        private async void timer_Tick(object sender, object e)
        {
            if (pbTimer.Value <= 0)
            {
                playerFinishedTurn = true;
                await Turns();
            }
            if (turnTimer > 0)
            {
                turnTimer--;
                pbTimer.Value = (turnTimer / 6) * 100;
            }
        }
        private void Update_Tick(object sender, object e)
        {
            if (Chips <= 0)
            {
                tbPlayerChips.Text = "Chips : 0";
            }
            if (botOneChips <= 0)
            {
                tbBotOneChips.Text = "Chips : 0";
            }
            if (botTwoChips <= 0)
            {
                tbBotTwoChips.Text = "Chips : 0";
            }
            if (botThreeChips <= 0)
            {
                tbBotThreeChips.Text = "Chips : 0";
            }
            if (botFourChips <= 0)
            {
                tbBotFourChips.Text = "Chips : 0";
            }
            if (botFiveChips <= 0)
            {
                tbBotFiveChips.Text = "Chips : 0";
            }
            tbPlayerChips.Text = "Chips : " + Chips.ToString();
            tbBotOneChips.Text = "Chips : " + botOneChips.ToString();
            tbBotTwoChips.Text = "Chips : " + botTwoChips.ToString();
            tbBotThreeChips.Text = "Chips : " + botThreeChips.ToString();
            tbBotFourChips.Text = "Chips : " + botFourChips.ToString();
            tbBotFiveChips.Text = "Chips : " + botFiveChips.ToString();
            if (Chips <= 0)
            {
                playerTurn = false;
                playerFinishedTurn = true;
                bCall.Enabled = false;
                bRaise.Enabled = false;
                bFold.Enabled = false;
                bCheck.Enabled = false;
            }
            if (up > 0)
            {
                up--;
            }
            if (Chips >= call)
            {
                bCall.Text = "Call " + call.ToString();
            }
            else
            {
                bCall.Text = "All in";
                bRaise.Enabled = false;
            }
            if (call > 0)
            {
                bCheck.Enabled = false;
            }
            if (call <= 0)
            {
                bCheck.Enabled = true;
                bCall.Text = "Call";
                bCall.Enabled = false;
            }
            if (Chips <= 0)
            {
                bRaise.Enabled = false;
            }
            int parsedValue;

            if (tbRaise.Text != "" && int.TryParse(tbRaise.Text, out parsedValue))
            {
                if (Chips <= int.Parse(tbRaise.Text))
                {
                    bRaise.Text = "All in";
                }
                else
                {
                    bRaise.Text = "Raise";
                }
            }
            if (Chips < call)
            {
                bRaise.Enabled = false;
            }
        }
        private async void bFold_Click(object sender, EventArgs e)
        {
            pStatus.Text = "Fold";
            playerTurn = false;
            playerFinishedTurn = true;
            await Turns();
        }
        private async void bCheck_Click(object sender, EventArgs e)
        {
            if (call <= 0)
            {
                playerTurn = false;
                pStatus.Text = "Check";
            }
            else
            {
                //pStatus.Text = "All in " + Chips;

                bCheck.Enabled = false;
            }
            await Turns();
        }
        private async void bCall_Click(object sender, EventArgs e)
        {
            Rules(0, 1, "Player", ref playerType, ref playerPower, playerFinishedTurn);
            if (Chips >= call)
            {
                Chips -= call;
                tbPlayerChips.Text = "Chips : " + Chips.ToString();
                if (tbPot.Text != "")
                {
                    tbPot.Text = (int.Parse(tbPot.Text) + call).ToString();
                }
                else
                {
                    tbPot.Text = call.ToString();
                }
                playerTurn = false;
                pStatus.Text = "Call " + call;
                playerCall = call;
            }
            else if (Chips <= call && call > 0)
            {
                tbPot.Text = (int.Parse(tbPot.Text) + Chips).ToString();
                pStatus.Text = "All in " + Chips;
                Chips = 0;
                tbPlayerChips.Text = "Chips : " + Chips.ToString();
                playerTurn = false;
                bFold.Enabled = false;
                playerCall = Chips;
            }
            await Turns();
        }
        private async void bRaise_Click(object sender, EventArgs e)
        {
            Rules(0, 1, "Player", ref playerType, ref playerPower, playerFinishedTurn);
            int parsedValue;
            if (tbRaise.Text != "" && int.TryParse(tbRaise.Text, out parsedValue))
            {
                if (Chips > call)
                {
                    if (Raise * 2 > int.Parse(tbRaise.Text))
                    {
                        tbRaise.Text = (Raise * 2).ToString();
                        MessageBox.Show("You must raise atleast twice as the currentHand raise !");
                        return;
                    }
                    else
                    {
                        if (Chips >= int.Parse(tbRaise.Text))
                        {
                            call = int.Parse(tbRaise.Text);
                            Raise = int.Parse(tbRaise.Text);
                            pStatus.Text = "Raise " + call.ToString();
                            tbPot.Text = (int.Parse(tbPot.Text) + call).ToString();
                            bCall.Text = "Call";
                            Chips -= int.Parse(tbRaise.Text);
                            raising = true;
                            lastPlayerPlayed = 0;
                            playerRaise = Convert.ToInt32(Raise);
                        }
                        else
                        {
                            call = Chips;
                            Raise = Chips;
                            tbPot.Text = (int.Parse(tbPot.Text) + Chips).ToString();
                            pStatus.Text = "Raise " + call.ToString();
                            Chips = 0;
                            raising = true;
                            lastPlayerPlayed = 0;
                            playerRaise = Convert.ToInt32(Raise);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("This is a number only field");
                return;
            }
            playerTurn = false;
            await Turns();
        }
        private void bAdd_Click(object sender, EventArgs e)
        {
            if (tbAdd.Text == "") { }
            else
            {
                Chips += int.Parse(tbAdd.Text);
                botOneChips += int.Parse(tbAdd.Text);
                botTwoChips += int.Parse(tbAdd.Text);
                botThreeChips += int.Parse(tbAdd.Text);
                botFourChips += int.Parse(tbAdd.Text);
                botFiveChips += int.Parse(tbAdd.Text);
            }
            tbPlayerChips.Text = "Chips : " + Chips.ToString();
        }
        private void bOptions_Click(object sender, EventArgs e)
        {
            tbBigBlind.Text = bigBlind.ToString();
            tbSmallBlind.Text = smallBlind.ToString();
            if (tbBigBlind.Visible == false)
            {
                tbBigBlind.Visible = true;
                tbSmallBlind.Visible = true;
                bBigBlind.Visible = true;
                bSmallBlind.Visible = true;
            }
            else
            {
                tbBigBlind.Visible = false;
                tbSmallBlind.Visible = false;
                bBigBlind.Visible = false;
                bSmallBlind.Visible = false;
            }
        }
        private void bSB_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (tbSmallBlind.Text.Contains(",") || tbSmallBlind.Text.Contains("."))
            {
                MessageBox.Show("The Small Blind can be only round number !");
                tbSmallBlind.Text = smallBlind.ToString();
                return;
            }
            if (!int.TryParse(tbSmallBlind.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                tbSmallBlind.Text = smallBlind.ToString();
                return;
            }
            if (int.Parse(tbSmallBlind.Text) > 100000)
            {
                MessageBox.Show("The maximum of the Small Blind is 100 000 $");
                tbSmallBlind.Text = smallBlind.ToString();
            }
            if (int.Parse(tbSmallBlind.Text) < 250)
            {
                MessageBox.Show("The minimum of the Small Blind is 250 $");
            }
            if (int.Parse(tbSmallBlind.Text) >= 250 && int.Parse(tbSmallBlind.Text) <= 100000)
            {
                smallBlind = int.Parse(tbSmallBlind.Text);
                MessageBox.Show("The changes have been saved ! They will become available the next hand you play. ");
            }
        }
        private void bBB_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (tbBigBlind.Text.Contains(",") || tbBigBlind.Text.Contains("."))
            {
                MessageBox.Show("The Big Blind can be only round number !");
                tbBigBlind.Text = bigBlind.ToString();
                return;
            }
            if (!int.TryParse(tbSmallBlind.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                tbSmallBlind.Text = bigBlind.ToString();
                return;
            }
            if (int.Parse(tbBigBlind.Text) > 200000)
            {
                MessageBox.Show("The maximum of the Big Blind is 200 000");
                tbBigBlind.Text = bigBlind.ToString();
            }
            if (int.Parse(tbBigBlind.Text) < 500)
            {
                MessageBox.Show("The minimum of the Big Blind is 500 $");
            }
            if (int.Parse(tbBigBlind.Text) >= 500 && int.Parse(tbBigBlind.Text) <= 200000)
            {
                bigBlind = int.Parse(tbBigBlind.Text);
                MessageBox.Show("The changes have been saved ! They will become available the next hand you play. ");
            }
        }
        private void Layout_Change(object sender, LayoutEventArgs e)
        {
            width = this.Width;
            height = this.Height;
        }
        private void EnableChips()
        {
            tbPot.Enabled = false;
            tbPlayerChips.Enabled = false;
            tbBotOneChips.Enabled = false;
            tbBotTwoChips.Enabled = false;
            tbBotThreeChips.Enabled = false;
            tbBotFourChips.Enabled = false;
            tbBotFiveChips.Enabled = false;
        }
        private void SetupBlinds()
        {
            tbBigBlind.Visible = true;
            tbSmallBlind.Visible = true;
            bBigBlind.Visible = true;
            bSmallBlind.Visible = true;
            tbBigBlind.Visible = true;
            tbSmallBlind.Visible = true;
            bBigBlind.Visible = true;
            bSmallBlind.Visible = true;
            tbBigBlind.Visible = false;
            tbSmallBlind.Visible = false;
            bBigBlind.Visible = false;
            bSmallBlind.Visible = false;
        }

        private void DisablePanels()
        {
            playerPanel.Visible = false;
            botOnePanel.Visible = false;
            botTwoPanel.Visible = false;
            botThreePanel.Visible = false;
            botFourPanel.Visible = false;
            botFivePanel.Visible = false;
        }
        #endregion
    }
}