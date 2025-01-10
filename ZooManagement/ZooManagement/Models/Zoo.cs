namespace ZooManagement.Models;

public class ZooData
{
    public static List<Zoo> Zoos = new List<Zoo>();
    
    public Zoo Zoo { get; set; }
    public Tier Tier { get; set; }
    public Gehege Gehege { get; set; }
    public Tierart Tierart { get; set; }
    public Tierpass Tierpass { get; set; }
    public Welt Welt { get; set; }
}

public class Zoo
{
    public int ID { get; set; }
    public string Name { get; set; }
    public List<Welt> Welten { get; set; } = new List<Welt>();

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
    public int TierpassID { get; set; }

    public Tier(int id, int gehegeid, int tierpassid)
    {
        this.ID = id;
        this.GehegeID = gehegeid;
        this.TierpassID = tierpassid;
    }
}

public class Gehege
{
    public int ID { get; set; }
    public int WeltID { get; set; }

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
    public int TierartID { get; set; }

    public Tierpass(int id, string name, int tierartid)
    {
        this.ID = id;
        this.Name = name;
        this.TierartID = tierartid;
    }
}

public class Welt
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int ZooID { get; set; }
    public List<Gehege> GehegeListe { get; set; } = new List<Gehege>();

    public Welt(int id, string name, int zooid)
    {
        this.ID = id;
        this.Name = name;
        this.ZooID = zooid;
    }
}