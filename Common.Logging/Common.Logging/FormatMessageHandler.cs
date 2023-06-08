namespace Common.Logging;

/// <summary>
///  The type of method that is passed into e.g. <see cref="M:Common.Logging.ILog.Debug(System.Action{Common.Logging.FormatMessageHandler})" /> 
///  and allows the callback method to "submit" it's message to the underlying output system.
/// </summary>
/// <param name="format">the format argument as in <see cref="M:System.String.Format(System.String,System.Object[])" /></param>
/// <param name="args">the argument list as in <see cref="M:System.String.Format(System.String,System.Object[])" /></param>
/// <seealso cref="T:Common.Logging.ILog" />
///  <author>Erich Eichinger</author>
public delegate string FormatMessageHandler(string format, params object[] args);
