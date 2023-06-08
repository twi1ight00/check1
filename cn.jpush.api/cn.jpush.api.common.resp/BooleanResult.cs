using Newtonsoft.Json;

namespace cn.jpush.api.common.resp;

public class BooleanResult : DefaultResult
{
	public bool result;

	public new static BooleanResult fromResponse(ResponseWrapper responseWrapper)
	{
		BooleanResult booleanResult = new BooleanResult();
		if (responseWrapper.isServerResponse())
		{
			booleanResult = JsonConvert.DeserializeObject<BooleanResult>(responseWrapper.responseContent);
		}
		booleanResult.ResponseResult = responseWrapper;
		return booleanResult;
	}
}
