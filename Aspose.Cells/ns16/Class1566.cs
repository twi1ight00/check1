using System.Collections;
using Aspose.Cells;
using ns2;

namespace ns16;

internal class Class1566
{
	internal Class1567 class1567_0;

	internal ArrayList arrayList_0 = new ArrayList();

	internal static byte smethod_0(string string_0)
	{
		return string_0 switch
		{
			"topRight" => 1, 
			"topLeft" => 3, 
			"bottomRight" => 0, 
			"bottomLeft" => 2, 
			_ => 3, 
		};
	}

	internal static string smethod_1(byte byte_0)
	{
		return byte_0 switch
		{
			0 => "bottomRight", 
			1 => "topRight", 
			2 => "bottomLeft", 
			3 => "topLeft", 
			_ => "topLeft", 
		};
	}

	internal void method_0(Worksheet worksheet_0)
	{
		if (class1567_0 != null)
		{
			PaneCollection paneCollection = worksheet_0.method_1();
			switch (class1567_0.string_0.ToLower())
			{
			case "frozen":
			case "frozensplit":
				worksheet_0.method_14(bool_1: true);
				break;
			}
			paneCollection.method_1(smethod_0(class1567_0.string_2));
			if (class1567_0.string_1 != null)
			{
				CellsHelper.CellNameToIndex(class1567_0.string_1, out var row, out var column);
				paneCollection.method_2(row);
				paneCollection.method_3(column);
			}
			paneCollection.method_7((int)class1567_0.double_0);
			paneCollection.method_5((int)class1567_0.double_1);
		}
		if (arrayList_0 == null)
		{
			return;
		}
		Class1733 @class = new Class1733(worksheet_0);
		worksheet_0.method_35(@class);
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1568 class2 = (Class1568)arrayList_0[i];
			Class1732 class3 = new Class1732(smethod_0(class2.string_0));
			@class.Add(class3);
			string string_ = class2.string_2;
			if (string_ != null && string_.Length > 0)
			{
				int column;
				int row = (column = 0);
				if (class2.string_1 != null)
				{
					CellsHelper.CellNameToIndex(class2.string_1, out row, out column);
				}
				class3.method_6(row);
				class3.method_8(column);
				class3.method_10(class2.int_0);
				string[] array = string_.Split(' ');
				for (int j = 0; j < array.Length; j++)
				{
					string text = array[j].Trim();
					if (text.Length > 0)
					{
						CellArea cellArea = Class1618.smethod_17(text);
						class3.method_3().Add(cellArea);
					}
				}
			}
			else
			{
				class3.method_6(0);
				class3.method_8(0);
				class3.method_10(0);
				class3.method_3().Add(default(CellArea));
			}
		}
	}

	internal static Class1566 smethod_2(Worksheet worksheet_0)
	{
		Class1566 @class = new Class1566();
		if (worksheet_0.GetPanes() != null)
		{
			PaneCollection paneCollection = worksheet_0.method_1();
			Class1567 class2 = (@class.class1567_0 = new Class1567());
			class2.string_2 = smethod_1(paneCollection.method_0());
			class2.string_0 = (worksheet_0.method_13() ? "frozen" : "split");
			class2.string_1 = CellsHelper.CellIndexToName(paneCollection.Row, paneCollection.Column);
			class2.double_0 = paneCollection.method_6();
			class2.double_1 = paneCollection.method_4();
		}
		if (worksheet_0.method_34() != null && worksheet_0.method_34().Count != 0)
		{
			@class.arrayList_0 = new ArrayList();
			for (int i = 0; i < worksheet_0.method_34().Count; i++)
			{
				Class1732 class3 = (Class1732)worksheet_0.method_34()[i];
				Class1568 class4 = new Class1568();
				@class.arrayList_0.Add(class4);
				class4.string_1 = CellsHelper.CellIndexToName(class3.method_5(), class3.method_7());
				class4.int_0 = class3.method_9();
				class4.string_2 = Class1618.smethod_32(class3.method_3(), 0, class3.method_3().Count);
				class4.string_0 = smethod_1(class3.method_1());
			}
		}
		return @class;
	}
}
