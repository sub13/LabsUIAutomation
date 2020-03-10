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
                // ��������� �������� �����
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("input.xml");
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    // ������� ��� �������� ���� �������� user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // ���� ���� - company
                        if (childnode.Name == "perem1")
                        {
                            perems.Add(childnode.InnerText);
                        }
                        // ���� ���� age
                        if (childnode.Name == "perem2")
                        {
                            perems.Add(childnode.InnerText);
                        }
                    }
                }

                    //��������� ������� ������ ����������
                Process p = Process.Start("..\\..\\..\\StatCalc\\bin\\Debug\\StatCalc.exe");
                Thread.Sleep(2000); // �� ������ ������ ������ ��������

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
                    throw new Exception("���� �� ���� ��������");


                //////////////////////////////////////////////////////////�������� ��� ��������
                AutomationElement aeButton = aeForm.FindFirst(TreeScope.Children,
                  new PropertyCondition(AutomationElement.NameProperty, "���������"));

                AutomationElementCollection aeAllTextBoxes = aeForm.FindAll(TreeScope.Children,
                  new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)); // �������� textbox

                AutomationElement aeTextBox1 = aeAllTextBoxes[1]; // ���������� textbox � ������
                AutomationElement aeTextBox2 = aeAllTextBoxes[0];

                AutomationElement aeRadioButton1 = aeForm.FindFirst(TreeScope.Descendants,
                  new PropertyCondition(AutomationElement.NameProperty, "�����"));

                AutomationElement aeRadioButton2 = aeForm.FindFirst(TreeScope.Descendants,
                  new PropertyCondition(AutomationElement.NameProperty, "������������"));

                ValuePattern vpTextBox1 = (ValuePattern)aeTextBox1.GetCurrentPattern(ValuePattern.Pattern);
                vpTextBox1.SetValue(perems[0] + " " + perems[1]);


                Thread.Sleep(1000);

                //�������� ������� ������
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

                //���� ����� 1
                if (result[0] == "1800,0000")
                {
                    Console.WriteLine("\n����1 ������ �������");
                }
                else
                {
                    Console.WriteLine("\n����1 ��������");
                }

                //���� ����� 2
                vpTextBox1.SetValue(perems[2] + " " + perems[3]);
                Thread.Sleep(1000);
                ipSelectRadioButton1.Select();
                Thread.Sleep(1000);
                ipClickButton1.Invoke();
                Thread.Sleep(1000);
                result[1] = (string)aeTextBox2.GetCurrentPropertyValue(ValuePattern.ValueProperty);

                if (result[1] == "-182,0000")
                {
                    Console.WriteLine("\n����2 ������ �������");
                }
                else
                {
                    Console.WriteLine("\n����2 ��������");
                }

                // ���� ����� 3

                vpTextBox1.SetValue(perems[4] + " " + perems[5]);
                Thread.Sleep(1000);
                ipSelectRadioButton1.Select();
                Thread.Sleep(1000);
                ipClickButton1.Invoke();
                Thread.Sleep(1000);
                result[2] = (string)aeTextBox2.GetCurrentPropertyValue(ValuePattern.ValueProperty);

                if (result[2] == "-10001,0000")
                {
                    Console.WriteLine("\n����3 ������ �������");
                }
                else
                {
                    Console.WriteLine("\n����3 ��������");
                }

                Console.WriteLine("\n���������� ��������� ����� 5 ������");
                Thread.Sleep(5000);
                // �������� ������� �������� �����
                WindowPattern wpCloseForm =
                  (WindowPattern)aeForm.GetCurrentPattern(WindowPattern.Pattern);
                wpCloseForm.Close();

                Console.WriteLine("\n����� ���������!\n���������� ����� ������� � xml ���������: 'output.xml'");
                //���������� ���������� �����

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
                Console.WriteLine("��� ������� �������� ���������, ��������� ������!: " + ex.Message);
                Console.ReadLine();
            }
        }


        //static string read_data_from_xml()
        //{

        //}

    }
}
