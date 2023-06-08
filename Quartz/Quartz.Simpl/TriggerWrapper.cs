using System;
using Quartz.Spi;

namespace Quartz.Simpl;

/// <summary>
/// Helper wrapper class
/// </summary>
public class TriggerWrapper : IEquatable<TriggerWrapper>
{
	/// <summary>
	/// The key used
	/// </summary>
	public readonly TriggerKey key;

	/// <summary>
	/// Job's key
	/// </summary>
	public readonly JobKey jobKey;

	/// <summary>
	/// The trigger
	/// </summary>
	public readonly IOperableTrigger trigger;

	/// <summary>
	/// Current state
	/// </summary>
	public InternalTriggerState state;

	internal TriggerWrapper(IOperableTrigger trigger)
	{
		this.trigger = trigger;
		key = trigger.Key;
		jobKey = trigger.JobKey;
	}

	public bool Equals(TriggerWrapper other)
	{
		return other?.key.Equals(key) ?? false;
	}

	/// <summary>
	/// Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
	/// </summary>
	/// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
	/// <returns>
	/// true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
	/// </returns>
	public override bool Equals(object obj)
	{
		return Equals(obj as TriggerWrapper);
	}

	/// <summary>
	/// Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
	/// </summary>
	/// <returns>
	/// A hash code for the current <see cref="T:System.Object"></see>.
	/// </returns>
	public override int GetHashCode()
	{
		return key.GetHashCode();
	}
}
