using System;
//using System.Web.UI.WebControls;
using System.Windows.Forms;
using Model.Elements;

namespace Model
{
    public class TreeINode : TreeNode
    {
        #region Properties

        /// <summary>
        ///     Значение.
        /// </summary>
        public INode Value { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="node">Нода.</param>
        public TreeINode(INode node)
        {
            if (node == null)
            {
                return;

            }

            Value = node;

            switch (node)
            {
                case SerialSubcircuit series:
                    Text = $"[Послед] (Id:{series.Id})";
                    break;
                case ParallelSubcircuit parallel:
                    Text = $"[Паралл] (Id:{parallel.Id})";
                    break;
                case Resistor resistor:
                    Text = $"({resistor.Name}) [{resistor.Value}]";
                    break;
                case Capacitor capacitor:
                    Text = $"({capacitor.Name}) [{capacitor.Value}]";
                    break;
                case Inductor inductor:
                    Text = $"({inductor.Name}) [{inductor.Value}]";
                    break;
                default:
                    throw new InvalidOperationException(nameof(node));
            }
        }

        #endregion
    }
}

