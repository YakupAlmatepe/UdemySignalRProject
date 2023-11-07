using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
	public class OpenHour
	{
		[Key]
		public int OpenHoursID { get; set; }
        public string Description { get; set; }
    }
}
