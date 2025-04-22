using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kutse_App.Models
{
	public class HolidayContext: DbContext
    {
        public DbSet<Kutse.Models.Holiday> Holidays { get; set; }
    }
}