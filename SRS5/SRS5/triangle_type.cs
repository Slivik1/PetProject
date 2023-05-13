namespace SRS5
{
    public class triangle_type : DomainObject
    {
        public string name_type;
        public string type_description;
        public triangle_type() : base() { }
        public triangle_type(List<string> _params) : base(_params) { }
        protected override void LoadObject(List<string> _params)
        {
            name_type = Convert.ToString(_params[1]);
            type_description = Convert.ToString(_params[2]);
        }

        public override string GetColumns()
        {
            return $"{GetId()} {name_type} {type_description}";
        }

        public override string GetUpdateColumns()
        {
            return $"name_type = '{name_type}', type_description = '{type_description}'";
        }
    }
}