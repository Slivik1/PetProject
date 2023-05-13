namespace SRS5
{
    public class triangle : DomainObject
    {
        public int Corner1;
        public int Corner2;
        triangle_type? triangle_type;
        public triangle_type? triangle_Type
        {
            set
            {
                triangle_type = value;
            }
            get
            {
                if (Triangle_Type_Id > 0)
                {
                    Mapper TTM = new Mapper("triangle_type");
                    triangle_type = (triangle_type)TTM.Find(Triangle_Type_Id);
                }
                else
                {
                    if (GetId() != 0)
                    {
                        throw new Exception("Не могу закгрузить объект");
                    }
                    else
                    {
                        triangle_type = null;
                    }    
                }
                return triangle_type;
            }
        }
        public triangle_type GetType()
        {
            return triangle_type;
        }
        public triangle() : base() { }
        public triangle(List<string> _params) : base(_params) { }
        protected override void LoadObject(List<string> _params)
        {
            Corner1 = Convert.ToInt32(_params[1]);
            Corner2 = Convert.ToInt32(_params[2]);
            Triangle_Type_Id = Convert.ToInt32(_params[3]);
        }

        public override string GetColumns()
        {
            return $"{Corner1}, {Corner2}, {Triangle_Type_Id}";
        }
        public override string GetUpdateColumns()
        {
            return $"Corner1 = {Corner1}, Corner2 = {Corner2}";
        }
        public int Triangle_Type_Id
        {
            set
            {
                if (value > 0)
                {
                    Mapper TTM = new Mapper("triangle_type");
                    triangle_type = (triangle_type)TTM.Find(value);
                }
                else
                {
                    if (GetId() != 0)
                    {
                        throw new Exception("Ошибка!");
                    }
                    else
                    {
                        triangle_type = null;
                    }
                }
            }
            get
            {
                if (triangle_type != null)
                {
                    return triangle_type.GetId();
                }
                else
                {
                    return 0;
                }

            }
        }
        //public triangle(int id) : base(id)
        //{
        //    Triangle_Type_Id = 1;
        //}
        //public triangle(int corner1, int corner2, int TriangleTypeId) : base(0)
        //{
        //    if (corner1 + corner2 < 180)
        //    {
        //        this.corner1 = corner1;
        //        this.corner2 = corner2;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Сумма двух углов не может быть больше или равна 180 градусам");
        //    }
        //    Triangle_Type_Id = TriangleTypeId;
        //}
        //public triangle(int id, int corner1, int corner2, int TriangleTypeId) : base(id)
        //{
        //    if (corner1 + corner2 < 180)
        //    {
        //        this.corner1 = corner1;
        //        this.corner2 = corner2;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Сумма двух углов не может быть больше или равна 180 градусам");
        //    }
        //    Triangle_Type_Id = TriangleTypeId;
    //}
    }
}