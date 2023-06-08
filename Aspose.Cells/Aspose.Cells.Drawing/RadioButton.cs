using System.Collections;
using ns12;
using ns2;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents a radion button.
///       </summary>
public class RadioButton : Shape
{
	private bool bool_3;

	private bool bool_4;

	/// <summary>
	///        Represents the cell linked to value of the radiobutton.
	///       </summary>
	public override string LinkedCell
	{
		get
		{
			byte[] linkedCell = m_linkedCell;
			if (linkedCell == null)
			{
				GroupBox groupBox = GroupBox;
				if (groupBox != null)
				{
					ArrayList arrayList = groupBox.method_69();
					foreach (Shape item in arrayList)
					{
						if (item.MsoDrawingType == MsoDrawingType.RadioButton)
						{
							linkedCell = ((RadioButton)item).m_linkedCell;
							if (linkedCell != null)
							{
								break;
							}
						}
					}
				}
				else
				{
					foreach (Shape item2 in shapeCollection_0)
					{
						if (item2.MsoDrawingType == MsoDrawingType.RadioButton && item2.GroupBox == null)
						{
							linkedCell = ((RadioButton)item2).m_linkedCell;
							if (linkedCell != null)
							{
								break;
							}
						}
					}
				}
				if (linkedCell == null)
				{
					return null;
				}
			}
			string text = method_25().method_4().method_4(0, linkedCell.Length, linkedCell, 0, 0, bool_0: false);
			if (text != null && text != "" && text[0] == '=')
			{
				return text.Substring(1);
			}
			return text;
		}
		set
		{
			if (value != null && !(value == ""))
			{
				bool isValid = false;
				byte[] linkedCell = Class1675.smethod_1(method_25(), method_26().Index, value, externRef: false, validName: true, convertName: false, out isValid);
				if (base.Shapes.method_38())
				{
					GroupBox groupBox = GroupBox;
					if (groupBox != null)
					{
						ArrayList arrayList = groupBox.method_69();
						{
							foreach (Shape item in arrayList)
							{
								if (item.MsoDrawingType == MsoDrawingType.RadioButton)
								{
									if (isValid)
									{
										((RadioButton)item).m_linkedCell = linkedCell;
									}
									else
									{
										((RadioButton)item).m_linkedCell = null;
									}
								}
							}
							return;
						}
					}
					{
						foreach (Shape item2 in shapeCollection_0)
						{
							if (item2.MsoDrawingType == MsoDrawingType.RadioButton && item2.GroupBox == null)
							{
								if (isValid)
								{
									((RadioButton)item2).m_linkedCell = linkedCell;
								}
								else
								{
									((RadioButton)item2).m_linkedCell = null;
								}
							}
						}
						return;
					}
				}
				{
					foreach (Shape item3 in shapeCollection_0)
					{
						if (item3.MsoDrawingType == MsoDrawingType.RadioButton)
						{
							if (isValid)
							{
								((RadioButton)item3).m_linkedCell = linkedCell;
							}
							else
							{
								((RadioButton)item3).m_linkedCell = null;
							}
						}
					}
					return;
				}
			}
			m_linkedCell = null;
		}
	}

	/// <summary>
	///       Indicates if the radiobutton is checked or not.
	///       </summary>
	public bool IsChecked
	{
		get
		{
			return bool_3;
		}
		set
		{
			if (bool_3 == value)
			{
				return;
			}
			int num = -1;
			if (value)
			{
				int num2 = 0;
				if (base.Shapes.method_38())
				{
					GroupBox groupBox = GroupBox;
					if (groupBox != null)
					{
						ArrayList arrayList = groupBox.method_69();
						foreach (Shape item in arrayList)
						{
							if (item.MsoDrawingType == MsoDrawingType.RadioButton)
							{
								((RadioButton)item).bool_3 = false;
								if (item == this)
								{
									num = num2;
								}
								num2++;
							}
						}
					}
					else
					{
						foreach (Shape item2 in shapeCollection_0)
						{
							if (item2.MsoDrawingType == MsoDrawingType.RadioButton && item2.GroupBox == null)
							{
								((RadioButton)item2).bool_3 = false;
								if (item2 == this)
								{
									num = num2;
								}
								num2++;
							}
						}
					}
				}
				else
				{
					foreach (Shape item3 in shapeCollection_0)
					{
						if (item3.MsoDrawingType == MsoDrawingType.RadioButton)
						{
							((RadioButton)item3).bool_3 = false;
							if (item3 == this)
							{
								num = num2;
							}
							num2++;
						}
					}
				}
			}
			bool_3 = value;
			if (((!value || num == -1) && value) || m_linkedCell == null)
			{
				return;
			}
			byte[] data = method_58();
			bool isArea = false;
			CellArea cellArea = Class1279.smethod_2(method_25(), data, 0, 0, 0, out isArea);
			if (isArea)
			{
				Cell cell = method_26().Cells.GetCell(cellArea.StartRow, cellArea.StartColumn, bool_2: false);
				if (value)
				{
					cell.PutValue(num + 1);
				}
				else
				{
					cell.PutValue(0);
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
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public new GroupBox GroupBox => base.GroupBox;

	internal RadioButton(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.RadioButton, shapeCollection_1)
	{
		class1737_0 = new Class1737(this);
	}

	internal void method_69(bool bool_5)
	{
		bool_3 = bool_5;
	}

	internal void Copy(RadioButton radioButton_0, CopyOptions copyOptions_0)
	{
		bool_4 = radioButton_0.bool_4;
		m_linkedCell = radioButton_0.m_linkedCell;
		bool_3 = radioButton_0.bool_3;
		Copy((Shape)radioButton_0, copyOptions_0);
	}
}
