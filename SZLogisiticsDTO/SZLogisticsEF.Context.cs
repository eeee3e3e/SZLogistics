﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SZLogisiticsDTO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SZLogisticsEFContainer : DbContext
    {
        public SZLogisticsEFContainer()
            : base("name=SZLogisticsEFContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<T_HotelInfo> T_HotelInfo { get; set; }
        public virtual DbSet<T_HUserInfo> T_HUserInfo { get; set; }
        public virtual DbSet<T_HUserType> T_HUserType { get; set; }
        public virtual DbSet<T_ProductOrder> T_ProductOrder { get; set; }
        public virtual DbSet<T_ProviderInfo> T_ProviderInfo { get; set; }
        public virtual DbSet<T_PUserInfo> T_PUserInfo { get; set; }
        public virtual DbSet<T_PUserType> T_PUserType { get; set; }
        public virtual DbSet<T_Unit> T_Unit { get; set; }
    }
}
