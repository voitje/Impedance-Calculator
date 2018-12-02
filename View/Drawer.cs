using Model.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Linq;
using Model;

namespace View
{
    /// <summary>
    /// Рисовальщик цепи.
    /// </summary>
    public static class Drawer
    {
        #region - - Поля - -

        /// <summary>
        /// Сдвиг по X для отрисовки имени.
        /// </summary>
        private static readonly int _nameDisplasemantX = 15;

        /// <summary>
        /// Сдвиг по Y для отрисовки имени.
        /// </summary>
        private static readonly int _nameDisplasemantY = 40;

        /// <summary>
        /// Координата X резистора.
        /// </summary>
        private static readonly int _resistorPositionX = 10;

        /// <summary>
        /// Координата Y резистора.
        /// </summary>
        private static readonly int _resistorPositionY = 20;

        /// <summary>
        /// Высота резистора.
        /// </summary>
        private static readonly int _resistorHight = 10;

        /// <summary>
        /// Ширина резистора.
        /// </summary>
        private static readonly int _resistorWidth = 30;

        /// <summary>
        /// Координата X первой пластины конденсатора.
        /// </summary>
        private static readonly int _firstPlatePosition = 20;

        /// <summary>
        /// Координата X второй пластины конденсатора.
        /// </summary>
        private static readonly int _secondPlatePosition = 30;

        /// <summary>
        /// Высота конденсатора.
        /// </summary>
        private static readonly int _capacitorHight = 20;

        /// <summary>
        /// Количество дуг катушки.
        /// </summary>
        private static readonly int _arcCount = 3;

        /// <summary>
        /// Диаметр дуги.
        /// </summary>
        private static readonly int _arcDiameter = 10;

        /// <summary>
        /// Координата X катушки.
        /// </summary>
        private static readonly int _inductorPositionX = 10;

        /// <summary>
        /// Координата Y катушки.
        /// </summary>
        private static readonly int _inductorPositionY = 20;

        /// <summary>
        /// Сдвиг линий по Y.
        /// </summary>
        private static readonly int _lineDisplasemantY = 25;

        /// <summary>
        /// Длинна добавочной линии по X.
        /// </summary>
        private static readonly int _lineLengthX = 25;

        /// <summary>
        /// Длинна добавочной линии по Y.
        /// </summary>
        private static readonly int _lineLengthY = 40;

        /// <summary>
        /// Длинна элемента цепи по X.
        /// </summary>
        private static readonly int _elementLengthX = 50;


        /// <summary>
        /// Формат текста.
        /// </summary>
        private static Font _font;

        /// <summary>
        /// Поверхность рисования.
        /// </summary>
        private static Graphics _graphics;

        /// <summary>
        /// Ручка.
        /// </summary>
        private static Pen _pen;

        #endregion

        #region - - Свойства - -

        /// <summary>
        /// Формат текста.
        /// </summary>
        public static Font Font
        {
            get => _font;
            set => _font = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Поверхность рисования.
        /// </summary>
        public static Graphics Graphics
        {
            get => _graphics;
            set => _graphics = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Ручка.
        /// </summary>
        public static Pen Pen
        {
            get => _pen;
            set => _pen = value ?? throw new ArgumentNullException(nameof(value));
        }

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Рисовать схему электрической цепи.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="displacement">Смещение.</param>
        /// <returns>Размер поддерева.</returns>
        public static Point DrawCircuit(INode root,
            Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
            }

            if (root is ElementBase elementBase)
            {
                DrawElement(elementBase, displacement);
                return new Point(1, 1);
            }

            return root is SerialSubcircuit
                ? DrawSerialConnection(root, displacement)
                : DrawParallelConnection(root, displacement);
        }

        #endregion

        #region - - Приватные методы - -

        /// <summary>
        /// Рисовать последовательное соединение.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="displacement">Смещение.</param>
        /// <returns>Размер поддерева.</returns>
        private static Point DrawSerialConnection(INode root,
            Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
            }

            var maxCount = 0;
            var steps = new List<int>();

            foreach (var child in root.Nodes)
            {
                var count = DrawCircuit(child,
                    new Point(steps.Sum() * _elementLengthX + displacement.X,
                        displacement.Y));

                steps.Add(count.X);

                if (maxCount < count.Y)
                {
                    maxCount = count.Y;
                }
            }

            return new Point(steps.Sum(), maxCount);
        }

        /// <summary>
        /// Рисовать параллельное соединение.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="displacement">Смещение.</param>
        /// <returns>Размер поддерева.</returns>
        private static Point DrawParallelConnection(INode root,
            Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
            }

            var maxCount = 0;
            var steps = new List<int>();

            Graphics.DrawLine(Pen,
                    new Point(displacement.X,
                        _lineDisplasemantY + displacement.Y),
                    new Point(_lineLengthX + displacement.X,
                        _lineDisplasemantY + displacement.Y));

            for (var i = 0; i < root.Nodes.Count; i++)
            {
                var count = DrawCircuit(root.Nodes[i],
                    new Point(_lineLengthX + displacement.X,
                        steps.Sum() * _lineLengthY + displacement.Y));

                steps.Add(count.Y);

                if (maxCount < count.X)
                {
                    var step = 0;
                    for (var j = 0; j < i; j++)
                    {
                        Graphics.DrawLine(Pen,
                            new Point(
                                _lineLengthX + maxCount * _elementLengthX +
                                displacement.X,
                                _lineDisplasemantY + step * _lineLengthY +
                                displacement.Y),
                            new Point(
                                _lineLengthX + count.X * _elementLengthX +
                                displacement.X,
                                _lineDisplasemantY + step * _lineLengthY +
                                displacement.Y));

                        step += steps[j];
                    }

                    maxCount = count.X;
                }
                else
                {
                    var step = 0;
                    for (var j = 0; j < i; j++)
                    {
                        step += steps[j];
                    }

                    Graphics.DrawLine(Pen,
                        new Point(
                            _lineLengthX + count.X * _elementLengthX +
                            displacement.X,
                            _lineDisplasemantY + step * _lineLengthY +
                            displacement.Y),
                        new Point(
                            _lineLengthX + maxCount * _elementLengthX +
                            displacement.X,
                            _lineDisplasemantY + step * _lineLengthY +
                            displacement.Y));
                }
            }

            Graphics.DrawLine(Pen,
                new Point(
                    _lineLengthX + maxCount * _elementLengthX + displacement.X,
                    _lineDisplasemantY + displacement.Y),
                new Point(
                    2 * _lineLengthX + maxCount * _elementLengthX +
                    displacement.X, _lineDisplasemantY + displacement.Y));

            if (steps.Count != 0)
            {
                Graphics.DrawLine(Pen,
                    new Point(_lineLengthX + displacement.X,
                        _lineDisplasemantY + displacement.Y),
                    new Point(_lineLengthX + displacement.X,
                        _lineDisplasemantY + (steps.Sum() - steps[steps.Count - 1]) *
                        _lineLengthY +
                        displacement.Y));


                Graphics.DrawLine(Pen,
                    new Point(
                        _lineLengthX + maxCount * _elementLengthX + displacement.X,
                        _lineDisplasemantY + displacement.Y),
                    new Point(
                        _lineLengthX + maxCount * _elementLengthX + displacement.X,
                        _lineDisplasemantY + (steps.Sum() - steps[steps.Count - 1]) *
                        _lineLengthY +
                        displacement.Y));
            }

            return new Point(maxCount + 1, steps.Sum());
        }

        /// <summary>
        /// Рисовать элемент электрической цепи.
        /// </summary>
        /// <param name="element">Элемент электрической цепи.</param>
        /// <param name="displacement">Смещение.</param>
        private static void DrawElement(ElementBase element,
            Point displacement)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
            }

            var brush = new SolidBrush(Color.Black);
            switch (element)
            {
                case Resistor _:
                    DrawResistor(displacement);
                    break;
                case Capacitor _:
                    DrawCapacitor(displacement);
                    break;
                case Inductor _:
                    DrawInductor(displacement);
                    break;
            }

            Graphics.DrawString(element.Name, Font, brush,
                _nameDisplasemantX + displacement.X,
                _nameDisplasemantY + displacement.Y);
        }

        /// <summary>
        /// Рисовать резистор.
        /// </summary>
        /// <param name="displacement">Смещение.</param>
        private static void DrawResistor(Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
            }

            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + displacement.Y),
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + _resistorHight + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + _resistorHight + displacement.Y),
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + _resistorHight + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + displacement.Y),
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + _resistorHight + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _resistorPositionY + displacement.Y),
                new Point(_resistorPositionX + displacement.X,
                    _resistorPositionY + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(displacement.X, _lineDisplasemantY + displacement.Y),
                new Point(_resistorPositionX + displacement.X,
                    _lineDisplasemantY + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_resistorPositionX + _resistorWidth + displacement.X,
                    _lineDisplasemantY + displacement.Y),
                new Point(_elementLengthX + displacement.X,
                    _lineDisplasemantY + displacement.Y));
        }

        /// <summary>
        /// Рисовать конденсатор.
        /// </summary>
        /// <param name="displacement">Смещение.</param>
        private static void DrawCapacitor(Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
            }

            Graphics.DrawLine(Pen,
                new Point(_firstPlatePosition + displacement.X,
                    _lineDisplasemantY - _capacitorHight / 2 + displacement.Y),
                new Point(_firstPlatePosition + displacement.X,
                    _lineDisplasemantY + _capacitorHight / 2 + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_secondPlatePosition + displacement.X,
                    _lineDisplasemantY - _capacitorHight / 2 + displacement.Y),
                new Point(_secondPlatePosition + displacement.X,
                    _lineDisplasemantY + _capacitorHight / 2 + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(displacement.X, _lineDisplasemantY + displacement.Y),
                new Point(_firstPlatePosition + displacement.X,
                    _lineDisplasemantY + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(_secondPlatePosition + displacement.X,
                    _lineDisplasemantY + displacement.Y),
                new Point(_elementLengthX + displacement.X,
                    _lineDisplasemantY + displacement.Y));
        }

        /// <summary>
        /// Рисовать катушку.
        /// </summary>
        /// <param name="displacement">Смещение.</param>
        private static void DrawInductor(Point displacement)
        {
            if (displacement == null)
            {
                throw new ArgumentNullException(nameof(displacement));
            }

            for (var i = 0; i < _arcCount; i++)
            {
                Graphics.DrawArc(Pen,
                    _inductorPositionX + i * _arcDiameter + displacement.X,
                    _inductorPositionY + displacement.Y,
                    _arcDiameter, _arcDiameter, 0, -180);
            }

            Graphics.DrawLine(Pen,
                new Point(displacement.X, _lineDisplasemantY + displacement.Y),
                new Point(_inductorPositionX + displacement.X,
                    _lineDisplasemantY + displacement.Y));

            Graphics.DrawLine(Pen,
                new Point(
                    _inductorPositionX + _arcCount * _arcDiameter +
                    displacement.X,
                    _lineDisplasemantY + displacement.Y),
                new Point(_elementLengthX + displacement.X,
                    _lineDisplasemantY + displacement.Y));
        }
        #endregion
    }
}
