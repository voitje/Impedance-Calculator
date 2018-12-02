using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Конденсатор
    /// </summary>
    public class Capacitor : ElementBase
    {
        #region Public methods

        /// <summary>
        ///     Конструктор класса Capacitor
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        public Capacitor(string name, double value) : base(name, value)
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

            return new Complex(0, -1 / (2 * Math.PI * frequency * Value));
        }

        #endregion
    }
}
