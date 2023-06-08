namespace LumiSoft.Net;

internal class _Parameter
{
	private string m_ParamName = "";

	private string m_ParamValue = "";

	public string ParamName => m_ParamName;

	public string ParamValue => m_ParamValue;

	public _Parameter(string paramName, string paramValue)
	{
		m_ParamName = paramName;
		m_ParamValue = paramValue;
	}
}
