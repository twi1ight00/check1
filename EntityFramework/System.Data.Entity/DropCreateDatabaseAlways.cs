using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity;

/// <summary>
///     An implementation of IDatabaseInitializer that will always recreate and optionally re-seed the
///     database the first time that a context is used in the app domain.
///     To seed the database, create a derived class and override the Seed method.
/// </summary>
/// <typeparam name="TContext">The type of the context.</typeparam>
public class DropCreateDatabaseAlways<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
{
	/// <summary>
	///     Executes the strategy to initialize the database for the given context.
	/// </summary>
	/// <param name="context">The context.</param>
	public void InitializeDatabase(TContext context)
	{
		RuntimeFailureMethods.Requires(context != null, null, "context != null");
		context.Database.Delete();
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
