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
                Console.WriteLine("3. Вычислить радиус вписанной/описанной окружности");
                Console.WriteLine("4. Выход.");
               
                //Последовательно получаем и проверяем все необходимое (Длины, номер задачи)
                Console.Write("\nВведите желаемое действие: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice < 5)
                {
                    if (choice == 4)
                        return;
                    Console.Write("Введите a: ");
                    if (double.TryParse(Console.ReadLine(), out a))
                    {
                        Console.Write("Введите b: ");
                        if (double.TryParse(Console.ReadLine(), out b))
                        {
                            Console.Write("Введите c: ");
                            if (double.TryParse(Console.ReadLine(), out c))
                            {
                                if (!(a + b > c && b + c > a && a + c > b) || a == 0 || b == 0 || c == 0) //Проверка на существование треуголника
                                {
                                    Console.WriteLine($"Треугольник со сторонами a = {a}, b = {b}, c = {c} не существует!");
                                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                    Console.ReadKey();
                                    continue;
                                }    
                            }
                        }
                    }
                }
                else
                    continue;
                Poluperimetr();
            }
        }
        static void Poluperimetr() //Поиск полупериметра
        {
            double p = (a + b + c) / 2; //Формула для полупериметра
            if (choice == 1) //Если требуется решить эту задачу, выдаем ответ и все
            {
                Console.WriteLine($"p = {p:F2}");
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }
            else //Иначе переходим к следующему этапу
                Ploshad(p);
        }
        static void Ploshad(double p) //Поиск площади формулой Герона
        {
            double pod_kornem = p * (p - a) * (p - b) * (p - c); //Считаем подкоренное значение
            if (pod_kornem < 0) //Чтобы убедиться что оно не < 0
                Error("подкоренное выражение < 0, поиск площади формулой Герона невозможен!");

            double s = Math.Sqrt(pod_kornem); //Считаем по формуле
            if (choice == 2) //Если требуется решить эту задачу, выводим ответ и завершаем работу
            {
                Console.WriteLine($"S = {s:F2}");
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }
            else //Иначе переходим к следующему этапу
                Radius(p, s);
        }
        static void Radius(double p, double s) //Поиск радиуса вписанной/описанной окружности
        {
            Console.WriteLine("Какой окружности радиус необходимо найти? (1 - вписанная, 2 - описанная)");
            //Получаем и проверяем номер выбранной подзадачи
            if (int.TryParse(Console.ReadLine(), out int choice_radius) && choice_radius < 3 && choice_radius > 0)
            {
                if (choice_radius == 1) //Считаем радиус вписанной
                {
                    double r = s / p; //По формуле
                    Console.WriteLine($"r = {r:F2}");
                }
                else //Считаем радиус описанной
                {
                    double R = (a*b*c) / (4*s); //По формуле
                    Console.WriteLine($"R = {R:F2}");
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }
        }
        static void Error(string message) //Функция для вывода ошибки
        {
            Console.WriteLine("Ошибка, ", message);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            return;
        }
    }
}
