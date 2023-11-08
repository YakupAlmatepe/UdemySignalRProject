using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
	public class Category
	{
        [Key] 
        public int CatregoryID { get; set; }
        public string CatregoryName { get; set; }
        public bool Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
