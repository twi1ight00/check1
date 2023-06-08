using System;
using System.Collections.Generic;
using Aspose.Cells;
using ns1;
using ns2;
using ns29;

namespace ns12;

internal class Class1662
{
	internal static int Compare(double double_0, double double_1, string string_0)
	{
		switch (string_0)
		{
		case ">=":
			if (double_0 > double_1 || Math.Abs(double_0 - double_1) < double.Epsilon)
			{
				return 1;
			}
			break;
		case "<=":
			if (double_0 < double_1 || Math.Abs(double_0 - double_1) < double.Epsilon)
			{
				return 1;
			}
			break;
		case "<>":
			if (Math.Abs(double_0 - double_1) > double.Epsilon)
			{
				return 1;
			}
			break;
		case ">":
			if (double_0 > double_1)
			{
				return 1;
			}
			break;
		case "<":
			if (double_0 < double_1)
			{
				return 1;
			}
			break;
		case "=":
			if (Math.Abs(double_0 - double_1) < double.Epsilon)
			{
				return 1;
			}
			break;
		}
		return 0;
	}

	internal static int Compare(string string_0, string string_1, string string_2)
	{
		switch (string_2)
		{
		case "<>":
			if (string.Compare(string_0, string_1, ignoreCase: true) != 0)
			{
				return 1;
			}
			break;
		case ">=":
			if (string.Compare(string_0, string_1, ignoreCase: true) >= 0)
			{
				return 1;
			}
			break;
		case "<=":
			if (string.Compare(string_0, string_1, ignoreCase: true) <= 0)
			{
				return 1;
			}
			break;
		case ">":
			if (string.Compare(string_0, string_1, ignoreCase: true) > 0)
			{
				return 1;
			}
			break;
		case "<":
			if (string.Compare(string_0, string_1, ignoreCase: true) < 0)
			{
				return 1;
			}
			break;
		case "=":
			if (string_1.IndexOfAny(new char[2] { '*', '?' }) != -1 && Class1679.smethod_4(string_1, string_0, bool_0: true) == 0)
			{
				return 1;
			}
			if (string.Compare(string_0, string_1, ignoreCase: true) == 0)
			{
				return 1;
			}
			break;
		}
		return 0;
	}

	internal static int Compare(string string_0, string string_1, string string_2, bool bool_0)
	{
		switch (string_2)
		{
		case "<>":
			if (string.Compare(string_0, string_1, ignoreCase: true) != 0)
			{
				return 1;
			}
			break;
		case ">=":
			if (string.Compare(string_0, string_1, ignoreCase: true) >= 0)
			{
				return 1;
			}
			break;
		case "<=":
			if (string.Compare(string_0, string_1, ignoreCase: true) <= 0)
			{
				return 1;
			}
			break;
		case ">":
			if (string.Compare(string_0, string_1, ignoreCase: true) > 0)
			{
				return 1;
			}
			break;
		case "<":
			if (string.Compare(string_0, string_1, ignoreCase: true) < 0)
			{
				return 1;
			}
			break;
		case "=":
			if (bool_0 && string_1.IndexOfAny(new char[2] { '*', '?' }) != -1 && Class1679.smethod_4(string_1, string_0, bool_0: true) == 0)
			{
				return 1;
			}
			if (string.Compare(string_0, string_1, ignoreCase: true) == 0)
			{
				return 1;
			}
			break;
		}
		return 0;
	}

	internal static int smethod_0(string string_0, string string_1, string string_2)
	{
		string_0 = string_0.Trim();
		switch (string_2)
		{
		case "<>":
			if (string.Compare(string_0, string_1, ignoreCase: true) != 0)
			{
				return 1;
			}
			break;
		case ">=":
			if (string.Compare(string_0, string_1, ignoreCase: true) >= 0)
			{
				return 1;
			}
			break;
		case "<=":
			if (string.Compare(string_0, string_1, ignoreCase: true) <= 0)
			{
				return 1;
			}
			break;
		case ">":
			if (string.Compare(string_0, string_1, ignoreCase: true) > 0)
			{
				return 1;
			}
			break;
		case "<":
			if (string.Compare(string_0, string_1, ignoreCase: true) < 0)
			{
				return 1;
			}
			break;
		case "=":
			if (string_1.IndexOfAny(new char[2] { '*', '?' }) != -1 && Class1679.smethod_4(string_1, string_0, bool_0: true) == 0)
			{
				return 1;
			}
			if (string.Compare(string_0, string_1, ignoreCase: true) == 0)
			{
				return 1;
			}
			break;
		}
		return 0;
	}

	internal static double smethod_1(object object_0, bool bool_0)
	{
		if (object_0 == null)
		{
			return 0.0;
		}
		if (object_0 is ErrorType)
		{
			return 1.0;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return (double)object_0;
		case TypeCode.DateTime:
			return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
		default:
			return 1.0;
		case TypeCode.String:
		{
			string text = (string)object_0;
			if (text == "")
			{
				return 0.0;
			}
			return 1.0;
		}
		case TypeCode.Int32:
			return (int)object_0;
		case TypeCode.Boolean:
			if ((bool)object_0)
			{
				return 1.0;
			}
			return 0.0;
		}
	}

	internal static double CompareTo(double double_0, double double_1)
	{
		if (Math.Abs(double_0 - double_1) < double.Epsilon)
		{
			return 0.0;
		}
		if (double_0 > double_1)
		{
			return 1.0;
		}
		return -1.0;
	}

	internal static object CompareTo(object object_0, object object_1, bool bool_0, bool bool_1)
	{
		if (object_0 != null && object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_1 != null && object_1 is ErrorType)
		{
			return object_1;
		}
		if (object_0 != null && object_1 != null)
		{
			switch (Type.GetTypeCode(object_0.GetType()))
			{
			case TypeCode.Double:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				case TypeCode.Double:
				{
					double double_ = (double)object_0;
					double double_2 = (double)object_1;
					return CompareTo(double_, double_2);
				}
				case TypeCode.DateTime:
				{
					double double_ = (double)object_0;
					double double_2 = CellsHelper.GetDoubleFromDateTime((DateTime)object_1, bool_0);
					return CompareTo(double_, double_2);
				}
				default:
					return -1.0;
				case TypeCode.String:
					return -1.0;
				}
			case TypeCode.DateTime:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				case TypeCode.Double:
				{
					double double_ = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
					return CompareTo(double_, (double)object_1);
				}
				case TypeCode.DateTime:
				{
					double double_ = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
					double double_2 = CellsHelper.GetDoubleFromDateTime((DateTime)object_1, bool_0);
					return CompareTo(double_, double_2);
				}
				default:
					return -1.0;
				case TypeCode.String:
					return -1.0;
				}
			default:
				if (bool_1)
				{
					return (double)object_0.ToString().ToUpper().CompareTo(object_1.ToString().ToUpper());
				}
				return (double)object_0.ToString().CompareTo(object_1.ToString());
			case TypeCode.String:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				default:
					if (bool_1)
					{
						return (double)object_0.ToString().ToUpper().CompareTo(object_1.ToString().ToUpper());
					}
					return (double)object_0.ToString().CompareTo(object_1.ToString());
				case TypeCode.Double:
				case TypeCode.DateTime:
					return 1.0;
				case TypeCode.Boolean:
					return -1.0;
				}
			case TypeCode.Boolean:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				default:
					return 1.0;
				case TypeCode.Double:
				case TypeCode.DateTime:
				case TypeCode.String:
					return 1.0;
				case TypeCode.Boolean:
				{
					double double_ = (((bool)object_0) ? 1.0 : 0.0);
					double double_2 = (((bool)object_1) ? 1.0 : 0.0);
					return CompareTo(double_, double_2);
				}
				}
			}
		}
		double num = smethod_1(object_0, bool_0);
		double num2 = smethod_1(object_1, bool_0);
		if (num == num2)
		{
			return 0.0;
		}
		if (num > num2)
		{
			return 1.0;
		}
		return -1.0;
	}

	internal static object Compare(object object_0, object object_1, string string_0, bool bool_0, bool bool_1)
	{
		if (object_0 != null && object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_1 != null && object_1 is ErrorType)
		{
			return object_1;
		}
		if (object_0 != null && object_1 != null)
		{
			switch (Type.GetTypeCode(object_0.GetType()))
			{
			case TypeCode.Double:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				case TypeCode.Double:
					return smethod_4((double)object_0, (double)object_1, string_0);
				case TypeCode.DateTime:
				{
					double doubleFromDateTime2 = CellsHelper.GetDoubleFromDateTime((DateTime)object_1, bool_0);
					return smethod_4((double)object_0, doubleFromDateTime2, string_0);
				}
				default:
				{
					int num = Compare(object_0.ToString(), object_1.ToString(), string_0, bool_1);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.String:
				{
					string key3;
					if ((key3 = string_0) != null)
					{
						if (Class1742.dictionary_196 == null)
						{
							Class1742.dictionary_196 = new Dictionary<string, int>(6)
							{
								{ "=", 0 },
								{ ">", 1 },
								{ ">=", 2 },
								{ "<", 3 },
								{ "<>", 4 },
								{ "<=", 5 }
							};
						}
						if (Class1742.dictionary_196.TryGetValue(key3, out var value3))
						{
							switch (value3)
							{
							case 0:
							case 1:
							case 2:
								return false;
							case 3:
							case 4:
							case 5:
								return true;
							}
						}
					}
					int num = Compare(object_0.ToString(), object_1.ToString(), string_0, bool_1);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				}
			case TypeCode.DateTime:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				case TypeCode.Double:
				{
					double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
					return smethod_4(doubleFromDateTime, (double)object_1, string_0);
				}
				case TypeCode.DateTime:
				{
					double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
					double doubleFromDateTime2 = CellsHelper.GetDoubleFromDateTime((DateTime)object_1, bool_0);
					return smethod_4(doubleFromDateTime, doubleFromDateTime2, string_0);
				}
				default:
				{
					int num = Compare(object_0.ToString(), object_1.ToString(), string_0, bool_1);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.String:
				{
					string text3 = (string)object_1;
					object_1 = Class1660.smethod_26(text3, bool_0);
					if (object_1 is double)
					{
						double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
						return smethod_4(doubleFromDateTime, (double)object_1, string_0);
					}
					int num = Compare(object_0.ToString(), text3, string_0, bool_1);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				}
			default:
			{
				int num = Compare(object_0.ToString(), object_1.ToString(), string_0, bool_1);
				if (num == 1)
				{
					return true;
				}
				return false;
			}
			case TypeCode.String:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				default:
				{
					string text = (string)object_0;
					string text2 = object_1.ToString();
					int num;
					if (text2.Length == 0)
					{
						double double_ = ((text.Length != 0) ? 1 : 0);
						num = Compare(double_, 0.0, string_0);
					}
					else
					{
						num = Compare(text, text2, string_0, bool_1);
					}
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.Double:
				case TypeCode.DateTime:
				{
					string key2;
					if ((key2 = string_0) != null)
					{
						if (Class1742.dictionary_197 == null)
						{
							Class1742.dictionary_197 = new Dictionary<string, int>(6)
							{
								{ "<>", 0 },
								{ ">", 1 },
								{ ">=", 2 },
								{ "<", 3 },
								{ "=", 4 },
								{ "<=", 5 }
							};
						}
						if (Class1742.dictionary_197.TryGetValue(key2, out var value2))
						{
							switch (value2)
							{
							case 0:
							case 1:
							case 2:
								return true;
							case 3:
							case 4:
							case 5:
								return false;
							}
						}
					}
					int num = Compare((string)object_0, object_1.ToString(), string_0, bool_1);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.Boolean:
				{
					string key;
					if ((key = string_0) != null)
					{
						if (Class1742.dictionary_198 == null)
						{
							Class1742.dictionary_198 = new Dictionary<string, int>(6)
							{
								{ "<>", 0 },
								{ ">", 1 },
								{ ">=", 2 },
								{ "=", 3 },
								{ "<", 4 },
								{ "<=", 5 }
							};
						}
						if (Class1742.dictionary_198.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
								return true;
							case 1:
							case 2:
							case 3:
								return false;
							case 4:
							case 5:
								return true;
							}
						}
					}
					int num = Compare((string)object_0, object_1.ToString(), string_0, bool_1);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				}
			}
		}
		double num2 = smethod_1(object_0, bool_0);
		double num3 = smethod_1(object_1, bool_0);
		string key4;
		if ((key4 = string_0) != null)
		{
			if (Class1742.dictionary_195 == null)
			{
				Class1742.dictionary_195 = new Dictionary<string, int>(6)
				{
					{ "=", 0 },
					{ "<>", 1 },
					{ ">=", 2 },
					{ "<=", 3 },
					{ ">", 4 },
					{ "<", 5 }
				};
			}
			if (Class1742.dictionary_195.TryGetValue(key4, out var value4))
			{
				switch (value4)
				{
				case 0:
					return num2 == num3;
				case 1:
					return num2 != num3;
				case 2:
					return num2 >= num3;
				case 3:
					return num2 <= num3;
				case 4:
					return num2 > num3;
				case 5:
					return num2 < num3;
				}
			}
		}
		return false;
	}

	internal static object Compare(object object_0, object object_1, string string_0, bool bool_0)
	{
		return Compare(object_0, object_1, string_0, bool_0, bool_1: false);
	}

	internal static object smethod_2(object object_0, object object_1, string string_0, bool bool_0)
	{
		if (object_0 != null && object_0 is ErrorType)
		{
			object_0 = Class1673.smethod_4((ErrorType)object_0);
		}
		if (object_1 != null && object_1 is ErrorType)
		{
			object_1 = Class1673.smethod_4((ErrorType)object_1);
		}
		if (object_0 != null && object_1 != null)
		{
			switch (Type.GetTypeCode(object_0.GetType()))
			{
			case TypeCode.Double:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				case TypeCode.Double:
					return smethod_4((double)object_0, (double)object_1, string_0);
				case TypeCode.DateTime:
				{
					double doubleFromDateTime2 = CellsHelper.GetDoubleFromDateTime((DateTime)object_1, bool_0);
					return smethod_4((double)object_0, doubleFromDateTime2, string_0);
				}
				default:
				{
					int num = smethod_0(object_0.ToString(), object_1.ToString(), string_0);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.String:
				{
					string key3;
					if ((key3 = string_0) != null)
					{
						if (Class1742.dictionary_200 == null)
						{
							Class1742.dictionary_200 = new Dictionary<string, int>(6)
							{
								{ "=", 0 },
								{ ">", 1 },
								{ ">=", 2 },
								{ "<", 3 },
								{ "<>", 4 },
								{ "<=", 5 }
							};
						}
						if (Class1742.dictionary_200.TryGetValue(key3, out var value3))
						{
							switch (value3)
							{
							case 0:
							case 1:
							case 2:
								return false;
							case 3:
							case 4:
							case 5:
								return true;
							}
						}
					}
					int num = smethod_0(object_0.ToString(), object_1.ToString(), string_0);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				}
			case TypeCode.DateTime:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				case TypeCode.Double:
				{
					double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
					return smethod_4(doubleFromDateTime, (double)object_1, string_0);
				}
				case TypeCode.DateTime:
				{
					double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
					double doubleFromDateTime2 = CellsHelper.GetDoubleFromDateTime((DateTime)object_1, bool_0);
					return smethod_4(doubleFromDateTime, doubleFromDateTime2, string_0);
				}
				default:
				{
					int num = smethod_0(object_0.ToString(), object_1.ToString(), string_0);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.String:
				{
					string text3 = (string)object_1;
					object_1 = Class1660.smethod_26(text3, bool_0);
					if (object_1 is double)
					{
						double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
						return smethod_4(doubleFromDateTime, (double)object_1, string_0);
					}
					int num = smethod_0(object_0.ToString(), text3, string_0);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				}
			default:
			{
				int num = smethod_0(object_0.ToString(), object_1.ToString(), string_0);
				if (num == 1)
				{
					return true;
				}
				return false;
			}
			case TypeCode.String:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				default:
				{
					string text = (string)object_0;
					string text2 = object_1.ToString();
					int num;
					if (text2.Length == 0)
					{
						double double_ = ((text.Length != 0) ? 1 : 0);
						num = Compare(double_, 0.0, string_0);
					}
					else
					{
						num = smethod_0(text, text2, string_0);
					}
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.Double:
				case TypeCode.DateTime:
				{
					string key2;
					if ((key2 = string_0) != null)
					{
						if (Class1742.dictionary_201 == null)
						{
							Class1742.dictionary_201 = new Dictionary<string, int>(6)
							{
								{ "<>", 0 },
								{ ">", 1 },
								{ ">=", 2 },
								{ "<", 3 },
								{ "<=", 4 },
								{ "=", 5 }
							};
						}
						if (Class1742.dictionary_201.TryGetValue(key2, out var value2))
						{
							switch (value2)
							{
							case 0:
							case 1:
							case 2:
								return true;
							case 3:
							case 4:
								return false;
							case 5:
								return (string)object_0 == object_1.ToString();
							}
						}
					}
					int num = smethod_0((string)object_0, object_1.ToString(), string_0);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.Boolean:
				{
					string key;
					if ((key = string_0) != null)
					{
						if (Class1742.dictionary_202 == null)
						{
							Class1742.dictionary_202 = new Dictionary<string, int>(6)
							{
								{ "<>", 0 },
								{ ">", 1 },
								{ ">=", 2 },
								{ "=", 3 },
								{ "<", 4 },
								{ "<=", 5 }
							};
						}
						if (Class1742.dictionary_202.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
								return true;
							case 1:
							case 2:
							case 3:
								return false;
							case 4:
							case 5:
								return true;
							}
						}
					}
					int num = smethod_0((string)object_0, object_1.ToString(), string_0);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				}
			}
		}
		double num2 = smethod_1(object_0, bool_0);
		double num3 = smethod_1(object_1, bool_0);
		string key4;
		if ((key4 = string_0) != null)
		{
			if (Class1742.dictionary_199 == null)
			{
				Class1742.dictionary_199 = new Dictionary<string, int>(6)
				{
					{ "=", 0 },
					{ "<>", 1 },
					{ ">=", 2 },
					{ "<=", 3 },
					{ ">", 4 },
					{ "<", 5 }
				};
			}
			if (Class1742.dictionary_199.TryGetValue(key4, out var value4))
			{
				switch (value4)
				{
				case 0:
					return num2 == num3;
				case 1:
					return num2 != num3;
				case 2:
					return num2 >= num3;
				case 3:
					return num2 <= num3;
				case 4:
					return num2 > num3;
				case 5:
					return num2 < num3;
				}
			}
		}
		return false;
	}

	internal static object smethod_3(object object_0, object object_1, string string_0, bool bool_0)
	{
		if (object_0 != null && object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_1 != null && object_1 is ErrorType)
		{
			return object_1;
		}
		if (object_0 != null && object_1 != null)
		{
			switch (Type.GetTypeCode(object_0.GetType()))
			{
			case TypeCode.Double:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				case TypeCode.Double:
					return smethod_4((double)object_0, (double)object_1, string_0);
				case TypeCode.DateTime:
				{
					double double_3 = CellsHelper.GetDoubleFromDateTime((DateTime)object_1, bool_0);
					return smethod_4((double)object_0, double_3, string_0);
				}
				default:
				{
					int num = Compare(object_0.ToString(), object_1.ToString(), string_0);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.String:
				{
					string text4;
					if ((text4 = string_0) != null && text4 == "<>")
					{
						return true;
					}
					return false;
				}
				}
			case TypeCode.DateTime:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				case TypeCode.Double:
				{
					double double_2 = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
					return smethod_4(double_2, (double)object_1, string_0);
				}
				case TypeCode.DateTime:
				{
					double double_2 = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
					double double_3 = CellsHelper.GetDoubleFromDateTime((DateTime)object_1, bool_0);
					return smethod_4(double_2, double_3, string_0);
				}
				default:
				{
					int num = Compare(object_0.ToString(), object_1.ToString(), string_0);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.String:
				{
					string text3 = (string)object_1;
					object_1 = Class1660.smethod_26(text3, bool_0);
					if (object_1 is double)
					{
						double double_2 = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
						return smethod_4(double_2, (double)object_1, string_0);
					}
					int num = Compare(object_0.ToString(), text3, string_0);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				}
			default:
			{
				int num = Compare(object_0.ToString(), object_1.ToString(), string_0);
				if (num == 1)
				{
					return true;
				}
				return false;
			}
			case TypeCode.String:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				default:
				{
					string text = (string)object_0;
					string text2 = object_1.ToString();
					int num;
					if (text2.Length == 0)
					{
						double double_ = ((text.Length != 0) ? 1 : 0);
						num = Compare(double_, 0.0, string_0);
					}
					else
					{
						num = Compare(text, text2, string_0);
					}
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.Double:
				case TypeCode.DateTime:
				{
					string key2;
					if ((key2 = string_0) != null)
					{
						if (Class1742.dictionary_204 == null)
						{
							Class1742.dictionary_204 = new Dictionary<string, int>(6)
							{
								{ "<>", 0 },
								{ ">", 1 },
								{ ">=", 2 },
								{ "=", 3 },
								{ "<", 4 },
								{ "<=", 5 }
							};
						}
						if (Class1742.dictionary_204.TryGetValue(key2, out var value2))
						{
							switch (value2)
							{
							case 0:
							case 1:
							case 2:
								return false;
							case 3:
								if (Class1677.smethod_20((string)object_0))
								{
									double double_2 = double.Parse((string)object_0);
									double double_3;
									switch (Type.GetTypeCode(object_1.GetType()))
									{
									case TypeCode.Double:
										double_3 = (double)object_1;
										break;
									default:
										return false;
									case TypeCode.DateTime:
										double_3 = CellsHelper.GetDoubleFromDateTime((DateTime)object_1, bool_0);
										break;
									}
									return Class1374.smethod_0(double_2, double_3);
								}
								return false;
							case 4:
							case 5:
								return false;
							}
						}
					}
					int num = Compare((string)object_0, object_1.ToString(), string_0);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				case TypeCode.Boolean:
				{
					string key;
					if ((key = string_0) != null)
					{
						if (Class1742.dictionary_205 == null)
						{
							Class1742.dictionary_205 = new Dictionary<string, int>(6)
							{
								{ "<>", 0 },
								{ ">", 1 },
								{ ">=", 2 },
								{ "=", 3 },
								{ "<", 4 },
								{ "<=", 5 }
							};
						}
						if (Class1742.dictionary_205.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
								return true;
							case 1:
							case 2:
							case 3:
								return false;
							case 4:
							case 5:
								return true;
							}
						}
					}
					int num = Compare((string)object_0, object_1.ToString(), string_0);
					if (num == 1)
					{
						return true;
					}
					return false;
				}
				}
			}
		}
		if (object_0 == null && object_1 != null)
		{
			switch (string_0)
			{
			case "<>":
				return true;
			case "=":
				if (object_1 is string && (string)object_1 == "")
				{
					return true;
				}
				return false;
			default:
				return false;
			}
		}
		if (object_0 != null && object_1 == null)
		{
			string text5;
			if ((text5 = string_0) != null && text5 == "<>")
			{
				return true;
			}
			return false;
		}
		double num2 = smethod_1(object_0, bool_0);
		double num3 = smethod_1(object_1, bool_0);
		string key3;
		if ((key3 = string_0) != null)
		{
			if (Class1742.dictionary_203 == null)
			{
				Class1742.dictionary_203 = new Dictionary<string, int>(6)
				{
					{ "=", 0 },
					{ "<>", 1 },
					{ ">=", 2 },
					{ "<=", 3 },
					{ ">", 4 },
					{ "<", 5 }
				};
			}
			if (Class1742.dictionary_203.TryGetValue(key3, out var value3))
			{
				switch (value3)
				{
				case 0:
					if (object_0 == null && object_1 != null && object_1.ToString() != "" && num3 == 0.0)
					{
						return false;
					}
					return num2 == num3;
				case 1:
					return num2 != num3;
				case 2:
					return num2 >= num3;
				case 3:
					return num2 <= num3;
				case 4:
					return num2 > num3;
				case 5:
					return num2 < num3;
				}
			}
		}
		return false;
	}

	internal static bool smethod_4(double double_0, double double_1, string string_0)
	{
		switch (string_0)
		{
		case "<>":
			if (Class1374.smethod_0(double_0, double_1))
			{
				return false;
			}
			if (Math.Abs(double_0 - double_1) <= 1E-16)
			{
				return false;
			}
			return true;
		case ">=":
			if (!(double_0 > double_1) && Math.Abs(double_0 - double_1) > 1E-16)
			{
				return false;
			}
			return true;
		case "<=":
			if (!(double_0 < double_1) && Math.Abs(double_0 - double_1) > 1E-16)
			{
				return false;
			}
			return true;
		case ">":
			if (Class1374.smethod_0(double_0, double_1))
			{
				return false;
			}
			if (double_0 > double_1)
			{
				return true;
			}
			return false;
		case "<":
			if (Class1374.smethod_0(double_0, double_1))
			{
				return false;
			}
			if (double_0 < double_1)
			{
				return true;
			}
			return false;
		case "=":
			if (Class1374.smethod_0(double_0, double_1))
			{
				return true;
			}
			if (Math.Abs(double_0 - double_1) <= 1E-16)
			{
				return true;
			}
			return false;
		default:
			return false;
		}
	}

	internal static object smethod_5(string string_0)
	{
		bool flag = false;
		if (string_0[string_0.Length - 1] == '%')
		{
			flag = true;
			string_0 = string_0.Substring(0, string_0.Length - 1);
		}
		object obj = Class1677.smethod_37(string_0);
		if (obj != null)
		{
			if (flag)
			{
				obj = Class1660.smethod_26(obj, bool_0: false);
				if (obj is ErrorType)
				{
					return obj;
				}
				return (double)obj / 100.0;
			}
			return obj;
		}
		if (Class1677.smethod_17(string_0))
		{
			try
			{
				return DateTime.Parse(string_0);
			}
			catch
			{
			}
		}
		return string_0;
	}

	internal static object[] smethod_6(string string_0)
	{
		object[] array = new object[2] { "=", string_0 };
		if (string_0 != null && string_0.Length >= 1)
		{
			switch (string_0[0])
			{
			default:
				array[0] = "=";
				array[1] = string_0;
				break;
			case '<':
				if (string_0.Length > 1)
				{
					switch (string_0[1])
					{
					default:
						array[0] = "<";
						array[1] = string_0.Substring(1);
						break;
					case '=':
						array[0] = "<=";
						array[1] = string_0.Substring(2);
						break;
					case '>':
						array[0] = "<>";
						array[1] = string_0.Substring(2);
						break;
					}
				}
				else
				{
					array[0] = "<";
					array[1] = string_0.Substring(1);
				}
				break;
			case '=':
				array[0] = "=";
				array[1] = string_0.Substring(1);
				break;
			case '>':
				if (string_0.Length > 1)
				{
					char c = string_0[1];
					if (c == '=')
					{
						array[0] = ">=";
						array[1] = string_0.Substring(2);
					}
					else
					{
						array[0] = ">";
						array[1] = string_0.Substring(1);
					}
				}
				else
				{
					array[0] = ">";
					array[1] = string_0.Substring(1);
				}
				break;
			}
			if (array[1] != null)
			{
				string text = (string)array[1];
				if (text == "")
				{
					array[1] = null;
					return array;
				}
				bool flag = false;
				if (text[text.Length - 1] == '%')
				{
					flag = true;
					text = text.Substring(0, text.Length - 1);
				}
				object obj = Class1677.smethod_37(text);
				if (obj != null)
				{
					if (flag)
					{
						obj = Class1660.smethod_26(obj, bool_0: false);
						if (obj is ErrorType)
						{
							return array;
						}
						array[1] = (double)obj / 100.0;
					}
					else
					{
						array[1] = obj;
					}
				}
				else if (Class1677.smethod_17(text))
				{
					try
					{
						array[1] = DateTime.Parse(text);
					}
					catch
					{
					}
				}
			}
			return array;
		}
		return array;
	}
}
