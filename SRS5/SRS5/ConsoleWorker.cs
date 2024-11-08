namespace SRS5
{
    internal class ConsoleWorker // Класс, отделяющий пользователя от системы. Является прослойкой между пользователем и системой.
    {
        protected Mapper mapper;
        protected Triangle triangle;
        protected TriangleType type;

        protected string TableName;


        // Все нижепредставленные методы обращаются к классу Mapper
        public void SelectQueue() // Метод, общающийся к классу Mapper для поиска заданного объекта
        {
            Console.WriteLine("Введите id объекта, который нужно вывести...");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id <= 0)
            {
                Console.WriteLine("Некорректный id...");
            }

            if (TableName == "Triangle")
            {
                triangle = (Triangle)mapper.Find(id);
                if (triangle != null) 
                {
                    Console.WriteLine(triangle.GetColumns());
                }
            }
            else
            {
                type = (TriangleType)mapper.Find(id);
                if (type != null)
                {
                    Console.WriteLine(type.GetColumns());
                }
            }
            PrintMenu();
        }
        public void SaveQueue() // Метод,  общающийся к классу Mapper для попытки сохранения объекта
        {
            if (TableName == "Triangle")
            {
                Console.WriteLine("Введите id треугольника...");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите первый угол треугольника...");
                int corner1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите второй угол треугольника...");
                int corner2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите номер типа треугольника...");
                string type = Console.ReadLine();

                if (corner1 + corner2 < 180)
                {
                    triangle = new(new List<string> { Convert.ToString(id), Convert.ToString(corner1), Convert.ToString(corner2), type });
                    mapper.Save(triangle, id);
                }
                else
                {
                    Console.WriteLine("Треугольник не существует");
                }
            }
            else
            {
                Console.WriteLine("Введите id типа...");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите название треугольника...");
                string name = Console.ReadLine();

                Console.WriteLine("Введите описание типа треугольника...");
                string desr = Console.ReadLine();

                type = new(new List<string> { Convert.ToString(id), name, desr });
                mapper.Save(type, id);
            }
            PrintMenu();
        }

        public void DeleteQueue() // Метод,  общающийся к классу Mapper для удаления заданного объекта
        {
            Console.WriteLine("Введите id объекта, который нужно удалить...");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id <= 0)
            {
                Console.WriteLine("Некорректный id...");
            }

            mapper.Delete(id);
            PrintMenu();
        }
        public void PrintMenu() // Метод, выводящий весь функционал системы в виде главного меню
        {
            int tableChoose;
            int operationChoose;

            Console.WriteLine("\n----------ВЫБЕРИТЕ ТАБЛИЦУ---------");
            Console.WriteLine("1. 'Triangle'.\n2. 'TriangleType'.\n");

            bool isNumber = int.TryParse(Console.ReadLine(), out tableChoose);

            if (isNumber)
            {
                switch (tableChoose)
                {
                    case 1: mapper = new Mapper("Triangle"); TableName = "Triangle"; break;
                    case 2: mapper = new Mapper("TriangleType"); TableName = "TriangleType"; break;

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

