﻿using Microsoft.EntityFrameworkCore;
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
        }
    }
}