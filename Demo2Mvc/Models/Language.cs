using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2Mvc.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
