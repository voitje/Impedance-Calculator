#region

using System;
using System.Numerics;

#endregion

namespace Model.Elements
{
    /// <summary>
    ///     Катушка индуктивности
    /// </summary>
    public class Inductor : ElementBase
    {
        #region Public methods

        /// <summary>
        ///     Конструктор класса Inductor
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        public Inductor(string name, double value) : base(name, value)
        {
        }

        /// <summary>
        ///     Расчет импеданса
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException("Частота не может быть меньше нуля");
            }

            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion
    }
}