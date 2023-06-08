using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.ITManagement.Domain.Models;

public class ITManage : DBContextBase
{
	public DbSet<IT_ACCOUNT> IT_ACCOUNT { get; set; }

	public DbSet<IT_DEVICE> IT_DEVICE { get; set; }

	public DbSet<IT_DEVICE_SCRAP> IT_DEVICE_SCRAP { get; set; }

	public DbSet<IT_DEVICE_SCRAP_DETAIL> IT_DEVICE_SCRAP_DETAIL { get; set; }

	public DbSet<IT_MATERIAL> IT_MATERIAL { get; set; }

	public DbSet<IT_MATERIAL_APPLY_DETAIL> IT_MATERIAL_APPLY_DETAIL { get; set; }

	public DbSet<IT_MATERIAL_CHECKIN> IT_MATERIAL_CHECKIN { get; set; }

	public DbSet<IT_STOCK_IN> IT_STOCK_IN { get; set; }

	public DbSet<IT_STOCK_IN_DETAIL> IT_STOCK_IN_DETAIL { get; set; }

	public DbSet<IT_SUPPORTMANG> IT_SUPPORTMANG { get; set; }

	public DbSet<IT_STOCK_OUT_DETAIL> IT_STOCK_OUT_DETAIL { get; set; }

	public ITManage()
		: base("ITManage")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
