
namespace Tennis
{
    class Player
    {
        public Phrases Phrases;
        public string Name;
        public int Score;
        public int Num => Name.toPlayerNumber();
        public Player(string name)
        {
            Name = name;
            var self = this;
            Phrases = new Phrases(ref self);
        }

    }

}