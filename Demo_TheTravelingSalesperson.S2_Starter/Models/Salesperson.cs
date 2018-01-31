using System.Collections.Generic;
using System;
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






        #endregion

        #region PROPERTIES
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

        public static bool InstantiateProductType(Product initializedProduct, out Product finalizedProduct)
        {
            ConsoleKeyInfo userResponse = Console.ReadKey();

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

        #endregion
    }
}
