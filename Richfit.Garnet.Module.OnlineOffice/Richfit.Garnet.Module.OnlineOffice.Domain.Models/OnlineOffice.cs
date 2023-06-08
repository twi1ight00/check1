using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.OnlineOffice.Domain.Models;

public class OnlineOffice : DBContextBase
{
	public DbSet<OL_OFFICE> OL_OFFICE { get; set; }

	public DbSet<OL_TEMPLATE_FILE> OL_TEMPLATE_FILE { get; set; }

	public DbSet<OL_TEMPLATE_FILE_MAPPING> OL_TEMPLATE_FILE_MAPPING { get; set; }

	public OnlineOffice()
		: base("OnlineOffice")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
