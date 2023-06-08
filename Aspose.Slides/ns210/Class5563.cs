using System;
using System.Collections;
using System.Text;
using ns183;
using ns211;

namespace ns210;

internal class Class5563
{
	internal class Class5567
	{
		private string string_0;

		private string string_1;

		private string string_2;

		public Class5567(string script, string language, string feature)
		{
			if (script != null && script.Length != 0)
			{
				if (language != null && language.Length != 0)
				{
					if (feature != null && feature.Length != 0)
					{
						if (script.Equals("*"))
						{
							throw new Exception("script must not be wildcard");
						}
						if (language.Equals("*"))
						{
							throw new Exception("language must not be wildcard");
						}
						if (feature.Equals("*"))
						{
							throw new Exception("feature must not be wildcard");
						}
						string_0 = script.Trim();
						string_1 = language.Trim();
						string_2 = feature.Trim();
						return;
					}
					throw new Exception("feature must be non-empty string");
				}
				throw new Exception("language must be non-empty string");
			}
			throw new Exception("script must be non-empty string");
		}

		public string method_0()
		{
			return string_0;
		}

		public string method_1()
		{
			return string_1;
		}

		public string method_2()
		{
			return string_2;
		}

		public override int GetHashCode()
		{
			int num = 0;
			num = 0 + (0 ^ string_0.GetHashCode());
			num = 11 * num + (num ^ string_1.GetHashCode());
			return 17 * num + (num ^ string_2.GetHashCode());
		}

		public bool method_3(object o)
		{
			if (o is Class5567 @class)
			{
				if (!@class.string_0.Equals(string_0))
				{
					return false;
				}
				if (!@class.string_1.Equals(string_1))
				{
					return false;
				}
				if (!@class.string_2.Equals(string_2))
				{
					return false;
				}
				return true;
			}
			return false;
		}

		public int method_4(object o)
		{
			Class5567 @class = (Class5567)o;
			int result;
			if (@class != null)
			{
				if ((result = string_0.CompareTo(@class.string_0)) == 0 && (result = string_1.CompareTo(@class.string_1)) == 0 && (result = string_2.CompareTo(@class.string_2)) == 0)
				{
					result = 0;
				}
			}
			else
			{
				result = -1;
			}
			return result;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			stringBuilder.Append("{");
			stringBuilder.Append("<'" + string_0 + "'");
			stringBuilder.Append(",'" + string_1 + "'");
			stringBuilder.Append(",'" + string_2 + "'");
			stringBuilder.Append(">}");
			return stringBuilder.ToString();
		}
	}

	internal class Class5568
	{
		private string string_0;

		private ArrayList arrayList_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private Class5510[] class5510_0;

		private static Class5510[] class5510_1 = new Class5510[0];

		public Class5568(string id, Class5510 subtable)
			: this(id, smethod_1(subtable))
		{
		}

		public Class5568(string id, ArrayList subtables)
		{
			string_0 = id;
			arrayList_0 = new ArrayList();
			if (subtables != null)
			{
				Interface208 @interface = new Class5495(subtables);
				while (@interface.imethod_0())
				{
					Class5510 subtable = (Class5510)@interface.imethod_1();
					method_2(subtable);
				}
			}
		}

		public string method_0()
		{
			return string_0;
		}

		public Class5510[] method_1()
		{
			if (bool_2)
			{
				if (class5510_0 == null)
				{
					return class5510_1;
				}
				return class5510_0;
			}
			if (bool_0)
			{
				return (Class5510[])arrayList_0.ToArray(typeof(Class5510));
			}
			if (bool_1)
			{
				return (Class5510[])arrayList_0.ToArray(typeof(Class5510));
			}
			return null;
		}

		public bool method_2(Class5510 subtable)
		{
			bool flag = false;
			if (bool_2)
			{
				throw new InvalidOperationException("glyph table is frozen, subtable addition prohibited");
			}
			method_3(subtable);
			Interface168 @interface = new Class5495(arrayList_0);
			while (@interface.imethod_0())
			{
				Class5510 @class = (Class5510)@interface.imethod_1();
				int num;
				if ((num = subtable.method_12(@class)) < 0)
				{
					@interface.imethod_7(subtable);
					@interface.imethod_8(@class);
					flag = true;
				}
				else if (num == 0)
				{
					flag = false;
					subtable = null;
				}
			}
			if (!flag && subtable != null)
			{
				arrayList_0.Add(subtable);
				flag = true;
			}
			return flag;
		}

		private void method_3(Class5510 subtable)
		{
			if (subtable == null)
			{
				throw new Exception("subtable must be non-null");
			}
			if (subtable is Class5543)
			{
				if (bool_1)
				{
					throw new Exception("subtable must be positioning subtable, but is: " + subtable);
				}
				bool_0 = true;
			}
			if (subtable is Class5520)
			{
				if (bool_0)
				{
					throw new Exception("subtable must be substitution subtable, but is: " + subtable);
				}
				bool_1 = true;
			}
			if (arrayList_0.Count > 0)
			{
				Class5510 @class = (Class5510)arrayList_0[0];
				if (!@class.vmethod_3(subtable))
				{
					throw new Exception(string.Concat("subtable ", subtable, " is not compatible with subtable ", @class));
				}
			}
		}

		public void method_4(Hashtable lookupTables)
		{
			if (!bool_2)
			{
				Class5510[] subtables = method_1();
				smethod_0(subtables, lookupTables);
				class5510_0 = subtables;
				bool_2 = true;
			}
		}

		private static void smethod_0(Class5510[] subtables, Hashtable lookupTables)
		{
			if (subtables != null)
			{
				int i = 0;
				for (int num = subtables.Length; i < num; i++)
				{
					subtables[i]?.vmethod_6(lookupTables);
				}
			}
		}

		public bool method_5()
		{
			return bool_0;
		}

		public Class5591 method_6(Class5591 gs, string script, string language, string feature, Interface216 sct)
		{
			if (method_5())
			{
				return Class5543.smethod_3(gs, script, language, feature, (Class5543[])class5510_0, sct);
			}
			return gs;
		}

		public Class5591 method_7(Class5582 ss, int sequenceIndex)
		{
			if (method_5())
			{
				return Class5543.smethod_2(ss, (Class5543[])class5510_0, sequenceIndex);
			}
			return ss.method_20();
		}

		public bool method_8()
		{
			return bool_1;
		}

		public bool method_9(Class5591 gs, string script, string language, string feature, int fontSize, int[] widths, int[][] adjustments, Interface216 sct)
		{
			if (method_8())
			{
				return Class5520.smethod_3(gs, script, language, feature, fontSize, (Class5520[])class5510_0, widths, adjustments, sct);
			}
			return false;
		}

		public bool method_10(Class5581 ps, int sequenceIndex)
		{
			if (method_8())
			{
				return Class5520.smethod_2(ps, (Class5520[])class5510_0, sequenceIndex);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return string_0.GetHashCode();
		}

		public bool method_11(object o)
		{
			if (o is Class5568)
			{
				Class5568 @class = (Class5568)o;
				return string_0.Equals(@class.string_0);
			}
			return false;
		}

		public int method_12(object o)
		{
			if (o is Class5568)
			{
				Class5568 @class = (Class5568)o;
				int num = int.Parse(string_0.Substring(2));
				int num2 = int.Parse(@class.string_0.Substring(2));
				if (num < num2)
				{
					return -1;
				}
				if (num > num2)
				{
					return 1;
				}
				return 0;
			}
			return -1;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ ");
			stringBuilder.Append("id = " + string_0);
			stringBuilder.Append(", subtables = " + arrayList_0);
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}

		private static ArrayList smethod_1(Class5510 subtable)
		{
			if (subtable == null)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList(1);
			arrayList.Add(subtable);
			return arrayList;
		}
	}

	internal class Class5569
	{
		private Class5568 class5568_0;

		private string string_0;

		public Class5569(Class5568 lookupTable, string feature)
		{
			class5568_0 = lookupTable;
			string_0 = feature;
		}

		public Class5568 method_0()
		{
			return class5568_0;
		}

		public string method_1()
		{
			return string_0;
		}

		public Class5591 method_2(Class5591 gs, string script, string language, Interface216 sct)
		{
			return class5568_0.method_6(gs, script, language, string_0, sct);
		}

		public bool method_3(Class5591 gs, string script, string language, int fontSize, int[] widths, int[][] adjustments, Interface216 sct)
		{
			return class5568_0.method_9(gs, script, language, string_0, fontSize, widths, adjustments, sct);
		}

		public override int GetHashCode()
		{
			return class5568_0.GetHashCode();
		}

		public bool method_4(object o)
		{
			if (o is Class5569 @class)
			{
				return class5568_0.method_11(@class.class5568_0);
			}
			return false;
		}

		public int method_5(object o)
		{
			if (o is Class5569 @class)
			{
				return class5568_0.method_12(@class.class5568_0);
			}
			return -1;
		}
	}

	internal class Class5570
	{
		private int int_0;

		private int int_1;

		private Class5568 class5568_0;

		public Class5570(int sequenceIndex, int lookupIndex)
		{
			int_0 = sequenceIndex;
			int_1 = lookupIndex;
			class5568_0 = null;
		}

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public Class5568 method_2()
		{
			return class5568_0;
		}

		public void method_3(Hashtable lookupTables)
		{
			if (lookupTables != null)
			{
				string key = "lu" + int_1;
				Class5568 @class = (Class5568)lookupTables[key];
				if (@class != null)
				{
					class5568_0 = @class;
				}
			}
		}

		public override string ToString()
		{
			return "{ sequenceIndex = " + int_0 + ", lookupIndex = " + int_1 + " }";
		}
	}

	internal abstract class Class5571
	{
		private Class5570[] class5570_0;

		private int int_0;

		protected Class5571(Class5570[] lookups, int inputSequenceLength)
		{
			class5570_0 = lookups;
			int_0 = inputSequenceLength;
		}

		public Class5570[] method_0()
		{
			return class5570_0;
		}

		public int method_1()
		{
			return int_0;
		}

		public void method_2(Hashtable lookupTables)
		{
			if (class5570_0 != null)
			{
				int i = 0;
				for (int num = class5570_0.Length; i < num; i++)
				{
					class5570_0[i]?.method_3(lookupTables);
				}
			}
		}

		public override string ToString()
		{
			return "{ lookups = " + class5570_0.ToString() + ", inputSequenceLength = " + int_0 + " }";
		}
	}

	internal class Class5572 : Class5571
	{
		private int[] int_1;

		public Class5572(Class5570[] lookups, int inputSequenceLength, int[] glyphs)
			: base(lookups, inputSequenceLength)
		{
			int_1 = glyphs;
		}

		public int[] method_3()
		{
			return int_1;
		}

		public int[] method_4(int firstGlyph)
		{
			int[] array = new int[int_1.Length + 1];
			array[0] = firstGlyph;
			Array.Copy(int_1, 0, array, 1, int_1.Length);
			return array;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ ");
			stringBuilder.Append("lookups = " + method_0().ToString());
			stringBuilder.Append(", glyphs = " + int_1.ToString());
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}

	internal class Class5574 : Class5571
	{
		private int[] int_1;

		public Class5574(Class5570[] lookups, int inputSequenceLength, int[] classes)
			: base(lookups, inputSequenceLength)
		{
			int_1 = classes;
		}

		public int[] method_3()
		{
			return int_1;
		}

		public int[] method_4(int firstClass)
		{
			int[] array = new int[int_1.Length + 1];
			array[0] = firstClass;
			Array.Copy(int_1, 0, array, 1, int_1.Length);
			return array;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ ");
			stringBuilder.Append("lookups = " + method_0());
			stringBuilder.Append(", classes = " + int_1);
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}

	internal class Class5576 : Class5571
	{
		private Class5508[] class5508_0;

		public Class5576(Class5570[] lookups, int inputSequenceLength, Class5508[] coverages)
			: base(lookups, inputSequenceLength)
		{
			class5508_0 = coverages;
		}

		public Class5508[] method_3()
		{
			return class5508_0;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ ");
			stringBuilder.Append("lookups = " + method_0());
			stringBuilder.Append(", coverages = " + class5508_0);
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}

	internal class Class5573 : Class5572
	{
		private int[] int_2;

		private int[] int_3;

		public Class5573(Class5570[] lookups, int inputSequenceLength, int[] glyphs, int[] backtrackGlyphs, int[] lookaheadGlyphs)
			: base(lookups, inputSequenceLength, glyphs)
		{
			int_2 = backtrackGlyphs;
			int_3 = lookaheadGlyphs;
		}

		public int[] method_5()
		{
			return int_2;
		}

		public int[] method_6()
		{
			return int_3;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ ");
			stringBuilder.Append("lookups = " + method_0());
			stringBuilder.Append(", glyphs = " + method_3());
			stringBuilder.Append(", backtrackGlyphs = " + int_2);
			stringBuilder.Append(", lookaheadGlyphs = " + int_3);
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}

	internal class Class5575 : Class5574
	{
		private int[] int_2;

		private int[] int_3;

		public Class5575(Class5570[] lookups, int inputSequenceLength, int[] classes, int[] backtrackClasses, int[] lookaheadClasses)
			: base(lookups, inputSequenceLength, classes)
		{
			int_2 = backtrackClasses;
			int_3 = lookaheadClasses;
		}

		public int[] method_5()
		{
			return int_2;
		}

		public int[] method_6()
		{
			return int_3;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ ");
			stringBuilder.Append("lookups = " + method_0());
			stringBuilder.Append(", classes = " + method_3());
			stringBuilder.Append(", backtrackClasses = " + int_2);
			stringBuilder.Append(", lookaheadClasses = " + int_3);
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}

	internal class Class5577 : Class5576
	{
		private Class5508[] class5508_1;

		private Class5508[] class5508_2;

		public Class5577(Class5570[] lookups, int inputSequenceLength, Class5508[] coverages, Class5508[] backtrackCoverages, Class5508[] lookaheadCoverages)
			: base(lookups, inputSequenceLength, coverages)
		{
			class5508_1 = backtrackCoverages;
			class5508_2 = lookaheadCoverages;
		}

		public Class5508[] method_4()
		{
			return class5508_1;
		}

		public Class5508[] method_5()
		{
			return class5508_2;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ ");
			stringBuilder.Append("lookups = " + method_0());
			stringBuilder.Append(", coverages = " + method_3());
			stringBuilder.Append(", backtrackCoverages = " + class5508_1);
			stringBuilder.Append(", lookaheadCoverages = " + class5508_2);
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}

	internal class Class5578
	{
		private Class5571[] class5571_0;

		public Class5578(Class5571[] rules)
		{
			if (rules == null)
			{
				throw new Exception("rules[] is null");
			}
			class5571_0 = rules;
		}

		public Class5571[] method_0()
		{
			return class5571_0;
		}

		public void method_1(Hashtable lookupTables)
		{
			if (class5571_0 != null)
			{
				int i = 0;
				for (int num = class5571_0.Length; i < num; i++)
				{
					class5571_0[i]?.method_2(lookupTables);
				}
			}
		}

		public string method_2()
		{
			return string.Concat("{ rules = ", class5571_0, " }");
		}
	}

	internal class Class5579 : Class5578
	{
		public Class5579(Class5571[] rules)
			: base(rules)
		{
			Class5571 @class = null;
			int num = 1;
			int num2 = rules.Length;
			while (@class == null && num < num2)
			{
				if (rules[num] != null)
				{
					@class = rules[num];
				}
				num++;
			}
			if (@class == null)
			{
				return;
			}
			Type type = @class.GetType();
			int num3 = 1;
			int num4 = rules.Length;
			while (true)
			{
				if (num3 < num4)
				{
					Class5571 class2 = rules[num3];
					if (class2 != null && !type.IsInstanceOfType(class2))
					{
						break;
					}
					num3++;
					continue;
				}
				return;
			}
			throw new Exception("rules[" + num3 + "] is not an instance of " + type.Name);
		}
	}

	public static int int_0 = 1;

	public static int int_1 = 2;

	public static int int_2 = 3;

	public static int int_3 = 4;

	public static int int_4 = 5;

	private Class5563 class5563_0;

	private Hashtable hashtable_0;

	private Hashtable hashtable_1;

	private bool bool_0;

	public Class5563(Class5563 gdef, Hashtable lookups)
	{
		if (gdef != null && !(gdef is Class5564))
		{
			throw new Exception("bad glyph definition table");
		}
		if (lookups == null)
		{
			throw new Exception("lookups must be non-null map");
		}
		class5563_0 = gdef;
		hashtable_0 = lookups;
		hashtable_1 = new Hashtable();
	}

	public Class5564 method_0()
	{
		return (Class5564)class5563_0;
	}

	public ArrayList method_1()
	{
		return method_5("*", "*", "*");
	}

	public ArrayList method_2()
	{
		ArrayList arrayList = new ArrayList(hashtable_1.Keys);
		ArrayList arrayList2 = new ArrayList(arrayList.Count);
		Interface208 @interface = new Class5495(arrayList);
		while (@interface.imethod_0())
		{
			string key = (string)@interface.imethod_1();
			arrayList2.Add(hashtable_1[key]);
		}
		return arrayList2;
	}

	public Class5568 method_3(string lid)
	{
		return (Class5568)hashtable_1[lid];
	}

	protected virtual void vmethod_0(Class5510 subtable)
	{
		if (bool_0)
		{
			throw new InvalidOperationException("glyph table is frozen, subtable addition prohibited");
		}
		subtable.method_8(this);
		string text = subtable.method_0();
		if (hashtable_1.ContainsKey(text))
		{
			Class5568 @class = (Class5568)hashtable_1[text];
			@class.method_2(subtable);
		}
		else
		{
			Class5568 value = new Class5568(text, subtable);
			hashtable_1.Add(text, value);
		}
	}

	protected void method_4()
	{
		if (bool_0)
		{
			return;
		}
		foreach (Class5568 value in hashtable_1.Values)
		{
			value.method_4(hashtable_1);
		}
		bool_0 = true;
	}

	public ArrayList method_5(string script, string language, string feature)
	{
		ArrayList arrayList = new ArrayList(hashtable_0.Keys);
		ArrayList arrayList2 = new ArrayList();
		Interface208 @interface = new Class5495(arrayList);
		while (@interface.imethod_0())
		{
			Class5567 @class = (Class5567)@interface.imethod_1();
			if (("*".Equals(script) || @class.method_0().Equals(script)) && ("*".Equals(language) || @class.method_1().Equals(language)) && ("*".Equals(feature) || @class.method_2().Equals(feature)))
			{
				arrayList2.Add(@class);
			}
		}
		return arrayList2;
	}

	public Hashtable method_6(string script, string language, string feature)
	{
		ArrayList arrayList = method_5(script, language, feature);
		Hashtable hashtable = new Hashtable();
		Interface208 @interface = new Class5495(arrayList);
		while (@interface.imethod_0())
		{
			Class5567 @class = (Class5567)@interface.imethod_1();
			hashtable.Add(@class, method_7(@class));
		}
		return hashtable;
	}

	public ArrayList method_7(Class5567 ls)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2;
		if ((arrayList2 = (ArrayList)hashtable_0[ls]) != null)
		{
			Interface208 @interface = new Class5495(arrayList2);
			while (@interface.imethod_0())
			{
				string key = (string)@interface.imethod_1();
				Class5568 value;
				if ((value = (Class5568)hashtable_1[key]) != null)
				{
					arrayList.Add(value);
				}
			}
		}
		return new ArrayList(arrayList);
	}

	public Class5569[] method_8(string[] features, Hashtable lookups)
	{
		ArrayList arrayList = new ArrayList();
		int i = 0;
		for (int num = features.Length; i < num; i++)
		{
			string text = features[i];
			foreach (DictionaryEntry lookup in lookups)
			{
				Class5567 @class = (Class5567)lookup.Key;
				if (!@class.method_2().Equals(text))
				{
					continue;
				}
				ArrayList arrayList2 = (ArrayList)lookup.Value;
				if (arrayList2 != null)
				{
					Interface208 @interface = new Class5495(arrayList2);
					while (@interface.imethod_0())
					{
						Class5568 lookupTable = (Class5568)@interface.imethod_1();
						arrayList.Add(new Class5569(lookupTable, text));
					}
				}
			}
		}
		return (Class5569[])arrayList.ToArray(typeof(Class5569));
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(base.ToString());
		stringBuilder.Append("{");
		stringBuilder.Append("lookups={");
		stringBuilder.Append(hashtable_0.ToString());
		stringBuilder.Append("},lookupTables={");
		stringBuilder.Append(hashtable_1.ToString());
		stringBuilder.Append("}}");
		return stringBuilder.ToString();
	}

	public static int smethod_0(string name)
	{
		string value = name.ToLower();
		if ("gsub".Equals(value))
		{
			return int_0;
		}
		if ("gpos".Equals(value))
		{
			return int_1;
		}
		if ("jstf".Equals(value))
		{
			return int_2;
		}
		if ("base".Equals(value))
		{
			return int_3;
		}
		if ("gdef".Equals(value))
		{
			return int_4;
		}
		return -1;
	}

	public static void smethod_1(Class5578[] rsa, Hashtable lookupTables)
	{
		if (rsa != null && lookupTables != null)
		{
			int i = 0;
			for (int num = rsa.Length; i < num; i++)
			{
				rsa[i]?.method_1(lookupTables);
			}
		}
	}
}
