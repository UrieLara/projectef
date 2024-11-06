using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace projectef.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Weight { get; set; }

    [JsonIgnore] //paque no se estén enviando datos en ciclos
        public virtual ICollection<iTask> Tasks { get; set; }
    }
}