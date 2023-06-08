using System.Collections;

namespace Aspose.Cells.Properties;

public class ContentTypeProperty
{
	internal ContentTypePropertyCollection contentTypePropertyCollection_0;

	internal string string_0;

	internal int int_0 = -1;

	internal string string_1;

	internal ArrayList arrayList_0;

	internal string string_2;

	private string string_3;

	private object object_0;

	public string Name
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string Value
	{
		get
		{
			if (object_0 != null)
			{
				return object_0.ToString();
			}
			return "";
		}
		set
		{
			object_0 = value;
		}
	}

	internal int Index
	{
		get
		{
			ArrayList arrayList = contentTypePropertyCollection_0.arrayList_0;
			int num = 0;
			while (true)
			{
				if (num < arrayList.Count)
				{
					string text = (string)arrayList[num];
					if (string_0 == text)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}
	}

	internal ContentTypeProperty(ContentTypePropertyCollection contentTypePropertyCollection_1)
	{
		contentTypePropertyCollection_0 = contentTypePropertyCollection_1;
		arrayList_0 = new ArrayList();
		string_0 = "f0ee3e2c-6582-4549-9afa-575e8dac0aa5";
	}
}
