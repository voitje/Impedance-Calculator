#region

using System;
using System.Collections.Generic;
using System.Numerics;
//using System.Reflection.Metadata;
using Model.Elements;

#endregion

namespace Model
{
    /// <summary>
    ///     Цепь.
    /// </summary>
    public class Circuit
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Корень цепи.
        /// </summary>
        public INode Root { get; private set; }

        #endregion

        #endregion

        #region Public methods

        /// <summary>
        ///     Расчитать импедансы цепи для списка частот.
        /// </summary>
        /// <param name="frequencies">Список частот сигнала.</param>
        /// <returns>Список импедансов цепи.</returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            var impedances = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                impedances.Add(Root.CalculateZ(frequency));
            }

            return impedances;
        }

        public bool IsEmpty()
        {
            return Root == null;
        }

        public void Add(INode currentNode, INode newNode)
        {
            if (IsEmpty())
            {
                Root = newNode;
                return;
            }

            if (currentNode is Subcircuit subcircuit)
            {
                subcircuit.Nodes.Add(newNode);

                if (newNode is Subcircuit newSubcircuit)
                {
                    newSubcircuit.Parent = subcircuit;
                }

                if (newNode is ElementBase newElementBase)
                {
                    newElementBase.Parent = subcircuit;
                }
            }
        }

        public void Remove(INode currentNode)
        {
            if (currentNode == Root)
            {
                currentNode.Nodes.Clear();
                Root = null;
                return;
            }
            
            if (currentNode is Subcircuit subcircuit)
            {
                for (int i = 0; i < subcircuit.Nodes.Count; i++)
                {
                    subcircuit.Nodes[i].Parent = subcircuit.Parent;
                }
                subcircuit.Parent.Nodes.AddRange(subcircuit.Nodes);
                subcircuit.Parent.Nodes.Remove(subcircuit);
            }
            if (currentNode is ElementBase elementBase)
            {
                elementBase.Parent.Nodes.Remove(elementBase);
            }
        }

        public void  Clean()
        {
            Root = null;
        }
        #endregion
    }
}