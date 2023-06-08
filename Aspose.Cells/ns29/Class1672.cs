using System.Collections.Generic;
using Aspose.Cells;
using ns1;
using ns2;

namespace ns29;

internal class Class1672
{
	internal static bool smethod_0(Class1661 class1661_0, bool bool_0)
	{
		bool result = false;
		if (class1661_0 != null && class1661_0.method_5() != null)
		{
			if (!bool_0)
			{
				switch (class1661_0.method_9()[0])
				{
				case 24:
					if (class1661_0.method_9()[1] == 7)
					{
						bool_0 = true;
					}
					break;
				default:
					switch (class1661_0.method_5().Type)
					{
					case Enum180.const_3:
					case Enum180.const_4:
					case Enum180.const_5:
						switch (class1661_0.method_5().method_3())
						{
						case "VLOOKUP":
							if (class1661_0.method_5().method_7()[2] == class1661_0)
							{
								return true;
							}
							break;
						case "IF":
							if (class1661_0.method_5().method_7()[0] != class1661_0)
							{
								return smethod_0(class1661_0.method_5(), bool_0: true);
							}
							break;
						}
						break;
					}
					break;
				case 69:
				case 77:
				case 89:
				case 91:
					bool_0 = true;
					break;
				}
			}
			if (bool_0)
			{
				switch (class1661_0.method_5().Type)
				{
				case Enum180.const_3:
				case Enum180.const_4:
				case Enum180.const_5:
				{
					string key;
					if ((key = class1661_0.method_5().method_3()) == null)
					{
						break;
					}
					if (Class1742.dictionary_208 == null)
					{
						Class1742.dictionary_208 = new Dictionary<string, int>(7)
						{
							{ "ISBLANK", 0 },
							{ "ISERROR", 1 },
							{ "IF", 2 },
							{ "RANK", 3 },
							{ "VLOOKUP", 4 },
							{ "COUNTIFS", 5 },
							{ "_xlfn.COUNTIFS", 6 }
						};
					}
					if (!Class1742.dictionary_208.TryGetValue(key, out var value))
					{
						break;
					}
					switch (value)
					{
					case 0:
					case 1:
						result = true;
						break;
					case 2:
						if (class1661_0.method_5().method_7()[0] == class1661_0 && class1661_0.method_5().method_9()[0] == 34)
						{
							result = true;
						}
						break;
					case 3:
					case 4:
						if (class1661_0.method_5().method_7()[0] == class1661_0)
						{
							result = true;
						}
						break;
					case 5:
					case 6:
					{
						for (int i = 0; i < class1661_0.method_5().method_7().Count; i++)
						{
							if (class1661_0.method_5().method_7()[i] == class1661_0 && i % 2 == 1)
							{
								return true;
							}
						}
						break;
					}
					}
					break;
				}
				case Enum180.const_2:
				case Enum180.const_6:
					result = true;
					break;
				}
			}
		}
		else
		{
			result = true;
		}
		return result;
	}

	internal static int[] smethod_1(Cell cell_0, int int_0, int int_1, int int_2, int int_3)
	{
		int[] array = new int[2];
		if (cell_0 != null)
		{
			array[0] = cell_0.Row;
			array[1] = cell_0.Column;
		}
		if (array[0] >= int_0 && array[0] <= int_2 && array[1] >= int_1 && array[1] <= int_3)
		{
			return array;
		}
		if (int_0 == int_2)
		{
			if (int_1 == int_3)
			{
				array[0] = int_0;
				array[1] = int_1;
				return array;
			}
			if (array[1] >= int_1 && array[1] <= int_3)
			{
				array[0] = int_0;
				return array;
			}
		}
		else if (int_1 == int_3 && array[0] >= int_0 && array[0] <= int_2)
		{
			array[1] = int_1;
			return array;
		}
		return null;
	}

	internal static bool smethod_2(Class1661 class1661_0)
	{
		string text;
		do
		{
			if (class1661_0.method_5() != null)
			{
				class1661_0 = class1661_0.method_5();
				continue;
			}
			return false;
		}
		while (class1661_0.Type != Enum180.const_3 || (text = class1661_0.method_3()) == null || !(text == "SUMPRODUCT"));
		return true;
	}
}
