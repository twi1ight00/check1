using Aspose.Cells.Tables;
using ns10;

namespace ns9;

internal class Class388 : Class316
{
	internal Class388(ListObject listObject_0)
	{
		int_0 = 513;
		int num = 6;
		if (listObject_0.TableStyleName != null)
		{
			num += listObject_0.TableStyleName.Length * 2;
		}
		byte_0 = new byte[num];
		byte b = 0;
		if (listObject_0.ShowTableStyleFirstColumn)
		{
			b = (byte)(b | 1u);
		}
		if (listObject_0.ShowTableStyleLastColumn)
		{
			b = (byte)(b | 2u);
		}
		if (listObject_0.ShowTableStyleRowStripes)
		{
			b = (byte)(b | 4u);
		}
		if (listObject_0.ShowTableStyleColumnStripes)
		{
			b = (byte)(b | 8u);
		}
		byte_0[0] = b;
		int num2 = 2;
		if (listObject_0.TableStyleName != null)
		{
			Class1217.smethod_7(byte_0, ref num2, listObject_0.TableStyleName);
		}
	}
}
