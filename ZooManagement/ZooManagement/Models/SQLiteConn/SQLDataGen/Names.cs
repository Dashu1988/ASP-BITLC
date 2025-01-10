using System.Data;
using System.Data.SQLite;

namespace ZooManagement.Models;

public partial class SQLDataGen
{
    static List<string> WorldNames = new List<string>()
    {
        "Abenteuer Safari",
        "Dschungelparadies",
        "Tropeninsel",
        "Wildtier-Oase",
        "Exotica Park",
        "Naturwunder",
        "Safari Abenteuer",
        "Tierreich",
        "Dschungel Expedition",
        "Tierisches Abenteuer",
        "Abenteuer Dschungel",
        "Wildnis Entdeckung",
        "Exotischer Tierwelt",
        "Safari Erlebnis",
        "Tropischer Zoo",
        "Dschungelpfad",
        "Wildpark",
        "Abenteuer Oase",
        "Tierische Tropen",
        "Tropenparadies Zoo"
    };

    static List<string> AnimalTypes = new List<string>()

    {
        "Löwe", "Tiger", "Elefant", "Giraffe", "Zebra", "Känguru", "Pinguin", "Panda", "Koala", "Nashorn",
        "Flamingo", "Schimpanse", "Gorilla", "Leopard", "Jaguar", "Kamel", "Strauß", "Seelöwe", "Bison",
        "Antilope", "Bär", "Delfin", "Wal", "Meerschweinchen", "Fuchs", "Wolf", "Elch", "Waschbär",
        "Erdmännchen", "Faultier"
    };
}

