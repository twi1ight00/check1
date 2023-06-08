using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Common.Logging;

namespace Quartz.Job;

/// <summary>
/// Built in job for executing native executables in a separate process.
/// </summary>
/// <remarks>
/// <example>
///     JobDetail job = new JobDetail("dumbJob", null, typeof(Quartz.Jobs.NativeJob));
///     job.JobDataMap.Put(Quartz.Jobs.NativeJob.PropertyCommand, "echo \"hi\" &gt;&gt; foobar.txt");
///     Trigger trigger = TriggerUtils.MakeSecondlyTrigger(5);
///     trigger.Name = "dumbTrigger";
///     sched.ScheduleJob(job, trigger);
/// </example>
/// If PropertyWaitForProcess is true, then the integer exit value of the process
/// will be saved as the job execution result in the JobExecutionContext.
/// </remarks>
/// <author>Matthew Payne</author>
/// <author>James House</author>
/// <author>Steinar Overbeck Cook</author>
/// <author>Marko Lahma (.NET)</author>
public class NativeJob : IJob
{
	/// <summary> 
	/// Consumes data from the given input stream until EOF and prints the data to stdout
	/// </summary>
	/// <author>cooste</author>
	/// <author>James House</author>
	private class StreamConsumer : QuartzThread
	{
		private readonly NativeJob enclosingInstance;

		private readonly Stream inputStream;

		private readonly string type;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Quartz.Job.NativeJob.StreamConsumer" /> class.
		/// </summary>
		/// <param name="enclosingInstance">The enclosing instance.</param>
		/// <param name="inputStream">The input stream.</param>
		/// <param name="type">The type.</param>
		public StreamConsumer(NativeJob enclosingInstance, Stream inputStream, string type)
		{
			this.enclosingInstance = enclosingInstance;
			this.inputStream = inputStream;
			this.type = type;
		}

		/// <summary> 
		/// Runs this object as a separate thread, printing the contents of the input stream
		/// supplied during instantiation, to either Console. or stderr
		/// </summary>
		public override void Run()
		{
			try
			{
				using StreamReader br = new StreamReader(inputStream);
				string line;
				while ((line = br.ReadLine()) != null)
				{
					if (type == "stderr")
					{
						enclosingInstance.Log.Warn(string.Format(CultureInfo.InvariantCulture, "{0}>{1}", new object[2] { type, line }));
					}
					else
					{
						enclosingInstance.Log.Info(string.Format(CultureInfo.InvariantCulture, "{0}>{1}", new object[2] { type, line }));
					}
				}
			}
			catch (IOException ioe)
			{
				enclosingInstance.Log.Error(string.Format(CultureInfo.InvariantCulture, "Error consuming {0} stream of spawned process.", new object[1] { type }), ioe);
			}
		}
	}

	/// <summary> 
	/// Required parameter that specifies the name of the command (executable) 
	/// to be ran.
	/// </summary>
	public const string PropertyCommand = "command";

	/// <summary> 
	/// Optional parameter that specifies the parameters to be passed to the
	/// executed command.
	/// </summary>
	public const string PropertyParameters = "parameters";

	/// <summary> 
	/// Optional parameter (value should be 'true' or 'false') that specifies 
	/// whether the job should wait for the execution of the native process to 
	/// complete before it completes.
	///
	/// <para>Defaults to <see langword="true" />.</para>  
	/// </summary>
	public const string PropertyWaitForProcess = "waitForProcess";

	/// <summary> 
	/// Optional parameter (value should be 'true' or 'false') that specifies 
	/// whether the spawned process's stdout and stderr streams should be 
	/// consumed.  If the process creates output, it is possible that it might
	/// 'hang' if the streams are not consumed.
	///
	/// <para>Defaults to <see langword="false" />.</para>  
	/// </summary>
	public const string PropertyConsumeStreams = "consumeStreams";

	/// <summary> 
	/// Optional parameter that specifies the workling directory to be used by 
	/// the executed command.
	/// </summary>
	public const string PropertyWorkingDirectory = "workingDirectory";

	private const string StreamTypeStandardOutput = "stdout";

	private const string StreamTypeError = "stderr";

	private readonly ILog log;

	/// <summary>
	/// Gets the log.
	/// </summary>
	/// <value>The log.</value>
	protected ILog Log => log;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Job.NativeJob" /> class.
	/// </summary>
	public NativeJob()
	{
		log = LogManager.GetLogger(typeof(NativeJob));
	}

	/// <summary>
	/// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
	/// fires that is associated with the <see cref="T:Quartz.IJob" />.
	/// <para>
	/// The implementation may wish to set a  result object on the
	/// JobExecutionContext before this method exits.  The result itself
	/// is meaningless to Quartz, but may be informative to
	/// <see cref="T:Quartz.IJobListener" />s or
	/// <see cref="T:Quartz.ITriggerListener" />s that are watching the job's
	/// execution.
	/// </para>
	/// </summary>
	/// <param name="context"></param>
	public virtual void Execute(IJobExecutionContext context)
	{
		JobDataMap data = context.MergedJobDataMap;
		string command = data.GetString("command");
		string parameters = data.GetString("parameters") ?? "";
		bool wait = true;
		if (data.ContainsKey("waitForProcess"))
		{
			wait = data.GetBooleanValue("waitForProcess");
		}
		bool consumeStreams = false;
		if (data.ContainsKey("consumeStreams"))
		{
			consumeStreams = data.GetBooleanValue("consumeStreams");
		}
		string workingDirectory = data.GetString("workingDirectory");
		int exitCode = RunNativeCommand(command, parameters, workingDirectory, wait, consumeStreams);
		context.Result = exitCode;
	}

	private int RunNativeCommand(string command, string parameters, string workingDirectory, bool wait, bool consumeStreams)
	{
		string[] args = new string[2] { command, parameters };
		int result = -1;
		try
		{
			string osName = Environment.GetEnvironmentVariable("OS");
			if (osName == null)
			{
				throw new JobExecutionException("Could not read environment variable for OS");
			}
			string[] cmd;
			if (osName.ToLower().IndexOf("windows") <= -1)
			{
				cmd = ((osName.ToLower().IndexOf("linux") <= -1) ? args : new string[3]
				{
					"/bin/sh",
					"-c",
					args[0] + " " + args[1]
				});
			}
			else
			{
				cmd = new string[args.Length + 2];
				cmd[0] = "cmd.exe";
				cmd[1] = "/C";
				for (int j = 0; j < args.Length; j++)
				{
					cmd[j + 2] = args[j];
				}
			}
			string temp = "";
			for (int i = 1; i < cmd.Length; i++)
			{
				temp = temp + cmd[i] + " ";
			}
			temp = temp.Trim();
			Log.Info(string.Format(CultureInfo.InvariantCulture, "About to run {0} {1}...", new object[2]
			{
				cmd[0],
				temp
			}));
			Process proc = new Process();
			proc.StartInfo.FileName = cmd[0];
			proc.StartInfo.Arguments = temp;
			proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			proc.StartInfo.CreateNoWindow = true;
			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.RedirectStandardError = true;
			proc.StartInfo.RedirectStandardOutput = true;
			if (!string.IsNullOrEmpty(workingDirectory))
			{
				proc.StartInfo.WorkingDirectory = workingDirectory;
			}
			proc.Start();
			StreamConsumer stdoutConsumer = new StreamConsumer(this, proc.StandardOutput.BaseStream, "stdout");
			if (consumeStreams)
			{
				StreamConsumer stderrConsumer = new StreamConsumer(this, proc.StandardError.BaseStream, "stderr");
				stdoutConsumer.Start();
				stderrConsumer.Start();
			}
			if (wait)
			{
				proc.WaitForExit();
				result = proc.ExitCode;
			}
		}
		catch (Exception x)
		{
			throw new JobExecutionException("Error launching native command: " + x.Message, x, refireImmediately: false);
		}
		return result;
	}
}
