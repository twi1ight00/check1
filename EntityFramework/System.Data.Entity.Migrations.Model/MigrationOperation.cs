using System.Collections.Generic;
using System.Data.Entity.Migrations.Extensions;
using System.Reflection;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents an operation to modify a database schema.
/// </summary>
public abstract class MigrationOperation
{
	private readonly IDictionary<string, object> _anonymousArguments = new Dictionary<string, object>();

	/// <summary>
	/// Gets additional arguments that may be processed by providers.
	/// </summary>
	public IDictionary<string, object> AnonymousArguments => _anonymousArguments;

	/// <summary>
	/// Gets an operation that will revert this operation.
	/// </summary>
	public virtual MigrationOperation Inverse => null;

	/// <summary>
	/// Gets a value indicating if this operation may result in data loss.
	/// </summary>
	public abstract bool IsDestructiveChange { get; }

	/// <summary>
	/// Initializes a new instance of the MigrationOperation class.
	/// </summary>
	/// <param name="anonymousArguments">
	///
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	protected MigrationOperation(object anonymousArguments)
	{
		MigrationOperation migrationOperation = this;
		if (anonymousArguments != null)
		{
			anonymousArguments.GetType().GetProperties().Each(delegate(PropertyInfo p)
			{
				migrationOperation._anonymousArguments.Add(p.Name, p.GetValue(anonymousArguments, null));
			});
		}
	}
}
