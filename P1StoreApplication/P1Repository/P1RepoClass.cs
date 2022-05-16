using P1Models;
using System.Data.SqlClient;

namespace P1Repository;

public class P1RepoClass//Here we communicate with the database
{
    public P1MapperClass _mapper {get; set;}
    public P1RepoClass()
    {
        this._mapper = new P1MapperClass();//Go to mapper class to find the format by which we will look at this data
    }
    public List<P1ModelsClass> ProductsList()//...and here we are touching each file in the online database
    {
        //Query DB for list of members
        //USE ADO.NET
        //Use mapper to transfer the values into P1Models products in a List<>
            string connectionString = $"Server=tcp:tariqsaddlerserver.database.windows.net,1433;Initial Catalog=P1Store;Persist Security Info=False;User ID=TariqSaddlerDB;Password=One23Four%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string myQuery1 = "SELECT * FROM products";
            
            using (SqlConnection query1 = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(myQuery1, query1);

                query1.Open();
                SqlDataReader results = command.ExecuteReader();
                List<P1ModelsClass> m1 = new List<P1ModelsClass>();
        
            while(results.Read())//While the database reader reads, 
            {
                //see what _mapper is doing above. 
                //DboToMemeber: Database Object becomes a member of the list we ar making. Definition in mapper class
                m1.Add(this._mapper.DboToMember(results));// continue adding members to these rows. (I think "reader" represents the row)

            }
            query1.Close();
            
            return m1;//return a list of objects with multiple attributes. Essentially, return the database to business class who will hand it off to the original class

            //throw new NotImplementedException();
                
                
            }
        
        
        
    }
}

public class P1S_RepoClass
{
    public P1S_MappersClass s_mapper {get; set;}
    public P1S_RepoClass()
    {
        this.s_mapper = new P1S_MappersClass();//Go to mapper class to find the format by which we will look at this data
    }
    public List<P1S_ModelsClass> StoresList()//...and here we are touching each file in the online database
    {
        //Query DB for list of members
        //USE ADO.NET
        //Use mapper to transfer the values into P1Models products in a List<>
            string connectionString = "Server=tcp:tariqsaddlerserver.database.windows.net,1433;Initial Catalog=P1Store;Persist Security Info=False;User ID=TariqSaddlerDB;Password=One23Four%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string myQuery2 = "SELECT * FROM stores";
            using (SqlConnection query2 = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(myQuery2, query2);

                query2.Open();
                SqlDataReader results2 = command.ExecuteReader();
                List<P1S_ModelsClass> m2 = new List<P1S_ModelsClass>();
        
                while(results2.Read())//While the database reader reads, going through every row 
                {
                    //see what _mapper is doing above. 
                    //DboToMemeber: Database Object becomes a member of the list we ar making. Definition in mapper class
                    m2.Add(this.s_mapper.DboToMember(results2));// continue adding members to these rows. (I think "reader" represents the row)
                }
                query2.Close();
                return m2;
                
                
            }
        
        //return a list of objects with multiple attributes. Essentially, return the database to business class who will hand it off to the original class

            //throw new NotImplementedException();
        
    }
}
public class P1C_RepoClass
{
    public P1C_MappersClass c_mapper {get; set;}
    public P1C_RepoClass()
    {
        this.c_mapper = new P1C_MappersClass();//Go to mapper class to find the format by which we will look at this data
    }
    public List<P1C_ModelsClass> CustomersList()//...and here we are touching each file in the online database
    {
        //Query DB for list of members
        //USE ADO.NET
        //Use mapper to transfer the values into P1Models products in a List<>
            string connectionString = "Server=tcp:tariqsaddlerserver.database.windows.net,1433;Initial Catalog=P1Store;Persist Security Info=False;User ID=TariqSaddlerDB;Password=One23Four%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string myQuery3 = "SELECT * FROM CustomerInfo";
            using (SqlConnection query3 = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(myQuery3, query3);

                query3.Open();
                SqlDataReader results3 = command.ExecuteReader();
                List<P1C_ModelsClass> m3 = new List<P1C_ModelsClass>();
        
                while(results3.Read())//While the database reader reads, going through every row 
                {
                    //see what _mapper is doing above. 
                    //DboToMemeber: Database Object becomes a member of the list we ar making. Definition in mapper class
                    m3.Add(this.c_mapper.DboToMember(results3));// continue adding members to these rows. (I think "reader" represents the row)
                }
                query3.Close();
                return m3;
                
                
            }
        
        //return a list of objects with multiple attributes. Essentially, return the database to business class who will hand it off to the original class

            //throw new NotImplementedException();
        
    }
}

public class P1SC_RepoClass
{
    public P1SC_MappersClass sc_mapper {get; set;}
    public P1SC_RepoClass()
    {
        this.sc_mapper = new P1SC_MappersClass();//Go to mapper class to find the format by which we will look at this data
    }
    public List<P1SC_ModelsClass> ShoppingList()//...and here we are touching each file in the online database
    {
        //Query DB for list of members
        //USE ADO.NET
        //Use mapper to transfer the values into P1Models products in a List<>
            string connectionString = "Server=tcp:tariqsaddlerserver.database.windows.net,1433;Initial Catalog=P1Store;Persist Security Info=False;User ID=TariqSaddlerDB;Password=One23Four%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string myQuery4 = "SELECT * FROM shopping_cart";
            using (SqlConnection query4 = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(myQuery4, query4);

                query4.Open();
                SqlDataReader results4 = command.ExecuteReader();
                List<P1SC_ModelsClass> m4 = new List<P1SC_ModelsClass>();
        
                while(results4.Read())//While the database reader reads, going through every row 
                {
                    //see what _mapper is doing above. 
                    //DboToMemeber: Database Object becomes a member of the list we ar making. Definition in mapper class
                    m4.Add(this.sc_mapper.DboToMember(results4));// continue adding members to these rows. (I think "reader" represents the row)
                }
                query4.Close();
                return m4;
                
                
            }
        
        //return a list of objects with multiple attributes. Essentially, return the database to business class who will hand it off to the original class

            //throw new NotImplementedException();
        
    }
}



public class P1OH_RepoClass
{
    public P1OH_MappersClass oh_mapper {get; set;}
    public P1OH_RepoClass()
    {
        this.oh_mapper = new P1OH_MappersClass();//Go to mapper class to find the format by which we will look at this data
    }
    public List<P1OH_ModelsClass> OrdersList()//...and here we are touching each file in the online database
    {
        //Query DB for list of members
        //USE ADO.NET
        //Use mapper to transfer the values into P1Models products in a List<>
            string connectionString = "Server=tcp:tariqsaddlerserver.database.windows.net,1433;Initial Catalog=P1Store;Persist Security Info=False;User ID=TariqSaddlerDB;Password=One23Four%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string myQuery5 = "SELECT * FROM shopping_cart";
            using (SqlConnection query5 = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(myQuery5, query5);

                query5.Open();
                SqlDataReader results5 = command.ExecuteReader();
                List<P1OH_ModelsClass> m5 = new List<P1OH_ModelsClass>();
        
                while(results5.Read())//While the database reader reads, going through every row 
                {
                    //see what _mapper is doing above. 
                    //DboToMemeber: Database Object becomes a member of the list we ar making. Definition in mapper class
                    m5.Add(this.oh_mapper.DboToMember(results5));// continue adding members to these rows. (I think "reader" represents the row)
                }
                query5.Close();
                return m5;
                
                
            }
        
        //return a list of objects with multiple attributes. Essentially, return the database to business class who will hand it off to the original class

            //throw new NotImplementedException();
        
    }
}