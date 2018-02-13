using System;
using System.ComponentModel.DataAnnotations;

namespace DataModels
{
    public class Test
    {
        [Key]
        public Int16 ID { get; set; }
        public string Fname { get; set; }
    }
}
