using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Store.Models
{
    public class Oder
    {
        [BindNever]
        public int id { get; set; }
        [Required(ErrorMessage = "введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage ="введите адрес доставки")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "введите Город доставки")]
        public string City { get; set; }
        [BindNever]
        public bool Shipped { get; set; }

        public ICollection<productsToOder> products { get; set; } = new List<productsToOder>();


    }
}
