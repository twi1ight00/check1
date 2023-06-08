using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.ScheduleManagement.Domain.Models;

public class ScheduleManagement : DBContextBase
{
	public DbSet<SCH_BELONGER_USER> SCH_BELONGER_USER { get; set; }

	public DbSet<SCH_INFO> SCH_INFO { get; set; }

	public DbSet<SCH_PARTICIPANTS_USER> SCH_PARTICIPANTS_USER { get; set; }

	public DbSet<SYS_USER> SYS_USER { get; set; }

	public ScheduleManagement()
		: base("ScheduleManagement")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
