namespace SRS5
{
    // Identity Map
    internal class ObjectWatcher
    {
        private static ObjectWatcher Instance = new ObjectWatcher();
        private ObjectWatcher() { }
        public static ObjectWatcher GetInstance()
        {
            return Instance;
        }
        private Dictionary<string, DomainObject> ObjectsMap = new Dictionary<string, DomainObject>();
        public DomainObject GetObject(string object_id)
        {
            if (ObjectsMap.ContainsKey(object_id))
            {
                Console.WriteLine("Получаем ссылку на объект из списка");
                return ObjectsMap[object_id];
            }
            else
            {
                Console.WriteLine("В списке нет такого объекта");
                return null;
            }
        }
        public void Add(string object_id, DomainObject domainObject)
        {
            ObjectsMap[object_id] = domainObject;
        }
    }
}