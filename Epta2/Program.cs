using System;

namespace Epta2
{
    public class Calculat
    {
        private static void Main(string[] args)
        {
            var Calc = new Calculator();
            string x;
            while (true)
            {
                Console.WriteLine("Введите выражение для подсчета или е для выхода");
                x = Console.ReadLine();
                if (string.IsNullOrEmpty(x) == false)
                {
                    if ((x[0] == 'e') || (x[0] == 'E') || (x[0] == 'е') || (x[0] == 'Е'))
                        break;
                    if (Calc.Proverka(x) == true)
                        Calc.ConvertToKurwa(x);
                    else Console.WriteLine("Неверная запись!");
                }
            }
        }
    }
}
