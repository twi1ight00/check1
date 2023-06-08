using System;
using System.Collections;
using System.Text;

namespace ns299;

internal sealed class Class6866
{
	private class Class6867 : IEnumerable
	{
		private Hashtable hashtable_0 = new Hashtable();

		private bool bool_0;

		private int int_0;

		public int Count => hashtable_0.Count;

		public void method_0(Enum930 style, string value)
		{
			if (hashtable_0.ContainsKey(style))
			{
				hashtable_0[style] = value;
			}
			else
			{
				hashtable_0.Add(style, value);
			}
			bool_0 = true;
		}

		public string method_1(Enum930 style)
		{
			if (hashtable_0.ContainsKey(style))
			{
				return (string)hashtable_0[style];
			}
			return null;
		}

		public IDictionaryEnumerator GetEnumerator()
		{
			return hashtable_0.GetEnumerator();
		}

		public override bool Equals(object obj)
		{
			Class6867 @class = obj as Class6867;
			if (object.ReferenceEquals(null, @class))
			{
				return false;
			}
			return GetHashCode() == @class.GetHashCode();
		}

		public override int GetHashCode()
		{
			if (bool_0)
			{
				int num = 0;
				foreach (DictionaryEntry item in hashtable_0)
				{
					num ^= item.Key.GetHashCode() ^ item.Value.GetHashCode();
				}
				int_0 = num;
				bool_0 = false;
			}
			return int_0;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private Class6867 class6867_0 = new Class6867();

	public string this[Enum930 style]
	{
		get
		{
			return method_0(style);
		}
		set
		{
			method_1(style, value);
		}
	}

	public string BackgroundColor
	{
		get
		{
			return method_0(Enum930.const_0);
		}
		set
		{
			method_1(Enum930.const_0, value);
		}
	}

	public string BackgroundImage
	{
		get
		{
			return method_0(Enum930.const_1);
		}
		set
		{
			method_1(Enum930.const_1, value);
		}
	}

	public string BorderCollapse
	{
		get
		{
			return method_0(Enum930.const_2);
		}
		set
		{
			method_1(Enum930.const_2, value);
		}
	}

	public string BorderColor
	{
		get
		{
			return method_0(Enum930.const_3);
		}
		set
		{
			method_1(Enum930.const_3, value);
		}
	}

	public string BorderStyle
	{
		get
		{
			return method_0(Enum930.const_4);
		}
		set
		{
			method_1(Enum930.const_4, value);
		}
	}

	public string BorderWidth
	{
		get
		{
			return method_0(Enum930.const_5);
		}
		set
		{
			method_1(Enum930.const_5, value);
		}
	}

	public string Color
	{
		get
		{
			return method_0(Enum930.const_10);
		}
		set
		{
			method_1(Enum930.const_10, value);
		}
	}

	public string Cursor
	{
		get
		{
			return method_0(Enum930.const_20);
		}
		set
		{
			method_1(Enum930.const_20, value);
		}
	}

	public string Direction
	{
		get
		{
			return method_0(Enum930.const_21);
		}
		set
		{
			method_1(Enum930.const_21, value);
		}
	}

	public string Display
	{
		get
		{
			return method_0(Enum930.const_22);
		}
		set
		{
			method_1(Enum930.const_22, value);
		}
	}

	public string Filter
	{
		get
		{
			return method_0(Enum930.const_23);
		}
		set
		{
			method_1(Enum930.const_23, value);
		}
	}

	public string FontFamily
	{
		get
		{
			return method_0(Enum930.const_11);
		}
		set
		{
			method_1(Enum930.const_11, value);
		}
	}

	public string FontSize
	{
		get
		{
			return method_0(Enum930.const_12);
		}
		set
		{
			method_1(Enum930.const_12, value);
		}
	}

	public string FontStyle
	{
		get
		{
			return method_0(Enum930.const_13);
		}
		set
		{
			method_1(Enum930.const_13, value);
		}
	}

	public string FontVariant
	{
		get
		{
			return method_0(Enum930.const_24);
		}
		set
		{
			method_1(Enum930.const_24, value);
		}
	}

	public string FontWeight
	{
		get
		{
			return method_0(Enum930.const_14);
		}
		set
		{
			method_1(Enum930.const_14, value);
		}
	}

	public string Height
	{
		get
		{
			return method_0(Enum930.const_15);
		}
		set
		{
			method_1(Enum930.const_15, value);
		}
	}

	public string Left
	{
		get
		{
			return method_0(Enum930.const_25);
		}
		set
		{
			method_1(Enum930.const_25, value);
		}
	}

	public string ListStyleImage
	{
		get
		{
			return method_0(Enum930.const_18);
		}
		set
		{
			method_1(Enum930.const_18, value);
		}
	}

	public string ListStyleType
	{
		get
		{
			return method_0(Enum930.const_19);
		}
		set
		{
			method_1(Enum930.const_19, value);
		}
	}

	public string Margin
	{
		get
		{
			return method_0(Enum930.const_27);
		}
		set
		{
			method_1(Enum930.const_27, value);
		}
	}

	public string MarginBottom
	{
		get
		{
			return method_0(Enum930.const_28);
		}
		set
		{
			method_1(Enum930.const_28, value);
		}
	}

	public string MarginLeft
	{
		get
		{
			return method_0(Enum930.const_29);
		}
		set
		{
			method_1(Enum930.const_29, value);
		}
	}

	public string MarginRight
	{
		get
		{
			return method_0(Enum930.const_30);
		}
		set
		{
			method_1(Enum930.const_30, value);
		}
	}

	public string MarginTop
	{
		get
		{
			return method_0(Enum930.const_31);
		}
		set
		{
			method_1(Enum930.const_31, value);
		}
	}

	public string OverflowX
	{
		get
		{
			return method_0(Enum930.const_34);
		}
		set
		{
			method_1(Enum930.const_34, value);
		}
	}

	public string OverflowY
	{
		get
		{
			return method_0(Enum930.const_35);
		}
		set
		{
			method_1(Enum930.const_35, value);
		}
	}

	public string Overflow
	{
		get
		{
			return method_0(Enum930.const_33);
		}
		set
		{
			method_1(Enum930.const_33, value);
		}
	}

	public string Padding
	{
		get
		{
			return method_0(Enum930.const_36);
		}
		set
		{
			method_1(Enum930.const_36, value);
		}
	}

	public string PaddingBottom
	{
		get
		{
			return method_0(Enum930.const_37);
		}
		set
		{
			method_1(Enum930.const_37, value);
		}
	}

	public string PaddingLeft
	{
		get
		{
			return method_0(Enum930.const_38);
		}
		set
		{
			method_1(Enum930.const_38, value);
		}
	}

	public string PaddingRight
	{
		get
		{
			return method_0(Enum930.const_39);
		}
		set
		{
			method_1(Enum930.const_39, value);
		}
	}

	public string PaddingTop
	{
		get
		{
			return method_0(Enum930.const_40);
		}
		set
		{
			method_1(Enum930.const_40, value);
		}
	}

	public string Position
	{
		get
		{
			return method_0(Enum930.const_41);
		}
		set
		{
			method_1(Enum930.const_41, value);
		}
	}

	public string TextAlign
	{
		get
		{
			return method_0(Enum930.const_42);
		}
		set
		{
			method_1(Enum930.const_42, value);
		}
	}

	public string TextDecoration
	{
		get
		{
			return method_0(Enum930.const_16);
		}
		set
		{
			method_1(Enum930.const_16, value);
		}
	}

	public string TextOverflow
	{
		get
		{
			return method_0(Enum930.const_44);
		}
		set
		{
			method_1(Enum930.const_44, value);
		}
	}

	public string Top
	{
		get
		{
			return method_0(Enum930.const_45);
		}
		set
		{
			method_1(Enum930.const_45, value);
		}
	}

	public string VerticalAlign
	{
		get
		{
			return method_0(Enum930.const_43);
		}
		set
		{
			method_1(Enum930.const_43, value);
		}
	}

	public string Visibility
	{
		get
		{
			return method_0(Enum930.const_46);
		}
		set
		{
			method_1(Enum930.const_46, value);
		}
	}

	public string Width
	{
		get
		{
			return method_0(Enum930.const_17);
		}
		set
		{
			method_1(Enum930.const_17, value);
		}
	}

	public string WhiteSpace
	{
		get
		{
			return method_0(Enum930.const_47);
		}
		set
		{
			method_1(Enum930.const_47, value);
		}
	}

	public string ZIndex
	{
		get
		{
			return method_0(Enum930.const_48);
		}
		set
		{
			method_1(Enum930.const_48, value);
		}
	}

	private string method_0(Enum930 style)
	{
		return class6867_0.method_1(style);
	}

	private void method_1(Enum930 style, string value)
	{
		class6867_0.method_0(style, value);
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as Class6866);
	}

	public override int GetHashCode()
	{
		return class6867_0.GetHashCode();
	}

	public bool Equals(Class6866 builder)
	{
		if (object.ReferenceEquals(null, builder))
		{
			return false;
		}
		if (object.ReferenceEquals(this, builder))
		{
			return true;
		}
		return class6867_0.GetHashCode() == builder.class6867_0.GetHashCode();
	}

	public string method_2()
	{
		if (class6867_0.Count == 0)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (DictionaryEntry item in class6867_0)
		{
			stringBuilder.AppendFormat("{0}:{1};", Class6874.smethod_1((Enum930)item.Key), item.Value);
		}
		return stringBuilder.ToString();
	}

	internal string method_3(string elementId)
	{
		if (class6867_0.Count == 0)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(elementId + " {");
		foreach (DictionaryEntry item in class6867_0)
		{
			stringBuilder.AppendFormat("\t{0}: {1};{2}", Class6874.smethod_1((Enum930)item.Key), item.Value, Environment.NewLine);
		}
		stringBuilder.AppendLine("}");
		return stringBuilder.ToString();
	}
}
