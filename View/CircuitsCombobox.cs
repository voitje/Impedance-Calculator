using System.Collections.Generic;
using Model;
using Model.Elements;

namespace View
{
    //TODO: неправильное название. Это не комбобокс. Это генератор тестовых цепей
    /// <summary>
    ///     Класс для создание готовых цепей
    /// </summary>
    public class CircuitsComboBox
    {
        #region Public methods

        public void CreateCircuit(string selectedState,
            List<Tools.Pair<char, int>> vectorOfElements, Circuit circuit)
        {
            //TODO: лучше бы, конечно, по индексу, чем по русской строке с номером
            if (selectedState == "Цепь №1")
            {
                var resistor = new Resistor("R1", 10);
                var inductor = new Inductor("L1", 50);
                var capacitor = new Capacitor("C1", 15);

                vectorOfElements.Clear();

                vectorOfElements.Add(new Tools.Pair<char, int>('R', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('C', 1));

                var parallelSubcircuit = new ParallelSubcircuit();
                parallelSubcircuit.Nodes.Add(capacitor);
                parallelSubcircuit.Nodes.Add(inductor);
                inductor.Parent = parallelSubcircuit;
                capacitor.Parent = parallelSubcircuit;

                var serialSubcircuit = new SerialSubcircuit();
                serialSubcircuit.Nodes.Add(parallelSubcircuit);
                serialSubcircuit.Nodes.Add(resistor);
                parallelSubcircuit.Parent = serialSubcircuit;
                resistor.Parent = serialSubcircuit;

                circuit.Clean();
                circuit.Add(null, serialSubcircuit);
            }

            if (selectedState == "Цепь №2")
            {
                var capacitor1 = new Capacitor("C1", 20);
                var inductor2 = new Inductor("L1", 20);
                var resistor3 = new Resistor("R1", 20);
                var inductor4 = new Inductor("L2", 20);

                vectorOfElements.Clear();

                vectorOfElements.Add(new Tools.Pair<char, int>('C', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('R', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 2));

                var parallelSubcircuit1 = new ParallelSubcircuit();
                parallelSubcircuit1.Nodes.Add(capacitor1);
                capacitor1.Parent = parallelSubcircuit1;

                var serialSubcircuit1 = new SerialSubcircuit();
                parallelSubcircuit1.Nodes.Add(serialSubcircuit1);
                serialSubcircuit1.Parent = parallelSubcircuit1;

                serialSubcircuit1.Nodes.Add(inductor2);
                inductor2.Parent = serialSubcircuit1;

                var parallelSubcircuit2 = new ParallelSubcircuit();
                parallelSubcircuit2.Nodes.Add(resistor3);
                resistor3.Parent = parallelSubcircuit2;
                parallelSubcircuit2.Nodes.Add(inductor4);
                inductor4.Parent = parallelSubcircuit2;

                serialSubcircuit1.Nodes.Add(parallelSubcircuit2);
                parallelSubcircuit2.Parent = serialSubcircuit1;
                circuit.Clean();
                circuit.Add(null, parallelSubcircuit1);
            }

            if (selectedState == "Цепь №3")
            {
                var resistor1 = new Resistor("R1", 20);
                var inductor2 = new Inductor("L1", 20);
                var inductor3 = new Inductor("L2", 20);
                var inductor4 = new Inductor("L3", 20);
                var resistor5 = new Resistor("R2", 20);
                var resistor6 = new Resistor("R3", 20);
                var inductor7 = new Inductor("L4", 20);

                vectorOfElements.Clear();

                vectorOfElements.Add(new Tools.Pair<char, int>('R', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('R', 2));
                vectorOfElements.Add(new Tools.Pair<char, int>('R', 3));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 2));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 3));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 4));

                var parallelSubcircuit1 = new ParallelSubcircuit();

                var serialSubcircuit1 = new SerialSubcircuit();
                var serialSubcircuit2 = new SerialSubcircuit();

                parallelSubcircuit1.Nodes.Add(serialSubcircuit1);
                serialSubcircuit1.Parent = parallelSubcircuit1;
                parallelSubcircuit1.Nodes.Add(serialSubcircuit2);
                serialSubcircuit2.Parent = parallelSubcircuit1;

                var parallelSubcircuit2 = new ParallelSubcircuit();
                var parallelSubcircuit3 = new ParallelSubcircuit();

                serialSubcircuit1.Nodes.Add(inductor3);
                inductor3.Parent = serialSubcircuit1;
                serialSubcircuit1.Nodes.Add(parallelSubcircuit2);
                parallelSubcircuit2.Parent = serialSubcircuit1;
                parallelSubcircuit2.Nodes.Add(resistor1);
                resistor1.Parent = parallelSubcircuit2;
                parallelSubcircuit2.Nodes.Add(inductor4);
                inductor4.Parent = parallelSubcircuit2;

                serialSubcircuit2.Nodes.Add(inductor2);
                inductor2.Parent = serialSubcircuit2;
                serialSubcircuit2.Nodes.Add(resistor5);
                resistor5.Parent = serialSubcircuit2;
                serialSubcircuit2.Nodes.Add(parallelSubcircuit3);
                parallelSubcircuit3.Parent = serialSubcircuit2;
                parallelSubcircuit3.Nodes.Add(resistor6);
                resistor6.Parent = parallelSubcircuit3;
                parallelSubcircuit3.Nodes.Add(inductor7);
                inductor7.Parent = parallelSubcircuit3;
                circuit.Clean();
                circuit.Add(null, parallelSubcircuit1);
            }

            if (selectedState == "Цепь №4")
            {
                var resistor1 = new Resistor("R1", 1);
                var capacitor2 = new Capacitor("C1", 20);
                var resistor3 = new Resistor("R2", 20);
                var inductor4 = new Inductor("L1", 20);
                var resistor5 = new Resistor("R3", 20);
                var inductor6 = new Inductor("L2", 20);

                vectorOfElements.Clear();

                vectorOfElements.Add(new Tools.Pair<char, int>('L', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 2));
                vectorOfElements.Add(new Tools.Pair<char, int>('R', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('R', 2));
                vectorOfElements.Add(new Tools.Pair<char, int>('C', 1));

                var serialSubcircuit1 = new SerialSubcircuit();
                var parallelSubcircuit1 = new ParallelSubcircuit();
                var parallelSubcircuit2 = new ParallelSubcircuit();

                serialSubcircuit1.Nodes.Add(parallelSubcircuit1);
                parallelSubcircuit1.Parent = serialSubcircuit1;
                serialSubcircuit1.Nodes.Add(parallelSubcircuit2);
                parallelSubcircuit2.Parent = serialSubcircuit1;
                serialSubcircuit1.Nodes.Add(resistor3);
                resistor3.Parent = serialSubcircuit1;
                parallelSubcircuit1.Nodes.Add(resistor1);
                resistor1.Parent = parallelSubcircuit1;
                parallelSubcircuit1.Nodes.Add(inductor4);
                inductor4.Parent = parallelSubcircuit1;
                parallelSubcircuit2.Nodes.Add(capacitor2);
                capacitor2.Parent = parallelSubcircuit2;
                parallelSubcircuit2.Nodes.Add(resistor5);
                resistor5.Parent = parallelSubcircuit2;
                parallelSubcircuit2.Nodes.Add(inductor6);
                inductor6.Parent = parallelSubcircuit2;
                circuit.Clean();
                circuit.Add(null, serialSubcircuit1);
            }

            if (selectedState == "Цепь №5")
            {
                var resistor1 = new Resistor("R1", 20);
                var capacitor2 = new Capacitor("C1", 20);
                var resistor3 = new Resistor("R2", 20);
                var inductor4 = new Inductor("L1", 20);
                var resistor5 = new Resistor("R3", 20);
                var inductor6 = new Inductor("L2", 20);
                var resistor7 = new Resistor("R4", 20);
                var inductor8 = new Inductor("L3", 20);

                vectorOfElements.Clear();

                vectorOfElements.Add(new Tools.Pair<char, int>('R', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('R', 2));
                vectorOfElements.Add(new Tools.Pair<char, int>('R', 3));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 4));
                vectorOfElements.Add(new Tools.Pair<char, int>('C', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 1));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 2));
                vectorOfElements.Add(new Tools.Pair<char, int>('L', 3));

                var serialSubcircuit1 = new SerialSubcircuit();
                var serialSubcircuit2 = new SerialSubcircuit();
                var parallelSubcircuit1 = new ParallelSubcircuit();
                var parallelSubcircuit2 = new ParallelSubcircuit();
                var parallelSubcircuit3 = new ParallelSubcircuit();
                serialSubcircuit1.Nodes.Add(parallelSubcircuit1);
                parallelSubcircuit1.Parent = serialSubcircuit1;
                parallelSubcircuit1.Nodes.Add(resistor1);
                resistor1.Parent = parallelSubcircuit1;
                parallelSubcircuit1.Nodes.Add(inductor4);
                inductor4.Parent = parallelSubcircuit1;

                serialSubcircuit1.Nodes.Add(parallelSubcircuit2);
                parallelSubcircuit2.Parent = serialSubcircuit1;
                parallelSubcircuit2.Nodes.Add(capacitor2);
                capacitor2.Parent = parallelSubcircuit2;
                parallelSubcircuit2.Nodes.Add(serialSubcircuit2);
                serialSubcircuit2.Parent = parallelSubcircuit2;
                serialSubcircuit2.Nodes.Add(parallelSubcircuit3);
                parallelSubcircuit3.Parent = serialSubcircuit2;
                serialSubcircuit2.Nodes.Add(resistor7);
                resistor7.Parent = serialSubcircuit2;
                parallelSubcircuit3.Nodes.Add(resistor5);
                resistor5.Parent = parallelSubcircuit3;
                parallelSubcircuit3.Nodes.Add(inductor8);
                inductor8.Parent = parallelSubcircuit3;
                parallelSubcircuit2.Nodes.Add(inductor6);
                inductor6.Parent = parallelSubcircuit2;
                serialSubcircuit1.Nodes.Add(resistor3);
                resistor3.Parent = serialSubcircuit1;
                circuit.Clean();
                circuit.Add(null, serialSubcircuit1);
            }
        }

        #endregion
    }
}