//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Branchenverzeichnis
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IndustryDirectoryEntities : DbContext
    {
        public IndustryDirectoryEntities()
            : base("name=IndustryDirectoryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyProduct> CompanyProduct { get; set; }
        public virtual DbSet<Industry> Industry { get; set; }
        public virtual DbSet<Product> Product { get; set; }
    }
}
