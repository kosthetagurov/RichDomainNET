using Demo.Data.ViewModels;

using RichDomainNET.Abstractions;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class Order : AdvancedRichDomainModel<OrderViewModel>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }        
        public List<Product> Products { get; set; }
        public int Quantity { get; set; }
    }
}
