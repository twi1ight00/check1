using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Authorization.Domain.Models;

public class Authorization : DBContextBase
{
	public DbSet<SYS_AUTHORIZATION> SYS_AUTHORIZATION { get; set; }

	public DbSet<SYS_AUTHORIZATION_DETAILS> SYS_AUTHORIZATION_DETAILS { get; set; }

	public DbSet<SYS_AUTHORIZATION_SPECIAL> SYS_AUTHORIZATION_SPECIAL { get; set; }

	public Authorization()
		: base("Authorization")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
