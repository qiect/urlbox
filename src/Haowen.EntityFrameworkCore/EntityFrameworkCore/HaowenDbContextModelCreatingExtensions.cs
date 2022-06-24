using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using static Haowen.HaowenDbConsts;

namespace Haowen.EntityFrameworkCore
{
    public static class HaowenDbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.Entity<Article>(p =>
            {
                p.ToTable(HaowenConsts.DbTablePrefix + DbTableName.Tests);
                p.HasKey(t => t.Id);
                p.Property(p => p.Title).HasMaxLength(500).IsRequired();
                p.Property(p => p.Url).HasMaxLength(200).IsRequired();
                p.Property(p => p.Icon).HasMaxLength(200);
                p.Property(p => p.Des).HasMaxLength(500);
                p.Property(p => p.Tags).HasMaxLength(200).IsRequired();
            });
        }
    }
}
