using Microsoft.AspNetCore.Components;

namespace ZooManagement.Models;


public class ZooData()
{
    public int ZooID { get; set; }
    public int OptionID { get; set; }
}


public class Zoo
{
    public int ID { get; set; }
    public string Name { get; set; }
    public List<Welt> Welten { get; set; } = new List<Welt>();

    public Zoo()
    {
        
    }
    public Zoo(int id, string name)
    {
        this.ID = id;
        this.Name = name;
    }
}

public class Tier
{
    public int ID { get; set; }
    public int GehegeID { get; set; }
    public Tierpass Tierpass { get; set; }

    public Tier(int id, int gehegeid, Tierpass tierpass)
    {
        this.ID = id;
        this.GehegeID = gehegeid;
        this.Tierpass = tierpass;
    }
}

public class Gehege
{
    public int ID { get; set; }
    public int WeltID { get; set; }
    public List<Tier> Tiere { get; set; }

    public Gehege(int id, int weltid)
    {
        this.ID = id;
        this.WeltID = weltid;
    }

    
}

public class Tierart
{
    public int ID { get; set; }
    public string Name { get; set; }

    public Tierart(int id, string name)
    {
        this.ID = id;
        this.Name = name;
    }
}

public class Tierpass
{
    public int ID { get; set; }
    public string Name { get; set; }
    public Tierart Tierart { get; set; }

    public Tierpass(int id, string name, Tierart tierartid)
    {
        this.ID = id;
        this.Name = name;
        this.Tierart = tierartid;
    }
}

public class Welt
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int ZooID { get; set; }
    public List<Gehege> Gehege { get; set; } = new List<Gehege>();

    public Welt()
    {
        
    }
    public Welt(int id, int zooid, string name)
    {
        this.ID = id;
        this.Name = name;
        this.ZooID = zooid;
    }
}