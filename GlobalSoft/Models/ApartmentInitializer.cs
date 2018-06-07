using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GlobalSoft.Models
{
    public class ApartmentInitializer : DropCreateDatabaseAlways<GlobalDbContext>
    {

        protected override void Seed(GlobalDbContext GlobalContext)
        {
            // AptType Type = new AptType() { Tipe = "1BR" };
            GlobalContext.AptTipes.Add(new AptType() { Tipe = "1BR" });
            GlobalContext.AptTipes.Add(new AptType() { Tipe = "2BR" });
            GlobalContext.AptTipes.Add(new AptType() { Tipe = "3BR" });

            GlobalContext.AptStatuses.Add(new AptStatus() { StatusID=1,Status = "Available" });
            GlobalContext.AptStatuses.Add(new AptStatus() { StatusID=2,Status = "Pending" });
            GlobalContext.AptStatuses.Add(new AptStatus() { StatusID=3,Status = "Sold" });

        }



    }
}