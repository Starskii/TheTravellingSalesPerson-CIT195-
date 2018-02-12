using System.Collections.Generic;
using System;
using System.IO;

namespace Demo_TheTravelingSalesperson
{
    /// <summary>
    /// Salesperson MVC Model class
    /// </summary>
    public class Salesperson
    {
        #region FIELDS

        private string _firstName;
        private string _lastName;
        private string _accountID;
        private List<string> _citiesVisited;
        private Product _productToSell;
        private bool _isOnBackOrder;
        private int _age;

        #endregion

        #region PROPERTIES

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public bool IsOnBackOrder
        {
            get { return _isOnBackOrder; }
            set { _isOnBackOrder = value; }
        }

        public Product ProductToSell
        {
            get { return _productToSell; }
            set { _productToSell = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string AccountID
        {
            get { return _accountID; }
            set { _accountID = value; }
        }
      
        public List<string> CitiesVisited
        {
            get { return _citiesVisited; }
            set { _citiesVisited = value; }
        }

        #endregion
        
        #region CONSTRUCTORS

        public Salesperson()
        {
            _citiesVisited = new List<string>();
            _productToSell = new Product();
        }

        public Salesperson(string firstName, string lastName, string acountID)
        {
            _firstName = firstName;
            _lastName = lastName;
            _accountID = acountID;
            _productToSell = new Product();

            _citiesVisited = new List<string>();
        }

        #endregion

        #region METHODS

        public static bool InstantiateProductType(ConsoleKeyInfo userResponse, Product initializedProduct, out Product finalizedProduct)
        {
            

            switch (userResponse.KeyChar)
            {
                case '1':
                    initializedProduct.TypeOfProduct = Product.ProductType.Cool;
                    break;
                case '2':
                    initializedProduct.TypeOfProduct = Product.ProductType.Cuddly;
                    break;
                case '3':
                    initializedProduct.TypeOfProduct = Product.ProductType.Crazy;
                    break;
                default:
                    finalizedProduct = initializedProduct;
                    return false;
            }

            finalizedProduct = initializedProduct;
            return true;
        }

        public static bool InstantiateProductInventory(Product productToInstantiate, out Product instantiatedProduct)
        {
            int productAmount = 0;
            bool succesfulParse = false;

            succesfulParse = int.TryParse(Console.ReadLine(), out productAmount);
            productToInstantiate.AmountOfProduct = productAmount;
            instantiatedProduct = productToInstantiate;

            return succesfulParse; 
        }

        public static Salesperson LoadSalesPerson(Salesperson salesperson)
        {
            StreamReader LoadSave = new StreamReader("data.csv");

            string mySalesPersonData = "";

            using (LoadSave)
            {
                mySalesPersonData = LoadSave.ReadLine();
            }

            string[] SalesPersonData = mySalesPersonData.Split(',');

            salesperson.FirstName = SalesPersonData[0];
            salesperson.LastName = SalesPersonData[1];
            salesperson.AccountID = SalesPersonData[2];
            salesperson.ProductToSell.TypeOfProduct = Product.StringToProductType(SalesPersonData[3]);
            salesperson.ProductToSell.AmountOfProduct = int.Parse(SalesPersonData[4]);

            return salesperson;
        }

        public static bool SaveSalesPerson(Salesperson salesperson)
        {
            StreamWriter SaveSalesPerson = new StreamWriter("data.csv");
            string saveData = "";

            saveData = (salesperson.FirstName) + "," +
            (salesperson.LastName) + "," +
            (salesperson.AccountID) + "," +
            (salesperson.ProductToSell.TypeOfProduct.ToString()) + "," +
            (salesperson.ProductToSell.AmountOfProduct);

            using (SaveSalesPerson)
            {
                SaveSalesPerson.Write(saveData);
            }

                return true;
        }
        #endregion
    }
}
