using System;
using System.Collections;

namespace Oracle.DataAccess.Client;

internal class ODTConfigFileInfoForRefCursors
{
	internal DateTime lastModifiedTime;

	internal Hashtable storedProcList = new Hashtable();
}
