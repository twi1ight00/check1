namespace Aspose.Cells.Markup;

/// <summary>
///       Represents the property of the cell smart tag.
///       </summary>
public class SmartTagProperty
{
	private string string_0;

	private string string_1;

	/// <summary>
	///       Gets and sets the name of the property.
	///       </summary>
	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets the value of the property.
	///       </summary>
	public string Value
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	internal SmartTagProperty(string string_2, string string_3)
	{
		string_0 = string_2;
		string_1 = string_3;
	}
}
