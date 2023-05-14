namespace SRS5
{
    public class TriangleType : DomainObject
    {
        public string NameType;
        public string TypeDescription;
        public TriangleType() : base() { }
        public TriangleType(List<string> _params) : base(_params) { }
        protected override void LoadObject(List<string> _params)
        {
            NameType = Convert.ToString(_params[1]);
            TypeDescription = Convert.ToString(_params[2]);
        }

        public override string GetColumns()
        {
            return $"{GetId()}, '{NameType}', '{TypeDescription}'";
        }

        public override string GetUpdateColumns()
        {
            return $"NameType = '{NameType}', TypeDescription = '{TypeDescription}'";
        }
    }
}