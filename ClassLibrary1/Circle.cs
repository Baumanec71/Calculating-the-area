//Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам.
//Дополнительно к работоспособности оценим:

//Юнит-тесты
//Легкость добавления других фигур


//Вычисление площади фигуры без знания типа фигуры в compile-time

//Проверку на то, является ли треугольник прямоугольным

namespace ClassLibrary1

{
    public class Circle
    {
        const double P = 3.14;
        protected static List<int> variables = new List<int>();
        private int r;
        protected double square;
        private bool condition = true;
        public Circle(int y)
        {
           

            try
            {
                Console.WriteLine("Введите исходные данные для вычисления площади: радиус если круг или 3 стороны для треугольника, если данные закончились введите 0");
                while (condition)
                {
                    r = int.Parse(Console.ReadLine());
                    if(r != 0)
                    {
                        variables.Add(r);
                    }
                    else
                    {
                        condition = false;
                    }
                    
                }
                if(variables.Count == 1)
                {
                    Square();
                }
                else if(variables.Count == 3)
                {
                    Triangle triangle = new Triangle();
                    triangle.Square();
                }
                else
                {
                    Console.WriteLine($"программа не может определить фигуру");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
               
            }

        }
        public Circle()
        {

        }

        public virtual double Square()
        {
            Console.WriteLine("Ваша фигура круг");
            foreach (int i in variables)
            {
                r = i;
            }
                square = P*r * r;
            Console.WriteLine($"Его площадь {square}");
            return square;
        }




    }


    public class Triangle : Circle
    {
        private bool rectangular = true;
        private int a;
        private int b;
        private int c;

        public bool Rectangular()
        {
            
            foreach (int i in variables)
            {
                if (i== variables.Max())
                {
                    c = i;
                }
                else if(i== variables.Min())
                {
                    a = i;
                }
                else
                {
                    b = i;
                }
            }
            if (c * c != b * b + a * a)
            {
                rectangular = false;
            }

            return rectangular;
        }

        public override double Square()
        {
            Rectangular();
            if (rectangular == true)
            {
                Console.WriteLine("Треугольник прямоугольный");

                square = 0.5 * a * b;
                Console.WriteLine($"Его площадь {square}");
            }
            else
            {
                Console.WriteLine("Треугольник не является прямоугольным");
                square = Math.Sin(a) * a * b * 0.5;
                Console.WriteLine($"Его площадь {square}");
            }

            
            return square;
        }

              

    }
    


}
