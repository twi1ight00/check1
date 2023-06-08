using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.SiteMessage.Domain.Models;

public class Message : DBContextBase
{
	public DbSet<MSG_MESSAGE> MSG_MESSAGE { get; set; }

	public DbSet<MSG_MESSAGE_USER> MSG_MESSAGE_USER { get; set; }

	public Message()
		: base("Message")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
