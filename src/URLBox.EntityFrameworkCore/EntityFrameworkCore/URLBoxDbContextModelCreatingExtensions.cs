using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using static URLBox.URLBoxDbConsts;

namespace URLBox.EntityFrameworkCore
{
    public static class URLBoxDbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.Entity<Article>(p =>
            {
                p.ToTable(URLBoxConsts.DbTablePrefix + DbTableName.Articles);
                p.HasKey(t => t.Id);
                p.Property(p => p.Name).HasMaxLength(500).IsRequired();
                p.Property(p => p.Url).HasMaxLength(200).IsRequired();
                p.Property(p => p.Icon).HasMaxLength(200);
                p.Property(p => p.Des).HasMaxLength(500);
                p.Property(p => p.Tags).HasMaxLength(100);
            });
            builder.Entity<Tag>(p =>
            {
                p.ToTable(URLBoxConsts.DbTablePrefix + DbTableName.Tags);
                p.Property(p => p.Name).HasMaxLength(50).IsRequired();
            });
            builder.Entity<User>(p =>
            {
                p.ToTable(URLBoxConsts.DbTablePrefix + DbTableName.Users);
                p.Property(p => p.PhoneNum).HasMaxLength(20).IsUnicode(false);
                p.Property(p=>p.Email).HasMaxLength(50);
                p.Property(p=>p.EmailStatus).HasMaxLength(10);
                p.Property(p=>p.VCode).HasMaxLength(10);
                p.Property(p => p.PasswordHash).HasMaxLength(100);
                p.Property(p => p.PasswordSalt).HasMaxLength(20);
                p.Property(p => p.QQOpenId).HasMaxLength(100);
                p.Property(p => p.Name).HasMaxLength(50);
                p.Property(p => p.Avatar).HasMaxLength(500);
                p.Property(p => p.Gender).HasMaxLength(10);
                p.Property(p => p.LastLoginIP).HasMaxLength(50);
                p.HasQueryFilter(p => !p.IsDeleted);
            });
        }
    }
}
