﻿using System.Diagnostics.CodeAnalysis;
using Cake.Core;
using Cake.Core.Annotations;
using LogLevel = Cake.Core.Diagnostics.LogLevel;
using Verbosity = Cake.Core.Diagnostics.Verbosity;

namespace AltCover.Cake
{
  /// <summary>
  ///
  /// </summary>
  [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
                    Justification = "It's the API for the system")]
  public static class Api
  {
    private static CSApi.ILogging MakeLog(ICakeContext context, CSApi.ILogging log)
    {
      if (log != null)
        return log;

      if (context != null)
        return new CSApi.Primitive.LoggingParameters()
        {
          Info = x => context.Log.Write(Verbosity.Normal, LogLevel.Information, x),
          Warn = x => context.Log.Write(Verbosity.Normal, LogLevel.Warning, x),
          Echo = x => context.Log.Write(Verbosity.Normal, LogLevel.Error, x),
          StandardError = x => context.Log.Write(Verbosity.Verbose, LogLevel.Information, x),
        };

      return new CSApi.Primitive.LoggingParameters()
      {
        Info = x => { },
        Warn = x => { },
        Echo = x => { },
        StandardError = x => { }
      };
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="context"></param>
    /// <param name="prepareArgs"></param>
    /// <param name="log"></param>
    /// <returns></returns>
    [CakeMethodAlias]
    [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed",
                     Justification = "WTF is this rule saying?")]
    public static int Prepare(this ICakeContext context, CSApi.IPrepareParameters prepareArgs, CSApi.ILogging log = null)
    {
      return CSApi.Prepare(prepareArgs, MakeLog(context, log));
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="context"></param>
    /// <param name="collectArgs"></param>
    /// <param name="log"></param>
    /// <returns></returns>
    [CakeMethodAlias]
    [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed",
                     Justification = "WTF is this rule saying?")]
    public static int Collect(this ICakeContext context, CSApi.ICollectParameters collectArgs, CSApi.ILogging log = null)
    {
      return CSApi.Collect(collectArgs, MakeLog(context, log));
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    [CakeMethodAlias]
    public static string ImportModule(this ICakeContext context)
    {
      if (context == null) throw new System.ArgumentNullException(nameof(context));
      return CSApi.ImportModule();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    [CakeMethodAlias]
    public static string Version(this ICakeContext context)
    {
      if (context == null) throw new System.ArgumentNullException(nameof(context));
      return CSApi.Version();
    }
  }
}