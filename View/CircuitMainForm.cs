using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.Elements;


namespace View
{
    public partial class MainForm : Form
    {
        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Цепь.
        /// </summary>
        private readonly Circuit _circuit;

        /// <summary>
        ///     Объект готовых цепей.
        /// </summary>
        private readonly GenerateCircuits _generateCircuits;

        /// <summary>
        ///     Лист, который хранит имена всех элементов.
        /// </summary>
        private readonly List<Tuple<char, int>> _vectorOfElements;

        private readonly Tuple<char, int> vectorofelements;

        #endregion

        #region Private fields

        /// <summary>
        ///     Количество элементов.
        /// </summary>
        private int _count;

        /// <summary>
        ///     Выбранная нода.
        /// </summary>
        private INode _currentNode;

        /// <summary>
        ///     Форма для расчета импеданса.
        /// </summary>
        private ImpedanceForm _impedanceForm;

        /// <summary>
        ///     Форма для изменения значения элемента.
        /// </summary>
        private EditForm _editForm;
        #endregion

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            var circuits = new List<string>();
            circuits.Add("Своя цепь");
            for (var i = 1; i < 6; i++)
            {
                circuits.Add("Цепь №" + i);
            }

            CircuitsComboBox.DataSource = circuits;
            CircuitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            _count = 0;
            var elements = new List<string>();
            var arrayElements = Enum.GetValues(typeof(NodeType));

            foreach (NodeType element in arrayElements)
            {
                elements.Add(ToolsForEnum.GetDescription(element));
            }


            NadeComboBox.DataSource = elements;
            NadeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _circuit = new Circuit();

            _vectorOfElements = new List<Tuple<char, int>>();

            _generateCircuits = new GenerateCircuits();
            circuitPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            vectorofelements = new Tuple<char, int>('!',0);
        }

        #endregion

        #region Private methods

        private void NominalTextBox_Enter(object sender, EventArgs e)
        {
            NominalTextBox.ForeColor = SystemColors.WindowText;
            NominalTextBox.Text = "";
            NominalTextBox.TextAlign = HorizontalAlignment.Center;
        }


        private void NominalTextBox_Leave(object sender, EventArgs e)
        {
            //Если поле для заполнения пустое, редактируется
            if (NominalTextBox.Text == "")
            {
                NominalTextBox.ForeColor = SystemColors.WindowFrame;
                NominalTextBox.Enter += NominalTextBox_Enter;
                NominalTextBox.Text = "Значение";
                NominalTextBox.TextAlign = HorizontalAlignment.Center;
            }
            //Если поле заполнилось, то проверяем значение
            else
            {
                NominalTextBox.Enter -= NominalTextBox_Enter;
                if (Tools.IsCellCorrect(NominalTextBox.Text) == false)
                {
                    Tools.ShowError(NominalTextBox.Text);

                    NominalTextBox.Clear();
                }
            }
        }

        private void SelectingCircuitsComboBox_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            if (_generateCircuits != null)
            {
                var selectedState = CircuitsComboBox.Items.IndexOf(CircuitsComboBox.SelectedItem.ToString());
                if (selectedState == 0)
                {
                    _count = 0;
                    treeView.Nodes.Clear();
                    _circuit.Clean();
                    circuitPictureBox.Image = null;
                    _vectorOfElements.Clear();
                    return;
                }

                _generateCircuits.CreateCircuit(selectedState, _vectorOfElements,
                    _circuit);

                _count = _vectorOfElements.Count;
                UpdateTreeView();
            }
        }

        /// <summary>
        ///     Обновление TreeView
        /// </summary>
        private void UpdateTreeView()
        {
            void AddNodeTreeNodes(INode node, TreeNode treeNode)
            {
                if (node == null)
                {
                    return;
                }

                if (node is ElementBase)
                {
                    return;
                }

                foreach (var children in node.Nodes)
                {
                    var newTreeNode = new TreeINode(children);
                    treeNode.Nodes.Add(newTreeNode);
                    AddNodeTreeNodes(children, newTreeNode);
                }
            }

            treeView.Nodes.Clear();

            var root = new TreeINode(_circuit.Root);
            treeView.Nodes.Add(root);
            AddNodeTreeNodes(_circuit.Root, root);

            treeView.ExpandAll();

            circuitPictureBox.Image = null;

            var bitmapBackground = new Bitmap(1000, 1000);
            Drawer.Graphics = Graphics.FromImage(bitmapBackground);
            Drawer.Pen = new Pen(Color.Black, 1);
            Drawer.Font = Font;

            var displacement = new Point(15, 0);
            Drawer.DrawCircuit(_circuit.Root, displacement);

            circuitPictureBox.Image = bitmapBackground;
        }

        /// <summary>
        ///     Проверка, того что выбрал пользователь в TreeView
        /// </summary>
        /// <returns></returns>
        private bool IsCorrectAdd()
        {
            if (!(_currentNode is Subcircuit) && treeView.Nodes.Count > 0)
            {
                MessageBox.Show(
                    "Для добавление элемента в цепь, требуеться выбрать " +
                    "последовательность (параллельная, последовательная)");

                return true;
            }

            return false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var selectedState = NadeComboBox.SelectedItem.ToString();
            if (_vectorOfElements.Count > 18)
            {
                MessageBox.Show("Максимальное количество элементов в цепи 18!");
                return;
            }

            try
            {
                switch (selectedState)
                {
                    case "Последовательное":
                        _circuit.Add(_currentNode, new SerialSubcircuit());
                        break;
                    case "Параллельное":
                        _circuit.Add(_currentNode, new ParallelSubcircuit());
                        break;
                    case "Резистор":
                        if (IsCorrectAdd())
                        {
                            return;
                        }

                        _vectorOfElements.Add(Tools.CreateName('R', _vectorOfElements));
                        _circuit.Add(_currentNode,
                            new Resistor(
                                _vectorOfElements[_count].Item1 +
                                _vectorOfElements[_count]
                                    .Item2.ToString(),
                                double.Parse(NominalTextBox.Text)));

                        _count++;

                        break;
                    case "Катушка":
                        if (IsCorrectAdd())
                        {
                            return;
                        }

                        _vectorOfElements.Add(Tools.CreateName('L', _vectorOfElements));
                        _circuit.Add(_currentNode,
                            new Inductor(
                                _vectorOfElements[_count].Item1 +
                                _vectorOfElements[_count]
                                    .Item2.ToString(),
                                double.Parse(NominalTextBox.Text)));

                        _count++;

                        break;
                    case "Конденсатор":
                        if (IsCorrectAdd())
                        {
                            return;
                        }

                        _vectorOfElements.Add(Tools.CreateName('C', _vectorOfElements));
                        _circuit.Add(_currentNode,
                            new Capacitor(
                                _vectorOfElements[_count].Item1 +
                                _vectorOfElements[_count]
                                    .Item2.ToString(),
                                double.Parse(NominalTextBox.Text)));

                        _count++;

                        break;
                }

                UpdateTreeView();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void TreeViewCircuit_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is TreeINode treeNode)
            {
                _currentNode = treeNode.Value;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_vectorOfElements.Count != 0)
            {
                if (_currentNode == _circuit.Root)
                {
                    _circuit.Remove(_currentNode);
                    treeView.Nodes.Clear();
                    circuitPictureBox.Image = null;
                    _count = 0;
                    _vectorOfElements.Clear();
                    return;
                }

                if (_currentNode is ElementBase currentNode)
                {
                    var deletedElement = new Tuple<char, int>(currentNode.Name[0],
                        (int) char.GetNumericValue(currentNode.Name[1]));

                    for (var i = 0; i < _vectorOfElements.Count; i++)
                    {
                        if (_vectorOfElements[i].Item1 == deletedElement.Item1 &&
                            _vectorOfElements[i].Item2 == deletedElement.Item2)
                        {
                            _vectorOfElements.Remove(_vectorOfElements[i]);
                        }
                    }

                    _count--;
                }

                _circuit.Remove(_currentNode);
                UpdateTreeView();
            }
        }

        private void CalculateImpedanceButton_Click(object sender, EventArgs e)
        {
            _impedanceForm = new ImpedanceForm();
            _impedanceForm.Circuit = _circuit;
            _impedanceForm.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (_currentNode != null)
            {
                if (_currentNode is ElementBase element)
                {
                    _editForm = new EditForm();
                    _editForm.Element = element;
                    _editForm.ShowDialog();
                        //TODO: если результат завершения равен Cancel, тогда обновить дерево, \ DONE
                        // а если элемент действительно изменен, то обновлять дерево не нужно? \ DONE
                    UpdateTreeView();
                }
                else
                {
                    MessageBox.Show("Выбранный вами узел не является элементом.");
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент, который хотите изменить.");
            }
        }

        #endregion
    }
}