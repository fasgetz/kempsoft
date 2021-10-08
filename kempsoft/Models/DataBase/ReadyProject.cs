using System;
using System.Collections.Generic;

#nullable disable

namespace kempsoft.Models.DataBase
{
    public partial class ReadyProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TasksProject { get; set; }
        public string LogoImg { get; set; }
        public string ProjectRoute { get; set; }
        public string ProjectImg { get; set; }
    }
}
