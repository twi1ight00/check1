using System;
using System.Collections;
using ns30;
using ns57;

namespace Aspose.Cells.Properties;

/// <summary>
///        A collection of custom document properties. 
///        </summary>
/// <remarks>
///   <p>Each <see cref="T:Aspose.Cells.Properties.DocumentProperty" /> object represents a custom property of a container document.</p>
/// </remarks>
/// <example>
///   <code>
///
///        [C#]
///
///        //Instantiate a Workbook object
///        Workbook workbook = new Workbook("C:\\book1.xls");
///
///        //Retrieve a list of all custom document properties of the Excel file
///        CustomDocumentPropertyCollection customProperties = workbook.Worksheets.CustomDocumentProperties;
///
///        [VB.NET]
///
///        'Instantiate a Workbook object
///        Dim workbook As New Workbook("C:\book1.xls")
///
///        'Retrieve a list of all custom document properties of the Excel file
///        Dim customProperties As CustomDocumentPropertyCollection = workbook.Worksheets.CustomDocumentProperties
///
///        </code>
/// </example>
public class CustomDocumentPropertyCollection : DocumentPropertyCollection
{
	private WorksheetCollection worksheetCollection_0;

	internal CustomDocumentPropertyCollection(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	internal DocumentProperty Add(string string_0, object object_0)
	{
		Class1321.smethod_7(string_0, "name");
		return Add(Enum218.const_2, method_0(), string_0, object_0, bool_0: false);
	}

	/// <overloads>Creates a new custom document property.</overloads>
	/// <summary>
	///       Creates a new custom document property of the <b>PropertyType.String</b> data type.
	///       </summary>
	/// <param name="name">The name of the property.</param>
	/// <param name="value">The value of the property.</param>
	/// <returns>The newly created property object.</returns>
	public DocumentProperty Add(string name, string value)
	{
		Class1321.smethod_7(name, "name");
		return Add(Enum218.const_2, method_0(), name, value, bool_0: false);
	}

	/// <summary>
	///       Creates a new custom document property of the <b>PropertyType.Number</b> data type.
	///       </summary>
	/// <param name="name">The name of the property.</param>
	/// <param name="value">The value of the property.</param>
	/// <returns>The newly created property object.</returns>
	public DocumentProperty Add(string name, int value)
	{
		Class1321.smethod_7(name, "name");
		return Add(Enum218.const_2, method_0(), name, value, bool_0: false);
	}

	/// <summary>
	///       Creates a new custom document property of the <b>PropertyType.DateTime</b> data type.
	///       </summary>
	/// <param name="name">The name of the property.</param>
	/// <param name="value">The value of the property.</param>
	/// <returns>The newly created property object.</returns>
	public DocumentProperty Add(string name, DateTime value)
	{
		Class1321.smethod_7(name, "name");
		return Add(Enum218.const_2, method_0(), name, value, bool_0: false);
	}

	/// <summary>
	///       Creates a new custom document property of the <b>PropertyType.Boolean</b> data type.
	///       </summary>
	/// <param name="name">The name of the property.</param>
	/// <param name="value">The value of the property.</param>
	/// <returns>The newly created property object.</returns>
	public DocumentProperty Add(string name, bool value)
	{
		Class1321.smethod_7(name, "name");
		return Add(Enum218.const_2, method_0(), name, value, bool_0: false);
	}

	/// <summary>
	///       Creates a new custom document property of the <b>PropertyType.Float</b> data type.
	///       </summary>
	/// <param name="name">The name of the property.</param>
	/// <param name="value">The value of the property.</param>
	/// <returns>The newly created property object.</returns>
	public DocumentProperty Add(string name, double value)
	{
		Class1321.smethod_7(name, "name");
		return Add(Enum218.const_2, method_0(), name, value, bool_0: false);
	}

	/// <summary>
	///        Creates a new custom document property which links to content.
	///       </summary>
	/// <param name="name">The name of the property.</param>
	/// <param name="source">The source of the property</param>
	/// <returns>The newly created property object.</returns>
	public DocumentProperty AddLinkToContent(string name, string source)
	{
		Class1321.smethod_7(name, "name");
		Name name2 = worksheetCollection_0.Names[source];
		string object_ = "";
		if (name2 != null && name2.method_32())
		{
			Range range = name2.CreateRange();
			if (range != null)
			{
				Cell cell = range.Worksheet.Cells.CheckCell(range.FirstRow, range.FirstColumn);
				if (cell != null)
				{
					object_ = cell.StringValue;
				}
			}
		}
		DocumentProperty documentProperty = Add(Enum218.const_2, method_0(), name, object_, bool_0: false);
		int num = documentProperty.method_0() | 0x1000000;
		name = "?_generated_" + documentProperty.method_0() + "." + num;
		Add(Enum218.const_2, num, name, source, bool_0: true);
		return documentProperty;
	}

	/// <summary>
	///       Update custom document property value which links to content.
	///       </summary>
	public void UpdateLinkedPropertyValue()
	{
		if (this == null || base.Count <= 0)
		{
			return;
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DocumentProperty documentProperty = (DocumentProperty)enumerator.Current;
				if (!documentProperty.IsLink && documentProperty.IsLinkedToContent)
				{
					documentProperty.Value = worksheetCollection_0.GetRangeByName(documentProperty.Source).Value;
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

	public void UpdateLinkedRange()
	{
		if (this == null || base.Count <= 0)
		{
			return;
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DocumentProperty documentProperty = (DocumentProperty)enumerator.Current;
				if (!documentProperty.IsLink && documentProperty.IsLinkedToContent)
				{
					Range rangeByName = worksheetCollection_0.GetRangeByName(documentProperty.Source);
					if (rangeByName != null)
					{
						rangeByName.Value = documentProperty.Value;
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

	private int method_0()
	{
		int num = 1;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DocumentProperty documentProperty = (DocumentProperty)enumerator.Current;
				num = Math.Max(num, documentProperty.method_1());
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
		return num + 1;
	}
}
