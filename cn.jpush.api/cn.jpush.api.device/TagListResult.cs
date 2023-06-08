using System.Collections.Generic;
using System.Net;
using cn.jpush.api.common;
using Newtonsoft.Json;

namespace cn.jpush.api.device;

public class TagListResult : BaseResult
{
	public List<string> tags;

	public TagListResult()
	{
		tags = null;
	}

	public override bool isResultOK()
	{
		if (!object.Equals(base.ResponseResult.responseCode, HttpStatusCode.OK))
		{
			return false;
		}
		return true;
	}

	public static TagListResult fromResponse(ResponseWrapper responseWrapper)
	{
		TagListResult tagListResult = new TagListResult();
		if (responseWrapper.isServerResponse())
		{
			tagListResult = JsonConvert.DeserializeObject<TagListResult>(responseWrapper.responseContent);
		}
		tagListResult.ResponseResult = responseWrapper;
		return tagListResult;
	}
}
