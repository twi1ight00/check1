using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class Workflow : DBContextBase
{
	public DbSet<WF_ACTIVITY> WF_ACTIVITY { get; set; }

	public DbSet<WF_ACTIVITY_PARTICIPANT> WF_ACTIVITY_PARTICIPANT { get; set; }

	public DbSet<WF_DATA_HISTORY> WF_DATA_HISTORY { get; set; }

	public DbSet<WF_FORM> WF_FORM { get; set; }

	public DbSet<WF_FORM_DEFINITION> WF_FORM_DEFINITION { get; set; }

	public DbSet<WF_FORM_DEFINITION_DATA> WF_FORM_DEFINITION_DATA { get; set; }

	public DbSet<WF_INSTANCE> WF_INSTANCE { get; set; }

	public DbSet<WF_INSTANCE_ACTIVITY> WF_INSTANCE_ACTIVITY { get; set; }

	public DbSet<WF_INSTANCE_ACTIVITY_USER> WF_INSTANCE_ACTIVITY_USER { get; set; }

	public DbSet<WF_META_TABLE> WF_META_TABLE { get; set; }

	public DbSet<WF_METADATA> WF_METADATA { get; set; }

	public DbSet<WF_PACKAGE> WF_PACKAGE { get; set; }

	public DbSet<WF_PAGE> WF_PAGE { get; set; }

	public DbSet<WF_PAGE_EVENT> WF_PAGE_EVENT { get; set; }

	public DbSet<WF_RULE> WF_RULE { get; set; }

	public DbSet<WF_TEMPLATE> WF_TEMPLATE { get; set; }

	public DbSet<WF_TEMPLATE_AUTHORIZATION> WF_TEMPLATE_AUTHORIZATION { get; set; }

	public DbSet<WF_WORKITEM> WF_WORKITEM { get; set; }

	public DbSet<WF_WORKITEM_HANDLER> WF_WORKITEM_HANDLER { get; set; }

	public Workflow()
		: base("Workflow")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
