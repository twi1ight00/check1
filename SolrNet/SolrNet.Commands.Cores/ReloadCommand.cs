using System;

namespace SolrNet.Commands.Cores;

public class ReloadCommand : CoreCommand
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:SolrNet.Commands.Cores.ReloadCommand" /> class.
	/// </summary>
	/// <param name="coreName">Name of the core to reload.</param>
	public ReloadCommand(string coreName)
	{
		if (string.IsNullOrEmpty(coreName))
		{
			throw new ArgumentException("Core Name must be specified.", "coreName");
		}
		AddParameter("action", "RELOAD");
		AddParameter("core", coreName);
	}
}
