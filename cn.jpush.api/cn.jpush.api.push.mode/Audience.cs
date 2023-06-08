using System.Collections.Generic;
using cn.jpush.api.push.audience;
using cn.jpush.api.util;

namespace cn.jpush.api.push.mode;

public class Audience
{
	private const string ALL = "all";

	public string allAudience;

	public Dictionary<string, HashSet<string>> dictionary;

	private void AddWithAudienceTarget(AudienceTarget target)
	{
		if (target == null || target.valueBuilder == null)
		{
			return;
		}
		allAudience = null;
		if (dictionary == null)
		{
			dictionary = new Dictionary<string, HashSet<string>>();
		}
		if (dictionary.ContainsKey(target.audienceType.ToString()))
		{
			HashSet<string> hashSet = dictionary[target.audienceType.ToString()];
			{
				foreach (string item in target.valueBuilder)
				{
					hashSet.Add(item);
				}
				return;
			}
		}
		dictionary.Add(target.audienceType.ToString(), target.valueBuilder);
	}

	private Audience()
	{
		allAudience = "all";
		dictionary = null;
	}

	public static Audience all()
	{
		return new Audience
		{
			allAudience = "all",
			dictionary = null
		}.Check();
	}

	public static Audience s_tag(HashSet<string> values)
	{
		return new Audience().tag(values);
	}

	public static Audience s_tag(params string[] values)
	{
		return new Audience().tag(values);
	}

	public static Audience s_tag_and(HashSet<string> values)
	{
		return new Audience().tag_and(values);
	}

	public static Audience s_tag_and(params string[] values)
	{
		return new Audience().tag_and(values);
	}

	public static Audience s_alias(HashSet<string> values)
	{
		return new Audience().alias(values);
	}

	public static Audience s_alias(params string[] values)
	{
		return new Audience().alias(values);
	}

	public static Audience s_segment(HashSet<string> values)
	{
		return new Audience().segment(values);
	}

	public static Audience s_segment(params string[] values)
	{
		return new Audience().segment(values);
	}

	public static Audience s_registrationId(HashSet<string> values)
	{
		return new Audience().registrationId(values);
	}

	public static Audience s_registrationId(params string[] values)
	{
		return new Audience().registrationId(values);
	}

	public Audience tag(HashSet<string> values)
	{
		if (allAudience != null)
		{
			allAudience = null;
		}
		AudienceTarget target = AudienceTarget.tag(values);
		AddWithAudienceTarget(target);
		return Check();
	}

	public Audience tag(params string[] values)
	{
		if (allAudience != null)
		{
			allAudience = null;
		}
		HashSet<string> values2 = new HashSet<string>(values);
		return tag(values2);
	}

	public Audience tag_and(HashSet<string> values)
	{
		if (allAudience != null)
		{
			allAudience = null;
		}
		AudienceTarget audienceTarget = AudienceTarget.tag_and(values);
		allAudience = null;
		if (dictionary == null)
		{
			dictionary = new Dictionary<string, HashSet<string>>();
		}
		if (dictionary.ContainsKey(audienceTarget.audienceType.ToString()))
		{
			HashSet<string> hashSet = dictionary[audienceTarget.audienceType.ToString()];
			foreach (string value in values)
			{
				hashSet.Add(value);
			}
		}
		else
		{
			dictionary.Add(audienceTarget.audienceType.ToString(), values);
		}
		return Check();
	}

	public Audience tag_and(params string[] values)
	{
		if (allAudience != null)
		{
			allAudience = null;
		}
		HashSet<string> values2 = new HashSet<string>(values);
		return tag_and(values2);
	}

	public Audience alias(HashSet<string> values)
	{
		if (allAudience != null)
		{
			allAudience = null;
		}
		AddWithAudienceTarget(AudienceTarget.alias(values));
		return Check();
	}

	public Audience alias(params string[] values)
	{
		if (allAudience != null)
		{
			allAudience = null;
		}
		return alias(new HashSet<string>(values));
	}

	public Audience segment(HashSet<string> values)
	{
		if (allAudience != null)
		{
			allAudience = null;
		}
		AddWithAudienceTarget(AudienceTarget.segment(values));
		return Check();
	}

	public Audience segment(params string[] values)
	{
		if (allAudience != null)
		{
			allAudience = null;
		}
		return segment(new HashSet<string>(values));
	}

	public Audience registrationId(HashSet<string> values)
	{
		if (allAudience != null)
		{
			allAudience = null;
		}
		AddWithAudienceTarget(AudienceTarget.registrationId(values));
		return Check();
	}

	public Audience registrationId(params string[] values)
	{
		if (allAudience != null)
		{
			allAudience = null;
		}
		return registrationId(new HashSet<string>(values));
	}

	public bool isAll()
	{
		return allAudience != null;
	}

	public Audience Check()
	{
		Preconditions.checkArgument(!isAll() || dictionary == null, "Since all is enabled, any platform should not be set.");
		Preconditions.checkArgument(isAll() || dictionary != null, "No any deviceType is set.");
		return this;
	}
}
