namespace Diamond
{
    public class Program
    {
        static void Main(string[] args)
        {
            var diamond = Create('c');
            Console.WriteLine(diamond);

        }

        public static string Create(char target)
        {
            if (!char.IsAsciiLetter(target))
                throw new ArgumentException("It must be a letter.", nameof(target));

            return string.Join('\n', GenerateDiamondLines(target));
        }

        public static string[] GenerateDiamondLines(char target)
        {
            int count = char.ToUpper(target) - 'A';
            string[] numberOfLinesInDiamond = new string[2 * count + 1];

            string startAndEndPadding = new string(' ', count);

            numberOfLinesInDiamond[0] = numberOfLinesInDiamond[^1] = startAndEndPadding + 'A' + startAndEndPadding;

            for (int i = 1; i <= count; i++)
            {
                char nextLetter = (char)('A' + i);
                string middlePadding = new string(' ', 2 * i - 1);
                numberOfLinesInDiamond[i] = numberOfLinesInDiamond[^(i + 1)] = startAndEndPadding[i..] + nextLetter + middlePadding + nextLetter + startAndEndPadding[i..];
            }

            return numberOfLinesInDiamond;
        }
    }
}
