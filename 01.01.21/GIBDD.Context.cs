﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gibdd
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GIBDDContainer1 : DbContext
    {
        public GIBDDContainer1()
            : base("name=GIBDDContainer1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ColorsCar> ColorsCar { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<EngineType> EngineType { get; set; }
        public virtual DbSet<Fines> Fines { get; set; }
        public virtual DbSet<Licences> Licences { get; set; }
        public virtual DbSet<Manufacture> Manufacture { get; set; }
        public virtual DbSet<PlaceFines> PlaceFines { get; set; }
        public virtual DbSet<RegionSet> RegionSet { get; set; }
        public virtual DbSet<SubCodeSet> SubCodeSet { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transport> Transport { get; set; }
    }
}