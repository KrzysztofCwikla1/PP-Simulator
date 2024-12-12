using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string description = "Unknown";
    public required string Description 
    {
        get { return description; }
        init 
        {

            value = value.Trim();

            if (value.Length > 25)
                value = value.Substring(0, 15).TrimEnd();
            if (value.Length < 3)
                value = value.PadRight(3, '#');
            if (char.IsLower(value[0]))
                value = char.ToUpper(value[0]) + value.Substring(1);
            description = value;
        }
    }
    public uint Size { get; set; } = 3;
    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}