using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x623dea19444a5371
{
	private string x466efe2449ba68a6 = string.Empty;

	internal string xe5d13ccbc3df998a
	{
		get
		{
			return x466efe2449ba68a6;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x466efe2449ba68a6 = value;
		}
	}

	internal x623dea19444a5371()
	{
	}

	internal x623dea19444a5371(string progId)
	{
		xe5d13ccbc3df998a = progId;
	}

	internal static string xda09af88ab899a50(string x1fd8f5e5bbfdb602)
	{
		x623dea19444a5371 x623dea19444a5372 = new x623dea19444a5371(x1fd8f5e5bbfdb602);
		return x623dea19444a5372.ToString();
	}

	internal static x623dea19444a5371 x1f490eac106aee12(string x0e59413709b18038)
	{
		x623dea19444a5371 x623dea19444a5372 = new x623dea19444a5371();
		x985dd08fd338eeea x985dd08fd338eeea2 = new x985dd08fd338eeea(x0e59413709b18038);
		x623dea19444a5372.xe5d13ccbc3df998a = x985dd08fd338eeea2.x642e37025c67edab(0, x9fc40ce4428c62cc: true, xbd96676852fc71de: true);
		return x623dea19444a5372;
	}

	public override string ToString()
	{
		return $" EMBED {xe5d13ccbc3df998a} ";
	}
}
