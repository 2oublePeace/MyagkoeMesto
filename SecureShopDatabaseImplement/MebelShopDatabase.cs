using SecureShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace SecureShopDatabaseImplement
{
	public class MebelShopDatabase : DbContext
	{
		/*public SecureShopDatabase()
		{
			Database.EnsureDeleted();   // удаляем бд со старой схемой
			Database.EnsureCreated();   // создаем бд с новой схемой
		}*/

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NameShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
			}
			base.OnConfiguring(optionsBuilder);
		}

		public virtual DbSet<Material> Materials { set; get; }
		public virtual DbSet<Module> Modules { set; get; }
		public virtual DbSet<ModuleMaterial> ModuleMaterials { set; get; }
		public virtual DbSet<Supply> Orders { set; get; }
	}
}