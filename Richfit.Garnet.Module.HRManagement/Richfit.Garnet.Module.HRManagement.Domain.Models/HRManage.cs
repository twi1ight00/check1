using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.HRManagement.Domain.Models;

public class HRManage : DBContextBase
{
	public DbSet<AB_CONTACT> AB_CONTACT { get; set; }

	public DbSet<AB_ORG_CONTACT> AB_ORG_CONTACT { get; set; }

	public DbSet<HR_DONATE_BLOOD> HR_DONATE_BLOOD { get; set; }

	public DbSet<HR_EMPLOYEE> HR_EMPLOYEE { get; set; }

	public DbSet<HR_VACATION_DAYS> HR_VACATION_DAYS { get; set; }

	public DbSet<LY_INFO> LY_INFO { get; set; }

	public DbSet<S_TEMP_STO_HRMANAGEMENT> S_TEMP_STO_HRMANAGEMENT { get; set; }

	public DbSet<SYS_ORG> SYS_ORG { get; set; }

	public HRManage()
		: base("HRManage")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
