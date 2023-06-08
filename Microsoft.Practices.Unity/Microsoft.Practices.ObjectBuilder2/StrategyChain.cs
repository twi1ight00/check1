using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Represents a chain of responsibility for builder strategies.
/// </summary>
public class StrategyChain : IStrategyChain, IEnumerable<IBuilderStrategy>, IEnumerable
{
	private readonly List<IBuilderStrategy> strategies = new List<IBuilderStrategy>();

	/// <summary>
	/// Initialzie a new instance of the <see cref="T:Microsoft.Practices.ObjectBuilder2.StrategyChain" /> class.
	/// </summary>
	public StrategyChain()
	{
	}

	/// <summary>
	/// Initialzie a new instance of the <see cref="T:Microsoft.Practices.ObjectBuilder2.StrategyChain" /> class with a colleciton of strategies.
	/// </summary>
	/// <param name="strategies">A collection of strategies to initialize the chain.</param>
	public StrategyChain(IEnumerable strategies)
	{
		AddRange(strategies);
	}

	/// <summary>
	/// Adds a strategy to the chain.
	/// </summary>
	/// <param name="strategy">The strategy to add to the chain.</param>
	public void Add(IBuilderStrategy strategy)
	{
		strategies.Add(strategy);
	}

	/// <summary>
	/// Adds strategies to the chain.
	/// </summary>
	/// <param name="strategyEnumerable">The strategies to add to the chain.</param>
	public void AddRange(IEnumerable strategyEnumerable)
	{
		Guard.ArgumentNotNull(strategyEnumerable, "strategyEnumerable");
		foreach (IBuilderStrategy item in strategyEnumerable)
		{
			Add(item);
		}
	}

	/// <summary>
	/// Reverse the order of the strategy chain.
	/// </summary>
	/// <returns>The reversed strategy chain.</returns>
	public IStrategyChain Reverse()
	{
		List<IBuilderStrategy> list = new List<IBuilderStrategy>(strategies);
		list.Reverse();
		return new StrategyChain(list);
	}

	/// <summary>
	/// Execute this strategy chain against the given context to build up.
	/// </summary>
	/// <param name="context">Context for the build processes.</param>
	/// <returns>The build up object</returns>
	public object ExecuteBuildUp(IBuilderContext context)
	{
		int i = 0;
		try
		{
			for (; i < strategies.Count; i++)
			{
				if (context.BuildComplete)
				{
					break;
				}
				strategies[i].PreBuildUp(context);
			}
			if (context.BuildComplete)
			{
				i--;
			}
			for (i--; i >= 0; i--)
			{
				strategies[i].PostBuildUp(context);
			}
			return context.Existing;
		}
		catch (Exception)
		{
			context.RecoveryStack.ExecuteRecovery();
			throw;
		}
	}

	/// <summary>
	/// Execute this strategy chain against the given context,
	/// calling the TearDown methods on the strategies.
	/// </summary>
	/// <param name="context">Context for the teardown process.</param>
	public void ExecuteTearDown(IBuilderContext context)
	{
		int i = 0;
		try
		{
			for (; i < strategies.Count; i++)
			{
				if (context.BuildComplete)
				{
					i--;
					break;
				}
				strategies[i].PreTearDown(context);
			}
			for (i--; i >= 0; i--)
			{
				strategies[i].PostTearDown(context);
			}
		}
		catch (Exception)
		{
			context.RecoveryStack.ExecuteRecovery();
			throw;
		}
	}

	/// <summary>
	/// Returns an enumerator that iterates through the collection.
	/// </summary>
	///
	/// <returns>
	/// A <see cref="T:System.Collections.Generic.IEnumerator`1"></see> that can be used to iterate through the collection.
	/// </returns>
	/// <filterpriority>1</filterpriority>
	IEnumerator<IBuilderStrategy> IEnumerable<IBuilderStrategy>.GetEnumerator()
	{
		return strategies.GetEnumerator();
	}

	/// <summary>
	/// Returns an enumerator that iterates through a collection.
	/// </summary>
	///
	/// <returns>
	/// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
	/// </returns>
	/// <filterpriority>2</filterpriority>
	public IEnumerator GetEnumerator()
	{
		return strategies.GetEnumerator();
	}
}
