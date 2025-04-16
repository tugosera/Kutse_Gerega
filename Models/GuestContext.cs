using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using kutse_app.Models;

namespace Kutse_App.Models
{
	public class GuestContext: DbContext
	{
		public DbSet<Guest> Guests { get; set; }
	}
}