using System.Collections;

namespace Aspose.Cells.Properties;

public class ContentTypePropertyCollection : CollectionBase
{
	internal ArrayList arrayList_0;

	public ContentTypeProperty this[int index] => (ContentTypeProperty)base.InnerList[index];

	public ContentTypeProperty this[string name]
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

	internal ContentTypePropertyCollection()
	{
		arrayList_0 = new ArrayList();
	}

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
			ContentTypeProperty contentTypeProperty = new ContentTypeProperty(this);
			contentTypeProperty.Name = name;
			contentTypeProperty.Value = value;
			base.InnerList.Add(contentTypeProperty);
			return base.InnerList.Count - 1;
		}
		this[num].Value = value;
		return num;
	}

	internal int Add(ContentTypeProperty contentTypeProperty_0)
	{
		base.InnerList.Add(contentTypeProperty_0);
		return base.InnerList.Count - 1;
	}
}
