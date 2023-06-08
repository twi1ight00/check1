using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.MeetingManagement.Domain.Models;

public class MeetingManage : DBContextBase
{
	public DbSet<MM_MEETING_APPLY> MM_MEETING_APPLY { get; set; }

	public DbSet<MM_MEETING_PARTICIPANTS> MM_MEETING_PARTICIPANTS { get; set; }

	public MeetingManage()
		: base("MeetingManage")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
