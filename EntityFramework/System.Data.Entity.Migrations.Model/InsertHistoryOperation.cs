using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Reflection;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents inserting a new record into the migrations history table.
/// The migrations history table is used to store a log of the migrations that have been applied to the database.
/// </summary>
public class InsertHistoryOperation : HistoryOperation
{
	private static readonly string _productVersion = Assembly.GetExecutingAssembly().GetInformationalVersion();

	private readonly DateTime _createdOn;

	private readonly byte[] _model;

	/// <summary>
	/// Gets the value to store in the history table indicating when this entry was created.
	/// </summary>
	public DateTime CreatedOn => _createdOn;

	/// <summary>
	/// Gets the value to store in the history table representing the target model of the migration.
	/// </summary>
	public byte[] Model => _model;

	/// <summary>
	/// Gets the value to store in the history table indicating the version of Entity Framework used to produce this migration.
	/// </summary>
	public string ProductVersion => _productVersion;

	/// <inheritdoc />
	public override bool IsDestructiveChange => false;

	/// <summary>
	/// Initializes a new instance of the InsertHistoryOperation class.
	/// </summary>
	/// <param name="table">Name of the migrations history table.</param>
	/// <param name="migrationId">Id of the migration record to be inserted.</param>
	/// <param name="model">Value to be stored in the model column.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	public InsertHistoryOperation(string table, string migrationId, byte[] model, object anonymousArguments = null)
	{
		RuntimeFailureMethods.Requires(model != null, null, "model != null");
		base._002Ector(table, migrationId, anonymousArguments);
		_createdOn = DateTime.UtcNow;
		_model = model;
	}
}
