using System;
using System.Text;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns27;

internal class Class629 : Class538
{
	private int int_0 = 1048575;

	private int int_1 = 16383;

	private Worksheet worksheet_0;

	internal Class629(Worksheet worksheet_1)
	{
		method_2(446);
		worksheet_0 = worksheet_1;
	}

	internal bool method_4(Validation validation_0)
	{
		if (validation_0.method_0())
		{
			return false;
		}
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
			return false;
		}
		int num2 = 14 + num * 8;
		byte[] array = Class1677.smethod_15(validation_0.InputTitle);
		num2 += method_5(array);
		byte[] array2 = Class1677.smethod_15(validation_0.InputMessage);
		num2 += method_5(array2);
		byte[] array3 = Class1677.smethod_15(validation_0.ErrorTitle);
		num2 += method_5(array3);
		byte[] array4 = Class1677.smethod_15(validation_0.ErrorMessage);
		num2 += method_5(array4);
		byte[] array5 = null;
		if (validation_0.Type != 0 && ((validation_0.Formula1 != null && validation_0.Formula1 != "") || validation_0.method_7() != null))
		{
			array5 = validation_0.method_7();
		}
		if (array5 != null)
		{
			num2 += array5.Length;
		}
		byte[] array6 = null;
		if ((validation_0.Operator == OperatorType.Between || validation_0.Operator == OperatorType.NotBetween) && validation_0.Type != ValidationType.List && validation_0.Type != ValidationType.Custom && validation_0.Type != 0)
		{
			array6 = validation_0.method_9();
		}
		if (array6 != null)
		{
			num2 += array6.Length;
		}
		method_0((short)num2);
		byte_0 = new byte[num2];
		switch (validation_0.Type)
		{
		case ValidationType.WholeNumber:
			byte_0[0] = 1;
			break;
		case ValidationType.Decimal:
			byte_0[0] = 2;
			break;
		case ValidationType.List:
			byte_0[0] = 3;
			if (!validation_0.InCellDropDown)
			{
				byte_0[1] = 2;
			}
			if (array5 == null || array5.Length <= 0 || array5[0] != 23)
			{
				break;
			}
			if (array5[2] == 0)
			{
				if (array5.Length == array5[1] + 3)
				{
					byte_0[0] |= 128;
				}
			}
			else if (array5[2] == 1 && array5.Length == 2 * array5[1] + 3)
			{
				byte_0[0] |= 128;
			}
			break;
		case ValidationType.Date:
			byte_0[0] = 4;
			break;
		case ValidationType.Time:
			byte_0[0] = 5;
			break;
		case ValidationType.TextLength:
			byte_0[0] = 6;
			break;
		case ValidationType.Custom:
			byte_0[0] = 7;
			break;
		}
		switch (validation_0.AlertStyle)
		{
		case ValidationAlertType.Information:
			byte_0[0] |= 32;
			break;
		case ValidationAlertType.Warning:
			byte_0[0] |= 16;
			break;
		}
		if (validation_0.IgnoreBlank)
		{
			byte_0[1] |= 1;
		}
		if (validation_0.ShowInput)
		{
			byte_0[2] = 4;
		}
		if (validation_0.ShowError)
		{
			byte_0[2] |= 8;
		}
		switch (validation_0.Operator)
		{
		case OperatorType.Equal:
			byte_0[2] |= 32;
			break;
		case OperatorType.GreaterThan:
			byte_0[2] |= 64;
			break;
		case OperatorType.GreaterOrEqual:
			byte_0[2] |= 96;
			break;
		case OperatorType.LessThan:
			byte_0[2] |= 80;
			break;
		case OperatorType.LessOrEqual:
			byte_0[2] |= 112;
			break;
		case OperatorType.NotBetween:
			byte_0[2] |= 16;
			break;
		case OperatorType.NotEqual:
			byte_0[2] |= 48;
			break;
		}
		int num3 = 4;
		if (array == null)
		{
			byte_0[num3] = 1;
			num3 += 4;
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(validation_0.InputTitle.Length), 0, byte_0, num3, 2);
			if (validation_0.InputTitle.Length != array.Length)
			{
				byte_0[num3 + 2] = 1;
			}
			num3 += 3;
			Array.Copy(array, 0, byte_0, num3, array.Length);
			num3 += array.Length;
		}
		if (array3 == null)
		{
			byte_0[num3] = 1;
			num3 += 4;
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(validation_0.ErrorTitle.Length), 0, byte_0, num3, 2);
			if (validation_0.ErrorTitle.Length != array3.Length)
			{
				byte_0[num3 + 2] = 1;
			}
			num3 += 3;
			Array.Copy(array3, 0, byte_0, num3, array3.Length);
			num3 += array3.Length;
		}
		if (array2 == null)
		{
			byte_0[num3] = 1;
			num3 += 4;
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(validation_0.InputMessage.Length), 0, byte_0, num3, 2);
			if (validation_0.InputMessage.Length != array2.Length)
			{
				byte_0[num3 + 2] = 1;
			}
			num3 += 3;
			Array.Copy(array2, 0, byte_0, num3, array2.Length);
			num3 += array2.Length;
		}
		if (array4 == null)
		{
			byte_0[num3] = 1;
			num3 += 4;
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(validation_0.ErrorMessage.Length), 0, byte_0, num3, 2);
			if (validation_0.ErrorMessage.Length != array4.Length)
			{
				byte_0[num3 + 2] = 1;
			}
			num3 += 3;
			Array.Copy(array4, 0, byte_0, num3, array4.Length);
			num3 += array4.Length;
		}
		if (array5 == null)
		{
			num3 += 4;
		}
		else
		{
			Array.Copy(BitConverter.GetBytes((ushort)array5.Length), 0, byte_0, num3, 2);
			num3 += 4;
			Array.Copy(array5, 0, byte_0, num3, array5.Length);
			num3 += array5.Length;
		}
		if (array6 == null)
		{
			num3 += 4;
		}
		else
		{
			Array.Copy(BitConverter.GetBytes((ushort)array6.Length), 0, byte_0, num3, 2);
			num3 += 4;
			Array.Copy(array6, 0, byte_0, num3, array6.Length);
			num3 += array6.Length;
		}
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, num3, 2);
		num3 += 2;
		for (int j = 0; j < validation_0.AreaList.Count; j++)
		{
			if (validation_0.AreaList[j] is CellArea cellArea2)
			{
				Array.Copy(BitConverter.GetBytes((ushort)cellArea2.StartRow), 0, byte_0, num3, 2);
				num3 += 2;
				Array.Copy(BitConverter.GetBytes((ushort)cellArea2.EndRow), 0, byte_0, num3, 2);
				num3 += 2;
				byte_0[num3] = (byte)cellArea2.StartColumn;
				num3 += 2;
				byte_0[num3] = (byte)cellArea2.EndColumn;
				num3 += 2;
			}
		}
		return true;
	}

	private int method_5(byte[] byte_1)
	{
		if (byte_1 == null)
		{
			return 4;
		}
		return byte_1.Length + 3;
	}

	internal Validation method_6(byte[] byte_1)
	{
		Validation validation = new Validation(worksheet_0.Validations);
		switch (byte_1[0] & 0xF)
		{
		case 0:
			validation.Type = ValidationType.AnyValue;
			break;
		case 1:
			validation.Type = ValidationType.WholeNumber;
			break;
		case 2:
			validation.Type = ValidationType.Decimal;
			break;
		case 3:
			validation.Type = ValidationType.List;
			break;
		case 4:
			validation.Type = ValidationType.Date;
			break;
		case 5:
			validation.Type = ValidationType.Time;
			break;
		case 6:
			validation.Type = ValidationType.TextLength;
			break;
		case 7:
			validation.Type = ValidationType.Custom;
			break;
		}
		switch (byte_1[0] & 0x70)
		{
		case 32:
			validation.AlertStyle = ValidationAlertType.Information;
			break;
		case 16:
			validation.AlertStyle = ValidationAlertType.Warning;
			break;
		case 0:
			validation.AlertStyle = ValidationAlertType.Stop;
			break;
		}
		if (((uint)byte_1[1] & (true ? 1u : 0u)) != 0)
		{
			validation.IgnoreBlank = true;
		}
		else
		{
			validation.IgnoreBlank = false;
		}
		if ((byte_1[1] & 2) == 0)
		{
			validation.InCellDropDown = true;
		}
		else
		{
			validation.InCellDropDown = false;
		}
		switch (((byte_1[2] & 3) << 6) + ((byte_1[1] & 0xFC) >> 2))
		{
		default:
			validation.method_6(Enum228.const_0);
			break;
		case 0:
			validation.method_6(Enum228.const_0);
			break;
		case 1:
			validation.method_6(Enum228.const_1);
			break;
		case 2:
			validation.method_6(Enum228.const_2);
			break;
		case 3:
			validation.method_6(Enum228.const_3);
			break;
		case 4:
			validation.method_6(Enum228.const_4);
			break;
		case 5:
			validation.method_6(Enum228.const_5);
			break;
		case 6:
			validation.method_6(Enum228.const_6);
			break;
		case 7:
			validation.method_6(Enum228.const_7);
			break;
		case 8:
			validation.method_6(Enum228.const_8);
			break;
		case 9:
			validation.method_6(Enum228.const_9);
			break;
		case 10:
			validation.method_6(Enum228.const_10);
			break;
		}
		if ((byte_1[2] & 4) == 0)
		{
			validation.ShowInput = false;
		}
		else
		{
			validation.ShowInput = true;
		}
		if ((byte_1[2] & 8) == 0)
		{
			validation.ShowError = false;
		}
		else
		{
			validation.ShowError = true;
		}
		switch (byte_1[2] & 0xF0)
		{
		case 16:
			validation.Operator = OperatorType.NotBetween;
			break;
		case 0:
			validation.Operator = OperatorType.Between;
			break;
		case 48:
			validation.Operator = OperatorType.NotEqual;
			break;
		case 32:
			validation.Operator = OperatorType.Equal;
			break;
		case 80:
			validation.Operator = OperatorType.LessThan;
			break;
		case 64:
			validation.Operator = OperatorType.GreaterThan;
			break;
		case 112:
			validation.Operator = OperatorType.LessOrEqual;
			break;
		case 96:
			validation.Operator = OperatorType.GreaterOrEqual;
			break;
		}
		int int_ = 4;
		validation.InputTitle = method_7(byte_1, ref int_);
		validation.ErrorTitle = method_7(byte_1, ref int_);
		validation.InputMessage = method_7(byte_1, ref int_);
		validation.ErrorMessage = method_7(byte_1, ref int_);
		int num = byte_1[int_];
		int num2 = 0;
		int num3 = 0;
		num = BitConverter.ToUInt16(byte_1, int_);
		int_ += 4;
		if (num != 0)
		{
			validation.method_8(new byte[num]);
			Array.Copy(byte_1, int_, validation.method_7(), 0, num);
			int_ += num;
		}
		num = BitConverter.ToUInt16(byte_1, int_);
		int_ += 4;
		if (num != 0)
		{
			validation.method_10(new byte[num]);
			Array.Copy(byte_1, int_, validation.method_9(), 0, num);
			int_ += num;
		}
		ushort num4 = BitConverter.ToUInt16(byte_1, int_);
		if (num4 == 0)
		{
			return null;
		}
		num2 = (int_0 = BitConverter.ToUInt16(byte_1, int_ + 2));
		num3 = (int_1 = byte_1[int_ + 6]);
		if (validation.method_7() != null)
		{
			validation.method_2(Validation.smethod_2(worksheet_0.method_2(), validation.method_7(), 0, validation.Type, num2, num3));
		}
		if (validation.method_9() != null)
		{
			validation.method_3(Validation.smethod_2(worksheet_0.method_2(), validation.method_9(), 0, validation.Type, num2, num3));
		}
		int_ += 2;
		for (int i = 0; i < num4; i++)
		{
			CellArea range = GetRange(byte_1, int_);
			int_ += 8;
			validation.AreaList.Add(range);
		}
		return validation;
	}

	private CellArea GetRange(byte[] byte_1, int int_2)
	{
		CellArea result = default(CellArea);
		result.StartRow = BitConverter.ToUInt16(byte_1, int_2);
		int_2 += 2;
		result.EndRow = BitConverter.ToUInt16(byte_1, int_2);
		result.StartColumn = byte_1[int_2 + 2];
		result.EndColumn = byte_1[int_2 + 4];
		int_2 += 6;
		return result;
	}

	[Attribute0(true)]
	private string method_7(byte[] byte_1, ref int int_2)
	{
		ushort num = BitConverter.ToUInt16(byte_1, int_2);
		if (num == 0)
		{
			int_2 += 3;
			return null;
		}
		if (num != 0 && (num != 1 || byte_1[int_2 + 2] != 0 || byte_1[int_2 + 3] != 0))
		{
			int_2 += 2;
			if (byte_1[int_2] == 0)
			{
				byte[] array = new byte[2 * num];
				for (int i = 0; i < num; i++)
				{
					array[2 * i] = byte_1[int_2 + i + 1];
				}
				int_2 += num + 1;
				return Encoding.Unicode.GetString(array);
			}
			string @string = Encoding.Unicode.GetString(byte_1, int_2 + 1, 2 * num);
			int_2 += 2 * num + 1;
			return @string;
		}
		int_2 += 4;
		return null;
	}
}
