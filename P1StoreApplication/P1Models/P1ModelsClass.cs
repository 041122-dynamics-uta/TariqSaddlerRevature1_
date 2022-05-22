namespace P1Models;
public class P1ModelsClass//Instantiate these values, they will be redefined
{
    public int ProductID {get; set;} = 1;
    public string  p_name { get; set; } = "";
    public string details { get; set; } = "";
    public string intensity{ get; set; } = "";
    public int inventory{ get; set; } = 0;
    public decimal price{ get; set; } = 0;
    public int fk_StoreID{ get; set; } = 0;
}

public class P1C_ModelsClass//Instantiate these values, they will be redefined
{
    public int CustomerID {get; set;} = 1;
    public string  name_of_user { get; set; } = "";
    public string username { get; set; } = "";
    public string user_pw{ get; set; } = "";
    public string user_email{ get; set; } = "";
}

public class P1SC_ModelsClass//Instantiate these values, they will be redefined
{
    public int CartSlotID {get; set;} = 1;
    public int fk_ProductID {get; set;} = 1;
    public int quantity_in_cart {get; set;} = 0;
    
}


public class P1OH_ModelsClass//Instantiate these values, they will be redefined
{
    public int OrderID {get; set;} = 1;
    public int fk_StoreID {get; set;} = 1;
    public int fk_CustomerID {get; set;} = 1;
    public decimal total_cost {get; set;} = 0;
    public DateTime order_datetime {get; set;} = DateTime.Now;
    
}