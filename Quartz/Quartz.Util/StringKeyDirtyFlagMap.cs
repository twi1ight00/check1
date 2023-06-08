using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Quartz.Util;

/// <summary>
/// An implementation of <see cref="T:System.Collections.IDictionary" /> that wraps another <see cref="T:System.Collections.IDictionary" />
/// and flags itself 'dirty' when it is modified, enforces that all keys are
/// strings. 
/// </summary>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class StringKeyDirtyFlagMap : DirtyFlagMap<string, object>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Util.StringKeyDirtyFlagMap" /> class.
	/// </summary>
	public StringKeyDirtyFlagMap()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Util.StringKeyDirtyFlagMap" /> class.
	/// </summary>
	/// <param name="initialCapacity">The initial capacity.</param>
	public StringKeyDirtyFlagMap(int initialCapacity)
		: base(initialCapacity)
	{
	}

	/// <summary>
	/// Serialization constructor.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected StringKeyDirtyFlagMap(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	/// <summary>
	/// Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
	/// </summary>
	/// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
	/// <returns>
	/// 	<see langword="true" /> if the specified <see cref="T:System.Object" /> is equal to the
	/// current <see cref="T:System.Object" />; otherwise, <see langword="false" />.
	/// </returns>
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	/// <summary>
	/// Serves as a hash function for a particular type, suitable
	/// for use in hashing algorithms and data structures like a hash table.
	/// </summary>
	/// <returns>
	/// A hash code for the current <see cref="T:System.Object" />.
	/// </returns>
	public override int GetHashCode()
	{
		return WrappedMap.GetHashCode();
	}

	/// <summary>
	/// Gets the keys.
	/// </summary>
	/// <returns></returns>
	public virtual IList<string> GetKeys()
	{
		return new List<string>(KeySet());
	}

	/// <summary>
	/// Adds the name-value pairs in the given <see cref="T:System.Collections.IDictionary" /> to the <see cref="T:Quartz.JobDataMap" />.
	/// <para>
	/// All keys must be <see cref="T:System.String" />s, and all values must be serializable.
	/// </para>
	/// </summary>
	public override void PutAll(IDictionary<string, object> map)
	{
		foreach (KeyValuePair<string, object> pair in map)
		{
			Put(pair.Key, pair.Value);
		}
	}

	/// <summary>
	/// Adds the given <see cref="T:System.Int32" /> value to the <see cref="T:Quartz.IJob" />'s
	/// data map.
	/// </summary>
	public virtual void Put(string key, int value)
	{
		base.Put(key, value);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.Int64" /> value to the <see cref="T:Quartz.IJob" />'s
	/// data map.
	/// </summary>
	public virtual void Put(string key, long value)
	{
		base.Put(key, value);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.Single" /> value to the <see cref="T:Quartz.IJob" />'s
	/// data map.
	/// </summary>
	public virtual void Put(string key, float value)
	{
		base.Put(key, value);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.Double" /> value to the <see cref="T:Quartz.IJob" />'s
	/// data map.
	/// </summary>
	public virtual void Put(string key, double value)
	{
		base.Put(key, value);
	}

	/// <summary> 
	/// Adds the given <see cref="T:System.Boolean" /> value to the <see cref="T:Quartz.IJob" />'s
	/// data map.
	/// </summary>
	public virtual void Put(string key, bool value)
	{
		base.Put(key, value);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.Char" /> value to the <see cref="T:Quartz.IJob" />'s
	/// data map.
	/// </summary>
	public virtual void Put(string key, char value)
	{
		base.Put(key, value);
	}

	/// <summary>
	/// Adds the given <see cref="T:System.String" /> value to the <see cref="T:Quartz.IJob" />'s
	/// data map.
	/// </summary>
	public virtual void Put(string key, string value)
	{
		base.Put(key, value);
	}

	/// <summary> 
	/// Retrieve the identified <see cref="T:System.Int32" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual int GetInt(string key)
	{
		object obj = this[key];
		try
		{
			return Convert.ToInt32(obj);
		}
		catch (Exception)
		{
			throw new InvalidCastException("Identified object is not an Integer.");
		}
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Int64" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual long GetLong(string key)
	{
		object obj = this[key];
		try
		{
			return Convert.ToInt64(obj);
		}
		catch (Exception)
		{
			throw new InvalidCastException("Identified object is not a Long.");
		}
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Single" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual float GetFloat(string key)
	{
		object obj = this[key];
		try
		{
			return Convert.ToSingle(obj);
		}
		catch (Exception)
		{
			throw new InvalidCastException("Identified object is not a Float.");
		}
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Double" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual double GetDouble(string key)
	{
		object obj = this[key];
		try
		{
			return Convert.ToDouble(obj);
		}
		catch (Exception)
		{
			throw new InvalidCastException("Identified object is not a Double.");
		}
	}

	/// <summary> 
	/// Retrieve the identified <see cref="T:System.Boolean" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual bool GetBoolean(string key)
	{
		object obj = this[key];
		try
		{
			return Convert.ToBoolean(obj);
		}
		catch (Exception)
		{
			throw new InvalidCastException("Identified object is not a Boolean.");
		}
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.Char" /> value from the <see cref="T:Quartz.JobDataMap" />. 
	/// </summary>
	public virtual char GetChar(string key)
	{
		object obj = this[key];
		try
		{
			return Convert.ToChar(obj);
		}
		catch (Exception)
		{
			throw new InvalidCastException("Identified object is not a Character.");
		}
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.String" /> value from the <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	public virtual string GetString(string key)
	{
		object obj = this[key];
		try
		{
			return (string)obj;
		}
		catch (Exception)
		{
			throw new InvalidCastException("Identified object is not a String.");
		}
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.DateTime" /> value from the <see cref="T:Quartz.JobDataMap" />. 
	/// </summary>
	public virtual DateTime GetDateTime(string key)
	{
		object obj = this[key];
		try
		{
			return Convert.ToDateTime(obj, CultureInfo.InvariantCulture);
		}
		catch (Exception)
		{
			throw new InvalidCastException("Identified object is not a DateTime.");
		}
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.DateTimeOffset" /> value from the <see cref="T:Quartz.JobDataMap" />. 
	/// </summary>
	public virtual DateTimeOffset GetDateTimeOffset(string key)
	{
		object obj = this[key];
		return (DateTimeOffset)obj;
	}

	/// <summary>
	/// Retrieve the identified <see cref="T:System.TimeSpan" /> value from the <see cref="T:Quartz.JobDataMap" />. 
	/// </summary>
	public virtual TimeSpan GetTimeSpan(string key)
	{
		object obj = this[key];
		return (TimeSpan)obj;
	}
}
