using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class CorporationContext: DbContext
    {
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Person> People { get; set; }
        public CorporationContext() : base("CorporationDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasRequired(a => a.Corporation).WithMany(b => b.People).HasForeignKey(k => k.Corporation_Id);
        }

        //public class CorporationDbInitializer:DropCreateDatabaseAlways<CorporationContext>
        //{
        //    protected override void Seed(CorporationContext db)
        //    {
        //        db.Corporations.Add(new Corporation { Department = "Automation System", Position = "Designer", Salary =20000});
        //        db.Corporations.Add(new Corporation { Department = "Automation Systemr", Position = "Engineer", Salary=30000 });
        //        db.Corporations.Add(new Corporation { Department = "Automation System", Position = "Idol", Salary=40000 });
        //        db.People.Add(new Person { Name = "Matthew", Surname = "Bellamy" });
        //        base.Seed(db);
        //    }
    }
}