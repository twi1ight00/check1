using Quartz.Util;

namespace Quartz.Impl.Matchers;

/// <summary>
/// Matches on the complete key being equal (both name and group).
/// </summary>
/// <remarks>
/// </remarks>
/// <author>jhouse</author>
public class EverythingMatcher<TKey> : IMatcher<TKey> where TKey : Key<TKey>
{
	protected EverythingMatcher()
	{
	}

	/// <summary>
	/// Create an EverythingMatcher that matches all jobs.
	/// </summary>
	/// <returns></returns>
	public static EverythingMatcher<JobKey> AllJobs()
	{
		return new EverythingMatcher<JobKey>();
	}

	/// <summary>
	/// Create an EverythingMatcher that matches all triggers.
	/// </summary>
	/// <returns></returns>
	public static EverythingMatcher<TriggerKey> AllTriggers()
	{
		return new EverythingMatcher<TriggerKey>();
	}

	public bool IsMatch(TKey key)
	{
		return true;
	}

	public override bool Equals(object obj)
	{
		return obj?.GetType().Equals(GetType()) ?? false;
	}

	public override int GetHashCode()
	{
		return GetType().Name.GetHashCode();
	}
}
