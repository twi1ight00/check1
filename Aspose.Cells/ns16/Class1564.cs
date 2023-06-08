namespace ns16;

internal class Class1564
{
	internal string string_0;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal Class1564()
	{
		string_1 = null;
		string_2 = null;
		string_3 = null;
		string_4 = null;
	}

	internal Class1564(string string_5, string string_6, string string_7, string string_8)
	{
		string_1 = string_5;
		string_2 = string_6;
		if (string_8 != null && string_8.Equals("External") && string_7 != null && string_7.Length > 3 && string_7[1] == ':' && (string_7[2] == '/' || string_7[2] == '\\') && ((string_7[0] >= 'a' && string_7[0] <= 'z') || (string_7[0] >= 'A' && string_7[0] <= 'Z')))
		{
			string_7 = "file:///" + string_7;
		}
		string_3 = string_7;
		string_4 = string_8;
	}
}
