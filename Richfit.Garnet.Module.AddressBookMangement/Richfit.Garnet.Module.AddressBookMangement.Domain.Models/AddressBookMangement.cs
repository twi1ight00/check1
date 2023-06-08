using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.AddressBookMangement.Domain.Models;

public class AddressBookMangement : DBContextBase
{
	public DbSet<AB_CATEGORY> AB_CATEGORY { get; set; }

	public DbSet<AB_CONTACT> AB_CONTACT { get; set; }

	public DbSet<AB_GROUP_CONTACT> AB_GROUP_CONTACT { get; set; }

	public DbSet<AB_ORG_CONTACT> AB_ORG_CONTACT { get; set; }

	public DbSet<AB_PERSONAL_GROUP> AB_PERSONAL_GROUP { get; set; }

	public DbSet<AB_VIRTUAL_CONTACT> AB_VIRTUAL_CONTACT { get; set; }

	public DbSet<AB_VIRTUAL_ORG> AB_VIRTUAL_ORG { get; set; }

	public DbSet<HR_EMPLOYEE> HR_EMPLOYEE { get; set; }

	public DbSet<SYS_ORG> SYS_ORG { get; set; }

	public AddressBookMangement()
		: base("AddressBookMangement")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
