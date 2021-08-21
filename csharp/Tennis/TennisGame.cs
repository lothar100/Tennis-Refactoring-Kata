using System;

namespace Tennis
{
    class TennisGame : ITennisGame
    {
        private (string Love, string All, string Fifteen, string Thirty, string Forty, string Deuce, Func<int, string> WinForPlayer, Func<int,string> AdvantageForPlayer) _phrases =>
                (Love: "Love", All: "All", Fifteen: "Fifteen", Thirty: "Thirty", Forty: "Forty", Deuce: "Deuce",
                WinForPlayer: (int player) =>
                {
                    return $"Win for {_players[player].Name}";
                },
                AdvantageForPlayer: (int player) =>
                {
                    return $"Advantage {_players[player].Name}";
                });
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
            Func<string, string, string> join = (string left, string right) => $"{left}-{right}";
            // "Love-All", "Fifteen-All", "Thirty-All", "Deuce"
            string[] equalScorePhrases = { join(_phrases.Love, _phrases.All), join(_phrases.Fifteen, _phrases.All), join(_phrases.Thirty, _phrases.All), _phrases.Deuce };
            
            if (Player1.Score == Player2.Score) return equalScorePhrases[Math.Min(Player1.Score, 3)];

            // "Advantage playerX", "Win for playerX"
            (Func<int, string[]> Player, int placeholder) endGamePhrases = (Player: (int playerX) =>  new string[]{ _phrases.AdvantageForPlayer(playerX), _phrases.WinForPlayer(playerX) } , placeholder: 0);

            if(Player1.Score > Player2.Score && Player1.Score >= 4){
                int diff = Player1.Score - Player2.Score;
                return endGamePhrases.Player(Player1.Num)[diff >= 2 ? 1 : 0];
            }

            if(Player2.Score > Player1.Score && Player2.Score >= 4){
                int diff = Player2.Score - Player1.Score;
                return endGamePhrases.Player(Player2.Num)[diff >= 2 ? 1 : 0];
            }

            string[] midGamePhrases = { _phrases.Love, _phrases.Fifteen, _phrases.Thirty, _phrases.Forty };
            return join(midGamePhrases[Player1.Score], midGamePhrases[Player2.Score]);
        }
    }
}

