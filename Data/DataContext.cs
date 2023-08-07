using DenemeAPI.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace DenemeAPI.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }
		//public DbSet<Author> Author { get; set; }

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var entries = ChangeTracker.Entries()
				.Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added
				|| e.State == EntityState.Modified));

			foreach (var entry in entries)
			{
				if (entry.State == EntityState.Added)
				{
					((BaseEntity)entry.Entity).CreatedTime = DateTime.Now;
				}
				else if (entry.State == EntityState.Modified)
				{
					entry.Property("CreatedTime").IsModified = false;
                    ((BaseEntity)entry.Entity).UpdatedTime = DateTime.Now;
                }
			}
			return await base.SaveChangesAsync(cancellationToken);
		}

		public override int SaveChanges()
		{
			var entries = ChangeTracker.Entries()
				.Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added
				|| e.State == EntityState.Modified));

			foreach (var entry in entries)
			{
				if (entry.State == EntityState.Added)
				{
					((BaseEntity)entry.Entity).CreatedTime = DateTime.Now;
				}

				else if (entry.State == EntityState.Modified)
				{
					entry.Property("CreatedTime").IsModified = false;
				}

				((BaseEntity)entry.Entity).UpdatedTime = DateTime.Now;
			}
			return base.SaveChanges();
		}
	}
}

