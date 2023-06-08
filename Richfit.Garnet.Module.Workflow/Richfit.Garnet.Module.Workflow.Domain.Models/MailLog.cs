using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Workflow.Domain.Models;

public class MailLog : DBContextBase
{
	public DbSet<SYS_MAIL_LOG> SYS_MAIL_LOG { get; set; }

	public DbSet<SYS_MESSAGE_LOG> SYS_MESSAGE_LOG { get; set; }

	public MailLog()
		: base("MailLog")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
