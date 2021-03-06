using Xunit;
using System;


namespace P1StoreApp.Tests
{
    public class UnitTest1
    {

        // [Fact]
        // public void StringToUpperReturnsAllUpperCase()
        // {
        //     //Arrange
        //     string s1 = "This is a test";

        //     //Act
        //     string result = Program.StringToUpper(s1);
        //     string expected = "THIS IS A TEST";

        //     //Assert
        //     Assert.Equal(expected, result);
        // }
        
        // [Fact]

        // public void AddOneItemToCart() //---------------In a world that makes sense to me, this test would check if I successfully put an item in the cart and also check the price of the cart
        // {
        //     // //Arrange
        //     // Program.howMany = "1";

        //     // //Act
        //     // Program.enterStore(1, "add", "1", 0, 0);
            


        //     // //Assert
        //     // Assert.Equal(Convert.ToString(8.99), Convert.ToString(Program.totalMoney));
        //     // Assert.Equal(1, Program.numberOfItems);
        //     // Assert.Equal(1, carts.Count);

        // }

        [Fact]
        public void checkProducts()
        {
            Assert.Equal("Henry\'s Signature Sauce", Program.getProducts()[1].p_name);
        }
        [Fact]
        public void checkProducts2()
        {
            Assert.Equal("Henry-Q Sauce", Program.getProducts()[5].p_name);
        }
        [Fact]
        public void checkProducts3()
        {
            Assert.Equal("Mild", Program.getProducts()[5].intensity);
        }
        // public void checkProducts4()
        // {
        //     Assert.Equal(9.99, Program.getProducts()[49].price);
        // }
        [Fact]
        public void checkStores()
        {
            Assert.Equal("100 Boneless Boulevard", Program.getStores()[0].s_address);
        }

        [Fact]
        public void checkStores2()
        {
            Assert.Equal("Henry\'s Hot Sauce Haven", Program.getStores()[1].s_name);
        }



        // [Fact]
        // public void AddTwoSameItemToCart()
        // {
        //     // //Arrange
        //     // howMany = 2;

        //     // //Act

            
        //     // Program.enterStore(1, "add", 1, Program.totalCostofCart, Program.numOfItemsInCart);
            


        //     // // //Assert
        //     // Assert.Equal(26.97, totalCostofCart);
        //     // Assert.Equal(3, numOfItemsInCart);
        //     // Assert.Equal(1, carts.Count);

        // }

        // [Fact]
        // public void DeleteTwoItemsFromCart()
        // {
        //     // //Arrange
        //     // Program.howMany = 2;

        //     // //Act

            
        //     // Program.enterStore(1, "delete", 1, Program.totalCostofCart, Program.numOfItemsInCart);
            


        //     // //Assert
        //     // Assert.Equal(8.99, Program.totalCostofCart);
        //     // Assert.Equal(1, Program.numOfItemsInCart);
        //     // Assert.Equal(1, Program.carts.Count);

        // }

        // [Fact]
        // public void AddTwoDiffItemsToCart()
        // {
        //     // //Arrange
        //     // Program.howMany = 2;

        //     // //Act
        //     // Program.enterStore(1, "add", 2, Program.totalCostofCart, Program.numOfItemsInCart);
            


        //     // //Assert
        //     // Assert.Equal(26.97, Program.totalCostofCart);
        //     // Assert.Equal(3, Program.numOfItemsInCart);
        //     // Assert.Equal(2, Program.carts.Count);

        // }

        // [Fact]
        // public void CheckoutThenHistory()
        // {
        //     //Arrange
        //     // Program.currentID = 1;

        //     // //Act
        //     // Program.enterStore(1, "checkout", null, Program.totalCostofCart, Program.numOfItemsInCart);
            


        //     // //Assert
        //     // Assert.Equal(0, Program.totalCostofCart);
        //     // Assert.Equal(0, Program.numOfItemsInCart);
        //     // Assert.Equal(0, Program.carts.Count);
        //     // Assert.Equal(1, Program.order_history.Count);
        //     // Assert.Equal(26.97, Program.order_history[1].total_cost);

        // }

    }
}