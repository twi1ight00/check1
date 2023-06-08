using System.Data.Objects;

namespace System.Data.Entity.Internal;

/// <summary>
///     The methods here are called from multiple places with an ObjectContext that may have
///     been created in a variety of ways and ensure that the same code is run regardless of
///     how the context was created.
/// </summary>
internal class DatabaseOperations
{
	/// <summary>
	///     Used a delegate to do the actual creation once an ObjectContext has been obtained.
	///     This is factored in this way so that we do the same thing regardless of how we get to
	///     having an ObjectContext.
	///     Note however that a context obtained from only a connection will have no model and so
	///     will result in an empty database.
	/// </summary>
	public virtual bool Create(ObjectContext objectContext)
	{
		objectContext.CreateDatabase();
		return true;
	}

	/// <summary>
	///     Used a delegate to do the actual existence check once an ObjectContext has been obtained.
	///     This is factored in this way so that we do the same thing regardless of how we get to
	///     having an ObjectContext.
	/// </summary>
	public virtual bool Exists(ObjectContext objectContext)
	{
		try
		{
			return objectContext.DatabaseExists();
		}
		catch (Exception)
		{
			if (objectContext.Connection.State == ConnectionState.Open)
			{
				return true;
			}
			try
			{
				objectContext.Connection.Open();
				return true;
			}
			catch (EntityException)
			{
				return false;
			}
			finally
			{
				objectContext.Connection.Close();
			}
		}
	}

	/// <summary>
	///     Used a delegate to do the actual check/delete once an ObjectContext has been obtained.
	///     This is factored in this way so that we do the same thing regardless of how we get to
	///     having an ObjectContext.
	/// </summary>
	public virtual bool DeleteIfExists(ObjectContext objectContext)
	{
		if (Exists(objectContext))
		{
			objectContext.DeleteDatabase();
			return true;
		}
		return false;
	}
}
