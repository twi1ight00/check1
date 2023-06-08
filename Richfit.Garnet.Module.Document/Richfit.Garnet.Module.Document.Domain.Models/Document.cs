using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Document.Domain.Models;

public class Document : DBContextBase
{
	public DbSet<DOC_CONTENTS> DOC_CONTENTS { get; set; }

	public DbSet<DOC_FILE> DOC_FILE { get; set; }

	public Document()
		: base("Document")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
