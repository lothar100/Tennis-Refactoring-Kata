using System;

namespace Tennis
{
    class TennisGame : ITennisGame
    {
        private Player[] _players;
        public Player Player1 => _players[0];
        public Player Player2 => _players[1];

        public TennisGame(string player1Name, string player2Name)
        {
            _players = new Player[2];
            _players[0] = new Player(player1Name);
            _players[1] = new Player(player2Name);
        }

        public void WonPoint(string playerName) => _players[playerName.toPlayerNumber()].Score++;

        public string GetScore()
        {
            // if scores are equal
            if (Player1.Score == Player2.Score) return Player1.Phrases.EqualScorePhrase;

            // if a player has won or is close to winning
            if(Player1.Score > Player2.Score && Player1.Score >= 4){
                int diff = Player1.Score - Player2.Score;
                return Player1.Phrases.EndGamePhrase[diff >= 2 ? 1 : 0];
            }

            if(Player2.Score > Player1.Score && Player2.Score >= 4){
                int diff = Player2.Score - Player1.Score;
                return Player2.Phrases.EndGamePhrase[diff >= 2 ? 1 : 0];
            }

            // else it's mid game
            return Utils.join(Player1.Phrases.MidGamePhrase, Player2.Phrases.MidGamePhrase);
        }
    }
}

