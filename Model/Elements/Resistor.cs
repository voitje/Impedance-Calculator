#region

using System;
using System.Numerics;

#endregion

namespace Model.Elements
{
    /// <summary>
    ///     Резистор
    /// </summary>
    public class Resistor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор класса Resistor
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        public Resistor(string name, double value) : base(name, value)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Расчет импеданса
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns>Комплекное сопротивление</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Частота не может быть меньше нуля");
            }

            return new Complex(Value, 0);
        }

        #endregion
    }
}