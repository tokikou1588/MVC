
 //------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM11.Respository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using CRM11.MODEL;
    
    public partial class NewCRMEntities : DbContext
    {
        public NewCRMEntities()
            : base("name=NewCRMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmpRoleRelation> EmpRoleRelation { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RolePerRelationship> RolePerRelationship { get; set; }
        public DbSet<VipPermssion> VipPermssion { get; set; }
    }
}
