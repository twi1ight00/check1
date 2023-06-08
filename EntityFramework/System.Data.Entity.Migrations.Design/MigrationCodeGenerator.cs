using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;

namespace System.Data.Entity.Migrations.Design;

/// <summary>
/// Base class for providers that generate code for code-based migrations.
/// </summary>
public abstract class MigrationCodeGenerator
{
	/// <summary>
	/// Generates the code that should be added to the users project.
	/// </summary>
	/// <param name="migrationId">Unique identifier of the migration.</param>
	/// <param name="operations">Operations to be performed by the migration.</param>
	/// <param name="sourceModel">Source model to be stored in the migration metadata.</param>
	/// <param name="targetModel">Target model to be stored in the migration metadata.</param>
	/// <param name="namespace">Namespace that code should be generated in.</param>
	/// <param name="className">Name of the class that should be generated.</param>
	/// <returns>The generated code.</returns>
	public abstract ScaffoldedMigration Generate(string migrationId, IEnumerable<MigrationOperation> operations, string sourceModel, string targetModel, string @namespace, string className);
}
