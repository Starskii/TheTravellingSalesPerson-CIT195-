using System.Collections.Generic;
using System;


namespace Demo_TheTravelingSalesperson
{


    public class Product
    {
        public enum ProductType  
        {
            Cool,
            Crazy,
            Cuddly
        }
        private string _nameOfProduct;
        private string _descriptionOfProduct;
        private ProductType _typeOfProduct;
        private int _amountOfProduct;

        public string NameOfProduct
        {
            get { return _nameOfProduct; }
            set { _nameOfProduct = value; }
        }

        public int AmountOfProduct
        {
            get { return _amountOfProduct; }
            set { _amountOfProduct = value; }
        }

        public ProductType TypeOfProduct
        {
            get { return _typeOfProduct; }
            set { _typeOfProduct = value; }
        }

        public string DescriptionOfProduct
        {
            get { return _descriptionOfProduct; }
            set { _descriptionOfProduct = value; }
        }


        public Product()
        {

        }


        static void AddToProductQuantity(Product productModified, int amountToAdd)
        {
            productModified._amountOfProduct += amountToAdd;
        }

        static void RemoveToProductQuantity(Product productModified, int amountToRemove)
        {
            productModified._amountOfProduct -= amountToRemove;
        }

        public static ProductType StringToProductType(string stuff)
        {
            ProductType ParsedSliz = 0;
            Enum.TryParse<ProductType>(stuff, out ParsedSliz);
            return ParsedSliz;
        }
    }
}
