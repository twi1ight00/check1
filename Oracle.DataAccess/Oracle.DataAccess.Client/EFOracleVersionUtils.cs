using System;

namespace Oracle.DataAccess.Client;

internal static class EFOracleVersionUtils
{
	internal static EFOracleVersion GetStorageVersion(OracleConnection connection)
	{
		string serverVersion = connection.ServerVersion;
		if (serverVersion.StartsWith("9.2"))
		{
			return EFOracleVersion.Oracle9iR2;
		}
		if (serverVersion.StartsWith("10.1"))
		{
			return EFOracleVersion.Oracle10gR1;
		}
		if (serverVersion.StartsWith("10.2"))
		{
			return EFOracleVersion.Oracle10gR2;
		}
		if (serverVersion.StartsWith("11.1"))
		{
			return EFOracleVersion.Oracle11gR1;
		}
		if (serverVersion.StartsWith("11.2"))
		{
			return EFOracleVersion.Oracle11gR2;
		}
		if (serverVersion.StartsWith("12.1"))
		{
			return EFOracleVersion.Oracle12gR1;
		}
		if (serverVersion.StartsWith("12.2"))
		{
			return EFOracleVersion.Oracle12gR2;
		}
		throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_NOT_SUPPORTED, "Oracle Data Provider for .NET", "Oracle " + serverVersion));
	}

	internal static string GetVersionHint(EFOracleVersion version)
	{
		return version switch
		{
			EFOracleVersion.Oracle9iR2 => "9.2", 
			EFOracleVersion.Oracle10gR1 => "10.1", 
			EFOracleVersion.Oracle10gR2 => "10.2", 
			EFOracleVersion.Oracle11gR1 => "11.1", 
			EFOracleVersion.Oracle11gR2 => "11.2", 
			EFOracleVersion.Oracle12gR1 => "12.1", 
			EFOracleVersion.Oracle12gR2 => "12.2", 
			_ => throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "ProviderManifestToken")), 
		};
	}

	internal static EFOracleVersion GetStorageVersion(string versionHint)
	{
		if (!string.IsNullOrEmpty(versionHint))
		{
			switch (versionHint)
			{
			case "9.2":
				return EFOracleVersion.Oracle9iR2;
			case "10.1":
				return EFOracleVersion.Oracle10gR1;
			case "10.2":
				return EFOracleVersion.Oracle10gR2;
			case "11.1":
				return EFOracleVersion.Oracle11gR1;
			case "11.2":
				return EFOracleVersion.Oracle11gR2;
			case "12.1":
				return EFOracleVersion.Oracle12gR1;
			case "12.2":
				return EFOracleVersion.Oracle12gR2;
			}
		}
		throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "ProviderManifestToken"));
	}

	internal static bool IsVersionX(EFOracleVersion storageVersion)
	{
		if (storageVersion != EFOracleVersion.Oracle10gR1 && storageVersion != EFOracleVersion.Oracle10gR2 && storageVersion != EFOracleVersion.Oracle11gR1 && storageVersion != EFOracleVersion.Oracle11gR2 && storageVersion != EFOracleVersion.Oracle12gR1 && storageVersion != EFOracleVersion.Oracle12gR2)
		{
			return storageVersion == EFOracleVersion.Oracle9iR2;
		}
		return true;
	}
}
