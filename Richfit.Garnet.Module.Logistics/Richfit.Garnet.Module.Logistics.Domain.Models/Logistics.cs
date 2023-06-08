using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Logistics.Domain.Models;

public class Logistics : DBContextBase
{
	public DbSet<LM_VEHICLE_MANAGE> LM_VEHICLE_MANAGE { get; set; }

	public Logistics()
		: base("Logistics")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
