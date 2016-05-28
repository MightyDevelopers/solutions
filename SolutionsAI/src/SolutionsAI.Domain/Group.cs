using System;

namespace SolutionsAI.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
