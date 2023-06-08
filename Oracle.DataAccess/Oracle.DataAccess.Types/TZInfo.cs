namespace Oracle.DataAccess.Types;

internal struct TZInfo
{
	internal int m_tzHours;

	internal int m_tzMinutes;

	internal TZInfo(int tzHours, int tzMinutes)
	{
		m_tzHours = tzHours;
		m_tzMinutes = tzMinutes;
	}
}
