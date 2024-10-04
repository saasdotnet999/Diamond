namespace Diamond.Tests
{
    public class DiamondPatternTests
    {
        [Fact]
        public void Create_WithSpecialCharacter_ThrowsArgumentException()
        {            
            char input = '@';
         
            var exception = Assert.Throws<ArgumentException>(() => Program.Create(input));

            Assert.Equal("It must be a letter. (Parameter 'target')", exception.Message);
        }

        [Fact]
        public void Create_WithNonLetter_ThrowsArgumentException()
        {
            char input = '1';
         
            var exception = Assert.Throws<ArgumentException>(() => Program.Create(input));

            Assert.Equal("It must be a letter. (Parameter 'target')", exception.Message);
        }

        [Theory]
        [InlineData('A')]
        [InlineData('a')]
        public void Create_WithUpperOrLowercaseA_ReturnsCorrectDiamond(char input)
        {            
            string expected = "A";
            
            string result = Program.Create(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('B')]
        [InlineData('b')]
        public void Create_WithUpperOrLowercaseB_ReturnsCorrectDiamond(char input)
        {
            string expected = " A \nB B\n A ";
         
            string result = Program.Create(input);
            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('C')]
        [InlineData('c')]
        public void Create_WithUpperOrLowercaseC_ReturnsCorrectDiamond(char input)
        {           
            string expected = "  A  \n B B \nC   C\n B B \n  A  ";
         
            string result = Program.Create(input);

            Assert.Equal(expected, result);
        }                

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        public void GenerateDiamondLines_ShouldHaveSymmetricLines(char input)
        {
            string[] lines = Program.GenerateDiamondLines(input);

            for (int i = 0; i < lines.Length/2; i++)
            {
                Assert.Equal(lines[i], lines[^(i + 1)]);
            }
        }

        [Theory]
        [InlineData('A', "A")]
        [InlineData('B', " A ")]
        [InlineData('C', "  A  ")]
        public void FirstAndLastLines_ShouldBeACentered(char input, string expectedLine)
        {
            string[] diamondLines = Program.GenerateDiamondLines(char.ToUpper(input));

            Assert.Equal(expectedLine, diamondLines[0]);
            Assert.Equal(expectedLine, diamondLines[^1]);
        }

        [Theory]
        [InlineData('A', 1)]
        [InlineData('B', 3)]
        [InlineData('C', 5)]
        public void GenerateDiamondLines_ShouldHaveCorrectNumberOfLines(char input, int expectedNumberOfLines)
        {
            string[] diamondLines = Program.GenerateDiamondLines(char.ToUpper(input));

            Assert.Equal(expectedNumberOfLines, diamondLines.Length);
        }
    }
}