using System;
using System.Collections.Generic;
using System.Linq;

namespace Quartz.Listener;

/// <summary>
/// Holds a List of references to TriggerListener instances and broadcasts all
/// events to them (in order).
/// </summary>
/// <remarks>
/// <para>The broadcasting behavior of this listener to delegate listeners may be
/// more convenient than registering all of the listeners directly with the
/// Scheduler, and provides the flexibility of easily changing which listeners
/// get notified.</para>
/// </remarks>
/// <seealso cref="M:Quartz.Listener.BroadcastTriggerListener.AddListener(Quartz.ITriggerListener)" />
/// <seealso cref="M:Quartz.Listener.BroadcastTriggerListener.RemoveListener(Quartz.ITriggerListener)" />
/// <seealso cref="M:Quartz.Listener.BroadcastTriggerListener.RemoveListener(System.String)" />
/// <author>James House (jhouse AT revolition DOT net)</author>
public class BroadcastTriggerListener : ITriggerListener
{
	private readonly string name;

	private readonly List<ITriggerListener> listeners;

	public string Name => name;

	public IList<ITriggerListener> Listeners => listeners.AsReadOnly();

	/// <summary>
	/// Construct an instance with the given name.
	/// </summary>
	/// <remarks>
	/// (Remember to add some delegate listeners!)
	/// </remarks>
	/// <param name="name">the name of this instance</param>
	public BroadcastTriggerListener(string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name", "Listener name cannot be null!");
		}
		this.name = name;
		listeners = new List<ITriggerListener>();
	}

	/// <summary>
	/// Construct an instance with the given name, and List of listeners.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="name">the name of this instance</param>
	/// <param name="listeners">the initial List of TriggerListeners to broadcast to.</param>
	public BroadcastTriggerListener(string name, IList<ITriggerListener> listeners)
		: this(name)
	{
		this.listeners.AddRange(listeners);
	}

	public void AddListener(ITriggerListener listener)
	{
		listeners.Add(listener);
	}

	public bool RemoveListener(ITriggerListener listener)
	{
		return listeners.Remove(listener);
	}

	public bool RemoveListener(string listenerName)
	{
		ITriggerListener listener = listeners.Find((ITriggerListener x) => x.Name == listenerName);
		if (listener != null)
		{
			listeners.Remove(listener);
			return true;
		}
		return false;
	}

	public void TriggerFired(ITrigger trigger, IJobExecutionContext context)
	{
		foreach (ITriggerListener i in listeners)
		{
			i.TriggerFired(trigger, context);
		}
	}

	public bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
	{
		return listeners.Any((ITriggerListener l) => l.VetoJobExecution(trigger, context));
	}

	public void TriggerMisfired(ITrigger trigger)
	{
		foreach (ITriggerListener i in listeners)
		{
			i.TriggerMisfired(trigger);
		}
	}

	public void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode)
	{
		foreach (ITriggerListener i in listeners)
		{
			i.TriggerComplete(trigger, context, triggerInstructionCode);
		}
	}
}
