﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TheTravelingSalesperson
{
    /// <summary>
    /// MVC Controller class
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private bool _usingApplication;

        //
        // declare ConsoleView and Salesperson objects for the Controller to use
        // Note: There is no need for a Salesperson or ConsoleView property given only the Controller 
        //       will access the ConsoleView object and will pass the Salesperson object to the ConsoleView.
        //
        private ConsoleView _consoleView;
        private Salesperson _salesperson;


        #endregion

        #region PROPERTIES


        #endregion
        
        #region CONSTRUCTORS

        public Controller()
        {
            InitializeController();

            //
            // instantiate a Salesperson object
            //
            _salesperson = new Salesperson();

            //
            // instantiate a ConsoleView object
            //
            _consoleView = new ConsoleView();

            //
            // begins running the application UI
            //
            ManageApplicationLoop();
        }

        #endregion
        
        #region METHODS

        /// <summary>
        /// initialize the controller 
        /// </summary>
        private void InitializeController()
        {
            _usingApplication = true;
        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageApplicationLoop()
        {
            MenuOption userMenuChoice;

            _consoleView.DisplayWelcomeScreen();

            //
            // setup initial salesperson account
            //

            if (_consoleView.DisplayAccountLoadOrCreate())
                _salesperson = _consoleView.DisplaySetupAccount();
            else
                _salesperson = _consoleView.DisplayLoadAccount();

            //
            // application loop
            //
            while (_usingApplication)
            {

                //
                // get a menu choice from the ConsoleView object
                //
                userMenuChoice = _consoleView.DisplayGetUserMenuChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (userMenuChoice)
                {
                    case MenuOption.None:
                        break;
                    case MenuOption.Travel:
                        Travel();
                        break;
                    case MenuOption.CheckInventory:
                        CheckInventory();
                        break;
                    case MenuOption.Buy:
                        BuyProduct();
                        break;
                    case MenuOption.Sell:
                        SellProduct();
                        break;
                    case MenuOption.ChangeAccountInformation:
                        ChangeAccountInformation();
                        break;
                    case MenuOption.DisplayCities:
                        DisplayCities();
                        break;
                    case MenuOption.DisplayAccountInfo:
                        DisplayAccountInfo();
                        break;
                    case MenuOption.Load:
                        LoadAccountInformation();
                        break;
                    case MenuOption.Save:
                        SaveAccountInformation();
                        break;
                    case MenuOption.Exit:
                        _usingApplication = false;
                        break;
                    default:
                        break;
                }
            }

            _consoleView.DisplayClosingScreen();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// add the next city location to the list of cities
        /// </summary>
        /// 
        private void SaveAccountInformation()
        {
            _consoleView.DisplaySaveSalesPerson(_salesperson);
        }

        private void LoadAccountInformation()
        {
            _salesperson = _consoleView.DisplayLoadSalesPerson();
        }
        private void ChangeAccountInformation()
        {
           _salesperson =  _consoleView.DisplayChangeAccountInformation(_salesperson);
        }
        private void Travel()
        {
            string nextCity = _consoleView.DisplayGetNextCity();

            //
            // do not add empty strings to list for city names
            //
            if (nextCity != "")
            {
                _salesperson.CitiesVisited.Add(nextCity);
            }
        }

        /// <summary>
        /// display all cities traveled to
        /// </summary>
        private void DisplayCities()
        {
            _consoleView.DisplayCitiesTraveled(_salesperson);
        }

        /// <summary>
        /// display account information
        /// </summary>
        private void DisplayAccountInfo()
        {
            _consoleView.DisplayAccountInfo(_salesperson);
        }


        private void BuyProduct()
        {
            _salesperson = _consoleView.DisplayGetBuy(_salesperson);
        }

        private void SellProduct()
        {
            _salesperson = _consoleView.DisplayGetSell(_salesperson);
        }

        private void CheckInventory()
        {
            _consoleView.DisplayCurrentInventory(_salesperson);
        }
        #endregion
    }
}
