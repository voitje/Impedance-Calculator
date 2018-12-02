using System.Collections.Generic;
using System.Numerics;

namespace Model
{
    public interface INode
    {
        #region Properties

        /// <summary>
        ///     Дочерние узлы.
        /// </summary>
        List<INode> Nodes { get; }

        /// <summary>
        ///     Родитель.
        /// </summary>
        INode Parent { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Подсчет комлпксного сопротивления.
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns></returns>
        Complex CalculateZ(double frequency);

        #endregion
    }
}