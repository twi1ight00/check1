using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential)]
internal class OraGlobStruct
{
	internal string m_calendar;

	internal string m_clientCharacterSet;

	internal string m_comparison;

	internal string m_currency;

	internal string m_dateFormat;

	internal string m_dateLanguage;

	internal string m_dualCurrency;

	internal string m_isoCurrency;

	internal string m_language;

	internal string m_lengthSemantics;

	internal string m_nCharConvExcp;

	internal string m_numericCharacters;

	internal string m_sort;

	internal string m_territory;

	internal string m_timeStampFormat;

	internal string m_timeStampTZFormat;

	internal string m_timeZone;
}
