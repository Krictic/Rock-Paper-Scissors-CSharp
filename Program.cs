using static System.Net.Mime.MediaTypeNames;

public class MyApp
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Type 'play' to start.");
        var read = Console.ReadLine();

        if (read == "play" && read != "exit")
        {
            StartGame();
        }

    }
    public static string ComputerChoice()
    {
        var rand = new Random();
        int rng = rand.Next(1, 9);


        if (rng >= 0 && rng <= 3)
        {
            return "rock";
        }
        else if (rng >= 4 && rng <= 6)
        {
            return "paper";
        }
        else
        {
            return "scissors";
        }
    }

    public static string PlayRound(string playerSelection, string computerSelection)
    {
        if (playerSelection == computerSelection)
        {
            return "D"; // Draw
        }
        else if (playerSelection == "rock" && computerSelection == "paper")
        {
            return "C"; // Computer wins
        }
        else if (playerSelection == "paper" && computerSelection == "rock")
        {
            return "P"; // Player wins
        }
        else if (playerSelection == "scissors" && computerSelection == "paper")
        {
            return "P";
        }
        else if (playerSelection == "paper" && computerSelection == "scissors")
        {
            return "C";
        }
        else if (playerSelection == "scissors" && computerSelection == "rock")
        {
            return "C";
        }
        else if (playerSelection == "rock" && computerSelection == "scissors")
        {
            return "P";
        }
        else
        {
            return "error";
        }
    }

    public static string StartGame()
    {
        int rounds = 0;
        int playerScore = 0;
        int computerScore = 0;
        int draw = 0;
        string[] allowedInputs = { "rock", "paper", "scissors" };

        Console.WriteLine("Type either rock, paper or scissors: ");
        string? player = Console.ReadLine();
        int pos = Array.IndexOf(allowedInputs, player);
        if (pos > -1 && player != null)
        {
            while (rounds <= 4)
            {
                string computer = ComputerChoice();
                string result = PlayRound(player, computer);

                if (result == "P")
                {
                    playerScore++;
                    Console.WriteLine("Player");
                }
                else if (result == "C")
                {
                    computerScore++;
                    Console.WriteLine("Computer");
                }
                else if (result == "D")
                {
                    draw++;
                    Console.WriteLine("Draw");
                }
                else
                {
                    Console.WriteLine("error");
                }
                rounds++;
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
            StartGame();
        }
        string scores = string.Format("Player Score: {0} \n Computer Score: {1} \n Draws: {2}", playerScore, computerScore, draw);

        if (playerScore > computerScore)
        {
            Console.WriteLine(string.Format("Player won. \n The scores were: \n {0}", scores));
        }
        else if (playerScore < computerScore)
        {
            Console.WriteLine(string.Format("Computer won. \n The scores were: \n {0}", scores));
        }
        else
        {
            Console.WriteLine(string.Format("DRAW! \n The scores were: \n {0}", scores));
        }

        Console.Write("Do you want to play again? (yes or no) ");
        if (Console.ReadLine() == "yes")
        {
            return StartGame();
        }
        else
        {
            return "";
        }

    }

}