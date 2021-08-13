using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Test
{
    [TestClass]
    public class CartTest
    {
        static CartItem _cartItem;
        static CartManager _cartManager;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            //Arrange
            _cartManager = new CartManager();
            _cartItem = new CartItem
            {
                Product = new Product()
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 1500
                },
                Quantity = 1
            };
            _cartManager.Add(_cartItem);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _cartManager.Clear();
        }

        [TestMethod]
        public void AddToCart()
        {
            const int expectedProduct = 1;

            //Act
            var totalItem = _cartManager.TotalItem;

            //Assert
            Assert.AreEqual(expectedProduct, totalItem);
        }

        [TestMethod]
        public void DeletingASpecificProductFromTheCart()
        {
            var sumCartProduct = _cartManager.TotalItem;
            //Act
            _cartManager.Remove(1);
            var lastCartProduct = _cartManager.TotalItem;

            //Assert
            Assert.AreEqual(sumCartProduct - 1, lastCartProduct);
        }

        [TestMethod]
        public void RemoveFromCart()
        {
            //Act
            _cartManager.Clear();
            //Assert
            Assert.AreEqual(0, _cartManager.TotalItem);
            Assert.AreEqual(0, _cartManager.TotalQuantity);
        }

        [TestMethod]
        public void ReAIncreasesWhenIAddAnotherProduct()
        {
            //Arrange
            int totalQuantity = _cartManager.TotalQuantity;
            int totalItem = _cartManager.TotalItem;
            //Act
            _cartManager.Add(new CartItem
            {
                Product = new Product
                {
                    ProductId = 2,
                    ProductName = "Mouse",
                    UnitPrice = 200
                },
                Quantity = 1
            });
            //Assert
            Assert.AreEqual(totalQuantity + 1, _cartManager.TotalQuantity);
            Assert.AreEqual(totalItem + 1, _cartManager.TotalItem);
        }

        [TestMethod]
        public void ReAddFromTheSameProduct()
        {
            //Arrange
            int totalQuantity = _cartManager.TotalQuantity;
            int totalItem = _cartManager.TotalItem;
            //Act
            _cartManager.Add(_cartItem);
            //Assert
            Assert.AreEqual(totalQuantity + 1, _cartManager.TotalQuantity);
            Assert.AreEqual(totalItem + 1, _cartManager.TotalItem);
        }
    }
}