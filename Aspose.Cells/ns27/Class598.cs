using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cells;
using ns1;
using ns2;
using ns22;
using ns59;

namespace ns27;

internal class Class598 : Class538
{
	private Class539 class539_0;

	internal Class598()
	{
		method_2(158);
		method_0(24);
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		base.vmethod_0(class1725_0);
		if (class539_0 != null)
		{
			class539_0.vmethod_0(class1725_0);
		}
	}

	[Attribute0(true)]
	internal void method_4(FilterColumn filterColumn_0)
	{
		class539_0 = null;
		switch (filterColumn_0.FilterType)
		{
		case FilterType.MultipleFilters:
		{
			MultipleFilterCollection multipleFilterCollection = (MultipleFilterCollection)filterColumn_0.Filter;
			if (multipleFilterCollection.Count < 1)
			{
				method_5(new Class1194(filterColumn_0));
				break;
			}
			switch (multipleFilterCollection.Count)
			{
			case 0:
				method_5(new Class1194(filterColumn_0));
				return;
			case 1:
				if (!multipleFilterCollection.MatchBlank && multipleFilterCollection[0] is string)
				{
					method_5(new Class1194(filterColumn_0));
					return;
				}
				break;
			case 2:
				if (!multipleFilterCollection.MatchBlank && multipleFilterCollection[0] is string && multipleFilterCollection[1] is string)
				{
					method_5(new Class1194(filterColumn_0));
					return;
				}
				break;
			}
			class539_0 = new Class539();
			class539_0.method_4(filterColumn_0);
			goto default;
		}
		default:
			byte_0 = new byte[base.Length];
			byte_0[0] = (byte)filterColumn_0.FieldIndex;
			byte_0[2] = 1;
			byte_0[5] = 2;
			byte_0[12] = 40;
			byte_0[13] = 64;
			break;
		case FilterType.CustomFilters:
		case FilterType.Top10:
			method_5(new Class1194(filterColumn_0));
			break;
		}
	}

	[Attribute0(true)]
	private void method_5(Class1194 class1194_0)
	{
		int num = -1;
		int int_ = -1;
		string text = null;
		string text2 = null;
		if (!class1194_0.method_5())
		{
			if (class1194_0.filterOperatorType_0 != FilterOperatorType.None && class1194_0.object_1 != null && class1194_0.object_1 is string)
			{
				text = (string)class1194_0.object_1;
				if (text.Length > 0 && text[0] == '#')
				{
					string key;
					if ((key = text) != null)
					{
						if (Class1742.dictionary_224 == null)
						{
							Class1742.dictionary_224 = new Dictionary<string, int>(7)
							{
								{ "#DIV/0!", 0 },
								{ "#N/A", 1 },
								{ "#NAME?", 2 },
								{ "#NULL!", 3 },
								{ "#NUM!", 4 },
								{ "#REF!", 5 },
								{ "#VALUE!", 6 }
							};
						}
						if (Class1742.dictionary_224.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
								break;
							case 1:
								goto IL_010e;
							case 2:
								goto IL_0113;
							case 3:
								goto IL_0118;
							case 4:
								goto IL_011c;
							case 5:
								goto IL_0121;
							case 6:
								goto IL_0126;
							default:
								goto IL_012b;
							}
							num = 7;
							goto IL_015f;
						}
					}
					goto IL_012b;
				}
				method_0((short)(base.Length + (short)(2 * text.Length + 1)));
			}
			goto IL_015f;
		}
		goto IL_02ab;
		IL_02ab:
		byte_0 = new byte[base.Length];
		byte_0[0] = (byte)class1194_0.int_0;
		Array.Copy(BitConverter.GetBytes(class1194_0.ushort_0), 0, byte_0, 2, 2);
		if (class1194_0.method_5() && class1194_0.object_1 == null)
		{
			return;
		}
		if (class1194_0.object_1 == null)
		{
			byte_0[2] = 4;
			switch (class1194_0.filterOperatorType_0)
			{
			case FilterOperatorType.Equal:
				byte_0[4] = 12;
				break;
			case FilterOperatorType.NotEqual:
				byte_0[4] = 14;
				break;
			}
			byte_0[5] = 2;
			return;
		}
		if (class1194_0.filterOperatorType_0 != FilterOperatorType.None)
		{
			method_6(4, class1194_0.filterOperatorType_0, class1194_0.object_1, num);
		}
		if (class1194_0.filterOperatorType_1 != FilterOperatorType.None)
		{
			method_6(14, class1194_0.filterOperatorType_1, class1194_0.object_0, int_);
		}
		int num2 = 24;
		if (num == -1 && text != null)
		{
			byte_0[24] = 1;
			Array.Copy(Encoding.Unicode.GetBytes(text), 0, byte_0, 25, text.Length * 2);
			num2 += 1 + text.Length * 2;
		}
		if (num == -1 && text2 != null)
		{
			byte_0[num2] = 1;
			Array.Copy(Encoding.Unicode.GetBytes(text2), 0, byte_0, num2 + 1, text2.Length * 2);
			num2 += 1 + text2.Length * 2;
		}
		return;
		IL_012b:
		method_0((short)(base.Length + (short)(2 * text.Length + 1)));
		goto IL_015f;
		IL_0268:
		num = 36;
		goto IL_02ab;
		IL_015f:
		if (class1194_0.filterOperatorType_1 != FilterOperatorType.None && class1194_0.object_0 != null && class1194_0.object_0 is string)
		{
			text2 = (string)class1194_0.object_0;
			if (text2.Length > 0 && text2[0] == '#')
			{
				string key2;
				if ((key2 = text) != null)
				{
					if (Class1742.dictionary_225 == null)
					{
						Class1742.dictionary_225 = new Dictionary<string, int>(7)
						{
							{ "#DIV/0!", 0 },
							{ "#N/A", 1 },
							{ "#NAME?", 2 },
							{ "#NULL!", 3 },
							{ "#NUM!", 4 },
							{ "#REF!", 5 },
							{ "#VALUE!", 6 }
						};
					}
					if (Class1742.dictionary_225.TryGetValue(key2, out var value2))
					{
						switch (value2)
						{
						case 0:
							break;
						case 1:
							goto IL_025a;
						case 2:
							goto IL_025f;
						case 3:
							goto IL_0264;
						case 4:
							goto IL_0268;
						case 5:
							goto IL_026d;
						case 6:
							goto IL_0272;
						default:
							goto IL_0277;
						}
						num = 7;
						goto IL_02ab;
					}
				}
				goto IL_0277;
			}
			method_0((short)(base.Length + (short)(2 * text2.Length + 1)));
		}
		goto IL_02ab;
		IL_0272:
		num = 15;
		goto IL_02ab;
		IL_026d:
		num = 23;
		goto IL_02ab;
		IL_0264:
		num = 0;
		goto IL_02ab;
		IL_025a:
		num = 42;
		goto IL_02ab;
		IL_025f:
		num = 29;
		goto IL_02ab;
		IL_0277:
		method_0((short)(base.Length + (short)(2 * text2.Length + 1)));
		goto IL_02ab;
		IL_0126:
		num = 15;
		goto IL_015f;
		IL_0121:
		num = 23;
		goto IL_015f;
		IL_011c:
		num = 36;
		goto IL_015f;
		IL_0118:
		num = 0;
		goto IL_015f;
		IL_0113:
		num = 29;
		goto IL_015f;
		IL_010e:
		num = 42;
		goto IL_015f;
	}

	private void method_6(int int_0, FilterOperatorType filterOperatorType_0, object object_0, int int_1)
	{
		switch (filterOperatorType_0)
		{
		case FilterOperatorType.LessOrEqual:
			byte_0[int_0 + 1] = 3;
			break;
		case FilterOperatorType.LessThan:
			byte_0[int_0 + 1] = 1;
			break;
		case FilterOperatorType.Equal:
			byte_0[int_0 + 1] = 2;
			break;
		case FilterOperatorType.GreaterThan:
			byte_0[int_0 + 1] = 4;
			break;
		case FilterOperatorType.NotEqual:
			byte_0[int_0 + 1] = 5;
			break;
		case FilterOperatorType.GreaterOrEqual:
			byte_0[int_0 + 1] = 6;
			break;
		}
		if (int_1 != -1)
		{
			byte_0[int_0] = 8;
			byte_0[int_0 + 2] = (byte)int_1;
			byte_0[int_0 + 3] = 1;
			return;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Int32:
			byte_0[int_0] = 4;
			Array.Copy(BitConverter.GetBytes((double)(int)object_0), 0, byte_0, int_0 + 2, 8);
			break;
		case TypeCode.Boolean:
			byte_0[int_0] = 8;
			byte_0[int_0 + 2] = (byte)(((bool)object_0) ? 1u : 0u);
			break;
		case TypeCode.String:
			byte_0[int_0] = 6;
			byte_0[int_0 + 6] = (byte)((string)object_0).Length;
			break;
		case TypeCode.Double:
			byte_0[int_0] = 4;
			Array.Copy(BitConverter.GetBytes((double)object_0), 0, byte_0, int_0 + 2, 8);
			break;
		}
	}
}
