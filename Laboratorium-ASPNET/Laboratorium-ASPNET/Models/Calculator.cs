using Microsoft.VisualBasic.CompilerServices;

namespace Laboratorium_ASPNET.Models;

public class Calculator
{
    public Operator? Operator { get; set; }
    public double? X { get; set; }
    public double? Y { get; set; }

    public string Op
    {
        get
        {
            switch (Operator)
            {
                case Models.Operator.Add:
                    return "+";
                case Models.Operator.Sub:
                    return "−";
                case Models.Operator.Mul:
                    return "×";
                case Models.Operator.Div:
                    return "÷";
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return Operator != null && X != null && Y != null;
    }

    public double Calculate()
    {
        switch (Operator)
        {
            case Models.Operator.Add:
                return (double)(X + Y)!;

            case Models.Operator.Sub:
                return (double)(X - Y)!;

            case Models.Operator.Mul:
                return (double)(X * Y)!;

            case Models.Operator.Div:
                return Y != 0 ? (double)(X / Y)! : double.NaN;

            default:
                return double.NaN;
        }
    }
}

public enum Operator
{
    Add, Sub, Mul, Div
}
