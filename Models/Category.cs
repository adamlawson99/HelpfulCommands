using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpfulCommands.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
