using System.Collections.Generic;
using System.Net;
using cn.jpush.api.common;
using Newtonsoft.Json;

namespace cn.jpush.api.device;

public class AliasDeviceListResult : BaseResult
{
	public List<string> registration_ids;

	public AliasDeviceListResult()
	{
		registration_ids = null;
	}

	public override bool isResultOK()
	{
		if (!object.Equals(base.ResponseResult.responseCode, HttpStatusCode.OK))
		{
			return false;
		}
		return true;
	}

	public static AliasDeviceListResult fromResponse(ResponseWrapper responseWrapper)
	{
		AliasDeviceListResult aliasDeviceListResult = new AliasDeviceListResult();
		if (responseWrapper.isServerResponse())
		{
			aliasDeviceListResult = JsonConvert.DeserializeObject<AliasDeviceListResult>(responseWrapper.responseContent);
		}
		aliasDeviceListResult.ResponseResult = responseWrapper;
		return aliasDeviceListResult;
	}
}
