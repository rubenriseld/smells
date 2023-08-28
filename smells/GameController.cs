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


        private IUI _ui;
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
            _ui = ui;
            return this;
        }
        public void Menu()
        {
            try
            {
                if(_ui != null)
                {

                bool ShowMenu = true;
                _ui.Output("Enter your user name:");
                userName = _ui.Input();

                while (ShowMenu)
                {
                    _ui.Clear();
                    _ui.Output($"Welcome {userName}! \nChoose what to play:\n");

                    foreach (IGame game in games)
                    {
                        _ui.Output($"[{games.IndexOf(game)}] {game.Name}");
                        //\n\t[2] Second Game\n\t

                    }
                    _ui.Output("[E] Exit\n");
                    menuChoice = _ui.Input();
                    if (menuChoice.ToUpper() == "E") _ui.Exit();
                    HandleMenuChoice();
                }
                }
                else
                {
                    Console.WriteLine("No UI connected to the GameController!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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

                    _ui.Output("New game [Y]\tBack to Menu [M]");
                    menuChoice = _ui.Input();
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
