namespace P1Business;
using P1Models;
using P1Repository;
public class P1BusinessClass
{
    //inject dependency into the class
    private P1RepoClass _repo {get; set;}
    public P1BusinessClass(P1RepoClass r)
    {
        this._repo = r;
    }
    public List<P1ModelsClass> ProductsList()
    {  
        List<P1ModelsClass> m1 = _repo.ProductsList();//...we must grab the list from the repository...

        return m1;

    }

   

    //Logging goes here
}
public class P1S_BusinessClass
{
    private P1S_RepoClass s_repo {get; set;}
    public P1S_BusinessClass(P1S_RepoClass s_r)
    {
        this.s_repo = s_r;
    }
    public List<P1S_ModelsClass> StoresList()
    {  
        List<P1S_ModelsClass> m2 = s_repo.StoresList();//...we must grab the list from the repository...

        return m2;

    }
}

public class P1C_BusinessClass
{
    private P1C_RepoClass c_repo {get; set;}
    public P1C_BusinessClass(P1C_RepoClass c_r)
    {
        this.c_repo = c_r;
    }
    public List<P1C_ModelsClass> CustomersList()
    {  
        List<P1C_ModelsClass> m3 = c_repo.CustomersList();//...we must grab the list from the repository...

        return m3;

    }
}


public class P1SC_BusinessClass
{
    private P1SC_RepoClass sc_repo {get; set;}
    public P1SC_BusinessClass(P1SC_RepoClass sc_r)
    {
        this.sc_repo = sc_r;
    }
    public List<P1SC_ModelsClass> ShoppingList()
    {  
        List<P1SC_ModelsClass> m4 = sc_repo.ShoppingList();//...we must grab the list from the repository...

        return m4;

    }
}

public class P1OH_BusinessClass
{
    private P1OH_RepoClass oh_repo {get; set;}
    public P1OH_BusinessClass(P1OH_RepoClass oh_r)
    {
        this.oh_repo = oh_r;
    }
    public List<P1OH_ModelsClass> OrdersList()
    {  
        List<P1OH_ModelsClass> m5 = oh_repo.OrdersList();//...we must grab the list from the repository...

        return m5;

    }
}
