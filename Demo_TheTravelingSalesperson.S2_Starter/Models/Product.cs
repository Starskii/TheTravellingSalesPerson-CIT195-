using System.Collections.Generic;


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

        private ProductType _typeOfProduct;
        private int _amountOfProduct;

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
    }
}
