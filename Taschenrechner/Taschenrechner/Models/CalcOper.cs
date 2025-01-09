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
        }else if (op == "%")
        {
            res = n1 % n2;
        }else if (op == "\u221a")
        {
            res = Math.Pow(n1, 1.0 / (int)n2);
        }
    }
}