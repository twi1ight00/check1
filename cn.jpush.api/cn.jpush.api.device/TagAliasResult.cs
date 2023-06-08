using System.Collections.Generic;
using System.Net;
using cn.jpush.api.common;
using Newtonsoft.Json;

namespace cn.jpush.api.device;

public class TagAliasResult : BaseResult
{
	public List<string> tags;

	public string alias;

	public TagAliasResult()
	{
		tags = null;
		alias = null;
	}

	public override bool isResultOK()
	{
		if (object.Equals(base.ResponseResult.responseCode, HttpStatusCode.OK))
		{
			return true;
		}
		return false;
	}

	public static TagAliasResult fromResponse(ResponseWrapper responseWrapper)
	{
		TagAliasResult tagAliasResult = new TagAliasResult();
		if (responseWrapper.isServerResponse())
		{
			tagAliasResult = JsonConvert.DeserializeObject<TagAliasResult>(responseWrapper.responseContent);
		}
		tagAliasResult.ResponseResult = responseWrapper;
		return tagAliasResult;
	}
}
