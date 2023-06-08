using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;
using ns12;
using ns16;
using ns2;
using ns21;
using ns52;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents all the shape in a worksheet/chart.
///       </summary>
public class ShapeCollection : CollectionBase
{
	private WorksheetCollection worksheetCollection_0;

	private Worksheet worksheet_0;

	private object object_0;

	private ushort ushort_0;

	private Class1701 class1701_0;

	private ArrayList arrayList_0;

	/// <summary>
	///       Gets the shape object at the specific index.
	///       </summary>
	/// <param name="index">
	/// </param>
	/// <returns>
	/// </returns>
	public Shape this[int index] => (Shape)base.InnerList[index];

	public Shape this[string name]
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					if (string.Compare(this[num].Name, name, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return this[num];
		}
	}

	internal ArrayList method_0()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal void method_1(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}

	internal ShapeCollection(WorksheetCollection worksheetCollection_1, Worksheet worksheet_1, Class1703 class1703_0, object object_1, int int_0)
	{
		object_0 = object_1;
		worksheetCollection_0 = worksheetCollection_1;
		worksheet_0 = worksheet_1;
		if (int_0 == -1)
		{
			class1701_0 = class1703_0.method_3(this, class1703_0);
		}
		else
		{
			class1701_0 = new Class1701(this, class1703_0, int_0);
		}
		ushort_0 = 0;
	}

	internal static MsoDrawingType smethod_0(AutoShapeType autoShapeType_0)
	{
		return autoShapeType_0 switch
		{
			AutoShapeType.Arc => MsoDrawingType.Arc, 
			AutoShapeType.Rectangle => MsoDrawingType.Rectangle, 
			AutoShapeType.Oval => MsoDrawingType.Oval, 
			_ => MsoDrawingType.CellsDrawing, 
		};
	}

	internal void method_2()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Shape shape = (Shape)enumerator.Current;
				switch (shape.MsoDrawingType)
				{
				case MsoDrawingType.CellsDrawing:
					method_3(((CellsDrawing)shape).method_64(), 0);
					break;
				case MsoDrawingType.Rectangle:
					method_3(((RectangleShape)shape).method_64(), 0);
					break;
				case MsoDrawingType.Oval:
					method_3(((Oval)shape).method_64(), 0);
					break;
				case MsoDrawingType.Arc:
					method_3(((ArcShape)shape).method_64(), 0);
					break;
				case MsoDrawingType.Chart:
				{
					Chart chart = ((ChartShape)shape).method_69();
					chart.method_37(method_36().method_52());
					break;
				}
				case MsoDrawingType.TextBox:
					method_3(((TextBox)shape).method_63(), 0);
					break;
				case MsoDrawingType.Button:
					method_3(((Button)shape).method_63(), 0);
					break;
				case MsoDrawingType.CheckBox:
					method_3(((CheckBox)shape).method_64(), 0);
					break;
				case MsoDrawingType.RadioButton:
					method_3(((RadioButton)shape).method_64(), 0);
					break;
				case MsoDrawingType.Label:
					method_3(((Label)shape).method_64(), 0);
					break;
				case MsoDrawingType.GroupBox:
					method_3(((GroupBox)shape).method_64(), 0);
					break;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal void method_3(Class1737 class1737_0, int int_0)
	{
		if (class1737_0 == null)
		{
			return;
		}
		if (class1737_0.method_5() != null)
		{
			worksheetCollection_0.method_63(class1737_0.Font);
		}
		else
		{
			class1737_0.method_10(int_0);
		}
		if (class1737_0.method_12() == null || class1737_0.method_12().Count == 0)
		{
			return;
		}
		class1737_0.method_11();
		foreach (FontSetting item in class1737_0.method_12())
		{
			if (item.method_2() != null)
			{
				worksheetCollection_0.method_63(item.method_2());
			}
		}
	}

	[SpecialName]
	internal Class1701 method_4()
	{
		return class1701_0;
	}

	[SpecialName]
	internal Class1703 method_5()
	{
		return class1701_0.method_0();
	}

	/// <summary>
	///       Adds and copy a shape to the worksheet..
	///       </summary>
	/// <param name="sourceShape"> Source shape.</param>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of checkbox from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of textbox from its left column, in unit of pixel. </param>
	/// <returns>The new shape object index.</returns>
	public Shape AddCopy(Shape sourceShape, int upperLeftRow, int top, int upperLeftColumn, int left)
	{
		if (sourceShape.method_33())
		{
			return null;
		}
		CopyOptions copyOptions_ = new CopyOptions(bool_6: false, Enum173.const_5);
		Shape shape = method_12(sourceShape, null, copyOptions_);
		PlacementType placement = shape.Placement;
		shape.Placement = PlacementType.Move;
		int rowHeightPixel = method_37().Cells.GetRowHeightPixel(upperLeftRow);
		top = (int)((double)((float)top * Class1698.float_1 / (float)rowHeightPixel) + 0.5);
		rowHeightPixel = method_37().Cells.GetViewColumnWidthPixel(upperLeftColumn);
		left = (int)((double)((float)left * Class1698.float_0 / (float)rowHeightPixel) + 0.5);
		shape.method_27().method_7().method_6(upperLeftRow);
		shape.method_27().method_7().Top = top;
		shape.method_27().method_7().method_8(upperLeftColumn);
		shape.method_27().method_7().Left = left;
		shape.method_27().method_7().Right = sourceShape.Width;
		shape.method_27().method_7().Bottom = sourceShape.Height;
		shape.Placement = placement;
		return shape;
	}

	/// <summary>
	///       Adds a checkbox to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of checkbox from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of textbox from its left column, in unit of pixel. </param>
	/// <param name="height">Height of textbox, in unit of pixel.</param>
	/// <param name="width">Width of textbox, in unit of pixel.</param>
	/// <returns>The new CheckBox object index.</returns>
	public CheckBox AddCheckBox(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		if (method_33())
		{
			return null;
		}
		CheckBox checkBox = new CheckBox(this);
		checkBox.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(checkBox);
		worksheet_0.CheckBoxes.Add(checkBox);
		return checkBox;
	}

	/// <summary>
	///       Adds a text box to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of textbox from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of textbox from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of textbox, in unit of pixel. </param>
	/// <param name="width">Represents the width of textbox, in unit of pixel. </param>
	/// <returns>A <see cref="T:Aspose.Cells.Drawing.TextBox" /> object.</returns>
	public TextBox AddTextBox(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		TextBox textBox = new TextBox(this);
		textBox.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(textBox);
		if (!method_33())
		{
			worksheet_0.TextBoxes.Add(textBox);
		}
		return textBox;
	}

	/// <summary>
	///       Adds a Spinner to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of Spinner from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of Spinner from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of Spinner, in unit of pixel. </param>
	/// <param name="width">Represents the width of Spinner, in unit of pixel. </param>
	/// <returns>A Spinner object.</returns>
	public Spinner AddSpinner(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		if (method_33())
		{
			return null;
		}
		Spinner spinner = new Spinner(this);
		spinner.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(spinner);
		return spinner;
	}

	/// <summary>
	///       Adds a ScrollBar to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of ScrollBar from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of ScrollBar from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of ScrollBar, in unit of pixel. </param>
	/// <param name="width">Represents the width of ScrollBar, in unit of pixel. </param>
	/// <returns>A ScrollBar object.</returns>
	public ScrollBar AddScrollBar(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		if (method_33())
		{
			return null;
		}
		ScrollBar scrollBar = new ScrollBar(this);
		scrollBar.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(scrollBar);
		return scrollBar;
	}

	/// <summary>
	///       Adds a RadioButton to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of RadioButton from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of RadioButton from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of RadioButton, in unit of pixel. </param>
	/// <param name="width">Represents the width of RadioButton, in unit of pixel. </param>
	/// <returns>A RadioButton object.</returns>
	public RadioButton AddRadioButton(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		RadioButton radioButton = new RadioButton(this);
		radioButton.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(radioButton);
		return radioButton;
	}

	/// <summary>
	///       Adds a ListBox to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of ListBox from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of ListBox from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of ListBox, in unit of pixel. </param>
	/// <param name="width">Represents the width of ListBox, in unit of pixel. </param>
	/// <returns>A ListBox object.</returns>
	public ListBox AddListBox(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		ListBox listBox = new ListBox(this);
		listBox.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(listBox);
		return listBox;
	}

	/// <summary>
	///       Adds a ComboBox to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of ComboBox from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of ComboBox from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of ComboBox, in unit of pixel. </param>
	/// <param name="width">Represents the width of ComboBox, in unit of pixel. </param>
	/// <returns>A ComboBox object.</returns>
	public ComboBox AddComboBox(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		ComboBox comboBox = new ComboBox(this);
		comboBox.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(comboBox);
		return comboBox;
	}

	/// <summary>
	///       Adds a GroupBox to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of GroupBox from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of GroupBox from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of GroupBox, in unit of pixel. </param>
	/// <param name="width">Represents the width of GroupBox, in unit of pixel. </param>
	/// <returns>A GroupBox object.</returns>
	public GroupBox AddGroupBox(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		GroupBox groupBox = new GroupBox(this);
		groupBox.method_27().method_7().method_4(PlacementType.Move);
		groupBox.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		groupBox.method_63().Font.Size = 8;
		groupBox.method_63().Font.method_13("Tahoma");
		groupBox.method_63().method_7(bool_2: true);
		Add(groupBox);
		return groupBox;
	}

	/// <summary>
	///       Adds a Button to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of Button from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of Button from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of Button, in unit of pixel. </param>
	/// <param name="width">Represents the width of Button, in unit of pixel. </param>
	/// <returns>A Button object.</returns>
	public Button AddButton(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		Button button = new Button(this);
		button.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(button);
		return button;
	}

	/// <summary>
	///       Adds a Label to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of Label from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of Label from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of Label, in unit of pixel. </param>
	/// <param name="width">Represents the width of Label, in unit of pixel. </param>
	/// <returns>A Label object.</returns>
	public Label AddLabel(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		Label label = new Label(this);
		label.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(label);
		return label;
	}

	/// <summary>
	///       Adds a label to the chart.
	///       </summary>
	/// <param name="top">Represents the vertical offset of label from the upper left corner in units of 1/4000 of the chart area. </param>
	/// <param name="left">Represents the vertical offset of label from the upper left corner in units of 1/4000 of the chart area.</param>
	/// <param name="height">Represents the height of label, in units of 1/4000 of the chart area.</param>
	/// <param name="width">Represents the width of label, in units of 1/4000 of the chart area.</param>
	/// <returns>A new Label object.</returns>
	public Label AddLabelInChart(int top, int left, int height, int width)
	{
		if (!method_33())
		{
			return null;
		}
		Label label = new Label(this);
		Add(label);
		label.method_16(left, top, width, height);
		return label;
	}

	/// <summary>
	///       Adds a textbox to the chart.
	///       </summary>
	/// <param name="top">Represents the vertical offset of textbox from the upper left corner in units of 1/4000 of the chart area. </param>
	/// <param name="left">Represents the vertical offset of textbox from the upper left corner in units of 1/4000 of the chart area.</param>
	/// <param name="height">Represents the height of textbox, in units of 1/4000 of the chart area.</param>
	/// <param name="width">Represents the width of textbox, in units of 1/4000 of the chart area.</param>
	/// <returns>A TextBox object.</returns>
	public TextBox AddTextBoxInChart(int top, int left, int height, int width)
	{
		if (!method_33())
		{
			return null;
		}
		TextBox textBox = new TextBox(this);
		Add(textBox);
		textBox.method_16(left, top, width, height);
		return textBox;
	}

	/// <summary>
	///       Inserts a WordArt object to the chart
	///       </summary>
	/// <param name="effect">The mso preset text effect type.</param>
	/// <param name="text">The WordArt text.</param>
	/// <param name="fontName">The font name.</param>
	/// <param name="size">The font size</param>
	/// <param name="fontBold">Indicates whether font is bold.</param>
	/// <param name="fontItalic">Indicates whether font is italic.</param>
	/// <param name="top">Represents the vertical offset of shape from the upper left corner in units of 1/4000 of the chart area. </param>
	/// <param name="left">Represents the vertical offset of shape from the upper left corner in units of 1/4000 of the chart area.</param>
	/// <param name="height">Represents the height of shape, in units of 1/4000 of the chart area.</param>
	/// <param name="width">Represents the width of shape, in units of 1/4000 of the chart area.</param>
	/// <returns>Returns a Shape object that represents the new WordArt object.</returns>
	public Shape AddTextEffectInChart(MsoPresetTextEffect effect, string text, string fontName, int size, bool fontBold, bool fontItalic, int top, int left, int height, int width)
	{
		if (!method_33())
		{
			return null;
		}
		CellsDrawing cellsDrawing = new CellsDrawing(this);
		Add(cellsDrawing);
		cellsDrawing.method_16(left, top, width, height);
		TextEffectFormat textEffectFormat = new TextEffectFormat(cellsDrawing);
		textEffectFormat.SetTextEffect(effect);
		textEffectFormat.Text = text;
		textEffectFormat.FontName = fontName;
		textEffectFormat.FontSize = size;
		textEffectFormat.FontBold = fontBold;
		textEffectFormat.FontItalic = fontItalic;
		return cellsDrawing;
	}

	/// <summary>
	///       Inserts a WordArt object.
	///       </summary>
	/// <param name="effect">The mso preset text effect type.</param>
	/// <param name="text">The WordArt text.</param>
	/// <param name="fontName">The font name.</param>
	/// <param name="size">The font size</param>
	/// <param name="fontBold">Indicates whether font is bold.</param>
	/// <param name="fontItalic">Indicates whether font is italic.</param>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of shape from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of shape from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of shape, in unit of pixel. </param>
	/// <param name="width">Represents the width of shape, in unit of pixel. </param>
	/// <returns>Returns a Shape object that represents the new WordArt object.</returns>
	public Shape AddTextEffect(MsoPresetTextEffect effect, string text, string fontName, int size, bool fontBold, bool fontItalic, int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		CellsDrawing cellsDrawing = new CellsDrawing(this);
		cellsDrawing.bool_0 = true;
		cellsDrawing.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		TextEffectFormat textEffectFormat = new TextEffectFormat(cellsDrawing);
		textEffectFormat.SetTextEffect(effect);
		textEffectFormat.Text = text;
		textEffectFormat.FontName = fontName;
		textEffectFormat.FontSize = size;
		textEffectFormat.FontBold = fontBold;
		textEffectFormat.FontItalic = fontItalic;
		Add(cellsDrawing);
		return cellsDrawing;
	}

	/// <summary>
	///       Adds a RectangleShape to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of RectangleShape from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of RectangleShape from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of RectangleShape, in unit of pixel. </param>
	/// <param name="width">Represents the width of RectangleShape, in unit of pixel. </param>
	/// <returns>A RectangleShape object.</returns>
	public RectangleShape AddRectangle(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		RectangleShape rectangleShape = new RectangleShape(this);
		rectangleShape.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(rectangleShape);
		return rectangleShape;
	}

	/// <summary>
	///       Adds a Oval to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of Oval from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of Oval from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of Oval, in unit of pixel. </param>
	/// <param name="width">Represents the width of Oval, in unit of pixel. </param>
	/// <returns>A Oval object.</returns>
	public Oval AddOval(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		Oval oval = new Oval(this);
		oval.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(oval);
		return oval;
	}

	/// <summary>
	///       Adds a LineShape to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of LineShape from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of LineShape from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of LineShape, in unit of pixel. </param>
	/// <param name="width">Represents the width of LineShape, in unit of pixel. </param>
	/// <returns>A LineShape object.</returns>
	public LineShape AddLine(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		LineShape lineShape = new LineShape(this);
		lineShape.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(lineShape);
		return lineShape;
	}

	/// <summary>
	///       Adds a free floating shape to the worksheet.Only applies for line/image shape.
	///       </summary>
	/// <param name="type">The shape type.</param>
	/// <param name="top">Represents the vertical  offset of shape from the worksheet's top row, in unit of pixel.</param>
	/// <param name="left">Represents the horizontal offset of shape from the worksheet's left column, in unit of pixel.</param>
	/// <param name="height">Represents the height of LineShape, in unit of pixel. </param>
	/// <param name="width">Represents the width of LineShape, in unit of pixel. </param>
	/// <param name="imageData">The image data,only applies for the picture.</param>
	/// <param name="isOriginalSize">Whether the shape use original size if the shape is image.</param>
	/// <returns>
	/// </returns>
	public Shape AddFreeFloatingShape(MsoDrawingType type, int top, int left, int height, int width, byte[] imageData, bool isOriginalSize)
	{
		Shape shape = null;
		switch (type)
		{
		case MsoDrawingType.Picture:
		{
			Picture picture = new Picture(this);
			shape = picture;
			if (imageData != null)
			{
				MemoryStream memoryStream = new MemoryStream(imageData);
				picture.method_71(Add(picture, memoryStream));
				memoryStream.Close();
				Class1696 @class = picture.method_69();
				if (isOriginalSize)
				{
					width = @class.Width;
					height = @class.Height;
				}
			}
			else
			{
				Add(shape);
			}
			worksheet_0.Pictures.Add(picture);
			break;
		}
		case MsoDrawingType.Line:
			shape = new LineShape(this);
			Add(shape);
			break;
		}
		if (shape != null)
		{
			shape.method_27().method_7().method_4(PlacementType.FreeFloating);
			shape.method_27().method_7().Top = top;
			shape.method_27().method_7().Left = left;
			shape.method_27().method_7().Right = width;
			shape.method_27().method_7().Bottom = height;
		}
		return shape;
	}

	internal Shape method_6(MsoDrawingType msoDrawingType_0, PlacementType placementType_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7, byte[] byte_0)
	{
		Shape shape = null;
		switch (msoDrawingType_0)
		{
		case MsoDrawingType.Line:
			shape = new LineShape(this);
			Add(shape);
			break;
		case MsoDrawingType.Rectangle:
			shape = new RectangleShape(this);
			Add(shape);
			break;
		case MsoDrawingType.Oval:
			shape = new Oval(this);
			Add(shape);
			break;
		case MsoDrawingType.Arc:
			shape = new ArcShape(this);
			Add(shape);
			break;
		case MsoDrawingType.TextBox:
			shape = new TextBox(this);
			Add(shape);
			method_37().TextBoxes.Add((TextBox)shape);
			break;
		case MsoDrawingType.Button:
			shape = new Button(this);
			Add(shape);
			break;
		case MsoDrawingType.Picture:
		{
			Picture picture = new Picture(this);
			shape = picture;
			if (byte_0 != null)
			{
				MemoryStream memoryStream2 = new MemoryStream(byte_0);
				picture.method_71(Add(picture, memoryStream2));
				memoryStream2.Close();
			}
			else
			{
				Add(shape);
			}
			worksheet_0.Pictures.Add(picture);
			break;
		}
		case MsoDrawingType.CheckBox:
			shape = new CheckBox(this);
			Add(shape);
			method_37().CheckBoxes.Add((CheckBox)shape);
			break;
		case MsoDrawingType.RadioButton:
			shape = new RadioButton(this);
			Add(shape);
			break;
		case MsoDrawingType.Label:
			shape = new Label(this);
			Add(shape);
			break;
		case MsoDrawingType.Spinner:
			shape = new Spinner(this);
			Add(shape);
			break;
		case MsoDrawingType.ScrollBar:
			shape = new ScrollBar(this);
			Add(shape);
			break;
		case MsoDrawingType.ListBox:
			shape = new ListBox(this);
			Add(shape);
			break;
		case MsoDrawingType.GroupBox:
			shape = new GroupBox(this);
			Add(shape);
			break;
		case MsoDrawingType.ComboBox:
			shape = new ComboBox(this);
			Add(shape);
			break;
		case MsoDrawingType.OleObject:
		{
			OleObject oleObject = new OleObject(this);
			shape = oleObject;
			MemoryStream memoryStream = new MemoryStream(byte_0);
			oleObject.method_76(Add(oleObject, memoryStream));
			memoryStream.Close();
			worksheet_0.OleObjects.Add(oleObject);
			break;
		}
		case MsoDrawingType.CellsDrawing:
			shape = new CellsDrawing(this);
			Add(shape);
			break;
		}
		if (shape != null)
		{
			shape.method_27().method_7().method_4(PlacementType.MoveAndSize);
			int num = method_37().Cells.method_15(int_0);
			int_1 = (int)((double)((float)int_1 * Class1698.float_1 / (float)num) + 0.5);
			if ((float)int_1 > Class1698.float_1)
			{
				int_1 = (int)Class1698.float_1;
			}
			num = method_37().Cells.GetViewColumnWidthPixel(int_2);
			int_3 = (int)((double)((float)int_3 * Class1698.float_0 / (float)num) + 0.5);
			if ((float)int_3 > Class1698.float_0)
			{
				int_3 = (int)Class1698.float_0;
			}
			shape.method_27().method_7().method_8(int_2);
			shape.method_27().method_7().Left = int_3;
			shape.method_27().method_7().method_6(int_0);
			shape.method_27().method_7().Top = int_1;
			num = method_37().Cells.method_15(int_4);
			int_5 = (int)((double)((float)int_5 * Class1698.float_1 / (float)num) + 0.5);
			if ((float)int_5 > Class1698.float_1)
			{
				int_5 = (int)Class1698.float_1;
			}
			num = method_37().Cells.GetViewColumnWidthPixel(int_6);
			int_7 = (int)((double)((float)int_7 * Class1698.float_0 / (float)num) + 0.5);
			if ((float)int_7 > Class1698.float_0)
			{
				int_7 = (int)Class1698.float_0;
			}
			shape.method_27().method_7().method_12(int_6);
			shape.method_27().method_7().Right = int_7;
			shape.method_27().method_7().method_10(int_4);
			shape.method_27().method_7().Bottom = int_5;
			shape.Placement = placementType_0;
		}
		return shape;
	}

	/// <summary>
	///       Add a shape to chart .All unit is 1/4000 of chart area.
	///       </summary>
	/// <param name="type">The drawing type.</param>
	/// <param name="placement">the placement type.</param>
	/// <param name="left">In unit of 1/4000 chart area width.</param>
	/// <param name="top">In unit of 1/4000 chart area height.</param>
	/// <param name="right">In unit of 1/4000 chart area width.</param>
	/// <param name="bottom">In unit of 1/4000 chart area height.</param>
	/// <param name="imageData">If the shape is not a picture or ole object,imageData should be null.</param>
	public Shape AddShapeInChart1(MsoDrawingType type, PlacementType placement, int left, int top, int right, int bottom, byte[] imageData)
	{
		Shape shape = null;
		switch (type)
		{
		case MsoDrawingType.Group:
		{
			GroupShape groupShape = new GroupShape(this);
			shape = groupShape;
			Add(shape);
			break;
		}
		case MsoDrawingType.Line:
			shape = new LineShape(this);
			Add(shape);
			break;
		case MsoDrawingType.Rectangle:
			shape = new RectangleShape(this);
			Add(shape);
			break;
		case MsoDrawingType.Oval:
			shape = new Oval(this);
			Add(shape);
			break;
		case MsoDrawingType.Arc:
			shape = new ArcShape(this);
			Add(shape);
			break;
		case MsoDrawingType.TextBox:
			shape = new TextBox(this);
			Add(shape);
			break;
		case MsoDrawingType.Button:
			shape = new Button(this);
			Add(shape);
			break;
		case MsoDrawingType.Picture:
		{
			Picture picture = new Picture(this);
			shape = picture;
			if (imageData != null)
			{
				MemoryStream memoryStream2 = new MemoryStream(imageData);
				picture.method_71(Add(picture, memoryStream2));
				memoryStream2.Close();
			}
			else
			{
				Add(shape);
			}
			break;
		}
		case MsoDrawingType.CheckBox:
			shape = new CheckBox(this);
			Add(shape);
			break;
		case MsoDrawingType.RadioButton:
			shape = new RadioButton(this);
			Add(shape);
			break;
		case MsoDrawingType.Label:
			shape = new Label(this);
			Add(shape);
			break;
		case MsoDrawingType.Spinner:
			shape = new Spinner(this);
			Add(shape);
			break;
		case MsoDrawingType.ScrollBar:
			shape = new ScrollBar(this);
			Add(shape);
			break;
		case MsoDrawingType.ListBox:
			shape = new ListBox(this);
			Add(shape);
			break;
		case MsoDrawingType.GroupBox:
			shape = new GroupBox(this);
			Add(shape);
			break;
		case MsoDrawingType.ComboBox:
			shape = new ComboBox(this);
			Add(shape);
			break;
		case MsoDrawingType.OleObject:
		{
			OleObject oleObject = new OleObject(this);
			shape = oleObject;
			MemoryStream memoryStream = new MemoryStream(imageData);
			oleObject.method_76(Add(shape, memoryStream));
			memoryStream.Close();
			break;
		}
		case MsoDrawingType.Unknown:
			shape = new Shape(this, MsoDrawingType.Unknown, this);
			Add(shape);
			break;
		}
		if (shape != null)
		{
			shape.method_27().method_7().method_4(PlacementType.MoveAndSize);
			shape.method_27().method_7().Left = left;
			shape.method_27().method_7().Top = top;
			shape.method_27().method_7().Right = right;
			shape.method_27().method_7().Bottom = bottom;
			shape.Placement = placement;
		}
		return shape;
	}

	/// <summary>
	///       Add a shape to chart .All unit is 1/4000 of chart area.
	///       </summary>
	/// <param name="type">The drawing type.</param>
	/// <param name="placement">the placement type.</param>
	/// <param name="left">In unit of 1/4000 chart area width.</param>
	/// <param name="top">In unit of 1/4000 chart area height.</param>
	/// <param name="right">In unit of 1/4000 chart area width.</param>
	/// <param name="bottom">In unit of 1/4000 chart area height.</param>
	public Shape AddShapeInChart(MsoDrawingType type, PlacementType placement, int left, int top, int right, int bottom)
	{
		Shape shape = null;
		switch (type)
		{
		case MsoDrawingType.Group:
		{
			GroupShape groupShape = new GroupShape(this);
			shape = groupShape;
			Add(shape);
			break;
		}
		case MsoDrawingType.Line:
			shape = new LineShape(this);
			Add(shape);
			break;
		case MsoDrawingType.Rectangle:
			shape = new RectangleShape(this);
			Add(shape);
			break;
		case MsoDrawingType.Oval:
			shape = new Oval(this);
			Add(shape);
			break;
		case MsoDrawingType.Arc:
			shape = new ArcShape(this);
			Add(shape);
			break;
		case MsoDrawingType.TextBox:
			shape = new TextBox(this);
			Add(shape);
			break;
		case MsoDrawingType.Button:
			shape = new Button(this);
			Add(shape);
			break;
		case MsoDrawingType.Picture:
			shape = new Picture(this);
			Add(shape);
			break;
		case MsoDrawingType.CheckBox:
			shape = new CheckBox(this);
			Add(shape);
			break;
		case MsoDrawingType.RadioButton:
			shape = new RadioButton(this);
			Add(shape);
			break;
		case MsoDrawingType.Label:
			shape = new Label(this);
			Add(shape);
			break;
		case MsoDrawingType.Spinner:
			shape = new Spinner(this);
			Add(shape);
			break;
		case MsoDrawingType.ScrollBar:
			shape = new ScrollBar(this);
			Add(shape);
			break;
		case MsoDrawingType.ListBox:
			shape = new ListBox(this);
			Add(shape);
			break;
		case MsoDrawingType.GroupBox:
			shape = new GroupBox(this);
			Add(shape);
			break;
		case MsoDrawingType.ComboBox:
			shape = new ComboBox(this);
			Add(shape);
			break;
		case MsoDrawingType.Unknown:
			shape = new Shape(this, MsoDrawingType.Unknown, this);
			Add(shape);
			break;
		}
		if (shape != null)
		{
			shape.method_27().method_7().method_4(PlacementType.MoveAndSize);
			shape.method_27().method_7().Left = left;
			shape.method_27().method_7().Top = top;
			shape.method_27().method_7().Right = right;
			shape.method_27().method_7().Bottom = bottom;
			shape.Placement = placement;
		}
		return shape;
	}

	/// <summary>
	///       Adds a ArcShape to the worksheet.
	///       </summary>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of ArcShape from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of ArcShape from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of ArcShape, in unit of pixel. </param>
	/// <param name="width">Represents the width of ArcShape, in unit of pixel. </param>
	/// <returns>A ArcShape object.</returns>
	public ArcShape AddArc(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		ArcShape arcShape = new ArcShape(this);
		arcShape.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
		Add(arcShape);
		return arcShape;
	}

	/// <summary>
	///       Adds a Shape to the worksheet.
	///       </summary>
	/// <param name="type">Mso drawing type.</param>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of Shape from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of Shape from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of Shape, in unit of pixel. </param>
	/// <param name="width">Represents the width of Shape, in unit of pixel. </param>
	/// <returns>A Shape object.</returns>
	/// <remarks>The type could not be Chart/Comment/Picuter/OleObject/Polygon/DialogBox</remarks>
	public Shape AddShape(MsoDrawingType type, int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		switch (type)
		{
		case MsoDrawingType.Line:
			return AddLine(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.Rectangle:
			return AddRectangle(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.Oval:
			return AddOval(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.Arc:
			return AddArc(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.TextBox:
			return AddTextBox(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.Button:
			return AddButton(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.CheckBox:
			return AddCheckBox(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.RadioButton:
			return AddRadioButton(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.Label:
			return AddLabel(upperLeftRow, top, upperLeftColumn, left, height, width);
		default:
		{
			CellsDrawing cellsDrawing = new CellsDrawing(this);
			cellsDrawing.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
			Add(cellsDrawing);
			return cellsDrawing;
		}
		case MsoDrawingType.Spinner:
			return AddSpinner(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.ScrollBar:
			return AddScrollBar(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.ListBox:
			return AddListBox(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.GroupBox:
			return AddGroupBox(upperLeftRow, top, upperLeftColumn, left, height, width);
		case MsoDrawingType.ComboBox:
			return AddComboBox(upperLeftRow, top, upperLeftColumn, left, height, width);
		}
	}

	/// <summary>
	///       Adds a AutoShape to the worksheet.
	///       </summary>
	/// <param name="type">Auto shape type.</param>
	/// <param name="upperLeftRow"> Upper left row index.</param>
	/// <param name="top">Represents the vertical  offset of Shape from its left row, in unit of pixel. </param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="left">Represents the horizontal offset of Shape from its left column, in unit of pixel. </param>
	/// <param name="height">Represents the height of Shape, in unit of pixel. </param>
	/// <param name="width">Represents the width of Shape, in unit of pixel. </param>
	/// <returns>A Shape object.</returns>
	/// <remarks>The type could not be Chart/Comment/Picuter/OleObject/Polygon/DialogBox</remarks>
	public Shape AddAutoShape(AutoShapeType type, int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width)
	{
		switch (type)
		{
		case AutoShapeType.Arc:
			return AddArc(upperLeftRow, top, upperLeftColumn, left, height, width);
		case AutoShapeType.Rectangle:
			return AddRectangle(upperLeftRow, top, upperLeftColumn, left, height, width);
		default:
		{
			CellsDrawing cellsDrawing = new CellsDrawing(this, type);
			cellsDrawing.method_20(upperLeftRow, top, upperLeftColumn, left, height, width);
			Add(cellsDrawing);
			return cellsDrawing;
		}
		case AutoShapeType.Oval:
			return AddOval(upperLeftRow, top, upperLeftColumn, left, height, width);
		}
	}

	internal Shape AddAutoShape(AutoShapeType autoShapeType_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7)
	{
		Shape shape = null;
		shape = autoShapeType_0 switch
		{
			AutoShapeType.Arc => new ArcShape(this), 
			AutoShapeType.Rectangle => new RectangleShape(this), 
			AutoShapeType.Oval => new Oval(this), 
			_ => new CellsDrawing(this, autoShapeType_0), 
		};
		shape.method_22(int_0, int_1, int_2, int_3, int_4, int_5, int_6, int_7);
		Add(shape);
		return shape;
	}

	internal Shape method_7(AutoShapeType autoShapeType_0, int int_0, int int_1, int int_2, int int_3)
	{
		Shape shape = null;
		shape = autoShapeType_0 switch
		{
			AutoShapeType.Arc => new ArcShape(this), 
			AutoShapeType.Rectangle => new RectangleShape(this), 
			AutoShapeType.Oval => new Oval(this), 
			_ => new CellsDrawing(this, autoShapeType_0), 
		};
		shape.method_17(int_0, int_1, int_2, int_3);
		Add(shape);
		return shape;
	}

	/// <summary>
	///       Adds a AutoShape to the chart.
	///       </summary>
	/// <param name="type">Auto shape type.</param>
	/// <param name="top">Represents the vertical offset of textbox from the upper left corner in units of 1/4000 of the chart area. </param>
	/// <param name="left">Represents the vertical offset of textbox from the upper left corner in units of 1/4000 of the chart area.</param>
	/// <param name="height">Represents the height of textbox, in units of 1/4000 of the chart area.</param>
	/// <param name="width">Represents the width of textbox, in units of 1/4000 of the chart area.</param>
	/// <returns>Returns a shape objct.</returns>
	/// <remarks>The type could not be Chart/Comment/Picuter/OleObject/Polygon/DialogBox</remarks>
	public Shape AddAutoShapeInChart(AutoShapeType type, int top, int left, int height, int width)
	{
		if (!method_33())
		{
			return null;
		}
		Shape shape = null;
		shape = type switch
		{
			AutoShapeType.Arc => new ArcShape(this), 
			AutoShapeType.Rectangle => new RectangleShape(this), 
			AutoShapeType.Oval => new Oval(this), 
			_ => new CellsDrawing(this, type), 
		};
		shape.method_16(left, top, width, height);
		Add(shape);
		return shape;
	}

	/// <summary>
	///       Adds a picture to the collection.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="lowerRightRow">Lower right row index</param>
	/// <param name="lowerRightColumn">Lower right column index</param>
	/// <param name="stream">Stream object which contains the image data.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.Picture" /> Picture object.</returns>
	public Picture AddPicture(int upperLeftRow, int upperLeftColumn, int lowerRightRow, int lowerRightColumn, Stream stream)
	{
		if (method_33())
		{
			return null;
		}
		Class1677.smethod_26(upperLeftRow, upperLeftColumn, lowerRightRow, lowerRightColumn);
		Picture picture = new Picture(this);
		picture.method_71(Add(picture, stream));
		picture.MoveToRange(upperLeftRow, upperLeftColumn, lowerRightRow, lowerRightColumn);
		worksheet_0.Pictures.Add(picture);
		return picture;
	}

	/// <summary>
	///       Adds a picture to the collection.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="stream">Stream object which contains the image data.</param>
	/// <param name="widthScale">Scale of image width, a percentage.</param>
	/// <param name="heightScale">Scale of image width, a percentage.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.Picture" /> Picture object.</returns>
	public Picture AddPicture(int upperLeftRow, int upperLeftColumn, Stream stream, int widthScale, int heightScale)
	{
		if (widthScale <= 0 || heightScale <= 0)
		{
			throw new CellsException(ExceptionType.InvalidData, "Scale of image should be larger than 0.");
		}
		Class1677.CheckCell(upperLeftRow, upperLeftColumn);
		Picture picture = new Picture(this);
		picture.method_71(Add(picture, stream));
		Class1696 @class = picture.method_69();
		int int_ = (int)((double)((float)(@class.Width * widthScale) / 100f) + 0.5);
		int int_2 = (int)((double)((float)(@class.Height * heightScale) / 100f) + 0.5);
		picture.method_20(upperLeftRow, 0, upperLeftColumn, 0, int_2, int_);
		worksheet_0.Pictures.Add(picture);
		return picture;
	}

	/// <summary>
	///       Add a linked picture.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="height">The height of the shape. In unit of pixels</param>
	/// <param name="width">The width of the shape. In unit of pixels</param>
	/// <param name="sourceFullName">
	///       The path and name of the source file for the linked image</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.Picture" /> Picture object.</returns>
	public Picture AddLinkedPicture(int upperLeftRow, int upperLeftColumn, int height, int width, string sourceFullName)
	{
		Picture picture = new Picture(this);
		Add(picture);
		picture.SourceFullName = sourceFullName;
		picture.method_20(upperLeftRow, 0, upperLeftColumn, 0, height, width);
		worksheet_0.Pictures.Add(picture);
		return picture;
	}

	/// <summary>
	///       Add a linked picture.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="height">The height of the shape. In unit of pixels</param>
	/// <param name="width">The width of the shape. In unit of pixels</param>
	/// <param name="sourceFullName">
	///       The path and name of the source file for the linked image</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.Picture" /> Picture object.</returns>
	public OleObject AddOleObjectWithLinkedImage(int upperLeftRow, int upperLeftColumn, int height, int width, string sourceFullName)
	{
		OleObject oleObject = new OleObject(this);
		Add(oleObject);
		oleObject.ImageSourceFullName = sourceFullName;
		oleObject.method_20(upperLeftRow, 0, upperLeftColumn, 0, height, width);
		worksheet_0.OleObjects.Add(oleObject);
		return oleObject;
	}

	/// <summary>
	///       Adds a picture to the chart.
	///       </summary>
	/// <param name="top">Represents the vertical offset of shape from the upper left corner in units of 1/4000 of the chart area. </param>
	/// <param name="left">Represents the vertical offset of shape from the upper left corner in units of 1/4000 of the chart area.</param>
	/// <param name="stream">Stream object which contains the image data.</param>
	/// <param name="widthScale">Scale of image width, a percentage.</param>
	/// <param name="heightScale">Scale of image width, a percentage.</param>
	/// <returns>Returns a Picture objct.</returns>
	public Picture AddPictureInChart(int top, int left, Stream stream, int widthScale, int heightScale)
	{
		if (!method_33())
		{
			return null;
		}
		if (widthScale > 0 && heightScale > 0)
		{
			Picture picture = new Picture(this);
			picture.method_71(Add(picture, stream));
			Class1696 @class = picture.method_69();
			int num = (int)((double)((float)(@class.Width * widthScale) / 100f) + 0.5);
			int num2 = (int)((double)((float)(@class.Height * heightScale) / 100f) + 0.5);
			Chart chart = (Chart)object_0;
			num = (int)((double)((float)num * 4000f / (float)chart.ChartObject.Width) + 0.5);
			num2 = (int)((double)((float)num2 * 4000f / (float)chart.ChartObject.Height) + 0.5);
			if (num + left > 4000)
			{
				num = 4000 - left;
			}
			if (num2 + top > 4000)
			{
				num2 = 4000 - top;
			}
			picture.method_16(left, top, num, num2);
			return picture;
		}
		throw new CellsException(ExceptionType.InvalidData, "Scale of image should be larger than 0.");
	}

	/// <summary>
	/// </summary>
	/// <param name="upperLeftRow">
	/// </param>
	/// <param name="top">
	/// </param>
	/// <param name="upperLeftColumn">
	/// </param>
	/// <param name="left">
	/// </param>
	/// <param name="height">
	/// </param>
	/// <param name="width">
	/// </param>
	/// <param name="imageData">
	/// </param>
	/// <returns>
	/// </returns>
	public OleObject AddOleObject(int upperLeftRow, int top, int upperLeftColumn, int left, int height, int width, byte[] imageData)
	{
		if (method_33())
		{
			return null;
		}
		Class1677.CheckCell(upperLeftRow, upperLeftColumn);
		OleObject oleObject = new OleObject(this);
		if (imageData != null)
		{
			MemoryStream memoryStream = new MemoryStream(imageData);
			oleObject.method_76(Add(oleObject, memoryStream));
			oleObject.method_27().method_7().method_4(PlacementType.Move);
			oleObject.method_20(upperLeftRow, 0, upperLeftColumn, 0, height, width);
			memoryStream.Close();
		}
		WorksheetCollection worksheetCollection = method_36();
		worksheetCollection.method_1(worksheetCollection.method_0() + 1);
		oleObject.method_98(method_36().method_0());
		worksheet_0.OleObjects.Add(oleObject);
		return oleObject;
	}

	[SpecialName]
	internal int method_8()
	{
		return ushort_0;
	}

	[SpecialName]
	internal void method_9(int int_0)
	{
		ushort_0 = (ushort)int_0;
	}

	/// <summary>
	///       Copy all comments in the range.
	///       </summary>
	/// <param name="shapes">The source shapes.</param>
	/// <param name="ca">The source range.</param>
	/// <param name="destRow">The dest range start row.</param>
	/// <param name="destColumn">The dest range start column.</param>
	public void CopyCommentsInRange(ShapeCollection shapes, CellArea ca, int destRow, int destColumn)
	{
		int count = shapes.Count;
		Shape shape = null;
		CopyOptions copyOptions_ = new CopyOptions(bool_6: false);
		for (int i = 0; i < count; i++)
		{
			Shape shape2 = shapes[i];
			if (shape2.method_33() || shape2.MsoDrawingType != MsoDrawingType.Comment)
			{
				continue;
			}
			Comment comment = ((CommentShape)shape2).method_69();
			if (comment.Row >= ca.StartRow && comment.Row <= ca.EndRow && comment.Column >= ca.StartColumn && comment.Column <= ca.EndColumn)
			{
				Comment comment2 = new Comment(method_37().Comments, (ushort)destRow, (byte)comment.Column);
				comment2.CommentShape.Copy((CommentShape)shape2, copyOptions_);
				shape = comment2.CommentShape;
				Add(comment2.CommentShape);
				method_37().Comments.Add(comment2);
				PlacementType placement = shape.Placement;
				shape.Placement = PlacementType.FreeFloating;
				if (destRow == 0)
				{
					shape.method_27().method_7().Top = 1;
				}
				else
				{
					shape.method_27().method_7().Top = shape.method_41(0, 0, destRow - 1, 105);
				}
				shape.Placement = placement;
			}
		}
	}

	/// <summary>
	///       Copy shapes in the range to destination range.
	///       </summary>
	/// <param name="sourceShapes">Source shapes.</param>
	/// <param name="ca">The source range.</param>
	/// <param name="destRow">The dest row index of the dest range.</param>
	/// <param name="destColumn">The dest column of the dest range.</param>
	/// <param name="isContained">Whether only copy the shapes which are contained in the range.
	///       If true,only copies the shapes in the range. 
	///       Otherwise,it works as MS Office.</param>
	public void CopyInRange(ShapeCollection sourceShapes, CellArea ca, int destRow, int destColumn, bool isContained)
	{
		int count = sourceShapes.Count;
		int num = 0;
		bool flag = false;
		CopyOptions copyOptions_ = new CopyOptions(bool_6: false, Enum173.const_4);
		for (int i = 0; i < count; i++)
		{
			flag = false;
			Shape shape = sourceShapes[i];
			if (shape.method_33() || shape.MsoDrawingType == MsoDrawingType.Comment)
			{
				continue;
			}
			int upperLeftRow = shape.UpperLeftRow;
			int upperLeftColumn = shape.UpperLeftColumn;
			int num2 = ((shape.LowerDeltaY == 0) ? (shape.LowerRightRow - 1) : shape.LowerRightRow);
			int num3 = ((shape.LowerDeltaX == 0) ? (shape.LowerRightColumn - 1) : shape.LowerRightColumn);
			if (isContained)
			{
				if (upperLeftRow >= ca.StartRow && upperLeftColumn >= ca.StartColumn && num2 <= ca.EndRow && num3 <= ca.EndColumn)
				{
					flag = true;
				}
			}
			else if (upperLeftRow >= ca.StartRow - 1 && upperLeftColumn >= ca.StartColumn - 1 && upperLeftRow <= ca.EndRow && upperLeftColumn <= ca.EndColumn && num2 >= ca.StartRow && num3 >= ca.StartColumn && num2 <= ca.EndRow + 1 && num3 <= ca.EndColumn + 1)
			{
				flag = true;
			}
			if (flag)
			{
				num = base.Count;
				method_12(shape, null, copyOptions_);
				Shape shape2 = this[num];
				PlacementType placement = shape2.Placement;
				shape2.Placement = PlacementType.Move;
				shape2.UpperLeftRow = shape2.UpperLeftRow - ca.StartRow + destRow;
				shape2.UpperLeftColumn = shape2.UpperLeftColumn - ca.StartColumn + destColumn;
				shape2.Placement = placement;
			}
		}
	}

	/// <summary>
	///       Delete shapes in the range.Comment shapes will not be deleted.
	///       </summary>
	/// <param name="ca">The range.If the shapes are contained in the range, they will be removed.</param>
	public void DeleteInRange(CellArea ca)
	{
		int num = base.Count;
		int num2 = 1;
		for (int i = 0; i < num; i++)
		{
			Shape shape = this[i];
			if (shape.method_33() || shape.MsoDrawingType == MsoDrawingType.Comment || shape.UpperLeftRow < ca.StartRow || shape.UpperLeftColumn < ca.StartColumn)
			{
				continue;
			}
			int num3 = ((shape.LowerDeltaY == 0) ? (shape.LowerRightRow - 1) : shape.LowerRightRow);
			int num4 = ((shape.LowerDeltaX == 0) ? (shape.LowerRightColumn - 1) : shape.LowerRightColumn);
			if (num3 <= ca.EndRow && num4 <= ca.EndColumn)
			{
				num2 = shape.method_5();
				method_26(shape);
				i -= num2;
				num -= num2;
				if (i < -1)
				{
					i = -1;
				}
			}
		}
	}

	/// <summary>
	///       Delete a shape. If the shape is in the group or is a comment shape, it will not be deleted.
	///       </summary>
	/// <param name="shape">
	/// </param>
	public void DeleteShape(Shape shape)
	{
		if (!shape.method_33() && shape.MsoDrawingType != MsoDrawingType.Comment)
		{
			method_26(shape);
		}
	}

	internal void method_10(ShapeCollection shapeCollection_0, int int_0, int int_1, int int_2)
	{
		new CopyOptions(bool_6: false);
		if (int_0 != int_1 || shapeCollection_0 != this)
		{
			method_37().Comments.CopyColumns(shapeCollection_0.method_37().Comments, int_0, int_1, int_2);
			method_37().Charts.method_1(shapeCollection_0.method_37().Charts, int_0, int_1, int_2);
		}
	}

	internal void method_11(ShapeCollection shapeCollection_0, int int_0, int int_1, int int_2)
	{
		CopyOptions copyOptions_ = new CopyOptions(bool_6: false);
		if (int_0 == int_1 && shapeCollection_0 == this)
		{
			return;
		}
		int num = int_0 + int_2 - 1;
		int num2 = int_1 - int_0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		Shape shape = null;
		int count = shapeCollection_0.Count;
		for (int i = 0; i < count; i++)
		{
			Shape shape2 = shapeCollection_0[i];
			if ((double)shape2.Width < double.Epsilon || (double)shape2.Height < double.Epsilon || shape2.method_33())
			{
				continue;
			}
			if (shape2.MsoDrawingType == MsoDrawingType.Comment)
			{
				CommentShape commentShape = (CommentShape)shape2;
				Comment comment = commentShape.method_69();
				if (comment.Row >= int_0 && comment.Row < int_0 + int_2)
				{
					int index = method_37().Comments.Add(int_1 + comment.Row - int_0, comment.Column);
					Comment comment2 = method_37().Comments[index];
					comment2.Copy(comment);
					comment2.CommentShape.Width = commentShape.Width;
					comment2.CommentShape.Height = commentShape.Height;
				}
			}
			else
			{
				if (shape2.Placement == PlacementType.FreeFloating)
				{
					continue;
				}
				num3 = shape2.UpperLeftRow;
				num4 = shape2.LowerRightRow;
				num5 = (((float)shape2.UpperDeltaY == Class1698.float_1) ? (num3 + 1) : num3);
				num6 = ((shape2.LowerDeltaY == 0) ? (num4 - 1) : num4);
				if ((num5 >= int_0 || int_0 - num5 == 1) && (num6 <= num || num6 - num == 1))
				{
					shape = method_12(shape2, null, copyOptions_);
					switch (shape.Placement)
					{
					case PlacementType.Move:
						shape.method_27().method_7().method_6(num3 + num2);
						break;
					case PlacementType.MoveAndSize:
						shape.method_27().method_7().method_6(num3 + num2);
						shape.method_27().method_7().method_10(num4 + num2);
						break;
					}
				}
			}
		}
	}

	internal void CopyInRange(ShapeCollection shapeCollection_0, CellArea cellArea_0, CellArea cellArea_1, CopyOptions copyOptions_0)
	{
		int count = shapeCollection_0.Count;
		for (int i = 0; i < count; i++)
		{
			Shape shape = shapeCollection_0[i];
			if (!shape.method_33() && shape.MsoDrawingType != MsoDrawingType.Comment)
			{
				PlacementType placement = shape.Placement;
				shape.Placement = PlacementType.MoveAndSize;
				int num = (((float)shape.UpperDeltaX == Class1698.float_0) ? (shape.UpperLeftColumn + 1) : shape.UpperLeftColumn);
				int num2 = ((shape.LowerDeltaX == 0) ? (shape.LowerRightColumn - 1) : shape.LowerRightColumn);
				int num3 = (((float)shape.UpperDeltaY == Class1698.float_1) ? (shape.UpperLeftRow + 1) : shape.UpperLeftRow);
				int num4 = ((shape.LowerDeltaY == 0) ? (shape.LowerRightRow - 1) : shape.LowerRightRow);
				int num5 = cellArea_1.StartRow - cellArea_0.StartRow;
				int num6 = cellArea_1.StartColumn - cellArea_0.StartColumn;
				if (num >= cellArea_0.StartColumn && num2 <= cellArea_0.EndColumn && num3 >= cellArea_0.StartRow && num4 <= cellArea_0.EndRow)
				{
					shape.Placement = PlacementType.Move;
					Shape shape2 = method_12(shape, null, copyOptions_0);
					Class1698 @class = shape2.method_27().method_7();
					@class.method_6(@class.method_5() + num5);
					Class1698 class2 = shape2.method_27().method_7();
					class2.method_8(class2.method_7() + num6);
					shape2.Placement = placement;
				}
				shape.Placement = placement;
			}
		}
	}

	internal void Copy(ShapeCollection shapeCollection_0, CopyOptions copyOptions_0)
	{
		int count = base.Count;
		foreach (Shape item in shapeCollection_0)
		{
			if (!item.method_33() && item.MsoDrawingType != MsoDrawingType.Unknown)
			{
				method_12(item, null, copyOptions_0);
			}
		}
		if (worksheetCollection_0 != shapeCollection_0.worksheetCollection_0 || method_33() != shapeCollection_0.method_33() || count != 0)
		{
			return;
		}
		arrayList_0 = shapeCollection_0.arrayList_0;
		foreach (Shape item2 in shapeCollection_0)
		{
			if (item2.MsoDrawingType == MsoDrawingType.Unknown && item2.class1556_0 != null && !item2.class1556_0.bool_0)
			{
				Shape shape3 = ((!item2.method_30()) ? AddShape(MsoDrawingType.Unknown, 0, 0, 0, 0, 0, 0) : AddShapeInChart(MsoDrawingType.Unknown, PlacementType.Move, 0, 0, 0, 0));
				shape3.class1556_0 = new Class1556();
				shape3.class1556_0.int_1 = item2.class1556_0.int_1;
				shape3.class1556_0.string_3 = item2.class1556_0.string_3;
				shape3.class1556_0.int_2 = item2.class1556_0.int_2;
			}
		}
	}

	internal Shape method_12(Shape shape_0, GroupShape groupShape_0, CopyOptions copyOptions_0)
	{
		Shape shape = null;
		switch (shape_0.MsoDrawingType)
		{
		case MsoDrawingType.Group:
		{
			GroupShape groupShape = (GroupShape)shape_0;
			GroupShape groupShape2 = new GroupShape(this);
			shape = groupShape2;
			groupShape2.Copy(groupShape, copyOptions_0);
			Add(groupShape2);
			Shape[] groupedShapes = groupShape.GetGroupedShapes();
			if (groupedShapes != null && groupedShapes.Length != 0)
			{
				Shape[] array = groupedShapes;
				foreach (Shape shape_2 in array)
				{
					method_12(shape_2, groupShape2, copyOptions_0);
				}
			}
			else
			{
				groupShape2.method_74();
			}
			break;
		}
		case MsoDrawingType.Line:
		{
			LineShape lineShape_ = (LineShape)shape_0;
			LineShape lineShape = new LineShape(this);
			shape = lineShape;
			lineShape.Copy(lineShape_, copyOptions_0);
			Add(lineShape);
			break;
		}
		case MsoDrawingType.Rectangle:
		{
			RectangleShape rectangleShape_ = (RectangleShape)shape_0;
			RectangleShape rectangleShape = new RectangleShape(this);
			shape = rectangleShape;
			rectangleShape.Copy(rectangleShape_, copyOptions_0);
			Add(rectangleShape);
			break;
		}
		case MsoDrawingType.Oval:
		{
			Oval oval_ = (Oval)shape_0;
			Oval oval = new Oval(this);
			shape = oval;
			oval.Copy(oval_, copyOptions_0);
			Add(oval);
			break;
		}
		case MsoDrawingType.Arc:
		{
			ArcShape arcShape_ = (ArcShape)shape_0;
			ArcShape arcShape = new ArcShape(this);
			shape = arcShape;
			arcShape.Copy(arcShape_, copyOptions_0);
			Add(arcShape);
			break;
		}
		case MsoDrawingType.Chart:
		{
			Chart chart = new Chart(worksheet_0);
			chart.ChartObject.Copy((ChartShape)shape_0, copyOptions_0);
			shape = chart.ChartObject;
			Add(chart.ChartObject);
			if (!method_33())
			{
				worksheetCollection_0[worksheet_0.SheetIndex].Charts.Add(chart);
			}
			break;
		}
		case MsoDrawingType.TextBox:
		{
			TextBox textBox_ = (TextBox)shape_0;
			TextBox textBox = new TextBox(this);
			shape = textBox;
			textBox.Copy(textBox_, copyOptions_0);
			Add(textBox);
			if (!method_33())
			{
				worksheetCollection_0[worksheet_0.SheetIndex].TextBoxes.Add(textBox);
			}
			break;
		}
		case MsoDrawingType.Button:
		{
			Button button_ = (Button)shape_0;
			Button button = new Button(this);
			shape = button;
			button.Copy(button_, copyOptions_0);
			Add(button);
			break;
		}
		case MsoDrawingType.Picture:
		{
			Picture picture_ = (Picture)shape_0;
			Picture picture = new Picture(this);
			shape = picture;
			picture.Copy(picture_, copyOptions_0);
			Add(picture);
			if (!method_33())
			{
				worksheetCollection_0[worksheet_0.SheetIndex].Pictures.Add(picture);
			}
			break;
		}
		case MsoDrawingType.Polygon:
		{
			Class1347 shape_ = (Class1347)shape_0;
			Class1347 @class = new Class1347(this);
			shape = @class;
			@class.Copy(shape_, copyOptions_0);
			Add(@class);
			break;
		}
		case MsoDrawingType.CheckBox:
		{
			CheckBox checkBox_ = (CheckBox)shape_0;
			CheckBox checkBox = new CheckBox(this);
			shape = checkBox;
			checkBox.Copy(checkBox_, copyOptions_0);
			Add(checkBox);
			worksheetCollection_0[worksheet_0.SheetIndex].CheckBoxes.Add(checkBox);
			break;
		}
		case MsoDrawingType.RadioButton:
		{
			RadioButton radioButton_ = (RadioButton)shape_0;
			RadioButton radioButton = new RadioButton(this);
			shape = radioButton;
			radioButton.Copy(radioButton_, copyOptions_0);
			Add(radioButton);
			break;
		}
		case MsoDrawingType.Label:
		{
			Label label_ = (Label)shape_0;
			Label label = new Label(this);
			shape = label;
			label.Copy(label_, copyOptions_0);
			Add(label);
			break;
		}
		case MsoDrawingType.Spinner:
		{
			Spinner spinner_ = (Spinner)shape_0;
			Spinner spinner = new Spinner(this);
			shape = spinner;
			spinner.Copy(spinner_, copyOptions_0);
			Add(spinner);
			break;
		}
		case MsoDrawingType.ScrollBar:
		{
			ScrollBar scrollBar_ = (ScrollBar)shape_0;
			ScrollBar scrollBar = new ScrollBar(this);
			shape = scrollBar;
			scrollBar.Copy(scrollBar_, copyOptions_0);
			Add(scrollBar);
			break;
		}
		case MsoDrawingType.ListBox:
		{
			ListBox listBox_ = (ListBox)shape_0;
			ListBox listBox = new ListBox(this);
			shape = listBox;
			listBox.Copy(listBox_, copyOptions_0);
			Add(listBox);
			break;
		}
		case MsoDrawingType.GroupBox:
		{
			GroupBox groupBox_ = (GroupBox)shape_0;
			GroupBox groupBox = new GroupBox(this);
			shape = groupBox;
			groupBox.Copy(groupBox_, copyOptions_0);
			Add(groupBox);
			break;
		}
		case MsoDrawingType.ComboBox:
		{
			ComboBox comboBox_ = (ComboBox)shape_0;
			ComboBox comboBox = new ComboBox(this);
			shape = comboBox;
			comboBox.Copy(comboBox_, copyOptions_0);
			Add(comboBox);
			break;
		}
		case MsoDrawingType.OleObject:
		{
			OleObject oleObject_ = (OleObject)shape_0;
			OleObject oleObject = new OleObject(this);
			shape = oleObject;
			oleObject.Copy(oleObject_, copyOptions_0);
			Add(oleObject);
			if (!method_33())
			{
				worksheetCollection_0[worksheet_0.SheetIndex].OleObjects.Add(oleObject);
			}
			break;
		}
		case MsoDrawingType.Comment:
		{
			Comment comment = ((CommentShape)shape_0).method_69();
			Comment comment2 = new Comment(method_37().Comments, (ushort)comment.Row, (byte)comment.Column);
			comment2.CommentShape.Copy((CommentShape)shape_0, copyOptions_0);
			shape = comment2.CommentShape;
			Add(comment2.CommentShape);
			if (!method_33())
			{
				worksheetCollection_0[worksheet_0.SheetIndex].Comments.Add(comment2);
			}
			break;
		}
		default:
			shape = new Shape(this, shape_0.MsoDrawingType, this);
			shape.Copy(shape_0, copyOptions_0);
			Add(shape);
			break;
		case MsoDrawingType.CellsDrawing:
		{
			CellsDrawing cellsDrawing_ = (CellsDrawing)shape_0;
			CellsDrawing cellsDrawing = new CellsDrawing(this);
			shape = cellsDrawing;
			cellsDrawing.Copy(cellsDrawing_, copyOptions_0);
			Add(cellsDrawing);
			break;
		}
		}
		if (method_36() != shape_0.method_25() && shape.method_28() != null && !copyOptions_0.bool_0)
		{
			shape.method_28().arrayList_0 = null;
		}
		if (method_36() != shape_0.method_25() && copyOptions_0.bool_0 && shape_0.method_23() != shape.method_23())
		{
			shape.method_24(shape_0.method_23());
			if (ushort_0 < shape.method_23())
			{
				ushort_0 = shape.method_23();
			}
		}
		groupShape_0?.Add(shape);
		return shape;
	}

	/// <summary>
	///       Group the shapes.
	///       </summary>
	/// <param name="groupItems">the group items.</param>
	/// <returns>Return the group shape.</returns>
	/// <remarks>
	///
	///       The shape in the groupItems should not be grouped.
	///       The shape must be in this Shapes collection.</remarks>
	public GroupShape Group(Shape[] groupItems)
	{
		if (method_34())
		{
			return null;
		}
		GroupShape groupShape = new GroupShape(this);
		Add(groupShape);
		int[][] array = new int[groupItems.Length][];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		while (true)
		{
			if (num5 < groupItems.Length)
			{
				if (groupItems[num5].Shapes == this)
				{
					if (!groupItems[num5].IsGroup)
					{
						if (!groupItems[num5].method_28().method_6())
						{
							groupItems[num5].method_27().method_9().method_7(bool_0: true);
							int num6 = 0;
							int num7 = 0;
							int[] array2 = new int[4];
							if (method_33())
							{
								switch (groupItems[0].Placement)
								{
								case PlacementType.Move:
								{
									array2[0] = groupItems[num5].method_27().method_7().Left;
									array2[1] = groupItems[num5].method_27().method_7().Top;
									Chart chart = (Chart)groupItems[num5].Shapes.method_35();
									array2[2] = (int)((double)((float)groupItems[num5].method_27().method_7().Right * 4000f / (float)chart.ChartObject.Width) + 0.5);
									array2[3] = (int)((double)((float)groupItems[num5].method_27().method_7().Bottom * 4000f / (float)chart.ChartObject.Height) + 0.5);
									break;
								}
								case PlacementType.MoveAndSize:
									array2[0] = groupItems[num5].method_27().method_7().Left;
									array2[1] = groupItems[num5].method_27().method_7().Top;
									array2[2] = groupItems[num5].method_27().method_7().Right;
									array2[3] = groupItems[num5].method_27().method_7().Bottom;
									break;
								}
							}
							else
							{
								switch (groupItems[num5].Placement)
								{
								case PlacementType.FreeFloating:
									array2[0] = groupItems[num5].method_27().method_7().Left;
									array2[1] = groupItems[num5].method_27().method_7().Top;
									array2[2] = groupItems[num5].method_27().method_7().Right;
									array2[3] = groupItems[num5].method_27().method_7().Bottom;
									break;
								case PlacementType.Move:
									num6 = groupItems[num5].method_27().method_7().method_7();
									num7 = groupItems[num5].method_27().method_7().Left;
									array2[0] = groupItems[num5].method_44(0, 0, num6, num7);
									num6 = groupItems[num5].method_27().method_7().method_5();
									num7 = groupItems[num5].method_27().method_7().Top;
									array2[1] = groupItems[num5].method_41(0, 0, num6, num7);
									array2[2] = groupItems[num5].method_27().method_7().Right;
									array2[3] = groupItems[num5].method_27().method_7().Bottom;
									break;
								case PlacementType.MoveAndSize:
								{
									int num8 = groupItems[num5].method_27().method_7().method_7();
									int left = groupItems[num5].method_27().method_7().Left;
									array2[0] = groupItems[num5].method_44(0, 0, num8, left);
									num6 = groupItems[num5].method_27().method_7().method_11();
									num7 = groupItems[num5].method_27().method_7().Right;
									array2[2] = groupItems[num5].method_44(num8, left, num6, num7);
									num8 = groupItems[num5].method_27().method_7().method_5();
									left = groupItems[num5].method_27().method_7().Top;
									array2[1] = groupItems[num5].method_41(0, 0, num8, left);
									num6 = groupItems[num5].method_27().method_7().method_9();
									num7 = groupItems[num5].method_27().method_7().Bottom;
									array2[3] = groupItems[num5].method_41(num8, left, num6, num7);
									break;
								}
								}
							}
							array[num5] = array2;
							if (num5 == 0)
							{
								num = array2[0];
								num2 = array2[1];
								num3 = array2[2] + array2[0];
								num4 = array2[3] + array2[1];
							}
							else
							{
								if (num > array2[0])
								{
									num = array2[0];
								}
								if (num2 > array2[1])
								{
									num2 = array2[1];
								}
								if (num3 < array2[0] + array2[2])
								{
									num3 = array2[0] + array2[2];
								}
								if (num4 < array2[1] + array2[3])
								{
									num4 = array2[1] + array2[3];
								}
							}
							num5++;
							continue;
						}
						throw new CellsException(ExceptionType.Limitation, "Could not be grouped.");
					}
					throw new CellsException(ExceptionType.Limitation, "Please ungroup the shape before grouping shapes");
				}
				throw new CellsException(ExceptionType.Limitation, "Please add the shape to here.");
			}
			int num9 = num3 - num;
			int num10 = num4 - num2;
			groupShape.method_27().method_7().Left = num;
			groupShape.method_27().method_7().Top = num2;
			groupShape.method_27().method_7().Right = num9;
			groupShape.method_27().method_7().Bottom = num10;
			groupShape.method_69().int_0 = num;
			groupShape.method_69().int_2 = num2;
			groupShape.method_69().int_1 = num9;
			groupShape.method_69().int_3 = num10;
			groupShape.method_27().method_7().method_4(PlacementType.FreeFloating);
			if (!method_33())
			{
				groupShape.Placement = PlacementType.MoveAndSize;
			}
			for (int i = 0; i < groupItems.Length; i++)
			{
				int[] array3 = array[i];
				groupItems[i].method_27().method_7().Left = (int)((double)((float)(array3[0] - num) * 4000f / (float)num9) + 0.5);
				groupItems[i].method_27().method_7().Top = (int)((double)((float)(array3[1] - num2) * 4000f / (float)num10) + 0.5);
				groupItems[i].method_27().method_7().Right = (int)((double)((float)array3[2] * 4000f / (float)num9) + 0.5);
				groupItems[i].method_27().method_7().Bottom = (int)((double)((float)array3[3] * 4000f / (float)num10) + 0.5);
				groupShape.Add(groupItems[i]);
			}
			break;
		}
		return groupShape;
	}

	internal void method_13(GroupShape groupShape_0, Shape[] shape_0)
	{
		for (int i = 0; i < shape_0.Length; i++)
		{
			shape_0[i].method_27().method_9().method_7(bool_0: true);
		}
		int int_ = groupShape_0.method_69().int_0;
		int int_2 = groupShape_0.method_69().int_2;
		int int_3 = groupShape_0.method_69().int_1;
		int int_4 = groupShape_0.method_69().int_3;
		for (int j = 0; j < shape_0.Length; j++)
		{
			shape_0[j].method_27().method_7().Left = (int)((double)((float)(shape_0[j].method_27().method_7().Left - int_) * 4000f / (float)int_3) + 0.5);
			shape_0[j].method_27().method_7().Top = (int)((double)((float)(shape_0[j].method_27().method_7().Top - int_2) * 4000f / (float)int_4) + 0.5);
			shape_0[j].method_27().method_7().Right = (int)((double)((float)shape_0[j].method_27().method_7().Right * 4000f / (float)int_3) + 0.5);
			shape_0[j].method_27().method_7().Bottom = (int)((double)((float)shape_0[j].method_27().method_7().Bottom * 4000f / (float)int_4) + 0.5);
			groupShape_0.Add(shape_0[j]);
		}
	}

	internal void method_14(GroupShape groupShape_0, Shape[] shape_0)
	{
		for (int i = 0; i < shape_0.Length; i++)
		{
			shape_0[i].method_27().method_9().method_7(bool_0: true);
		}
		_ = groupShape_0.method_69().int_0;
		_ = groupShape_0.method_69().int_2;
		int int_ = groupShape_0.method_69().int_1;
		int int_2 = groupShape_0.method_69().int_3;
		for (int j = 0; j < shape_0.Length; j++)
		{
			shape_0[j].method_27().method_7().Left = (int)((double)((float)shape_0[j].method_27().method_7().Left * 4000f / (float)int_) + 0.5);
			shape_0[j].method_27().method_7().Top = (int)((double)((float)shape_0[j].method_27().method_7().Top * 4000f / (float)int_2) + 0.5);
			shape_0[j].method_27().method_7().Right = (int)((double)((float)shape_0[j].method_27().method_7().Right * 4000f / (float)int_) + 0.5);
			shape_0[j].method_27().method_7().Bottom = (int)((double)((float)shape_0[j].method_27().method_7().Bottom * 4000f / (float)int_2) + 0.5);
			groupShape_0.Add(shape_0[j]);
		}
	}

	/// <summary>
	///       Ungroups the shape items.
	///       </summary>
	/// <param name="group">The group shape.</param>
	/// <remarks>If the group shape is grouped by another group shape,nothing will be done.</remarks>
	public void Ungroup(GroupShape group)
	{
		if (!group.IsGroup || group.method_33())
		{
			return;
		}
		Shape[] groupedShapes = group.GetGroupedShapes();
		if (method_33())
		{
			group.Placement = PlacementType.MoveAndSize;
			int left = group.method_27().method_7().Left;
			int top = group.method_27().method_7().Top;
			int right = group.method_27().method_7().Right;
			int bottom = group.method_27().method_7().Bottom;
			foreach (Shape shape in groupedShapes)
			{
				shape.object_0 = group.object_0;
				shape.method_27().method_9().method_7(bool_0: false);
				shape.method_27().method_7().method_4(PlacementType.MoveAndSize);
				shape.method_27().method_7().Left = (int)((double)((float)(right * shape.method_27().method_7().Left) / 4000f) + 0.5 + (double)left);
				shape.method_27().method_7().Top = (int)((double)((float)(bottom * shape.method_27().method_7().Top) / 4000f) + 0.5 + (double)top);
				int right2 = (int)((double)((float)(right * shape.method_27().method_7().Right) / 4000f) + 0.5 + (double)shape.method_27().method_7().Left);
				shape.method_27().method_7().Right = right2;
				right2 = (int)((double)((float)(bottom * shape.method_27().method_7().Bottom) / 4000f) + 0.5 + (double)shape.method_27().method_7().Top);
				shape.method_27().method_7().Bottom = right2;
			}
		}
		else
		{
			group.Placement = PlacementType.Move;
			int int_ = group.method_27().method_7().method_7();
			int left2 = group.method_27().method_7().Left;
			int int_2 = group.method_27().method_7().method_5();
			int top2 = group.method_27().method_7().Top;
			int right3 = group.method_27().method_7().Right;
			int bottom2 = group.method_27().method_7().Bottom;
			int num = 0;
			int[] array = null;
			int[] array2 = null;
			foreach (Shape shape2 in groupedShapes)
			{
				shape2.method_27().method_9().method_7(bool_0: false);
				shape2.object_0 = group.object_0;
				shape2.method_27().method_7().method_4(PlacementType.MoveAndSize);
				num = (int)((double)((float)(right3 * shape2.method_27().method_7().Left) / 4000f) + 0.5);
				array = shape2.method_45(int_, left2, num);
				shape2.method_27().method_7().method_8(array[0]);
				shape2.method_27().method_7().Left = array[1];
				num = (int)((double)((float)(bottom2 * shape2.method_27().method_7().Top) / 4000f) + 0.5);
				array2 = shape2.method_40(int_2, top2, num);
				shape2.method_27().method_7().method_6(array2[0]);
				shape2.method_27().method_7().Top = array2[1];
				num = (int)((double)((float)(right3 * shape2.method_27().method_7().Right) / 4000f) + 0.5);
				array = shape2.method_45(array[0], array[1], num);
				shape2.method_27().method_7().method_12(array[0]);
				shape2.method_27().method_7().Right = array[1];
				num = (int)((double)((float)(bottom2 * shape2.method_27().method_7().Bottom) / 4000f) + 0.5);
				array2 = shape2.method_40(array2[0], array2[1], num);
				shape2.method_27().method_7().method_10(array2[0]);
				shape2.method_27().method_7().Bottom = array2[1];
			}
		}
		group.method_75();
		method_26(group);
	}

	/// <summary>
	///       Remove the shape.
	///       </summary>
	/// <param name="index">The index of the shape.</param>
	public new void RemoveAt(int index)
	{
		method_26(this[index]);
	}

	/// <summary>
	///       Remove the shape.
	///       </summary>
	/// <param name="shape">
	/// </param>
	public void Remove(Shape shape)
	{
		DeleteShape(shape);
	}

	/// <summary>
	///       Update the selected value by the value of the linked cell of the shapes.
	///       </summary>
	public void UpdateSelectedValue()
	{
		for (int i = 0; i < base.Count; i++)
		{
			this[i].UpdateSelectedValue();
		}
	}

	internal void method_15(int int_0)
	{
		method_26(this[int_0]);
	}

	internal void method_16(int int_0)
	{
		base.InnerList.RemoveAt(int_0);
	}

	internal void method_17(int int_0, Shape shape_0)
	{
		if (int_0 >= base.Count)
		{
			base.InnerList.Add(shape_0);
		}
		else
		{
			base.InnerList.Insert(int_0, shape_0);
		}
	}

	internal void method_18(Shape shape_0)
	{
		base.InnerList.Remove(shape_0);
	}

	internal void method_19(int int_0)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Shape shape = (Shape)enumerator.Current;
				if (shape.method_23() == int_0)
				{
					method_26(shape);
					break;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal void method_20(int int_0, int int_1, Worksheet worksheet_1, bool bool_0)
	{
		if (int_1 == 0)
		{
			return;
		}
		if (method_37().Comments.Count != 0)
		{
			method_37().Comments.method_3(int_0, int_1);
		}
		if (method_37().Charts.Count != 0)
		{
			method_37().Charts.InsertRows(int_0, int_1, worksheet_1, bool_0);
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Shape shape = (Shape)enumerator.Current;
				if (shape.method_58() != null)
				{
					byte[] array = shape.method_58();
					Class1674.InsertRows(worksheet_1, bool_0, int_0, int_1, 0, 0, 0, array.Length - 1, array);
				}
				switch (shape.MsoDrawingType)
				{
				case MsoDrawingType.ListBox:
				{
					ListBox listBox = (ListBox)shape;
					if (listBox.method_69() != null)
					{
						byte[] array3 = listBox.method_69();
						Class1674.InsertRows(worksheet_1, bool_0, int_0, int_1, 0, 0, 0, array3.Length - 1, array3);
					}
					break;
				}
				case MsoDrawingType.ComboBox:
				{
					ComboBox comboBox = (ComboBox)shape;
					if (comboBox.method_70() != null)
					{
						byte[] array2 = comboBox.method_70();
						Class1674.InsertRows(worksheet_1, bool_0, int_0, int_1, 0, 0, 0, array2.Length - 1, array2);
					}
					break;
				}
				}
				if (shape.method_33())
				{
					continue;
				}
				switch (shape.Placement)
				{
				case PlacementType.Move:
				{
					int upperLeftRow = shape.UpperLeftRow;
					_ = shape.UpperDeltaY;
					if (int_0 <= upperLeftRow)
					{
						if (int_1 < 0 && int_0 - int_1 > upperLeftRow)
						{
							shape.UpperDeltaY = 0;
							upperLeftRow = int_0;
						}
						else
						{
							upperLeftRow += int_1;
						}
						if (upperLeftRow > 1048575)
						{
							throw new CellsException(ExceptionType.Shape, "Can not shift object off the sheet.");
						}
						shape.UpperLeftRow = upperLeftRow;
					}
					break;
				}
				case PlacementType.MoveAndSize:
				{
					int upperLeftRow = shape.UpperLeftRow;
					_ = shape.UpperDeltaY;
					int num = shape.LowerRightRow;
					int lowerDeltaY = shape.LowerDeltaY;
					if (int_1 > 0)
					{
						if (int_0 <= upperLeftRow)
						{
							upperLeftRow += int_1;
							num += int_1;
							if (upperLeftRow <= 1048575 && num <= 1048575)
							{
								shape.method_27().method_7().method_6(upperLeftRow);
								shape.method_27().method_7().method_10(num);
								break;
							}
							throw new CellsException(ExceptionType.Shape, "Can not shift object off the sheet.");
						}
						if (lowerDeltaY == 0)
						{
							num--;
						}
						if (int_0 <= num)
						{
							num += int_1;
							if (lowerDeltaY == 0)
							{
								num++;
							}
							shape.method_27().method_7().method_10(num);
						}
						break;
					}
					int num2 = ((lowerDeltaY == 0) ? (num - 1) : num);
					int num3 = int_0 - int_1 - 1;
					if (int_0 < upperLeftRow)
					{
						if (num3 < upperLeftRow)
						{
							upperLeftRow += int_1;
							num += int_1;
							shape.method_27().method_7().method_6(upperLeftRow);
							shape.method_27().method_7().method_10(num);
						}
						else if (num3 < num2)
						{
							upperLeftRow = int_0;
							shape.method_27().method_7().Top = 0;
							num += int_1;
							shape.method_27().method_7().method_6(upperLeftRow);
							shape.method_27().method_7().method_10(num);
						}
						else
						{
							shape.method_27().method_7().method_6(int_0);
							shape.method_27().method_7().Top = 0;
							shape.method_27().method_7().method_10(int_0);
							shape.method_27().method_7().Bottom = 0;
						}
					}
					else if (int_0 <= num2)
					{
						if (num3 < num2)
						{
							shape.method_27().method_7().method_10(num + int_1);
							break;
						}
						shape.method_27().method_7().method_10(int_0);
						shape.method_27().method_7().Bottom = 0;
					}
					break;
				}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal void method_21(int int_0, int int_1, Worksheet worksheet_1, bool bool_0)
	{
		if (int_1 == 0)
		{
			return;
		}
		if (method_37().Comments.Count != 0)
		{
			method_37().Comments.method_4(int_0, int_1);
		}
		if (method_37().Charts.Count != 0)
		{
			method_37().Charts.InsertColumns(int_0, int_1, worksheet_1, bool_0);
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Shape shape = (Shape)enumerator.Current;
				if (shape.method_58() != null)
				{
					byte[] array = shape.method_58();
					Class1674.InsertColumns(worksheet_1, bool_0, int_0, int_1, 0, 0, 0, array.Length - 1, array);
				}
				switch (shape.MsoDrawingType)
				{
				case MsoDrawingType.ListBox:
				{
					ListBox listBox = (ListBox)shape;
					if (listBox.method_69() != null)
					{
						byte[] array3 = listBox.method_69();
						Class1674.InsertColumns(worksheet_1, bool_0, int_0, int_1, 0, 0, 0, array3.Length - 1, array3);
					}
					break;
				}
				case MsoDrawingType.ComboBox:
				{
					ComboBox comboBox = (ComboBox)shape;
					if (comboBox.method_70() != null)
					{
						byte[] array2 = comboBox.method_70();
						Class1674.InsertColumns(worksheet_1, bool_0, int_0, int_1, 0, 0, 0, array2.Length - 1, array2);
					}
					break;
				}
				}
				if (shape.method_33())
				{
					continue;
				}
				switch (shape.Placement)
				{
				case PlacementType.Move:
				{
					int upperLeftColumn = shape.UpperLeftColumn;
					_ = shape.UpperDeltaX;
					if (int_0 <= upperLeftColumn)
					{
						if (int_1 < 0 && int_0 - int_1 > upperLeftColumn)
						{
							shape.UpperDeltaX = 0;
							upperLeftColumn = int_0;
						}
						else
						{
							upperLeftColumn += int_1;
						}
						if (upperLeftColumn > 16383)
						{
							throw new CellsException(ExceptionType.Limitation, "Can not shift object off the sheet.");
						}
						shape.UpperLeftColumn = upperLeftColumn;
					}
					break;
				}
				case PlacementType.MoveAndSize:
				{
					int upperLeftColumn = shape.UpperLeftColumn;
					_ = shape.UpperDeltaX;
					int num = shape.LowerRightColumn;
					int lowerDeltaX = shape.LowerDeltaX;
					if (int_1 > 0)
					{
						if (int_0 <= upperLeftColumn)
						{
							upperLeftColumn += int_1;
							num += int_1;
							if (upperLeftColumn <= 16383 && num <= 16383)
							{
								shape.method_27().method_7().method_8(upperLeftColumn);
								shape.method_27().method_7().method_12(num);
								break;
							}
							throw new CellsException(ExceptionType.Limitation, "Aspose.Cells cannot shift nonblank cell off the worksheet.");
						}
						if (lowerDeltaX == 0)
						{
							num--;
						}
						if (int_0 <= num)
						{
							num += int_1;
							if (lowerDeltaX == 0)
							{
								num++;
							}
							shape.method_27().method_7().method_12(num);
						}
						break;
					}
					int num2 = ((lowerDeltaX == 0) ? (num - 1) : num);
					int num3 = int_0 - int_1 - 1;
					if (int_0 < upperLeftColumn)
					{
						if (num3 < upperLeftColumn)
						{
							upperLeftColumn += int_1;
							num += int_1;
							shape.method_27().method_7().method_8(upperLeftColumn);
							shape.method_27().method_7().method_12(num);
						}
						else if (num3 < num2)
						{
							upperLeftColumn = int_0;
							shape.method_27().method_7().Left = 0;
							num += int_1;
							shape.method_27().method_7().method_8(upperLeftColumn);
							shape.method_27().method_7().method_12(num);
						}
						else
						{
							shape.method_27().method_7().method_8(int_0);
							shape.method_27().method_7().Left = 0;
							shape.method_27().method_7().method_12(int_0);
							shape.method_27().method_7().Right = 0;
						}
					}
					else if (int_0 <= num2)
					{
						if (num3 < num2)
						{
							shape.method_27().method_7().method_12(num + int_1);
							break;
						}
						shape.method_27().method_7().method_12(int_0);
						shape.method_27().method_7().Right = 0;
					}
					break;
				}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal void InsertRange(CellArea cellArea_0, int int_0, ShiftType shiftType_0, Worksheet worksheet_1, bool bool_0)
	{
		if (int_0 == 0)
		{
			return;
		}
		if (method_37().Comments.Count != 0)
		{
			method_37().Comments.method_5(cellArea_0, int_0, shiftType_0);
		}
		if (method_37().Charts.Count != 0)
		{
			method_37().Charts.method_2(cellArea_0, int_0, shiftType_0, worksheet_1, bool_0);
		}
		if (shiftType_0 == ShiftType.Left || shiftType_0 == ShiftType.Up)
		{
			return;
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Shape shape = (Shape)enumerator.Current;
				if (shape.method_58() != null)
				{
					byte[] array = shape.method_58();
					Class1674.smethod_19(cellArea_0, int_0, shiftType_0, worksheet_1, bool_0, array, 0, array.Length - 1, 0, 0, 0, 0);
				}
				switch (shape.MsoDrawingType)
				{
				case MsoDrawingType.ListBox:
				{
					ListBox listBox = (ListBox)shape;
					if (listBox.method_69() != null)
					{
						byte[] array3 = listBox.method_69();
						Class1674.smethod_19(cellArea_0, int_0, shiftType_0, worksheet_1, bool_0, array3, 0, array3.Length - 1, 0, 0, 0, 0);
					}
					break;
				}
				case MsoDrawingType.ComboBox:
				{
					ComboBox comboBox = (ComboBox)shape;
					if (comboBox.method_70() != null)
					{
						byte[] array2 = comboBox.method_70();
						Class1674.smethod_19(cellArea_0, int_0, shiftType_0, worksheet_1, bool_0, array2, 0, array2.Length - 1, 0, 0, 0, 0);
					}
					break;
				}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		switch (shiftType_0)
		{
		case ShiftType.Down:
			method_23(cellArea_0, int_0);
			break;
		case ShiftType.Left:
			method_24(cellArea_0, int_0);
			break;
		case ShiftType.Right:
			method_22(cellArea_0, int_0);
			break;
		case ShiftType.Up:
			method_25(cellArea_0, int_0);
			break;
		case ShiftType.None:
			break;
		}
	}

	private void method_22(CellArea cellArea_0, int int_0)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Shape shape = (Shape)enumerator.Current;
				if (shape.method_33())
				{
					continue;
				}
				switch (shape.Placement)
				{
				case PlacementType.Move:
					num2 = shape.UpperLeftColumn;
					num = shape.UpperLeftRow;
					num3 = shape.LowerRightRow;
					if (num2 >= cellArea_0.StartColumn && cellArea_0.StartRow <= num && cellArea_0.EndRow >= num3)
					{
						shape.method_27().method_7().method_8(num2 + int_0);
					}
					break;
				case PlacementType.MoveAndSize:
					num2 = shape.UpperLeftColumn;
					num = shape.UpperLeftRow;
					num3 = shape.LowerRightRow;
					if (cellArea_0.StartRow <= num && cellArea_0.EndRow >= num3)
					{
						if (num2 >= cellArea_0.StartColumn)
						{
							Class1698 @class = shape.method_27().method_7();
							@class.method_8(@class.method_7() + int_0);
						}
						else if (num2 <= cellArea_0.EndColumn)
						{
							Class1698 class2 = shape.method_27().method_7();
							class2.method_12(class2.method_11() + int_0);
						}
					}
					break;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void method_23(CellArea cellArea_0, int int_0)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Shape shape = (Shape)enumerator.Current;
				if (shape.method_33())
				{
					continue;
				}
				switch (shape.Placement)
				{
				case PlacementType.Move:
					num2 = shape.UpperLeftColumn;
					num3 = shape.LowerRightColumn;
					num = shape.UpperLeftRow;
					if (cellArea_0.StartColumn <= num2 && cellArea_0.EndColumn >= num3 && num <= cellArea_0.StartRow)
					{
						shape.UpperLeftRow = num + int_0;
					}
					break;
				case PlacementType.MoveAndSize:
					num2 = shape.UpperLeftColumn;
					num3 = shape.LowerRightColumn;
					num = shape.UpperLeftRow;
					if (cellArea_0.StartColumn <= num2 && cellArea_0.EndColumn >= num3)
					{
						if (num >= cellArea_0.StartRow)
						{
							Class1698 @class = shape.method_27().method_7();
							@class.method_6(@class.method_5() + int_0);
						}
						else if (num <= cellArea_0.EndRow)
						{
							Class1698 class2 = shape.method_27().method_7();
							class2.method_10(class2.method_9() + int_0);
						}
					}
					break;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void method_24(CellArea cellArea_0, int int_0)
	{
	}

	private void method_25(CellArea cellArea_0, int int_0)
	{
	}

	internal void method_26(Shape shape_0)
	{
		if (shape_0.IsGroup)
		{
			GroupShape groupShape = (GroupShape)shape_0;
			Shape[] groupedShapes = groupShape.GetGroupedShapes();
			if (groupedShapes != null && groupedShapes.Length != 0)
			{
				Shape[] array = groupedShapes;
				foreach (Shape shape_ in array)
				{
					method_26(shape_);
				}
			}
		}
		base.InnerList.Remove(shape_0);
		if (object_0 is Worksheet)
		{
			switch (shape_0.MsoDrawingType)
			{
			case MsoDrawingType.OleObject:
				worksheet_0.OleObjects.Remove((OleObject)shape_0);
				break;
			case MsoDrawingType.Comment:
				worksheet_0.Comments.Remove(((CommentShape)shape_0).method_69());
				break;
			case MsoDrawingType.ComboBox:
			{
				Class1700 @class = method_4().method_2();
				@class.method_2(@class.method_1() - 1);
				break;
			}
			case MsoDrawingType.Chart:
				worksheet_0.Charts.Remove(((ChartShape)shape_0).method_69());
				break;
			case MsoDrawingType.TextBox:
				worksheet_0.TextBoxes.Remove((TextBox)shape_0);
				break;
			case MsoDrawingType.Picture:
				worksheet_0.Pictures.Remove((Picture)shape_0);
				method_27(((Picture)shape_0).method_70());
				break;
			case MsoDrawingType.CheckBox:
				worksheet_0.CheckBoxes.Remove((CheckBox)shape_0);
				break;
			}
			Worksheet worksheet = (Worksheet)object_0;
			if (worksheet.class1557_0 != null)
			{
				worksheet.class1557_0.method_1(shape_0);
			}
		}
	}

	internal void method_27(int int_0)
	{
		if (int_0 != 0)
		{
			if (method_28(int_0))
			{
				class1701_0.method_0().method_0()[int_0 - 1].method_8();
				return;
			}
			class1701_0.method_0().method_0().RemoveAt(int_0 - 1);
			method_30(int_0);
		}
	}

	internal bool method_28(int int_0)
	{
		int num = 0;
		while (true)
		{
			if (num < method_36().Count)
			{
				Worksheet worksheet = method_36()[num];
				if (worksheet.method_36() != null && worksheet.Shapes.Count > 0 && worksheet.Shapes.method_29(int_0))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal bool method_29(int int_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			switch (this[i].MsoDrawingType)
			{
			case MsoDrawingType.Picture:
			case MsoDrawingType.OleObject:
			{
				int num = this[i].method_27().method_2().method_4(16644, 0);
				if (num != 0 && num == int_0)
				{
					return true;
				}
				break;
			}
			case MsoDrawingType.Chart:
			{
				ShapeCollection shapeCollection = ((ChartShape)this[i]).method_69().method_16();
				if (shapeCollection != null && shapeCollection.method_29(int_0))
				{
					return true;
				}
				break;
			}
			}
		}
		return false;
	}

	internal void method_30(int int_0)
	{
		for (int i = 0; i < method_36().Count; i++)
		{
			Worksheet worksheet = method_36()[i];
			if (worksheet.method_36() != null && worksheet.Shapes.Count > 0)
			{
				worksheet.Shapes.method_31(int_0);
			}
		}
	}

	internal void method_31(int int_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			switch (this[i].MsoDrawingType)
			{
			case MsoDrawingType.Picture:
			case MsoDrawingType.OleObject:
			{
				int num = this[i].method_27().method_2().method_4(16644, 0);
				if (num != 0 && num > int_0)
				{
					this[i].method_27().method_2().method_1(16644, Enum183.const_0, num - 1);
				}
				break;
			}
			case MsoDrawingType.Chart:
				((ChartShape)this[i]).method_69().method_16()?.method_31(int_0);
				break;
			}
		}
	}

	internal int Add(Shape shape_0, Stream stream_0)
	{
		int result = 0;
		if (shape_0.method_23() == 0)
		{
			ushort_0++;
			shape_0.method_24(ushort_0);
			result = class1701_0.AddShape(shape_0, stream_0);
		}
		base.InnerList.Add(shape_0);
		return result;
	}

	internal void Add(Shape shape_0)
	{
		if (shape_0.method_23() == 0)
		{
			ushort_0++;
			shape_0.method_24(ushort_0);
			class1701_0.AddShape(shape_0);
		}
		base.InnerList.Add(shape_0);
	}

	internal void method_32(Shape shape_0, Stream stream_0)
	{
		base.InnerList.Add(shape_0);
	}

	[SpecialName]
	internal bool method_33()
	{
		return object_0 is Chart;
	}

	[SpecialName]
	internal bool method_34()
	{
		return object_0 is PageSetup;
	}

	[SpecialName]
	internal object method_35()
	{
		return object_0;
	}

	[SpecialName]
	internal WorksheetCollection method_36()
	{
		return worksheetCollection_0;
	}

	internal void SortNames(Hashtable hashtable_0)
	{
		if (worksheet_0.Charts.Count > 0)
		{
			worksheet_0.Charts.method_3(hashtable_0);
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Shape shape = (Shape)enumerator.Current;
				if (shape.method_58() != null)
				{
					Class1674.smethod_17(shape.method_58(), 0, shape.method_58().Length - 1, hashtable_0, worksheetCollection_0);
				}
				if (shape.method_28().arrayList_0 == null || shape.method_28().arrayList_0.Count == 0)
				{
					continue;
				}
				foreach (byte[] item in shape.method_28().arrayList_0)
				{
					switch (item[0])
					{
					case 9:
						if (BitConverter.ToUInt16(item, 4) != 0)
						{
							num3 = BitConverter.ToUInt16(item, 6);
							Class1674.smethod_17(item, 12, 12 + num3, hashtable_0, worksheetCollection_0);
						}
						break;
					case 4:
						num3 = BitConverter.ToUInt16(item, 4);
						num2 = BitConverter.ToUInt16(item, 6 + num3) - 1;
						if (hashtable_0[num2] != null)
						{
							num = (int)hashtable_0[num2] + 1;
							Array.Copy(BitConverter.GetBytes((ushort)num), 0, item, 6 + num3, 2);
						}
						break;
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	[SpecialName]
	internal Worksheet method_37()
	{
		return worksheet_0;
	}

	[SpecialName]
	internal bool method_38()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Shape shape = (Shape)enumerator.Current;
				if (shape.MsoDrawingType == MsoDrawingType.GroupBox)
				{
					return true;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return false;
	}

	internal void method_39()
	{
		byte[] array = null;
		for (int i = 0; i < Count; i++)
		{
			Shape shape = this[i];
			if (shape.string_0 != null && shape.string_0 != "" && shape.method_28() != null)
			{
				shape.method_28().method_0(worksheetCollection_0, worksheet_0, shape.string_0);
			}
			switch (shape.MsoDrawingType)
			{
			case MsoDrawingType.ListBox:
			{
				array = shape.method_58();
				if (array != null)
				{
					shape.method_59(Class1248.smethod_1(array, 0));
				}
				ListBox listBox = (ListBox)shape;
				array = listBox.method_69();
				if (array != null)
				{
					listBox.method_70(Class1248.smethod_1(array, 0));
				}
				break;
			}
			default:
				array = shape.method_58();
				if (array != null)
				{
					shape.method_59(Class1248.smethod_1(array, 0));
				}
				break;
			case MsoDrawingType.ComboBox:
			{
				array = shape.method_58();
				if (array != null)
				{
					shape.method_59(Class1248.smethod_1(array, 0));
				}
				ComboBox comboBox = (ComboBox)shape;
				array = comboBox.method_70();
				if (array != null)
				{
					comboBox.method_71(Class1248.smethod_1(array, 0));
				}
				break;
			}
			case MsoDrawingType.Chart:
			{
				Chart chart = ((ChartShape)shape).method_69();
				chart.method_54();
				break;
			}
			}
		}
	}

	internal void method_40()
	{
		byte[] array = null;
		for (int i = 0; i < Count; i++)
		{
			Shape shape = this[i];
			shape.method_8();
			switch (shape.MsoDrawingType)
			{
			case MsoDrawingType.ListBox:
			{
				array = shape.method_58();
				if (array != null)
				{
					shape.method_59(Class1247.smethod_1(array, 0, 0, 0, bool_0: false));
				}
				ListBox listBox = (ListBox)shape;
				array = listBox.method_69();
				if (array != null)
				{
					listBox.method_70(Class1247.smethod_1(array, 0, 0, 0, bool_0: false));
				}
				break;
			}
			default:
				array = shape.method_58();
				if (array != null)
				{
					shape.method_59(Class1247.smethod_1(array, 0, 0, 0, bool_0: false));
				}
				break;
			case MsoDrawingType.ComboBox:
			{
				array = shape.method_58();
				if (array != null)
				{
					shape.method_59(Class1247.smethod_1(array, 0, 0, 0, bool_0: false));
				}
				ComboBox comboBox = (ComboBox)shape;
				array = comboBox.method_70();
				if (array != null)
				{
					comboBox.method_71(Class1247.smethod_1(array, 0, 0, 0, bool_0: false));
				}
				break;
			}
			case MsoDrawingType.Chart:
			{
				Chart chart = ((ChartShape)shape).method_69();
				chart.method_53();
				break;
			}
			}
		}
	}

	internal Shape method_41(MsoDrawingType msoDrawingType_0)
	{
		Shape shape;
		switch (msoDrawingType_0)
		{
		case MsoDrawingType.Group:
			shape = new GroupShape(this);
			Add(shape);
			break;
		case MsoDrawingType.Line:
			shape = new LineShape(this);
			Add(shape);
			break;
		case MsoDrawingType.Rectangle:
			shape = new RectangleShape(this);
			Add(shape);
			break;
		case MsoDrawingType.Oval:
			shape = new Oval(this);
			Add(shape);
			break;
		case MsoDrawingType.Arc:
			shape = new ArcShape(this);
			Add(shape);
			break;
		case MsoDrawingType.TextBox:
			shape = new TextBox(this);
			Add(shape);
			method_37().TextBoxes.Add((TextBox)shape);
			break;
		case MsoDrawingType.Button:
			shape = new Button(this);
			Add(shape);
			break;
		case MsoDrawingType.CheckBox:
			shape = new CheckBox(this);
			Add(shape);
			method_37().CheckBoxes.Add((CheckBox)shape);
			break;
		case MsoDrawingType.RadioButton:
			shape = new RadioButton(this);
			Add(shape);
			break;
		case MsoDrawingType.Label:
			shape = new Label(this);
			Add(shape);
			break;
		case MsoDrawingType.Spinner:
			shape = new Spinner(this);
			Add(shape);
			break;
		case MsoDrawingType.ScrollBar:
			shape = new ScrollBar(this);
			Add(shape);
			break;
		case MsoDrawingType.ListBox:
			shape = new ListBox(this);
			Add(shape);
			break;
		case MsoDrawingType.GroupBox:
			shape = new GroupBox(this);
			Add(shape);
			break;
		case MsoDrawingType.ComboBox:
			shape = new ComboBox(this);
			Add(shape);
			break;
		default:
			shape = new Shape(this, msoDrawingType_0, null);
			Add(shape);
			break;
		case MsoDrawingType.CellsDrawing:
			shape = new CellsDrawing(this);
			Add(shape);
			break;
		}
		return shape;
	}
}
