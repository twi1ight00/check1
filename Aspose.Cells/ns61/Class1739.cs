using System;
using System.Globalization;
using System.Text;
using Aspose.Cells;
using ns12;
using ns2;

namespace ns61;

internal class Class1739
{
	private int int_0 = 1048575;

	private int int_1 = 16383;

	private Worksheet worksheet_0;

	private string string_0 = "Invalid formula in data validation settings.";

	internal int StartRow => int_0;

	internal int StartColumn => int_1;

	internal Class1739(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	internal void method_0(Validation validation_0)
	{
		if (validation_0.method_0())
		{
			return;
		}
		int_0 = 1048575;
		int_1 = 16383;
		int num = 0;
		for (int i = 0; i < validation_0.AreaList.Count; i++)
		{
			if (validation_0.AreaList[i] is CellArea cellArea)
			{
				if (cellArea.StartRow < int_0)
				{
					int_0 = cellArea.StartRow;
					int_1 = cellArea.StartColumn;
				}
				num++;
			}
		}
		if (num == 0)
		{
			return;
		}
		byte[] array = null;
		if (validation_0.Type != 0 && ((validation_0.Formula1 != null && validation_0.Formula1 != "") || validation_0.method_7() != null))
		{
			array = ((validation_0.method_7() != null) ? validation_0.method_7() : ((validation_0.Type == ValidationType.List || validation_0.Formula1[0] != '=') ? method_1(validation_0, 1) : worksheet_0.method_2().Formula.method_3(validation_0.Formula1, StartRow, StartColumn, Enum226.const_0, Enum227.const_0, bool_0: true, bool_1: false)));
			validation_0.method_8(array);
		}
		byte[] byte_ = null;
		if ((validation_0.Operator != 0 && validation_0.Operator != OperatorType.NotBetween) || validation_0.Type == ValidationType.List || validation_0.Type == ValidationType.Custom || validation_0.Type == ValidationType.AnyValue)
		{
			return;
		}
		if (validation_0.Type == ValidationType.Custom)
		{
			if (validation_0.method_9() != null)
			{
				byte_ = validation_0.method_9();
			}
		}
		else if (validation_0.method_9() != null)
		{
			byte_ = validation_0.method_9();
		}
		else if (validation_0.Formula2 != null)
		{
			byte_ = ((validation_0.Formula2[0] != '=') ? method_1(validation_0, 2) : worksheet_0.method_2().Formula.method_3(validation_0.Formula2, StartRow, StartColumn, Enum226.const_0, Enum227.const_1, bool_0: true, bool_1: false));
		}
		validation_0.method_10(byte_);
	}

	private byte[] method_1(Validation validation_0, int int_2)
	{
		string text = ((int_2 != 1) ? validation_0.Formula2 : validation_0.Formula1);
		if (text != null)
		{
			switch (text)
			{
			default:
				switch (validation_0.Type)
				{
				default:
					return null;
				case ValidationType.List:
					return method_2(text);
				case ValidationType.Date:
					return method_3(text, bool_0: false);
				case ValidationType.Time:
					return method_3(text, bool_0: true);
				case ValidationType.WholeNumber:
				case ValidationType.Decimal:
				case ValidationType.TextLength:
					return method_4(text);
				}
			case null:
			case "":
				throw new CellsException(ExceptionType.DataValidation, "You must enter data for validation criteria.");
			case "=#REF!":
				break;
			}
		}
		return new byte[13]
		{
			43, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0
		};
	}

	private byte[] method_2(string string_1)
	{
		byte[] array = null;
		if (string_1[0] == '=')
		{
			array = worksheet_0.method_2().Formula.method_3(string_1, StartRow, StartColumn, Enum226.const_0, Enum227.const_0, bool_0: true, bool_1: false);
		}
		else
		{
			string_1 = string_1.Replace(',', '\0');
			byte[] bytes = Encoding.Unicode.GetBytes(string_1);
			array = new byte[3 + bytes.Length];
			array[0] = 23;
			Array.Copy(BitConverter.GetBytes(string_1.Length), 0, array, 1, 2);
			Array.Copy(bytes, 0, array, 3, bytes.Length);
		}
		return array;
	}

	private byte[] method_3(string string_1, bool bool_0)
	{
		if (string_1 != null && string_1.Length != 0)
		{
			byte[] array = null;
			if (string_1[0] == '=')
			{
				string_1 = string_1.Substring(1).Trim().ToUpper();
				return worksheet_0.method_2().Formula.method_3(string_1, StartColumn, StartColumn, Enum226.const_0, Enum227.const_0, bool_0: true, bool_1: false);
			}
			try
			{
				DateTime dateTime = DateTime.Parse(string_1);
				double num = ((!bool_0) ? CellsHelper.GetDoubleFromDateTime(dateTime, worksheet_0.method_2().Workbook.Settings.Date1904) : ((double)(dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second) / 86400.0));
				if (Math.Abs(num - (double)(int)num) < double.Epsilon)
				{
					int num2 = (int)num;
					if (num2 <= 65535 && num2 >= 0)
					{
						array = new byte[3] { 30, 0, 0 };
						Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, 1, 2);
					}
					else
					{
						array = new byte[9] { 31, 0, 0, 0, 0, 0, 0, 0, 0 };
						Array.Copy(BitConverter.GetBytes(num), 0, array, 1, 8);
					}
				}
				else
				{
					array = new byte[9] { 31, 0, 0, 0, 0, 0, 0, 0, 0 };
					Array.Copy(BitConverter.GetBytes(num), 0, array, 1, 8);
				}
			}
			catch
			{
				throw new CellsException(ExceptionType.InvalidData, string_0);
			}
			return array;
		}
		return null;
	}

	private byte[] method_4(string string_1)
	{
		byte[] array = null;
		if (string_1[0] == '=')
		{
			return worksheet_0.method_2().Formula.method_3(string_1, StartRow, StartColumn, Enum226.const_0, Enum227.const_1, bool_0: true, bool_1: false);
		}
		if (!Class1677.smethod_19(string_1))
		{
			throw new CellsException(ExceptionType.DataValidation, string_0);
		}
		double num = double.Parse(string_1, CultureInfo.InvariantCulture);
		if (Math.Abs(num - (double)(int)num) < double.Epsilon)
		{
			int num2 = (int)num;
			if (num2 <= 65535 && num2 >= 0)
			{
				array = new byte[3] { 30, 0, 0 };
				Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, 1, 2);
			}
			else
			{
				array = new byte[9] { 31, 0, 0, 0, 0, 0, 0, 0, 0 };
				Array.Copy(BitConverter.GetBytes(num), 0, array, 1, 8);
			}
		}
		else
		{
			array = new byte[9] { 31, 0, 0, 0, 0, 0, 0, 0, 0 };
			Array.Copy(BitConverter.GetBytes(num), 0, array, 1, 8);
		}
		return array;
	}
}
