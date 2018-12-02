using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    ///     Форма для расчета имеданса
    /// </summary>
    public partial class ImpedanceForm : Form
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Поле для цепи.
        /// </summary>
        private Circuit _circuit;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Свойство для цепи.
        /// </summary>
        public Circuit Circuit { get; set; }

        #endregion

        #region Constructor

        public ImpedanceForm()
        {
            InitializeComponent();
            dataGridView.RowHeadersVisible = false;
            CalculateButton.Enabled = false;
        }

        #endregion

        #region Private methods

        private void CalculateImpedance()
        {
            _circuit = Circuit;
            var start = double.Parse(StartTextBox.Text.Replace('.', ','));
            var finish = double.Parse(FinishTextBox.Text.Replace('.', ','));
            var step = double.Parse(StepTextBox.Text.Replace('.', ','));

            //TODO: Заменить на список, а список преобразовать в массив при передаче в CalculateZ с помощью LINQ-запроса ToArray(). \ DONE
            // Иначе твоя логика постоянного увеличения массива на один элемент внутри цикла просто отвратительно читается. \ DONE
            //TODO: массив хранит не частоту, а частотЫ (много частот). Название переменной неправильное \ DONE
            var frequency = new double[1];

            List<double> listOfFrequency = new List<double>();



            var j = 0;
            for (var i = start; i <= finish; i += step)
            {
                listOfFrequency.Add(i);
                j++;
            }

            var arrayOfElements = new double [listOfFrequency.Count];
            arrayOfElements = listOfFrequency.ToArray();

            var impedances = _circuit.CalculateZ(arrayOfElements);
            var correctListOfImpedances = new List<string>();

            for (var i = 0; i < impedances.Count; i++)
            {
                correctListOfImpedances.Add(
                    $"R:{Math.Round(impedances[i].Real, 3)} " +
                    $"I:{Math.Round(impedances[i].Imaginary, 3)}");
            }

            for (var i = 0; i < impedances.Count; i++)
            {
                dataGridView.Rows.Add(Math.Round(arrayOfElements[i], 3),
                    correctListOfImpedances[i]);
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Tools.IsCorrectStartFinish(StartTextBox.Text, FinishTextBox.Text);
            CalculateImpedance();
        }

        private void ValidatigTextBox(TextBox textBox)
        {
            if (Tools.IsCellCorrect(textBox.Text) != true)
            {
                Tools.ShowError(textBox.Text);
                textBox.Text = null;
                textBox.Clear();
                return;
            }

            if (Tools.IsCellCorrect(StartTextBox.Text) != true ||
                Tools.IsCellCorrect(FinishTextBox.Text) != true ||
                Tools.IsCellCorrect(StepTextBox.Text) != true)
            {
                CalculateButton.Enabled = false;
                return;
            }

            if (Circuit.Root != null)
            {
                CalculateButton.Enabled = true;
            }
        }

        private void StartTextBox_TextChanged(object sender, EventArgs e)
        {
            if (StartTextBox.Text.Length > 0)
            {
                ValidatigTextBox(StartTextBox);
            }

            Tools.IsCorrectStep(StartTextBox.Text, FinishTextBox.Text, StepTextBox.Text);
        }

        private void FinishTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FinishTextBox.Text.Length > 0)
            {
                ValidatigTextBox(FinishTextBox);
            }

            Tools.IsCorrectStep(StartTextBox.Text, FinishTextBox.Text, StepTextBox.Text);
        }

        private void StepTextBox_TextChanged(object sender, EventArgs e)
        {
            if (StartTextBox.Text.Length > 0)
            {
                ValidatigTextBox(StepTextBox);
            }

            Tools.IsCorrectStep(StartTextBox.Text, FinishTextBox.Text, StepTextBox.Text);
        }

        #endregion

        private void ImpedanceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Circuit = null;
        }
    }
}