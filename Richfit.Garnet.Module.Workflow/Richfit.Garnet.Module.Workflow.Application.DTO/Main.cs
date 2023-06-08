using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class Main
{
	public int? RetCode { get; set; }

	public string RetMessage { get; set; }

	public List<WF_WORKITEMOLDDTO> Data { get; set; }
}
