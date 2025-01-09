using System.Net.Sockets;

namespace Taschenrechner.Models;

public class CalcOper
{
    static public List<CalcOper> AllOpers = new List<CalcOper>();
    public double n1 { get; set; }
    public double n2 { get; set; }
    public string? op { get; set; }
    public double? res { get; set; }

   

    public void Calc()
    {
        if (op == "+")
        {
            res = n1 + n2;
        }
        else if (op == "-")
        {
            res = n1 - n2;
        }
        else if (op == "*")
        {
            res = n1 * n2;
        }
        else if (op == "/")
        {
            if (n2 == 0)
            {
                res = null;
            }
            else
            {
                res = (double)n1 / n2;
            }
        }
        else if (op == "%")
        {
            res = n1 % n2;
        }
        else if (op == "\u221a")
        {
            res = Math.Pow(n1, 1.0 / (int)n2);
        }
        else if (op == "^")
        {
            res = Math.Pow(n1, n2);
        }
        else if (op == "x")
        {
            n2 = 1;
            res = null;
            CalcOper.AllOpers.Clear();
        }
    }

    public bool IsValid()
    {
        if (op == null || n1 == null || n2 == null) return false;
        return true;
    }
}