using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Model
{
    //TODO: Класс нарушает принципы ООП: Один класс - одна задача! \ DONE
    // Здесь же солянка методов для разных классов без какого-либо принципа \ DONE
    /// <summary>
    ///     Функции для NodeType
    /// </summary>
    public class Tools
    {
        #region Public methods

        /// <summary>
        ///     Проверка на корректность веденных данных
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool IsCellCorrect(string e)
        {
            var formatingString = e.Replace('.', ',');

            //Если число входит в рамки входных данных
            if (double.TryParse(formatingString, out var newValue)
                && !(newValue < 0.1) && newValue <= 1e12)
            {
                //Если число начинаеться с нуля и после нуля нету запятой
                if (formatingString.Length > 1 && formatingString[0] == '0' &&
                    formatingString[1] != ',')
                {
                    return false;
                }

                if (formatingString[0] == ',' || formatingString[0] == '.')
                {
                    return false;
                }

                if (e.Contains(" "))
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        //TODO: Почему класс бизнес-логики знает что-то про пользовательский интерфейс? \ DONE
        public static void ShowError(string text)
        {
            if (text != "")
            {
                MessageBox.Show(
                    "Вы ввели: " + text + "\n" +
                    "Вводимое значение должно удовлетворять следующим условиям:\n " +
                    "-быть положительным числом\n " +
                    "-быть вещественным или натуральным числом\n " +
                    "-быть большим 0,1 по модулю\n " +
                    "-быть меньше 1e12 (1000000000000)\n " +
                    "-запись не должна содержать пробелов\n " +
                    "-запись должна начинаться с цифры\n " +
                    "-использование экспоненциальной записи не допускается\n " +
                    "-eсли первой цифрой числа являтся ноль, значит после него обязательно должна быть запятая.",
                    "Ошибка ввода значения частоты", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///     Создание имени для элемента
        /// </summary>
        /// <param name="nameElements">Латинская буква элемента</param>
        /// <param name="vectorOfElements">Список имен</param>
        /// <returns></returns>
        public static Tuple<char, int> CreateName(char nameElements,
            List<Tuple<char, int>> vectorOfElements)
        {
            vectorOfElements.Sort((p1, p2) => p1.Item2.CompareTo(p2.Item2));
            var j = 1;
            for (var i = 0; i < vectorOfElements.Count; i++)
            {
                if (vectorOfElements[i].Item1 == nameElements)
                {
                    if (vectorOfElements[i].Item2 > j)
                    {
                        return new Tuple<char, int>(nameElements, j);
                    }

                    j++;
                }
            }

            return new Tuple<char, int>(nameElements, j);
            ;
        }

        //TODO: бизнес-логика использует GUI - неправильно! \ DONE
        /// <summary>
        ///     Правильность вводимых данных и их зависимость(Начало, Граница)
        /// </summary>
        /// <param name="startTextBox">Текст с текстбокса "Начало"</param>
        /// <param name="finishTextBox">Текст с текстбокса "Граница"</param>
        public static void IsCorrectStartFinish(string startTextBox,
            string finishTextBox)
        {
            if (startTextBox.Length != 0 && finishTextBox.Length != 0)
            {
                if (double.Parse(startTextBox) > double.Parse(finishTextBox))
                {
                    MessageBox.Show("Начало должно быть меньше границы!");
                    startTextBox = null;
                    finishTextBox = null;
                }
            }
        }

        /// <summary>
        ///     Проверка поля
        /// </summary>
        /// <param name="startTextBox">Текст с текстбокса "Начало"</param>
        /// <param name="finishTextBox">Текст с текстбокса "Граница"</param>
        /// <param name="stepTextBox">Текст с текстбокса "Шаг"</param>
        public static void IsCorrectStep(string startTextBox, string finishTextBox,
            string stepTextBox)
        {
            if (startTextBox.Length != 0 && finishTextBox.Length != 0 &&
                stepTextBox.Length != 0)
            {
                if (double.Parse(finishTextBox) - double.Parse(startTextBox) <
                    double.Parse(stepTextBox))
                {
                    MessageBox.Show(
                        "Разница между началом и концов по модулю не может быть меньше шага!");

                    startTextBox = null;
                    finishTextBox = null;
                    stepTextBox = null;
                }
            }
        }

        #endregion
    }
}