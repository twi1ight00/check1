using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class OpoConRefCtx
{
	public string serverVersion;

	public string userID;

	public string password;

	public string dataSource;

	public string newPassword;

	public string proxyUserId;

	public string proxyPassword;

	public string dbName;

	public string dbDomainName;

	public string hostName;

	public string instanceName;

	public string serviceName;

	public string clientID;

	public string appEdition;

	public ITransaction pITransaction;

	public string moduleName;

	public string actionName;

	public string clientInfo;

	public string ttOpsConOpenErrMssg;
}
