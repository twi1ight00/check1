namespace ns28;

internal class Class466
{
	protected string string_0;

	protected string string_1;

	protected string string_2;

	protected string string_3;

	protected string string_4;

	protected string string_5;

	protected string string_6;

	protected string string_7;

	protected string string_8;

	protected string string_9 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";

	protected string string_10 = "urn:oasis:names:tc:opendocument:xmlns:table:1.0";

	protected string string_11 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";

	protected string string_12 = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";

	protected string string_13 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

	protected Class437 class437_0;

	protected Class437 class437_1;

	protected Class437 class437_2;

	protected Class487 class487_0;

	protected int int_0;

	public string CaptionID
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

	public string DrawClassNames
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

	public string DrawId
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string Layer
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

	public string Name
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string DrawStyleNameString
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public string TextStyleNameString
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public Class487 Transform
	{
		get
		{
			return class487_0;
		}
		set
		{
			class487_0 = value;
		}
	}

	public int ZIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			ZIndex = value;
		}
	}

	public string PresentationClassNames
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public string StyleNameString
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public Class437 PresStyleName
	{
		get
		{
			return class437_0;
		}
		set
		{
			class437_0 = value;
			string_7 = value.Name;
		}
	}

	public Class437 DrawStyleName
	{
		get
		{
			return class437_1;
		}
		set
		{
			class437_1 = value;
			string_5 = value.Name;
		}
	}

	public Class437 TextStyleName
	{
		get
		{
			return class437_2;
		}
		set
		{
			class437_2 = value;
			string_6 = value.Name;
		}
	}

	public Class466()
	{
	}

	public Class466(Class369 source)
	{
		if (source != null)
		{
			method_0(source);
		}
	}

	internal void method_0(Class369 source)
	{
		if (source == null)
		{
			return;
		}
		string_0 = source.GetAttribute("caption-id", string_9);
		string_1 = source.GetAttribute("class-names", string_9);
		string_2 = source.GetAttribute("id", string_9);
		string_3 = source.GetAttribute("layer", string_9);
		string_4 = source.GetAttribute("name", string_9);
		string_5 = source.GetAttribute("style-name", string_9);
		string_6 = source.GetAttribute("text-style-name", string_9);
		class487_0 = new Class487(source, "transform", string_9);
		int_0 = source.method_13("z-index", string_9, 0);
		string_8 = source.GetAttribute("class-names", string_11);
		string_7 = source.GetAttribute("style-name", string_11);
		if (string_7 != "")
		{
			foreach (Class437 item in source.OwnerDocument.GetElementsByTagName("style", string_13))
			{
				if (item.Name == string_7)
				{
					class437_0 = item;
					break;
				}
			}
		}
		if (string_5 != "")
		{
			foreach (Class437 item2 in source.OwnerDocument.GetElementsByTagName("style", string_13))
			{
				if (item2.Name == string_5)
				{
					class437_1 = item2;
					break;
				}
			}
		}
		if (!(string_6 != ""))
		{
			return;
		}
		foreach (Class437 item3 in source.OwnerDocument.GetElementsByTagName("style", string_13))
		{
			if (item3.Name == string_6)
			{
				class437_2 = item3;
				break;
			}
		}
	}

	internal void Write(Class369 target)
	{
		if (string_5 != null && string_5 != "")
		{
			target.SetAttribute("style-name", string_9, string_5);
		}
		if (string_6 != null && string_6 != "")
		{
			target.SetAttribute("text-style-name", string_9, string_6);
		}
		if (string_7 != null && string_7 != "")
		{
			target.SetAttribute("style-name", string_11, string_7);
		}
	}
}
