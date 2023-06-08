using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SystemManage : DBContextBase
{
	public DbSet<SYS_ACTION> SYS_ACTION { get; set; }

	public DbSet<SYS_ACTION_GROUP> SYS_ACTION_GROUP { get; set; }

	public DbSet<SYS_ACTION_GROUP_ACTION> SYS_ACTION_GROUP_ACTION { get; set; }

	public DbSet<SYS_AUTHORIZATION> SYS_AUTHORIZATION { get; set; }

	public DbSet<SYS_BUSINESS> SYS_BUSINESS { get; set; }

	public DbSet<SYS_DOMAIN> SYS_DOMAIN { get; set; }

	public DbSet<SYS_HANDLER> SYS_HANDLER { get; set; }

	public DbSet<SYS_LIBRARY> SYS_LIBRARY { get; set; }

	public DbSet<SYS_MENU> SYS_MENU { get; set; }

	public DbSet<SYS_MODULE> SYS_MODULE { get; set; }

	public DbSet<SYS_ORG> SYS_ORG { get; set; }

	public DbSet<SYS_PRIVILEGE> SYS_PRIVILEGE { get; set; }

	public DbSet<SYS_ROLE> SYS_ROLE { get; set; }

	public DbSet<SYS_ROLE_ORG> SYS_ROLE_ORG { get; set; }

	public DbSet<SYS_USER> SYS_USER { get; set; }

	public DbSet<SYS_USER_BUSINESS> SYS_USER_BUSINESS { get; set; }

	public DbSet<SYS_USER_ORG> SYS_USER_ORG { get; set; }

	public DbSet<SYS_USER_ROLE> SYS_USER_ROLE { get; set; }

	public DbSet<SYS_LOG> SYS_LOG { get; set; }

	public SystemManage()
		: base("SystemManage")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
