using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Supervise.Domain.Models;

public class Supervise : DBContextBase
{
	public DbSet<SUP_ASSIGN_TASK> SUP_ASSIGN_TASK { get; set; }

	public DbSet<SUP_CHANGE> SUP_CHANGE { get; set; }

	public DbSet<SUP_FEED_BACK> SUP_FEED_BACK { get; set; }

	public DbSet<SUP_PORJECT> SUP_PORJECT { get; set; }

	public DbSet<SUP_PORJECT_USER> SUP_PORJECT_USER { get; set; }

	public DbSet<SUP_TASK_PROGRESS> SUP_TASK_PROGRESS { get; set; }

	public DbSet<SUP_TASK_USER> SUP_TASK_USER { get; set; }

	public DbSet<SYS_USER> SYS_USER { get; set; }

	public Supervise()
		: base("Supervise")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
