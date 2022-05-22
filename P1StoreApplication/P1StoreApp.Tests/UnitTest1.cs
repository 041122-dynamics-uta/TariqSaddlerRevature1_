using Xunit;



namespace P1StoreApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddOneItemToCart()
        {
            //Arrange
            string[] arguments = new string[] {"login", "Tarizzle", "1and2and3and4", "shop", "1", "add 1", "1", "checkout", "log out", "quit"};

            //Act
            //Program.Main(arguments);
            


            //Assert
            // P1OH_RepoClass orderHistory_rc = new P1OH_RepoClass();
            // P1OH_BusinessClass orderHistory_bc = new P1OH_BusinessClass(orderHistory_rc);
            // List<P1OH_ModelsClass> orders = orderHistory_bc.OrdersList();
            // Assert.Equal(1, orders.Count);

        }

        [Fact]
        public void AddTwoSameItemToCart()
        {
            // //Arrange
            // Program.howMany = 2;

            // //Act

            
            // Program.enterStore(1, "add", 1, Program.totalCostofCart, Program.numOfItemsInCart);
            


            // //Assert
            // Assert.Equal(26.97, Program.totalCostofCart);
            // Assert.Equal(3, Program.numOfItemsInCart);
            // Assert.Equal(1, Program.carts.Count);

        }

        [Fact]
        public void DeleteTwoItemsFromCart()
        {
            // //Arrange
            // Program.howMany = 2;

            // //Act

            
            // Program.enterStore(1, "delete", 1, Program.totalCostofCart, Program.numOfItemsInCart);
            


            // //Assert
            // Assert.Equal(8.99, Program.totalCostofCart);
            // Assert.Equal(1, Program.numOfItemsInCart);
            // Assert.Equal(1, Program.carts.Count);

        }

        [Fact]
        public void AddTwoDiffItemsToCart()
        {
            // //Arrange
            // Program.howMany = 2;

            // //Act
            // Program.enterStore(1, "add", 2, Program.totalCostofCart, Program.numOfItemsInCart);
            


            // //Assert
            // Assert.Equal(26.97, Program.totalCostofCart);
            // Assert.Equal(3, Program.numOfItemsInCart);
            // Assert.Equal(2, Program.carts.Count);

        }

        [Fact]
        public void CheckoutThenHistory()
        {
            //Arrange
            // Program.currentID = 1;

            // //Act
            // Program.enterStore(1, "checkout", null, Program.totalCostofCart, Program.numOfItemsInCart);
            


            // //Assert
            // Assert.Equal(0, Program.totalCostofCart);
            // Assert.Equal(0, Program.numOfItemsInCart);
            // Assert.Equal(0, Program.carts.Count);
            // Assert.Equal(1, Program.order_history.Count);
            // Assert.Equal(26.97, Program.order_history[1].total_cost);

        }

    }
}