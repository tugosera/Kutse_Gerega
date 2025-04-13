using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Kutse_App.Models
{ 
    public class GuestDBIninitializer: CreateDatabaseIfNotExists<guestContext>
    {
        protected override void Seed(guestContext db)
        { 
            base.Seed(db);
        }
    }
}