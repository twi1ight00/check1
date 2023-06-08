using System.Collections;

namespace Aspose.Cells.Properties;

/// <summary>
///       A collection of <see cref="T:Aspose.Cells.Properties.CustomProperty" /> objects that represent additional information. 
///       </summary>
public class CustomPropertyCollection : CollectionBase
{
	/// <summary>
	///       Gets the custom property by the specific index.
	///       </summary>
	/// <param name="index">The index.</param>
	/// <returns>The custom property</returns>
	public CustomProperty this[int index] => (CustomProperty)base.InnerList[index];

	/// <summary>
	///       Gets the custom property by the property name.
	///       </summary>
	/// <param name="name">The property name.</param>
	/// <returns>The custom property</returns>
	public CustomProperty this[string name]
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					if (this[num].Name == name)
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

	internal CustomPropertyCollection()
	{
	}

	/// <summary>
	///       Adds custom property information.
	///       </summary>
	/// <param name="name">The name of the custom property.</param>
	/// <param name="value">The value of the custom property.</param>
	public int Add(string name, string value)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				if (this[num].Name == name)
				{
					break;
				}
				num++;
				continue;
			}
			CustomProperty customProperty = new CustomProperty();
			customProperty.Name = name;
			customProperty.Value = value;
			base.InnerList.Add(customProperty);
			return base.InnerList.Count - 1;
		}
		this[num].Value = value;
		return num;
	}
}
