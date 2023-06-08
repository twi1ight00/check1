using System.Data.Common;
using System.Data.Entity.ModelConfiguration;

namespace System.Data.Entity.Migrations.History;

internal class HistoryContext : DbContext
{
	private class HistoryRowConfiguration : EntityTypeConfiguration<HistoryRow>
	{
		public HistoryRowConfiguration()
		{
			ToTable("__MigrationHistory");
			HasKey((HistoryRow h) => h.MigrationId);
			Property((HistoryRow h) => h.MigrationId).HasMaxLength(255).IsRequired();
			Property((HistoryRow h) => h.Model).IsRequired().IsMaxLength();
			Property((HistoryRow h) => h.ProductVersion).HasMaxLength(32).IsRequired();
		}
	}

	internal const string TableName = "__MigrationHistory";

	public virtual IDbSet<HistoryRow> History { get; set; }

	static HistoryContext()
	{
		Database.SetInitializer<HistoryContext>(null);
	}

	public HistoryContext(DbConnection existingConnection, bool contextOwnsConnection = true)
		: base(existingConnection, contextOwnsConnection)
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		modelBuilder.Configurations.Add(new HistoryRowConfiguration());
	}
}
