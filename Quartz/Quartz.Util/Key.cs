using System;

namespace Quartz.Util;

/// <summary>
/// Object representing a job or trigger key.
/// </summary>
/// <author>  <a href="mailto:jeff@binaryfeed.org">Jeffrey Wescott</a></author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class Key<T> : IComparable<Key<T>>
{
	/// <summary>
	/// The default group for scheduling entities, with the value "DEFAULT".
	/// </summary>
	public const string DefaultGroup = "DEFAULT";

	private readonly string name;

	private readonly string group;

	/// <summary>
	/// Get the name portion of the key.
	/// </summary>
	/// <returns> the name
	/// </returns>
	public virtual string Name => name;

	/// <summary> <para>
	/// Get the group portion of the key.
	/// </para>
	///
	/// </summary>
	/// <returns> the group
	/// </returns>
	public virtual string Group => group;

	/// <summary> 
	/// Construct a new key with the given name and group.
	/// </summary>
	/// <param name="name">the name</param>
	/// <param name="group">the group</param>
	public Key(string name, string group)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name", "Name cannot be null.");
		}
		this.name = name;
		if (group != null)
		{
			this.group = group;
		}
		else
		{
			this.group = "DEFAULT";
		}
	}

	/// <summary> <para>
	/// Return the string representation of the key. The format will be:
	/// &lt;group&gt;.&lt;name&gt;.
	/// </para>
	///
	/// </summary>
	/// <returns> the string representation of the key
	/// </returns>
	public override string ToString()
	{
		return Group + '.' + Name;
	}

	public override int GetHashCode()
	{
		int result = 1;
		result = 31 * result + ((group != null) ? group.GetHashCode() : 0);
		return 31 * result + ((name != null) ? name.GetHashCode() : 0);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj == null)
		{
			return false;
		}
		if (GetType() != obj.GetType())
		{
			return false;
		}
		Key<T> other = (Key<T>)obj;
		if (group == null)
		{
			if (other.group != null)
			{
				return false;
			}
		}
		else if (!group.Equals(other.group))
		{
			return false;
		}
		if (name == null)
		{
			if (other.name != null)
			{
				return false;
			}
		}
		else if (!name.Equals(other.name))
		{
			return false;
		}
		return true;
	}

	public int CompareTo(Key<T> o)
	{
		if (group.Equals("DEFAULT") && !o.group.Equals("DEFAULT"))
		{
			return -1;
		}
		if (!group.Equals("DEFAULT") && o.group.Equals("DEFAULT"))
		{
			return 1;
		}
		int r = group.CompareTo(o.Group);
		if (r != 0)
		{
			return r;
		}
		return name.CompareTo(o.Name);
	}
}
