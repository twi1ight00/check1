using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

public class Driver
{
	private Guid ruleId;

	private Guid parentRuleId;

	private int activityType;

	private List<User> nextHandler;

	private IList<Driver> next;

	public List<User> NextHandler
	{
		get
		{
			return nextHandler;
		}
		set
		{
			nextHandler = value;
		}
	}

	public int ActivityType
	{
		get
		{
			return activityType;
		}
		set
		{
			activityType = value;
		}
	}

	public Guid RuleId
	{
		get
		{
			return ruleId;
		}
		set
		{
			ruleId = value;
		}
	}

	public IList<Driver> Next
	{
		get
		{
			return next;
		}
		set
		{
			next = value;
		}
	}

	public Driver()
	{
		next = new List<Driver>();
	}

	public bool HaveNextDriver()
	{
		return next == null || next.Count == 0;
	}
}
