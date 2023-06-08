using System;
using System.ComponentModel;
using ns2;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents a check box object in a worksheet.
///       </summary>
/// <example>
///   <code>
///       [C#]
///
///       int index = excel.Worksheets[0].CheckBoxes.Add(15, 15, 20, 100);
///       CheckBox checkBox = excel.Worksheets[0].CheckBoxes[index];
///       checkBox.Text = "Check Box 1";
///
///
///       [Visual Basic]
///
///       Dim index as integer = excel.Worksheets(0).CheckBoxes.Add(15, 15, 20, 100)
///       Dim checkBox as CheckBox = excel.Worksheets(0).CheckBoxes[index];
///       checkBox.Text = "Check Box 1"
///       </code>
/// </example>
public class CheckBox : Shape
{
	private CheckValueType checkValueType_0;

	private bool bool_3;

	/// <summary>
	///       Indicates if the checkbox is checked or not.
	///       </summary>
	public bool Value
	{
		get
		{
			return checkValueType_0 == CheckValueType.Checked;
		}
		set
		{
			if (value)
			{
				CheckedValue = CheckValueType.Checked;
			}
			else
			{
				CheckedValue = CheckValueType.UnChecked;
			}
		}
	}

	/// <summary>
	///       Gets or set checkbox' value.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use CheckBox.CheckValueType property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use CheckBox.CheckValueType property instead.")]
	public CheckValueType CheckValue
	{
		get
		{
			return checkValueType_0;
		}
		set
		{
			CheckedValue = value;
		}
	}

	/// <summary>
	///       Gets or set checkbox' value.
	///       </summary>
	public CheckValueType CheckedValue
	{
		get
		{
			if (m_linkedCell != null)
			{
				UpdateSelectedValue();
			}
			return checkValueType_0;
		}
		set
		{
			checkValueType_0 = value;
			if (m_linkedCell == null)
			{
				return;
			}
			Cell cell = method_60();
			if (cell != null)
			{
				switch (value)
				{
				case CheckValueType.Checked:
					cell.PutValue(boolValue: true);
					break;
				case CheckValueType.Mixed:
					cell.PutValue("#N/A");
					break;
				default:
					cell.PutValue(boolValue: false);
					break;
				}
			}
		}
	}

	/// <summary>
	///       Indicates whether the combobox has 3-D shading.
	///       </summary>
	public bool Shadow
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	internal CheckBox(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.CheckBox, shapeCollection_1)
	{
		class1737_0 = new Class1737(this);
	}

	internal void method_69(CheckValueType checkValueType_1)
	{
		checkValueType_0 = checkValueType_1;
	}

	internal CheckValueType method_70()
	{
		return checkValueType_0;
	}

	internal void Copy(CheckBox checkBox_0, CopyOptions copyOptions_0)
	{
		bool_3 = checkBox_0.bool_3;
		checkValueType_0 = checkBox_0.checkValueType_0;
		Copy((Shape)checkBox_0, copyOptions_0);
	}
}
