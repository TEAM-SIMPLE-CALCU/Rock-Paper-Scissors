using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Models;
using System.Diagnostics;

namespace RockPaperScissors.Controllers
{
    public class GameController : Controller
    {
        private static int playerScore = 0;
        private static int computerScore = 0;

        // GET: Game
        public ActionResult Index()
        {
            ViewBag.PlayerScore = playerScore;
            ViewBag.ComputerScore = computerScore;
            return View();
        }

        [HttpPost]
        public ActionResult Play(string userChoice)
        {
            // Implement game logic here
            string[] choices = { "rock", "paper", "scissors" };
            Random random = new Random();
            string computerChoice = choices[random.Next(choices.Length)];


            // Determine the winner
            string result;
            if ((userChoice == "rock" && computerChoice == "scissors") ||
                (userChoice == "paper" && computerChoice == "rock") ||
                (userChoice == "scissors" && computerChoice == "paper"))
            {
                result = "You win!";
                playerScore++;
            }
            else if ((userChoice == "rock" && computerChoice == "paper") ||
                     (userChoice == "paper" && computerChoice == "scissors") ||
                     (userChoice == "scissors" && computerChoice == "rock"))
            {
                result = "Ai wins!";
                computerScore++;
            }
            else 
            {
                result = "It's a tie!";
            }
            ViewBag.Result = result;
            ViewBag.PlayerChoice = userChoice;
            ViewBag.ComputerChoice = computerChoice;
            ViewBag.PlayerScore = playerScore;
            ViewBag.ComputerScore = computerScore;

            return View("Result");
        }
    }
}