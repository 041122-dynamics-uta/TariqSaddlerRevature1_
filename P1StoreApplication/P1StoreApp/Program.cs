using System;
using System.Collections.Generic;
using P1Models;
using P1Business;
using P1Repository;
using System.Data.SqlClient;

namespace P1StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {

            
            
            // Console.WriteLine("Hello World!");

            // Console.WriteLine("Wanna see a list of all members?");

            // string ans = Console.ReadLine();

            P1RepoClass rc = new P1RepoClass();//creates an instance of the repo class
            P1BusinessClass bc = new P1BusinessClass(rc);//creates an instance of the business class that takes an instance the repo class as an argument.
            List<P1ModelsClass> products = bc.ProductsList();

            P1S_RepoClass store_rc = new P1S_RepoClass();
            P1S_BusinessClass stores_bc = new P1S_BusinessClass(store_rc);
            List<P1S_ModelsClass> stores = stores_bc.StoresList();
            

            P1C_RepoClass customer_rc = new P1C_RepoClass();
            P1C_BusinessClass customer_bc = new P1C_BusinessClass(customer_rc);
            List<P1C_ModelsClass> customers = customer_bc.CustomersList();

            P1SC_RepoClass shoppingCart_rc = new P1SC_RepoClass();
            P1SC_BusinessClass shoppingCart_bc = new P1SC_BusinessClass(shoppingCart_rc);
            List<P1SC_ModelsClass> cart = shoppingCart_bc.ShoppingList();

            P1OH_RepoClass orderHistory_rc = new P1OH_RepoClass();
            P1OH_BusinessClass orderHistory_bc = new P1OH_BusinessClass(orderHistory_rc);
            List<P1OH_ModelsClass> orders = orderHistory_bc.OrdersList();

                //FORMAT
                //(login credentials)
            int currentID = 0;
            if(customers.Count < 1)
            {
                register();
            }

            void loginOrRegisterHere()
            {
                Console.WriteLine("Login or Register? (Or quit, see if I care.)");
                string loginOrRegister = Console.ReadLine();
                if(loginOrRegister == "login" || loginOrRegister == "log in" || loginOrRegister == "log")
                {
                    login();
                }
                else if(loginOrRegister == "register")
                {
                    register();
                }
                else if(loginOrRegister == "quit")
                {
                    Console.WriteLine("So that's it? No, no, it's fine. Bye.");
                    System.Environment.Exit(0);
                }
                
                void login()
                {
                    string loginUN = "";
                    string loginPW = "";
                    bool validLogin = false;
                    Console.WriteLine("Please enter your Username");
                    loginUN = Console.ReadLine();
                    Console.WriteLine("Please enter your PW");
                    loginPW = Console.ReadLine();
                    for(int i = 0; i<customers.Count; i++)
                    {
                        if(customers[i].username == loginUN)
                        {
                            if(customers[i].user_pw == loginPW)
                            {
                                validLogin = true;
                                currentID = customers[i].CustomerID;
                                
                            }
                        }
                    }
                    if(validLogin == false)
                    {
                        Console.WriteLine("INVALID LOGIN CREDENTIALS");
                        loginOrRegisterHere();
                    }
                    viewOrShop();
                    
                }
            }    




            //register();
            void register()
            {
                string nameOfUser = "";
                string userNameInput = "";
                string pw = "";
                string email = "";
                Console.WriteLine("New user, please enter your name: <FirstName> <LastName>");
                nameOfUser = Console.ReadLine();
                while(nameOfUser.Length < 1)
                {
                    Console.WriteLine("Name of user must be at least 1 character.");
                    nameOfUser = Console.ReadLine(); 
                }
               


                Console.WriteLine("User Name:");
                userNameInput = Console.ReadLine();
                List<P1C_ModelsClass> customers = customer_bc.CustomersList();
                for(int i = 0; i<customers.Count; i++)
                {
                    if(customers[i].username == userNameInput)
                    {
                        i = 0;
                        Console.WriteLine("That user name already exists, try a different one:");
                        userNameInput = Console.ReadLine(); 
                    }
                    if(userNameInput.Length < 5)
                    {
                        i = 0;
                        Console.WriteLine("Username must be at least 5 characters.");
                        userNameInput = Console.ReadLine(); 
                        
                    }
                }

                Console.WriteLine("Password: ");
                pw = Console.ReadLine();
                while(pw.Length < 5)
                {
                    Console.WriteLine("Password must be at least 5 characters.");
                    pw = Console.ReadLine(); 
                }

                Console.WriteLine("Email Address: ");
                email = Console.ReadLine();
                bool validEmail = false;
                for(int i = 0; i<customers.Count || customers.Count == 0; i++)
                {
                    if(customers.Count != 0)
                    {
                        if(customers[i].user_email == email)
                        {
                            i = 0;
                            Console.WriteLine("That Email already exists, try a different one:");
                            userNameInput = Console.ReadLine(); 
                        }
                    }
                    if(validEmail == false)
                    {
                        for(int x = 0; x<email.Length; x++)
                        {
                            if(email[x] == '@')
                            {
                                validEmail = true;
                                break;
                            }
                            
                        }
                        if(validEmail == false)
                        {
                            i = 0;
                            Console.WriteLine("Make sure you input the proper format for an email: name@example.com");
                            email = Console.ReadLine(); 
                        }
                    }
                    if(customers.Count == 0)
                    {
                        break;
                    }
                    Console.WriteLine("Good to go!");
                    loginOrRegisterHere();
                }
                string connectionString = "Server=tcp:tariqsaddlerserver.database.windows.net,1433;Initial Catalog=P1Store;Persist Security Info=False;User ID=TariqSaddlerDB;Password=One23Four%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                string myCustomerQuery = $"INSERT INTO CustomerInfo (name_of_user, username, user_pw, user_email) VALUES ('{nameOfUser}', '{userNameInput}', '{pw}', '{email}');";

                using (SqlConnection customerQuery = new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand(myCustomerQuery, customerQuery);
                    customerQuery.Open();
                    SqlDataReader results9 = command.ExecuteReader();
                    customerQuery.Close();
                        
                }
                for(int i = 0; i<customers.Count; i++)
                {
                    if(customers[i].username == userNameInput)
                    {
                        currentID = customers[i].CustomerID;  
                    }
                }
                
            viewOrShop();
            }
            void viewOrShop()
            {

                Console.WriteLine("You wanna view the selection in all the stores? Or just start shopping at one?");
                Console.WriteLine("Type 'view' or 'shop.");
                string shopOrView = Console.ReadLine();
                if (shopOrView == "view" || shopOrView == "see" || shopOrView == "browse")
                {
                    viewProducts(0);
                }
                else if(shopOrView == "shop" || shopOrView == "shopping" || shopOrView == "s")
                {
                    shopProducts();
                }
            }
                //IF VIEW:
                //Prompt user to write specifications: "What attribute would you like to filter?"
                //Intensity, Price, Name, etc...
                //Type 'search' or '' to commence the search
                //Reprompt for more filters
                //Once search commences, initialize a list of all the products
                //Go through functions corresponding to filters, every filter returns that list minus the products that didn't match
                //Once that's done, for loop print each product on the list and their attributes
                //Reprompt: Shop or view?
            

            void viewProducts(int currentStore)
            {
                var viewList = new List<Object>();
                bool validListEntry = true;
                int x = 0;
                string intensityView = "";
                string nameView = "";
                decimal priceView = 0;
                int inventoryView = 0;
                decimal cartTotal = 0;
                int totalItems = 0;
                
                
                List<string> intensityViewList = new List<string>();
                List<string> nameViewList = new List<string>();
                List<decimal> priceViewList = new List<decimal>();
                List<int> inventoryViewList = new List<int>();



                Console.WriteLine("Please specify your search criteria by typing 'name', 'intensity', 'price', or 'inventory'");
                string viewCriteria = Console.ReadLine();
                while(viewCriteria != "search" && viewCriteria != "view")
                {
                    if(viewCriteria == "intensity")
                    {
                        validListEntry = true;
                        Console.WriteLine("How hot??");
                        intensityView = Console.ReadLine();
                        do
                        {
                            if(intensityViewList.Count > 0)
                            {
                                if(intensityViewList.Contains(intensityView))
                                {
                                    validListEntry = false;
                                }
                                
                            }
                            x++;
                        }while (x<intensityViewList.Count);
                        if(validListEntry)
                        {
                            intensityViewList.Add(intensityView);
                            validListEntry = false;
                        }

                    }
                    


                    else if(viewCriteria == "name")
                    {
                        validListEntry = true;
                        Console.WriteLine("What's the name of the product?");
                        nameView = Console.ReadLine();
                        
                            if(nameViewList.Count > 0)
                            {
                                if(nameViewList.Contains(nameView))
                                {
                                    validListEntry = false;
                                }
                                
                            }
                        if(validListEntry)
                        {
                            nameViewList.Add(nameView);
                            validListEntry = false;
                        }

                    }
                    


                    else if(viewCriteria == "price")
                    {
                        validListEntry = true;
                        Console.WriteLine("What price?");
                        priceView = Convert.ToDecimal(Console.ReadLine());
                        
                            if(priceViewList.Count > 0)
                            {
                                if(priceViewList.Contains(priceView))
                                {
                                    validListEntry = false;
                                }
                                
                            }
                        if(validListEntry)
                        {
                            priceViewList.Add(priceView);
                            validListEntry = false;
                        }

                    }
                    


                    else if(viewCriteria == "inventory")
                    {
                        validListEntry = true;
                        Console.WriteLine("How much should be in stock");
                        inventoryView = Convert.ToInt32(Console.ReadLine());
                        
                            if(inventoryViewList.Count > 0)
                            {
                                if(inventoryViewList.Contains(inventoryView))
                                {
                                    validListEntry = false;
                                }
                                
                            }
                        if(validListEntry)
                        {
                            inventoryViewList.Add(inventoryView);
                            validListEntry = false;
                        }
                        

                    }
                    else
                    {
                        Console.WriteLine("INVALID CATEGORY");
                    }
                    Console.WriteLine("Please specify your search criteria by typing 'name', 'intensity', 'price', or 'inventory'");
                    Console.WriteLine("You may type 'search' to confirm your search criteria and print the list");
                    viewCriteria = Console.ReadLine();
                        
                }
                bool validItem = false;
                //int finalCount = inventoryViewList.Count + nameViewList.Count + priceViewList.Count + intensityViewList.Count;
                for(int j = 0; j<products.Count; j++)
                {
                    validItem = true;
                    if(intensityViewList.Count > 0 && validItem == true)
                    {
                        for(int a = 0; a<intensityViewList.Count; a++)
                        {
                            if(products[j].intensity == intensityViewList[a])
                            {
                                validItem = true;
                                a += intensityViewList.Count;
                            }
                            else
                            {
                                validItem = false;
                            }
                        }
                    }
                        
                    if(nameViewList.Count > 0 && validItem == true)
                    {
                        for(int b = 0; b<nameViewList.Count; b++)
                        {
                            if(products[j].p_name == nameViewList[b])
                            {
                                validItem = true;
                                b += nameViewList.Count;
                            }
                            else
                            {
                                validItem = false;
                            }
                        }
                    }
                    if(priceViewList.Count > 0 && validItem == true)
                    {
                        for(int c = 0; c<priceViewList.Count; c++)
                        {
                            if(products[j].price == priceViewList[c])
                            {
                                validItem = true;
                                c += priceViewList.Count;
                            }
                            else
                            {
                                validItem = false;
                            }
                            
                        }
                    }
                    if(inventoryViewList.Count > 0 && validItem == true)
                    {
                        for(int d = 0; d<inventoryViewList.Count; d++)
                        {
                            if(products[j].inventory == inventoryViewList[d])
                            {
                                validItem = true;
                                d += inventoryViewList.Count;
                            }
                            else
                            {
                                validItem = false;
                            }
                        }
                    }
                    if(currentStore > 0 && validItem == true)
                    {
                        for(int e = 0; e<stores.Count; e++)
                        {
                            if(products[j].fk_StoreID == currentStore)
                            {
                                validItem = true;
                                e += stores.Count;
                            }
                            else
                            {
                                validItem = false;
                            }
                        }
                    }
                    if(validItem)
                    {
                        Console.WriteLine($"This member is the PRODUCT ID: {products[j].ProductID}, NAME: {products[j].p_name}, INTENSITY: {products[j].intensity}");//and so on
                        Console.WriteLine($"PRICE: {products[j].price}, INVENTORY: {products[j].inventory}, STORE ID: {products[j].fk_StoreID}");//and so on
                        Console.WriteLine($"DESCRIPTION: {products[j].details}");
                    }

                   
                }
                if(currentStore > 0)
                {
                    startShop(currentStore, cartTotal, totalItems);
                }
                else
                {
                    viewOrShop(); 
                }
            }

            void shopProducts()
            {

                //IF SHOP: (while answer != exit, escape, or quit)(Must confirm quit. If customer quits, truncate cart, and go to store view)
                //Prompt which store, 1, 2, 3 (or input the address)
                //To add to shopping cart, type "add <ProductID>" then prompt how many, then add it to the cart (use separator character)
                //Loop through cart to make sure ProductID doesn't match [CartSlotID, fk_ProductID, quantity] if it does, add to qty
                //To remove items from cart, type "remove <CartSlotID> <quantity>" Qty is optional, default will prompt for qty 
                //To empty cart, type "empty" to truncate Cart table
                //"View" options are available for this store
                //To view cart, type "cart", a function will print the cart object list's contents
                //Type "checkout" to purchase the items in cart, confirm (and show the total price of cart):
                //add object list to OrderHistory [OrderID, fk_StoreID, fk_CustomerID, Cost], then truncate cart
                //Exit the shop, reprompt: Shop or view?
                decimal cartTotal = 0;
                int totalItems = 0;
                Console.WriteLine("Which store would you like to enter?");
                Console.WriteLine("Please select the store by number");
                for(int i = 0; i<stores.Count; i++)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------");
                    Console.WriteLine($"Store number {stores[i].StoreID}, {stores[i].s_name} at {stores[i].s_address}");
                }
                Console.WriteLine("-----------------------------------------------------------------------------");

                int storePick = Convert.ToInt32(Console.ReadLine());
                if(storePick > stores.Count || storePick < 1)
                {
                    shopProducts();
                }
                else
                {
                    startShop(storePick, cartTotal, totalItems);
                }
            }
            void startShop(int storeSelection, decimal cartTotalCost, int totalItemsCart)
            {   Console.WriteLine("---------------------------------------------------"); 
                Console.WriteLine("What'll you have?");
                Console.WriteLine("Type 'help' if you don't know how to shop.");

                string action = Console.ReadLine();

                string[] actionFormat = action.Split(' ');
                
                string verb = actionFormat[0];
                string dObject = "";
                if(action == "help")
                {
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine($"Try 'add <ProductID>' to place that product in your cart, 'view' to browse what we got, and 'checkout' to purchase what's in your cart");
                    Console.WriteLine("Or you can 'log out'");
                    startShop(storeSelection, cartTotalCost, totalItemsCart);
                }
                
                else if(actionFormat.Length < 2)
                {
                    Console.WriteLine($"{verb} what exactly? (try typing a ProductID number)(press enter if you have no specifications)");
                    dObject = Console.ReadLine();
                }
                else if(action == "log out")
                {
                    loginOrRegisterHere();
                }
                else
                {
                    dObject = actionFormat[1];
                }

                switch(storeSelection)
                {
                    case 1:
                        enterStore1(verb, dObject, cartTotalCost, totalItemsCart);
                    break;

                    case 2:
                        enterStore2(verb, dObject, cartTotalCost, totalItemsCart);
                    break;

                    case 3:
                        enterStore3(verb, dObject, cartTotalCost, totalItemsCart);
                    break;
                }

                
            }
            

            void enterStore1(string act, string dObj, decimal totalCostofCart, int numOfItemsInCart)
            {
                if(act == "view")
                {
                    viewProducts(1);
                }
                
                
                else if(act == "add")
                {
                    

                    Console.WriteLine($"How many {products[Convert.ToInt32(dObj)].p_name}s do you want? (Type 'cancel' to cancel.)");
                    string howMany = Console.ReadLine();

                    if(howMany == "cancel" || howMany == "wait go back" || howMany == "escape")
                    {
                        startShop(products[Convert.ToInt32(dObj)].fk_StoreID, totalCostofCart, numOfItemsInCart);
                    }
                    else if(Convert.ToInt32(howMany) > products[Convert.ToInt32(dObj)].inventory)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("We ain't got that much of that item!");
                        enterStore1(act, dObj, totalCostofCart, numOfItemsInCart);
                    }
                    else if(Convert.ToInt32(howMany) + totalCostofCart > 500)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Your order can't exceed 500 bucks. I wish it could!");
                        enterStore1(act, dObj, totalCostofCart, numOfItemsInCart);
                    }
                    else if(Convert.ToInt32(howMany) + numOfItemsInCart > 50)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("You can't exceed 50 items in your cart!");
                    }
                    else
                    {
                        int i = 0;
                        int cartSlot = 0;
                        bool alreadyInCart = false;
                        
                        do
                        {
                            if(cart.Count > 0)
                            {
                                if(Convert.ToInt32(dObj) == cart[i].fk_ProductID)
                                {
                                    alreadyInCart = true;
                                    cartSlot = i;
                                }
                                i++;
                            }
                        }while(i<cart.Count);
                        if(alreadyInCart)
                        {
                            for(int x = 0; x<cart.Count; x++)
                            {
                                totalCostofCart += products[cart[x].fk_ProductID].price;
                            }
                            numOfItemsInCart += Convert.ToInt32(howMany);

                            string connectionString = "Server=tcp:tariqsaddlerserver.database.windows.net,1433;Initial Catalog=P1Store;Persist Security Info=False;User ID=TariqSaddlerDB;Password=One23Four%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                            string myCartQuery = $"UPDATE shopping_cart SET quantity_in_cart = quantity_in_cart + {Convert.ToInt32(howMany)} WHERE CartSlotID = {cartSlot};";
                            string myCartQuery2 = $"UPDATE products SET inventory = inventory - {Convert.ToInt32(howMany)} WHERE ProductID = {Convert.ToInt32(dObj)};";

                            using (SqlConnection cartQuery = new SqlConnection(connectionString))
                            {

                                SqlCommand command = new SqlCommand(myCartQuery, cartQuery);
                                cartQuery.Open();
                                SqlDataReader results9 = command.ExecuteReader();
                                cartQuery.Close();
                                    
                            }
                            using (SqlConnection cartQuery2 = new SqlConnection(connectionString))
                            {

                                SqlCommand command = new SqlCommand(myCartQuery2, cartQuery2);
                                cartQuery2.Open();
                                SqlDataReader results8 = command.ExecuteReader();
                                cartQuery2.Close();
                                    
                            }
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine($"{howMany} of those, comin' right up! Into your cart!");
                        }
                        else
                        {
                            for(int x = 0; x<cart.Count; x++)
                            {
                                totalCostofCart += products[cart[x].fk_ProductID].price;
                            }
                            numOfItemsInCart += Convert.ToInt32(howMany);

                            string connectionString = "Server=tcp:tariqsaddlerserver.database.windows.net,1433;Initial Catalog=P1Store;Persist Security Info=False;User ID=TariqSaddlerDB;Password=One23Four%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                            string myCartQuery = $"INSERT INTO shopping_cart (fk_ProductID, quantity_in_cart) VALUES ({Convert.ToInt32(dObj)}, {Convert.ToInt32(howMany)});";
                            string myCartQuery2 = $"UPDATE products SET inventory = inventory - {Convert.ToInt32(howMany)} WHERE ProductID = {Convert.ToInt32(dObj)};";                            

                            using (SqlConnection cartQuery = new SqlConnection(connectionString))
                            {

                                SqlCommand command = new SqlCommand(myCartQuery, cartQuery);
                                cartQuery.Open();
                                SqlDataReader results9 = command.ExecuteReader();
                                cartQuery.Close();
                                    
                            }
                            using (SqlConnection cartQuery2 = new SqlConnection(connectionString))
                            {

                                SqlCommand command = new SqlCommand(myCartQuery2, cartQuery2);
                                cartQuery2.Open();
                                SqlDataReader results8 = command.ExecuteReader();
                                cartQuery2.Close();
                                    
                            }
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine($"{howMany} of those, comin' in hot!");

                        }
                    }
                    startShop(1, totalCostofCart, numOfItemsInCart);
                }

                else if(act == "checkout")
                {
                    //should be a condition to check if the cart is empty
                    string connectionString = "Server=tcp:tariqsaddlerserver.database.windows.net,1433;Initial Catalog=P1Store;Persist Security Info=False;User ID=TariqSaddlerDB;Password=One23Four%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                    string myCartQuery = $"INSERT INTO order_history (fk_StoreID, fk_CustomerID, total_cost) VALUES (1, {currentID}, {totalCostofCart});";    
                    string myCartQuery2 = $"TRUNCATE TABLE shopping_cart;";                        

                    using (SqlConnection cartQuery = new SqlConnection(connectionString))
                    {

                        SqlCommand command = new SqlCommand(myCartQuery, cartQuery);
                        cartQuery.Open();
                        SqlDataReader results9 = command.ExecuteReader();
                        cartQuery.Close();
                                    
                    }
                    using (SqlConnection cartQuery2 = new SqlConnection(connectionString))
                    {

                        SqlCommand command = new SqlCommand(myCartQuery2, cartQuery2);
                        cartQuery2.Open();
                        SqlDataReader results8 = command.ExecuteReader();
                        cartQuery2.Close();
                                    
                    }
                    numOfItemsInCart = 0;
                    totalCostofCart = 0;
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("BOOM! It's all yours, pal! Thank for your service!");
                    startShop(1, totalCostofCart, numOfItemsInCart);

                }
                else if(act == "cart")
                {
                    //view what's in your cart
                    List<P1SC_ModelsClass> cart = shoppingCart_bc.ShoppingList();
                    foreach(P1SC_ModelsClass c in cart)
                    {
                        Console.WriteLine($"You have - {c.quantity_in_cart} of product {c.fk_ProductID}, that is {products[c.fk_ProductID].p_name} ");
                    }
                    startShop(1, totalCostofCart, numOfItemsInCart);
                }
                else if(act == "wipe")
                {
                    //truncate the shopping cart
                    startShop(1, totalCostofCart, numOfItemsInCart);
                }
                else if(act == "history")
                {
                    List<P1OH_ModelsClass> orders = orderHistory_bc.OrdersList();
                    foreach(P1OH_ModelsClass o in orders)
                    {
                        Console.WriteLine($"From Store {o.fk_StoreID} Customer number {o.fk_CustomerID}, named {customers[o.fk_CustomerID].name_of_user} ordered $ {o.total_cost}");
                    }
                    startShop(1, totalCostofCart, numOfItemsInCart);
                }
                else
                {
                    //invalid input
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"That's an INVALID INPUT pal, work with me here!.");
                    startShop(1, totalCostofCart, numOfItemsInCart);
                }

            }
            void enterStore2(string act, string dObj, decimal totalCostofCart, int numOfItemsInCart)
            {
                //simply paste from the previous store and change variables
            }
            void enterStore3(string act, string dObj, decimal totalCostofCart, int numOfItemsInCart)
            {
                //simply paste from the previous store and change variables
            }


                //PLAYING AROUND
                //---------------------------------------------------------------------------
                // Console.WriteLine("Please specify your search criteria by typing 'name', 'intensity', 'price', or 'inventory'");
                // string viewCriteria = Console.ReadLine();
                // while(viewCriteria != "search" && viewCriteria != "view")
                // {
                //     if(viewCriteria == "intensity")
                //     {
                //         Console.WriteLine("How hot??");
                //         intensityView = Console.ReadLine();
                //         for(int i = 0; i<products.Count; i++)
                //         {
                //             if(products[i].intensity == intensityView)
                //             {
                //                 validListEntry = true;
                                
                //                 do
                //                 {
                //                     if(viewList.Count > 0)
                //                     {
                //                         if(viewList[x] == products[i])
                //                         {
                //                             validListEntry = false;
                //                         }
                //                     }
                //                     x++;
                //                 }while(x<viewList.Count);
                                
                //             }
                //             if(validListEntry)
                //             {
                //                 viewList.Add(products[i]);
                //                 validListEntry = false;
                //             }
                //             Console.WriteLine("Please specify your search criteria by typing 'name', 'intensity', 'price', or 'inventory'");
                //             viewCriteria = Console.ReadLine();
                //         }

                //     }
                //     if(viewCriteria == "name")
                //     {
                //         Console.WriteLine("Name of the product?");
                //         nameView = Console.ReadLine();
                //         for(int i = 0; i<products.Count; i++)
                //         {
                //             if(products[i].p_name == nameView)
                //             {
                //                 validListEntry = true;
                                
                                
                //                 if(viewList.Contains(products[i]))
                //                 {
                //                     validListEntry = false;
                //                 }   
                //             }
                //             if(validListEntry)
                //             {
                //                 viewList.Add(products[i]);
                //                 validListEntry = false;
                //             } 
                            
                //         }
                //         Console.WriteLine("Please specify your search criteria by typing 'name', 'intensity', 'price', or 'inventory'");
                //         viewCriteria = Console.ReadLine();

                //     }
                // }


            

                //Welcome the user (back)


                //Ask user if they want to enter store 1,2,3 or view the products

                //IF VIEW:
                //Prompt user to write specifications: "What attribute would you like to filter?"
                //Intensity, Price, Name, etc...
                //Type 'search' or '' to commence the search
                //Reprompt for more filters
                //Once search commences, initialize a list of all the products
                //Go through functions corresponding to filters, every filter returns that list minus the products that didn't match
                //Once that's done, for loop print each product on the list and their attributes
                //Reprompt: Shop or view?

                //IF SHOP: (while answer != exit, escape, or quit)(Must confirm quit. If customer quits, truncate cart, and go to store view)
                //Prompt which store, 1, 2, 3 (or input the address)
                //To add to shopping cart, type "add <ProductID>" then prompt how many, then add it to the cart (use separator character)
                //Loop through cart to make sure ProductID doesn't match [CartSlotID, fk_ProductID, quantity] if it does, add to qty
                //To remove items from cart, type "remove <CartSlotID> <quantity>" Qty is optional, default will prompt for qty 
                //To empty cart, type "empty" to truncate Cart table
                //"View" options are available for this store
                //To view cart, type "cart", a function will print the cart object list's contents
                //Type "checkout" to purchase the items in cart, confirm (and show the total price of cart):
                //add object list to OrderHistory [OrderID, fk_StoreID, fk_CustomerID, Cost], then truncate cart
                //Exit the shop, reprompt: Shop or view?

            

            // if(ans.CompareTo("yes") == 0)
            // {
            //     //Create the member class
            //     //List<P1S_ModelsClass> stores = stores_bc.StoresList();

            //     foreach(P1S_ModelsClass s in stores)
            //     {
            //         Console.WriteLine($"This member is the STORE ID - {s.StoreID}, STORE NAME-{s.s_name}, ADDRESS - {s.s_address} ");
            //     }


            //     //List<P1ModelsClass> products = bc.ProductsList();//We grab products list from business class...

            //     foreach(P1ModelsClass p in products)//p represents the row. This should access each product of the list and its attributes
            //     {
            //         Console.WriteLine($"This member is the PRODUCT ID: {p.ProductID}, NAME: {p.p_name}, INTENSITY: {p.intensity}");//and so on
            //         Console.WriteLine($"PRICE: {p.price}, INVENTORY: {p.inventory}, STORE ID: {p.fk_StoreID}");//and so on
            //         Console.WriteLine($"DESCRIPTION: {p.details}");
            //     }
            //     Console.WriteLine("WHAT U WANNA SEE ABOUT THE PRODUCTS??????");
            //     string uInput = Console.ReadLine();
            //     if(uInput == "intensity")
            //     {
            //         Console.WriteLine("HOW HOT??? (Mild, Medium, Hot, Henry Heat, Henry Hell");
            //         string uIntensity = Console.ReadLine();
            //         intensityCheck(uIntensity);
            //     }
            //     if(uInput == "name" || uInput == "product name")
            //     {
            //         Console.WriteLine("Product named what?");
            //         string uName = Console.ReadLine();
            //         nameCheck(uName);
            //     }
            //     //Console.WriteLine($"WHAT {loop} U WANNA SEE??????");
            //     //string category = Console.ReadLine();
            //     //string connectionString = "Server=tcp:tariqsaddlerserver.database.windows.net,1433;Initial Catalog=P1Store;Persist Security Info=False;User ID=TariqSaddlerDB;Password=One23Four%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //     //string myQuery3 = $"SELECT * FROM products WHERE {loop} = {category}";
            //     // string myQuery3 = $"SELECT products FROM {loop} = {loop} + 1 WHERE ProductID = 1";

            //     // Console.WriteLine("WANNA INCREMENT???");
            //     // string loop = Console.ReadLine();

            //     // while( loop == "yes")
            //     // using (SqlConnection query3 = new SqlConnection(connectionString))
            //     // {

            //     //     SqlCommand command = new SqlCommand(myQuery3, query3);
            //     //     query3.Open();
            //     //     SqlDataReader results9 = command.ExecuteReader();
            //     //     query3.Close();

            //     //     Console.WriteLine("WANNA INCREMENT???");
            //     //     loop = Console.ReadLine();
                    
            //     // }
                
            //     // using (SqlConnection query3 = new SqlConnection(connectionString))
            //     // {
            //     //     query3.Open();
            //     //     SqlCommand command = new SqlCommand(myQuery3, query3);
                    
            //     //     SqlDataReader results9 = command.ExecuteReader();
            //     //     //List<P1S_ModelsClass> m3 = new List<P1S_ModelsClass>();
                    
            //     //     while(results9.Read())//While the database reader reads, going through every row 
            //     //     {
            //     //         Console.WriteLine($"From Store Number {products} {loop} is {category}");
            //     //     }
                    
            //     //     query3.Close();


            //     //     // Console.WriteLine("WHAT U WANNA SEE??????");
            //     //     // loop = Console.ReadLine();
            //     //     // Console.WriteLine($"WHAT {loop} U WANNA SEE??????");
            //     //     // category = Console.ReadLine();
                    
            //     // }

            //     // void intensityCheck(string input)
            //     // {
            //     //     for(int i = 0; i<products.Count; i++)
            //     //     {
            //     //         if(products[i].intensity == input)
            //     //         {
            //     //             Console.WriteLine($"This member is the PRODUCT ID: {products[i].ProductID}, NAME: {products[i].p_name}, INTENSITY: {products[i].intensity}");//and so on
            //     //             Console.WriteLine($"PRICE: {products[i].price}, INVENTORY: {products[i].inventory}, STORE ID: {products[i].fk_StoreID}");//and so on
            //     //             Console.WriteLine($"DESCRIPTION: {products[i].details}");
            //     //         }
            //     //     }
            //     // }
            //     // void nameCheck(string input)
            //     // {
            //     //     bool badName = true;
            //     //     for(int i = 0; i<products.Count; i++)
            //     //     {
            //     //         if(products[i].p_name == input)
            //     //         {
            //     //             badName = false;
            //     //             Console.WriteLine($"This member is the PRODUCT ID: {products[i].ProductID}, NAME: {products[i].p_name}, INTENSITY: {products[i].intensity}");//and so on
            //     //             Console.WriteLine($"PRICE: {products[i].price}, INVENTORY: {products[i].inventory}, STORE ID: {products[i].fk_StoreID}");//and so on
            //     //             Console.WriteLine($"DESCRIPTION: {products[i].details}");
            //     //         }
            //     //     }
            //     //     if(badName)
            //     //     {
            //     //         Console.WriteLine("None of our stores got that...");
            //     //     }
            //     // }

                

            // }
        loginOrRegisterHere(); 
        }
    }
}
