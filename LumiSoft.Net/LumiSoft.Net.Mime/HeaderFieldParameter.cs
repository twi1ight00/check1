namespace LumiSoft.Net.Mime;

public class HeaderFieldParameter
{
	private string m_Name = "";

	private string m_Value = "";

	public string Name => m_Name;

	public string Value => m_Value;

	public HeaderFieldParameter(string parameterName, string parameterValue)
	{
		m_Name = parameterName;
		m_Value = parameterValue;
	}
}
