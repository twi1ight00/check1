using System.Collections.Generic;
using System.Data.Entity.Internal;
using System.Data.Entity.Resources;
using System.Data.Objects;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Data.Entity.Infrastructure;

[Serializable]
[SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "SerializeObjectState used instead")]
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbUpdateException : DataException
{
	/// <summary>
	///     Holds exception state that will be serialized when the exception is serialized.
	/// </summary>
	[Serializable]
	private struct DbUpdateExceptionState : ISafeSerializationData
	{
		/// <summary>
		///     Gets or sets a value indicating whether the exception involved independent associations.
		/// </summary>
		public bool InvolvesIndependentAssociations { get; set; }

		/// <summary>
		///     Completes the deserialization.
		/// </summary>
		/// <param name="deserialized">The deserialized object.</param>
		public void CompleteDeserialization(object deserialized)
		{
			((DbUpdateException)deserialized)._state = this;
		}
	}

	[NonSerialized]
	private readonly InternalContext _internalContext;

	[NonSerialized]
	private DbUpdateExceptionState _state;

	[CompilerGenerated]
	private static Func<ObjectStateEntry, bool> CS_0024_003C_003E9__CachedAnonymousMethodDelegate2;

	/// <summary>
	///     Gets <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> objects that represents the entities that could not
	///     be saved to the database.
	/// </summary>
	/// <returns>The entries representing the entities that could not be saved.</returns>
	public IEnumerable<DbEntityEntry> Entries
	{
		get
		{
			UpdateException ex = base.InnerException as UpdateException;
			if (_state.InvolvesIndependentAssociations || _internalContext == null || ex == null || ex.StateEntries == null)
			{
				return Enumerable.Empty<DbEntityEntry>();
			}
			_ = ex.StateEntries;
			if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate2 == null)
			{
				CS_0024_003C_003E9__CachedAnonymousMethodDelegate2 = (ObjectStateEntry e) => e.Entity == null;
			}
			return ex.StateEntries.Select((ObjectStateEntry e) => new DbEntityEntry(new InternalEntityEntry(_internalContext, new StateEntryAdapter(e))));
		}
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbUpdateException" /> class.
	/// </summary>
	/// <param name="internalContext">The internal context.</param>
	/// <param name="innerException">The inner exception.</param>
	internal DbUpdateException(InternalContext internalContext, UpdateException innerException, bool involvesIndependentAssociations)
		: base(involvesIndependentAssociations ? Strings.DbContext_IndependentAssociationUpdateException : innerException.Message, innerException)
	{
		_internalContext = internalContext;
		_state.InvolvesIndependentAssociations = involvesIndependentAssociations;
		SubscribeToSerializeObjectState();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbUpdateException" /> class.
	/// </summary>
	public DbUpdateException()
	{
		SubscribeToSerializeObjectState();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbUpdateException" /> class.
	/// </summary>
	/// <param name="message">The message.</param>
	public DbUpdateException(string message)
		: base(message)
	{
		SubscribeToSerializeObjectState();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbUpdateException" /> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="innerException">The inner exception.</param>
	public DbUpdateException(string message, Exception innerException)
		: base(message, innerException)
	{
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
