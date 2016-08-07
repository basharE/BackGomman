namespace Control
{
    public interface IGame
    {
        void CreateGame();
        int[] FirstPlayerToPlay();
        int[] DiceRoll();
        int CountBarCheckers(PlayerColor player);
        bool MoveEligablity(int from, int count);
        bool AllCkeckersInBase(int except);
        void ProccedMove(int fromTriangle, int count);
        void ProccedMoveFromBar(int toTriangle);
        bool MoveEligablityFromBar(int toTriangle);
        Triangle TriangleByOrder(int order);
        void RemoveChecker(int from);
        void AddChecker(int to);
        bool IsGameOver();
        PlayerColor Winner();
        void ChangePlayerTurn();
        bool IsCheckersAtHome();
    }
}
