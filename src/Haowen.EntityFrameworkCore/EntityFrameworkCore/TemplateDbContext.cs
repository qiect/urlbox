using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Haowen.EntityFrameworkCore
{
    [ConnectionStringName("MySql")]
    public class TemplateDbContext : AbpDbContext<TemplateDbContext>
    {
        public DbSet<Test> Tests { get; set; }
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }
    }
}
