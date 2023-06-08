using ns305;

namespace ns284;

internal class Class7050 : Class7049
{
	private const string string_4 = "HTML";

	private const string string_5 = "-//W3C//DTD HTML 4.01//EN";

	private bool bool_0;

	public bool IsHTMLStrict => bool_0;

	public Class7050(string name, string publicId, string systemId, string internalSubset, Class7046 doc)
		: base(name, publicId, systemId, internalSubset, doc)
	{
		string text;
		if (!string.IsNullOrEmpty(name) && name.ToUpper().Equals("HTML") && !string.IsNullOrEmpty(publicId) && (text = publicId.ToUpper()) != null && text == "-//W3C//DTD HTML 4.01//EN")
		{
			bool_0 = true;
		}
	}
}
