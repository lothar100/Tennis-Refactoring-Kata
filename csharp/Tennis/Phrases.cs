using System;

namespace Tennis
{
    class Phrases
    {
        public string Love = "Love";
        public string All = "All";
        public string Fifteen = "Fifteen";
        public string Thirty = "Thirty";
        public string Forty = "Forty";
        public string Deuce = "Deuce";
        public string Advantage => $"Advantage {_player.Name}";
        public string Win => $"Win for {_player.Name}";

        private Player _player;
        private string[] _equalScorePhrases; // "Love-All", "Fifteen-All", "Thirty-All", "Deuce"
        private string[] _endGamePhrases; // "Advantage playerX", "Win for playerX"

        private string[] _midGamePhrases; // "Love", "Fifteen", "Thirty", "Forty"
        public Phrases(ref Player player)
        {
            _player = player;
            _equalScorePhrases = new string[] { Utils.join(Love, All), Utils.join(Fifteen, All), Utils.join(Thirty, All), Deuce };
            _endGamePhrases = new string[] { Advantage, Win };
            _midGamePhrases = new string[] { Love, Fifteen, Thirty, Forty };
        }
        public string EqualScorePhrase => _equalScorePhrases[Math.Min(_player.Score, 3)];

        public string[] EndGamePhrase => _endGamePhrases;
        public string MidGamePhrase => _midGamePhrases[_player.Score];
        
    }

}