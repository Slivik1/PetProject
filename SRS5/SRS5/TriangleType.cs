using System.ComponentModel;

namespace SRS5
{
    internal class TriangleType : DomainObject
    {
        public string TypeName;
        public string TypeDescription;
        public TriangleType(int id, string typeName, string typeDescription) : base(id)
        {
            TypeName = typeName;
            TypeDescription = typeDescription;
        }
        public TriangleType(string typeName, string typeDescription) : base(0)
        {
            TypeName = typeName;
            TypeDescription = typeDescription;
        }
    }
}