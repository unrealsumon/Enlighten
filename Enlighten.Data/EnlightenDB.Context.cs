﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Enlighten.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EnlightenDBContext : DbContext
    {
        public EnlightenDBContext()
            : base("name=EnlightenDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_Godown> TB_Godown { get; set; }
        public virtual DbSet<TB_Inventory> TB_Inventory { get; set; }
        public virtual DbSet<TB_Product> TB_Product { get; set; }
        public virtual DbSet<TB_ProductCategory> TB_ProductCategory { get; set; }
        public virtual DbSet<TB_User> TB_User { get; set; }
        public virtual DbSet<TB_Company> TB_Company { get; set; }
    }
}
