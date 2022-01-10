using System;

namespace QuadaxMastermindProblem
{
    class Mastermind
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine();
            Console.WriteLine("Enter a 4 digit number to begin guessing the generated answer.");
            Console.WriteLine("A + sign will indicate a digit is correct and in the correct location.");
            Console.WriteLine("A - sign will indicate the digit is correct, but in the wrong location.");
            Console.WriteLine("The digits are between 1-6 and you will have 10 attempts. Good luck!");

            string endGame = "Y";
            while (endGame.Equals("Y"))
            {
                Random rand = new Random();
                bool won = false;
                string answer = "";
                for (int i = 0; i < 4; i++)
                {
                    int generatedDigit = rand.Next(6) + 1;
                    answer += generatedDigit;
                }
                for (int i = 0; i < 10; i++)
                {
                    string feedback = "";
                    string guess = Console.ReadLine();
                    if (guess.Length != 4)
                    {
                        Console.WriteLine("Please enter only 4 digit guesses");
                        i--;
                        continue;
                    }

                    bool[] used = new bool[4];
                    for (int guessIndex = 0; guessIndex < 4; guessIndex++)
                    {
                        string partFeedback = " ";
                        int fixIndex = 0;
                        bool digitUsed = false;
                        for (int answerIndex = 0; answerIndex < 4; answerIndex++)
                        {
                            if (guess[guessIndex] == answer[answerIndex])
                            {
                                if (guessIndex == answerIndex)
                                {
                                    used[answerIndex] = true;
                                    partFeedback = "+";
                                    if (digitUsed)
                                        used[fixIndex] = false;
                                    break;
                                }
                                if (!used[answerIndex])
                                {
                                    partFeedback = "-";
                                    used[answerIndex] = true;
                                    if (digitUsed)
                                        used[fixIndex] = false;
                                    digitUsed = true;
                                    fixIndex = answerIndex;
                                }
                            }
                        }

                        feedback += partFeedback;
                    }
                    Console.WriteLine(feedback);
                    if (feedback.Equals("++++"))
                    {
                        Console.WriteLine("You win!");
                        won = true;
                        break;
                    }
                }
                if (!won)
                    Console.WriteLine("Sorry, you ran out of attempts. The answer was " + answer + ".");
                Console.WriteLine("Would you like to play again? Enter Y for yes. Enter any other charater for no.");
                endGame = Console.ReadLine();
            }
        }
    }
}
