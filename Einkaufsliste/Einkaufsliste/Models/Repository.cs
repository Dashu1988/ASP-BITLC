using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Einkaufsliste.Models;

public class Repository
{
    public static List<Position> Pos = new List<Position>();
    public static HashSet<string> Shops = new HashSet<string>();

    public static void ReadShops()
    {
        foreach (Position pos in Pos)
        {
            Shops.Add(pos.Shop);
        }
    }
}