using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

namespace System.Data.Entity.Validation;

/// <summary>
///     Exception thrown from <see cref="M:System.Data.Entity.DbContext.SaveChanges" /> when validating entities fails.
/// </summary>
[Serializable]
[SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "SerializeObjectState used instead")]
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbEntityValidationException : DataException
{
	/// <summary>
	///     Holds exception state that will be serialized when the exception is serialized.
	/// </summary>
	[Serializable]
	private class DbEntityValidationExceptionState : ISafeSerializationData
	{
		/// <summary>
		///     Validation results.
		/// </summary>
		private IList<DbEntityValidationResult> _entityValidationResults;

		/// <summary>
		///     Validation results.
		/// </summary>
		public IEnumerable<DbEntityValidationResult> EntityValidationErrors => _entityValidationResults;

		internal void InititializeValidationResults(IEnumerable<DbEntityValidationResult> entityValidationResults)
		{
			_entityValidationResults = ((entityValidationResults == null) ? new List<DbEntityValidationResult>() : entityValidationResults.ToList());
		}

		/// <summary>
		///     Completes the deserialization.
		/// </summary>
		/// <param name="deserialized">The deserialized object.</param>
		public void CompleteDeserialization(object deserialized)
		{
			((DbEntityValidationException)deserialized)._state = this;
		}
	}

	[NonSerialized]
	private DbEntityValidationExceptionState _state;

	/// <summary>
	///     Validation results.
	/// </summary>
	public IEnumerable<DbEntityValidationResult> EntityValidationErrors => _state.EntityValidationErrors;

	/// <summary>
	///     Initializes a new instance of DbEntityValidationException
	/// </summary>
	public DbEntityValidationException()
		: this(Strings.DbEntityValidationException_ValidationFailed)
	{
	}

	/// <summary>
	///     Initializes a new instance of DbEntityValidationException
	/// </summary>
	/// <param name="message">The exception message.</param>
	public DbEntityValidationException(string message)
		: this(message, Enumerable.Empty<DbEntityValidationResult>())
	{
	}

	/// <summary>
	///     Initializes a new instance of DbEntityValidationException
	/// </summary>
	/// <param name="message">The exception message.</param>
	/// <param name="entityValidationResults">Validation results.</param>
	public DbEntityValidationException(string message, IEnumerable<DbEntityValidationResult> entityValidationResults)
	{
		RuntimeFailureMethods.Requires(entityValidationResults != null, null, "entityValidationResults != null");
		_state = new DbEntityValidationExceptionState();
		base._002Ector(message);
		_state.InititializeValidationResults(entityValidationResults);
		SubscribeToSerializeObjectState();
	}

	/// <summary>
	///     Initializes a new instance of DbEntityValidationException
	/// </summary>
	/// <param name="message">The exception message.</param>
	/// <param name="innerException">The inner exception.</param>
	public DbEntityValidationException(string message, Exception innerException)
		: this(message, Enumerable.Empty<DbEntityValidationResult>(), innerException)
	{
	}

	/// <summary>
	///     Initializes a new instance of DbEntityValidationException
	/// </summary>
	/// <param name="message">The exception message.</param>
	/// <param name="entityValidationResults">Validation results.</param>
	/// <param name="innerException">The inner exception.</param>
	public DbEntityValidationException(string message, IEnumerable<DbEntityValidationResult> entityValidationResults, Exception innerException)
	{
		RuntimeFailureMethods.Requires(entityValidationResults != null, null, "entityValidationResults != null");
		_state = new DbEntityValidationExceptionState();
		base._002Ector(message, innerException);
		_state.InititializeValidationResults(entityValidationResults);
		SubscribeToSerializeObjectState();
	}

	/// <summary>
	///     Subscribes the SerializeObjectState event.
	/// </summary>
	private void SubscribeToSerializeObjectState()
	{
		base.SerializeObjectState += delegate(object exception, SafeSerializationEventArgs eventArgs)
		{
			eventArgs.AddSerializedState(_state);
		};
	}
}
