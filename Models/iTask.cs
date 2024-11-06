using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectef.Models
{

    public enum Priority{
        low,
        medium,
        high
    }
    public class iTask
    {
        public Guid iTaskId { get; set; }


        [ForeignKey("CategoryId")]
        public Guid CategoryId{ get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
        public Priority iTaskPriority { get; set; }
        public DateTime CreationDate {  get; set; }

        public string AssignedPerson {get; set; }

        public virtual Category Category { get; set; }

        //[NotMapped]
        public string Resume { get; set; }
    }
}