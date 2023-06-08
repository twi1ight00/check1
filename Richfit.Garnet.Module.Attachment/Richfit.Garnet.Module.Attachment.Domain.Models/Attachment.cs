using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Attachment.Domain.Models;

public class Attachment : DBContextBase
{
	public DbSet<SYS_ATTACHMENT> SYS_ATTACHMENT { get; set; }

	public DbSet<SYS_ATTACHMENT_MAPPING> SYS_ATTACHMENT_MAPPING { get; set; }

	public Attachment()
		: base("Attachment")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
