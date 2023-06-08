using System;
using System.ComponentModel;

namespace Aspose.Cells.Properties;

/// <summary>
///       Represents identifier information.
///       </summary>
public class CustomProperty
{
	private string string_0;

	private object object_0;

	/// <summary>
	///       Returns or sets the name of the object.
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
	///       Returns or sets the value of the custom property.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use CustomProperty.Value property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use CustomProperty.Value property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public string StringValue
	{
		get
		{
			return object_0.ToString();
		}
		set
		{
			object_0 = value;
		}
	}

	/// <summary>
	///       Returns or sets the value of the custom property.
	///       </summary>
	public string Value
	{
		get
		{
			return object_0.ToString();
		}
		set
		{
			object_0 = value;
		}
	}
}
