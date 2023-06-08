using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Workflow.Application.IServices;

namespace Richfit.Garnet.Module.Workflow.Form.Application.Services;

public class WorkflowFormService : ServiceBase, IWorkflowFormService
{
	public string AccountList(string p)
	{
		Dictionary<string, string> dicInfo = p.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string dtoName = dicInfo["DTONAME"];
		Type t = Type.GetType($"{dtoName},Richfit.Garnet.Module.Workflow.Form");
		IDTO dto = (IDTO)t.CreateInstance();
		return dto.FindList(p);
	}
}
