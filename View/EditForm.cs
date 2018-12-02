using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Elements;

namespace View
{
    /// <summary>
    ///     Форма редактирования элементов
    /// </summary>
    public partial class EditForm : Form
    {
        #region Fields

        /// <summary>
        ///     Элемент
        /// </summary>
        private  ElementBase _element;

        #region Private fields

        /// <summary>
        ///     Номинал
        /// </summary>
        private double _value;

        public ElementBase Element { get; set; }

        #endregion

        #endregion

        #region Private methods

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            _element.Value = _value;
            Close();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            //TODO: А Close() зачем убрал? \ DONE
            //TODO: Либо здесь Close(), либо этот обработчик вообще не нужен \ DONE
        }

        private void TextBoxValue_TextChanged(object sender, EventArgs e)
       {
            if (!double.TryParse(_textBoxValue.Text, out _value))
            {
                buttonEdit.Enabled = false;
                return;
            }

            if (_value <= 0.1 || _value >= 1e12)
            {
                buttonEdit.Enabled = false;
                return;
            }

            buttonEdit.Enabled = true;
        }

        #endregion

        #region Public methods

        //TODO: ЕЩЕ РАЗ! элемент должен быть открытым свойством, а не входным аргументом конструктора! \ DONE
        //TODO: НЕЛЬЗЯ ПРОСТО ТАК УДАЛЯТЬ TODO!!! \ DONE
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="element">Элемент</param>
        public EditForm()
        {
            InitializeComponent();
            //TODO: Результат диалога должен присваиваться в обработчиках, закрывающих форму, а не в конструкторе\ DONE
            //TODO: Зачем кнопке присваивать DialogResult? \ DONE
        }

        #endregion

        private void EditForm_Load(object sender, EventArgs e)
        {
            _element = Element ?? throw new ArgumentNullException(nameof(_element));
            Text = "Элемент: " + _element.Name;
            _textBoxValue.Text = _element.Value.ToString();
        }
    }
}
