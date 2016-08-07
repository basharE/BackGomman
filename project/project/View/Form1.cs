using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Control;

namespace View
{
    public partial class Form1 : Form
    {
        private Game TheGame { get; }
        private List<int> DiceRe { get; set; }

        public Form1(Game theGame)
        {
            TheGame = theGame;
            InitializeComponent();
            TheGame.CreateGame();
            UpdateTextBoxs();
        }
       

        private void RollDiceBtn_Click(object sender, EventArgs e)
        {
            var dice = TheGame.DiceRoll();
            DiceRe = new List<int>();
            firstDiceBox.Text = dice[0].ToString();             
            secondDiceBox.Text = dice[1].ToString(); 
            if (dice[0] == dice[1])
            {
                DiceRe.Add(dice[0]);
                DiceRe.Add(dice[0]);
                DiceRe.Add(dice[1]);
                DiceRe.Add(dice[1]);
            }
            else
            {
                DiceRe.Add(dice[0]);
                DiceRe.Add(dice[1]);
            }            
            if (TheGame.CurrentPlayer == PlayerColor.Black && TheGame.GameBoard.TrianglesBar[1].Count!=0)
            {                
                if (StillCanMove())
                {
                    MessageBox.Show(@"Please move your Black checkers from Bar!!!" +
                                    @"Select your target location you want to move from Bar");
                    MoveFromtxtBox.Text = @"Black Bar";
                    RollDiceBtn.Hide();
                }
                else
                {
                    MessageBox.Show(@"There's No possible moves!!!");
                    ChangePlayer();
                }
                
            }
            else if(TheGame.CurrentPlayer == PlayerColor.White && TheGame.GameBoard.TrianglesBar[0].Count != 0)
            {
                if (StillCanMove())
                {
                    MessageBox.Show(@"Please move your White checkers from Bar!!!" +
                                @"Select your target location you want to move from Bar");
                    MoveFromtxtBox.Text = @"White Bar";
                    RollDiceBtn.Hide();
                }
                else
                {
                    MessageBox.Show(@"There's No possible moves!!!");
                    ChangePlayer();
                }
                
            }else if (TheGame.GameBoard.TrianglesBar[0].Count == 0 || TheGame.GameBoard.TrianglesBar[1].Count == 0)
            {
                if (TheGame.IsCheckersAtHome())
                {               
                    MoveTotxtBox.Text = TheGame.CurrentPlayer == PlayerColor.White? @"White Home!!!": @"Black Home!!!";
                    MessageBox.Show(@"Please press the Button you want to move FROM !!!");
                    RollDiceBtn.Hide();
                }
                else
                if (StillCanMove())
                {
                    MessageBox.Show(@"Please press the Button you want to move FROM !!!");
                    RollDiceBtn.Hide();
                }
                else
                {
                    MessageBox.Show(@"There's No possible moves!!!");
                    ChangePlayer();
                }
                
            }     
        }

        
        private void btn1_Click(object sender, EventArgs e)
        {
            Button(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Button(2);                                
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Button(3);                           
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Button(4);           
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Button(5);    
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Button(7);            
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Button(8);            
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Button(9);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            Button(10);
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            Button(11);
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            Button(12);
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            Button(13);
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            Button(14);
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            Button(15);
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            Button(16);
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            Button(17);                         
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            Button(18);                     
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            Button(19);                                       
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            Button(20);            
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            Button(21);                     
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            Button(22);                       
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            Button(23);                              
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            Button(24);      
        }

        private void Button(int buttonNum)
        {
            var button = buttonNum;

            if (firstDiceBox.Text.Length == 0 || secondDiceBox.Text.Length == 0)
            {
                MessageBox.Show(@"Please Roll the Dice First!!!");
            }
            else if (TheGame.CurrentPlayer == PlayerColor.Black && TheGame.GameBoard.TrianglesBar[1].Count != 0 && MoveFromtxtBox.Text.Length == 0)
            {
                MessageBox.Show(@"Please Move checkers from Bar!!!");
                MoveFromtxtBox.Text = @"Black Bar";
            }
            else if (TheGame.CurrentPlayer == PlayerColor.White && TheGame.GameBoard.TrianglesBar[0].Count != 0 && MoveFromtxtBox.Text.Length == 0)
            {
                MessageBox.Show(@"Please Move checkers from Bar!!!");
                MoveFromtxtBox.Text = @"White Bar";
            }
            else
            {
                if (TheGame.CurrentPlayer == PlayerColor.Black)
                {
                    if (MoveFromtxtBox.Text.Length == 0)
                    {
                        if (TheGame.TriangleByOrder(button).Player == PlayerColor.Black)
                        //TheGame.GameBoard.HomeP1.TrianglesZone[0].Player
                        {
                            MoveFromtxtBox.Text = @"Black " + button;
                            MessageBox.Show(@"Please press the Button you want to move TO !!!");
                        }
                        else
                        {
                            MessageBox.Show(@"You can't move from this location!!! there's no Black checkers!!! " +
                                            @"Please choose another location to move from...");
                        }

                    }
                    else
                    {
                        MoveTotxtBox.Text = @"Black " + button;
                    }
                }
                else
                {
                    if (MoveFromtxtBox.Text.Length == 0)
                    {
                        if (TheGame.TriangleByOrder(25 - button).Player == PlayerColor.White)
                        {
                            MoveFromtxtBox.Text = @"White " + (25 - button);
                            MessageBox.Show(@"Please press the Button you want to move TO !!!");
                        }
                        else
                        {
                            MessageBox.Show(@"You can't move from this location!!! there's no White checkers!!! " +
                                            @"Please choose another location to move from...");
                        }

                    }
                    else
                    {
                        MoveTotxtBox.Text = @"White " + (25 - button);
                    }
                }
            }
        }

        private void MoveBtn_Click(object sender, EventArgs e)
        {
            if (MoveFromtxtBox.Text.Length == 0 && MoveTotxtBox.Text.Length == 0)
            {
                MessageBox.Show(@"Can't procced , insert move information !!!");
            }
            else if (MoveFromtxtBox.Text.Length == 0 && MoveTotxtBox.Text.Length != 0)
            {
                if ((GetNumber(firstDiceBox.Text)+ GetNumber(secondDiceBox.Text)+ GetNumber(MoveFromtxtBox.Text))>24 ||
                    (GetNumber(firstDiceBox.Text)+GetNumber(MoveFromtxtBox.Text)) >24 || (GetNumber(secondDiceBox.Text) + GetNumber(MoveFromtxtBox.Text)) > 24)
                {
                    if (GetNumber(firstDiceBox.Text) > GetNumber(secondDiceBox.Text))
                    {
                        if (TheGame.MoveEligablity(GetNumber(MoveFromtxtBox.Text), GetNumber(firstDiceBox.Text)))
                        {
                            TheGame.ProccedMove(GetNumber(MoveFromtxtBox.Text), GetNumber(firstDiceBox.Text));
                            DiceRe.Remove(GetNumber(firstDiceBox.Text));
                            MessageBox.Show(@"Move procceded!!!");
                            MoveFromtxtBox.Clear();
                            MoveTotxtBox.Clear();
                            UpdateTextBoxs();
                        }
                        else
                        {
                            MessageBox.Show(@"Move not Alowed!!!");
                            MoveFromtxtBox.Clear();
                            MoveTotxtBox.Clear();
                        }
                    }
                    else
                    {
                        if (TheGame.MoveEligablity(GetNumber(MoveFromtxtBox.Text), GetNumber(secondDiceBox.Text)))
                        {
                            TheGame.ProccedMove(GetNumber(MoveFromtxtBox.Text), GetNumber(secondDiceBox.Text));
                            DiceRe.Remove(GetNumber(secondDiceBox.Text));
                            MessageBox.Show(@"Move procceded!!!");
                            MoveFromtxtBox.Clear();
                            MoveTotxtBox.Clear();
                            UpdateTextBoxs();
                        }
                        else
                        {
                            MessageBox.Show(@"Move not Alowed!!!");
                            MoveFromtxtBox.Clear();
                            MoveTotxtBox.Clear();
                        }
                    }                                       
                    if (DiceRe.Count == 0 )
                    {                        
                        ChangePlayer();
                    }
                }               
            }
            else
            {
                if (TheGame.CurrentPlayer == PlayerColor.Black && TheGame.GameBoard.TrianglesBar[1].Count != 0)
                {

                    if ((TheGame.MoveEligablityFromBar(GetNumber(firstDiceBox.Text) + GetNumber(secondDiceBox.Text)) &&
                         (TheGame.MoveEligablityFromBar(GetNumber(firstDiceBox.Text)) ||
                          TheGame.MoveEligablityFromBar(GetNumber(secondDiceBox.Text)))) ||
                        (TheGame.MoveEligablityFromBar(GetNumber(firstDiceBox.Text)) ||
                         (TheGame.MoveEligablityFromBar(GetNumber(secondDiceBox.Text)))))
                    {
                        if ((GetNumber(MoveTotxtBox.Text) ==
                             GetNumber(firstDiceBox.Text) + GetNumber(secondDiceBox.Text))
                            || GetNumber(MoveTotxtBox.Text) == GetNumber(firstDiceBox.Text) ||
                            GetNumber(MoveTotxtBox.Text) == GetNumber(secondDiceBox.Text))
                        {
                            if (GetNumber(MoveTotxtBox.Text) ==
                                (GetNumber(firstDiceBox.Text) + GetNumber(secondDiceBox.Text)))
                            {
                                if (TheGame.MoveEligablityFromBar(GetNumber(firstDiceBox.Text)))
                                {
                                    TheGame.ProccedMoveFromBar(GetNumber(firstDiceBox.Text));
                                    TheGame.ProccedMove(GetNumber(firstDiceBox.Text), GetNumber(secondDiceBox.Text));
                                }
                                else
                                {
                                    TheGame.ProccedMoveFromBar(GetNumber(secondDiceBox.Text));
                                    TheGame.ProccedMove(GetNumber(secondDiceBox.Text), GetNumber(firstDiceBox.Text));
                                }
                                DiceRe.Remove(GetNumber(firstDiceBox.Text));
                                DiceRe.Remove(GetNumber(secondDiceBox.Text));
                            }
                            else if (GetNumber(MoveTotxtBox.Text) == GetNumber(firstDiceBox.Text))
                            {
                                TheGame.ProccedMoveFromBar(GetNumber(firstDiceBox.Text));
                                DiceRe.Remove(GetNumber(MoveTotxtBox.Text));
                            }
                            else if (GetNumber(MoveTotxtBox.Text) == GetNumber(secondDiceBox.Text))
                            {
                                TheGame.ProccedMoveFromBar(GetNumber(secondDiceBox.Text));
                                DiceRe.Remove(GetNumber(MoveTotxtBox.Text));
                            }
                            MessageBox.Show(@"Move procceded!!!");
                            MoveFromtxtBox.Clear();
                            MoveTotxtBox.Clear();
                            UpdateTextBoxs();
                            bool noMoreMoves = false;
                            if (DiceRe.Count != 0)
                            {
                                noMoreMoves = !StillCanMove();
                            }
                            if (DiceRe.Count == 0 || noMoreMoves)
                            {
                                if (noMoreMoves)
                                {
                                    MessageBox.Show(@"There's No possible moves!!!");
                                }
                                ChangePlayer();
                            }

                        }
                        else
                        {
                            MessageBox.Show(@"Number of steps dosn't match the dices result!!!");
                            MoveFromtxtBox.Clear();
                            MoveTotxtBox.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Can't move from Bar!!!");
                    }

                }
                else if (TheGame.CurrentPlayer == PlayerColor.White && TheGame.GameBoard.TrianglesBar[0].Count != 0)
                {
                    if ((TheGame.MoveEligablityFromBar(GetNumber(firstDiceBox.Text) + GetNumber(secondDiceBox.Text)) &&
                         (TheGame.MoveEligablityFromBar(GetNumber(firstDiceBox.Text)) ||
                          TheGame.MoveEligablityFromBar(GetNumber(secondDiceBox.Text)))) ||
                        (TheGame.MoveEligablityFromBar(GetNumber(firstDiceBox.Text)) ||
                         (TheGame.MoveEligablityFromBar(GetNumber(secondDiceBox.Text)))))
                    {
                        if ((GetNumber(MoveTotxtBox.Text) ==
                             GetNumber(firstDiceBox.Text) + GetNumber(secondDiceBox.Text))
                            || GetNumber(MoveTotxtBox.Text) == GetNumber(firstDiceBox.Text) ||
                            GetNumber(MoveTotxtBox.Text) == GetNumber(secondDiceBox.Text))
                        {
                            if ((GetNumber(MoveTotxtBox.Text)) ==
                                (GetNumber(firstDiceBox.Text) + GetNumber(secondDiceBox.Text)))
                            {
                                if (TheGame.MoveEligablityFromBar(GetNumber(firstDiceBox.Text)))
                                {
                                    TheGame.ProccedMoveFromBar(GetNumber(firstDiceBox.Text));
                                    TheGame.ProccedMove(GetNumber(firstDiceBox.Text), GetNumber(secondDiceBox.Text));
                                }
                                else
                                {
                                    TheGame.ProccedMoveFromBar(GetNumber(secondDiceBox.Text));
                                    TheGame.ProccedMove(GetNumber(secondDiceBox.Text), GetNumber(firstDiceBox.Text));
                                }
                                DiceRe.Remove(GetNumber(firstDiceBox.Text));
                                DiceRe.Remove(GetNumber(secondDiceBox.Text));
                            }
                            else if ((GetNumber(MoveTotxtBox.Text)) == GetNumber(firstDiceBox.Text))
                            {
                                TheGame.ProccedMoveFromBar(GetNumber(firstDiceBox.Text));
                                DiceRe.Remove(GetNumber(firstDiceBox.Text));
                            }
                            else if ((GetNumber(MoveTotxtBox.Text)) == GetNumber(secondDiceBox.Text))
                            {
                                TheGame.ProccedMoveFromBar(GetNumber(secondDiceBox.Text));
                                DiceRe.Remove(GetNumber(secondDiceBox.Text));
                            }

                            MessageBox.Show(@"Move procceded!!!");
                            MoveFromtxtBox.Clear();
                            MoveTotxtBox.Clear();
                            UpdateTextBoxs();
                            bool noMoreMoves = false;
                            if (DiceRe.Count != 0)
                            {
                                noMoreMoves = !StillCanMove();
                            }
                            if (DiceRe.Count == 0 || noMoreMoves)
                            {
                                if (noMoreMoves)
                                {
                                    MessageBox.Show(@"There's No possible moves!!! ");
                                }
                                ChangePlayer();
                            }
                        }
                        else
                        {
                            MessageBox.Show(@"Number of steps dosn't match the dices result!!!");
                            MoveFromtxtBox.Clear();
                            MoveTotxtBox.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Can't move from Bar!!!");
                    }
                }
                else
                {
                    var from = GetNumber(MoveFromtxtBox.Text);
                    var steps = GetNumber(MoveTotxtBox.Text) - GetNumber(MoveFromtxtBox.Text);
                    if (steps == GetNumber(firstDiceBox.Text) || steps == GetNumber(secondDiceBox.Text) ||
                        steps == (GetNumber(firstDiceBox.Text) + GetNumber(secondDiceBox.Text)))
                    {
                        if (TheGame.MoveEligablity(from, steps) &&
                            (TheGame.MoveEligablity(from, GetNumber(firstDiceBox.Text))
                             || TheGame.MoveEligablity(from, GetNumber(secondDiceBox.Text))))
                        {
                            if (steps == (GetNumber(firstDiceBox.Text) + GetNumber(secondDiceBox.Text)))
                            {
                                if (TheGame.MoveEligablity(from, GetNumber(firstDiceBox.Text)))
                                {
                                    TheGame.ProccedMove(from, GetNumber(firstDiceBox.Text));
                                    TheGame.ProccedMove(from + GetNumber(firstDiceBox.Text),
                                        GetNumber(secondDiceBox.Text));
                                }
                                else
                                {
                                    TheGame.ProccedMove(from, GetNumber(secondDiceBox.Text));
                                    TheGame.ProccedMove(from + GetNumber(secondDiceBox.Text),
                                        GetNumber(firstDiceBox.Text));
                                }
                                DiceRe.Remove(GetNumber(firstDiceBox.Text));
                                DiceRe.Remove(GetNumber(secondDiceBox.Text));
                            }
                            else if (steps == GetNumber(firstDiceBox.Text))
                            {
                                TheGame.ProccedMove(from, steps);
                                DiceRe.Remove(steps);
                            }
                            else if (steps == GetNumber(secondDiceBox.Text))
                            {
                                TheGame.ProccedMove(from, steps);
                                DiceRe.Remove(steps);
                            }

                            MessageBox.Show(@"Move procceded!!!");
                            if (TheGame.IsGameOver())
                            {
                                MessageBox.Show(@"Game Over !!!");
                                MessageBox.Show(@"The Winner is : {0}", TheGame.Winner().ToString());
                                Dispose();
                            }
                            MoveFromtxtBox.Clear();
                            MoveTotxtBox.Clear();
                            UpdateTextBoxs();
                            bool noMoreMoves = false;
                            if (DiceRe.Count != 0)
                            {
                                noMoreMoves = !StillCanMove();
                            }

                            if (DiceRe.Count == 0 || noMoreMoves)
                            {
                                if (noMoreMoves)
                                {
                                    MessageBox.Show(@"There's No possible moves !!! ");
                                }
                                ChangePlayer();
                            }
                        }
                        else
                        {
                            MessageBox.Show(@"Can't procced the move!!!");
                            MoveFromtxtBox.Clear();
                            MoveTotxtBox.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Number of steps dosn't match the dices result!!!");
                        MoveFromtxtBox.Clear();
                        MoveTotxtBox.Clear();
                    }
                }
            }
        }

        private void UpdateTextBoxs()
        {
            var tRiangelsBoxs = new []
            {
                Triangle1,Triangle2,Triangle3,Triangle4, Triangle5 , Triangle6 , Triangle7,Triangle8,Triangle9,Triangle10,
                Triangle11,Triangle12,Triangle13,Triangle14, Triangle15 , Triangle16 , Triangle17,Triangle18,Triangle19,Triangle20,
                Triangle21,Triangle22,Triangle23,Triangle24
            };

            var checkersBoxs = new []
            {
                checker1,checker2,checker3,checker4, checker5 , checker6 , checker7,checker8,checker9,checker10,
                checker11,checker12,checker13,checker14, checker15 , checker16 , checker17,checker18,checker19,checker20,
                checker21,checker22,checker23,checker24
            };


            for (var i = 0; i < 24; i++)
            {
                if (6 > i)
                {
                    tRiangelsBoxs[i].Text = TheGame.GameBoard.HomeP1.TrianglesZone[i].Player.ToString();
                    checkersBoxs[i].Text = TheGame.GameBoard.HomeP1.TrianglesZone[i].Count.ToString();
                }
                else if (12 > i)
                {
                    tRiangelsBoxs[i].Text = TheGame.GameBoard.OutP1.TrianglesZone[i % 6].Player.ToString();
                    checkersBoxs[i].Text = TheGame.GameBoard.OutP1.TrianglesZone[i % 6].Count.ToString();
                }
                else if (18 > i)
                {
                    tRiangelsBoxs[i].Text = TheGame.GameBoard.OutP2.TrianglesZone[i % 12].Player.ToString();
                    checkersBoxs[i].Text = TheGame.GameBoard.OutP2.TrianglesZone[i % 12].Count.ToString();
                }
                else
                {
                    tRiangelsBoxs[i].Text = TheGame.GameBoard.HomeP2.TrianglesZone[i % 18].Player.ToString();
                    checkersBoxs[i].Text = TheGame.GameBoard.HomeP2.TrianglesZone[i % 18].Count.ToString();
                }
            }
            whiteHomeBox.Text = TheGame.HomeWhite.ToString();
            BlackHomeBox.Text = TheGame.HomeBlack.ToString();
            whiteBarBox.Text = TheGame.CountBarCheckers(TheGame.Player1.Color).ToString();
            BlackBarBox.Text = TheGame.CountBarCheckers(TheGame.Player2.Color).ToString();
            TurnBox.Text = TheGame.CurrentPlayer.ToString();
        }
       
        private static int GetNumber(string triangleBtn)
        {           
            triangleBtn = Regex.Replace(triangleBtn, "[^0-9]+", string.Empty);
            return int.Parse(triangleBtn);
        }

        private bool StillCanMove()
        {
            if (TheGame.CurrentPlayer == PlayerColor.Black && TheGame.GameBoard.TrianglesBar[1].Count != 0)
            {
                if (DiceRe.Count > 1)
                {
                    if (TheGame.MoveEligablityFromBar(DiceRe[1]) || TheGame.MoveEligablityFromBar(DiceRe[0]))
                        return true;
                }
                else
                {
                    int x = DiceRe.First();
                    if (TheGame.MoveEligablityFromBar(x))
                    {
                        return true;
                    }
                }
            }
            else if (TheGame.CurrentPlayer == PlayerColor.White && TheGame.GameBoard.TrianglesBar[0].Count != 0)
            {
                if (DiceRe.Count > 1)
                {
                    if (TheGame.MoveEligablityFromBar(DiceRe[1]) || TheGame.MoveEligablityFromBar(DiceRe[0]))
                        return true;
                }
                else
                {
                    int x = DiceRe.First();
                    if (TheGame.MoveEligablityFromBar(x))
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 1; i < 25; i++)
                {
                    if (TheGame.TriangleByOrder(i).Player == TheGame.CurrentPlayer)
                        if (DiceRe.Count > 1)
                        {
                            if (TheGame.MoveEligablity(i, DiceRe[0]) || TheGame.MoveEligablity(i, DiceRe[1]))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            int x = DiceRe.First();
                            if (TheGame.MoveEligablity(i, x ))
                            {
                                return true;
                            }
                        }                        
                }
            }
            return false;
        }

        private void ChangePlayer()
        {
            RollDiceBtn.Show();
            firstDiceBox.Clear();
            secondDiceBox.Clear();
            TheGame.ChangePlayerTurn();
            UpdateTextBoxs();
            MessageBox.Show(TheGame.CurrentPlayer == PlayerColor.White
                ? @"White Player Turn!!!"
                : @"Black Player Turn!!!");
        }

        
    }
}
