using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Localizing.Domain.Models;

public class Localizing : DBContextBase
{
	public DbSet<SYS_LANGUAGE> SYS_LANGUAGE { get; set; }

	public DbSet<SYS_LOCALIZING> SYS_LOCALIZING { get; set; }

	public Localizing()
		: base("Localizing")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
