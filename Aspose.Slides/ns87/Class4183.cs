using System.Collections.Generic;
using System.Text;
using ns73;

namespace ns87;

internal class Class4183 : Class4154
{
	public class Class4333
	{
		private bool bool_0;

		private bool bool_1;

		private string string_0;

		public bool Clip
		{
			get
			{
				return bool_0;
			}
			internal set
			{
				bool_0 = value;
			}
		}

		public bool Ellipsis
		{
			get
			{
				return bool_1;
			}
			internal set
			{
				bool_1 = value;
			}
		}

		public string StringValue
		{
			get
			{
				return string_0;
			}
			internal set
			{
				string_0 = value;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (Ellipsis)
			{
				stringBuilder.Append("ellipsis");
			}
			else if (Clip)
			{
				stringBuilder.Append("clip");
			}
			else
			{
				stringBuilder.AppendFormat("'{0}'", StringValue);
			}
			return stringBuilder.ToString();
		}
	}

	private IList<Class4333> ilist_0 = new List<Class4333>();

	public int Count => ilist_0.Count;

	public Class4333 this[int index] => ilist_0[index];

	internal Class4183(Class3679 value)
		: base(value)
	{
		Class3691 @class = value as Class3691;
		foreach (Class3680 item2 in @class)
		{
			Class4333 item = new Class4333
			{
				StringValue = item2.vmethod_3()
			};
			ilist_0.Add(item);
		}
	}
}
