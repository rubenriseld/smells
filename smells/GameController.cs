using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smells.Interfaces;

namespace smells
{
    public class GameController : IGameController
    //meny, "Länk" till alla spel o menyval, skriver ut o läser från console mha ui
    {
        public List<IGame>? games = new List<IGame>();


        private IUI ui;
        string userName { get; set; }
        string menuChoice { get; set; }
        public GameController()
        {
            userName = "";
            menuChoice = "";
        }

        public IGameController AddGame(IGame game)
        {
            games.Add(game);
            return this;
        }
        public IGameController AddUserInterface(IUI ui)
        {
            this.ui = ui;
            return this;
        }
        public void Menu()
        {
            bool ShowMenu = true;
            ui.PrintToConsole("\tEnter your user name:\n\t");
            userName = ui.ReadFromConsole();

            while (ShowMenu)
            {
                ui.ClearConsole();
                ui.PrintToConsole($"\n\tWelcome {userName}! \n\tChoose what to play:\n");

                foreach (IGame game in games)
                {
                    ui.PrintToConsole($"\t{games.IndexOf(game)} {game.Name} [E] Exit");
                    //\n\t[2] Second Game\n\t

                }
                menuChoice = ui.ReadFromConsole();
                if (menuChoice.ToUpper() == "E") ui.ExitConsole();
                HandleMenuChoice();
            }
        }
        public void HandleMenuChoice()
        {

            bool continuePlaying = true;
            int choice = Convert.ToInt32(menuChoice);
            if (games[choice] != null)
            {
                while (continuePlaying)
                {
                    games[choice].RunGame(userName);

                    ui.PrintToConsole("New game [y]\tBack to Menu [M]");
                    menuChoice = ui.ReadFromConsole();
                    if (menuChoice.ToUpper() == "M") continuePlaying = false;
                }
            }
            else
            {
                continuePlaying = false;
            }

        }

    }
}
