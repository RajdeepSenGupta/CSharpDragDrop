using System.Collections.Generic;

namespace CSharpDragDrop.Models
{
    public class UpdateAC
    {
        public ObjectDef Source { get; set; }

        public ObjectDef Destination { get; set; }

        public List<Country> CountryList { get; set; }

        public List<State> StatesList { get; set; }
    }

    public class ObjectDef
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
