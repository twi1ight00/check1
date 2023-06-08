using System;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Fails a node when the specified number of failures happen in a specified time window.
/// </summary>
public class ThrottlingFailurePolicy : INodeFailurePolicy
{
	private static readonly ILog log = LogManager.GetLogger(typeof(ThrottlingFailurePolicy));

	private static readonly bool LogIsDebugEnabled = log.IsDebugEnabled;

	private int resetAfter;

	private int failureThreshold;

	private DateTime lastFailed;

	private int failCounter;

	/// <summary>
	/// Creates a new instance of <see cref="T:ThrottlingFailurePolicy" />.
	/// </summary>
	/// <param name="resetAfter">Specifies the time in milliseconds how long a node should function properly to reset its failure counter.</param>
	/// <param name="failureThreshold">Specifies the number of failures that must occur in the specified time window to fail a node.</param>
	public ThrottlingFailurePolicy(int resetAfter, int failureThreshold)
	{
		this.resetAfter = resetAfter;
		this.failureThreshold = failureThreshold;
	}

	bool INodeFailurePolicy.ShouldFail()
	{
		DateTime now = DateTime.UtcNow;
		if (lastFailed == DateTime.MinValue)
		{
			if (LogIsDebugEnabled)
			{
				log.Debug("Setting fail counter to 1.");
			}
			failCounter = 1;
		}
		else
		{
			int diff = (int)(now - lastFailed).TotalMilliseconds;
			if (LogIsDebugEnabled)
			{
				log.DebugFormat("Last fail was {0} msec ago with counter {1}.", diff, failCounter);
			}
			if (diff <= resetAfter)
			{
				failCounter++;
			}
			else
			{
				failCounter = 1;
			}
		}
		lastFailed = now;
		if (failCounter == failureThreshold)
		{
			if (LogIsDebugEnabled)
			{
				log.DebugFormat("Threshold reached, node will fail.");
			}
			lastFailed = DateTime.MinValue;
			failCounter = 0;
			return true;
		}
		if (LogIsDebugEnabled)
		{
			log.DebugFormat("Current counter is {0}, threshold not reached.", failCounter);
		}
		return false;
	}
}
