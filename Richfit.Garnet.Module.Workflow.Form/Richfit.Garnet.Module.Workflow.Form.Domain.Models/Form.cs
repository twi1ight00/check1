using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Workflow.Form.Domain.Models;

public class Form : DBContextBase
{
	public DbSet<W_HR_EMPLOYEE_RESUME> W_HR_EMPLOYEE_RESUME { get; set; }

	public Form()
		: base("Form")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
