using P1Models;
using P1Repository;
using System.Data.SqlClient;

namespace P1Repository
{
    public class P1MapperClass
    {

        
        //Create a method that will transfer data from P1Models list
        internal P1ModelsClass DboToMember(SqlDataReader reader)
        {
            P1ModelsClass p = new P1ModelsClass//We redefine the instantiated values from models class of whichever row we are on
            {
                ProductID = (int)reader[0],
                p_name = (string)reader[1],
                details = (string)reader[2],
                intensity = (string)reader[3],
                inventory = (int)reader[4],
                price = (decimal)reader[5],
                fk_StoreID = (int)reader[6]
            };
            return p;//returns 1 row of data for our _mapper in the repository class
        }
    }
    public class P1S_MappersClass
    {
        internal P1S_ModelsClass DboToMember(SqlDataReader reader2)
        {
            P1S_ModelsClass s = new P1S_ModelsClass
            {
                StoreID = (int)reader2[0],
                s_name = (string)reader2[1],
                s_address = (string)reader2[2]
            };
            return s;
        }
    }

    public class P1C_MappersClass
    {
        internal P1C_ModelsClass DboToMember(SqlDataReader reader3)
        {
            P1C_ModelsClass s = new P1C_ModelsClass
            {
                CustomerID = (int)reader3[0],
                name_of_user = (string)reader3[1],
                username = (string)reader3[2],
                user_pw = (string)reader3[3],
                user_email = (string)reader3[4]
            };
            return s;
        }
    }

    public class P1SC_MappersClass
    {
        internal P1SC_ModelsClass DboToMember(SqlDataReader reader4)
        {
            P1SC_ModelsClass sc = new P1SC_ModelsClass
            {
                CartSlotID = (int)reader4[0],
                fk_ProductID = (int)reader4[1],
                quantity_in_cart = (int)reader4[2]
            };
            return sc;
        }
    }

    public class P1OH_MappersClass
    {
        internal P1OH_ModelsClass DboToMember(SqlDataReader reader5)
        {
            P1OH_ModelsClass oh = new P1OH_ModelsClass
            {
                OrderID = (int)reader5[0],
                fk_StoreID = (int)reader5[1],
                fk_CustomerID = (int)reader5[2],
                total_cost = (int)reader5[3]
            };
            return oh;
        }
    }
}