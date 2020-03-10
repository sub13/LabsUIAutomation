using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                float excepted = 5.5F;

                Process proc = Process.Start("Calc"); // Запускаем процесс

                AutomationElement aeDesktop = AutomationElement.RootElement;

                AutomationElement aeForm = null;

                int i = 0;

                while (aeForm == null && i < 50)
                {
                    aeForm = aeDesktop.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Калькулятор"));
                    i++;
                    Thread.Sleep(100);
                    Console.WriteLine("Получаю окно!Ждите");
                }

                if (aeForm == null)
                {
                    Console.WriteLine(proc.ProcessName + "не найден");
                    throw new Exception();
                }

                /////////////////////////////////////НАХОДИМ КНОПКИ С ОКНА!!!!!!!

                // Находим "Открывающая круглая скобка"
                var skobkaButton = aeForm.FindFirst(TreeScope.Descendants,
       new PropertyCondition(AutomationElement.NameProperty, "Открывающая круглая скобка"));
                var skobkaPattern = skobkaButton.GetCurrentPattern(InvokePattern.Pattern)
                                   as InvokePattern;

                // Находим "Один"
                var oneButton = aeForm.FindFirst(TreeScope.Descendants,
       new PropertyCondition(AutomationElement.NameProperty, "Один"));
                var invokePattern = oneButton.GetCurrentPattern(InvokePattern.Pattern)
                                   as InvokePattern;

                // Находим "\"X\" в степени"
                var xInNButton = aeForm.FindFirst(TreeScope.Descendants,
       new PropertyCondition(AutomationElement.NameProperty, "\"X\" в степени"));
                var xInNPattern = xInNButton.GetCurrentPattern(InvokePattern.Pattern)
                                   as InvokePattern;

                // Находим "Минус"
                var minusButton = aeForm.FindFirst(TreeScope.Descendants,
       new PropertyCondition(AutomationElement.NameProperty, "Минус"));
                var minusPattern = minusButton.GetCurrentPattern(InvokePattern.Pattern)
                                   as InvokePattern;

                // Находим "Два"
                var twoButton = aeForm.FindFirst(TreeScope.Descendants,
       new PropertyCondition(AutomationElement.NameProperty, "Два"));
                var twoPattern = twoButton.GetCurrentPattern(InvokePattern.Pattern)
                                   as InvokePattern;

                // Находим "Закрывающая круглая скобка"
                var zakrKrugSkobkaButton = aeForm.FindFirst(TreeScope.Descendants,
       new PropertyCondition(AutomationElement.NameProperty, "Закрывающая круглая скобка"));
                var zakrKrugSkobkaPattern = zakrKrugSkobkaButton.GetCurrentPattern(InvokePattern.Pattern)
                                   as InvokePattern;

                // Находим "Плюс"
                var plusButton = aeForm.FindFirst(TreeScope.Descendants,
       new PropertyCondition(AutomationElement.NameProperty, "Плюс"));
                var plusPattern = plusButton.GetCurrentPattern(InvokePattern.Pattern)
                                   as InvokePattern;

                // Находим "Нуль"
                var zeroButton = aeForm.FindFirst(TreeScope.Descendants,
       new PropertyCondition(AutomationElement.NameProperty, "Нуль"));
                var zeroButtonPattern = zeroButton.GetCurrentPattern(InvokePattern.Pattern)
                                   as InvokePattern;

                // Находим "Разделить на"
                var divideButton = aeForm.FindFirst(TreeScope.Descendants,
       new PropertyCondition(AutomationElement.NameProperty, "Разделить на"));
                var divideButtonPattern = divideButton.GetCurrentPattern(InvokePattern.Pattern)
                                   as InvokePattern;

                // Находим "Три"
                var threeButton = aeForm.FindFirst(TreeScope.Descendants,
      new PropertyCondition(AutomationElement.NameProperty, "Три"));
                var threeButtonPattern = threeButton.GetCurrentPattern(InvokePattern.Pattern)
                                   as InvokePattern;

                // Находим "Равно"
                var equallyButton = aeForm.FindFirst(TreeScope.Descendants,
      new PropertyCondition(AutomationElement.NameProperty, "Равно"));
                var equallyButtonPattern = equallyButton.GetCurrentPattern(InvokePattern.Pattern)
                                   as InvokePattern;

                //Находим "Плюс-минус"
                var minusPlusButton = aeForm.FindFirst(TreeScope.Descendants,
      new PropertyCondition(AutomationElement.NameProperty, " Положительное отрицательное"));
            var minusPlusButtonPattern = minusPlusButton.GetCurrentPattern(InvokePattern.Pattern)
                               as InvokePattern;

            /////////////////////////////////////НАЖИМАЕМ КНОПКИ (решаем уравнение при x = 1)!!!!!!!
            Console.WriteLine($"решаю уравнение при x = 1; Ожидаемое значение:{excepted}");
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:круглую открывающейся скобку");
                skobkaPattern.Invoke(); // нажимаем круглую открывающейся скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:единицу");
                invokePattern.Invoke(); // нажимаем единицу
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:x в степени");
                xInNPattern.Invoke(); // нажимаем x в степени
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:круглую открывающейся скобку");
                skobkaPattern.Invoke(); // нажимаем круглую открывающейся скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:минус");
                minusPattern.Invoke(); // нажимаем минус
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:два");
                twoPattern.Invoke(); // нажимаем два
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:закрывающейся круглую скобку");
                zakrKrugSkobkaPattern.Invoke(); // нажимаем закрывающейся круглую скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:плюс");
                plusPattern.Invoke(); // нажимаем плюс
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:один");
                invokePattern.Invoke(); // нажимаем один
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:ноль");
                zeroButtonPattern.Invoke(); // нажимаем ноль
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:закрываюзейся круглую скобку");
                zakrKrugSkobkaPattern.Invoke(); // нажимаем закрываюзейся круглую скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:разделить на");
                divideButtonPattern.Invoke(); // нажимаем разделить на
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:круглую открывающейся скобку");
                skobkaPattern.Invoke(); // нажимаем круглую открывающейся скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:один");
                invokePattern.Invoke(); // нажимаем один
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:x в степени");
                xInNPattern.Invoke(); // нажимаем x в степени
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:тройку");
                threeButtonPattern.Invoke(); // нажимаем тройку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:плюс");
                plusPattern.Invoke(); // нажимаем плюс
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:один");
                invokePattern.Invoke(); // нажимаем один
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:закрываюзейся круглую скобку");
                zakrKrugSkobkaPattern.Invoke(); // нажимаем закрываюзейся круглую скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:равно");
                equallyButtonPattern.Invoke(); // нажимаем равно

                var result1 = aeForm.FindFirst(
            TreeScope.Descendants,
            new PropertyCondition(AutomationElement.AutomationIdProperty, "CalculatorResults"));
                Console.WriteLine("Результат:" + result1.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString());
                Console.WriteLine("Нажмите любую кнопку для продолжения!");
                Console.ReadKey();

                //InvokePattern click = (InvokePattern)aeTextBox.GetCurrentPattern(InvokePattern.Pattern);
                //click.Invoke();


                /////////////////////////////////////НАЖИМАЕМ КНОПКИ (решаем уравнение при x = 0)!!!!!!!

                int excepted3 = 10;
                Console.WriteLine($"решаю уравнение при x = 0; Ожидаемое значение:{excepted3}");
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:круглую открывающейся скобку");
                skobkaPattern.Invoke(); // нажимаем круглую открывающейся скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:ноль");
                zeroButtonPattern.Invoke(); // нажимаем ноль
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:x в степени");
                xInNPattern.Invoke(); // нажимаем x в степени
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:круглую открывающейся скобку");
                skobkaPattern.Invoke(); // нажимаем круглую открывающейся скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:минус");
                minusPattern.Invoke(); // нажимаем минус
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:два");
                twoPattern.Invoke(); // нажимаем два
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:закрывающейся круглую скобку");
                zakrKrugSkobkaPattern.Invoke(); // нажимаем закрывающейся круглую скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:плюс");
                plusPattern.Invoke(); // нажимаем плюс
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:единицу");
                invokePattern.Invoke(); // нажимаем один
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:ноль");
                zeroButtonPattern.Invoke(); // нажимаем ноль
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:закрываюзейся круглую скобку");
                zakrKrugSkobkaPattern.Invoke(); // нажимаем закрываюзейся круглую скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:разделить на");
                divideButtonPattern.Invoke(); // нажимаем разделить на
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:круглую открывающейся скобку");
                skobkaPattern.Invoke(); // нажимаем круглую открывающейся скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:ноль");
                zeroButtonPattern.Invoke(); // нажимаем ноль
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:x в степени");
                xInNPattern.Invoke(); // нажимаем x в степени
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:тройку");
                threeButtonPattern.Invoke(); // нажимаем тройку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:плюс");
                plusPattern.Invoke(); // нажимаем плюс
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:ноль");
                invokePattern.Invoke(); // нажимаем ноль
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:закрываюзейся круглую скобку");
                zakrKrugSkobkaPattern.Invoke(); // нажимаем закрываюзейся круглую скобку
                Thread.Sleep(1000);
                Console.WriteLine("Нажимаю:равно");
                equallyButtonPattern.Invoke(); // нажимаем равно

                var result3 = aeForm.FindFirst(
            TreeScope.Descendants,
            new PropertyCondition(AutomationElement.AutomationIdProperty, "CalculatorResults"));
                Console.WriteLine("Результат:" + result3.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString());
                Console.WriteLine("Нажмите любую кнопку для продолжения!");
                Console.ReadKey();


                /////////////////////////////////////НАЖИМАЕМ КНОПКИ (решаем уравнение при x = -1)!!!!!!!
                string excepted2 = "Деление на ноль невозможно!";
            Console.WriteLine($"решаю уравнение при x = -1; Ожидаемое значение:{excepted2}");
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:круглую открывающейся скобку");
            skobkaPattern.Invoke(); // нажимаем круглую открывающейся скобку
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:единицу");
            invokePattern.Invoke(); // нажимаем единицу
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:плюс-минус");
            minusPlusButtonPattern.Invoke(); // нажимаем плюс-минус
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:x в степени");
            xInNPattern.Invoke(); // нажимаем x в степени
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:круглую открывающейся скобку");
            skobkaPattern.Invoke(); // нажимаем круглую открывающейся скобку
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:минус");
            minusPattern.Invoke(); // нажимаем минус
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:два");
            twoPattern.Invoke(); // нажимаем два
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:закрывающейся круглую скобку");
            zakrKrugSkobkaPattern.Invoke(); // нажимаем закрывающейся круглую скобку
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:плюс");
            plusPattern.Invoke(); // нажимаем плюс
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:один");
            invokePattern.Invoke(); // нажимаем один
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:ноль");
            zeroButtonPattern.Invoke(); // нажимаем ноль
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:закрываюзейся круглую скобку");
            zakrKrugSkobkaPattern.Invoke(); // нажимаем закрываюзейся круглую скобку
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:разделить на");
            divideButtonPattern.Invoke(); // нажимаем разделить на
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:круглую открывающейся скобку");
            skobkaPattern.Invoke(); // нажимаем круглую открывающейся скобку
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:один");
            invokePattern.Invoke(); // нажимаем один
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:плюс-минус");
            minusPlusButtonPattern.Invoke(); // нажимаем плюс-минус
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:x в степени");
            xInNPattern.Invoke(); // нажимаем x в степени
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:тройку");
            threeButtonPattern.Invoke(); // нажимаем тройку
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:плюс");
            plusPattern.Invoke(); // нажимаем плюс
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:один");
            invokePattern.Invoke(); // нажимаем один
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:закрываюзейся круглую скобку");
            zakrKrugSkobkaPattern.Invoke(); // нажимаем закрываюзейся круглую скобку
            Thread.Sleep(1000);
            Console.WriteLine("Нажимаю:равно");
            equallyButtonPattern.Invoke(); // нажимаем равно

            var result2 = aeForm.FindFirst(
        TreeScope.Descendants,
        new PropertyCondition(AutomationElement.AutomationIdProperty, "CalculatorResults"));
            string result2String = result2.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();
            Console.WriteLine("Результат:" + result2String);
            Console.WriteLine("Нажмите любую кнопку для продолжения!");
            Console.ReadKey();
            }
            catch (Exception e)
            {
               Console.WriteLine($"Ошибка при выполнении теста: {e.Message}");
              Console.ReadKey();
            }


        }
    }
}
