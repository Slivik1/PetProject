namespace SRS5
{
    internal class ConsoleWorker
    {
        protected Mapper mapper;
        protected triangle triangle;
        protected triangle_type type;

        protected string _tableName;

        public void SelectQueue()
        {
            Console.WriteLine("Введите id объекта, который нужно вывести...");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id <= 0)
            {
                Console.WriteLine("Некорректный id...");
                return;
            }

            if (_tableName == "Triangle")
            {
                triangle = (triangle)mapper.Find(id);
                if (triangle != null) Console.WriteLine(triangle.GetColumns());
            }
            else
            {
                type = (triangle_type)mapper.Find(id);
                if (type != null) Console.WriteLine(type.GetColumns());
            }

            PrintMenu();
        }

        public void SaveQueue()
        {
            if (_tableName == "Triangle")
            {
                Console.WriteLine("Введите id треугольника...");
                string id = Console.ReadLine();

                Console.WriteLine("Введите первый угол треугольника...");
                string corner1 = Console.ReadLine();

                Console.WriteLine("Введите второй угол треугольника...");
                string corner2 = Console.ReadLine();

                Console.WriteLine("Введите номер типа треугольника...");
                string type = Console.ReadLine();



                triangle = new(new List<string> { id, corner1, corner2, type });
                mapper.Save(triangle);
            }
            else
            {
                Console.WriteLine("Введите id типа...");
                string id = Console.ReadLine();

                Console.WriteLine("Введите название треугольника...");
                string Type_T = Console.ReadLine();

                Console.WriteLine("Введите описание типа треугольника...");
                string desr = Console.ReadLine();

                type = new(new List<string> { id, Type_T, desr });
                mapper.Save(type);
            }

            PrintMenu();
        }

        public void DeleteQueue()
        {
            Console.WriteLine("Введите id объекта, который нужно удалить...");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id <= 0)
            {
                Console.WriteLine("Некорректный id...");
                return;
            }

            mapper.Delete(id);
            PrintMenu();
        }

        public void PrintMenu()
        {
            int tableChoose;
            int operationChoose;

            Console.WriteLine("\n----------ВЫБЕРИТЕ ТАБЛИЦУ---------");
            Console.WriteLine("1. 'Triangle'.\n2. 'Type_triangle'.\n");

            bool isNumber = int.TryParse(Console.ReadLine(), out tableChoose);

            if (isNumber)
            {
                switch (tableChoose)
                {
                    case 1: mapper = new Mapper("Triangle"); _tableName = "Triangle"; break;
                    case 2: mapper = new Mapper("Type_triangle"); _tableName = "Type_triangle"; break;

                    default:
                        Console.WriteLine("\nНеверная команда.");
                        PrintMenu();
                        break;
                }
            }

            Console.WriteLine("\n----------МЕНЮ---------");
            Console.WriteLine("1. SELECT QUEUE.\n2. DELETE QUEUE.\n3. SAVE QUEUE (INSERT/UPDATE QUEUES)\n");

            isNumber = int.TryParse(Console.ReadLine(), out operationChoose);

            if (isNumber)
            {
                switch (operationChoose)
                {
                    case 1:
                        SelectQueue();
                        break;
                    case 2:
                        DeleteQueue();
                        break;
                    case 3:
                        SaveQueue();
                        break;
                    default:
                        Console.WriteLine("\nНеверная команда.");
                        PrintMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nНеверная команда.");
                PrintMenu();
            }
        }
    }
}

