﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WarehouseManagement
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_warehouse_managementEntities : DbContext
    {
        public db_warehouse_managementEntities()
            : base("name=db_warehouse_managementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<hang_hoa> hang_hoa { get; set; }
        public virtual DbSet<hang_nhap> hang_nhap { get; set; }
        public virtual DbSet<hang_xuat> hang_xuat { get; set; }
        public virtual DbSet<nha_cung_cap> nha_cung_cap { get; set; }
        public virtual DbSet<tai_khoan> tai_khoan { get; set; }
    }
}
