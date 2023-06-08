using System;
using System.Drawing;
using System.Text;
using ns171;
using ns176;
using ns183;
using ns184;
using ns195;
using ns205;

namespace ns173;

internal class Class5757
{
	internal class Class5761
	{
		private Color color_0 = Color.Empty;

		private string string_0;

		private Class5741 class5741_0;

		private int int_0;

		private int int_1;

		private int int_2;

		internal bool bool_0;

		public Color method_0()
		{
			return color_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public int method_2()
		{
			return int_0;
		}

		public string method_3()
		{
			return string_0;
		}

		public Class5741 method_4()
		{
			return class5741_0;
		}

		public int method_5()
		{
			return int_2;
		}

		public void method_6(Color color)
		{
			color_0 = color;
		}

		public void method_7(int horiz)
		{
			int_1 = horiz;
		}

		public void method_8(int repeat)
		{
			int_0 = repeat;
		}

		public void method_9(string repeat)
		{
			method_8(smethod_0(repeat));
		}

		public void method_10(string url)
		{
			string_0 = url;
		}

		public void method_11(Class5741 info)
		{
			class5741_0 = info;
		}

		public void method_12(int vertical)
		{
			int_2 = vertical;
		}

		private string method_13()
		{
			return (Enum679)method_2() switch
			{
				Enum679.const_199 => "repeat", 
				Enum679.const_200 => "repeat-x", 
				Enum679.const_201 => "repeat-y", 
				Enum679.const_183 => "no-repeat", 
				_ => throw new ArgumentOutOfRangeException("Illegal repeat style: " + method_2()), 
			};
		}

		private static int smethod_0(string repeat)
		{
			return repeat.ToLower() switch
			{
				"repeat" => 112, 
				"repeat-x" => 113, 
				"repeat-y" => 114, 
				"no-repeat" => 96, 
				_ => throw new ArgumentOutOfRangeException("Illegal repeat style: " + repeat), 
			};
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (!color_0.IsEmpty)
			{
				stringBuilder.Append("color=").Append(Class5713.smethod_10(color_0));
			}
			if (string_0 != null)
			{
				if (!color_0.IsEmpty)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append("url=").Append(string_0);
				stringBuilder.Append(",repeat=").Append(method_13());
				stringBuilder.Append(",horiz=").Append(int_1);
				stringBuilder.Append(",vertical=").Append(int_2);
			}
			return stringBuilder.ToString();
		}
	}

	internal class Class5759
	{
		private string string_0;

		private string string_1;

		public Class5759(string pvKey, string idRef)
		{
			method_0(pvKey);
			method_2(idRef);
		}

		public Class5759(string attrValue)
		{
			string[] array = smethod_1(attrValue);
			method_0(array[0]);
			method_2(array[1]);
		}

		public void method_0(string pvKey)
		{
			string_0 = pvKey;
		}

		public string method_1()
		{
			return string_0;
		}

		public void method_2(string idRef)
		{
			string_1 = idRef;
		}

		public string method_3()
		{
			return string_1;
		}

		public string method_4()
		{
			return smethod_0(string_0, string_1);
		}

		public static string smethod_0(string pvKey, string idRef)
		{
			return "(" + ((pvKey == null) ? string.Empty : pvKey) + "," + ((idRef == null) ? string.Empty : idRef) + ")";
		}

		public static string[] smethod_1(string attrValue)
		{
			string[] array = new string[2];
			string[] array2 = array;
			if (attrValue != null)
			{
				int length = attrValue.Length;
				if (length >= 2 && attrValue[0] == '(' && attrValue[length - 1] == ')' && attrValue.IndexOf(',') != -1)
				{
					string text = Class5479.smethod_0(attrValue, 1, length - 1);
					int num = text.IndexOf(',');
					array2[0] = Class5479.smethod_0(text, 0, num).Trim();
					array2[1] = Class5479.smethod_0(text, num + 1, text.Length).Trim();
				}
				else
				{
					array2[0] = attrValue;
				}
			}
			return array2;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("pvKey=").Append(string_0);
			stringBuilder.Append(",idRef=").Append(string_1);
			return stringBuilder.ToString();
		}
	}

	internal class Class5760
	{
		private string string_0;

		private bool bool_0;

		public Class5760(string destination, bool newWindow)
		{
			string_0 = destination;
			bool_0 = newWindow;
		}

		protected static Class5760 smethod_0(string traitValue)
		{
			string destination = null;
			bool newWindow = false;
			string[] array = traitValue.Split(',');
			int i = 0;
			for (int num = array.Length; i < num; i++)
			{
				string text = array[i];
				if (text.StartsWith("dest="))
				{
					destination = text.Substring(5);
					continue;
				}
				if (text.StartsWith("newWindow="))
				{
					newWindow = bool.Parse(text.Substring(10));
					continue;
				}
				throw new ArgumentOutOfRangeException("Malformed trait value for Trait.ExternalLink: " + traitValue);
			}
			return new Class5760(destination, newWindow);
		}

		public string method_0()
		{
			return string_0;
		}

		public bool method_1()
		{
			return bool_0;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.Append("newWindow=").Append(bool_0);
			stringBuilder.Append(",dest=").Append(string_0);
			return stringBuilder.ToString();
		}
	}

	private class Class5758
	{
		private string string_0;

		private Type type_0;

		public Class5758(string name, Type clazz)
		{
			string_0 = name;
			type_0 = clazz;
		}

		public string method_0()
		{
			return string_0;
		}

		public Type method_1()
		{
			return type_0;
		}
	}

	public static int int_0;

	public static int int_1;

	public static int int_2;

	public static int int_3;

	public static int int_4;

	public static int int_5;

	public static int int_6;

	public static int int_7;

	public static int int_8;

	public static int int_9;

	public static int int_10;

	public static int int_11;

	public static int int_12;

	public static int int_13;

	public static int int_14;

	public static int int_15;

	public static int int_16;

	public static int int_17;

	public static int int_18;

	public static int int_19;

	public static int int_20;

	public static int int_21;

	public static int int_22;

	public static int int_23;

	public static int int_24;

	public static int int_25;

	public static int int_26;

	public static int int_27;

	public static int int_28;

	public static int int_29;

	public static int int_30;

	public static int int_31;

	public static int int_32;

	public static int int_33;

	public static int int_34;

	public static int int_35;

	public static int int_36;

	public static int int_37;

	public static int int_38;

	public static int int_39;

	public static int int_40;

	public static int int_41;

	public static int int_42;

	public static int int_43;

	public static int int_44;

	public static int int_45;

	private static Class5758[] class5758_0;

	private Class5757()
	{
	}

	private static void smethod_0(int key, Class5758 info)
	{
		class5758_0[key] = info;
	}

	static Class5757()
	{
		int_0 = 1;
		int_1 = 2;
		int_2 = 3;
		int_3 = 4;
		int_4 = 7;
		int_5 = 8;
		int_6 = 9;
		int_7 = 10;
		int_8 = 11;
		int_9 = 12;
		int_10 = 15;
		int_11 = 16;
		int_12 = 17;
		int_13 = 18;
		int_14 = 19;
		int_15 = 20;
		int_16 = 21;
		int_17 = 22;
		int_18 = 23;
		int_19 = 24;
		int_20 = 27;
		int_21 = 28;
		int_22 = 29;
		int_23 = 30;
		int_24 = 31;
		int_25 = 32;
		int_26 = 33;
		int_27 = 34;
		int_28 = 35;
		int_29 = 36;
		int_30 = 37;
		int_31 = 38;
		int_32 = 39;
		int_33 = 40;
		int_34 = 41;
		int_35 = 42;
		int_36 = 43;
		int_37 = 44;
		int_38 = 45;
		int_39 = 46;
		int_40 = 47;
		int_41 = 48;
		int_42 = 49;
		int_43 = 50;
		int_44 = 51;
		int_45 = 51;
		class5758_0 = new Class5758[int_45 + 1];
		smethod_0(int_30, new Class5758("structure-tree-element", typeof(string)));
		smethod_0(int_0, new Class5758("internal-link", typeof(Class5759)));
		smethod_0(int_1, new Class5758("external-link", typeof(Class5760)));
		smethod_0(int_2, new Class5758("font", typeof(Class5732)));
		smethod_0(int_3, new Class5758("font-size", typeof(int)));
		smethod_0(int_4, new Class5758("color", typeof(Color)));
		smethod_0(int_5, new Class5758("prod-id", typeof(string)));
		smethod_0(int_6, new Class5758("background", typeof(Class5761)));
		smethod_0(int_7, new Class5758("underline-score", typeof(bool)));
		smethod_0(int_27, new Class5758("underline-score-color", typeof(Color)));
		smethod_0(int_8, new Class5758("overline-score", typeof(bool)));
		smethod_0(int_28, new Class5758("overline-score-color", typeof(Color)));
		smethod_0(int_9, new Class5758("through-score", typeof(bool)));
		smethod_0(int_29, new Class5758("through-score-color", typeof(Color)));
		smethod_0(int_26, new Class5758("blink", typeof(bool)));
		smethod_0(int_10, new Class5758("border-start", typeof(Class5705)));
		smethod_0(int_11, new Class5758("border-end", typeof(Class5705)));
		smethod_0(int_12, new Class5758("border-before", typeof(Class5705)));
		smethod_0(int_13, new Class5758("border-after", typeof(Class5705)));
		smethod_0(int_14, new Class5758("padding-start", typeof(int)));
		smethod_0(int_15, new Class5758("padding-end", typeof(int)));
		smethod_0(int_16, new Class5758("padding-before", typeof(int)));
		smethod_0(int_17, new Class5758("padding-after", typeof(int)));
		smethod_0(int_18, new Class5758("space-start", typeof(int)));
		smethod_0(int_19, new Class5758("space-end", typeof(int)));
		smethod_0(int_20, new Class5758("start-indent", typeof(int)));
		smethod_0(int_21, new Class5758("end-indent", typeof(int)));
		smethod_0(int_22, new Class5758("space-before", typeof(int)));
		smethod_0(int_23, new Class5758("space-after", typeof(int)));
		smethod_0(int_24, new Class5758("is-reference-area", typeof(bool)));
		smethod_0(int_25, new Class5758("is-viewport-area", typeof(bool)));
		smethod_0(int_31, new Class5758("writing-mode", typeof(Class5445)));
		smethod_0(int_32, new Class5758("inline-progression-direction", typeof(Class5444)));
		smethod_0(int_33, new Class5758("block-progression-direction", typeof(Class5444)));
		smethod_0(int_35, new Class5758("shift-direction", typeof(Class5444)));
		smethod_0(int_36, new Class5758("z-index", typeof(Interface181)));
		smethod_0(int_39, new Class5758("control-type", typeof(Interface181)));
		smethod_0(int_40, new Class5758("control-part", typeof(Interface181)));
		smethod_0(int_37, new Class5758("outline", typeof(Class5475)));
		smethod_0(int_38, new Class5758("visibility", typeof(Class5442)));
		smethod_0(int_42, new Class5758("control-height", typeof(int)));
		smethod_0(int_41, new Class5758("control-width", typeof(int)));
	}

	public static string smethod_1(object traitCode)
	{
		return class5758_0[(int)traitCode].method_0();
	}

	public static Type smethod_2(object traitCode)
	{
		return class5758_0[(int)traitCode].method_1();
	}
}
