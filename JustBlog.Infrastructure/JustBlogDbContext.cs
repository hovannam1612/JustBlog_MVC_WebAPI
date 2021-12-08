using JustBlog.Model.BaseEntity;
using JustBlog.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JustBlog.Infrastructure
{
    public class JustBlogDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public JustBlogDbContext()
        {
        }

        public JustBlogDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostTagMap> PostTagMaps { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-0MTS6DU\\SQLEXPRESS;database=JustBlogMVC;integrated security=true");
                optionsBuilder.LogTo(Console.WriteLine);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(category =>
            {
                category.HasKey(c => c.Id);
                category.Property(c => c.Name).IsRequired().HasMaxLength(255);
                category.Property(c => c.UrlSlug).HasMaxLength(255);
                category.Property(c => c.Description).HasMaxLength(1024);
            });

            builder.Entity<Post>(post =>
            {
                post.HasKey(c => c.Id);
                post.Property(c => c.Title).IsRequired().HasMaxLength(200);
                post.Property(c => c.UrlSlug).IsRequired();
                post.Property(c => c.PostContent).IsRequired();
                post.HasOne(p => p.Category)
                    .WithMany(c => c.Posts)
                    .HasForeignKey(p => p.CategoryId);
            });

            builder.Entity<Tag>(tag =>
            {
                tag.HasKey(x => x.Id);
                tag.Property(x => x.Name).IsRequired().HasMaxLength(255);
                tag.Property(x => x.UrlSlug).IsRequired();
            });

            builder.Entity<Comment>(comment =>
            {
                comment.HasKey(x => x.Id);
                comment.Property(x => x.CommentText).HasMaxLength(1024);
                comment.HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(p => p.PostId);
            });

            builder.Entity<PostTagMap>(postTag =>
            {
                postTag.HasKey(x => new { x.PostId, x.TagId });
                postTag.HasOne(pt => pt.Tag)
                        .WithMany(t => t.PostTagMaps)
                        .HasForeignKey(pt => pt.TagId);

                postTag.HasOne(pt => pt.Post)
                        .WithMany(p => p.PostTagMaps)
                        .HasForeignKey(pt => pt.PostId);
            });

            
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName(); 
                if (tableName.StartsWith("AspNet"))
                    entityType.SetTableName(tableName.Substring(6));
            }
        }

        public override int SaveChanges()
        {
            BeforeSaveChange();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            BeforeSaveChange();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void BeforeSaveChange()
        {
            var entities = this.ChangeTracker.Entries();
            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;
                if (entity.Entity is IBaseEntity<int> asEntity)
                {
                    if (entity.State == EntityState.Added)
                    {
                        asEntity.CreatedOn = now;
                        asEntity.UpdatedOn = now;
                    }
                    if (entity.State == EntityState.Modified)
                    {
                        asEntity.UpdatedOn = now;
                    }
                }
            }
        }
    }
}