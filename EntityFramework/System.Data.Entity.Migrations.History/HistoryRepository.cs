using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Internal;
using System.Data.Entity.Migrations.Edm;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Utilities;
using System.Data.Entity.Resources;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Xml.Linq;

namespace System.Data.Entity.Migrations.History;

internal class HistoryRepository : RepositoryBase
{
	public HistoryRepository(string connectionString, DbProviderFactory providerFactory)
		: base(connectionString, providerFactory)
	{
	}

	public virtual XDocument GetLastModel()
	{
		string migrationId;
		return GetLastModel(out migrationId);
	}

	public virtual XDocument GetLastModel(out string migrationId)
	{
		migrationId = null;
		using HistoryContext historyContext = new HistoryContext(CreateConnection());
		if (!Exists(historyContext))
		{
			return null;
		}
		var anon = (from h in historyContext.History
			orderby h.CreatedOn descending
			select h into s
			select new { s.MigrationId, s.Model }).FirstOrDefault();
		if (anon == null)
		{
			return null;
		}
		migrationId = anon.MigrationId;
		return new ModelCompressor().Decompress(anon.Model);
	}

	public virtual XDocument GetModel(string migrationId)
	{
		using HistoryContext historyContext = new HistoryContext(CreateConnection());
		if (!Exists(historyContext))
		{
			return null;
		}
		byte[] array = (from h in historyContext.History
			where h.MigrationId == migrationId
			select h.Model).Single();
		if (array == null)
		{
			return null;
		}
		return new ModelCompressor().Decompress(array);
	}

	public virtual IEnumerable<string> GetPendingMigrations(IEnumerable<string> localMigrations)
	{
		using HistoryContext historyContext = new HistoryContext(CreateConnection());
		if (!Exists(historyContext))
		{
			return localMigrations;
		}
		return localMigrations.Except(historyContext.History.Select((HistoryRow s) => s.MigrationId)).ToList();
	}

	public virtual IEnumerable<string> GetMigrationsSince(string migrationId)
	{
		using HistoryContext historyContext = new HistoryContext(CreateConnection());
		IQueryable<HistoryRow> source = historyContext.History.AsQueryable();
		bool flag = Exists(historyContext);
		if (migrationId != "0")
		{
			if (!flag || !historyContext.History.Any((HistoryRow h) => h.MigrationId == migrationId))
			{
				throw Error.MigrationNotFound(migrationId);
			}
			DateTime sinceDate = (from h in historyContext.History
				where h.MigrationId == migrationId
				select h.CreatedOn).Single();
			source = source.Where((HistoryRow h) => h.CreatedOn > sinceDate);
		}
		else if (!flag)
		{
			return Enumerable.Empty<string>();
		}
		return (from h in source
			orderby h.CreatedOn descending
			select h.MigrationId).ToList();
	}

	public virtual string GetMigrationId(string migrationName)
	{
		using HistoryContext historyContext = new HistoryContext(CreateConnection());
		if (!Exists(historyContext))
		{
			return null;
		}
		List<string> source = (from h in historyContext.History
			select h.MigrationId into m
			where m.Substring(16) == migrationName
			select m).ToList();
		if (!source.Any())
		{
			return null;
		}
		if (source.Count() == 1)
		{
			return source.Single();
		}
		throw Error.AmbiguousMigrationName(migrationName);
	}

	public virtual bool Exists()
	{
		using HistoryContext context = new HistoryContext(CreateConnection());
		return Exists(context);
	}

	public virtual IEnumerable<MigrationOperation> GetUpgradeOperations()
	{
		if (NeedsUpgrade())
		{
			yield return new DropColumnOperation("__MigrationHistory", "Hash");
			yield return new AddColumnOperation("__MigrationHistory", new ColumnModel(PrimitiveTypeKind.String)
			{
				MaxLength = 32,
				Name = "ProductVersion",
				IsNullable = false,
				DefaultValue = "0.7.0.0"
			});
		}
	}

	private bool NeedsUpgrade()
	{
		using (HistoryContext historyContext = new HistoryContext(CreateConnection()))
		{
			if (Exists(historyContext))
			{
				try
				{
					historyContext.History.Select((HistoryRow h) => h.ProductVersion).FirstOrDefault();
				}
				catch (EntityException)
				{
					return true;
				}
			}
		}
		return false;
	}

	public virtual MigrationOperation CreateCreateTableOperation(ModelDiffer modelDiffer)
	{
		using DbConnection existingConnection = CreateConnection();
		using HistoryContext context2 = new HistoryContext(existingConnection, contextOwnsConnection: false);
		using EmptyContext context = new EmptyContext(existingConnection);
		IEnumerable<MigrationOperation> source = modelDiffer.Diff(context.GetModel(), context2.GetModel(), null);
		CreateTableOperation createTableOperation = source.OfType<CreateTableOperation>().Single();
		createTableOperation.AnonymousArguments.Add("IsMSShipped", true);
		return createTableOperation;
	}

	public virtual MigrationOperation CreateDropTableOperation(ModelDiffer modelDiffer)
	{
		using DbConnection existingConnection = CreateConnection();
		using HistoryContext context = new HistoryContext(existingConnection, contextOwnsConnection: false);
		using EmptyContext context2 = new EmptyContext(existingConnection);
		IEnumerable<MigrationOperation> source = modelDiffer.Diff(context.GetModel(), context2.GetModel(), null);
		return source.OfType<DropTableOperation>().Single();
	}

	public virtual MigrationOperation CreateInsertOperation(string migrationId, XDocument model)
	{
		return new InsertHistoryOperation("__MigrationHistory", migrationId, new ModelCompressor().Compress(model));
	}

	public virtual MigrationOperation CreateDeleteOperation(string migrationId)
	{
		return new DeleteHistoryOperation("__MigrationHistory", migrationId);
	}

	public virtual void BootstrapUsingEFProviderDdl(XDocument model)
	{
		using HistoryContext historyContext = new HistoryContext(CreateConnection());
		historyContext.Database.ExecuteSqlCommand(((IObjectContextAdapter)historyContext).ObjectContext.CreateDatabaseScript());
		historyContext.History.Add(new HistoryRow
		{
			MigrationId = MigrationAssembly.CreateMigrationId(Strings.InitialCreate),
			CreatedOn = DateTime.UtcNow,
			Model = new ModelCompressor().Compress(model),
			ProductVersion = Assembly.GetExecutingAssembly().GetInformationalVersion()
		});
		historyContext.SaveChanges();
	}

	private static bool Exists(HistoryContext context)
	{
		bool flag;
		using (new TransactionScope(TransactionScopeOption.Suppress))
		{
			flag = context.Database.Exists();
		}
		if (flag)
		{
			try
			{
				context.History.Count();
				return true;
			}
			catch (EntityException)
			{
			}
		}
		return false;
	}
}
