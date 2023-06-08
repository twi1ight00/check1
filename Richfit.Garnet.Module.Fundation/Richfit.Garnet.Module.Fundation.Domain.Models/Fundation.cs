using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Fundation.Domain.Models;

public class Fundation : DBContextBase
{
	public DbSet<SYS_DOMAIN> SYS_DOMAIN { get; set; }

	public DbSet<SYS_USER> SYS_USER { get; set; }

	public DbSet<SYS_USER_ORG> SYS_USER_ORG { get; set; }

	public Fundation()
		: base("Fundation")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
