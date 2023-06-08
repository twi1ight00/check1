using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.CMS.Domain.Models;

public class CMS : DBContextBase
{
	public DbSet<CMS_ARTICLE> CMS_ARTICLE { get; set; }

	public DbSet<CMS_ARTICLE_DATA> CMS_ARTICLE_DATA { get; set; }

	public DbSet<CMS_AUDIT> CMS_AUDIT { get; set; }

	public DbSet<CMS_CATEGORY> CMS_CATEGORY { get; set; }

	public DbSet<CMS_COMMENT> CMS_COMMENT { get; set; }

	public DbSet<CMS_GUESTBOOK> CMS_GUESTBOOK { get; set; }

	public DbSet<CMS_PUBLISH_USERS> CMS_PUBLISH_USERS { get; set; }

	public DbSet<CMS_VIEW_AUDIT> CMS_VIEW_AUDIT { get; set; }

	public DbSet<CMS_ARTICLE_DATA_TEMP> CMS_ARTICLE_DATA_TEMP { get; set; }

	public DbSet<CMS_SCANNED> CMS_SCANNED { get; set; }

	public CMS()
		: base("CMS")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
