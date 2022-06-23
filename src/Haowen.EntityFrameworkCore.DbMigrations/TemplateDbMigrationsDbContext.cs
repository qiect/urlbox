using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Haowen.EntityFrameworkCore.DbMigrations
{
    public class TemplateDbMigrationsDbContext : AbpDbContext<TemplateDbMigrationsDbContext>
    {
        public TemplateDbMigrationsDbContext(DbContextOptions<TemplateDbMigrationsDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}
