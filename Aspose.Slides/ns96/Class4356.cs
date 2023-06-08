using System.Collections;
using System.Text;

namespace ns96;

internal class Class4356
{
	public static string smethod_0(IList coll)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (coll != null)
		{
			stringBuilder.Append("[");
			for (int i = 0; i < coll.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				object obj = coll[i];
				if (obj == null)
				{
					stringBuilder.Append("null");
				}
				else if (obj is IDictionary)
				{
					stringBuilder.Append(smethod_1((IDictionary)obj));
				}
				else if (obj is IList)
				{
					stringBuilder.Append(smethod_0((IList)obj));
				}
				else
				{
					stringBuilder.Append(obj.ToString());
				}
			}
			stringBuilder.Append("]");
		}
		else
		{
			stringBuilder.Insert(0, "null");
		}
		return stringBuilder.ToString();
	}

	public static string smethod_1(IDictionary dict)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (dict != null)
		{
			stringBuilder.Append("{");
			int num = 0;
			foreach (DictionaryEntry item in dict)
			{
				if (num > 0)
				{
					stringBuilder.Append(", ");
				}
				if (item.Value is IDictionary)
				{
					stringBuilder.AppendFormat("{0}={1}", item.Key.ToString(), smethod_1((IDictionary)item.Value));
				}
				else if (item.Value is IList)
				{
					stringBuilder.AppendFormat("{0}={1}", item.Key.ToString(), smethod_0((IList)item.Value));
				}
				else
				{
					stringBuilder.AppendFormat("{0}={1}", item.Key.ToString(), item.Value.ToString());
				}
				num++;
			}
			stringBuilder.Append("}");
		}
		else
		{
			stringBuilder.Insert(0, "null");
		}
		return stringBuilder.ToString();
	}
}
