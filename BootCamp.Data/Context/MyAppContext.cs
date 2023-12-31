﻿using BootCamp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Data.Context
{
    public class MyAppContext : IdentityDbContext<Trainee>
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        //public DbSet<Admin> Admins { get; set; }
        public DbSet<Test> Tests { get; set; }
        public IEnumerable<object> Test { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .Ignore(t => t.IsPassed);

            base.OnModelCreating(modelBuilder);
        }


    }

}
