using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns2;
using ns21;
using ns59;
using ns7;

namespace ns52;

internal class Class1709
{
	private Class1730 class1730_0;

	private byte[] byte_0;

	private Class1723 class1723_0;

	private ushort ushort_0;

	private byte[] byte_1;

	private ushort ushort_1;

	private WorksheetCollection worksheetCollection_0;

	private Worksheet worksheet_0;

	private ShapeCollection shapeCollection_0;

	private object object_0;

	private bool bool_0;

	private Range range_0;

	private ArrayList arrayList_0;

	internal Class1709(Class1730 class1730_1, Class1723 class1723_1, WorksheetCollection worksheetCollection_1, Worksheet worksheet_1, object object_1)
	{
		class1730_0 = class1730_1;
		class1723_0 = class1723_1;
		byte_0 = new byte[2];
		worksheet_0 = worksheet_1;
		worksheetCollection_0 = worksheetCollection_1;
		object_0 = object_1;
	}

	[SpecialName]
	internal bool method_0()
	{
		return object_0 is Chart;
	}

	internal void method_1()
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		class1723_0.method_3(-2);
		bool_0 = false;
		range_0 = null;
		if (!method_0())
		{
			Name name = worksheetCollection_0.Names["_FilterDatabase", worksheet_0.Index];
			if (name != null)
			{
				range_0 = name.GetRange();
				if (range_0 != null)
				{
					bool_0 = true;
				}
			}
		}
		Shape shape = null;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 60:
			case 236:
			{
				method_20();
				int num4 = 0;
				if (byte_1[2] == 2 && byte_1[3] == 240)
				{
					int num5 = BitConverter.ToInt16(byte_1, num4 + 8) >> 4;
					shapeCollection_0 = new ShapeCollection(worksheetCollection_0, worksheet_0, worksheetCollection_0.method_84(), object_0, num5);
					if (num5 > worksheetCollection_0.method_84().method_2().method_2())
					{
						worksheetCollection_0.method_84().method_2().method_3((ushort)num5);
					}
					method_19(shapeCollection_0);
					num4 += 16;
					shapeCollection_0.method_4().method_2().method_2(BitConverter.ToInt32(byte_1, num4));
					shapeCollection_0.method_4().method_2().method_4(BitConverter.ToInt32(byte_1, num4 + 4));
					num4 += 8;
					byte[] array = null;
					ushort num6 = 0;
					do
					{
						num6 = BitConverter.ToUInt16(byte_1, num4 + 2);
						ushort num7 = num6;
						if (num7 == 61443)
						{
							num4 += 8;
							num4 += 8 + BitConverter.ToInt32(byte_1, num4 + 4);
						}
						else if (num7 != 61720)
						{
							if (num7 == 61728)
							{
								array = new byte[8 + BitConverter.ToInt32(byte_1, num4 + 4)];
								Array.Copy(byte_1, num4, array, 0, array.Length);
								shapeCollection_0.method_4().method_3().byte_0 = array;
								num4 += array.Length;
							}
						}
						else
						{
							num4 += 8 + BitConverter.ToInt32(byte_1, num4 + 4);
						}
					}
					while (num6 != 61443 && num4 < ushort_1);
				}
				if (num4 >= ushort_1)
				{
					break;
				}
				if (shapeCollection_0 == null)
				{
					shapeCollection_0 = worksheet_0.Shapes;
				}
				if (byte_1[num4 + 2] != 5 || byte_1[num4 + 3] != 240)
				{
					byte[] array2 = new byte[ushort_1 - num4];
					Array.Copy(byte_1, num4, array2, 0, ushort_1 - num4);
					ushort_0 = class1723_0.method_2(byte_0);
					while (ushort_0 == 60 || ushort_0 == 236)
					{
						method_20();
						byte[] array3 = new byte[array2.Length + ushort_1];
						Array.Copy(array2, 0, array3, 0, array2.Length);
						Array.Copy(byte_1, 0, array3, array2.Length, ushort_1);
						array2 = array3;
						ushort_0 = class1723_0.method_2(byte_0);
					}
					if (ushort_0 == 93)
					{
						method_20();
						shape = method_2(array2, 0, method_4(byte_1[4]));
						if (shape != null)
						{
							shapeCollection_0.method_32(shape, null);
							method_3(shape);
						}
						break;
					}
					class1723_0.method_3(-2);
					return;
				}
				int num8 = BitConverter.ToInt32(byte_1, num4 + 4) + 8;
				if (num8 != 0)
				{
					byte[] byte_ = new byte[num8];
					method_17(0, num4, byte_, 0, num8);
					shapeCollection_0.method_4().method_6().byte_0 = byte_;
				}
				return;
			}
			case 127:
			{
				method_20();
				int num = BitConverter.ToInt32(byte_1, 4);
				int num2 = num - (ushort_1 - 4);
				while (num2 > 0)
				{
					ushort_0 = class1723_0.method_2(byte_0);
					int num3 = class1723_0.method_2(byte_0);
					class1723_0.method_3(num3);
					num2 -= num3;
				}
				break;
			}
			default:
				class1723_0.method_3(-2);
				return;
			}
		}
	}

	private Shape method_2(byte[] byte_2, int int_0, MsoDrawingType msoDrawingType_0)
	{
		Shape shape = null;
		switch (msoDrawingType_0)
		{
		case MsoDrawingType.Group:
		{
			GroupShape groupShape = new GroupShape(shapeCollection_0);
			shape = groupShape;
			shape = method_14(out var _, shape, byte_2, 0, byte_1);
			break;
		}
		case MsoDrawingType.Line:
		{
			LineShape lineShape = new LineShape(shapeCollection_0);
			shape = lineShape;
			shape = method_14(out var _, shape, byte_2, 0, byte_1);
			break;
		}
		case MsoDrawingType.Rectangle:
		{
			RectangleShape rectangleShape = new RectangleShape(shapeCollection_0);
			shape = rectangleShape;
			shape = method_14(out var remain8, shape, byte_2, 0, byte_1);
			if (remain8 != 0)
			{
				method_16(shape, rectangleShape.method_63(), bool_1: true);
			}
			break;
		}
		case MsoDrawingType.Oval:
		{
			Oval oval = new Oval(shapeCollection_0);
			shape = oval;
			shape = method_14(out var remain10, shape, byte_2, 0, byte_1);
			if (remain10 != 0)
			{
				method_15(shape);
			}
			break;
		}
		case MsoDrawingType.Arc:
		{
			ArcShape arcShape = new ArcShape(shapeCollection_0);
			shape = arcShape;
			shape = method_14(out var remain7, shape, byte_2, 0, byte_1);
			if (remain7 != 0)
			{
				method_16(shape, arcShape.method_63(), bool_1: true);
			}
			break;
		}
		case MsoDrawingType.Chart:
		{
			Chart chart = new Chart(worksheetCollection_0[worksheet_0.SheetIndex], shapeCollection_0);
			if (!method_0())
			{
				worksheet_0.Charts.Add(chart);
			}
			shape = chart.ChartObject;
			shape = method_14(out var _, shape, byte_2, 0, byte_1);
			Class1389 class3 = new Class1389(class1730_0, class1723_0, worksheetCollection_0, worksheet_0);
			class3.method_0(chart);
			break;
		}
		case MsoDrawingType.TextBox:
		{
			TextBox textBox = new TextBox(shapeCollection_0);
			if (!method_0())
			{
				worksheet_0.TextBoxes.Add(textBox);
			}
			shape = textBox;
			int remain13 = 0;
			shape = method_14(out remain13, shape, byte_2, 0, byte_1);
			if (remain13 > 0)
			{
				method_16(shape, textBox.method_63(), bool_1: true);
			}
			break;
		}
		case MsoDrawingType.Button:
		{
			Button button = new Button(shapeCollection_0);
			shape = button;
			int remain12 = 0;
			shape = method_14(out remain12, shape, byte_2, 0, byte_1);
			method_16(shape, button.method_63(), bool_1: true);
			break;
		}
		case MsoDrawingType.Picture:
		{
			Picture picture = new Picture(shapeCollection_0);
			shape = picture;
			int remain6 = 0;
			shape = method_14(out remain6, shape, byte_2, 0, byte_1);
			method_8(picture);
			if (method_6(shape))
			{
				OleObject oleObject = new OleObject(shapeCollection_0);
				CopyOptions copyOptions_ = new CopyOptions(bool_6: true);
				oleObject.Copy(shape, copyOptions_);
				oleObject.method_24(shape.method_23());
				shape = oleObject;
				if (!method_0())
				{
					worksheet_0.OleObjects.Add(oleObject);
				}
				oleObject.method_70(bool_6: true);
				method_7(oleObject);
			}
			else if (!method_0())
			{
				worksheet_0.Pictures.Add(picture);
			}
			break;
		}
		case MsoDrawingType.Polygon:
		{
			Class1347 class2 = new Class1347(shapeCollection_0);
			shape = class2;
			shape = method_14(out var _, shape, byte_2, 0, byte_1);
			break;
		}
		case MsoDrawingType.CheckBox:
		{
			CheckBox checkBox = new CheckBox(shapeCollection_0);
			if (!method_0())
			{
				worksheet_0.CheckBoxes.Add(checkBox);
			}
			shape = checkBox;
			int remain20 = 0;
			shape = method_14(out remain20, shape, byte_2, 0, byte_1);
			method_16(shape, checkBox.method_63(), bool_1: true);
			method_9(checkBox);
			break;
		}
		case MsoDrawingType.RadioButton:
		{
			RadioButton radioButton = new RadioButton(shapeCollection_0);
			shape = radioButton;
			int remain19 = 0;
			shape = method_14(out remain19, shape, byte_2, 0, byte_1);
			method_16(shape, radioButton.method_63(), bool_1: true);
			method_10(radioButton);
			break;
		}
		case MsoDrawingType.Label:
		{
			Label label = new Label(shapeCollection_0);
			shape = label;
			int remain18 = 0;
			shape = method_14(out remain18, shape, byte_2, 0, byte_1);
			method_16(shape, label.method_63(), bool_1: true);
			break;
		}
		case MsoDrawingType.Spinner:
		{
			Spinner spinner = new Spinner(shapeCollection_0);
			shape = spinner;
			int remain17 = 0;
			shape = method_14(out remain17, shape, byte_2, 0, byte_1);
			break;
		}
		case MsoDrawingType.ScrollBar:
		{
			ScrollBar scrollBar = new ScrollBar(shapeCollection_0);
			shape = scrollBar;
			int remain16 = 0;
			shape = method_14(out remain16, shape, byte_2, 0, byte_1);
			break;
		}
		case MsoDrawingType.ListBox:
		{
			ListBox listBox = new ListBox(shapeCollection_0);
			shape = listBox;
			int remain15 = 0;
			shape = method_14(out remain15, shape, byte_2, 0, byte_1);
			method_12(listBox);
			break;
		}
		case MsoDrawingType.GroupBox:
		{
			GroupBox groupBox = new GroupBox(shapeCollection_0);
			shape = groupBox;
			int remain14 = 0;
			shape = method_14(out remain14, shape, byte_2, 0, byte_1);
			method_16(shape, groupBox.method_63(), bool_1: true);
			break;
		}
		case MsoDrawingType.ComboBox:
		{
			ComboBox comboBox = new ComboBox(shapeCollection_0);
			shape = comboBox;
			int remain4 = 0;
			shape = method_14(out remain4, shape, byte_2, 0, byte_1);
			if (range_0 != null && bool_0 && arrayList_0.Count == 0)
			{
				Class1698 @class = shape.method_27().method_7();
				if (@class.method_5() == range_0.Area.StartRow && @class.method_9() == range_0.Area.StartRow + 1 && @class.method_11() - @class.method_7() >= 1 && @class.method_11() <= range_0.Area.EndColumn + 1 && @class.method_7() >= range_0.Area.StartColumn)
				{
					return null;
				}
			}
			method_11(comboBox);
			break;
		}
		case MsoDrawingType.Comment:
		{
			Comment comment = new Comment(worksheet_0.Comments);
			worksheet_0.Comments.Add(comment);
			shape = comment.CommentShape;
			shape = method_14(out var _, shape, byte_2, 0, byte_1);
			method_16(shape, comment.method_2(), bool_1: true);
			break;
		}
		default:
			shape = new Shape(shapeCollection_0, msoDrawingType_0, shapeCollection_0);
			break;
		case MsoDrawingType.CellsDrawing:
		{
			CellsDrawing cellsDrawing = new CellsDrawing(shapeCollection_0);
			shape = cellsDrawing;
			shape = method_14(out var remain, shape, byte_2, 0, byte_1);
			if (remain != 0)
			{
				method_15(shape);
			}
			break;
		}
		}
		return shape;
	}

	private void method_3(Shape shape_0)
	{
		if (arrayList_0.Count == 0)
		{
			return;
		}
		int num = arrayList_0.Count;
		if (shape_0.MsoDrawingType == MsoDrawingType.Group)
		{
			num--;
			if (num > 0)
			{
				((GroupShape)arrayList_0[num - 1]).Add(shape_0);
			}
		}
		else
		{
			((GroupShape)arrayList_0[num - 1]).Add(shape_0);
		}
		int num2 = num - 1;
		while (num2 >= 0 && ((GroupShape)arrayList_0[num2]).method_70() == 0)
		{
			GroupShape groupShape = (GroupShape)arrayList_0[num2];
			ArrayList arrayList = groupShape.method_73();
			bool flag = false;
			double num3 = 1.0;
			double num4 = 1.0;
			if (!groupShape.method_33() && groupShape.Width != 0 && groupShape.Height != 0)
			{
				int num5 = groupShape.method_69().int_1 + groupShape.method_69().int_0;
				int num6 = groupShape.method_69().int_3 + groupShape.method_69().int_2;
				for (int i = 0; i < arrayList.Count; i++)
				{
					Shape shape = (Shape)arrayList[i];
					int num7 = shape.method_27().method_7().Right + shape.method_27().method_7().Left;
					if (num7 > num5)
					{
						num5 = num7;
					}
					int num8 = shape.method_27().method_7().Bottom + shape.method_27().method_7().Top;
					if (num8 > num6)
					{
						num6 = num8;
					}
				}
				if (flag = num5 > groupShape.method_69().int_1 + groupShape.method_69().int_0 + 10 || num6 > groupShape.method_69().int_3 + groupShape.method_69().int_2 + 10)
				{
					double num9 = num5 - groupShape.method_69().int_0;
					num3 = num9 / (double)groupShape.method_69().int_1;
					double num10 = num6 - groupShape.method_69().int_2;
					num4 = num10 / (double)groupShape.method_69().int_3;
					groupShape.method_69().int_1 = num5 - groupShape.method_69().int_0;
					groupShape.method_69().int_3 = num6 - groupShape.method_69().int_2;
				}
			}
			for (int j = 0; j < arrayList.Count; j++)
			{
				Shape shape2 = (Shape)arrayList[j];
				shape2.method_27().method_7().Left = (int)((double)(shape2.method_27().method_7().Left - groupShape.method_69().int_0) / (double)groupShape.method_69().int_1 * 4000.0 + 0.5);
				if (shape2.method_27().method_7().Left < 0)
				{
					shape2.method_27().method_7().Left = 0;
				}
				shape2.method_27().method_7().Top = (int)((double)(shape2.method_27().method_7().Top - groupShape.method_69().int_2) / (double)groupShape.method_69().int_3 * 4000.0 + 0.5);
				shape2.method_27().method_7().Right = (int)((double)shape2.method_27().method_7().Right / (double)groupShape.method_69().int_1 * 4000.0 + 0.5);
				shape2.method_27().method_7().Bottom = (int)((double)shape2.method_27().method_7().Bottom / (double)groupShape.method_69().int_3 * 4000.0 + 0.5);
			}
			if (flag && !groupShape.method_33())
			{
				groupShape.Width = (int)((double)groupShape.Width * num3);
				groupShape.Height = (int)((double)groupShape.Height * num4);
			}
			arrayList_0.RemoveAt(num2);
			num2--;
		}
	}

	internal MsoDrawingType method_4(byte byte_2)
	{
		switch (byte_2)
		{
		case 0:
			return MsoDrawingType.Group;
		case 1:
			return MsoDrawingType.Line;
		case 2:
			return MsoDrawingType.Rectangle;
		case 3:
			return MsoDrawingType.Oval;
		case 4:
			return MsoDrawingType.Arc;
		case 5:
			return MsoDrawingType.Chart;
		case 7:
			return MsoDrawingType.Button;
		case 8:
			return MsoDrawingType.Picture;
		case 9:
			return MsoDrawingType.Polygon;
		case 11:
			return MsoDrawingType.CheckBox;
		case 12:
			return MsoDrawingType.RadioButton;
		case 6:
		case 13:
			return MsoDrawingType.TextBox;
		case 14:
			return MsoDrawingType.Label;
		case 15:
			return MsoDrawingType.DialogBox;
		case 16:
			return MsoDrawingType.Spinner;
		case 17:
			return MsoDrawingType.ScrollBar;
		case 18:
			return MsoDrawingType.ListBox;
		case 19:
			return MsoDrawingType.GroupBox;
		case 20:
			return MsoDrawingType.ComboBox;
		case 25:
			return MsoDrawingType.Comment;
		default:
			throw new ArgumentException("Unsupported mso drawing type.");
		case 29:
			return MsoDrawingType.Unknown;
		case 30:
			return MsoDrawingType.CellsDrawing;
		}
	}

	internal ArrayList method_5(byte[] byte_2, int int_0)
	{
		ArrayList arrayList = new ArrayList();
		byte[] array = null;
		int num = 0;
		while (true)
		{
			if (int_0 < byte_2.Length)
			{
				byte b = byte_2[int_0];
				if (b != 19)
				{
					if (int_0 + 2 >= byte_2.Length)
					{
						break;
					}
					num = BitConverter.ToUInt16(byte_2, int_0 + 2);
					array = new byte[num + 4];
					Array.Copy(byte_2, int_0, array, 0, array.Length);
					arrayList.Add(array);
					int_0 += array.Length;
					continue;
				}
				num = BitConverter.ToUInt16(byte_2, int_0 + 2);
				int num2 = byte_2.Length - int_0;
				if (num != 0 && num + 4 < num2 && num + int_0 + 4 == byte_2.Length - 1)
				{
					ArrayList arrayList2 = new ArrayList();
					while (true)
					{
						ushort_0 = class1723_0.method_2(byte_0);
						if (ushort_0 == 60)
						{
							method_20();
							if (ushort_1 <= 4 || byte_1[0] != 15 || byte_1[1] != 0 || (byte_1[2] != 4 && byte_1[2] != 2) || byte_1[3] != 240)
							{
								arrayList2.Add(byte_1);
								num2 += ushort_1;
								continue;
							}
							class1723_0.method_3(-(ushort_1 + 4));
							break;
						}
						class1723_0.method_3(-2);
						break;
					}
					array = new byte[num2];
					Array.Copy(byte_2, int_0, array, 0, byte_2.Length - int_0);
					num2 = byte_2.Length - int_0;
					for (int i = 0; i < arrayList2.Count; i++)
					{
						byte[] array2 = (byte[])arrayList2[i];
						Array.Copy(array2, 0, array, num2, array2.Length);
						num2 += array2.Length;
					}
					arrayList.Add(array);
				}
				else
				{
					array = new byte[byte_2.Length - int_0];
					Array.Copy(byte_2, int_0, array, 0, array.Length);
					arrayList.Add(array);
				}
				return arrayList;
			}
			return arrayList;
		}
		return arrayList;
	}

	internal bool method_6(Shape shape_0)
	{
		ArrayList arrayList = shape_0.method_28().arrayList_0;
		bool result = false;
		if (arrayList != null && arrayList.Count != 0)
		{
			int num = 0;
			byte[] array;
			while (true)
			{
				if (num < arrayList.Count)
				{
					array = (byte[])arrayList[num];
					if (array[0] == 9)
					{
						break;
					}
					if (array[0] == 8 && array.Length > 4)
					{
						result = (array[4] & 2) != 0;
					}
					num++;
					continue;
				}
				return false;
			}
			int num2 = BitConverter.ToUInt16(array, 2);
			int num3 = BitConverter.ToUInt16(array, 4) + 2;
			if (num2 - num3 == 4)
			{
				return true;
			}
			return result;
		}
		return false;
	}

	internal void method_7(OleObject oleObject_0)
	{
		ArrayList arrayList = oleObject_0.method_28().arrayList_0;
		if (arrayList == null || arrayList.Count == 0)
		{
			return;
		}
		ArrayList arrayList2 = new ArrayList();
		byte[] array = null;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < arrayList.Count)
			{
				array = (byte[])arrayList[num2];
				switch (array[0])
				{
				default:
					arrayList2.Add(array);
					break;
				case 8:
					oleObject_0.method_72(array[4]);
					switch (oleObject_0.method_71())
					{
					default:
						return;
					case 0:
					case 1:
					case 3:
					case 5:
					case 8:
					case 9:
						break;
					case 2:
					case 4:
					case 6:
					case 7:
						return;
					}
					break;
				case 9:
				{
					num = 2;
					int num3 = BitConverter.ToUInt16(array, 2);
					switch (oleObject_0.method_71())
					{
					case 3:
					{
						int num6 = BitConverter.ToUInt16(array, num + 2);
						if (num6 + 2 != num3)
						{
							if (num6 + 6 == num3)
							{
								int num7 = BitConverter.ToUInt16(array, num + 2);
								num = 18;
								int num8 = BitConverter.ToUInt16(array, 18);
								if (array[18 + 2] == 0)
								{
									oleObject_0.ProgID = Class937.smethod_3(array, num + 3, num8);
								}
								else
								{
									oleObject_0.ProgID = Encoding.Unicode.GetString(array, num + 3, num8 * 2);
								}
								num = num7 + 6;
								oleObject_0.method_98(BitConverter.ToInt32(array, num));
								break;
							}
							return;
						}
						int num9 = BitConverter.ToInt16(array, 13);
						int num10 = BitConverter.ToInt32(array, 15);
						Class1303 @class = worksheetCollection_0.method_39();
						if (@class != null && @class.Count != 0 && num9 < @class.Count && num9 < @class.Count && num9 >= 0)
						{
							Class1718 class2 = @class[num9];
							if (class2.method_25() != null)
							{
								string progId = null;
								string fileName = null;
								class2.method_20(out progId, out fileName);
								oleObject_0.ProgID = progId;
								oleObject_0.method_88(fileName, bool_6: true, bool_7: false);
								oleObject_0.method_90(num9);
							}
							Class1653 class3 = (Class1653)class2.method_0()[num10 - 1];
							oleObject_0.method_98(class3.method_3());
						}
						return;
					}
					case 0:
					case 1:
					case 5:
					case 8:
					case 9:
					{
						int num4 = BitConverter.ToUInt16(array, num + 2);
						num = 18;
						int num5 = BitConverter.ToUInt16(array, 18);
						if (array[18 + 2] == 0)
						{
							oleObject_0.ProgID = Class937.smethod_3(array, num + 3, num5);
						}
						else
						{
							oleObject_0.ProgID = Encoding.Unicode.GetString(array, num + 3, num5 * 2);
						}
						num = num4 + 6;
						oleObject_0.method_98(BitConverter.ToInt32(array, num));
						break;
					}
					}
					break;
				}
				case 0:
				case 7:
					break;
				}
				num2++;
				continue;
			}
			if (arrayList2.Count > 0)
			{
				oleObject_0.method_28().arrayList_0 = arrayList2;
			}
			else
			{
				oleObject_0.method_28().arrayList_0 = null;
			}
			break;
		}
	}

	internal void method_8(Picture picture_0)
	{
		ArrayList arrayList = picture_0.method_28().arrayList_0;
		if (arrayList == null || arrayList.Count == 0)
		{
			return;
		}
		byte[] array = null;
		for (int i = 0; i < arrayList.Count; i++)
		{
			array = (byte[])arrayList[i];
			switch (array[0])
			{
			case 8:
				if (array[2] == 2)
				{
					picture_0.method_76(array[4]);
					switch (picture_0.method_75())
					{
					case 0:
					case 1:
					case 3:
					case 8:
					case 9:
						break;
					default:
						return;
					}
				}
				break;
			case 9:
				if (BitConverter.ToUInt16(array, 4) != 0)
				{
					int int_ = BitConverter.ToUInt16(array, 6);
					picture_0.method_66(worksheetCollection_0.method_4().method_4(12, int_, array, 0, 0, bool_0: false));
					if (picture_0.method_65() != null && picture_0.method_65().StartsWith("="))
					{
						picture_0.method_66(picture_0.method_65().Substring(1));
					}
				}
				break;
			}
		}
	}

	internal void method_9(CheckBox checkBox_0)
	{
		ArrayList arrayList = checkBox_0.method_28().arrayList_0;
		if (arrayList == null || arrayList.Count == 0)
		{
			return;
		}
		ArrayList arrayList2 = new ArrayList();
		byte[] array = null;
		for (int num = arrayList.Count - 1; num >= 0; num--)
		{
			array = (byte[])arrayList[num];
			switch (array[0])
			{
			default:
				arrayList2.Add(array);
				break;
			case 20:
			{
				int num2 = array[4];
				byte[] destinationArray = new byte[num2];
				Array.Copy(array, 10, destinationArray, 0, num2);
				checkBox_0.method_59(destinationArray);
				break;
			}
			case 10:
			case 18:
				switch (array[4])
				{
				case 0:
					checkBox_0.method_69(CheckValueType.UnChecked);
					break;
				case 1:
					checkBox_0.method_69(CheckValueType.Checked);
					break;
				case 2:
					checkBox_0.method_69(CheckValueType.Mixed);
					break;
				}
				if (array[0] == 18)
				{
					checkBox_0.Shadow = (array[10] & 1) == 0;
				}
				break;
			case 0:
				break;
			}
		}
		if (arrayList2.Count > 0)
		{
			checkBox_0.method_28().arrayList_0 = arrayList2;
		}
		else
		{
			checkBox_0.method_28().arrayList_0 = null;
		}
	}

	internal void method_10(RadioButton radioButton_0)
	{
		ArrayList arrayList = radioButton_0.method_28().arrayList_0;
		if (arrayList == null || arrayList.Count == 0)
		{
			return;
		}
		ArrayList arrayList2 = new ArrayList();
		byte[] array = null;
		for (int num = arrayList.Count - 1; num >= 0; num--)
		{
			array = (byte[])arrayList[num];
			switch (array[0])
			{
			default:
				arrayList2.Add(array);
				break;
			case 20:
			{
				int num2 = array[4];
				byte[] destinationArray = new byte[num2];
				Array.Copy(array, 10, destinationArray, 0, num2);
				radioButton_0.method_59(destinationArray);
				break;
			}
			case 10:
			case 18:
				radioButton_0.method_69(array[4] == 1);
				if (array[0] == 18)
				{
					radioButton_0.Shadow = (array[10] & 1) == 0;
				}
				break;
			case 0:
			case 11:
			case 17:
				break;
			}
		}
		if (arrayList2.Count > 0)
		{
			radioButton_0.method_28().arrayList_0 = arrayList2;
		}
		else
		{
			radioButton_0.method_28().arrayList_0 = null;
		}
	}

	internal void method_11(ComboBox comboBox_0)
	{
		if (comboBox_0.method_27().method_7().method_0())
		{
			return;
		}
		ArrayList arrayList = comboBox_0.method_28().arrayList_0;
		if (arrayList == null || arrayList.Count == 0)
		{
			return;
		}
		ArrayList arrayList2 = new ArrayList();
		byte[] array = null;
		int num = 0;
		int num2 = 0;
		for (int num3 = arrayList.Count - 1; num3 >= 0; num3--)
		{
			array = (byte[])arrayList[num3];
			switch (array[0])
			{
			case 19:
			{
				num = 4;
				int num4 = BitConverter.ToUInt16(array, 4);
				num2 = array[4 + 2];
				num = 4 + 2;
				if (num4 != 0)
				{
					byte[] destinationArray2 = new byte[num2];
					Array.Copy(array, num + 6, destinationArray2, 0, num2);
					comboBox_0.method_71(destinationArray2);
					num += num4;
				}
				num += 2;
				int num5 = BitConverter.ToUInt16(array, num) - 1;
				if (num5 >= 0)
				{
					comboBox_0.method_73(num5);
				}
				comboBox_0.Shadow = (array[num + 2] & 8) == 0;
				bool flag = (array[num + 2] & 2) != 0;
				num += 6;
				comboBox_0.DropDownLines = BitConverter.ToUInt16(array, num + 2);
				num += 6;
				num += 4;
				if (!flag || num4 != 0 || num2 == 0 || num >= array.Length)
				{
					break;
				}
				ArrayList arrayList3 = new ArrayList();
				for (int i = 0; i < num2; i++)
				{
					if (num >= array.Length)
					{
						break;
					}
					num4 = BitConverter.ToUInt16(array, num);
					if (array[num + 2] == 0)
					{
						arrayList3.Add(Encoding.ASCII.GetString(array, num + 3, num4));
						num += 3 + num4;
					}
					else
					{
						arrayList3.Add(Encoding.Unicode.GetString(array, num + 3, num4 * 2));
						num += 3 + num4 * 2;
					}
				}
				comboBox_0.string_4 = new string[arrayList3.Count];
				for (int j = 0; j < arrayList3.Count; j++)
				{
					comboBox_0.string_4[j] = (string)arrayList3[j];
				}
				break;
			}
			default:
				arrayList2.Add(array);
				break;
			case 14:
			{
				num = 4;
				num2 = BitConverter.ToUInt16(array, 4);
				num = 4 + 6;
				byte[] destinationArray = new byte[num2];
				Array.Copy(array, 10, destinationArray, 0, num2);
				comboBox_0.method_59(destinationArray);
				break;
			}
			case 0:
			case 12:
				break;
			}
		}
		if (arrayList2.Count > 0)
		{
			comboBox_0.method_28().arrayList_0 = arrayList2;
		}
		else
		{
			comboBox_0.method_28().arrayList_0 = null;
		}
	}

	internal void method_12(ListBox listBox_0)
	{
		if (listBox_0.method_27().method_7().method_0())
		{
			return;
		}
		ArrayList arrayList = listBox_0.method_28().arrayList_0;
		if (arrayList == null || arrayList.Count == 0)
		{
			return;
		}
		ArrayList arrayList2 = new ArrayList();
		byte[] array = null;
		int num = 0;
		int num2 = 0;
		for (int num3 = arrayList.Count - 1; num3 >= 0; num3--)
		{
			array = (byte[])arrayList[num3];
			switch (array[0])
			{
			case 19:
			{
				num = 4;
				int num4 = BitConverter.ToUInt16(array, 4);
				num2 = array[4 + 2];
				num = 4 + 2;
				if (num4 != 0)
				{
					byte[] destinationArray2 = new byte[num2];
					Array.Copy(array, num + 6, destinationArray2, 0, num2);
					listBox_0.method_70(destinationArray2);
					num += num4;
				}
				num += 2;
				listBox_0.Shadow = (array[num + 2] & 8) == 0;
				switch (array[num + 2] & 0x30)
				{
				case 32:
					listBox_0.SelectionType = SelectionType.Extend;
					break;
				case 16:
					listBox_0.SelectionType = SelectionType.Multi;
					break;
				case 0:
					listBox_0.SelectionType = SelectionType.Single;
					break;
				}
				int num5 = BitConverter.ToUInt16(array, num) - 1;
				if (num5 >= 0 && listBox_0.SelectionType == SelectionType.Single)
				{
					listBox_0.SelectedIndex = num5;
				}
				num += 6;
				int itemCount = listBox_0.ItemCount;
				if (listBox_0.SelectionType == SelectionType.Single)
				{
					break;
				}
				listBox_0.method_73(new ArrayList());
				for (int i = 0; i < itemCount && num + i < array.Length; i++)
				{
					if (array[num + i] != 0)
					{
						listBox_0.method_72().Add((ushort)i);
					}
				}
				break;
			}
			case 12:
				num = 8;
				listBox_0.method_75(BitConverter.ToUInt16(array, 8));
				listBox_0.method_77(BitConverter.ToUInt16(array, 8 + 2));
				listBox_0.method_79(BitConverter.ToUInt16(array, 8 + 4));
				listBox_0.IncrementalChange = BitConverter.ToUInt16(array, 8 + 6);
				listBox_0.PageChange = BitConverter.ToUInt16(array, 8 + 8);
				listBox_0.Shadow = (array[8 + 14] & 0x80) == 0;
				break;
			default:
				arrayList2.Add(array);
				break;
			case 14:
			{
				num = 4;
				num2 = BitConverter.ToUInt16(array, 4);
				num = 4 + 6;
				byte[] destinationArray = new byte[num2];
				Array.Copy(array, 10, destinationArray, 0, num2);
				listBox_0.method_59(destinationArray);
				break;
			}
			case 0:
				break;
			}
		}
		if (arrayList2.Count > 0)
		{
			listBox_0.method_28().arrayList_0 = arrayList2;
		}
		else
		{
			listBox_0.method_28().arrayList_0 = null;
		}
	}

	private void method_13(Shape shape_0, byte[] byte_2)
	{
		shape_0.method_24(BitConverter.ToUInt16(byte_2, 6));
		if (shape_0.method_23() > shape_0.Shapes.method_8())
		{
			shape_0.Shapes.method_9(shape_0.method_23());
		}
		shape_0.method_28().IsLocked = (byte_2[8] & 1) != 0;
		shape_0.method_28().IsPrinted = (byte_2[8] & 0x10) != 0;
		shape_0.method_28().method_7((byte_2[9] & 1) != 0);
		shape_0.method_28().method_3((byte_2[9] & 0x20) != 0);
		shape_0.method_28().method_5((byte_2[9] & 0x40) != 0);
		if (byte_2.Length > 26)
		{
			shape_0.method_28().arrayList_0 = method_5(byte_2, 22);
		}
	}

	private Shape method_14(out int remain, Shape shape, byte[] msoDrawing, int offset, byte[] objRecord)
	{
		method_13(shape, objRecord);
		shape.method_27().method_2().Clear();
		shape.method_27().method_4();
		GroupShape groupShape = null;
		int num = 0;
		int num2 = 0;
		ushort num3 = 0;
		int num4 = 0;
		bool flag = true;
		bool flag2 = false;
		while (true)
		{
			switch (BitConverter.ToUInt16(msoDrawing, offset + 2))
			{
			case 61457:
				num = 0;
				offset += 8;
				break;
			case 61456:
				num = 18;
				offset += 10;
				if (method_0())
				{
					shape.method_27().method_7().Left = BitConverter.ToInt32(msoDrawing, offset);
					shape.method_27().method_7().Top = BitConverter.ToInt32(msoDrawing, offset + 4);
					shape.method_27().method_7().Right = BitConverter.ToInt32(msoDrawing, offset + 8);
					shape.method_27().method_7().Bottom = BitConverter.ToInt32(msoDrawing, offset + 12);
				}
				else
				{
					shape.method_27().method_7().method_8(BitConverter.ToUInt16(msoDrawing, offset));
					shape.method_27().method_7().Left = BitConverter.ToUInt16(msoDrawing, offset + 2);
					if ((float)shape.method_27().method_7().Left > Class1698.float_0)
					{
						shape.method_27().method_7().Left = (int)Class1698.float_0;
					}
					shape.method_27().method_7().method_6(BitConverter.ToUInt16(msoDrawing, offset + 4));
					shape.method_27().method_7().Top = BitConverter.ToUInt16(msoDrawing, offset + 6);
					shape.method_27().method_7().method_12(BitConverter.ToUInt16(msoDrawing, offset + 8));
					shape.method_27().method_7().Right = BitConverter.ToUInt16(msoDrawing, offset + 10);
					if ((float)shape.method_27().method_7().Right > Class1698.float_0)
					{
						shape.method_27().method_7().Right = (int)Class1698.float_0;
					}
					shape.method_27().method_7().method_10(BitConverter.ToUInt16(msoDrawing, offset + 12));
					shape.method_27().method_7().Bottom = BitConverter.ToUInt16(msoDrawing, offset + 14);
					if ((float)shape.method_27().method_7().Bottom > Class1698.float_1)
					{
						shape.method_27().method_7().Bottom = (int)Class1698.float_1;
					}
				}
				shape.method_27().method_7().method_4(PlacementType.MoveAndSize);
				offset += 16;
				switch (msoDrawing[offset - 18])
				{
				default:
					shape.method_27().method_7().placementType_1 = PlacementType.MoveAndSize;
					break;
				case 1:
					shape.method_27().method_7().placementType_1 = PlacementType.MoveAndSize;
					shape.method_27().method_7().method_1(bool_1: true);
					break;
				case 2:
					if (method_0())
					{
						shape.method_27().method_7().placementType_1 = PlacementType.Move;
					}
					else
					{
						shape.method_27().method_7().placementType_1 = PlacementType.Move;
					}
					break;
				case 3:
					shape.method_27().method_7().placementType_1 = PlacementType.FreeFloating;
					break;
				}
				break;
			case 61455:
			{
				offset += 8;
				num = 16;
				if (shape is GroupShape)
				{
					groupShape = (GroupShape)arrayList_0[arrayList_0.Count - 2];
				}
				else
				{
					groupShape = (GroupShape)arrayList_0[arrayList_0.Count - 1];
				}
				int num8 = BitConverter.ToInt32(msoDrawing, offset);
				shape.method_27().method_7().Left = num8;
				int num9 = BitConverter.ToInt32(msoDrawing, offset + 4);
				shape.method_27().method_7().Top = num9;
				num8 = BitConverter.ToInt32(msoDrawing, offset + 8) - num8;
				shape.method_27().method_7().Right = num8;
				num9 = BitConverter.ToInt32(msoDrawing, offset + 12) - num9;
				shape.method_27().method_7().Bottom = num9;
				offset += 16;
				break;
			}
			default:
			{
				num = BitConverter.ToInt32(msoDrawing, offset + 4);
				byte[] array3 = new byte[num + 8];
				Array.Copy(msoDrawing, offset, array3, 0, array3.Length);
				shape.method_27().method_1().Add(array3);
				offset += 8 + num;
				break;
			}
			case 61451:
			{
				int num11 = BitConverter.ToInt16(msoDrawing, offset) >> 4;
				num = BitConverter.ToInt32(msoDrawing, offset + 4);
				offset += 8;
				int num12 = offset + num11 * 6;
				int num13 = offset;
				for (int j = 0; j < num11; j++)
				{
					num3 = BitConverter.ToUInt16(msoDrawing, offset);
					num4 = BitConverter.ToInt32(msoDrawing, offset + 2);
					if (num3 == 904)
					{
						offset += 6;
						continue;
					}
					if ((num3 & 0x8000u) != 0)
					{
						if (num4 == 0)
						{
							offset += 6;
							continue;
						}
						if (Class1711.smethod_0(num3, num4))
						{
							int num14 = BitConverter.ToUInt16(msoDrawing, num12 + 4);
							if (num14 == 65520)
							{
								num14 = 4;
							}
							int num15 = BitConverter.ToUInt16(msoDrawing, num12) * num14;
							if (num15 == num4)
							{
								num4 += 6;
							}
							else if (num15 + 6 != num4)
							{
								num4 += 6;
							}
							byte[] array4 = new byte[num4];
							Array.Copy(msoDrawing, num12, array4, 0, num4);
							shape.method_27().method_2().method_1(num3, Enum183.const_5, array4);
							num12 += num4;
						}
						else
						{
							byte[] array5 = new byte[num4];
							Array.Copy(msoDrawing, num12, array5, 0, num4);
							shape.method_27().method_2().method_1(num3, Enum183.const_4, array5);
							num12 += num4;
						}
					}
					else
					{
						ushort num16 = num3;
						if (num16 == 4)
						{
							double num17 = Class1711.smethod_2(num4);
							if (shape.IsFlippedHorizontally ^ shape.IsFlippedVertically)
							{
								num17 = 0.0 - num17;
							}
							if (num17 < 0.0)
							{
								num17 += 360.0;
							}
							shape.method_27().method_2().method_8(num3, (float)num17);
						}
						else
						{
							shape.method_27().method_2().method_1(num3, Enum183.const_0, num4);
						}
					}
					offset += 6;
				}
				num = num12 - num13;
				offset = num12;
				break;
			}
			case 61450:
				num = 8;
				shape.method_27().method_9().method_1((short)(BitConverter.ToUInt16(msoDrawing, offset) >> 4));
				offset += 8;
				shape.method_27().method_9().method_3(BitConverter.ToInt32(msoDrawing, offset));
				shape.method_27().method_9().method_5(BitConverter.ToInt32(msoDrawing, offset + 4));
				offset += 8;
				break;
			case 61449:
				flag2 = true;
				offset += 8;
				num = 16;
				groupShape = (GroupShape)arrayList_0[arrayList_0.Count - 1];
				groupShape.method_69().int_0 = BitConverter.ToInt32(msoDrawing, offset);
				groupShape.method_69().int_2 = BitConverter.ToInt32(msoDrawing, offset + 4);
				groupShape.method_69().int_1 = BitConverter.ToInt32(msoDrawing, offset + 8) - groupShape.method_69().int_0;
				groupShape.method_69().int_3 = BitConverter.ToInt32(msoDrawing, offset + 12) - groupShape.method_69().int_2;
				offset += 16;
				break;
			case 61444:
				num2 = BitConverter.ToInt32(msoDrawing, offset + 4) + 8;
				num = 0;
				if (arrayList_0.Count != 0)
				{
					groupShape = (GroupShape)arrayList_0[arrayList_0.Count - 1];
					GroupShape groupShape2 = groupShape;
					groupShape2.method_71(groupShape2.method_70() - num2);
				}
				offset += 8;
				break;
			case 61443:
			{
				flag2 = true;
				int num10 = BitConverter.ToInt32(msoDrawing, offset + 4);
				if (arrayList_0.Count != 0)
				{
					groupShape = (GroupShape)arrayList_0[arrayList_0.Count - 1];
					GroupShape groupShape3 = groupShape;
					groupShape3.method_71(groupShape3.method_70() - (8 + num10));
				}
				if (!(shape is GroupShape))
				{
					shape = new GroupShape(shapeCollection_0);
					method_13(shape, objRecord);
				}
				groupShape = (GroupShape)shape;
				groupShape.method_71(num10);
				arrayList_0.Add(groupShape);
				offset += 8;
				break;
			}
			case 61730:
			{
				int num5 = BitConverter.ToInt16(msoDrawing, offset) >> 4;
				Shape shape2 = shape;
				if (num2 == 0 && shapeCollection_0.Count != 0)
				{
					shape2 = shapeCollection_0[shapeCollection_0.Count - 1];
					flag = false;
				}
				num = BitConverter.ToInt32(msoDrawing, offset + 4);
				offset += 8;
				int num6 = offset + num5 * 6;
				for (int i = 0; i < num5; i++)
				{
					num3 = BitConverter.ToUInt16(msoDrawing, offset);
					num4 = BitConverter.ToInt32(msoDrawing, offset + 2);
					if (num3 == 904)
					{
						offset += 6;
						continue;
					}
					if ((num3 & 0x8000u) != 0)
					{
						if (num4 == 0)
						{
							offset += 6;
							continue;
						}
						if (Class1711.smethod_0(num3, num4))
						{
							int num7 = BitConverter.ToUInt16(msoDrawing, num6) * BitConverter.ToUInt16(msoDrawing, num6 + 4);
							if (num7 + 6 != num4)
							{
								num4 += 6;
							}
							byte[] array = new byte[num4];
							Array.Copy(msoDrawing, num6, array, 0, num4);
							shape2.method_27().method_5().method_1(num3, Enum183.const_5, array);
							num6 += num4;
						}
						else
						{
							byte[] array2 = new byte[num4];
							Array.Copy(msoDrawing, num6, array2, 0, num4);
							shape2.method_27().method_5().method_1(num3, Enum183.const_4, array2);
							num6 += num4;
						}
					}
					else
					{
						shape2.method_27().method_5().method_1(num3, Enum183.const_0, num4);
					}
					offset += 6;
				}
				offset = num6;
				break;
			}
			}
			if (flag)
			{
				num2 -= num + 8;
				if (num2 == 0 || offset == msoDrawing.Length)
				{
					if (!flag2 && shape.MsoDrawingType == MsoDrawingType.Group && shape.method_27().method_2().Contains(16644))
					{
						Picture picture = new Picture(shapeCollection_0);
						shape = picture;
						int remain2 = 0;
						shape = method_14(out remain2, shape, msoDrawing, 0, byte_1);
						remain = remain2;
						return shape;
					}
					remain = num2;
					return shape;
				}
			}
			else if (offset == msoDrawing.Length)
			{
				break;
			}
			flag = true;
		}
		remain = 0;
		return shape;
	}

	private Shape method_15(Shape shape_0)
	{
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 != 236 && ushort_0 != 60)
		{
			class1723_0.method_3(-2);
			return shape_0;
		}
		method_20();
		byte[] array = byte_1;
		int num = 0;
		ushort num2 = 0;
		int num3 = 0;
		while (num + 2 < array.Length)
		{
			switch (BitConverter.ToUInt16(array, num + 2))
			{
			case 61730:
			{
				int num5 = BitConverter.ToInt16(array, num) >> 4;
				BitConverter.ToInt32(array, num + 4);
				num += 8;
				int num6 = num + num5 * 6;
				for (int i = 0; i < num5; i++)
				{
					num2 = BitConverter.ToUInt16(array, num);
					num3 = BitConverter.ToInt32(array, num + 2);
					if (num2 == 904)
					{
						num += 6;
						continue;
					}
					if ((num2 & 0x8000u) != 0)
					{
						if (num3 == 0)
						{
							num += 6;
							continue;
						}
						if (Class1711.smethod_0(num2, num3))
						{
							int num7 = BitConverter.ToUInt16(array, num6) * BitConverter.ToUInt16(array, num6 + 4);
							if (num7 + 6 != num3)
							{
								num3 += 6;
							}
							byte[] array2 = new byte[num3];
							Array.Copy(array, num6, array2, 0, num3);
							shape_0.method_27().method_5().method_1(num2, Enum183.const_5, array2);
							num6 += num3;
						}
						else
						{
							byte[] array3 = new byte[num3];
							Array.Copy(array, num6, array3, 0, num3);
							shape_0.method_27().method_5().method_1(num2, Enum183.const_4, array3);
							num6 += num3;
						}
					}
					else
					{
						shape_0.method_27().method_5().method_1(num2, Enum183.const_0, num3);
					}
					num += 6;
				}
				num = num6;
				break;
			}
			case 61453:
				switch (shape_0.MsoDrawingType)
				{
				case MsoDrawingType.CellsDrawing:
					method_16(shape_0, ((CellsDrawing)shape_0).method_63(), bool_1: false);
					return shape_0;
				case MsoDrawingType.Oval:
					method_16(shape_0, ((Oval)shape_0).method_63(), bool_1: false);
					return shape_0;
				}
				break;
			default:
				return shape_0;
			case 61443:
			case 61444:
				method_3(shape_0);
				ushort_0 = class1723_0.method_2(byte_0);
				if (ushort_0 != 93)
				{
					class1723_0.method_3(-2);
					return shape_0;
				}
				method_20();
				shapeCollection_0.method_32(shape_0, null);
				method_3(shape_0);
				return method_2(array, num, method_4(byte_1[4]));
			case 61445:
			{
				int num4 = BitConverter.ToInt32(byte_1, num + 4) + 8;
				if (num4 != 0)
				{
					byte[] byte_ = new byte[num4];
					method_17(0, num, byte_, 0, num4);
					shapeCollection_0.method_4().method_6().byte_0 = byte_;
					num += num4;
				}
				return shape_0;
			}
			}
		}
		return shape_0;
	}

	private void method_16(Shape shape_0, Class1737 class1737_0, bool bool_1)
	{
		if (bool_1)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 236 && ushort_0 != 60)
			{
				class1723_0.method_3(-2);
				return;
			}
			ushort_1 = class1723_0.method_2(byte_0);
			class1723_0.method_3(ushort_1);
		}
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 != 438)
		{
			class1723_0.method_3(-2);
			return;
		}
		method_20();
		switch ((byte_1[0] & 0xF) >> 1)
		{
		case 1:
			class1737_0.TextHorizontalAlignment = TextAlignmentType.Left;
			break;
		case 2:
			class1737_0.TextHorizontalAlignment = TextAlignmentType.Center;
			break;
		case 3:
			class1737_0.TextHorizontalAlignment = TextAlignmentType.Right;
			break;
		case 4:
			class1737_0.TextHorizontalAlignment = TextAlignmentType.Justify;
			break;
		case 7:
			class1737_0.TextHorizontalAlignment = TextAlignmentType.Distributed;
			break;
		}
		switch ((byte_1[0] & 0xF0) >> 4)
		{
		case 1:
			class1737_0.TextVerticalAlignment = TextAlignmentType.Top;
			break;
		case 2:
			class1737_0.TextVerticalAlignment = TextAlignmentType.Center;
			break;
		case 3:
			class1737_0.TextVerticalAlignment = TextAlignmentType.Bottom;
			break;
		case 4:
			class1737_0.TextVerticalAlignment = TextAlignmentType.Justify;
			break;
		case 7:
			class1737_0.TextVerticalAlignment = TextAlignmentType.Distributed;
			break;
		}
		class1737_0.method_7((byte_1[1] & 2) != 0);
		switch (byte_1[2])
		{
		case 0:
			class1737_0.TextOrientationType = TextOrientationType.NoRotation;
			break;
		case 1:
			class1737_0.TextOrientationType = TextOrientationType.TopToBottom;
			break;
		case 2:
			class1737_0.TextOrientationType = TextOrientationType.CounterClockWise;
			break;
		case 3:
			class1737_0.TextOrientationType = TextOrientationType.ClockWise;
			break;
		}
		int num = BitConverter.ToUInt16(byte_1, 10);
		int num2 = BitConverter.ToUInt16(byte_1, 12);
		if (BitConverter.ToUInt16(byte_1, 16) != 0)
		{
			int num3 = BitConverter.ToUInt16(byte_1, 18);
			byte[] destinationArray = new byte[num3];
			Array.Copy(byte_1, 24, destinationArray, 0, num3);
			shape_0.method_59(destinationArray);
		}
		if (num != 0)
		{
			string text = "";
			while (true)
			{
				if (num != 0)
				{
					ushort_0 = class1723_0.method_2(byte_0);
					if (ushort_0 == 60)
					{
						method_20();
						if (byte_1[0] == 0)
						{
							text += Class937.smethod_3(byte_1, 1, ushort_1 - 1);
							num -= ushort_1 - 1;
						}
						else
						{
							text += Encoding.Unicode.GetString(byte_1, 1, ushort_1 - 1);
							num -= (ushort_1 - 1) / 2;
						}
						continue;
					}
					throw new IOException("File is corrupted");
				}
				class1737_0.Text = text;
				ushort_0 = class1723_0.method_2(byte_0);
				if (ushort_0 != 60)
				{
					throw new IOException("File is corrupted");
				}
				method_20();
				int num4 = 0;
				if (num2 / 8 <= 2)
				{
					num4 = BitConverter.ToUInt16(byte_1, 2);
					if (num4 > 4)
					{
						num4--;
					}
					if (num4 < worksheetCollection_0.method_52().Count)
					{
						class1737_0.Font.Copy((Font)worksheetCollection_0.method_52()[num4]);
					}
					break;
				}
				int num5 = 0;
				int num6 = 0;
				for (int i = 0; i < ushort_1 - 8; i += 8)
				{
					num6 = BitConverter.ToUInt16(byte_1, i);
					num5 = BitConverter.ToUInt16(byte_1, i + 8);
					FontSetting fontSetting = class1737_0.Characters(num6, num5 - num6);
					num4 = BitConverter.ToUInt16(byte_1, i + 2);
					if (num4 > 4)
					{
						num4--;
					}
					if (num4 < worksheetCollection_0.method_52().Count)
					{
						fontSetting.Font.Copy((Font)worksheetCollection_0.method_52()[num4]);
					}
				}
				break;
			}
			return;
		}
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 == 60)
		{
			ushort_1 = class1723_0.method_2(byte_0);
			if (ushort_1 != 1)
			{
				class1723_0.method_3(-4);
				return;
			}
			class1723_0.method_3(1);
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 == 60)
			{
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
			}
			else
			{
				class1723_0.method_3(-2);
			}
		}
		else
		{
			class1723_0.method_3(-2);
		}
	}

	private int method_17(int int_0, int int_1, byte[] byte_2, int int_2, int int_3)
	{
		if (int_1 + int_3 <= ushort_1)
		{
			Array.Copy(byte_1, int_1, byte_2, int_2, int_3);
			int_1 += int_3;
			return int_1;
		}
		int num = 0;
		while (int_3 - int_2 > ushort_1)
		{
			num = ushort_1 - int_1;
			Array.Copy(byte_1, int_1, byte_2, int_2, num);
			int_2 += num;
			method_18();
			int_1 = int_0;
		}
		num = int_3 - int_2;
		Array.Copy(byte_1, int_1, byte_2, int_2, num);
		int_1 += num;
		return int_1;
	}

	private void method_18()
	{
		ushort_0 = class1723_0.method_2(byte_0);
		switch (ushort_0)
		{
		default:
			throw new CellsException(ExceptionType.IO, "File is corrupted");
		case 60:
		case 235:
		case 236:
			method_20();
			if (ushort_1 == 0)
			{
				method_18();
			}
			break;
		}
	}

	private void method_19(ShapeCollection shapeCollection_1)
	{
		shapeCollection_0 = shapeCollection_1;
		if (object_0 is Chart)
		{
			Chart chart = (Chart)object_0;
			chart.method_17(shapeCollection_1);
		}
		else
		{
			Worksheet worksheet = (Worksheet)object_0;
			worksheet.method_37(shapeCollection_1);
		}
	}

	internal void method_20()
	{
		class1730_0.method_5(class1723_0);
		byte_1 = class1730_0.method_105();
		ushort_1 = class1730_0.method_106();
	}
}
