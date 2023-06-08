using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.schedule;

public class Name
{
	[JsonProperty]
	private string name;

	public void setName(string name)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(name), "The name must not be empty.");
		Preconditions.checkArgument(StringUtil.IsValidName(name), "The name must be the right format.");
		Preconditions.checkArgument(name.Length < 255, "The name must be less than 255 bytes.");
		this.name = name;
	}

	public string getName()
	{
		return name;
	}
}
