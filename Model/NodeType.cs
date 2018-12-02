using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum NodeType
    {
        [Description("Параллельное")]
        Parallel,
        [Description("Последовательное")]
        Serial,
        [Description("Резистор")]
        Resistor,
        [Description("Катушка")]
        Inductor,
        [Description("Конденсатор")]
        Capacitor
    }
}
