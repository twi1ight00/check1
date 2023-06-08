using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Transactions;

namespace System.Data.Entity;

/// <summary>
///     An implementation of IDatabaseInitializer that will recreate and optionally re-seed the
///     database only if the database does not exist.
///     To seed the database, create a derived class and override the Seed method.
/// </summary>
/// <typeparam name="TContext">The type of the context.</typeparam>
public class CreateDatabaseIfNotExists<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
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
			bool throwIfNoMetadata = false;
			if (!database.CompatibleWithModel(throwIfNoMetadata))
			{
				throw Error.DatabaseInitializationStrategy_ModelMismatch(context.GetType().Name);
			}
		}
		else
		{
			context.Database.Create();
			Seed(context);
			context.SaveChanges();
		}
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
