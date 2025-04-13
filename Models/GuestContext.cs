using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using kutse_app.Models;

namespace Kutse_App.Models
{
    public class guestContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
    }
}