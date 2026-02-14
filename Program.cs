namespace Lab1
{
    internal class Program
    {
        static int choice; //Хранит номер задачи
        static double a, b, c; //Длины сторон
        static void Main(string[] args)
        {
            Console.Title = "Выполнено Корниловым К.В.";

            while (true) //Главный цикл
            {
                Console.Clear(); //Чистим консоль после предыдущих запусков

                //МЕНЮ
                Console.WriteLine("МЕНЮ");
                Console.WriteLine("1. Вычислить полупериметр треугольника со сторонами a, b, c.");
                Console.WriteLine("2. Вычислить площадь треугольника по формуле Герона.");
                Console.WriteLine("3. Вычислить радиус вписанной (r) и радиус описанной (R) окружностей.");
                Console.WriteLine("4. Выход.");

                //Выбор задачи и ввод сторон
                Console.Write("\nВведите номер задачи: ");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Error("введён некорректный номер задачи!");
                    continue;
                }
                else
                {
                    if (choice == 4) return;

                    //Попытка получить длинны сторон
                    try
                    {
                        Console.Write("Введите a: ");
                        a = double.Parse(Console.ReadLine()!);

                        Console.Write("Введите b: ");
                        b = double.Parse(Console.ReadLine()!);

                        Console.Write("Введите c: ");
                        c = double.Parse(Console.ReadLine()!);
                    }
                    catch (FormatException)
                    {
                        Error("введено некорректное числовое значение длины стороны!");
                        continue;
                    }

                    //Проверка длинн сторон
                    if (c < 0 || a < 0 || b < 0)
                    {
                        Error("длина стороны не может быть отрицательной!");
                        continue;
                    }

                    //Проверка на существование треуголника
                    if (!(a + b > c && b + c > a && a + c > b) || a == 0 || b == 0 || c == 0) 
                    {
                        string text_error = $"треугольник со сторонами a = {a}, b = {b}, c = {c} не существует!";
                        Error(text_error);
                        continue;
                    }

                    Poluperimetr(); //Все длинны получены, приступаем к рассчётам
                }

            }
        }
        static void Poluperimetr() //Поиск полупериметра
        {
            double p = (a + b + c) / 2; //Формула для полупериметра
            if (choice == 1) //Если требуется решить эту задачу, выдаем ответ и все
            {
                Console.WriteLine($"p = {p:F2}");
                End();
            }
            else //Иначе переходим к следующему этапу
                Ploshad(p);
        }

        static void Ploshad(double p) //Поиск площади формулой Герона
        {
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c)); //Считаем по формуле
            if (choice == 2) //Если требуется решить эту задачу, выводим ответ и завершаем работу
            {
                Console.WriteLine($"S = {s:F2}");
                End();
            }
            else //Иначе переходим к следующему этапу
                Radius(p, s);
        }

        static void Radius(double p, double s) //Поиск радиуса вписанной/описанной окружности
        {
            double r = s / p; //Радиус вписанной окружности
            double R = (a*b*c) / (4*s); //Радиус описанной окружности

            Console.WriteLine($"r = {r:F2}");
            Console.WriteLine($"R = {R:F2}");
            End();
        }

        static void Error(string message) //Функция для вывода ошибки
        {
            Console.WriteLine("Ошибка, " + message);
            Console.Write("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void End() //Функция корректного завершения программы
        {
            Console.Write("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            return;
        }
    }
}
