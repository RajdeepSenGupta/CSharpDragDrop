using System.Collections.Generic;

namespace CSharpDragDrop.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<State> States { get; set; }
    }
}
