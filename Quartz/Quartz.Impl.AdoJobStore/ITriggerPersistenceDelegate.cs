using Quartz.Spi;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// An interface which provides an implementation for storing a particular
/// type of <see cref="T:Quartz.ITrigger" />'s extended properties.
/// </summary>
/// <author>jhouse</author>
public interface ITriggerPersistenceDelegate
{
	/// <summary>
	/// Initializes the persistence delegate.
	/// </summary>
	void Initialize(string tablePrefix, string schedulerName, IDbAccessor dbAccessor);

	/// <summary>
	/// Returns whether the trigger type can be handled by delegate.
	/// </summary>
	bool CanHandleTriggerType(IOperableTrigger trigger);

	/// <summary>
	/// Returns database discriminator value for trigger type.
	/// </summary>
	string GetHandledTriggerTypeDiscriminator();

	/// <summary>
	/// Inserts trigger's special properties.
	/// </summary>
	int InsertExtendedTriggerProperties(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail jobDetail);

	/// <summary>
	/// Updates trigger's special properties.
	/// </summary>
	int UpdateExtendedTriggerProperties(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail jobDetail);

	/// <summary>
	/// Deletes trigger's special properties.
	/// </summary>
	int DeleteExtendedTriggerProperties(ConnectionAndTransactionHolder conn, TriggerKey triggerKey);

	/// <summary>
	/// Loads trigger's special properties.
	/// </summary>
	TriggerPropertyBundle LoadExtendedTriggerProperties(ConnectionAndTransactionHolder conn, TriggerKey triggerKey);
}
