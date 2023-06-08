using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Workflow.Application.Enums;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

public class SubmitDTO
{
	private User handler;

	private Driver drivers;

	private Guid instanceId;

	private Guid workItemId;

	private HANDLE_RESULT handleResult;

	private string suggestion;

	public List<WF_INSTANCE_ACTIVITY> WF_INSTANCE_ACTIVITY { get; set; }

	public WF_ACTIVITY CurrentActivity { get; set; }

	public User Handler
	{
		get
		{
			return handler;
		}
		set
		{
			handler = value;
		}
	}

	public Driver Drivers
	{
		get
		{
			return drivers;
		}
		set
		{
			drivers = value;
		}
	}

	public Guid InstanceId
	{
		get
		{
			return instanceId;
		}
		set
		{
			instanceId = value;
		}
	}

	public Guid WorkItemId
	{
		get
		{
			return workItemId;
		}
		set
		{
			workItemId = value;
		}
	}

	public HANDLE_RESULT HandleResult
	{
		get
		{
			return handleResult;
		}
		set
		{
			handleResult = value;
		}
	}

	public string Suggestion
	{
		get
		{
			return suggestion;
		}
		set
		{
			suggestion = value;
		}
	}

	public string FormData { get; set; }

	public string RuleExpress { get; set; }
}
