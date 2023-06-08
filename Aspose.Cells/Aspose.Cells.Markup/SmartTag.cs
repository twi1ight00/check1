using System.Runtime.CompilerServices;
using ns56;

namespace Aspose.Cells.Markup;

/// <summary>
///       Represents a smart tag.
///       </summary>
public class SmartTag
{
	private SmartTagCollection smartTagCollection_0;

	private bool bool_0;

	private bool bool_1;

	private Class1282 class1282_0;

	private SmartTagPropertyCollection smartTagPropertyCollection_0;

	/// <summary>
	///       Indicates whether the smart tag is deleted.
	///       </summary>
	public bool Deleted
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	/// <summary>
	///       Gets and set the properties of the smar tag.
	///       </summary>
	public SmartTagPropertyCollection Properties
	{
		get
		{
			return smartTagPropertyCollection_0;
		}
		set
		{
			smartTagPropertyCollection_0 = value;
		}
	}

	/// <summary>
	///       Gets the namespace URI of the smart tag.
	///       </summary>
	public string Uri => class1282_0.Uri;

	/// <summary>
	///       Gets the name of the smart tag. 
	///       </summary>
	public string Name => class1282_0.Name;

	internal SmartTag(SmartTagCollection smartTagCollection_1)
	{
		smartTagCollection_0 = smartTagCollection_1;
		smartTagPropertyCollection_0 = new SmartTagPropertyCollection();
	}

	[SpecialName]
	internal bool method_0()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_1(bool bool_2)
	{
		bool_1 = bool_2;
	}

	[SpecialName]
	internal Class1282 method_2()
	{
		return class1282_0;
	}

	[SpecialName]
	internal void method_3(Class1282 class1282_1)
	{
		class1282_0 = class1282_1;
	}

	/// <summary>
	///       Change the name and  the namespace URI of the smart tag.
	///       </summary>
	/// <param name="uri">The namespace URI of the smart tag.</param>
	/// <param name="name">The name of the smart tag.</param>
	public void SetLink(string uri, string name)
	{
		WorksheetCollection worksheetCollection = smartTagCollection_0.method_0().method_0().method_2();
		int int_ = worksheetCollection.method_92().Add(uri, name);
		class1282_0 = worksheetCollection.method_92()[int_];
	}
}
