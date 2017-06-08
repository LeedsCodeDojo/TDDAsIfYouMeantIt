using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Tests
{
    [TestClass]
    public class Tests
    {
        private const string IN_PROGRESS = "In Progress";
        private const string X_WINS = "X Wins";
        private const string O_WINS = "0 Wins";
        private const string DRAW = "Draw";

        [TestMethod]
        public void DataDrivenTests()
        {
            // Tests are in groups of 6 lines followed by a blank line
            var lines = System.IO.File.ReadAllLines(@"tests.txt");
            var numberOfLines = lines.Length;
            var currentLine = 0;
            var testNumber = 1;

            while (currentLine + 6 <= numberOfLines)
            {
                //First line is the description
                var description = lines[currentLine];

                //Second line is the expected result
                var expectedResult = lines[currentLine + 1];

                //Next 5 lines is the board
                var board = lines[currentLine + 2] + System.Environment.NewLine +
                            lines[currentLine + 3] + System.Environment.NewLine +
                            lines[currentLine + 4] + System.Environment.NewLine +
                            lines[currentLine + 5] + System.Environment.NewLine +
                            lines[currentLine + 6] + System.Environment.NewLine;
                currentLine = currentLine + 7;

                var gameState = GetGameState(board);

                if (gameState != expectedResult)
                    Assert.Fail($"Test number {testNumber} - {description} has failed.  Expected result was {expectedResult} but the actual result was {gameState}.");

                //Skip any blank lines
                while (currentLine < numberOfLines && string.IsNullOrWhiteSpace(lines[currentLine]))
                    currentLine++;
                testNumber++;
            }

        }

        private string GetGameState(string board)
        {
            const byte TOP_LEFT = 0;
            const byte TOP_MIDDLE = 2;
            const byte TOP_RIGHT = 4;
            const byte MIDDLE_LEFT = 14;
            const byte MIDDLE_MIDDLE = 16;
            const byte MIDDLE_RIGHT = 18;
            const byte BOTTOM_LEFT = 28;
            const byte BOTTOM_MIDDLE = 30;
            const byte BOTTOM_RIGHT = 32;

            var winningPositions = new byte[8, 3]
            {
                    { TOP_LEFT, TOP_MIDDLE, TOP_RIGHT },
                    { MIDDLE_LEFT, MIDDLE_MIDDLE, MIDDLE_RIGHT },
                    { BOTTOM_LEFT, BOTTOM_MIDDLE, BOTTOM_RIGHT },

                    { TOP_LEFT, MIDDLE_MIDDLE, BOTTOM_RIGHT },
                    { TOP_RIGHT, MIDDLE_MIDDLE, BOTTOM_LEFT },

                    { TOP_LEFT, MIDDLE_LEFT, BOTTOM_LEFT },
                    { TOP_MIDDLE, MIDDLE_MIDDLE, BOTTOM_MIDDLE },
                    { TOP_RIGHT, MIDDLE_RIGHT, BOTTOM_RIGHT }
            };

            bool DoesBoardContainLineOf(char piece)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (board[winningPositions[i, 0]] == piece && board[winningPositions[i, 1]] == piece && board[winningPositions[i, 2]] == piece)
                    {
                        return true;
                    }

                }
                return false;
            }


            string gameState;
            if (DoesBoardContainLineOf('X'))
            {
                gameState = X_WINS;
            }
            else if (DoesBoardContainLineOf('0'))
            {
                gameState = O_WINS;
            }
            else if (!board.Contains(" "))
            {
                gameState = DRAW;
            }
            else
            {
                gameState = IN_PROGRESS;
            }

            return gameState;
        }



    }
}
