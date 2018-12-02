using System.Collections.Generic;
using System.Numerics;

namespace Model
{
    public abstract class Subcircuit : INode
    {
        #region Fields

        #region Static fields

        private static int _id;

        #endregion

        #region Readonly fields

        private readonly int _global;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Идентификатор.
        /// </summary>
        public int Id { get; } = _id;

        /// <summary>
        ///     Родитель.
        /// </summary>
        public INode Parent { get; set; }

        /// <summary>
        ///     Дочерние узлы.
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        #endregion

        #region Events

        /// <summary>
        ///     Рассчет импеданса.
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор для изменение id.
        /// </summary>
        protected Subcircuit()
        {
            _id++;
        }

        #endregion
    }
}