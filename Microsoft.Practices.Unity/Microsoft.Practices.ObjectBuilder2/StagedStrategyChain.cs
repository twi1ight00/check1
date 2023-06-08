using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Represents a chain of responsibility for builder strategies partitioned by stages.
/// </summary>
/// <typeparam name="TStageEnum">The stage enumeration to partition the strategies.</typeparam>
public class StagedStrategyChain<TStageEnum> : IStagedStrategyChain
{
	private readonly StagedStrategyChain<TStageEnum> innerChain;

	private readonly object lockObject = new object();

	private readonly List<IBuilderStrategy>[] stages;

	/// <summary>
	/// Initialize a new instance of the <see cref="T:Microsoft.Practices.ObjectBuilder2.StagedStrategyChain`1" /> class.
	/// </summary>
	public StagedStrategyChain()
	{
		stages = new List<IBuilderStrategy>[NumberOfEnumValues()];
		for (int i = 0; i < stages.Length; i++)
		{
			stages[i] = new List<IBuilderStrategy>();
		}
	}

	/// <summary>
	/// Initialize a new instance of the <see cref="T:Microsoft.Practices.ObjectBuilder2.StagedStrategyChain`1" /> class with an inner strategy chain to use when building.
	/// </summary>
	/// <param name="innerChain">The inner strategy chain to use first when finding strategies in the build operation.</param>
	public StagedStrategyChain(StagedStrategyChain<TStageEnum> innerChain)
		: this()
	{
		this.innerChain = innerChain;
	}

	/// <summary>
	/// Adds a strategy to the chain at a particular stage.
	/// </summary>
	/// <param name="strategy">The strategy to add to the chain.</param>
	/// <param name="stage">The stage to add the strategy.</param>
	public void Add(IBuilderStrategy strategy, TStageEnum stage)
	{
		lock (lockObject)
		{
			stages[Convert.ToInt32(stage)].Add(strategy);
		}
	}

	/// <summary>
	/// Add a new strategy for the <paramref name="stage" />.
	/// </summary>
	/// <typeparam name="TStrategy">The <see cref="T:System.Type" /> of <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderStrategy" /></typeparam>
	/// <param name="stage">The stage to add the strategy.</param>
	public void AddNew<TStrategy>(TStageEnum stage) where TStrategy : IBuilderStrategy, new()
	{
		Add(new TStrategy(), stage);
	}

	/// <summary>
	/// Clear the current strategy chain list.
	/// </summary>
	/// <remarks>
	/// This will not clear the inner strategy chain if this instane was created with one.
	/// </remarks>
	public void Clear()
	{
		lock (lockObject)
		{
			List<IBuilderStrategy>[] array = stages;
			foreach (List<IBuilderStrategy> list in array)
			{
				list.Clear();
			}
		}
	}

	/// <summary>
	/// Makes a strategy chain based on this instance.
	/// </summary>
	/// <returns>A new <see cref="T:Microsoft.Practices.ObjectBuilder2.StrategyChain" />.</returns>
	public IStrategyChain MakeStrategyChain()
	{
		lock (lockObject)
		{
			StrategyChain strategyChain = new StrategyChain();
			for (int i = 0; i < stages.Length; i++)
			{
				FillStrategyChain(strategyChain, i);
			}
			return strategyChain;
		}
	}

	private void FillStrategyChain(StrategyChain chain, int index)
	{
		lock (lockObject)
		{
			if (innerChain != null)
			{
				innerChain.FillStrategyChain(chain, index);
			}
			chain.AddRange(stages[index]);
		}
	}

	private static int NumberOfEnumValues()
	{
		return typeof(TStageEnum).GetFields(BindingFlags.Static | BindingFlags.Public).Length;
	}
}
