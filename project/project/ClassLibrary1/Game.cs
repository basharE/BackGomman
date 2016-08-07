using System;
namespace Control
{
    public class Game : IGame
    {

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public PlayerColor CurrentPlayer { get; set; }
        public Board GameBoard { get; set; }
        public int HomeWhite { get; set; }
        public int HomeBlack { get; set; }



        public Game()
        {
            CreateGame();
        }


        public void CreateGame()
        {

            Player1 = new Player(PlayerColor.White);
            Player2 = new Player(PlayerColor.Black);
            GameBoard = new Board();

            GameBoard.HomeP1.TrianglesZone[0].Player = PlayerColor.White;
            GameBoard.HomeP1.TrianglesZone[0].Count = 2;
            GameBoard.HomeP1.TrianglesZone[5].Player = PlayerColor.Black;
            GameBoard.HomeP1.TrianglesZone[5].Count = 5;

            GameBoard.OutP1.TrianglesZone[1].Player = PlayerColor.Black;
            GameBoard.OutP1.TrianglesZone[1].Count = 3;
            GameBoard.OutP1.TrianglesZone[5].Player = PlayerColor.White;
            GameBoard.OutP1.TrianglesZone[5].Count = 5;

            GameBoard.OutP2.TrianglesZone[0].Player = PlayerColor.Black;
            GameBoard.OutP2.TrianglesZone[0].Count = 5;
            GameBoard.OutP2.TrianglesZone[4].Player = PlayerColor.White;
            GameBoard.OutP2.TrianglesZone[4].Count = 3;

            GameBoard.HomeP2.TrianglesZone[0].Player = PlayerColor.White;
            GameBoard.HomeP2.TrianglesZone[0].Count = 5;
            GameBoard.HomeP2.TrianglesZone[5].Player = PlayerColor.Black;
            GameBoard.HomeP2.TrianglesZone[5].Count = 2;
            
        }


        public void Play()
        {
           // CurrentPlayer = FirstPlayerToPlay();
            int[] diceResult = DiceRoll();
            CurrentPlayer = PlayerColor.White;


            ProccedMove(1, 4);
            ProccedMove(1, 3);
            //MoveEligablity(1, 7);
            ProccedMove(12, 4);
            ProccedMove(12, 3);
            ProccedMove(12, 7);
            ProccedMove(17, 4);
            ProccedMove(17, 3);
            //MoveEligablity(17, 7);
            ProccedMove(19, 4);
            ProccedMove(19, 3);
            //MoveEligablity(19, 7);
            

        }

        // returns the color of the first player to play
        public int[] FirstPlayerToPlay()
        {
            var dice = DiceRoll();
            while (dice[0] == dice[1])
            {
                DiceRoll();
            }
            CurrentPlayer = dice[0] > dice[1] ? PlayerColor.White : PlayerColor.Black;
            return dice;
        }



        // returns the result of throwing dice twice
        public int[] DiceRoll()
        {
            var dice= new int[2];
            var rnd = new Random();
            dice[0] = rnd.Next(1, 7);
            dice[1] = rnd.Next(1, 7);
            return dice;
        }



        /**/
        public int CountBarCheckers(PlayerColor player)
        {

            switch (player)
            {
                case PlayerColor.White: return GameBoard.TrianglesBar[0].Count;
                case PlayerColor.Black: return GameBoard.TrianglesBar[1].Count;
                default: return 0;
            }
        }


        /**/
        //  returns if the move is eligible to procced
        public bool MoveEligablity(int from, int count)
        {
            if (from < 0 || from > 24) return false;
            
            if (TriangleByOrder(from).Count == 0) return false;
            var who = TriangleByOrder(from).Player;
            int target;
            if (who == PlayerColor.White)
            {
                if (GameBoard.TrianglesBar[0].Count > 0) return false;
                target = from + count;
            }
            else
            {
                if (GameBoard.TrianglesBar[1].Count > 0) return false;
                target = from + count;
            }
            if (target > 24 || target < 1)
            {
                return AllCkeckersInBase(from);
            }
            var tarwho = TriangleByOrder(target).Player;
            if (tarwho == who || tarwho == PlayerColor.None)
            {
                return true;
            }
            else
            {
                return TriangleByOrder(target).Count == 1;
            }
        }


        /**/

        public bool AllCkeckersInBase(int except)
        {
            var from = 1;
            var to = 18;
            
            switch (CurrentPlayer)
            {
                case PlayerColor.Black:
                    if (GameBoard.TrianglesBar[1].Count > 0) return false;
                    break;
                case PlayerColor.White:
                    if (GameBoard.TrianglesBar[0].Count > 0) return false;
                    break;
                default: return false;
            }
            for (var i = from; i < to; i++)
            {
                if (TriangleByOrder(i).Player == CurrentPlayer && (i == except || TriangleByOrder(i).Count >= 1))
                {
                    return false;
                }
            }
            return true;
        }
        /* Test */
        /* Test */
        /* Test */
        // returns if procceding a move went succefully
        public void ProccedMove(int fromTriangle, int count)
        {           
            if (!MoveEligablity(fromTriangle, count)) throw new WrongMoveException();

            if (CurrentPlayer == PlayerColor.Black)
            {
                var target = fromTriangle + count;
                if (target > 24)
                {
                    HomeBlack++;
                }
                else if (TriangleByOrder(target).Player == PlayerColor.White)
                {
                    RemoveChecker(target);
                    GameBoard.TrianglesBar[0].Count++;
                    AddChecker(target);
                }
                else
                {
                    AddChecker(target);
                }
            }
            else
            {
                var target = fromTriangle + count;
                if (target < 0)
                {
                    HomeWhite++;
                }
                else if (TriangleByOrder(target).Player == PlayerColor.Black)
                {
                    RemoveChecker(target);
                    GameBoard.TrianglesBar[1].Count++;
                    AddChecker(target);
                }
                else
                {
                    AddChecker(target);
                }
            }
            if (fromTriangle != 0)
            {
                RemoveChecker(fromTriangle);

            }
        }
        /* Test */
        /* Test */
        /* Test */
        /* Test */
        public void ProccedMoveFromBar(int toTriangle)
        {
            if (MoveEligablityFromBar(toTriangle)) throw new WrongMoveException();
            switch (CurrentPlayer)
            {
                case PlayerColor.White:
                    GameBoard.TrianglesBar[0].Count--;                    
                    ProccedMove(0, toTriangle);
                    break;
                case PlayerColor.Black:
                    GameBoard.TrianglesBar[1].Count--;                   
                    ProccedMove(0, toTriangle);
                    break;
            }
        }
        /* Test */
        /* Test */
        /* Test */
        //  returns if the move is eligible to procced
        public bool MoveEligablityFromBar(int toTriangle)
        {
            switch (CurrentPlayer)
            {
                case PlayerColor.Black:
                    if (GameBoard.TrianglesBar[1].Count == 0) return false;
                    if (TriangleByOrder(toTriangle).Player == PlayerColor.White && TriangleByOrder(toTriangle).Count>1) return false;
                    break;
                case PlayerColor.White:
                    if (GameBoard.TrianglesBar[0].Count == 0) return false;
                    if (TriangleByOrder(toTriangle).Player == PlayerColor.Black&&TriangleByOrder(toTriangle).Count > 1) return false;
                    break;
                default: return false;
            }
            return true;
        }
        



        public Triangle TriangleByOrder(int order)
        {
            var range = (order-1) / 6;
            switch (range)
            {
                case 0:
                    if(CurrentPlayer==PlayerColor.Black)
                        return GameBoard.HomeP2.TrianglesZone[6 - order];
                    else
                    {
                        return GameBoard.HomeP1.TrianglesZone[order - 1];
                    }
                    break;
                case 1:
                    if (CurrentPlayer == PlayerColor.Black)
                        return GameBoard.OutP2.TrianglesZone[12 - order];
                    else
                    {
                        return GameBoard.OutP1.TrianglesZone[order - 7];
                    }
                    break;
                case 2:
                    if (CurrentPlayer == PlayerColor.Black)
                        return GameBoard.OutP1.TrianglesZone[18 - order];
                    else
                    {
                        return GameBoard.OutP2.TrianglesZone[order - 13];
                    }
                    break;
                default:
                    if (CurrentPlayer == PlayerColor.Black)
                        return GameBoard.HomeP1.TrianglesZone[24 - order];
                    else
                    {
                        return GameBoard.HomeP2.TrianglesZone[order - 19];
                    }
                    break;
            }
        }

    


        public void RemoveChecker(int from)
        {
            TriangleByOrder(from).Count--;
            if (TriangleByOrder(from).Count == 0)
            {
                TriangleByOrder(from).Player = PlayerColor.None;
            }
        }




        public void AddChecker(int to)
        {
            TriangleByOrder(to).Count++;
            if (TriangleByOrder(to).Player == PlayerColor.None)
            {
                TriangleByOrder(to).Player = CurrentPlayer;
            }
        }




        public bool IsGameOver()
        {
            return HomeWhite == 15 || HomeBlack == 15;
        }




        public PlayerColor Winner()
        {
            if (!IsGameOver())
            {
                return PlayerColor.None;
            }
            return HomeWhite == 15 ? PlayerColor.White : PlayerColor.Black;
        }




        public void ChangePlayerTurn()
        {
            CurrentPlayer = CurrentPlayer == PlayerColor.White ? PlayerColor.Black : PlayerColor.White;
        }




        public bool IsCheckersAtHome()
        {
            var checkersSum = 0;
            for (var i = 19; i < 25; i++)
            {
                if (TriangleByOrder(i).Player == CurrentPlayer)
                {
                    checkersSum += TriangleByOrder(i).Count;
                }
            }
            return checkersSum == 15;
        }        
    }    
}
