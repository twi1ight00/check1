namespace ns28;

internal class Class477
{
	private string string_0;

	private string string_1;

	internal Class463 class463_0;

	internal Class465 class465_0;

	internal Class462 class462_0;

	internal string Name
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

	internal string Href => string_1;

	internal Class477()
	{
	}

	internal Class477(string objectName, string path)
	{
		string_0 = objectName;
		string_1 = path;
	}
}
