using Microsoft.EntityFrameworkCore;
using MebelDatabaseImplement.Models;

namespace MebelDatabaseImplement
{
	public class MebelDatabase : DbContext
	{
		/*public MebelDatabase()
		{
			Database.EnsureDeleted();   // удаляем бд со старой схемой
										//Database.EnsureCreated();   // создаем бд с новой схемой
		}*/

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyagkoeMestoDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
			}
			base.OnConfiguring(optionsBuilder);
		}

		public virtual DbSet<Customer> Customers { set; get; }
		public virtual DbSet<Mebel> Mebel { set; get; }
		public virtual DbSet<Garniture> Garniture { set; get; }
		public virtual DbSet<Supply> Orders { set; get; }
		public virtual DbSet<Provider> Providers { set; get; }
		public virtual DbSet<Material> Materials { set; get; }
		public virtual DbSet<Module> Modules { set; get; }
		public virtual DbSet<ModuleMaterial> ModuleMaterials { set; get; }
		public virtual DbSet<GarnitureMaterial> GarnitureMaterials { set; get; }
		public virtual DbSet<ModuleMebel> ModuleMebels { set; get; }
		public virtual DbSet<GarnitureMebel> GarnitureMebels { set; get; }
		public virtual DbSet<Supply> Supplys { set; get; }
		public virtual DbSet<Shipment> Shipments { set; get; }
		public virtual DbSet<SupplyMaterial> SupplyMaterials { set; get; }
		public virtual DbSet<ShipmentGarniture> ShipmentGarnitures { set; get; }
	}
}