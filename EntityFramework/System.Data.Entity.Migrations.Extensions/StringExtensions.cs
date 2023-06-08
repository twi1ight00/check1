using System.Data.Entity.Resources;
using System.Text.RegularExpressions;

namespace System.Data.Entity.Migrations.Extensions;

internal static class StringExtensions
{
	private static readonly Regex _migrationIdPattern = new Regex("\\d{15}_.+");

	public static bool EqualsIgnoreCase(this string s1, string s2)
	{
		return string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);
	}

	public static string MigrationName(this string migrationId)
	{
		return migrationId.Substring(16);
	}

	public static string RestrictTo(this string s, int size)
	{
		if (string.IsNullOrEmpty(s) || s.Length <= size)
		{
			return s;
		}
		return s.Substring(0, size);
	}

	public static bool IsValidMigrationId(this string migrationId)
	{
		if (!_migrationIdPattern.IsMatch(migrationId))
		{
			return migrationId == "0";
		}
		return true;
	}

	public static bool IsAutomaticMigration(this string migrationId)
	{
		return migrationId.EndsWith(Strings.AutomaticMigration);
	}

	public static bool ComesBefore(this string migrationId1, string migrationId2)
	{
		string strA = migrationId1.Substring(0, 15);
		string strB = migrationId2.Substring(0, 15);
		int num = string.CompareOrdinal(strA, strB);
		if (num > 0)
		{
			return false;
		}
		if (num == 0)
		{
			if (migrationId1 == migrationId2 + "_" + Strings.AutomaticMigration)
			{
				return true;
			}
			return false;
		}
		return true;
	}
}
