using System.Collections;

namespace ns99;

internal class Class4519
{
	public enum Enum645
	{
		const_0 = 1033,
		const_1 = 2057,
		const_2 = 3081,
		const_3 = 4105,
		const_4 = 5129
	}

	private Hashtable hashtable_0 = new Hashtable();

	private Hashtable hashtable_1 = new Hashtable();

	public Class4519()
	{
	}

	public Class4519(string str)
	{
		method_0(str, Enum645.const_0);
	}

	public void method_0(string str, Enum645 languageId)
	{
		if (!hashtable_1.ContainsKey(str))
		{
			hashtable_1.Add(str, str);
		}
		if (!hashtable_0.ContainsKey(languageId))
		{
			hashtable_0.Add(languageId, str);
		}
	}

	public bool method_1(string str)
	{
		return hashtable_1.ContainsKey(str);
	}

	public string[] method_2()
	{
		string[] array = new string[hashtable_1.Keys.Count];
		int num = 0;
		foreach (string key in hashtable_1.Keys)
		{
			array[num++] = key;
		}
		return array;
	}

	public string method_3()
	{
		string text = string.Empty;
		foreach (Enum645 key in hashtable_0.Keys)
		{
			if (string.IsNullOrEmpty(text))
			{
				text = (string)hashtable_0[key];
			}
			if (key == Enum645.const_0 || key == Enum645.const_2 || key == Enum645.const_1 || key == Enum645.const_3 || key == Enum645.const_4)
			{
				return (string)hashtable_0[key];
			}
		}
		return text;
	}

	public override int GetHashCode()
	{
		return GetHashCode();
	}

	public static bool operator ==(Class4519 obj1, string obj2)
	{
		if ((object)obj1 != null)
		{
			return obj1.Equals(obj2);
		}
		if (obj2 == null)
		{
			return true;
		}
		return false;
	}

	public static bool operator ==(string obj1, Class4519 obj2)
	{
		if ((object)obj2 != null)
		{
			return obj2.Equals(obj1);
		}
		if (obj1 == null)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(Class4519 obj1, string obj2)
	{
		if ((object)obj1 != null)
		{
			return !obj1.Equals(obj2);
		}
		if (obj2 == null)
		{
			return false;
		}
		return true;
	}

	public static bool operator !=(string obj1, Class4519 obj2)
	{
		if ((object)obj2 != null)
		{
			return !obj2.Equals(obj1);
		}
		if (obj1 == null)
		{
			return false;
		}
		return true;
	}

	public override bool Equals(object objToCompare)
	{
		if (objToCompare is string str)
		{
			return method_1(str);
		}
		return object.ReferenceEquals(this, objToCompare);
	}
}
