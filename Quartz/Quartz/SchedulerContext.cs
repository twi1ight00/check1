using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Quartz.Util;

namespace Quartz;

/// <summary>
/// Holds context/environment data that can be made available to Jobs as they
/// are executed. 
/// </summary>
/// <remarks>
/// Future versions of Quartz may make distinctions on how it propagates
/// data in <see cref="T:Quartz.SchedulerContext" /> between instances of proxies to a 
/// single scheduler instance - i.e. if Quartz is being used via WCF of Remoting.
/// </remarks>
/// <seealso cref="P:Quartz.IScheduler.Context" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class SchedulerContext : StringKeyDirtyFlagMap
{
	/// <summary>
	/// Create an empty <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public SchedulerContext()
		: base(15)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.JobDataMap" /> with the given data.
	/// </summary>
	public SchedulerContext(IDictionary<string, object> map)
		: this()
	{
		PutAll(map);
	}

	/// <summary>
	/// Serialization constructor.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected SchedulerContext(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
