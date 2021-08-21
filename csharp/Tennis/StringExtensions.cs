
namespace Tennis
{
    public static class StringExtensions
    {
        public static int toPlayerNumber(this string playerName) => playerName == "player1" ? 0 : 1;
    }
}