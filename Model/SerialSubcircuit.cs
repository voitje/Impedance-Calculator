using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SerialSubcircuit : Subcircuit
    {
        /// <summary>
        ///     Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Импеданс.</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (Nodes.Count < 1)
            {
                throw new InvalidOperationException(
                    $"В последовательном соединении (Id: {Id}) нет узлов.");
            }

            var resistance = Complex.Zero;

            foreach (var node in Nodes)
            {
                resistance += node.CalculateZ(frequency);
            }

            return resistance;
        }
    }
}
