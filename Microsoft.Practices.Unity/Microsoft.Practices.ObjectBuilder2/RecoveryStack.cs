using System.Collections.Generic;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IRecoveryStack" />.
/// </summary>
public class RecoveryStack : IRecoveryStack
{
	private Stack<IRequiresRecovery> recoveries = new Stack<IRequiresRecovery>();

	private object lockObj = new object();

	/// <summary>
	/// Return the number of recovery objects currently in the stack.
	/// </summary>
	public int Count
	{
		get
		{
			lock (lockObj)
			{
				return recoveries.Count;
			}
		}
	}

	/// <summary>
	/// Add a new <see cref="T:Microsoft.Practices.ObjectBuilder2.IRequiresRecovery" /> object to this
	/// list.
	/// </summary>
	/// <param name="recovery">Object to add.</param>
	public void Add(IRequiresRecovery recovery)
	{
		Guard.ArgumentNotNull(recovery, "recovery");
		lock (lockObj)
		{
			recoveries.Push(recovery);
		}
	}

	/// <summary>
	/// Execute the <see cref="M:Microsoft.Practices.ObjectBuilder2.IRequiresRecovery.Recover" /> method
	/// of everything in the recovery list. Recoveries will execute
	/// in the opposite order of add - it's a stack.
	/// </summary>
	public void ExecuteRecovery()
	{
		while (recoveries.Count > 0)
		{
			recoveries.Pop().Recover();
		}
	}
}
