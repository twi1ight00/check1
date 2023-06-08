using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.CodeTableManagement.Domain.Models;

public class CodeTable : DBContextBase
{
	public DbSet<SYS_CODE_TABLE> SYS_CODE_TABLE { get; set; }

	public CodeTable()
		: base("CodeTable")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
