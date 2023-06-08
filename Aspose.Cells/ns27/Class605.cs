using Aspose.Cells;

namespace ns27;

internal class Class605 : Class538
{
	internal Class605(SheetType sheetType_0, FileFormatType fileFormatType_1)
	{
		method_4(fileFormatType_1);
		method_5(sheetType_0);
		byte_0[13] = 3;
	}

	private void method_4(FileFormatType fileFormatType_1)
	{
		method_2(2057);
		method_0(16);
		byte_0 = new byte[16];
		byte_0[1] = 6;
		if (fileFormatType_1 == FileFormatType.Default)
		{
			byte_0[4] = 124;
			byte_0[5] = 32;
		}
		else
		{
			byte_0[4] = 23;
			byte_0[5] = 25;
		}
		byte_0[6] = 205;
		byte_0[7] = 7;
		byte_0[8] = 201;
		byte_0[9] = 192;
		byte_0[12] = 6;
		byte_0[13] = 4;
	}

	internal Class605(FileFormatType fileFormatType_1)
	{
		method_4(fileFormatType_1);
		byte_0[2] = 5;
		byte_0[3] = 0;
	}

	private void method_5(SheetType sheetType_0)
	{
		switch (sheetType_0)
		{
		default:
			byte_0[2] = 16;
			byte_0[3] = 0;
			break;
		case SheetType.Worksheet:
			byte_0[2] = 16;
			byte_0[3] = 0;
			break;
		case SheetType.Chart:
			byte_0[2] = 32;
			byte_0[3] = 0;
			break;
		case SheetType.BIFF4Macro:
			byte_0[2] = 64;
			byte_0[3] = 0;
			break;
		}
	}
}
