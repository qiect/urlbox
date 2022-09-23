using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace URLBox.EntityFrameworkCore.DbMigrations
{
    public class URLBoxDbMigrationsDbContext : AbpDbContext<URLBoxDbMigrationsDbContext>
    {
        public URLBoxDbMigrationsDbContext(DbContextOptions<URLBoxDbMigrationsDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}
