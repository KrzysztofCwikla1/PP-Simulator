using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max) 
    { 
        if (value < min)
            value = min;
        if (value > max)
            value = max;
        return value;
    }

    public static string
        Shortener(string value, int min, int max, char placeholder)
    {
        value = value.Trim();

        if (value.Length < min)
            value = value.PadRight(min, placeholder);
        else if (value.Length > max)
            value = value.Substring(0, max).Trim();
        if (value.Length < min)
        {
            return value.PadRight(min, placeholder);
        }
        else
        {
            return char.ToUpper(value[0]) + value.Substring(1);
        }
    }
}
