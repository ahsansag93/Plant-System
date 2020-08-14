using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WaterPlant.Models
{
    public class Db : DbContext
    {
        public DbSet<Plants> Plant { get; set; }
        public Db()
            : base("DefaultConnection")
        {
        }
    }
}