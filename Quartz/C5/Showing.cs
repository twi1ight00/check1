using System;
using System.Runtime.InteropServices;
using System.Text;

namespace C5;

internal static class Showing
{
	[ComVisible(true)]
	public static bool Show(object obj, StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		if (rest <= 0)
		{
			return false;
		}
		if (obj is IShowable showable)
		{
			return showable.Show(stringbuilder, ref rest, formatProvider);
		}
		int length = stringbuilder.Length;
		stringbuilder.AppendFormat(formatProvider, "{0}", new object[1] { obj });
		rest -= stringbuilder.Length - length;
		return true;
	}

	[ComVisible(true)]
	public static string ShowString(IShowable showable, string format, IFormatProvider formatProvider)
	{
		int rest = maxLength(format);
		StringBuilder stringBuilder = new StringBuilder();
		showable.Show(stringBuilder, ref rest, formatProvider);
		return stringBuilder.ToString();
	}

	private static int maxLength(string format)
	{
		if (format == null)
		{
			return 80;
		}
		if (format.Length > 1 && format.StartsWith("L"))
		{
			return int.Parse(format.Substring(1));
		}
		return int.MaxValue;
	}

	[ComVisible(true)]
	public static bool ShowCollectionValue<T>(ICollectionValue<T> items, StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		string text = "{ ";
		string value = " }";
		bool flag = false;
		bool flag2 = false;
		ICollection<T> collection = items as ICollection<T>;
		if (items is IList<T> list)
		{
			text = "[ ";
			value = " ]";
			flag = list.IndexingSpeed == Speed.Constant;
		}
		else if (collection != null && collection.AllowsDuplicates)
		{
			text = "{{ ";
			value = " }}";
			if (collection.DuplicatesByCounting)
			{
				flag2 = true;
			}
		}
		stringbuilder.Append(text);
		rest -= 2 * text.Length;
		bool flag3 = true;
		bool flag4 = true;
		int num = 0;
		if (flag2)
		{
			foreach (KeyValuePair<T, int> item in collection.ItemMultiplicities())
			{
				flag4 = false;
				if (rest > 0)
				{
					if (flag3)
					{
						flag3 = false;
					}
					else
					{
						stringbuilder.Append(", ");
						rest -= 2;
					}
					if (flag4 = Show(item.Key, stringbuilder, ref rest, formatProvider))
					{
						string text2 = $"(*{item.Value})";
						stringbuilder.Append(text2);
						rest -= text2.Length;
					}
					continue;
				}
				break;
			}
		}
		else
		{
			foreach (T item2 in items)
			{
				flag4 = false;
				if (rest > 0)
				{
					if (flag3)
					{
						flag3 = false;
					}
					else
					{
						stringbuilder.Append(", ");
						rest -= 2;
					}
					if (flag)
					{
						string text3 = $"{num++}:";
						stringbuilder.Append(text3);
						rest -= text3.Length;
					}
					flag4 = Show(item2, stringbuilder, ref rest, formatProvider);
					continue;
				}
				break;
			}
		}
		if (!flag4)
		{
			stringbuilder.Append("...");
			rest -= 3;
		}
		stringbuilder.Append(value);
		return flag4;
	}

	[ComVisible(true)]
	public static bool ShowDictionary<K, V>(IDictionary<K, V> dictionary, StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		bool flag = dictionary is ISortedDictionary<K, V>;
		stringbuilder.Append(flag ? "[ " : "{ ");
		rest -= 4;
		bool flag2 = true;
		bool flag3 = true;
		foreach (KeyValuePair<K, V> item in dictionary)
		{
			flag3 = false;
			if (rest > 0)
			{
				if (flag2)
				{
					flag2 = false;
				}
				else
				{
					stringbuilder.Append(", ");
					rest -= 2;
				}
				flag3 = Show(item, stringbuilder, ref rest, formatProvider);
				continue;
			}
			break;
		}
		if (!flag3)
		{
			stringbuilder.Append("...");
			rest -= 3;
		}
		stringbuilder.Append(flag ? " ]" : " }");
		return flag3;
	}
}
