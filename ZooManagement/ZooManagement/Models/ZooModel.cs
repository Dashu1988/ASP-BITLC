namespace Zoo.Models;

public class ZooData
{
    public ZooModel ZooModel { get; set; }
    public Tier Tier { get; set; }
    public Gehege Gehege { get; set; }
    public Tierart Tierart { get; set; }
    public Tierpass Tierpass { get; set; }
    public Welt Welt { get; set; }
}
public class ZooModel
{
    public int ID { get; set; }
    public string Name { get; set; }
}

public class Tier
{
    public int ID { get; set; }
    public int GehegeID { get; set; }
    public int TierpassID { get; set; }
}

public class Gehege()
{
    public int ID { get; set; }
    public int WeltID { get; set; }
}

public class Tierart
{
    public int ID { get; set; }
    public string Name { get; set; }
}

public class Tierpass
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int TierartID { get; set; }
}

public class Welt
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int ZooID { get; set; }
    public List<Gehege> GehegeListe { get; set; }
}