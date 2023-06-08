using System;
using System.Collections.Generic;

namespace Quartz.Listener;

/// <summary>
/// Holds a List of references to JobListener instances and broadcasts all
/// events to them (in order).
/// </summary>
/// <remarks>
/// <para>The broadcasting behavior of this listener to delegate listeners may be
/// more convenient than registering all of the listeners directly with the
/// Scheduler, and provides the flexibility of easily changing which listeners
/// get notified.</para>
/// </remarks>
/// <seealso cref="M:Quartz.Listener.BroadcastJobListener.AddListener(Quartz.IJobListener)" />
/// <seealso cref="M:Quartz.Listener.BroadcastJobListener.RemoveListener(Quartz.IJobListener)" />
/// <seealso cref="M:Quartz.Listener.BroadcastJobListener.RemoveListener(System.String)" />
/// <author>James House (jhouse AT revolition DOT net)</author>
public class BroadcastJobListener : IJobListener
{
	private readonly string name;

	private readonly List<IJobListener> listeners;

	public string Name => name;

	public IList<IJobListener> Listeners => listeners.AsReadOnly();

	/// <summary>
	/// Construct an instance with the given name.
	/// </summary>
	/// <remarks>
	/// (Remember to add some delegate listeners!)
	/// </remarks>
	/// <param name="name">the name of this instance</param>
	public BroadcastJobListener(string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name", "Listener name cannot be null!");
		}
		this.name = name;
		listeners = new List<IJobListener>();
	}

	/// <summary>
	/// Construct an instance with the given name, and List of listeners.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="name">the name of this instance</param>
	/// <param name="listeners">the initial List of JobListeners to broadcast to.</param>
	public BroadcastJobListener(string name, List<IJobListener> listeners)
		: this(name)
	{
		this.listeners.AddRange(listeners);
	}

	public void AddListener(IJobListener listener)
	{
		listeners.Add(listener);
	}

	public bool RemoveListener(IJobListener listener)
	{
		return listeners.Remove(listener);
	}

	public bool RemoveListener(string listenerName)
	{
		IJobListener listener = listeners.Find((IJobListener x) => x.Name == listenerName);
		if (listener != null)
		{
			listeners.Remove(listener);
			return true;
		}
		return false;
	}

	public void JobToBeExecuted(IJobExecutionContext context)
	{
		foreach (IJobListener jl in listeners)
		{
			jl.JobToBeExecuted(context);
		}
	}

	public void JobExecutionVetoed(IJobExecutionContext context)
	{
		foreach (IJobListener jl in listeners)
		{
			jl.JobExecutionVetoed(context);
		}
	}

	public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
	{
		foreach (IJobListener jl in listeners)
		{
			jl.JobWasExecuted(context, jobException);
		}
	}
}
