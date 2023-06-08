using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using ns30;

namespace Aspose.Cells.Properties;

/// <summary>
///        Represents a custom or built-in document property.
///        </summary>
/// <example>
///   <code>
///
///        [C#]
///
///        //Instantiate a Workbook object
///        Workbook workbook = new Workbook("C:\\book1.xls");
///
///        //Retrieve a list of all custom document properties of the Excel file
///        DocumentProperties customProperties = workbook.Worksheets.CustomDocumentProperties;
///
///        //Accessng a custom document property by using the property index
///        DocumentProperty customProperty1 = customProperties[3];
///
///        //Accessng a custom document property by using the property name
///        DocumentProperty customProperty2 = customProperties["Owner"];
///
///        [VB.NET]
///
///        'Instantiate a Workbook object
///        Dim workbook As Workbook = New Workbook("C:\\book1.xls")
///
///        'Retrieve a list of all custom document properties of the Excel file
///        Dim customProperties As DocumentProperties = workbook.Worksheets.CustomDocumentProperties
///
///        'Accessng a custom document property by using the property index
///        Dim customProperty1 As DocumentProperty = customProperties(3)
///
///        'Accessng a custom document property by using the property name
///        Dim customProperty2 As DocumentProperty = customProperties("Owner")
///        </code>
/// </example>
public class DocumentProperty
{
	private DocumentPropertyCollection documentPropertyCollection_0;

	private Enum218 enum218_0;

	private int int_0;

	private string string_0;

	private object object_0;

	private bool bool_0;

	/// <summary>
	///       Returns the name of the property.
	///       </summary>
	public string Name => string_0;

	/// <summary>
	///       Gets or sets the value of the property.
	///       </summary>
	public object Value
	{
		get
		{
			return object_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			object_0 = value;
		}
	}

	/// <summary>
	///       Indicates whether this property is linked to content
	///       </summary>
	public bool IsLinkedToContent => Source != null;

	/// <summary>
	///       The linked content source.
	///       </summary>
	public string Source
	{
		get
		{
			int num = 0;
			DocumentProperty documentProperty;
			while (true)
			{
				if (num < documentPropertyCollection_0.Count)
				{
					documentProperty = documentPropertyCollection_0[num];
					if (documentProperty.IsLink && documentProperty.method_1() == method_0())
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return (string)documentProperty.Value;
		}
	}

	/// <summary>
	///       Gets the data type of the property.
	///       </summary>
	public PropertyType Type
	{
		get
		{
			if (object_0 is string)
			{
				return PropertyType.String;
			}
			if (object_0 is bool)
			{
				return PropertyType.Boolean;
			}
			if (object_0 is DateTime)
			{
				return PropertyType.DateTime;
			}
			if (!(object_0 is int) && !(object_0 is uint))
			{
				if (object_0 is double)
				{
					return PropertyType.Double;
				}
				if (object_0 is byte[])
				{
					return PropertyType.Blob;
				}
				throw new Exception("Unknown type of property value.");
			}
			return PropertyType.Number;
		}
	}

	/// <summary>
	///       Returns true if this property does not have a name in the OLE2 storage
	///       and a unique name was generated only for the public API.
	///       </summary>
	public bool IsGeneratedName => bool_0;

	internal bool IsLink => (int_0 & 0x1000000) != 0;

	internal Enum218 Group => enum218_0;

	internal DocumentProperty(DocumentPropertyCollection documentPropertyCollection_1, Enum218 enum218_1, int int_1, string string_1, object object_1, bool bool_1)
	{
		documentPropertyCollection_0 = documentPropertyCollection_1;
		enum218_0 = enum218_1;
		int_0 = int_1;
		string_0 = string_1;
		object_0 = object_1;
		bool_0 = bool_1;
	}

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	internal int method_1()
	{
		return int_0 & -16777217;
	}

	/// <summary>
	///       Returns the property value as a string.
	///       </summary>
	/// <remarks>
	///   <p>Converts a number property using Object.ToString(). Converts a boolean property
	///       into "Y" or "N". Converts a date property into a short date string.</p>
	/// </remarks>
	public override string ToString()
	{
		switch (Type)
		{
		default:
			throw new Exception("Unknown type of property value.");
		case PropertyType.Boolean:
			if (!(bool)object_0)
			{
				return "N";
			}
			return "Y";
		case PropertyType.DateTime:
			return ((DateTime)object_0).ToShortDateString();
		case PropertyType.Double:
			return ((double)object_0).ToString(CultureInfo.InvariantCulture);
		case PropertyType.Number:
			return object_0.ToString();
		case PropertyType.String:
			return (string)object_0;
		case PropertyType.Blob:
			return object_0.ToString();
		}
	}

	/// <summary>
	///       Returns the property value as integer.
	///       </summary>
	/// <remarks>
	///       Throws an exception if the property type is not PropertyType.Number.
	///       </remarks>
	public int ToInt()
	{
		if (Value is uint)
		{
			return (int)(uint)Value;
		}
		return (int)Value;
	}

	internal long method_2()
	{
		if (Value is uint)
		{
			return (uint)Value;
		}
		return (int)Value;
	}

	/// <summary>
	///       Returns the property value as double.
	///       </summary>
	/// <remarks>
	///       Throws an exception if the property type is not PropertyType.Float.
	///       </remarks>
	public double ToDouble()
	{
		return (double)Value;
	}

	/// <summary>
	///       Returns the property value as DateTime in local timezone.
	///       </summary>
	/// <remarks>
	///   <p>Throws an exception if the property type is not PropertyType.Date.</p>
	/// </remarks>
	public DateTime ToDateTime()
	{
		return (DateTime)Value;
	}

	/// <summary>
	///       Returns the property value as bool.
	///       </summary>
	/// <remarks>
	///   <p>Throws an exception if the property type is not PropertyType.Boolean.</p>
	/// </remarks>
	public bool ToBool()
	{
		return (bool)Value;
	}
}
