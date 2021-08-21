using System;

namespace Tennis
{
    class TennisGame : ITennisGame
    {
        private (string Love, string All, string Fifteen, string Thirty, string Deuce, Func<int, string> WinForPlayer, Func<int,string> AdvantageForPlayer) _phrases =>
                (Love: "Love", All: "All", Fifteen: "Fifteen", Thirty: "Thirty", Deuce: "Deuce",
                WinForPlayer: (int player) => $"WinForPlayer{_players[player].Name}",
                AdvantageForPlayer: (int player) => $"Advantage ${_players[player].Name}");
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
            string score = "";
            var tempScore = 0;
            if (Player1.Score == Player2.Score)
            {
                switch (Player1.Score)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (Player1.Score >= 4 || Player2.Score >= 4)
            {
                var minusResult = Player1.Score - Player2.Score;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = Player1.Score;
                    else { score += "-"; tempScore = Player2.Score; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
}

