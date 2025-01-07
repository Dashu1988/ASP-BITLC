namespace Einkaufsliste.Models;

public class Repository
{
    public static List<Position> Pos = new List<Position>();

    public static Position Add(Position newpos)
    {
        foreach (Position po in Repository.Pos)
        {
            if (po.Name == newpos.Name && po.Shop == newpos.Shop)
            {
                po.Menge += newpos.Menge;
                return po;
            }
        }
        Pos.Add(newpos);
        return newpos;
    }

    public static void Remove(Position p)
    {
        for (int i = 0; i < Pos.Count; i++)
        {
            if (Pos[i].Name == p.Name && Pos[i].Shop == p.Shop)
            {
                Pos.RemoveAt(i);
                return;
            }
        }

        return;
    }
}