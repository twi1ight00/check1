using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using ns22;

namespace ns2;

internal class Class1718
{
	private Enum194 enum194_0;

	private ArrayList arrayList_0;

	private string[] string_0;

	private ArrayList arrayList_1;

	private string string_1;

	internal Enum194 Type
	{
		get
		{
			return enum194_0;
		}
		set
		{
			enum194_0 = value;
		}
	}

	internal Class1718()
	{
		arrayList_0 = new ArrayList();
	}

	internal Class1718(Enum194 enum194_1)
	{
		enum194_0 = enum194_1;
		arrayList_0 = new ArrayList();
	}

	[SpecialName]
	internal ArrayList method_0()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal void method_1(ArrayList arrayList_2)
	{
		arrayList_0 = arrayList_2;
	}

	internal int method_2(WorksheetCollection worksheetCollection_0, string string_2)
	{
		int result = -1;
		bool flag = false;
		for (int i = 0; i < method_0().Count; i++)
		{
			Class1653 @class = (Class1653)method_0()[i];
			if (@class.Name.ToUpper() == string_2.ToUpper())
			{
				result = i + 1;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			Class1653 value = new Class1653(this);
			method_0().Add(value);
			result = method_0().Count;
		}
		return result;
	}

	internal void method_3(string string_2)
	{
		if (string_0 == null)
		{
			string_0 = new string[1] { string_2 };
			return;
		}
		string[] array = new string[string_0.Length + 1];
		for (int i = 0; i < string_0.Length; i++)
		{
			array[i] = string_0[i];
		}
		array[array.Length - 1] = string_2;
		string_0 = array;
	}

	[SpecialName]
	internal string[] method_4()
	{
		return string_0;
	}

	[SpecialName]
	internal void method_5(string[] string_2)
	{
		string_0 = string_2;
	}

	internal int method_6(string string_2)
	{
		if (string_0 != null && string_0.Length != 0)
		{
			int num = 0;
			while (true)
			{
				if (num < string_0.Length)
				{
					if (string.Compare(string_0[num], string_2, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}
		return -1;
	}

	internal ArrayList method_7()
	{
		return arrayList_1;
	}

	internal void method_8(ArrayList arrayList_2)
	{
		arrayList_1 = arrayList_2;
	}

	internal Class1373 method_9(int int_0)
	{
		if (arrayList_1 == null)
		{
			arrayList_1 = new ArrayList();
		}
		if (int_0 >= arrayList_1.Count)
		{
			for (int i = arrayList_1.Count; i < int_0 + 1; i++)
			{
				arrayList_1.Add(null);
			}
		}
		Class1373 @class = (Class1373)arrayList_1[int_0];
		if (@class == null)
		{
			@class = new Class1373();
			arrayList_1[int_0] = @class;
		}
		return @class;
	}

	internal Class1373 method_10(int int_0)
	{
		if (arrayList_1 == null)
		{
			return null;
		}
		if (int_0 >= arrayList_1.Count)
		{
			return null;
		}
		return (Class1373)arrayList_1[int_0];
	}

	internal Class1373 method_11(string string_2)
	{
		string_2 = string_2.ToUpper();
		if (string_0 != null)
		{
			for (int i = 0; i < string_0.Length; i++)
			{
				if (string_0[i].ToUpper() == string_2)
				{
					return method_10(i);
				}
			}
		}
		return null;
	}

	[SpecialName]
	internal bool method_12()
	{
		return enum194_0 == Enum194.const_1;
	}

	[SpecialName]
	internal void method_13(bool bool_0)
	{
		enum194_0 = Enum194.const_1;
	}

	[SpecialName]
	internal bool method_14()
	{
		return enum194_0 == Enum194.const_2;
	}

	[SpecialName]
	internal bool method_15()
	{
		return enum194_0 == Enum194.const_0;
	}

	internal void Copy(Class1718 class1718_0)
	{
		enum194_0 = class1718_0.enum194_0;
		string_1 = class1718_0.string_1;
		if (class1718_0.string_0 != null)
		{
			string_0 = new string[class1718_0.string_0.Length];
			for (int i = 0; i < class1718_0.string_0.Length; i++)
			{
				string_0[i] = class1718_0.string_0[i];
			}
		}
		if (class1718_0.arrayList_0 != null && class1718_0.arrayList_0.Count > 0)
		{
			for (int j = 0; j < class1718_0.arrayList_0.Count; j++)
			{
				Class1653 class1653_ = (Class1653)class1718_0.arrayList_0[j];
				Class1653 @class = new Class1653(this);
				@class.Copy(class1653_);
				arrayList_0.Add(@class);
			}
		}
		if (class1718_0.arrayList_1 == null)
		{
			return;
		}
		arrayList_1 = new ArrayList();
		for (int k = 0; k < class1718_0.arrayList_1.Count; k++)
		{
			Class1373 class2 = (Class1373)class1718_0.arrayList_1[k];
			if (class2 == null)
			{
				arrayList_1.Add(null);
				continue;
			}
			Class1373 class3 = new Class1373();
			class3.Copy(class2);
			arrayList_1.Add(class3);
		}
	}

	[SpecialName]
	internal string method_16()
	{
		return string_1;
	}

	[SpecialName]
	internal void method_17(string string_2)
	{
		string_1 = string_2;
	}

	internal string method_18()
	{
		if (string_1 != null && !(string_1 == ""))
		{
			return smethod_1(string_1);
		}
		return null;
	}

	internal string method_19(Workbook workbook_0)
	{
		if (string_1 != null && !(string_1 == ""))
		{
			string text = string_1;
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = text.ToCharArray();
			switch (array[0])
			{
			default:
				if (workbook_0.method_19() != null)
				{
					stringBuilder.Append(workbook_0.method_19());
				}
				stringBuilder.Append(text);
				return stringBuilder.ToString();
			case '\u0001':
			{
				for (int i = 1; i < array.Length; i++)
				{
					switch (array[i])
					{
					default:
						if (i == 1 && workbook_0.method_19() != null)
						{
							stringBuilder.Append(workbook_0.method_19());
						}
						stringBuilder.Append(array[i]);
						break;
					case '\'':
						if (i + 1 < array.Length && array[i + 1] != '\'')
						{
							stringBuilder.Append("''");
						}
						break;
					case '\u0001':
						if (array[i + 1] == '@')
						{
							i++;
							stringBuilder.Append("\\\\");
						}
						else
						{
							stringBuilder.Append(array[i + 1]);
							i++;
							stringBuilder.Append(":\\");
						}
						break;
					case '\u0002':
						if (workbook_0.method_19() != null)
						{
							stringBuilder.Append(Class1185.smethod_0(workbook_0.method_19()));
						}
						else
						{
							stringBuilder.Append("C:\\");
						}
						break;
					case '\u0003':
						if (workbook_0.method_19() != null && stringBuilder.Length == 0)
						{
							stringBuilder.Append(workbook_0.method_19());
						}
						else
						{
							stringBuilder.Append("\\");
						}
						break;
					case '\u0004':
						if (workbook_0.method_19() != null)
						{
							int num = workbook_0.method_19().LastIndexOf('\\');
							if (num != -1 && num != workbook_0.method_19().Length - 1)
							{
								stringBuilder.Append(workbook_0.method_19().Substring(0, num + 1));
							}
							else
							{
								stringBuilder.Append(workbook_0.method_19());
							}
						}
						else
						{
							stringBuilder.Append("../");
						}
						break;
					case '\u0005':
						if (i != 1)
						{
							stringBuilder.Append(array[i]);
							break;
						}
						return string_1.Substring(i + 2);
					case '\u0006':
						if (CellsHelper.StartupPath != null)
						{
							stringBuilder.Append(CellsHelper.StartupPath);
						}
						break;
					case '\a':
						if (CellsHelper.LibraryPath != null)
						{
							stringBuilder.Append(CellsHelper.LibraryPath);
						}
						break;
					case '\b':
						if (CellsHelper.AltStartPath != null)
						{
							stringBuilder.Append(CellsHelper.AltStartPath);
						}
						break;
					}
				}
				return stringBuilder.ToString();
			}
			case '\0':
			case '\u0002':
				return "";
			}
		}
		return null;
	}

	internal void method_20(out string progId, out string fileName)
	{
		fileName = (progId = "");
		if (enum194_0 == Enum194.const_3 || enum194_0 == Enum194.const_4)
		{
			string[] array = string_1.Split('\u0003');
			progId = array[0];
			fileName = array[1];
		}
	}

	internal void method_21(string string_2, string string_3)
	{
		string_1 = string_2 + '\u0003' + string_3;
	}

	internal void method_22(out string progId, out string fileName)
	{
		progId = (fileName = "");
		if (enum194_0 != Enum194.const_3 && enum194_0 != Enum194.const_4)
		{
			return;
		}
		string[] array = string_1.Split('\u0003');
		progId = array[0];
		fileName = array[1];
		if (fileName != null && fileName.Length > 2)
		{
			if (fileName[1] == ':')
			{
				fileName = "file:///" + fileName;
			}
			else if (fileName[0] == '\\' && fileName[1] == '\\')
			{
				fileName = "file:///" + fileName;
			}
		}
	}

	internal void method_23(string string_2, string string_3)
	{
		if (string_3.StartsWith("file:///"))
		{
			string_3 = string_3.Substring(8);
		}
		string_1 = string_2 + '\u0003' + string_3;
	}

	internal void method_24(string string_2, string[] string_3, Enum188 enum188_0)
	{
		if (string_2 == null || string_2 == "")
		{
			string_1 = null;
		}
		string_1 = smethod_0(string_2, enum188_0);
		string_0 = string_3;
	}

	[SpecialName]
	internal string method_25()
	{
		if (enum194_0 != Enum194.const_3 && enum194_0 != Enum194.const_4)
		{
			return smethod_1(string_1);
		}
		string[] array = string_1.Split('\u0003');
		return array[0];
	}

	[SpecialName]
	internal string method_26()
	{
		string text = null;
		if (enum194_0 != Enum194.const_3 && enum194_0 != Enum194.const_4)
		{
			text = smethod_1(string_1);
		}
		else
		{
			string[] array = string_1.Split('\u0003');
			text = array[0];
		}
		if (text != null && text.Length > 2)
		{
			if (text[1] == ':')
			{
				text = "file:///" + text;
			}
			else if (text[0] == '\\' && text[1] == '\\')
			{
				text = "file:///" + text;
			}
		}
		return text;
	}

	[SpecialName]
	internal void method_27(string string_2)
	{
		string text = string_2;
		if (text.StartsWith("file:///"))
		{
			text = text.Substring(8);
		}
		string_1 = smethod_0(text, Enum188.const_0);
	}

	internal static string smethod_0(string string_2, Enum188 enum188_0)
	{
		string_2 = string_2.Replace('/', '\\');
		if (enum188_0 == Enum188.const_0 && string_2.IndexOf('\\') == -1)
		{
			return string_2;
		}
		char[] array = string_2.ToCharArray();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('\u0001');
		int i = 0;
		bool flag = false;
		if (array.Length >= 2)
		{
			if (array[0] == '\\')
			{
				if (array[1] == '\\')
				{
					flag = true;
					stringBuilder.Append(smethod_2(Enum188.const_1));
					stringBuilder.Append('@');
					i = 2;
				}
				else
				{
					stringBuilder.Append(smethod_2(Enum188.const_2));
					i = 1;
				}
			}
			else if (array[0] == '.' && array[1] == '.')
			{
				stringBuilder.Append(smethod_2(Enum188.const_4));
				i = 3;
			}
			else if (array[1] == ':')
			{
				flag = true;
				stringBuilder.Append(smethod_2(Enum188.const_1));
				stringBuilder.Append(array[0]);
				i = 3;
			}
		}
		if (!flag)
		{
			switch (enum188_0)
			{
			case Enum188.const_6:
			case Enum188.const_7:
			case Enum188.const_8:
				if (stringBuilder.Length < 2)
				{
					stringBuilder.Append(smethod_2(enum188_0));
				}
				else
				{
					stringBuilder.Insert(1, smethod_2(enum188_0));
				}
				break;
			}
		}
		for (; i < array.Length; i++)
		{
			char c = array[i];
			if (c == '\\')
			{
				stringBuilder.Append(smethod_2(Enum188.const_3));
			}
			else
			{
				stringBuilder.Append(array[i]);
			}
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_1(string string_2)
	{
		if (string_2 != null && !(string_2 == ""))
		{
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = string_2.ToCharArray();
			switch (array[0])
			{
			default:
				return string_2;
			case '\u0001':
			{
				for (int i = 1; i < array.Length; i++)
				{
					switch (array[i])
					{
					default:
						stringBuilder.Append(array[i]);
						break;
					case '\u0001':
						if (array[i + 1] == '@')
						{
							i++;
							stringBuilder.Append("\\\\");
						}
						else
						{
							stringBuilder.Append(array[i + 1]);
							i++;
							stringBuilder.Append(":\\");
						}
						break;
					case '\u0002':
						stringBuilder.Append("\\");
						break;
					case '\u0003':
						stringBuilder.Append("\\");
						break;
					case '\u0004':
						stringBuilder.Append("../");
						break;
					case '\u0005':
						i++;
						break;
					case '\u0006':
					case '\a':
					case '\b':
						break;
					}
				}
				return stringBuilder.ToString();
			}
			case '\0':
			case '\u0002':
				return "";
			}
		}
		return "";
	}

	internal static char smethod_2(Enum188 enum188_0)
	{
		return (char)enum188_0;
	}
}
