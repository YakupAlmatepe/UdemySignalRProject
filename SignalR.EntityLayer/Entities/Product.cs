using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
	public class Product
	{
		[Key]
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public string VideoUrl { get; set; }
		public bool ProductStatus { get; set; }
		public int CatregoryID { get; set; }
		public Category Catregory { get; set; }
	}
}

