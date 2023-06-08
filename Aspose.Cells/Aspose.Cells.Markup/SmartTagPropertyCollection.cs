using System.Collections;

namespace Aspose.Cells.Markup;

/// <summary>
///       Represents all properties of cell smart tag.
///       </summary>
public class SmartTagPropertyCollection : CollectionBase
{
	/// <summary>
	///       Gets a <see cref="T:Aspose.Cells.Markup.SmartTagProperty" /> object.
	///       </summary>
	/// <param name="index">The index</param>
	/// <returns>Returns a <see cref="T:Aspose.Cells.Markup.SmartTagProperty" /> object.</returns>
	public SmartTagProperty this[int index] => (SmartTagProperty)base.InnerList[index];

	/// <summary>
	///       Gets a <see cref="T:Aspose.Cells.Markup.SmartTagProperty" /> object by the name of the property.
	///       </summary>
	/// <param name="name">The name of the proerty.</param>
	/// <returns>Returns a <see cref="T:Aspose.Cells.Markup.SmartTagProperty" /> object.</returns>
	public SmartTagProperty this[string name]
	{
		get
		{
			int num = 0;
			SmartTagProperty smartTagProperty;
			while (true)
			{
				if (num < base.Count)
				{
					smartTagProperty = (SmartTagProperty)base.InnerList[num];
					if (string.Compare(smartTagProperty.Name, name, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return smartTagProperty;
		}
	}

	/// <summary>
	///       Adds a property of cell's smart tag.
	///       </summary>
	/// <param name="name">The name of the propery</param>
	/// <param name="value">The value of the property.</param>
	/// <returns>return <see cref="T:Aspose.Cells.Markup.SmartTagProperty" /></returns>
	public int Add(string name, string value)
	{
		int num = 0;
		SmartTagProperty smartTagProperty;
		while (true)
		{
			if (num < base.Count)
			{
				smartTagProperty = (SmartTagProperty)base.InnerList[num];
				if (string.Compare(smartTagProperty.Name, name, ignoreCase: true) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			SmartTagProperty value2 = new SmartTagProperty(name, value);
			base.InnerList.Add(value2);
			return base.Count - 1;
		}
		smartTagProperty.Value = value;
		return num;
	}
}
