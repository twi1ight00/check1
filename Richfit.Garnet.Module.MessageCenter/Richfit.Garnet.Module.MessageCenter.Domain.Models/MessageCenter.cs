using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.MessageCenter.Domain.Models;

public class MessageCenter : DBContextBase
{
	public DbSet<MSG_CENTER> MSG_CENTER { get; set; }

	public DbSet<MSG_CENTER_USER> MSG_CENTER_USER { get; set; }

	public MessageCenter()
		: base("MessageCenter")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
