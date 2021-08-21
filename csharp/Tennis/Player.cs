
namespace Tennis
{
    class Player
    {
        public string Name;
        public int Score;
        public int Num => Name.toPlayerNumber();
        public Player(string name)
        {
            Name = name;
        }
        
    }

}