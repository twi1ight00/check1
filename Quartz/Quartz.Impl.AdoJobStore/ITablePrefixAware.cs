namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// Interface for Quartz objects that need to know what the table prefix of
/// the tables used by a ADO.NET JobStore is.
/// </summary>
/// <author>Marko Lahma (.NET)</author>
public interface ITablePrefixAware
{
	/// <summary>
	/// Table prefix to use.
	/// </summary>
	string TablePrefix { set; }

	string SchedName { set; }
}
