/// <summary>
/// <h1>Overview</h1>
/// <para>
/// There are a variety of logging implementations for .NET currently in use, log4net, Enterprise 
/// Library Logging, NLog, to name the most popular. The downside of having differerent implementation 
/// is that they do not share a common interface and therefore impose a particular logging 
/// implementation on the users of your library. To solve this dependency problem the Common.Logging 
/// library introduces a simple abstraction to allow you to select a specific logging implementation at 
/// runtime.
/// </para>
/// <para>
/// The library is based on work done by the developers of IBatis.NET and it's usage is inspired by 
/// log4net. Many thanks to the developers of those projects!
/// </para>
/// <h1>Usage</h1>
/// <para>
/// The core logging library Common.Logging provides the base logging <see cref="T:Common.Logging.ILog" /> interface as 
/// well as the global <see cref="T:Common.Logging.LogManager" /> that you use to instrument your code:
/// </para>
/// <code lang="C#">
/// ILog log = LogManager.GetLogger(this.GetType());  
///
/// log.DebugFormat("Hi {0}", "dude");
/// </code>
/// <para>
/// To output the information logged, you need to tell Common.Logging, what underlying logging system 
/// to use. Common.Logging already includes simple console and trace based logger implementations 
/// usable out of the box. Adding the following configuration snippet to your app.config causes 
/// Common.Logging to output all information to the console:
/// </para>
/// <code lang="XML">
/// &lt;configuration&gt; 
///     &lt;configSections&gt; 
///       &lt;sectionGroup name="common"&gt; 
///         &lt;section name="logging" type="Common.Logging.ConfigurationSectionHandler, Common.Logging" /&gt; 
///       &lt;/sectionGroup&gt;  
///     &lt;/configSections&gt; 
///
///     &lt;common&gt; 
///       &lt;logging&gt; 
///         &lt;factoryAdapter type="Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter, Common.Logging"&gt; 
///           &lt;arg key="level" value="DEBUG" /&gt; 
///         &lt;/factoryAdapter&gt; 
///       &lt;/logging&gt; 
///     &lt;/common&gt; 
/// &lt;/configuration&gt; 
/// </code>
/// <h1>Customizing</h1>
/// <para>
/// In the case you want to integrate your own logging system that is not supported by Common.Logging yet, it is easily 
/// possible to implement your own plugin by implementing <see cref="T:Common.Logging.ILoggerFactoryAdapter" />.
/// For convenience there is a base <see cref="T:Common.Logging.Factory.AbstractCachingLoggerFactoryAdapter" /> implementation available that usually 
/// makes implementing your own adapter a breeze.
/// </para>
/// <h1>&lt;system.diagnostics&gt; Integration</h1>
/// <para>
/// If your code already uses the .NET framework's built-in <a href="http://msdn.microsoft.com/library/system.diagnostics.trace.aspx">System.Diagnostics.Trace</a>
/// system, you can use <see cref="T:Common.Logging.Simple.CommonLoggingTraceListener" /> to redirect all trace output to the 
/// Common.Logging infrastructure.
/// </para>
/// </summary>
[CoverageExclude]
internal static class NamespaceDoc
{
}
