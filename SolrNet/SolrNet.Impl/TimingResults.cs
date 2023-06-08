using System.Collections.Generic;

namespace SolrNet.Impl;

/// <summary>
/// Timing results model
/// </summary>
public class TimingResults
{
	private readonly double totalTime;

	private readonly IDictionary<string, double> prepare;

	private readonly IDictionary<string, double> process;

	/// <summary>
	/// Elapsed time
	/// </summary>
	public double TotalTime => totalTime;

	/// <summary>
	/// Time results for preparing stage
	/// </summary>
	public IDictionary<string, double> Prepare => prepare;

	/// <summary>
	/// Time results for processing stage
	/// </summary>
	public IDictionary<string, double> Process => process;

	/// <summary>
	/// TimingResults initializer
	/// </summary>
	public TimingResults(double totalTime, IDictionary<string, double> prepare, IDictionary<string, double> process)
	{
		this.totalTime = totalTime;
		this.prepare = prepare;
		this.process = process;
	}
}
