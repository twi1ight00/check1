using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;
using Aspose.Cells.Rendering;
using ns12;
using ns16;
using ns2;
using ns21;
using ns36;
using ns37;
using ns52;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the msodrawing object.
///       </summary>
public class Shape
{
	internal Class1556 class1556_0;

	internal string string_0;

	internal ShapeCollection shapeCollection_0;

	internal Class1714 class1714_0;

	internal Class1708 class1708_0;

	internal ushort ushort_0;

	internal object object_0;

	internal bool bool_0;

	internal string string_1;

	private Class1110 class1110_0;

	private string string_2;

	private FillFormat fillFormat_0;

	private MsoFormatPicture msoFormatPicture_0;

	private Class1245 class1245_0;

	internal bool bool_1;

	private RectangleF rectangleF_0;

	internal bool bool_2;

	protected byte[] m_linkedCell;

	internal Class1737 class1737_0;

	private string string_3;

	private GeomPathsInfo geomPathsInfo_0;

	/// <summary>
	///       Returns the position of a shape in the z-order. 
	///       </summary>
	public int ZOrderPosition
	{
		get
		{
			return Index;
		}
		set
		{
			int index = Index;
			if (index != value)
			{
				if (value < index)
				{
					Shape shape_ = shapeCollection_0[index];
					shapeCollection_0.method_16(index);
					shapeCollection_0.method_17(value, shape_);
				}
				else
				{
					Shape shape_2 = shapeCollection_0[index];
					shapeCollection_0.method_16(index);
					shapeCollection_0.method_17(value, shape_2);
				}
			}
		}
	}

	/// <summary>
	///       Gets and sets the name of the shape. 
	///       </summary>
	public string Name
	{
		get
		{
			string stringValue = method_27().method_2().GetStringValue(50048);
			if (stringValue != null && stringValue != "")
			{
				return stringValue;
			}
			int num = method_27().method_9().method_2() - Shapes.method_4().method_8();
			if (num > 0)
			{
				num %= 1024;
				MsoDrawingType msoDrawingType = MsoDrawingType;
				if (msoDrawingType == MsoDrawingType.CellsDrawing)
				{
					return "AutoShape " + num;
				}
				return Class1130.smethod_2(MsoDrawingType) + " " + num;
			}
			return "Shape " + method_27().method_9().method_2();
		}
		set
		{
			method_62(Enum169.const_10);
			method_27().method_2().method_1(50048, Enum183.const_2, value);
		}
	}

	/// <summary>
	///       Returns or sets the descriptive (alternative) text string of the <see cref="T:Aspose.Cells.Drawing.Shape" /> object.
	///       </summary>
	public string AlternativeText
	{
		get
		{
			return method_27().method_2().GetStringValue(50049);
		}
		set
		{
			method_27().method_2().method_1(50049, Enum183.const_2, value);
		}
	}

	public string Title
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	/// <summary>
	///       Returns a MsoLineFormat object that contains line formatting properties for the specified shape.
	///       </summary>
	public MsoLineFormat LineFormat => new MsoLineFormat(this);

	/// <summary>
	///       Returns a MsoFillFormat object that contains fill formatting properties for the specified shape.
	///       </summary>
	public MsoFillFormat FillFormat => new MsoFillFormat(Fill);

	public FillFormat Fill
	{
		get
		{
			if (fillFormat_0 == null)
			{
				fillFormat_0 = new FillFormat(new MsoFillFormatHelper(this, method_27().method_2(), method_25().Workbook), this, method_25().Workbook, bool_1: false);
				if (fillFormat_0.Type == FillType.Texture)
				{
					fillFormat_0.TextureFill.method_4(bool_0);
				}
			}
			return fillFormat_0;
		}
	}

	/// <summary>
	///       Returns a TextFrame object that contains the alignment and anchoring properties for the specified shape.
	///       </summary>
	public MsoTextFrame TextFrame => new MsoTextFrame(this);

	/// <summary>
	///       Gets and sets the options of the picture format.
	///       </summary>
	public MsoFormatPicture FormatPicture
	{
		get
		{
			if (msoFormatPicture_0 == null)
			{
				msoFormatPicture_0 = new MsoFormatPicture(this);
			}
			return msoFormatPicture_0;
		}
	}

	/// <summary>
	///       Indicates whether the object is visible.
	///       </summary>
	public bool IsHidden
	{
		get
		{
			return method_27().method_2().method_5(959, 1, bool_0: false);
		}
		set
		{
			method_62(Enum169.const_12);
			method_27().method_2().method_6(959, 1, value);
		}
	}

	/// <summary>
	///       True means that don't allow changes in aspect ratio.
	///       </summary>
	public bool IsLockAspectRatio
	{
		get
		{
			bool flag = false;
			MsoDrawingType msoDrawingType = MsoDrawingType;
			if (msoDrawingType == MsoDrawingType.Picture || msoDrawingType == MsoDrawingType.OleObject)
			{
				flag = true;
			}
			return method_27().method_2().method_5(127, 7, flag);
		}
		set
		{
			method_27().method_2().method_6(127, 7, value);
		}
	}

	/// <summary>
	///       Gets and sets the rotation of the shape.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Shape.RotationAngle property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Shape.RotationAngle property instead.")]
	[Browsable(false)]
	public int Rotation
	{
		get
		{
			return (int)RotationAngle;
		}
		set
		{
			RotationAngle = value;
		}
	}

	/// <summary>
	///       Gets and sets the rotation of the shape.
	///       </summary>
	public double RotationAngle
	{
		get
		{
			return method_27().method_2().method_7(4, 0f);
		}
		set
		{
			double rotationAngle = RotationAngle;
			if (rotationAngle != value)
			{
				if (!method_33())
				{
					PlacementType placement = Placement;
					Placement = PlacementType.FreeFloating;
					int[] array = method_67(rotationAngle);
					class1714_0.method_7().Left = array[0];
					class1714_0.method_7().Top = array[1];
					class1714_0.method_7().Right = array[2];
					class1714_0.method_7().Bottom = array[3];
					int[] array2 = method_68(value);
					class1714_0.method_7().Left = array2[0];
					class1714_0.method_7().Top = array2[1];
					class1714_0.method_7().Right = array2[2];
					class1714_0.method_7().Bottom = array2[3];
					Placement = placement;
				}
				method_12(value);
			}
		}
	}

	/// <summary>
	///       Gets the hyperlink of the shape.
	///       </summary>
	public Hyperlink Hyperlink => method_27().method_2().method_2();

	/// <summary>
	///       Indicates whether the shape is a group.
	///       </summary>
	public bool IsGroup
	{
		get
		{
			if (method_28() == null)
			{
				return false;
			}
			return MsoDrawingType == MsoDrawingType.Group;
		}
	}

	/// <summary>
	///       Indicates whether this shape is a word art.
	///       </summary>
	public bool IsWordArt
	{
		get
		{
			string stringValue = method_27().method_2().GetStringValue(49344);
			if (stringValue != null)
			{
				return stringValue != "";
			}
			return false;
		}
	}

	/// <summary>
	///       Returns a TextEffectFormat object that contains text-effect formatting properties for the specified shape. 
	///       Applies to Shape objects that represent WordArt.
	///       </summary>
	public TextEffectFormat TextEffect => new TextEffectFormat(this);

	/// <summary>
	///       True if the object is locked, False if the object can be modified when the sheet is protected. 
	///       </summary>
	public bool IsLocked
	{
		get
		{
			if (method_28() == null)
			{
				return true;
			}
			return method_28().IsLocked;
		}
		set
		{
			if (method_28() != null)
			{
				method_28().IsLocked = value;
			}
		}
	}

	/// <summary>
	///       True if the object is printable
	///       </summary>
	public bool IsPrintable
	{
		get
		{
			if (method_28() == null)
			{
				return true;
			}
			return method_28().IsPrinted;
		}
		set
		{
			if (method_28() != null)
			{
				method_28().IsPrinted = value;
			}
		}
	}

	/// <summary>
	///       True if the object is printable
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Shape.IsPrintable property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Shape.IsPrintable property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool IsPrinted
	{
		get
		{
			return IsPrintable;
		}
		set
		{
			IsPrintable = true;
		}
	}

	/// <summary>
	///       Gets and sets mso drawing type.
	///       </summary>
	public MsoDrawingType MsoDrawingType
	{
		get
		{
			if (method_28() == null)
			{
				return MsoDrawingType.Picture;
			}
			return method_28().Type;
		}
	}

	/// <summary>
	///       Gets the auto shape type.
	///       </summary>
	public AutoShapeType AutoShapeType
	{
		get
		{
			if (Enum.IsDefined(typeof(AutoShapeType), method_27().method_9().method_0()))
			{
				return (AutoShapeType)method_27().method_9().method_0();
			}
			return AutoShapeType.Unknown;
		}
		set
		{
			method_27().method_9().method_1((short)value);
		}
	}

	/// <summary>
	///       Represents the way the drawing object is attached to the cells below it.
	///       The property controls the placement of an object on a worksheet.
	///       </summary>
	public PlacementType Placement
	{
		get
		{
			return method_27().method_7().method_3();
		}
		set
		{
			if (method_52() || method_33() || method_27().method_7().method_3() == value)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			if (method_30())
			{
				if (value != 0)
				{
					Chart chart = (Chart)Shapes.method_35();
					num = chart.ChartObject.Width;
					num2 = chart.ChartObject.Height;
					if (method_27().method_7().method_3() == PlacementType.MoveAndSize)
					{
						int right = (int)((double)((float)(num * (method_27().method_7().Right - method_27().method_7().Left)) / 4000f) + 0.5);
						method_27().method_7().Right = right;
						right = (int)((double)((float)(num2 * (method_27().method_7().Bottom - method_27().method_7().Top)) / 4000f) + 0.5);
						method_27().method_7().Bottom = right;
					}
					else
					{
						method_27().method_7().Right = (int)((double)((float)method_27().method_7().Right * 4000f / (float)num) + 0.5) + method_27().method_7().Left;
						method_27().method_7().Bottom = (int)((double)((float)method_27().method_7().Bottom * 4000f / (float)num2) + 0.5) + method_27().method_7().Top;
					}
					method_27().method_7().method_4(value);
				}
				return;
			}
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			if (method_27().method_7().method_3() == PlacementType.MoveAndSize)
			{
				num3 = method_27().method_7().method_5();
				num4 = method_27().method_7().Top;
				num5 = method_27().method_7().method_7();
				num6 = method_27().method_7().Left;
				num7 = method_27().method_7().method_9();
				num8 = method_27().method_7().Bottom;
				num9 = method_27().method_7().method_11();
				num10 = method_27().method_7().Right;
				if (value == PlacementType.FreeFloating)
				{
					num = method_44(0, 0, num5, num6);
					num2 = method_41(0, 0, num3, num4);
					method_27().method_7().Top = num2;
					method_27().method_7().Left = num;
				}
				num = method_44(num5, num6, num9, num10);
				num2 = method_41(num3, num4, num7, num8);
				method_27().method_7().Right = num;
				method_27().method_7().Bottom = num2;
				method_27().method_7().method_4(value);
			}
			else if (method_27().method_7().method_3() == PlacementType.Move)
			{
				num3 = method_27().method_7().method_5();
				num4 = method_27().method_7().Top;
				num5 = method_27().method_7().method_7();
				num6 = method_27().method_7().Left;
				switch (value)
				{
				case PlacementType.MoveAndSize:
				{
					num = method_27().method_7().Right;
					num2 = method_27().method_7().Bottom;
					int[] array = method_45(num5, num6, num);
					method_27().method_7().method_12(array[0]);
					method_27().method_7().Right = array[1];
					array = method_40(num3, num4, num2);
					method_27().method_7().method_10(array[0]);
					method_27().method_7().Bottom = array[1];
					break;
				}
				case PlacementType.FreeFloating:
					num = method_44(0, 0, num5, num6);
					method_27().method_7().Left = num;
					num2 = method_41(0, 0, num3, num4);
					method_27().method_7().Top = num2;
					break;
				}
				method_27().method_7().method_4(value);
			}
			else if (method_27().method_7().method_3() == PlacementType.FreeFloating)
			{
				num = method_27().method_7().Left;
				num2 = method_27().method_7().Top;
				int[] array2 = method_40(0, 0, num2);
				method_27().method_7().method_6(array2[0]);
				method_27().method_7().Top = array2[1];
				num3 = array2[0];
				num4 = array2[1];
				array2 = method_45(0, 0, num);
				method_27().method_7().method_8(array2[0]);
				method_27().method_7().Left = array2[1];
				num5 = array2[0];
				num6 = array2[1];
				if (value == PlacementType.MoveAndSize)
				{
					num = method_27().method_7().Right;
					num2 = method_27().method_7().Bottom;
					array2 = method_40(num3, num4, num2);
					method_27().method_7().method_10(array2[0]);
					method_27().method_7().Bottom = array2[1];
					array2 = method_45(num5, num6, num);
					method_27().method_7().method_12(array2[0]);
					method_27().method_7().Right = array2[1];
				}
				method_27().method_7().method_4(value);
			}
		}
	}

	/// <summary>
	///       Represents upper left corner row index. 
	///       </summary>
	/// <remarks>If the shape is in the shape or in the group , UpperLeftRow will be ignored.</remarks>
	public int UpperLeftRow
	{
		get
		{
			if (method_52())
			{
				return 0;
			}
			if (method_33())
			{
				GroupShape groupShape = (GroupShape)object_0;
				int int_ = (int)((double)((float)(method_27().method_7().Top * groupShape.Height) / 4000f) + 0.5);
				int[] array = method_40(groupShape.UpperLeftRow, groupShape.UpperDeltaY, int_);
				return array[0];
			}
			if (method_30())
			{
				return 0;
			}
			if (Placement != PlacementType.Move && Placement != PlacementType.MoveAndSize)
			{
				int top = method_27().method_7().Top;
				int[] array2 = method_40(0, 0, top);
				return array2[0];
			}
			return method_27().method_7().method_5();
		}
		set
		{
			Class1677.smethod_24(value);
			if (!method_52() && !method_33() && !method_30())
			{
				PlacementType placement = Placement;
				Placement = PlacementType.Move;
				method_27().method_7().method_6(value);
				Placement = placement;
			}
		}
	}

	/// <summary>
	///       Gets or sets the shape's vertical offset from its upper left corner row.
	///       <remarks>The range of value is 0 to 256.</remarks></summary>
	public int UpperDeltaY
	{
		get
		{
			if (method_52())
			{
				return 0;
			}
			if (method_33())
			{
				GroupShape groupShape = (GroupShape)object_0;
				int int_ = (int)((double)((float)(method_27().method_7().Top * groupShape.Height) / 4000f) + 0.5);
				int[] array = method_40(groupShape.UpperLeftRow, groupShape.UpperDeltaY, int_);
				return array[1];
			}
			if (method_30())
			{
				return 0;
			}
			if (Placement != PlacementType.Move && Placement != PlacementType.MoveAndSize)
			{
				int top = method_27().method_7().Top;
				int[] array2 = method_40(0, 0, top);
				return array2[1];
			}
			if (!((float)method_27().method_7().Top > Class1698.float_1))
			{
				return method_27().method_7().Top;
			}
			return (int)Class1698.float_1;
		}
		set
		{
			if (value >= 0 && (float)value <= Class1698.float_1 && !method_52() && !method_33() && !method_30())
			{
				PlacementType placement = Placement;
				Placement = PlacementType.Move;
				method_27().method_7().Top = value;
				Placement = placement;
			}
		}
	}

	/// <summary>
	///       Represents upper left corner column index.
	///       </summary>
	public int UpperLeftColumn
	{
		get
		{
			if (method_52())
			{
				return 0;
			}
			if (method_33())
			{
				GroupShape groupShape = (GroupShape)object_0;
				int int_ = (int)((double)((float)(method_27().method_7().Left * groupShape.Width) / 4000f) + 0.5);
				int[] array = method_45(groupShape.UpperLeftColumn, groupShape.UpperDeltaX, int_);
				return array[0];
			}
			if (method_30())
			{
				return 0;
			}
			if (Placement != PlacementType.Move && Placement != PlacementType.MoveAndSize)
			{
				int left = method_27().method_7().Left;
				int[] array2 = method_45(0, 0, left);
				return array2[0];
			}
			return method_27().method_7().method_7();
		}
		set
		{
			Class1677.smethod_25(value);
			if (!method_52() && !method_33() && !method_30())
			{
				PlacementType placement = Placement;
				Placement = PlacementType.Move;
				method_27().method_7().method_8(value);
				Placement = placement;
			}
		}
	}

	/// <summary>
	///       Gets or sets the shape's horizontal offset from its upper left corner column.
	///       <remarks>The range of value is 0 to 1024.</remarks></summary>
	public int UpperDeltaX
	{
		get
		{
			if (method_52())
			{
				return 0;
			}
			if (method_33())
			{
				GroupShape groupShape = (GroupShape)object_0;
				int int_ = (int)((double)((float)(method_27().method_7().Left * groupShape.Width) / 4000f) + 0.5);
				int[] array = method_45(groupShape.UpperLeftColumn, groupShape.UpperDeltaX, int_);
				return array[1];
			}
			if (method_30())
			{
				return 0;
			}
			if (Placement != PlacementType.Move && Placement != PlacementType.MoveAndSize)
			{
				int left = method_27().method_7().Left;
				int[] array2 = method_45(0, 0, left);
				return array2[1];
			}
			if (!((float)method_27().method_7().Left > Class1698.float_0))
			{
				return method_27().method_7().Left;
			}
			return (int)Class1698.float_0;
		}
		set
		{
			if (value >= 0 && (float)value <= Class1698.float_0 && !method_52() && !method_33() && !method_30())
			{
				PlacementType placement = Placement;
				Placement = PlacementType.Move;
				method_27().method_7().Left = value;
				Placement = placement;
			}
		}
	}

	/// <summary>
	/// </summary>
	public int ActualLowerRightRow
	{
		get
		{
			int num = LowerRightRow;
			if (Placement == PlacementType.MoveAndSize)
			{
				Cells cells = method_26().Cells;
				if (cells.method_25())
				{
					RowCollection rows = cells.Rows;
					if (rows.Count == 0)
					{
						return 0;
					}
					int num2 = rows.Count - 1;
					while (num2 >= 0)
					{
						Row rowByIndex = rows.GetRowByIndex(num2);
						if (rowByIndex.IsHidden)
						{
							num2--;
							continue;
						}
						if (num > rowByIndex.Index)
						{
							num = rowByIndex.Index;
						}
						break;
					}
				}
			}
			return num;
		}
	}

	/// <summary>
	///       Represents lower right corner row index.
	///       </summary>
	public int LowerRightRow
	{
		get
		{
			if (method_52())
			{
				return 0;
			}
			if (method_33())
			{
				GroupShape groupShape = (GroupShape)object_0;
				int int_ = (int)((double)((float)((method_27().method_7().Top + method_27().method_7().Bottom) * groupShape.Height) / 4000f) + 0.5);
				int[] array = method_40(groupShape.UpperLeftRow, groupShape.UpperDeltaY, int_);
				return array[0];
			}
			if (method_30())
			{
				return 0;
			}
			if (Placement == PlacementType.MoveAndSize)
			{
				return method_27().method_7().method_9();
			}
			int num = method_27().method_7().Bottom;
			int int_2 = 0;
			int int_3 = 0;
			if (Placement == PlacementType.Move)
			{
				int_2 = method_27().method_7().method_5();
				int_3 = method_27().method_7().Top;
			}
			else
			{
				num += method_27().method_7().Top;
			}
			int[] array2 = method_40(int_2, int_3, num);
			return array2[0];
		}
		set
		{
			Class1677.smethod_24(value);
			if (!method_52() && !method_33() && !method_30())
			{
				int lowerDeltaY = LowerDeltaY;
				PlacementType placement = Placement;
				Placement = PlacementType.Move;
				int bottom = method_27().method_7().Bottom;
				int[] array = method_46(value, lowerDeltaY, bottom);
				method_27().method_7().method_6(array[0]);
				method_27().method_7().Top = array[1];
				Placement = placement;
			}
		}
	}

	/// <summary>
	///       Gets or sets the shape's vertical offset from its lower right corner row.
	///       <remarks>The range of value is 0 to 256.</remarks></summary>
	public int LowerDeltaY
	{
		get
		{
			if (method_52())
			{
				return 0;
			}
			if (method_33())
			{
				GroupShape groupShape = (GroupShape)object_0;
				int int_ = (int)((double)((float)((method_27().method_7().Top + method_27().method_7().Bottom) * groupShape.Height) / 4000f) + 0.5);
				int[] array = method_40(groupShape.UpperLeftRow, groupShape.UpperDeltaY, int_);
				return array[1];
			}
			if (method_30())
			{
				return 0;
			}
			if (Placement == PlacementType.MoveAndSize)
			{
				return method_27().method_7().Bottom;
			}
			int num = method_27().method_7().Bottom;
			int int_2 = 0;
			int int_3 = 0;
			if (Placement == PlacementType.Move)
			{
				int_2 = method_27().method_7().method_5();
				int_3 = method_27().method_7().Top;
			}
			else
			{
				num += method_27().method_7().Top;
			}
			int[] array2 = method_40(int_2, int_3, num);
			return array2[1];
		}
		set
		{
			if (value >= 0 && (float)value <= Class1698.float_1 && !method_52() && !method_33() && !method_30())
			{
				int lowerRightRow = LowerRightRow;
				PlacementType placement = Placement;
				Placement = PlacementType.Move;
				int bottom = method_27().method_7().Bottom;
				int[] array = method_46(lowerRightRow, value, bottom);
				method_27().method_7().method_6(array[0]);
				method_27().method_7().Top = array[1];
				Placement = placement;
			}
		}
	}

	/// <summary>
	///       Represents lower right corner column index.
	///       </summary>
	public int LowerRightColumn
	{
		get
		{
			if (method_52())
			{
				return 0;
			}
			if (method_33())
			{
				GroupShape groupShape = (GroupShape)object_0;
				int int_ = (int)((double)((float)((method_27().method_7().Left + method_27().method_7().Right) * groupShape.Width) / 4000f) + 0.5);
				int[] array = method_45(groupShape.UpperLeftColumn, groupShape.UpperDeltaX, int_);
				return array[0];
			}
			if (method_30())
			{
				return 0;
			}
			if (Placement == PlacementType.MoveAndSize)
			{
				return method_27().method_7().method_11();
			}
			int int_2 = 0;
			int int_3 = 0;
			int num = method_27().method_7().Right;
			if (Placement == PlacementType.Move)
			{
				int_2 = method_27().method_7().method_7();
				int_3 = method_27().method_7().Left;
			}
			else
			{
				num += method_27().method_7().Left;
			}
			int[] array2 = method_45(int_2, int_3, num);
			return array2[0];
		}
		set
		{
			Class1677.smethod_25(value);
			if (!method_52() && !method_33() && !method_30())
			{
				int lowerDeltaX = LowerDeltaX;
				PlacementType placement = Placement;
				Placement = PlacementType.Move;
				int right = method_27().method_7().Right;
				int[] array = method_47(value, lowerDeltaX, right);
				method_27().method_7().method_8(array[0]);
				method_27().method_7().Left = array[1];
				Placement = placement;
			}
		}
	}

	/// <summary>
	///       Gets or sets the shape's horizontal  offset from its lower right corner column.
	///       <remarks>The range of value is 0 to 1024.</remarks></summary>
	public int LowerDeltaX
	{
		get
		{
			if (method_52())
			{
				return 0;
			}
			if (method_33())
			{
				GroupShape groupShape = (GroupShape)object_0;
				int int_ = (int)((double)((float)((method_27().method_7().Left + method_27().method_7().Right) * groupShape.Width) / 4000f) + 0.5);
				int[] array = method_45(groupShape.UpperLeftColumn, groupShape.UpperDeltaX, int_);
				return array[1];
			}
			if (method_30())
			{
				return 0;
			}
			if (Placement == PlacementType.MoveAndSize)
			{
				return method_27().method_7().Right;
			}
			int int_2 = 0;
			int int_3 = 0;
			int num = method_27().method_7().Right;
			if (Placement == PlacementType.Move)
			{
				int_2 = method_27().method_7().method_7();
				int_3 = method_27().method_7().Left;
			}
			else
			{
				num += method_27().method_7().Left;
			}
			int[] array2 = method_45(int_2, int_3, num);
			return array2[1];
		}
		set
		{
			if ((value >= 0 || !((float)value > Class1698.float_0)) && !method_52() && !method_33() && !method_30())
			{
				int lowerRightColumn = LowerRightColumn;
				PlacementType placement = Placement;
				Placement = PlacementType.Move;
				int right = method_27().method_7().Right;
				int[] array = method_47(lowerRightColumn, value, right);
				method_27().method_7().method_8(array[0]);
				method_27().method_7().Left = array[1];
				Placement = placement;
			}
		}
	}

	public int Right
	{
		get
		{
			int lowerRightColumn = LowerRightColumn;
			int lowerDeltaX = LowerDeltaX;
			if (lowerDeltaX == 0)
			{
				return 0;
			}
			return method_44(lowerRightColumn, 0, lowerRightColumn, lowerDeltaX);
		}
	}

	public int Bottom
	{
		get
		{
			int lowerRightRow = LowerRightRow;
			int lowerDeltaY = LowerDeltaY;
			if (lowerDeltaY == 0)
			{
				return 0;
			}
			return method_41(lowerRightRow, 0, lowerRightRow, lowerDeltaY);
		}
	}

	/// <summary>
	///       Represents the width of shape, in unit of pixels.
	///       </summary>
	public int Width
	{
		get
		{
			if (method_33())
			{
				GroupShape groupShape = (GroupShape)object_0;
				return (int)((double)((float)method_27().method_7().Right / 4000f * (float)groupShape.Width) + 0.5);
			}
			if (method_30())
			{
				switch (Placement)
				{
				default:
					return 0;
				case PlacementType.Move:
					return method_27().method_7().Right;
				case PlacementType.MoveAndSize:
				{
					Chart chart = (Chart)Shapes.method_35();
					return (int)((double)((float)(chart.ChartObject.Width * (method_27().method_7().Right - method_27().method_7().Left)) / 4000f) + 0.5);
				}
				}
			}
			if (Placement != PlacementType.Move && Placement != 0)
			{
				int int_ = method_27().method_7().method_7();
				int int_2 = method_27().method_7().method_11();
				int left = method_27().method_7().Left;
				int right = method_27().method_7().Right;
				return method_44(int_, left, int_2, right);
			}
			return method_27().method_7().Right;
		}
		set
		{
			if (method_33())
			{
				return;
			}
			if (method_30())
			{
				switch (Placement)
				{
				case PlacementType.Move:
					method_27().method_7().Right = value;
					break;
				case PlacementType.MoveAndSize:
				{
					Chart chart = (Chart)Shapes.method_35();
					int num = (int)((double)(4000f * (float)value / (float)chart.ChartObject.Width) + 0.5) + method_27().method_7().Left;
					method_27().method_7().Right = ((num > 4000) ? 4000 : num);
					break;
				}
				}
			}
			else if (Placement != PlacementType.Move && Placement != 0)
			{
				int int_ = method_27().method_7().method_7();
				int left = method_27().method_7().Left;
				int[] array = method_45(int_, left, value);
				method_27().method_7().method_12(array[0]);
				method_27().method_7().Right = array[1];
			}
			else
			{
				method_27().method_7().Right = value;
			}
		}
	}

	/// <summary>
	///        Represents the width of the shape, in unit of inch. 
	///       </summary>
	public double WidthInch
	{
		get
		{
			return method_49(Width);
		}
		set
		{
			Width = method_48(value);
		}
	}

	/// <summary>
	///        Represents the width of the shape, in unit of point. 
	///       </summary>
	public double WidthPt
	{
		get
		{
			return (float)Width * 72f / (float)method_25().method_75();
		}
		set
		{
			Width = (int)(value * (double)method_25().method_75() / 72.0 + 0.5);
		}
	}

	/// <summary>
	///       Represents the width of the shape, in unit of centimeters. 
	///       </summary>
	public double WidthCM
	{
		get
		{
			return method_51(Width);
		}
		set
		{
			Width = method_50(value);
		}
	}

	/// <summary>
	///       Represents the height of shape, in unit of pixel.
	///       </summary>
	public int Height
	{
		get
		{
			if (method_33())
			{
				GroupShape groupShape = (GroupShape)object_0;
				return (int)((double)((float)(method_27().method_7().Bottom * groupShape.Height) / 4000f) + 0.5);
			}
			if (method_30())
			{
				switch (Placement)
				{
				default:
					return 0;
				case PlacementType.Move:
					return method_27().method_7().Bottom;
				case PlacementType.MoveAndSize:
				{
					Chart chart = (Chart)Shapes.method_35();
					return (int)((double)((float)(chart.ChartObject.Height * (method_27().method_7().Bottom - method_27().method_7().Top)) / 4000f) + 0.5);
				}
				}
			}
			if (Placement != PlacementType.Move && Placement != 0)
			{
				int int_ = method_27().method_7().method_5();
				int int_2 = method_27().method_7().method_9();
				int top = method_27().method_7().Top;
				int bottom = method_27().method_7().Bottom;
				return method_41(int_, top, int_2, bottom);
			}
			return method_27().method_7().Bottom;
		}
		set
		{
			if (method_33())
			{
				return;
			}
			if (method_30())
			{
				switch (Placement)
				{
				case PlacementType.Move:
					method_27().method_7().Bottom = value;
					break;
				case PlacementType.MoveAndSize:
				{
					Chart chart = (Chart)Shapes.method_35();
					int num = (int)((double)(4000f * (float)value / (float)chart.ChartObject.Height) + 0.5) + method_27().method_7().Top;
					method_27().method_7().Bottom = ((num > 4000) ? 4000 : num);
					break;
				}
				}
			}
			else if (Placement != PlacementType.Move && Placement != 0)
			{
				int int_ = method_27().method_7().method_5();
				int top = method_27().method_7().Top;
				int[] array = method_40(int_, top, value);
				method_27().method_7().method_10(array[0]);
				method_27().method_7().Bottom = array[1];
			}
			else
			{
				method_27().method_7().Bottom = value;
			}
		}
	}

	/// <summary>
	///       Represents the height of the shape, in unit of inches. 
	///       </summary>
	public double HeightInch
	{
		get
		{
			return method_49(Height);
		}
		set
		{
			Height = method_48(value);
		}
	}

	/// <summary>
	///       Represents the height of the shape, in unit of points. 
	///       </summary>
	public double HeightPt
	{
		get
		{
			return (float)Height * 72f / (float)method_25().method_75();
		}
		set
		{
			Height = (int)(value * (double)method_25().method_75() / 72.0 + 0.5);
		}
	}

	/// <summary>
	///       Represents the height of the shape, in unit of inches. 
	///       </summary>
	public double HeightCM
	{
		get
		{
			return method_51(Height);
		}
		set
		{
			Height = method_50(value);
		}
	}

	/// <summary>
	///       Represents the horizontal offset of shape from its left column, in unit of pixels.
	///       </summary>
	public int Left
	{
		get
		{
			if (method_30())
			{
				Chart chart = (Chart)Shapes.method_35();
				return (int)((double)((float)(chart.ChartObject.Width * method_27().method_7().Left) / 4000f) + 0.5);
			}
			Cells cells = method_26().Cells;
			int viewColumnWidthPixel = cells.GetViewColumnWidthPixel(UpperLeftColumn);
			return (int)((double)((float)(viewColumnWidthPixel * UpperDeltaX) / Class1698.float_0) + 0.5);
		}
		set
		{
			if (method_33())
			{
				return;
			}
			if (method_30())
			{
				Chart chart = (Chart)Shapes.method_35();
				int num = (int)((double)((float)value * 4000f / (float)chart.ChartObject.Width) + 0.5);
				num = ((num > 4000) ? 4000 : num);
				method_27().method_7().Left = num;
				return;
			}
			Cells cells = method_26().Cells;
			int viewColumnWidthPixel = cells.GetViewColumnWidthPixel(UpperLeftColumn);
			if (viewColumnWidthPixel < value)
			{
				throw new ArgumentException("The left value must be less than the upper left column width.");
			}
			UpperDeltaX = (int)((double)((float)value * Class1698.float_0 / (float)viewColumnWidthPixel) + 0.5);
		}
	}

	/// <summary>
	///       Represents the horizontal offset of shape from its left column, in unit of inches.
	///       </summary>
	public double LeftInch
	{
		get
		{
			return method_49(Left);
		}
		set
		{
			Left = method_48(value);
		}
	}

	/// <summary>
	///       Represents the horizontal offset of shape from its left column, in unit of centimeters.
	///       </summary>
	public double LeftCM
	{
		get
		{
			return method_51(Left);
		}
		set
		{
			Left = method_50(value);
		}
	}

	/// <summary>
	///       Represents the vertical offset of shape from its top row, in unit of pixels.
	///       </summary>
	/// <remarks>If the shape is in the chart, represents the vertical offset of shape from its top border.</remarks>
	public int Top
	{
		get
		{
			if (method_52())
			{
				return 0;
			}
			if (method_30())
			{
				Chart chart = (Chart)Shapes.method_35();
				return (int)((double)((float)(method_27().method_7().Top * chart.ChartObject.Height) / 4000f) + 0.5);
			}
			Cells cells = method_26().Cells;
			int rowHeightPixel = cells.GetRowHeightPixel(UpperLeftRow);
			return (int)((double)((float)(rowHeightPixel * UpperDeltaY) / Class1698.float_1) + 0.5);
		}
		set
		{
			if (method_33())
			{
				return;
			}
			if (method_30())
			{
				Chart chart = (Chart)Shapes.method_35();
				int num = (int)((double)((float)value * 4000f / (float)chart.ChartObject.Height) + 0.5);
				num = ((num > 4000) ? 4000 : num);
				method_27().method_7().Top = num;
				return;
			}
			Cells cells = method_26().Cells;
			int rowHeightPixel = cells.GetRowHeightPixel(UpperLeftRow);
			if (rowHeightPixel < value)
			{
				throw new ArgumentException("The top value must be less than the upper left row height.");
			}
			UpperDeltaY = (int)((double)((float)value * Class1698.float_1 / (float)rowHeightPixel) + 0.5);
		}
	}

	/// <summary>
	///        Represents the vertical offset of shape from its top row, in unit of inches.
	///       </summary>
	public double TopInch
	{
		get
		{
			return method_49(Top);
		}
		set
		{
			Top = method_48(value);
		}
	}

	/// <summary>
	///        Represents the vertical offset of shape from its top row, in unit of centimeters.
	///       </summary>
	public double TopCM
	{
		get
		{
			return method_51(Top);
		}
		set
		{
			Top = method_50(value);
		}
	}

	/// <summary>
	///       Gets and sets the horizonal offset of shape from worksheet left border,in unit of pixels.
	///       </summary>
	public int X
	{
		get
		{
			return method_38();
		}
		set
		{
			method_39(value);
		}
	}

	/// <summary>
	///       Gets and sets the vertical offset of shape from worksheet top border,in unit of pixels.
	///       </summary>
	public int Y
	{
		get
		{
			return method_36();
		}
		set
		{
			method_37(value);
		}
	}

	/// <summary>
	///       Gets and sets the width scale, in unit of percent of the original picture width.
	///       If the shape is not picture ,the WidthScale property only returns 100;
	///       </summary>
	public int WidthScale
	{
		get
		{
			if (MsoDrawingType == MsoDrawingType.Picture)
			{
				Picture picture = (Picture)this;
				return (int)((double)(Width * 100 / picture.method_69().Width) + 0.5);
			}
			return 100;
		}
		set
		{
			if (method_33())
			{
				method_27().method_7().Right = (int)((double)((float)(method_27().method_7().Right * value) / 100f) + 0.5);
			}
			else if (MsoDrawingType == MsoDrawingType.Picture)
			{
				Picture picture = (Picture)this;
				int width = (int)((double)((float)(picture.method_69().Width * value) / 100f) + 0.5);
				Width = width;
			}
			else
			{
				int width2 = (int)((double)((float)(Width * value) / 100f) + 0.5);
				Width = width2;
			}
		}
	}

	/// <summary>
	///        Gets and sets the height scale,in unit of percent of the original picture height.
	///       If the shape is not picture ,the HeightScale property only returns 100;
	///       </summary>
	public int HeightScale
	{
		get
		{
			if (MsoDrawingType == MsoDrawingType.Picture)
			{
				Picture picture = (Picture)this;
				return (int)((double)(Height * 100 / picture.method_69().Height) + 0.5);
			}
			return 100;
		}
		set
		{
			if (value <= 0)
			{
				throw new ArgumentException("Invalid width scale: it must be greater than 0.");
			}
			if (method_33())
			{
				method_27().method_7().Bottom = method_27().method_7().Bottom * value / 100;
			}
			else if (MsoDrawingType == MsoDrawingType.Picture)
			{
				Picture picture = (Picture)this;
				int height = (int)((double)((float)(picture.method_69().Height * value) / 100f) + 0.5);
				Height = height;
			}
			else
			{
				int height2 = (int)((double)((float)(Height * value) / 100f) + 0.5);
				Height = height2;
			}
		}
	}

	/// <summary>
	///       Represents the vertical offset of shape from the top border of the parent shape, in unit of 1/4000 of height of the parent shape.
	///       </summary>
	/// <remarks>Only Applies when this shape in the group or chart.</remarks>
	public int TopInShape
	{
		get
		{
			if (!method_30() && !method_33())
			{
				return 0;
			}
			return method_27().method_7().Top;
		}
		set
		{
			if (method_30() || method_33())
			{
				if (value < 0 || value > 4000)
				{
					throw new ArgumentException("Invalid TopInShape value : it must be between 0 and 4000.");
				}
				if (Placement == PlacementType.MoveAndSize)
				{
					int num = method_27().method_7().Bottom - method_27().method_7().Top;
					method_27().method_7().Top = value;
					method_27().method_7().Bottom = value + num;
				}
				else
				{
					method_27().method_7().Top = value;
				}
			}
		}
	}

	/// <summary>
	///       Represents the vertical offset of shape from the left border of the parent shape, in unit of 1/4000 of width of the parent shape.
	///       </summary>
	/// <remarks>Only Applies when this shape in the group or chart.</remarks>
	public int LeftInShape
	{
		get
		{
			if (!method_30() && !method_33())
			{
				return 0;
			}
			return method_27().method_7().Left;
		}
		set
		{
			if (method_30() || method_33())
			{
				if (value < 0 || value > 4000)
				{
					throw new ArgumentException("Invalid TopInShape value : it must be between 0 and 4000.");
				}
				if (Placement == PlacementType.MoveAndSize)
				{
					int num = method_27().method_7().Right - method_27().method_7().Left;
					method_27().method_7().Left = value;
					method_27().method_7().Right = num + value;
				}
				else
				{
					method_27().method_7().Left = value;
				}
			}
		}
	}

	/// <summary>
	///       Represents the width of the shape, in unit of 1/4000 of the parent shape.
	///       </summary>
	/// <remarks>Only Applies when this shape in the group or chart.</remarks>
	public int WidthInShape
	{
		get
		{
			if (method_33())
			{
				return method_27().method_7().Right;
			}
			if (method_30())
			{
				if (Placement == PlacementType.Move)
				{
					Chart chart = (Chart)Shapes.method_35();
					int num = (int)((double)((float)method_27().method_7().Right * 4000f / (float)chart.ChartObject.Width) + 0.5);
					if (num <= 4000)
					{
						return num;
					}
					return 4000;
				}
				return method_27().method_7().Right - method_27().method_7().Left;
			}
			return 0;
		}
		set
		{
			if (value >= 0 && value <= 4000)
			{
				if (method_33())
				{
					method_27().method_7().Right = value;
				}
				if (method_30())
				{
					if (Placement == PlacementType.Move)
					{
						Chart chart = (Chart)Shapes.method_35();
						method_27().method_7().Right = (int)((double)((float)(value * chart.ChartObject.Width) / 4000f) + 0.5);
					}
					else
					{
						method_27().method_7().Right = value + method_27().method_7().Left;
					}
				}
				return;
			}
			throw new ArgumentException("Invalid TopInShape value : it must be between 0 and 4000.");
		}
	}

	/// <summary>
	///       Represents the vertical offset of shape from the top border of the parent shape, in unit of 1/4000 of height of the parent shape..
	///       </summary>
	/// <remarks>Only Applies when this shape in the group or chart.</remarks>
	public int HeightInShape
	{
		get
		{
			if (method_33())
			{
				return method_27().method_7().Bottom;
			}
			if (method_30())
			{
				if (Placement == PlacementType.Move)
				{
					Chart chart = (Chart)Shapes.method_35();
					int num = (int)((double)((float)method_27().method_7().Bottom * 4000f / (float)chart.ChartObject.Height) + 0.5);
					if (num <= 4000)
					{
						return num;
					}
					return 4000;
				}
				return method_27().method_7().Bottom - method_27().method_7().Top;
			}
			return 0;
		}
		set
		{
			if (value >= 0 && value <= 4000)
			{
				if (method_33())
				{
					method_27().method_7().Bottom = value;
				}
				if (method_30())
				{
					if (Placement == PlacementType.Move)
					{
						Chart chart = (Chart)Shapes.method_35();
						int bottom = (int)((double)((float)value * 4000f / (float)chart.ChartObject.Height) + 0.5);
						method_27().method_7().Bottom = bottom;
					}
					else
					{
						method_27().method_7().Bottom = value + method_27().method_7().Top;
					}
				}
				return;
			}
			throw new ArgumentException("Invalid TopInShape value : it must be between 0 and 4000.");
		}
	}

	public GroupShape Group
	{
		get
		{
			if (method_33())
			{
				return (GroupShape)object_0;
			}
			return null;
		}
	}

	public AutoShapeType Type => AutoShapeType;

	public bool HasLine
	{
		get
		{
			return LineFormat.IsVisible;
		}
		set
		{
			LineFormat.IsVisible = value;
		}
	}

	public bool IsFilled
	{
		get
		{
			return FillFormat.IsVisible;
		}
		set
		{
			FillFormat.IsVisible = value;
		}
	}

	public bool IsFlippedHorizontally
	{
		get
		{
			return method_27().method_9().method_11();
		}
		set
		{
			method_27().method_9().method_12(value);
		}
	}

	public bool IsFlippedVertically
	{
		get
		{
			return method_27().method_9().method_9();
		}
		set
		{
			method_27().method_9().method_10(value);
		}
	}

	/// <summary>
	///       Indicates whether shape is relative to original picture size.
	///       </summary>
	public bool RelativeToOriginalPictureSize
	{
		get
		{
			return method_27().method_2().method_5(831, 4, bool_0: true);
		}
		set
		{
			method_27().method_2().method_6(831, 4, value);
		}
	}

	/// <summary>
	///       Gets or sets the worksheet range linked to the control's value.
	///       </summary>
	public virtual string LinkedCell
	{
		get
		{
			if (m_linkedCell == null)
			{
				return null;
			}
			string text = method_25().method_4().method_4(0, m_linkedCell.Length, m_linkedCell, 0, 0, bool_0: false);
			if (text != null && text != "" && text[0] == '=')
			{
				return text.Substring(1);
			}
			return text;
		}
		set
		{
			method_61(value);
		}
	}

	/// <summary>
	///       Represents the font of textbox.
	///       </summary>
	public Font Font
	{
		get
		{
			return method_63().Font;
		}
		set
		{
			method_63().Font = value;
		}
	}

	/// <summary>
	///       Represents the string in this TextBox object.
	///       </summary>
	public string Text
	{
		get
		{
			if (class1737_0 == null)
			{
				return null;
			}
			return method_63().Text;
		}
		set
		{
			method_63().Text = value;
		}
	}

	/// <summary>
	///       Gets and sets the html string which contains data and some formattings in this textbox.
	///       </summary>
	public string HtmlText
	{
		get
		{
			if (class1737_0 == null)
			{
				return null;
			}
			return method_63().HtmlString;
		}
		set
		{
			method_63().HtmlString = value;
		}
	}

	/// <summary>
	///       Gets and sets the text vertical overflow type of the shape which contains text.
	///       </summary>
	public TextOverflowType TextVerticalOverflow
	{
		get
		{
			return method_63().TextVerticalOverflow;
		}
		set
		{
			method_63().TextVerticalOverflow = value;
		}
	}

	/// <summary>
	///       Gets and sets the text horizontal overflow type of the shape which contains text.
	///       </summary>
	public TextOverflowType TextHorizontalOverflow
	{
		get
		{
			return method_63().TextHorizontalOverflow;
		}
		set
		{
			method_63().TextHorizontalOverflow = value;
		}
	}

	/// <summary>
	///        Gets and sets the text wrapped type of the shape which contains text.
	///       </summary>
	public bool IsTextWrapped
	{
		get
		{
			return method_63().bool_1;
		}
		set
		{
			method_63().bool_1 = value;
		}
	}

	/// <summary>
	///       Gets and sets the text orientation type of the shape.
	///       </summary>
	public TextOrientationType TextOrientationType
	{
		get
		{
			return method_63().TextOrientationType;
		}
		set
		{
			method_63().TextOrientationType = value;
		}
	}

	/// <summary>
	///       Gets and sets the text horizontal alignment type of the shape.
	///       </summary>
	public TextAlignmentType TextHorizontalAlignment
	{
		get
		{
			return method_63().TextHorizontalAlignment;
		}
		set
		{
			method_63().TextHorizontalAlignment = value;
		}
	}

	/// <summary>
	///       Gets and sets the text vertical alignment type of the shape.
	///       </summary>
	public TextAlignmentType TextVerticalAlignment
	{
		get
		{
			return method_63().TextVerticalAlignment;
		}
		set
		{
			method_63().TextVerticalAlignment = value;
		}
	}

	public GeomPathsInfo PathsInfo
	{
		get
		{
			if (geomPathsInfo_0 == null)
			{
				geomPathsInfo_0 = new GeomPathsInfo(this);
			}
			return geomPathsInfo_0;
		}
	}

	internal int Index
	{
		get
		{
			if (shapeCollection_0 == null)
			{
				return 0;
			}
			int num = 0;
			while (true)
			{
				if (num < shapeCollection_0.Count)
				{
					if (shapeCollection_0[num] == this)
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
	}

	internal Class1110 Style => class1110_0;

	internal ShapeCollection Shapes => shapeCollection_0;

	internal int Length
	{
		get
		{
			if (method_34())
			{
				return 90;
			}
			int num = method_27().Length + 8;
			if (IsGroup)
			{
				num += 8;
			}
			return num;
		}
	}

	internal GroupBox GroupBox
	{
		get
		{
			PlacementType placement = Placement;
			Placement = PlacementType.MoveAndSize;
			int upperLeftRow = UpperLeftRow;
			int upperDeltaY = UpperDeltaY;
			int upperLeftColumn = UpperLeftColumn;
			int upperDeltaX = UpperDeltaX;
			int lowerRightRow = LowerRightRow;
			int lowerDeltaY = LowerDeltaY;
			int lowerRightColumn = LowerRightColumn;
			int lowerDeltaX = LowerDeltaX;
			Placement = placement;
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			foreach (Shape shape in Shapes)
			{
				if (shape.MsoDrawingType != MsoDrawingType.GroupBox)
				{
					continue;
				}
				switch (shape.Placement)
				{
				case PlacementType.FreeFloating:
				{
					if (num == -1)
					{
						num = method_36();
						num2 = method_38();
						num3 = num2 + Width;
						num4 = num + Height;
					}
					int num5 = shape.method_36();
					int num6 = shape.method_38();
					int num7 = num6 + shape.Width;
					int num8 = num5 + shape.Height;
					if (num >= num5 && num4 <= num8 && num2 >= num6 && num3 <= num7)
					{
						return (GroupBox)shape;
					}
					break;
				}
				case PlacementType.Move:
				case PlacementType.MoveAndSize:
				{
					int upperLeftRow2 = shape.UpperLeftRow;
					int upperDeltaY2 = shape.UpperDeltaY;
					int upperLeftColumn2 = shape.UpperLeftColumn;
					int upperDeltaX2 = shape.UpperDeltaX;
					if ((upperLeftRow > upperLeftRow2 || (upperLeftRow == upperLeftRow2 && upperDeltaY >= upperDeltaY2)) && (upperLeftColumn > upperLeftColumn2 || (upperLeftColumn == upperLeftColumn2 && upperDeltaX >= upperDeltaX2)))
					{
						placement = shape.Placement;
						shape.Placement = PlacementType.MoveAndSize;
						int lowerRightRow2 = shape.LowerRightRow;
						int lowerDeltaY2 = shape.LowerDeltaY;
						int lowerRightColumn2 = shape.LowerRightColumn;
						int lowerDeltaX2 = shape.LowerDeltaX;
						shape.Placement = placement;
						if ((lowerRightRow < lowerRightRow2 || (lowerRightRow == lowerRightRow2 && lowerDeltaY <= lowerDeltaY2)) && (lowerRightColumn < lowerRightColumn2 || (lowerRightColumn == lowerRightColumn2 && lowerDeltaX <= lowerDeltaX2)))
						{
							return (GroupBox)shape;
						}
					}
					break;
				}
				}
			}
			return null;
		}
	}

	[SpecialName]
	internal string method_0()
	{
		if (string_0 == null && method_28() != null)
		{
			return method_28().method_1(method_25());
		}
		return string_0;
	}

	[SpecialName]
	internal void method_1(string string_4)
	{
		method_62(Enum169.const_3);
		string_0 = string_4;
	}

	internal Shape(ShapeCollection shapeCollection_1, MsoDrawingType msoDrawingType_0, object object_1)
	{
		shapeCollection_0 = shapeCollection_1;
		class1708_0 = new Class1708(msoDrawingType_0);
		class1714_0 = new Class1714(this, shapeCollection_0.method_4());
		object_0 = object_1;
		ushort_0 = 0;
		method_2();
		if (method_25().Workbook.method_24() && msoDrawingType_0 != MsoDrawingType.Picture)
		{
			class1110_0 = new Class1110(AutoShapeType);
		}
	}

	internal Shape(ShapeCollection shapeCollection_1, MsoDrawingType msoDrawingType_0, AutoShapeType autoShapeType_0, object object_1)
	{
		shapeCollection_0 = shapeCollection_1;
		if ((msoDrawingType_0 == MsoDrawingType.Unknown || msoDrawingType_0 == MsoDrawingType.CellsDrawing) && autoShapeType_0 != AutoShapeType.Unknown)
		{
			msoDrawingType_0 = ShapeCollection.smethod_0(autoShapeType_0);
		}
		class1708_0 = new Class1708(msoDrawingType_0);
		class1714_0 = new Class1714(this, shapeCollection_0.method_4());
		object_0 = object_1;
		ushort_0 = 0;
		if (msoDrawingType_0 != MsoDrawingType.CellsDrawing)
		{
			method_2();
		}
		else
		{
			method_27().method_9().method_1((short)autoShapeType_0);
			method_27().method_2().method_1(191, Enum183.const_0, 524296);
			method_27().method_2().method_1(385, Enum183.const_0, 134217793);
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
		}
		if (method_25().Workbook.method_24())
		{
			class1110_0 = new Class1110(AutoShapeType);
		}
	}

	private void method_2()
	{
		bool flag = method_25().Workbook.method_24();
		switch (MsoDrawingType)
		{
		case MsoDrawingType.Group:
			method_27().method_9().method_1(0);
			method_27().method_9().method_6(bool_0: true);
			method_27().method_2().method_1(127, Enum183.const_0, 262148);
			break;
		case MsoDrawingType.Line:
			method_27().method_9().method_1(20);
			method_27().method_2().method_1(191, Enum183.const_0, 524296);
			method_27().method_2().method_1(324, Enum183.const_0, 4);
			method_27().method_2().method_1(383, Enum183.const_0, 65536);
			method_27().method_2().method_1(447, Enum183.const_0, 1048576);
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			method_27().method_2().method_1(511, Enum183.const_0, 1048592);
			break;
		case MsoDrawingType.Rectangle:
			method_27().method_9().method_1(1);
			method_27().method_2().method_1(191, Enum183.const_0, 524296);
			method_27().method_2().method_1(385, Enum183.const_0, 134217793);
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			break;
		case MsoDrawingType.Oval:
			method_27().method_9().method_1(3);
			method_27().method_2().method_1(191, Enum183.const_0, 524296);
			method_27().method_2().method_1(385, Enum183.const_0, 134217793);
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			break;
		case MsoDrawingType.Arc:
			method_27().method_9().method_1(19);
			method_27().method_2().method_1(191, Enum183.const_0, 524296);
			method_27().method_2().method_1(385, Enum183.const_0, 134217793);
			method_27().method_2().method_1(447, Enum183.const_0, 1048576);
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			break;
		case MsoDrawingType.Chart:
			method_27().method_2().method_1(127, Enum183.const_0, 17039620);
			method_27().method_2().method_1(191, Enum183.const_0, 524296);
			method_27().method_2().method_1(385, Enum183.const_0, 134217806);
			method_27().method_2().method_1(387, Enum183.const_0, 134217805);
			method_27().method_2().method_1(447, Enum183.const_0, 1048592);
			method_27().method_2().method_1(448, Enum183.const_0, 134217805);
			method_27().method_2().method_1(511, Enum183.const_0, 524296);
			method_27().method_2().method_1(575, Enum183.const_0, 131072);
			method_27().method_9().method_1(201);
			break;
		case MsoDrawingType.TextBox:
			method_27().method_9().method_1(202);
			method_27().method_2().method_1(128, Enum183.const_0, 30019360);
			method_27().method_2().method_1(139, Enum183.const_0, 2);
			method_27().method_2().method_1(191, Enum183.const_0, 524296);
			if (flag)
			{
				Fill.Type = FillType.Solid;
				Fill.SolidFill.Color = Color.White;
				LineFormat.Weight = 0.75;
			}
			else
			{
				method_27().method_2().method_1(385, Enum183.const_0, 134217793);
			}
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			break;
		case MsoDrawingType.Button:
			method_27().method_9().method_1(201);
			method_27().method_2().method_1(127, Enum183.const_0, 16777472);
			method_27().method_2().method_1(128, Enum183.const_0, 30019308);
			method_27().method_2().method_1(133, Enum183.const_0, 1);
			method_27().method_2().method_1(139, Enum183.const_0, 2);
			method_27().method_2().method_1(191, Enum183.const_0, 1703944);
			method_27().method_2().method_1(385, Enum183.const_0, 134217793);
			method_27().method_2().method_1(447, Enum183.const_0, 1048576);
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			method_27().method_2().method_1(511, Enum183.const_0, 524288);
			break;
		case MsoDrawingType.Picture:
			method_27().method_9().method_1(75);
			method_27().method_2().method_1(511, Enum183.const_0, 1572864);
			break;
		case MsoDrawingType.CheckBox:
			method_27().method_9().method_1(201);
			method_27().method_2().method_1(127, Enum183.const_0, 16777472);
			method_27().method_2().method_1(128, Enum183.const_0, 30019320);
			method_27().method_2().method_1(133, Enum183.const_0, 1);
			method_27().method_2().method_1(139, Enum183.const_0, 2);
			method_27().method_2().method_1(191, Enum183.const_0, 1703944);
			method_27().method_2().method_1(383, Enum183.const_0, 2687017);
			if (flag)
			{
				Fill.Type = FillType.None;
			}
			else
			{
				method_27().method_2().method_1(385, Enum183.const_0, 134217793);
				method_27().method_2().method_1(447, Enum183.const_0, 1048576);
			}
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			method_27().method_2().method_1(511, Enum183.const_0, 524288);
			method_28().method_3(bool_5: false);
			method_28().method_5(bool_5: false);
			break;
		case MsoDrawingType.RadioButton:
			method_27().method_9().method_1(201);
			method_28().method_3(bool_5: false);
			method_28().method_5(bool_5: false);
			method_27().method_2().method_1(127, Enum183.const_0, 16777472);
			method_27().method_2().method_1(128, Enum183.const_0, 30019260);
			method_27().method_2().method_1(133, Enum183.const_0, 1);
			method_27().method_2().method_1(139, Enum183.const_0, 2);
			method_27().method_2().method_1(191, Enum183.const_0, 1703944);
			method_27().method_2().method_1(383, Enum183.const_0, 2687017);
			if (flag)
			{
				Fill.Type = FillType.None;
			}
			else
			{
				method_27().method_2().method_1(385, Enum183.const_0, 134217793);
				method_27().method_2().method_1(447, Enum183.const_0, 1048576);
			}
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			method_27().method_2().method_1(511, Enum183.const_0, 524416);
			break;
		case MsoDrawingType.Label:
			method_27().method_9().method_1(201);
			method_27().method_2().method_1(127, Enum183.const_0, 16777472);
			method_27().method_2().method_1(128, Enum183.const_0, 30019656);
			method_27().method_2().method_1(133, Enum183.const_0, 1);
			method_27().method_2().method_1(139, Enum183.const_0, 2);
			method_27().method_2().method_1(191, Enum183.const_0, 1703944);
			if (flag)
			{
				Fill.Type = FillType.None;
			}
			else
			{
				method_27().method_2().method_1(385, Enum183.const_0, 134217795);
				method_27().method_2().method_1(387, Enum183.const_0, 134217795);
				method_27().method_2().method_1(447, Enum183.const_0, 1114129);
			}
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			method_28().method_3(bool_5: false);
			method_28().method_5(bool_5: false);
			break;
		case MsoDrawingType.Spinner:
		case MsoDrawingType.ScrollBar:
			method_27().method_9().method_1(201);
			method_27().method_2().method_1(127, Enum183.const_0, 17039620);
			method_27().method_2().method_1(191, Enum183.const_0, 524296);
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			break;
		case MsoDrawingType.GroupBox:
			method_27().method_9().method_1(201);
			method_27().method_2().method_1(127, Enum183.const_0, 16777472);
			method_27().method_2().method_1(128, Enum183.const_0, 30019476);
			method_27().method_2().method_1(133, Enum183.const_0, 1);
			method_27().method_2().method_1(139, Enum183.const_0, 2);
			method_27().method_2().method_1(191, Enum183.const_0, 1703944);
			if (flag)
			{
				Fill.Type = FillType.None;
			}
			else
			{
				method_27().method_2().method_1(447, Enum183.const_0, 1048576);
			}
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			method_27().method_2().method_1(511, Enum183.const_0, 524416);
			method_28().method_3(bool_5: false);
			break;
		case MsoDrawingType.ListBox:
		case MsoDrawingType.ComboBox:
			method_27().method_9().method_1(201);
			method_28().method_5(bool_5: false);
			method_27().method_2().method_1(127, Enum183.const_0, 17039620);
			method_27().method_2().method_1(191, Enum183.const_0, 524296);
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			method_27().method_2().method_1(511, Enum183.const_0, 524416);
			break;
		default:
			method_27().method_9().method_1(201);
			break;
		case MsoDrawingType.OleObject:
			method_27().method_2().method_1(191, Enum183.const_0, 524296);
			method_27().method_2().method_1(385, Enum183.const_0, 134217793);
			method_27().method_2().method_1(387, Enum183.const_0, 134217793);
			method_27().method_2().method_1(447, Enum183.const_0, 1048592);
			method_27().method_2().method_1(448, Enum183.const_0, 134217792);
			method_27().method_2().method_1(511, Enum183.const_0, 524296);
			method_27().method_2().method_1(575, Enum183.const_0, 131072);
			method_27().method_9().method_8(bool_0: true);
			method_27().method_9().method_1(75);
			break;
		case MsoDrawingType.Comment:
			method_27().method_9().method_1(202);
			method_27().method_2().method_1(128, Enum183.const_0, 30347012);
			method_27().method_2().method_1(139, Enum183.const_0, 2);
			method_27().method_2().method_1(191, Enum183.const_0, 524296);
			method_27().method_2().method_1(344, Enum183.const_0, 0);
			if (flag)
			{
				Fill.Type = FillType.Solid;
				Fill.SolidFill.Color = Color.White;
				LineFormat.Weight = 0.75;
			}
			else
			{
				method_27().method_2().method_1(385, Enum183.const_0, 134217808);
				method_27().method_2().method_1(387, Enum183.const_0, 134217808);
				method_27().method_2().method_1(447, Enum183.const_0, 1048592);
			}
			method_27().method_2().method_1(513, Enum183.const_0, 0);
			method_27().method_2().method_1(575, Enum183.const_0, 196611);
			method_27().method_2().method_1(959, Enum183.const_0, 131074);
			break;
		}
	}

	internal Class1110 method_3()
	{
		return class1110_0;
	}

	internal void method_4(Class1110 class1110_1)
	{
		class1110_0 = class1110_1;
	}

	[SpecialName]
	internal int method_5()
	{
		if (IsGroup)
		{
			int num = 1;
			Shape[] groupedShapes = ((GroupShape)this).GetGroupedShapes();
			foreach (Shape shape in groupedShapes)
			{
				num += shape.method_5();
			}
			return num;
		}
		return 1;
	}

	[SpecialName]
	internal MsoFillFormatHelper method_6()
	{
		return new MsoFillFormatHelper(this, method_27().method_2(), method_25().Workbook);
	}

	internal FillFormat method_7()
	{
		return fillFormat_0;
	}

	internal void method_8()
	{
		if (fillFormat_0 == null)
		{
			fillFormat_0 = new FillFormat(new MsoFillFormatHelper(this, method_27().method_2(), method_25().Workbook), this, method_25().Workbook, bool_1: true);
			if (fillFormat_0.Type == FillType.Texture)
			{
				fillFormat_0.TextureFill.method_4(bool_0);
			}
		}
	}

	[SpecialName]
	internal Class1245 method_9()
	{
		if (class1245_0 == null)
		{
			class1245_0 = new Class1245(this, method_27().method_2());
		}
		return class1245_0;
	}

	internal Class1245 method_10()
	{
		return class1245_0;
	}

	[SpecialName]
	internal bool method_11()
	{
		switch (MsoDrawingType)
		{
		case MsoDrawingType.Rectangle:
			return ((RectangleShape)this).method_64() != null;
		case MsoDrawingType.Oval:
			return ((Oval)this).method_64() != null;
		case MsoDrawingType.Arc:
			return ((ArcShape)this).method_64() != null;
		default:
			return false;
		case MsoDrawingType.CellsDrawing:
			return ((CellsDrawing)this).method_64() != null;
		case MsoDrawingType.TextBox:
		case MsoDrawingType.Button:
		case MsoDrawingType.CheckBox:
		case MsoDrawingType.RadioButton:
		case MsoDrawingType.Label:
		case MsoDrawingType.GroupBox:
		case MsoDrawingType.Comment:
			return true;
		}
	}

	internal void method_12(double double_0)
	{
		method_27().method_2().method_8(4, (float)double_0);
	}

	/// <summary>
	///       Adds a hyperlink to the shape.
	///       </summary>
	/// <param name="address">Address of the hyperlink.</param>
	/// <returns>Return the new hyperlink object.</returns>
	public Hyperlink AddHyperlink(string address)
	{
		HyperlinkCollection hyperlinkCollection = new HyperlinkCollection(null);
		hyperlinkCollection.method_1(0, 0, 1, 1, address);
		method_27().method_2().method_1(50050, Enum183.const_3, hyperlinkCollection[0]);
		method_27().method_2().method_6(959, 3, bool_0: true);
		return hyperlinkCollection[0];
	}

	/// <summary>
	///       Remove the hyperlink of the shape.
	///       </summary>
	public void RemoveHyperlink()
	{
		method_27().method_2().Remove(50050);
		method_27().method_2().method_6(959, 3, bool_0: false);
	}

	[SpecialName]
	internal object method_13()
	{
		return object_0;
	}

	[SpecialName]
	internal void method_14(object object_1)
	{
		object_0 = object_1;
	}

	internal void Copy(Shape shape_0, CopyOptions copyOptions_0)
	{
		if (shape_0.class1556_0 != null)
		{
			class1556_0 = new Class1556();
			class1556_0.string_0 = shape_0.class1556_0.string_0;
			class1556_0.string_1 = shape_0.class1556_0.string_1;
			class1556_0.int_0 = shape_0.class1556_0.int_0;
		}
		m_linkedCell = Class1379.Copy(shape_0.method_25(), method_25(), shape_0.m_linkedCell, 0, 0, 0);
		method_27().Copy(shape_0.method_27());
		if (shape_0.fillFormat_0 != null)
		{
			Fill.Copy(shape_0.fillFormat_0);
		}
		if (shape_0.method_28() != null)
		{
			method_28().Copy(shape_0.method_28());
		}
		else
		{
			method_29(null);
		}
		method_1(shape_0.method_0());
		bool_1 = shape_0.bool_1;
		string_3 = shape_0.string_3;
		bool_1 = shape_0.bool_1;
		if (shape_0.class1737_0 != null)
		{
			class1737_0 = new Class1737(this);
			class1737_0.Copy(shape_0.class1737_0);
		}
		if (shape_0.class1110_0 != null)
		{
			class1110_0 = new Class1110(AutoShapeType);
			class1110_0.Copy(shape_0.class1110_0);
		}
		if (shape_0.class1245_0 == null || shape_0.class1245_0.arrayList_0 == null)
		{
			return;
		}
		foreach (Class1244 item in shape_0.class1245_0.arrayList_0)
		{
			Class1244 @class = new Class1244();
			@class.Copy(item);
			method_9().method_0().Add(@class);
		}
	}

	/// <summary>
	///       Moves the shape to a specified range.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="lowerRightRow">Lower right row index</param>
	/// <param name="lowerRightColumn">Lower right column index</param>
	public void MoveToRange(int upperLeftRow, int upperLeftColumn, int lowerRightRow, int lowerRightColumn)
	{
		PlacementType placement = Placement;
		method_27().method_7().method_8(upperLeftColumn);
		method_27().method_7().Left = 0;
		method_27().method_7().method_6(upperLeftRow);
		method_27().method_7().Top = 0;
		method_27().method_7().method_12(lowerRightColumn);
		method_27().method_7().Right = 0;
		method_27().method_7().method_10(lowerRightRow);
		method_27().method_7().Bottom = 0;
		if (placement != PlacementType.MoveAndSize)
		{
			method_27().method_7().method_4(PlacementType.MoveAndSize);
			Placement = placement;
		}
	}

	internal void method_15(int int_0, int int_1, int int_2, int int_3)
	{
		PlacementType placement = Placement;
		Placement = PlacementType.Move;
		int num = 0;
		if (int_1 != 0)
		{
			num = method_26().Cells.GetRowHeightPixel(int_0);
			int_1 = (int)((double)((float)int_1 * Class1698.float_1 / (float)num) + 0.5);
			method_27().method_7().method_6(int_0);
			method_27().method_7().Top = int_1;
		}
		else
		{
			method_27().method_7().method_6(int_0);
			method_27().method_7().Top = 0;
		}
		if (int_3 != 0)
		{
			num = method_26().Cells.GetViewColumnWidthPixel(int_2);
			int_3 = (int)((double)((float)int_3 * Class1698.float_0 / (float)num) + 0.5);
			method_27().method_7().method_8(int_2);
			method_27().method_7().Left = int_3;
		}
		else
		{
			method_27().method_7().method_8(int_2);
			method_27().method_7().Left = 0;
		}
		Placement = placement;
	}

	internal void method_16(int int_0, int int_1, int int_2, int int_3)
	{
		PlacementType placement = Placement;
		method_27().method_7().Left = int_0;
		method_27().method_7().Top = int_1;
		method_27().method_7().Right = ((int_2 + int_0 >= 4000) ? 4000 : (int_2 + int_0));
		method_27().method_7().Bottom = ((int_3 + int_1 >= 4000) ? 4000 : (int_3 + int_1));
		if (placement != PlacementType.MoveAndSize)
		{
			method_27().method_7().method_4(PlacementType.MoveAndSize);
			Placement = placement;
		}
	}

	internal void method_17(int int_0, int int_1, int int_2, int int_3)
	{
		method_27().method_7().method_4(PlacementType.FreeFloating);
		method_27().method_7().Top = int_1;
		method_27().method_7().Left = int_0;
		method_27().method_7().Right = int_2;
		method_27().method_7().Bottom = int_3;
	}

	internal void method_18(out int left, out int top, out int right, out int bottom)
	{
		PlacementType placement = Placement;
		if (placement != PlacementType.MoveAndSize)
		{
			Placement = PlacementType.MoveAndSize;
		}
		left = method_27().method_7().Left;
		top = method_27().method_7().Top;
		right = method_27().method_7().Right;
		bottom = method_27().method_7().Bottom;
		if (placement != PlacementType.MoveAndSize)
		{
			Placement = placement;
		}
	}

	internal void method_19(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		PlacementType placement = Placement;
		method_27().method_7().Right = int_5;
		method_27().method_7().Bottom = int_4;
		method_27().method_7().method_8(int_2);
		method_27().method_7().Left = int_3;
		method_27().method_7().method_6(int_0);
		method_27().method_7().Top = int_1;
		if (placement != PlacementType.Move)
		{
			method_27().method_7().method_4(PlacementType.Move);
			Placement = placement;
		}
	}

	internal void method_20(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		PlacementType placement = Placement;
		if (method_31())
		{
			method_27().method_7().Left = 0;
			method_27().method_7().Top = 0;
			if (placement == PlacementType.Move)
			{
				method_27().method_7().Right = int_5;
				method_27().method_7().Bottom = int_4;
			}
			else
			{
				ChartShape chartObject = ((Chart)Shapes.method_35()).ChartObject;
				method_27().method_7().Right = (int)((double)((float)int_5 * 4000f / (float)chartObject.Width) + 0.5);
				method_27().method_7().Bottom = (int)((double)((float)int_4 * 4000f / (float)chartObject.Height) + 0.5);
			}
		}
		else if (method_30())
		{
			ChartShape chartObject2 = ((Chart)Shapes.method_35()).ChartObject;
			int num = chartObject2.method_38();
			int num2 = chartObject2.method_36();
			int width = chartObject2.Width;
			int height = chartObject2.Height;
			int num3 = method_44(0, 0, int_2, 0) + int_3;
			int num4 = method_41(0, 0, int_0, 0) + int_1;
			if (num3 <= num)
			{
				method_27().method_7().Left = 0;
				if (int_5 >= width)
				{
					method_27().method_7().Right = 4000;
				}
				else
				{
					method_27().method_7().Right = (int)((double)((float)int_5 * 4000f / (float)width) + 0.5);
				}
			}
			else if (num3 >= num + int_5)
			{
				method_27().method_7().Left = 4000;
				method_27().method_7().Right = 4000;
			}
			else
			{
				int num5 = num3 - num;
				method_27().method_7().Left = (int)((double)((float)num5 * 4000f / (float)width) + 0.5);
				if (num5 + int_5 >= width)
				{
					method_27().method_7().Right = 4000;
				}
				else
				{
					method_27().method_7().Right = (int)((double)((float)int_5 * 4000f / (float)width) + 0.5);
				}
			}
			if (num4 <= num2)
			{
				method_27().method_7().Top = 0;
				if (int_4 >= height)
				{
					method_27().method_7().Bottom = 4000;
				}
				else
				{
					method_27().method_7().Bottom = (int)((double)((float)int_4 * 4000f / (float)height) + 0.5);
				}
			}
			else if (num4 >= num2 + int_5)
			{
				method_27().method_7().Top = 4000;
				method_27().method_7().Bottom = 4000;
			}
			else
			{
				int num6 = num4 - num2;
				method_27().method_7().Top = (int)((double)((float)num6 * 4000f / (float)width) + 0.5);
				if (num6 + int_4 >= height)
				{
					method_27().method_7().Bottom = 4000;
				}
				else
				{
					method_27().method_7().Bottom = (int)((double)((float)int_4 * 4000f / (float)height) + 0.5);
				}
			}
			method_27().method_7().method_4(PlacementType.MoveAndSize);
		}
		else
		{
			int rowHeightPixel = method_26().Cells.GetRowHeightPixel(int_0);
			int_1 = (int)((double)((float)int_1 * Class1698.float_1 / (float)rowHeightPixel) + 0.5);
			rowHeightPixel = method_26().Cells.GetViewColumnWidthPixel(int_2);
			int_3 = (int)((double)((float)int_3 * Class1698.float_0 / (float)rowHeightPixel) + 0.5);
			method_27().method_7().Right = int_5;
			method_27().method_7().Bottom = int_4;
			method_27().method_7().method_8(int_2);
			method_27().method_7().Left = int_3;
			method_27().method_7().method_6(int_0);
			method_27().method_7().Top = int_1;
			if (placement != PlacementType.Move)
			{
				method_27().method_7().method_4(PlacementType.Move);
				Placement = placement;
			}
		}
	}

	internal string method_21()
	{
		PlacementType placement = Placement;
		Placement = PlacementType.MoveAndSize;
		int num = method_27().method_7().method_7();
		int num2 = method_27().method_7().method_5();
		int num3 = method_26().Cells.method_15(num2);
		int num4 = (int)((double)((float)(method_27().method_7().Top * num3) / Class1698.float_1) + 0.5);
		num3 = method_26().Cells.method_17(num);
		int num5 = (int)((double)((float)(method_27().method_7().Left * num3) / Class1698.float_0) + 0.5);
		int num6 = method_27().method_7().method_11();
		int num7 = method_27().method_7().method_9();
		num3 = method_26().Cells.method_15(num7);
		int num8 = (int)((double)((float)(method_27().method_7().Bottom * num3) / Class1698.float_1) + 0.5);
		num3 = method_26().Cells.method_17(num6);
		int num9 = (int)((double)((float)(method_27().method_7().Right * num3) / Class1698.float_0) + 0.5);
		Placement = placement;
		return num + "," + num5 + "," + num2 + "," + num4 + "," + num6 + "," + num9 + "," + num7 + "," + num8;
	}

	internal void method_22(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7)
	{
		PlacementType placement = Placement;
		int num = method_26().Cells.method_15(int_0);
		int_1 = ((num > int_1) ? ((int)((double)((float)int_1 * Class1698.float_1 / (float)num) + 0.5)) : ((int)Class1698.float_1));
		num = method_26().Cells.method_17(int_2);
		int_3 = ((num > int_3) ? ((int)((double)((float)int_3 * Class1698.float_0 / (float)num) + 0.5)) : ((int)Class1698.float_0));
		method_27().method_7().method_8(int_2);
		method_27().method_7().Left = int_3;
		method_27().method_7().method_6(int_0);
		method_27().method_7().Top = int_1;
		num = method_26().Cells.method_15(int_4);
		int_5 = ((num > int_5) ? ((int)((double)((float)int_5 * Class1698.float_1 / (float)num) + 0.5)) : ((int)Class1698.float_1));
		if (int_6 < 16383)
		{
			num = method_26().Cells.method_17(int_6);
			int_7 = ((num > int_7) ? ((int)((double)((float)int_7 * Class1698.float_0 / (float)num) + 0.5)) : ((int)Class1698.float_0));
		}
		else
		{
			int_6 = 16383;
			int_7 = (int)Class1698.float_0;
		}
		method_27().method_7().method_12(int_6);
		method_27().method_7().Right = int_7;
		method_27().method_7().method_10(int_4);
		method_27().method_7().Bottom = int_5;
		if (placement != PlacementType.MoveAndSize)
		{
			method_27().method_7().method_4(PlacementType.MoveAndSize);
			Placement = placement;
		}
	}

	[SpecialName]
	internal ushort method_23()
	{
		return ushort_0;
	}

	[SpecialName]
	internal void method_24(ushort ushort_1)
	{
		ushort_0 = ushort_1;
	}

	[SpecialName]
	internal WorksheetCollection method_25()
	{
		return shapeCollection_0.method_36();
	}

	[SpecialName]
	internal Worksheet method_26()
	{
		return shapeCollection_0.method_37();
	}

	[SpecialName]
	internal Class1714 method_27()
	{
		return class1714_0;
	}

	[SpecialName]
	internal Class1708 method_28()
	{
		return class1708_0;
	}

	[SpecialName]
	internal void method_29(Class1708 class1708_1)
	{
		class1708_0 = class1708_1;
	}

	[SpecialName]
	internal bool method_30()
	{
		return shapeCollection_0.method_33();
	}

	[SpecialName]
	internal bool method_31()
	{
		if (shapeCollection_0.method_33())
		{
			return method_26().Type == SheetType.Chart;
		}
		return false;
	}

	[SpecialName]
	internal bool method_32()
	{
		return shapeCollection_0.method_34();
	}

	[SpecialName]
	internal bool method_33()
	{
		if (object_0 is Shape)
		{
			return ((Shape)object_0).IsGroup;
		}
		return false;
	}

	[SpecialName]
	internal bool method_34()
	{
		if (MsoDrawingType == MsoDrawingType.ComboBox && method_27().method_7().method_0())
		{
			return ((ComboBox)this).method_69() != null;
		}
		return false;
	}

	[SpecialName]
	internal Class931 method_35()
	{
		return new Class931(this);
	}

	[SpecialName]
	internal int method_36()
	{
		if (method_30())
		{
			return 0;
		}
		if (Placement == PlacementType.FreeFloating && !method_33())
		{
			return method_27().method_7().Top;
		}
		return method_41(0, 0, UpperLeftRow, UpperDeltaY);
	}

	[SpecialName]
	internal void method_37(int int_0)
	{
		if (!method_30() && !method_33())
		{
			PlacementType placement = Placement;
			Placement = PlacementType.FreeFloating;
			method_27().method_7().Top = int_0;
			Placement = placement;
		}
	}

	[SpecialName]
	internal int method_38()
	{
		if (method_30())
		{
			return 0;
		}
		if (Placement == PlacementType.FreeFloating && !method_33())
		{
			return method_27().method_7().Left;
		}
		return method_44(0, 0, UpperLeftColumn, UpperDeltaX);
	}

	[SpecialName]
	internal void method_39(int int_0)
	{
		if (!method_30() && !method_33())
		{
			PlacementType placement = Placement;
			Placement = PlacementType.FreeFloating;
			method_27().method_7().Left = int_0;
			Placement = placement;
		}
	}

	internal int[] method_40(int int_0, int int_1, int int_2)
	{
		int[] array = new int[2];
		if (int_2 == 0)
		{
			array[0] = int_0;
			array[1] = int_1;
			return array;
		}
		int num = 0;
		Cells cells = method_26().Cells;
		if (int_1 != 0)
		{
			num = cells.GetRowHeightPixel(int_0);
			int num2 = (int)((double)((float)num - (float)(num * int_1) / Class1698.float_1) + 0.5);
			if (int_2 <= num2)
			{
				array[0] = int_0;
				array[1] = (int)((double)((float)int_2 * Class1698.float_1 / (float)num + (float)int_1) + 0.5);
				return array;
			}
			int_0++;
			int_2 -= num2;
		}
		int num3 = (int)(cells.StandardHeight * (double)method_25().method_76() / 72.0 + 0.5);
		int arrIndex = 0;
		if (cells.Rows.Count != 0)
		{
			cells.Rows.method_15(int_0, out arrIndex);
			if (arrIndex >= cells.Rows.Count)
			{
				int num4 = (int)Math.Ceiling((double)int_2 / (double)num3);
				int_0 += num4 - 1;
				int_2 -= num3 * num4;
				num = num3;
			}
			else
			{
				Row rowByIndex = cells.Rows.GetRowByIndex(arrIndex);
				while (int_0 <= 1048575)
				{
					if (rowByIndex.int_0 == int_0)
					{
						num = (int)(rowByIndex.Height * (double)method_25().method_76() / 72.0 + 0.5);
						int_2 -= num;
						if (int_2 <= 0)
						{
							break;
						}
						arrIndex++;
						if (arrIndex >= cells.Rows.Count)
						{
							int num5 = (int)Math.Ceiling((double)int_2 / (double)num3);
							int_0 += num5;
							int_2 -= num3 * num5;
							num = num3;
							break;
						}
						rowByIndex = cells.Rows.GetRowByIndex(arrIndex);
					}
					else
					{
						num = num3;
						int_2 -= num;
						if (int_2 <= 0)
						{
							break;
						}
					}
					int_0++;
				}
			}
		}
		else
		{
			int num6 = (int)Math.Ceiling((double)int_2 / (double)num3);
			int_0 += num6 - 1;
			int_2 -= num3 * num6;
			num = num3;
		}
		if (int_2 <= 0 && (int_2 != 0 || int_0 != 1048575))
		{
			if (int_2 == 0)
			{
				array[0] = int_0 + 1;
			}
			else
			{
				array[0] = int_0;
				array[1] = (int)((double)((float)(int_2 + num) * Class1698.float_1 / (float)num) + 0.5);
			}
			return array;
		}
		array[0] = 1048575;
		array[1] = (int)Class1698.float_1;
		return array;
	}

	internal int method_41(int int_0, int int_1, int int_2, int int_3)
	{
		int num = 0;
		int num2 = 0;
		Cells cells = method_26().Cells;
		if ((float)int_1 >= Class1698.float_1)
		{
			int_1 = (int)Class1698.float_1;
		}
		if ((float)int_3 >= Class1698.float_1)
		{
			int_3 = (int)Class1698.float_1;
		}
		if (int_2 == int_0)
		{
			num2 = cells.GetRowHeightPixel(int_0);
			return (int)((double)((float)((int_3 - int_1) * num2) / Class1698.float_1) + 0.5);
		}
		if (int_2 < int_0)
		{
			return 0;
		}
		num2 = cells.GetRowHeightPixel(int_0);
		num += num2 - (int)((double)((float)(int_1 * num2) / Class1698.float_1) + 0.5);
		int num3 = int_0;
		int_0++;
		int i = 0;
		int num4 = 0;
		cells.Rows.method_15(int_0, out i);
		for (; i < cells.Rows.Count; i++)
		{
			Row rowByIndex = cells.Rows.GetRowByIndex(i);
			if (rowByIndex.int_0 >= int_0)
			{
				if (rowByIndex.int_0 >= int_2)
				{
					break;
				}
				num4++;
				num += (int)(rowByIndex.Height * (double)method_25().method_76() / 72.0 + 0.5);
			}
		}
		int num5 = int_2 - num3 - 1 - num4;
		if (num5 > 0 && !cells.method_25())
		{
			num += num5 * (int)(cells.StandardHeight * (double)method_25().method_76() / 72.0 + 0.5);
		}
		num2 = cells.GetRowHeightPixel(int_2);
		return num + (int)((double)((float)(int_3 * num2) / Class1698.float_1) + 0.5);
	}

	internal int method_42(int int_0, int int_1, int int_2, int int_3)
	{
		int num = 0;
		int num2 = 0;
		Cells cells = method_26().Cells;
		if (int_2 == int_0)
		{
			num2 = cells.method_15(int_0);
			return (int)((double)((float)((int_3 - int_1) * num2) / Class1698.float_1) + 0.5);
		}
		num2 = cells.method_15(int_0);
		num += num2 - (int)((double)((float)(int_1 * num2) / Class1698.float_1) + 0.5);
		int num3 = int_0;
		int_0++;
		int i = 0;
		int num4 = 0;
		cells.Rows.method_15(int_0, out i);
		for (; i < cells.Rows.Count; i++)
		{
			Row rowByIndex = cells.Rows.GetRowByIndex(i);
			if (rowByIndex.int_0 >= int_0)
			{
				if (rowByIndex.int_0 >= int_2)
				{
					break;
				}
				num4++;
				num += (int)((double)(rowByIndex.method_13() * method_25().method_76() / 1440) + 0.5);
			}
		}
		int num5 = int_2 - num3 - 1 - num4;
		if (num5 > 0)
		{
			num += num5 * (int)(cells.StandardHeight * (double)method_25().method_76() / 72.0 + 0.5);
		}
		num2 = cells.method_15(int_2);
		return num + (int)((double)((float)(int_3 * num2) / Class1698.float_1) + 0.5);
	}

	internal int method_43(int int_0, int int_1, int int_2, int int_3)
	{
		int num = 0;
		int num2 = 0;
		Cells cells = method_26().Cells;
		if (int_2 == int_0)
		{
			num2 = cells.method_17(int_0);
			return (int)((double)((float)((int_3 - int_1) * num2) / Class1698.float_0) + 0.5);
		}
		num2 = cells.method_17(int_0);
		num += num2 - (int)((double)((float)(int_1 * num2) / Class1698.float_0) + 0.5);
		int num3 = int_0;
		int_0++;
		int num4 = 0;
		cells.Columns.method_8(int_0, out var i);
		for (; i < cells.Columns.Count; i++)
		{
			Column columnByIndex = cells.Columns.GetColumnByIndex(i);
			if (columnByIndex.Index >= int_0)
			{
				if (columnByIndex.Index >= int_2)
				{
					break;
				}
				num4++;
				if (!columnByIndex.IsHidden)
				{
					num += Class1677.smethod_1(columnByIndex.Width, method_25());
				}
			}
		}
		num += cells.Columns.method_4(num3 + num4 + 1, int_2 - 1, bool_0: true, bool_1: true);
		num2 = cells.method_17(int_2);
		return num + (int)((double)((float)(int_3 * num2) / Class1698.float_0) + 0.5);
	}

	internal int method_44(int int_0, int int_1, int int_2, int int_3)
	{
		int num = 0;
		int num2 = 0;
		Cells cells = method_26().Cells;
		if (int_2 == int_0)
		{
			num2 = cells.GetViewColumnWidthPixel(int_0);
			return (int)((double)((float)((int_3 - int_1) * num2) / Class1698.float_0) + 0.5);
		}
		if (int_2 < int_0)
		{
			return 0;
		}
		num2 = cells.GetViewColumnWidthPixel(int_0);
		num += num2 - (int)((double)((float)(int_1 * num2) / Class1698.float_0) + 0.5);
		int num3 = int_0;
		int_0++;
		int num4 = 0;
		cells.Columns.method_8(int_0, out var i);
		for (; i < cells.Columns.Count; i++)
		{
			Column columnByIndex = cells.Columns.GetColumnByIndex(i);
			if (columnByIndex.Index >= int_0)
			{
				if (columnByIndex.Index >= int_2)
				{
					break;
				}
				num4++;
				if (!columnByIndex.IsHidden)
				{
					num += Class1677.smethod_1(columnByIndex.Width, method_25());
				}
			}
		}
		num += cells.Columns.method_4(num3 + num4 + 1, int_2 - 1, bool_0: false, bool_1: true);
		num2 = cells.GetViewColumnWidthPixel(int_2);
		return num + (int)((double)((float)(int_3 * num2) / Class1698.float_0) + 0.5);
	}

	internal int[] method_45(int int_0, int int_1, int int_2)
	{
		int[] array = new int[2];
		int num = 0;
		Cells cells = method_26().Cells;
		if (int_1 != 0)
		{
			num = cells.GetViewColumnWidthPixel(int_0);
			int num2 = (int)((double)((float)num - (float)(num * int_1) / Class1698.float_0) + 0.5);
			if (int_2 <= num2)
			{
				array[0] = int_0;
				array[1] = (int)((double)((float)int_2 * Class1698.float_0 / (float)num + (float)int_1) + 0.5);
				return array;
			}
			int_0++;
			int_2 -= num2;
		}
		int arrIndex = 0;
		cells.Columns.method_8(int_0, out arrIndex);
		while (true)
		{
			double num3 = 0.0;
			if (arrIndex >= cells.Columns.Count)
			{
				num3 = cells.Columns.method_3(int_0, bool_0: false);
			}
			else
			{
				Column columnByIndex = cells.Columns.GetColumnByIndex(arrIndex);
				if (columnByIndex.Index == int_0)
				{
					arrIndex++;
					num3 = (columnByIndex.IsHidden ? 0.0 : columnByIndex.double_0);
				}
				else
				{
					num3 = cells.Columns.method_3(int_0, bool_0: false);
				}
			}
			num = Class1677.smethod_1(num3, method_25());
			int_2 -= num;
			if (int_2 <= 0)
			{
				break;
			}
			int_0++;
			if (int_0 > 16383)
			{
				array[0] = 16383;
				array[1] = (int)Class1698.float_0;
				return array;
			}
		}
		if (int_2 <= 0 && (int_2 != 0 || int_0 != 16383))
		{
			if (int_2 == 0)
			{
				array[0] = int_0 + 1;
			}
			else
			{
				array[0] = int_0;
				array[1] = (int)((double)((float)(int_2 + num) * Class1698.float_0 / (float)num) + 0.5);
			}
			return array;
		}
		array[0] = 16383;
		array[1] = (int)Class1698.float_0;
		return array;
	}

	internal int[] method_46(int int_0, int int_1, int int_2)
	{
		int[] array = new int[2];
		int num = 0;
		Cells cells = method_26().Cells;
		if (int_1 != 0)
		{
			num = cells.GetRowHeightPixel(int_0);
			int num2 = (int)((double)((float)(num * int_1) / Class1698.float_1) + 0.5);
			if (int_2 <= num2)
			{
				array[0] = int_0;
				array[1] = (int)((double)((float)(num2 - int_2) * Class1698.float_1 / (float)num + (float)int_1) + 0.5);
				return array;
			}
			int_2 -= num2;
		}
		for (int_0--; int_0 >= 0; int_0--)
		{
			num = cells.GetRowHeightPixel(int_0);
			int_2 -= num;
			if (int_2 <= 0)
			{
				break;
			}
		}
		if (int_2 <= 0 && (int_2 != 0 || int_0 > 0))
		{
			if (int_2 == 0)
			{
				array[0] = int_0;
			}
			else
			{
				array[0] = int_0;
				array[1] = (int)((double)((float)(-int_2) * Class1698.float_1 / (float)num) + 0.5);
			}
			return array;
		}
		return array;
	}

	internal int[] method_47(int int_0, int int_1, int int_2)
	{
		int[] array = new int[2];
		if (int_2 == 0)
		{
			array[0] = int_0;
			array[1] = int_1;
			return array;
		}
		int num = 0;
		Cells cells = method_26().Cells;
		if (int_1 != 0)
		{
			num = cells.GetViewColumnWidthPixel(int_0);
			int num2 = (int)((double)((float)(num * int_1) / Class1698.float_0) + 0.5);
			if (int_2 <= num2)
			{
				array[0] = int_0;
				array[1] = (int)((double)((float)(num2 - int_2) * Class1698.float_0 / (float)num + (float)int_1) + 0.5);
				return array;
			}
			int_2 -= num2;
		}
		for (int_0--; int_0 >= 0; int_0--)
		{
			num = cells.GetViewColumnWidthPixel(int_0);
			int_2 -= num;
			if (int_2 <= 0)
			{
				break;
			}
		}
		if (int_2 <= 0 && (int_2 != 0 || int_0 > 0))
		{
			array[0] = int_0;
			if (int_2 != 0)
			{
				array[0] = int_0;
				array[1] = (int)((double)((float)(-int_2) * Class1698.float_0 / (float)num) + 0.5);
			}
			return array;
		}
		return array;
	}

	private int method_48(double double_0)
	{
		return (int)(double_0 * (double)method_25().method_75() + 0.5);
	}

	internal double method_49(double double_0)
	{
		return double_0 / (double)method_25().method_75();
	}

	private int method_50(double double_0)
	{
		return (int)(double_0 * (double)method_25().method_75() / 2.5399999618530273 + 0.5);
	}

	internal double method_51(int int_0)
	{
		return (double)int_0 * 2.5399999618530273 / (double)method_25().method_75();
	}

	[SpecialName]
	private bool method_52()
	{
		if (MsoDrawingType == MsoDrawingType.Chart && this == method_26().Charts[0].ChartObject)
		{
			return method_26().Type == SheetType.Chart;
		}
		return false;
	}

	internal int method_53(byte[] byte_0, int int_0, Class1114 class1114_0)
	{
		byte_0[int_0 + 2] = 15;
		byte_0[int_0 + 3] = 240;
		byte_0[int_0 + 4] = 16;
		int_0 += 8;
		int num = class1114_0.int_0 + (int)((double)((float)class1114_0.int_1 * ((float)method_27().method_7().Left / 4000f)) + 0.5);
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, int_0, 4);
		int_0 += 4;
		int num2 = class1114_0.int_2 + (int)((double)((float)class1114_0.int_3 * ((float)method_27().method_7().Top / 4000f)) + 0.5);
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_0, 4);
		int_0 += 4;
		int num3 = 0;
		num3 = (int)((double)((float)class1114_0.int_1 * ((float)method_27().method_7().Right / 4000f)) + 0.5) + num;
		Array.Copy(BitConverter.GetBytes(num3), 0, byte_0, int_0, 4);
		int_0 += 4;
		num3 = (int)((double)((float)class1114_0.int_3 * ((float)method_27().method_7().Bottom / 4000f)) + 0.5) + num2;
		Array.Copy(BitConverter.GetBytes(num3), 0, byte_0, int_0, 4);
		int_0 += 4;
		byte_0[int_0 + 2] = 17;
		byte_0[int_0 + 3] = 240;
		int_0 += 8;
		return 32;
	}

	internal int method_54(byte[] byte_0, int int_0)
	{
		byte_0[int_0 + 2] = 16;
		byte_0[int_0 + 3] = 240;
		byte_0[int_0 + 4] = 18;
		int_0 += 8;
		switch (method_27().method_7().method_3())
		{
		default:
			if (method_27().method_7().method_0())
			{
				byte_0[int_0] = 1;
			}
			break;
		case PlacementType.FreeFloating:
			byte_0[int_0] = 3;
			break;
		case PlacementType.Move:
			byte_0[int_0] = 2;
			break;
		}
		int_0 += 2;
		if (Placement != PlacementType.MoveAndSize)
		{
			int top = method_27().method_7().Top;
			int left = method_27().method_7().Left;
			int bottom = method_27().method_7().Bottom;
			int right = method_27().method_7().Right;
			int int_ = method_27().method_7().method_5();
			int int_2 = method_27().method_7().method_7();
			int int_3 = method_27().method_7().method_9();
			int int_4 = method_27().method_7().method_11();
			PlacementType placement = Placement;
			Placement = PlacementType.MoveAndSize;
			int_0 = method_55(byte_0, int_0);
			method_27().method_7().Top = top;
			method_27().method_7().method_6(int_);
			method_27().method_7().Left = left;
			method_27().method_7().method_8(int_2);
			method_27().method_7().Bottom = bottom;
			method_27().method_7().method_10(int_3);
			method_27().method_7().Right = right;
			method_27().method_7().method_12(int_4);
			method_27().method_7().method_4(placement);
		}
		else
		{
			int_0 = method_55(byte_0, int_0);
		}
		byte_0[int_0 + 2] = 17;
		byte_0[int_0 + 3] = 240;
		int_0 += 8;
		return 34;
	}

	internal int method_55(byte[] byte_0, int int_0)
	{
		if (method_30())
		{
			Array.Copy(BitConverter.GetBytes(method_27().method_7().Left), 0, byte_0, int_0, 4);
			int_0 += 4;
			Array.Copy(BitConverter.GetBytes(method_27().method_7().Top), 0, byte_0, int_0, 4);
			int_0 += 4;
			Array.Copy(BitConverter.GetBytes(method_27().method_7().Right), 0, byte_0, int_0, 4);
			int_0 += 4;
			Array.Copy(BitConverter.GetBytes(method_27().method_7().Bottom), 0, byte_0, int_0, 4);
			int_0 += 4;
		}
		else
		{
			if (method_27().method_7().method_7() > 255)
			{
				byte_0[int_0] = byte.MaxValue;
				byte_0[int_0 + 1] = 0;
				byte_0[int_0 + 2] = 0;
				byte_0[int_0 + 3] = 4;
			}
			else
			{
				Array.Copy(BitConverter.GetBytes((ushort)method_27().method_7().method_7()), 0, byte_0, int_0, 2);
				Array.Copy(BitConverter.GetBytes((ushort)method_27().method_7().Left), 0, byte_0, int_0 + 2, 2);
			}
			int_0 += 4;
			if (method_27().method_7().method_5() > 65535)
			{
				byte_0[int_0] = byte.MaxValue;
				byte_0[int_0 + 1] = byte.MaxValue;
				byte_0[int_0 + 2] = 0;
				byte_0[int_0 + 3] = 1;
			}
			else
			{
				Array.Copy(BitConverter.GetBytes((ushort)method_27().method_7().method_5()), 0, byte_0, int_0, 2);
				Array.Copy(BitConverter.GetBytes((ushort)method_27().method_7().Top), 0, byte_0, int_0 + 2, 2);
			}
			int_0 += 4;
			if (method_27().method_7().method_11() > 255)
			{
				byte_0[int_0] = byte.MaxValue;
				byte_0[int_0 + 1] = 0;
				byte_0[int_0 + 2] = 0;
				byte_0[int_0 + 3] = 4;
			}
			else
			{
				Array.Copy(BitConverter.GetBytes((ushort)method_27().method_7().method_11()), 0, byte_0, int_0, 2);
				Array.Copy(BitConverter.GetBytes((ushort)method_27().method_7().Right), 0, byte_0, int_0 + 2, 2);
			}
			int_0 += 4;
			if (method_27().method_7().method_9() > 65535)
			{
				byte_0[int_0] = byte.MaxValue;
				byte_0[int_0 + 1] = byte.MaxValue;
				byte_0[int_0 + 2] = 0;
				byte_0[int_0 + 3] = 1;
			}
			else
			{
				Array.Copy(BitConverter.GetBytes((ushort)method_27().method_7().method_9()), 0, byte_0, int_0, 2);
				Array.Copy(BitConverter.GetBytes((ushort)method_27().method_7().Bottom), 0, byte_0, int_0 + 2, 2);
			}
			int_0 += 4;
		}
		return int_0;
	}

	/// <summary>
	///       Creates the shape image and saves it to a stream in the specified format.
	///       </summary>
	/// <param name="stream">The output stream.</param>
	/// <param name="imageFormat">The format in which to save the image.</param>
	/// <remarks>
	///   <p>The following formats are supported: 
	///       .bmp, .gif, .jpg, .jpeg, .tiff, .emf.</p>
	/// </remarks>
	public void ToImage(Stream stream, ImageFormat imageFormat)
	{
		if (method_25().Workbook.method_23())
		{
			Class912.ToImage(stream, imageFormat, this);
		}
		else
		{
			Class897.ToImage(stream, imageFormat, this);
		}
	}

	/// <summary>
	///       Saves the shape to a file.
	///       </summary>
	public void ToImage(string imageFile, ImageOrPrintOptions options)
	{
		if (method_25().Workbook.method_23())
		{
			Class912.ToImage(imageFile, options, this);
		}
		else
		{
			Class897.ToImage(imageFile, options, this);
		}
	}

	/// <summary>
	///       Saves the shape to a stream.
	///       </summary>
	public void ToImage(Stream stream, ImageOrPrintOptions options)
	{
		if (method_25().Workbook.method_23())
		{
			Class912.ToImage(stream, options, this);
		}
		else
		{
			Class897.ToImage(stream, options, this);
		}
	}

	/// <summary>
	///       Returns the bitmap object of the shape .
	///       </summary>
	public Bitmap ToImage(ImageOrPrintOptions options)
	{
		if (method_25().Workbook.method_23())
		{
			return Class912.ToImage(options, this);
		}
		return Class897.ToImage(options, this);
	}

	internal PointF method_56(Stream stream_0, ImageOrPrintOptions imageOrPrintOptions_0)
	{
		if (method_25().Workbook.method_23())
		{
			return Class912.smethod_0(stream_0, imageOrPrintOptions_0, this);
		}
		return Class897.smethod_0(stream_0, imageOrPrintOptions_0, this);
	}

	[SpecialName]
	internal RectangleF method_57()
	{
		if (!bool_2)
		{
			if (method_25().Workbook.method_23())
			{
				rectangleF_0 = Class912.Calculate(this);
			}
			else
			{
				rectangleF_0 = Class897.Calculate(this);
			}
			bool_2 = true;
		}
		return rectangleF_0;
	}

	[SpecialName]
	internal byte[] method_58()
	{
		return m_linkedCell;
	}

	[SpecialName]
	internal void method_59(byte[] byte_0)
	{
		m_linkedCell = byte_0;
	}

	internal Cell method_60()
	{
		Cell result = null;
		if (method_58() != null)
		{
			byte[] array = m_linkedCell;
			byte b = array[0];
			if (b == 35 || b == 67 || b == 99)
			{
				int index = BitConverter.ToInt16(array, 1) - 1;
				Name name = method_25().Names[index];
				byte[] array2 = name.method_2();
				if (method_25().Workbook.method_24())
				{
					array = new byte[array2.Length - 8];
					Array.Copy(array2, 4, array, 0, array.Length);
				}
				else
				{
					array = new byte[array2.Length - 2];
					Array.Copy(array2, 2, array, 0, array.Length);
				}
			}
			Cells cells = method_26().Cells;
			int num = Class1674.smethod_4(method_25(), array, 0);
			if (num != -1)
			{
				int num2 = method_25().method_32().method_13(num);
				if (num2 < 0 || num2 >= method_25().Count)
				{
					return null;
				}
				cells = method_25()[num2].Cells;
			}
			bool isArea = false;
			CellArea cellArea = Class1279.smethod_2(method_25(), array, 0, 0, 0, out isArea);
			if (isArea)
			{
				return cells.GetCell(cellArea.StartRow, cellArea.StartColumn, bool_2: false);
			}
		}
		return result;
	}

	internal void method_61(string string_4)
	{
		method_62(Enum169.const_4);
		if (string_4 != null && !(string_4 == ""))
		{
			bool isValid = false;
			byte[] linkedCell = Class1675.smethod_1(method_25(), method_26().Index, string_4, externRef: false, validName: true, convertName: false, out isValid);
			if (isValid)
			{
				m_linkedCell = linkedCell;
			}
			else
			{
				int[] array = method_25().Names.method_10(method_26().Index, string_4, bool_0: false, bool_1: false);
				int num = array[1];
				if (num != -1)
				{
					linkedCell = new byte[5] { 35, 0, 0, 0, 0 };
					Array.Copy(BitConverter.GetBytes(num + 1), 0, linkedCell, 1, 2);
					m_linkedCell = linkedCell;
				}
				else
				{
					m_linkedCell = null;
				}
			}
			if (MsoDrawingType == MsoDrawingType.ComboBox)
			{
				ComboBox comboBox = (ComboBox)this;
				comboBox.string_4 = null;
			}
		}
		else
		{
			m_linkedCell = null;
		}
	}

	/// <summary>
	///       Update the selected value by the value of the linked cell.
	///       </summary>
	public void UpdateSelectedValue()
	{
		if (MsoDrawingType == MsoDrawingType.Picture)
		{
			if (string_3 == null || !(string_3 != ""))
			{
				return;
			}
			Range range = method_25().GetRangeByName(string_3);
			if (range == null)
			{
				try
				{
					int num = string_3.LastIndexOf('!');
					if (num != -1)
					{
						string text = string_3.Substring(0, num);
						int[] array = Class1660.smethod_3(method_25(), text);
						if (array[1] == method_25().method_36() && array[2] < method_25().Count && array[2] >= 0)
						{
							range = method_25()[array[2]].Cells.CreateRange(string_3.Substring(num + 1));
						}
					}
					else
					{
						range = method_26().Cells.CreateRange(string_3);
					}
				}
				catch
				{
				}
			}
			if (range != null)
			{
				Picture picture = (Picture)this;
				picture.Data = null;
				Worksheet worksheet = range.Worksheet;
				string printArea = worksheet.PageSetup.PrintArea;
				worksheet.PageSetup.PrintArea = range.method_1();
				ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
				imageOrPrintOptions.OnlyArea = true;
				imageOrPrintOptions.ImageFormat = ImageFormat.Png;
				SheetRender sheetRender = new SheetRender(worksheet, imageOrPrintOptions);
				MemoryStream memoryStream = new MemoryStream();
				sheetRender.ToImage(0, memoryStream);
				picture.Data = memoryStream.ToArray();
				memoryStream.Close();
				range.Worksheet.PageSetup.PrintArea = printArea;
			}
			return;
		}
		Cell cell = method_60();
		if (cell == null)
		{
			return;
		}
		double num2 = 0.0;
		string stringValue = cell.StringValue;
		switch (cell.Type)
		{
		case CellValueType.IsBool:
			num2 = (cell.BoolValue ? 1 : 0);
			break;
		case CellValueType.IsDateTime:
		case CellValueType.IsNumeric:
			num2 = Math.Floor(cell.DoubleValue);
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
			break;
		}
		switch (MsoDrawingType)
		{
		case MsoDrawingType.CheckBox:
			switch (cell.Type)
			{
			case CellValueType.IsBool:
			{
				bool boolValue = cell.BoolValue;
				((CheckBox)this).method_69(boolValue ? CheckValueType.Checked : CheckValueType.UnChecked);
				break;
			}
			case CellValueType.IsError:
				if (cell.StringValue == "#N/A")
				{
					((CheckBox)this).method_69(CheckValueType.Mixed);
				}
				break;
			case CellValueType.IsDateTime:
			case CellValueType.IsNumeric:
				num2 = Math.Ceiling(cell.DoubleValue);
				((CheckBox)this).method_69((num2 != 0.0) ? CheckValueType.Checked : CheckValueType.UnChecked);
				break;
			case CellValueType.IsNull:
				break;
			}
			break;
		case MsoDrawingType.RadioButton:
		{
			int num7 = (int)(num2 - 1.0);
			GroupBox groupBox = GroupBox;
			int num8 = 0;
			if (groupBox != null)
			{
				ArrayList arrayList = groupBox.method_69();
				for (int i = 0; i < arrayList.Count; i++)
				{
					if (((Shape)arrayList[i]).MsoDrawingType == MsoDrawingType.RadioButton)
					{
						if (num8 == num7)
						{
							((RadioButton)arrayList[i]).method_69(bool_5: true);
						}
						else
						{
							((RadioButton)arrayList[i]).method_69(bool_5: false);
						}
						num8++;
					}
				}
				break;
			}
			for (int j = 0; j < shapeCollection_0.Count; j++)
			{
				if (shapeCollection_0[j].MsoDrawingType != MsoDrawingType.RadioButton)
				{
					continue;
				}
				groupBox = shapeCollection_0[j].GroupBox;
				if (groupBox == null)
				{
					if (num8 == num7)
					{
						((RadioButton)shapeCollection_0[j]).method_69(bool_5: true);
					}
					else
					{
						((RadioButton)shapeCollection_0[j]).method_69(bool_5: false);
					}
					num8++;
				}
			}
			break;
		}
		case MsoDrawingType.Spinner:
			((Spinner)this).method_69((int)num2);
			break;
		case MsoDrawingType.ScrollBar:
		{
			ScrollBar scrollBar = (ScrollBar)this;
			int num5 = (int)num2;
			if (num5 > scrollBar.Max)
			{
				num5 = scrollBar.Max;
			}
			else if (num5 < scrollBar.Min)
			{
				num5 = scrollBar.Min;
			}
			((ScrollBar)this).method_69(num5);
			break;
		}
		case MsoDrawingType.ListBox:
		{
			ListBox listBox = (ListBox)this;
			int itemCount = listBox.ItemCount;
			int num6 = (int)(num2 - 1.0);
			if (num6 >= itemCount)
			{
				num6 = itemCount - 1;
			}
			((ListBox)this).method_71(num6);
			break;
		}
		case MsoDrawingType.ComboBox:
		{
			ComboBox comboBox = (ComboBox)this;
			int num3 = comboBox.method_72();
			int num4 = (int)(num2 - 1.0);
			if (num4 >= num3)
			{
				num4 = num3 - 1;
			}
			comboBox.method_73(num4);
			break;
		}
		case MsoDrawingType.TextBox:
			((TextBox)this).method_63().method_4(stringValue);
			break;
		}
	}

	internal void method_62(Enum169 enum169_0)
	{
		if (class1556_0 != null && class1556_0.class1230_0 != null)
		{
			class1556_0.class1230_0.method_1(enum169_0);
		}
	}

	[SpecialName]
	internal Class1737 method_63()
	{
		if (class1737_0 == null)
		{
			class1737_0 = new Class1737(this);
		}
		return class1737_0;
	}

	internal Class1737 method_64()
	{
		return class1737_0;
	}

	public void FormatCharacters(int startIndex, int length, Font font)
	{
		if (startIndex == 0 && length == Text.Length)
		{
			Font = font;
			if (method_63().method_12() != null)
			{
				class1737_0.method_12().Clear();
			}
		}
		else
		{
			FontSetting fontSetting = method_63().Characters(startIndex, length);
			fontSetting.method_3(font);
		}
	}

	public FontSetting Characters(int startIndex, int length)
	{
		return method_63().Characters(startIndex, length);
	}

	public ArrayList GetCharacters()
	{
		return method_63().method_12();
	}

	[SpecialName]
	internal string method_65()
	{
		return string_3;
	}

	[SpecialName]
	internal void method_66(string string_4)
	{
		string_3 = string_4;
	}

	internal int[] method_67(double double_0)
	{
		int[] array = new int[4];
		if (double_0 < 0.0)
		{
			double_0 += 360.0;
		}
		int num = Math.Abs(Width - Height);
		if (Width > Height)
		{
			if ((double_0 >= 45.0 && double_0 < 135.0) || (double_0 >= 225.0 && double_0 < 315.0))
			{
				array[0] = X + num / 2;
				array[1] = Y - num / 2;
				array[2] = Height;
				array[3] = Width;
			}
			else
			{
				array[0] = X;
				array[1] = Y;
				array[2] = Width;
				array[3] = Height;
			}
		}
		else if ((double_0 >= 45.0 && double_0 < 135.0) || (double_0 >= 225.0 && double_0 < 315.0))
		{
			array[0] = X - num / 2;
			array[1] = Y + num / 2;
			array[2] = Height;
			array[3] = Width;
		}
		else
		{
			array[0] = X;
			array[1] = Y;
			array[2] = Width;
			array[3] = Height;
		}
		return array;
	}

	internal int[] method_68(double double_0)
	{
		int[] array = new int[4];
		if (double_0 < 0.0)
		{
			double_0 += 360.0;
		}
		int num = Math.Abs(Width - Height);
		if (Width < Height)
		{
			if ((double_0 >= 45.0 && double_0 < 135.0) || (double_0 >= 225.0 && double_0 < 315.0))
			{
				array[0] = X - num / 2;
				array[1] = Y + num / 2;
				array[2] = Height;
				array[3] = Width;
			}
			else
			{
				array[0] = X;
				array[1] = Y;
				array[2] = Width;
				array[3] = Height;
			}
		}
		else if ((double_0 >= 45.0 && double_0 < 135.0) || (double_0 >= 225.0 && double_0 < 315.0))
		{
			array[0] = X + num / 2;
			array[1] = Y - num / 2;
			array[2] = Height;
			array[3] = Width;
		}
		else
		{
			array[0] = X;
			array[1] = Y;
			array[2] = Width;
			array[3] = Height;
		}
		return array;
	}
}
