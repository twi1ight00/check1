using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Quartz.Util;

namespace Quartz;

/// <summary>
/// Holds state information for <see cref="T:Quartz.IJob" /> instances.
/// </summary>
/// <remarks>
/// <see cref="T:Quartz.JobDataMap" /> instances are stored once when the <see cref="T:Quartz.IJob" />
/// is added to a scheduler. They are also re-persisted after every execution of
/// instances that have <see cref="T:Quartz.PersistJobDataAfterExecutionAttribute" /> present.
/// <para>
/// <see cref="T:Quartz.JobDataMap" /> instances can also be stored with a 
/// <see cref="T:Quartz.ITrigger" />.  This can be useful in the case where you have a Job
/// that is stored in the scheduler for regular/repeated use by multiple 
/// Triggers, yet with each independent triggering, you want to supply the
/// Job with different data inputs.  
/// </para>
/// <para>
/// The <see cref="T:Quartz.IJobExecutionContext" /> passed to a Job at execution time 
/// also contains a convenience <see cref="T:Quartz.JobDataMap" /> that is the result
/// of merging the contents of the trigger's JobDataMap (if any) over the
/// Job's JobDataMap (if any).  
/// </para>
/// </remarks>
/// <seealso cref="T:Quartz.IJob" />
/// <seealso cref="T:Quartz.PersistJobDataAfterExecutionAttribute" />
/// <seealso cref="T:Quartz.ITrigger" />
/// <seealso cref="T:Quartz.IJobExecutionContext" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class JobDataMap : StringKeyDirtyFlagMap
{
	/// <summary>
	/// Create an empty <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public JobDataMap()
		: base(15)
	{
	}

	/// <summary> 
	/// Create a <see cref="T:Quartz.JobDataMap" /> with the given data.
	/// </summary>
	public JobDataMap(IDictionary<string, object> map)
		: this()
	{
		PutAll(map);
	}

	/// <summary> 
	/// Create a <see cref="T:Quartz.JobDataMap" /> with the given data.
	/// </summary>
	public JobDataMap(IDictionary map)
		: this()
	{
		foreach (DictionaryEntry entry in map)
		{
			Put((string)entry.Key, entry.Value);
		}
	}

	/// <summary>
	/// Serialization constructor.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected JobDataMap(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	/// <summary>
	/// Adds the given <see cref="T:System.Boolean" /> value as a string version to the
	/// <see cref="T:Quartz.IJob" />'s data map.
	/// </summary>
	public virtual void PutAsString(string key, bool value)
	{
		string strValue = value.ToString();
		base.Put(key, strValue);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.Char" /> value as a string version to the
	/// <see cref="T:Quartz.IJob" />'s data map.
	/// </summary>
	public virtual void PutAsString(string key, char value)
	{
		string strValue = value.ToString(CultureInfo.InvariantCulture);
		base.Put(key, strValue);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.Double" /> value as a string version to the
	/// <see cref="T:Quartz.IJob" />'s data map.
	/// </summary>
	public virtual void PutAsString(string key, double value)
	{
		string strValue = value.ToString(CultureInfo.InvariantCulture);
		base.Put(key, strValue);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.Single" /> value as a string version to the
	/// <see cref="T:Quartz.IJob" />'s data map.
	/// </summary>
	public virtual void PutAsString(string key, float value)
	{
		string strValue = value.ToString(CultureInfo.InvariantCulture);
		base.Put(key, strValue);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.Int32" /> value as a string version to the
	/// <see cref="T:Quartz.IJob" />'s data map.
	/// </summary>
	public virtual void PutAsString(string key, int value)
	{
		string strValue = value.ToString(CultureInfo.InvariantCulture);
		base.Put(key, strValue);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.Int64" /> value as a string version to the
	/// <see cref="T:Quartz.IJob" />'s data map.
	/// </summary>
	public virtual void PutAsString(string key, long value)
	{
		string strValue = value.ToString(CultureInfo.InvariantCulture);
		base.Put(key, strValue);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.DateTime" /> value as a string version to the
	/// <see cref="T:Quartz.IJob" />'s data map.
	/// </summary>
	public virtual void PutAsString(string key, DateTime value)
	{
		string strValue = value.ToString(CultureInfo.InvariantCulture);
		base.Put(key, strValue);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.DateTimeOffset" /> value as a string version to the
	/// <see cref="T:Quartz.IJob" />'s data map.
	/// </summary>
	public virtual void PutAsString(string key, DateTimeOffset value)
	{
		string strValue = value.ToString(CultureInfo.InvariantCulture);
		base.Put(key, strValue);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.TimeSpan" /> value as a string version to the
	/// <see cref="T:Quartz.IJob" />'s data map.
	/// </summary>
	public virtual void PutAsString(string key, TimeSpan value)
	{
		string strValue = value.ToString();
		base.Put(key, strValue);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Int32" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual int GetIntValueFromString(string key)
	{
		object obj = Get(key);
		return int.Parse((string)obj, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Int32" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual int GetIntValue(string key)
	{
		object obj = Get(key);
		if (obj is string)
		{
			return GetIntValueFromString(key);
		}
		return GetInt(key);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Boolean" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual bool GetBooleanValueFromString(string key)
	{
		object obj = Get(key);
		return ((string)obj).ToUpper(CultureInfo.InvariantCulture).Equals("TRUE");
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Boolean" /> value from the 
	/// <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual bool GetBooleanValue(string key)
	{
		object obj = Get(key);
		if (obj is string)
		{
			return GetBooleanValueFromString(key);
		}
		return GetBoolean(key);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Char" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual char GetCharFromString(string key)
	{
		object obj = Get(key);
		return ((string)obj)[0];
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Double" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual double GetDoubleValueFromString(string key)
	{
		object obj = Get(key);
		return double.Parse((string)obj, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Double" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual double GetDoubleValue(string key)
	{
		object obj = Get(key);
		if (obj is string)
		{
			return GetDoubleValueFromString(key);
		}
		return GetDouble(key);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Single" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual float GetFloatValueFromString(string key)
	{
		object obj = Get(key);
		return float.Parse((string)obj, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Single" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual float GetFloatValue(string key)
	{
		object obj = Get(key);
		if (obj is string)
		{
			return GetFloatValueFromString(key);
		}
		return GetFloat(key);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Int64" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual long GetLongValueFromString(string key)
	{
		object obj = Get(key);
		return long.Parse((string)obj, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.DateTime" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual DateTime GetDateTimeValueFromString(string key)
	{
		object obj = Get(key);
		return DateTime.Parse((string)obj, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.DateTimeOffset" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual DateTimeOffset GetDateTimeOffsetValueFromString(string key)
	{
		object obj = Get(key);
		return DateTimeOffset.Parse((string)obj, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.TimeSpan" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual TimeSpan GetTimeSpanValueFromString(string key)
	{
		object obj = Get(key);
		return TimeSpan.Parse((string)obj, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Int64" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual long GetLongValue(string key)
	{
		object obj = Get(key);
		if (obj is string)
		{
			return GetLongValueFromString(key);
		}
		return GetLong(key);
	}

	/// <summary>
	/// Gets the date time.
	/// </summary>
	/// <param name="key">The key.</param>
	/// <returns></returns>
	public virtual DateTime GetDateTimeValue(string key)
	{
		object obj = Get(key);
		if (obj is string)
		{
			return GetDateTimeValueFromString(key);
		}
		return GetDateTime(key);
	}

	/// <summary>
	/// Gets the date time offset.
	/// </summary>
	/// <param name="key">The key.</param>
	/// <returns></returns>
	public virtual DateTimeOffset GetDateTimeOffsetValue(string key)
	{
		object obj = Get(key);
		if (obj is string)
		{
			return GetDateTimeOffsetValueFromString(key);
		}
		return GetDateTimeOffset(key);
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.TimeSpan" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual TimeSpan GetTimeSpanValue(string key)
	{
		object obj = Get(key);
		if (obj is string)
		{
			return GetTimeSpanValueFromString(key);
		}
		return GetTimeSpan(key);
	}
}
