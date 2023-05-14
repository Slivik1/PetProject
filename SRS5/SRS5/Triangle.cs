namespace SRS5
{
    //Класс треугольников. Полное отображение таблицы Triangle из базы данных.
    public class Triangle : DomainObject
    {
        public int Corner1;
        public int Corner2;
        public int TriangleTypeId;
        TriangleType? triangleType;
        //Lazy Load
        public TriangleType? Triangle_Type
        {
            set
            {
                triangleType = value;
            }
            get
            {
                if (TriangleTypeId > 0)
                {
                    Mapper TTM = new Mapper("TriangleType");
                    triangleType = (TriangleType)TTM.Find(TriangleTypeId);
                }
                else
                {
                    if (GetId() != 0)
                    {
                        throw new Exception("Не могу закгрузить объект");
                    }
                    else
                    {
                        triangleType = null;
                    }    
                }
                return triangleType;
            }
        }
        public TriangleType GetType()
        {
            return triangleType;
        }
        public Triangle() : base() { }
        public Triangle(List<string> _params) : base(_params) { }
        protected override void LoadObject(List<string> _params)
        {
            Corner1 = Convert.ToInt32(_params[1]);
            Corner2 = Convert.ToInt32(_params[2]);
            TriangleTypeId = Convert.ToInt32(_params[3]);
        }
        //Получение значений полей класса для INSERT запроса
        public override string GetColumns()
        {
            return $"{Corner1}, {Corner2}, {TriangleTypeId}";
        }
        //Получение значений полей класса для UPDATE запроса
        public override string GetUpdateColumns()
        {
            return $"Corner1 = {Corner1}, Corner2 = {Corner2}";
        }
    }
}