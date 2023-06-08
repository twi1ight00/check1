using System.Collections;
using System.Runtime.CompilerServices;
using ns56;

namespace Aspose.Cells.Markup;

/// <summary>
///       Represents all smart tags in the cell.
///       </summary>
public class SmartTagCollection : CollectionBase
{
	private SmartTagSetting smartTagSetting_0;

	private int int_0;

	private int int_1;

	/// <summary>
	///       Gets the row of the cell smart tags.
	///       </summary>
	public int Row => int_0;

	/// <summary>
	///       Gets the column of the cell smart tags.
	///       </summary>
	public int Column => int_1;

	/// <summary>
	///       Gets a <see cref="T:Aspose.Cells.Markup.SmartTag" /> object at the specific index
	///       </summary>
	/// <param name="index">The index.</param>
	/// <returns>returns a <see cref="T:Aspose.Cells.Markup.SmartTag" /> object. </returns>
	public SmartTag this[int index] => (SmartTag)base.InnerList[index];

	[SpecialName]
	internal SmartTagSetting method_0()
	{
		return smartTagSetting_0;
	}

	internal SmartTagCollection(SmartTagSetting smartTagSetting_1, int int_2, int int_3)
	{
		smartTagSetting_0 = smartTagSetting_1;
		int_0 = int_2;
		int_1 = int_3;
	}

	/// <summary>
	///       Adds a smart tag.
	///       </summary>
	/// <param name="uri">Specifies the namespace URI of the smart tag</param>
	/// <param name="name">Specifies the name of the smart tag. </param>
	/// <returns>The index of smart tag in the list.</returns>
	public int Add(string uri, string name)
	{
		int num = smartTagSetting_0.method_0().method_2().method_92()
			.Add(uri, name);
		Class1282 class1282_ = smartTagSetting_0.method_0().method_2().method_92()[num];
		SmartTag smartTag = new SmartTag(this);
		smartTag.method_3(class1282_);
		base.InnerList.Add(smartTag);
		return base.Count - 1;
	}

	internal int Add(SmartTag smartTag_0)
	{
		base.InnerList.Add(smartTag_0);
		return base.Count - 1;
	}
}
