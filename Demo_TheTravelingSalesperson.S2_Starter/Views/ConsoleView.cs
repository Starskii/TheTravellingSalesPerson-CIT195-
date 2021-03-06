﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TheTravelingSalesperson
{
    /// <summary>
    /// MVC View class
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS
        bool goodAnswer = false;
        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView()
        {
            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize all console settings
        /// // 
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "Laughing Leaf Productions";
            ConsoleUtil.HeaderText = "The Traveling Salesperson Application";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            ConsoleUtil.DisplayMessage("");

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Thank you for using the application. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }


        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Written by Jacob Lakies");
            ConsoleUtil.DisplayMessage("Northwestern Michigan College");
            ConsoleUtil.DisplayMessage("");

            sb.Clear();
            sb.AppendFormat("You are a traveling salesperson buying and selling widgets ");
            sb.AppendFormat("around the country. You will be prompted regarding which city ");
            sb.AppendFormat("you wish to travel to and will then be asked whether you wish to buy ");
            sb.AppendFormat("or sell widgets.");
            ConsoleUtil.DisplayMessage(sb.ToString());
            ConsoleUtil.DisplayMessage("");

            sb.Clear();
            sb.AppendFormat("Your first task will be to set up your account details.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new salesperson object with the initial data
        /// Note: To maintain the pattern of only the Controller changing the data this method should
        ///       return a Salesperson object with the initial data to the controller. For simplicity in 
        ///       this demo, the ConsoleView object is allowed to access the Salesperson object's properties.
        /// </summary>
        /// 

        public Salesperson DisplayChangeAccountInformation(Salesperson SalespersonToModify)
        {

            ConsoleUtil.HeaderText = "Modify Account Information";


            bool goodAnswer = false;

            ConsoleKeyInfo Stuff;

            while (!goodAnswer)
            {
                ConsoleUtil.DisplayReset();

                ConsoleUtil.DisplayMessage("1.) First Name: " + SalespersonToModify.FirstName);
                ConsoleUtil.DisplayMessage("2.) Last Name: " + SalespersonToModify.LastName);
                ConsoleUtil.DisplayMessage("3.) ID: " + SalespersonToModify.AccountID);
                ConsoleUtil.DisplayMessage("4.) Age: " + SalespersonToModify.Age);
                ConsoleUtil.DisplayMessage("e.) Exit");
                Console.WriteLine();


                Stuff = Console.ReadKey();

                switch (Stuff.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.Write("What would you like to change the First Name value to?: ");
                        SalespersonToModify.FirstName = Console.ReadLine();
                        break;
                    case '2':
                        Console.Clear();
                        Console.Write("What would you like to change the Last Name value to?: ");
                        SalespersonToModify.LastName =  Console.ReadLine();
                        break;
                    case '3':
                        Console.Clear();
                        Console.Write("What would you like to change the ID value to?: ");
                        SalespersonToModify.AccountID = Console.ReadLine();
                        break;
                    case '4':
                        Console.Clear();
                        Console.Write("What would you like to change the Age value to?: ");
                        SalespersonToModify.AccountID = Console.ReadLine();
                        break;
                    case 'e':
                    case 'E':
                        goodAnswer = true;
                        break;
                    default:
                        break;
                }
            }


            return SalespersonToModify;
        }

        public bool DisplayAccountLoadOrCreate()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);


            ConsoleUtil.HeaderText = "Welcome";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Would you like to create a new account or load a previous one?");
            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayMessage("1.) Create a New Account");
            ConsoleUtil.DisplayMessage("2.) Load an old Account");

            ConsoleUtil.DisplayPromptMessage("Enter your Response: ");

            bool continueInputLoop = true;

            while (continueInputLoop)
            {
                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        return true;
                        //true means create new account
                    case '2':
                        return false;
                        //false means load old account
                    default:
                        break;
                }
            }
            return true;
        }

        public Salesperson DisplayLoadAccount()
        {
            Salesperson me = new Salesperson();
            return me;
        }
        public Salesperson DisplaySetupAccount()
        {
            Salesperson salesperson = new Salesperson();

            ConsoleUtil.HeaderText = "Account Setup";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Setup your account now.");
            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayPromptMessage("Enter your first name: ");
            salesperson.FirstName = Console.ReadLine();
            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayPromptMessage("Enter your last name: ");
            salesperson.LastName = Console.ReadLine();
            ConsoleUtil.DisplayMessage("");

            goodAnswer = false;

            int age = 0;

            while (!goodAnswer)
            {
                ConsoleUtil.DisplayPromptMessage("Enter your age: ");
                if (int.TryParse(Console.ReadLine(), out age))
                    goodAnswer = true;
                salesperson.Age = age;
                ConsoleUtil.DisplayMessage("");
            }

            ConsoleUtil.DisplayPromptMessage("Enter your account ID: ");
            salesperson.AccountID = Console.ReadLine();
            ConsoleUtil.DisplayMessage("");

            Product productToSell = new Product();
            do
            {
                Console.Clear();
                ConsoleUtil.HeaderText = "Product Setup";
                ConsoleUtil.DisplayReset();
                Console.WriteLine("\n");
                ConsoleUtil.DisplayPromptMessage("\nChoose your type of Product: ");
                Console.WriteLine();

                ConsoleUtil.DisplayMessage("\t 1.) Cool \n" +
                    "\t 2.) Cuddly \n " +
                    "\t 3.) Crazy \n");

                goodAnswer = Salesperson.InstantiateProductType(Console.ReadKey(), productToSell, out productToSell);
            } while (!goodAnswer);

            goodAnswer = false;

            do
            {
                Console.Clear();
                ConsoleUtil.HeaderText = "Product Setup";
                ConsoleUtil.DisplayReset();
                Console.WriteLine("\n");
                ConsoleUtil.DisplayPromptMessage("\nEnter the amount of product currently in inventory: ");
                Console.WriteLine();

                goodAnswer = Salesperson.InstantiateProductInventory(productToSell, out productToSell);

            } while (!goodAnswer);

            salesperson.ProductToSell = productToSell;

            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Your account is setup");

            DisplayContinuePrompt();
            Console.Clear();
            return salesperson;
        }

        /// <summary>
        /// display a closing screen when the user quits the application
        /// </summary>
        /// 

        public void DisplayCurrentInventory(Salesperson salesperson)
        {
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("This is your current inventory: ");
            ConsoleUtil.DisplayMessage("");

            if (salesperson.ProductToSell.AmountOfProduct < 0)
            {
                ConsoleUtil.DisplayMessage("You have backordered " + Math.Abs(salesperson.ProductToSell.AmountOfProduct) + ".");
                DisplayContinuePrompt();
            }
            else
            {
                ConsoleUtil.DisplayMessage("Current inventory of " + salesperson.ProductToSell.TypeOfProduct.ToString() + ":" + salesperson.ProductToSell.AmountOfProduct.ToString());
                DisplayContinuePrompt();
            }
        }
        public Salesperson DisplayGetBuy(Salesperson salesperson)
        {
            int amountToBuy = 0;

            do
            {
                Console.Clear();
            ConsoleUtil.DisplayMessage("How much would you like to buy?");
            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayMessage("Amount to buy: ");
            } while (!int.TryParse(Console.ReadLine(), out amountToBuy));

            salesperson.ProductToSell.AmountOfProduct += amountToBuy;

            return salesperson;
        }

        public Salesperson DisplayGetSell(Salesperson salesperson)
        {
            int amountToBuy = 0;

            do
            {
                Console.Clear();
                ConsoleUtil.DisplayMessage("How much would you like to sell?");
                ConsoleUtil.DisplayMessage("");

                ConsoleUtil.DisplayMessage("Amount to sell: ");
            } while (!int.TryParse(Console.ReadLine(), out amountToBuy));

            salesperson.ProductToSell.AmountOfProduct -= amountToBuy;

            if (salesperson.ProductToSell.AmountOfProduct <= 0)
            {
                ConsoleUtil.DisplayMessage("You have backordered " + Math.Abs(salesperson.ProductToSell.AmountOfProduct) + ".");
                DisplayContinuePrompt();
                
            }
            else
            {

            }



            return salesperson;
        }
        public void DisplayClosingScreen()
        {
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Thank you for using The Traveling Salesperson Application.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the menu choice from the user
        /// </summary>
        public MenuOption DisplayGetUserMenuChoice()
        {
            MenuOption userMenuChoice = MenuOption.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.HeaderText = "Main Menu";
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("Please type the number of your menu choice.");
                ConsoleUtil.DisplayMessage("");

                Console.Write(
                    "\t" + "1. Travel" + Environment.NewLine +
                    "\t" + "2. Display Cities" + Environment.NewLine +
                    "\t" + "3. Display Account Info" + Environment.NewLine +
                    "\t" + "4. Check Inventory" + Environment.NewLine +
                    "\t" + "5. Buy" + Environment.NewLine +
                    "\t" + "6. Sell" + Environment.NewLine +
                    "\t" + "7. Modify Account" + Environment.NewLine +
                    "\t" + "8. Load Account" + Environment.NewLine +
                    "\t" + "9. Save Account" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        userMenuChoice = MenuOption.Travel;
                        usingMenu = false;
                        break;
                    case '2':
                        userMenuChoice = MenuOption.DisplayCities;
                        usingMenu = false;
                        break;
                    case '3':
                        userMenuChoice = MenuOption.DisplayAccountInfo;
                        usingMenu = false;
                        break;
                    case '4':
                        userMenuChoice = MenuOption.CheckInventory; 
                        usingMenu = false;
                        break;
                    case '5':
                        userMenuChoice = MenuOption.Buy;
                        usingMenu = false;
                        break;
                    case '6':
                        userMenuChoice = MenuOption.Sell;
                        usingMenu = false;
                        break;
                    case '7':
                        userMenuChoice = MenuOption.ChangeAccountInformation;
                        usingMenu = false;
                        break;
                    case '8':
                        userMenuChoice = MenuOption.Load;
                        usingMenu = false;
                        break;
                    case '9':
                        userMenuChoice = MenuOption.Save;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        userMenuChoice = MenuOption.Exit;
                        usingMenu = false;
                        break;
                    default:
                        ConsoleUtil.DisplayMessage(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to quit the application.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;

            return userMenuChoice;
        }
        /// <summary>
        /// get the next city to travel to from the user
        /// </summary>
        /// <returns>string City</returns>
        public string DisplayGetNextCity()
        {
            string nextCity = "";

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Enter the name of the next city:");
            nextCity = Console.ReadLine();

            return nextCity;
        }

        /// <summary>
        /// display a list of the cities traveled
        /// </summary>
        public void DisplayCitiesTraveled(Salesperson salesperson)
        {
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("You have traveled to the following cities.");
            ConsoleUtil.DisplayMessage("");

            foreach (string city in salesperson.CitiesVisited)
            {
                ConsoleUtil.DisplayMessage(city);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current account information
        /// </summary>
        public void DisplayAccountInfo(Salesperson salesperson)
        {
            ConsoleUtil.HeaderText = "Account Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("First Name: " + salesperson.FirstName);
            ConsoleUtil.DisplayMessage("Last Name: " + salesperson.LastName);
            ConsoleUtil.DisplayMessage("Account ID: " + salesperson.AccountID);

            DisplayContinuePrompt();
        }

        public void DisplaySaveSalesPerson(Salesperson salesPersonToWrite)
        {
            Salesperson.SaveSalesPerson(salesPersonToWrite);
            Console.Clear();

            Console.WriteLine("\n\n Save successful! \n");
            DisplayContinuePrompt();
        }

        public Salesperson DisplayLoadSalesPerson()
        {
            Salesperson salesperson = new Salesperson();
            salesperson = Salesperson.LoadSalesPerson(salesperson);

            return salesperson;
        }

        #endregion

    }
}
