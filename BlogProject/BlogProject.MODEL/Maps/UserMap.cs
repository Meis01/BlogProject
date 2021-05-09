using BlogProject.CORE.Entity.Map;
using BlogProject.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.MODEL.Maps
{
    public class UserMap : CoreMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired(true);

            // TODO: Tüm mappingler yapmalı. Diğer Entity'ler için de. :))))))))

            // Burada Kalacak
            base.Configure(builder);
        }
    }
}
