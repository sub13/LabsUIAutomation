using System;
using System.Windows.Automation;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using System.Collections.Generic;

namespace TestScenario
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> perems = new List<string>();
                // Загружаем значения теста
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("input.xml");
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // если узел - company
                        if (childnode.Name == "perem1")
                        {
                            perems.Add(childnode.InnerText);
                        }
                        // если узел age
                        if (childnode.Name == "perem2")
                        {
                            perems.Add(childnode.InnerText);
                        }
                    }
                }

                    //запускаем процесс нашего приложения
                Process p = Process.Start("..\\..\\..\\StatCalc\\bin\\Debug\\StatCalc.exe");
                Thread.Sleep(2000); // на всякий случай ставим задержку

                AutomationElement aeDesktop = AutomationElement.RootElement;

                AutomationElement aeForm = null;

                int numWaits = 0;

                do
                {
                    aeForm = aeDesktop.FindFirst(TreeScope.Children,
                      new PropertyCondition(AutomationElement.NameProperty, "StatCalc"));

                    ++numWaits;

                    Thread.Sleep(100);
                }
                while (aeForm == null && numWaits < 50);

                if (aeForm == null)
                    throw new Exception("Окно не было получено");


                //////////////////////////////////////////////////////////Получаем все элементы
                AutomationElement aeButton = aeForm.FindFirst(TreeScope.Children,
                  new PropertyCondition(AutomationElement.NameProperty, "Расчитать"));

                AutomationElementCollection aeAllTextBoxes = aeForm.FindAll(TreeScope.Children,
                  new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)); // получаем textbox

                AutomationElement aeTextBox1 = aeAllTextBoxes[1]; // закидываем textbox в массив
                AutomationElement aeTextBox2 = aeAllTextBoxes[0];

                AutomationElement aeRadioButton1 = aeForm.FindFirst(TreeScope.Descendants,
                  new PropertyCondition(AutomationElement.NameProperty, "Сумма"));

                AutomationElement aeRadioButton2 = aeForm.FindFirst(TreeScope.Descendants,
                  new PropertyCondition(AutomationElement.NameProperty, "Произведение"));

                ValuePattern vpTextBox1 = (ValuePattern)aeTextBox1.GetCurrentPattern(ValuePattern.Pattern);
                vpTextBox1.SetValue(perems[0] + " " + perems[1]);


                Thread.Sleep(1000);

                //Получаем круглые кнопки
                SelectionItemPattern ipSelectRadioButton2 =
                  (SelectionItemPattern)aeRadioButton2.GetCurrentPattern(SelectionItemPattern.Pattern);
                SelectionItemPattern ipSelectRadioButton1 =
                  (SelectionItemPattern)aeRadioButton1.GetCurrentPattern(SelectionItemPattern.Pattern);

                ipSelectRadioButton2.Select();


                Thread.Sleep(1000);
                InvokePattern ipClickButton1 =
                  (InvokePattern)aeButton.GetCurrentPattern(InvokePattern.Pattern);
                ipClickButton1.Invoke();
                Thread.Sleep(1500);

                string[] result = new string[3]; 
                    
                result[0] =
                  (string)aeTextBox2.GetCurrentPropertyValue(ValuePattern.ValueProperty);

                //Тест номер 1
                if (result[0] == "1800,0000")
                {
                    Console.WriteLine("\nТест1 прошёл успешно");
                }
                else
                {
                    Console.WriteLine("\nТест1 провален");
                }

                //Тест номер 2
                vpTextBox1.SetValue(perems[2] + " " + perems[3]);
                Thread.Sleep(1000);
                ipSelectRadioButton1.Select();
                Thread.Sleep(1000);
                ipClickButton1.Invoke();
                Thread.Sleep(1000);
                result[1] = (string)aeTextBox2.GetCurrentPropertyValue(ValuePattern.ValueProperty);

                if (result[1] == "-182,0000")
                {
                    Console.WriteLine("\nТест2 прошёл успешно");
                }
                else
                {
                    Console.WriteLine("\nТест2 провален");
                }

                // Тест номер 3

                vpTextBox1.SetValue(perems[4] + " " + perems[5]);
                Thread.Sleep(1000);
                ipSelectRadioButton1.Select();
                Thread.Sleep(1000);
                ipClickButton1.Invoke();
                Thread.Sleep(1000);
                result[2] = (string)aeTextBox2.GetCurrentPropertyValue(ValuePattern.ValueProperty);

                if (result[2] == "-10001,0000")
                {
                    Console.WriteLine("\nТест3 прошёл успешно");
                }
                else
                {
                    Console.WriteLine("\nТест3 провален");
                }

                Console.WriteLine("\nПриложение закроется через 5 секунд");
                Thread.Sleep(5000);
                // получаем элемент закрытия формы
                WindowPattern wpCloseForm =
                  (WindowPattern)aeForm.GetCurrentPattern(WindowPattern.Pattern);
                wpCloseForm.Close();

                Console.WriteLine("\nТесты закончены!\nРезультаты можно увидеть в xml документе: 'output.xml'");
                //Записываем результаты теста

                XmlDocument xDocOutput = new XmlDocument();
                xDocOutput.Load("output.xml");
                XmlElement xRoot2 = xDocOutput.DocumentElement;
                int i = 0;
                foreach (XmlNode xnode in xRoot2)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "results")
                        {
                            XmlText nameText = xDocOutput.CreateTextNode(result[i]);
                            childnode.AppendChild(nameText);
                            i++;
                        }
                    }
                }
                xDocOutput.Save("output.xml");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("При запуске тестовой программы, произошла ошибка!: " + ex.Message);
                Console.ReadLine();
            }
        }


        //static string read_data_from_xml()
        //{

        //}

    }
}
