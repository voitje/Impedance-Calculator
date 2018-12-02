using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ParallelSubcircuit : Subcircuit
    {
        /// <summary>
        ///     Рассчет импеданса
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns>Импеданс</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (Nodes.Count <= 1)
            {
                throw new InvalidOperationException(
                    $"В параллельном соединении (Id: {Id}) необходимо минимум 2 узла.");
            }

            var resistance = Complex.Zero;

            foreach (var node in Nodes)
            {
                resistance += 1 / node.CalculateZ(frequency);
            }

            return 1 / resistance;
        }
    }
}
