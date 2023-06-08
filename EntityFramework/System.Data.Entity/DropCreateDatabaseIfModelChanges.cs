using System.Data.Entity.ModelConfiguration.Utilities;
using System.Transactions;

namespace System.Data.Entity;

/// <summary>
/// An implementation of IDatabaseInitializer that will <b>DELETE</b>, recreate, and optionally re-seed the
/// database only if the model has changed since the database was created.
/// </summary>
/// <remarks>
/// Whether or not the model has changed is determined by the <see cref="M:System.Data.Entity.Database.CompatibleWithModel(System.Boolean)" />
/// method.
/// To seed the database create a derived class and override the Seed method.
/// </remarks>
public class DropCreateDatabaseIfModelChanges<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
{
	/// <summary>
	///     Executes the strategy to initialize the database for the given context.
	/// </summary>
	/// <param name="context">The context.</param>
	public void InitializeDatabase(TContext context)
	{
		RuntimeFailureMethods.Requires(context != null, null, "context != null");
		bool flag;
		using (new TransactionScope(TransactionScopeOption.Suppress))
		{
			flag = context.Database.Exists();
		}
		if (flag)
		{
			Database database = context.Database;
			bool throwIfNoMetadata = true;
			if (database.CompatibleWithModel(throwIfNoMetadata))
			{
				return;
			}
			context.Database.Delete();
		}
		context.Database.Create();
		Seed(context);
		context.SaveChanges();
	}

	/// <summary>
	///     A that should be overridden to actually add data to the context for seeding. 
	///     The default implementation does nothing.
	/// </summary>
	/// <param name="context">The context to seed.</param>
	protected virtual void Seed(TContext context)
	{
	}
}
