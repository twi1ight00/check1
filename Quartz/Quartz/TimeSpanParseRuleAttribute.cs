using System;

namespace Quartz;

/// <summary>
/// Attribute to use with public <see cref="T:System.TimeSpan" /> properties that
/// can be set with Quartz configuration. Attribute can be used to advice
/// parsing to use correct type of time span (milliseconds, seconds, minutes, hours)
/// as it may depend on property.
/// </summary>
/// <author>Marko Lahma (.NET)</author>
/// <seealso cref="T:Quartz.TimeSpanParseRuleAttribute" />
public class TimeSpanParseRuleAttribute : Attribute
{
	private readonly TimeSpanParseRule rule;

	/// <summary>
	/// Gets the rule.
	/// </summary>
	/// <value>The rule.</value>
	public TimeSpanParseRule Rule => rule;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.TimeSpanParseRuleAttribute" /> class.
	/// </summary>
	/// <param name="rule">The rule.</param>
	public TimeSpanParseRuleAttribute(TimeSpanParseRule rule)
	{
		this.rule = rule;
	}
}
