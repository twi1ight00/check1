using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Portal.Domain.Models;

public class Portal : DBContextBase
{
	public DbSet<SYS_PORTAL> SYS_PORTAL { get; set; }

	public DbSet<SYS_SHORTCUT> SYS_SHORTCUT { get; set; }

	public DbSet<SYS_USER_PORTAL> SYS_USER_PORTAL { get; set; }

	public Portal()
		: base("Portal")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
