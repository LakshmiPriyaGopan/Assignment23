﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _23WebAPIAssignment1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PODbEntities : DbContext
    {
        public PODbEntities()
            : base("name=PODbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<PoDetail> PoDetails { get; set; }
        public virtual DbSet<PoMaster> PoMasters { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
    }
}
