﻿using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Test;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
  Scope = "member", Target = "AltCover.Cake.DotNet.#DotNetCoreTest(Cake.Core.ICakeContext,Cake.Core.IO.FilePath,Cake.Common.Tools.DotNetCore.Test.DotNetCoreTestSettings,AltCover.Cake.AltCoverSettings)",
  MessageId = "altcover", Justification = "It's the product name.")]

namespace AltCover.Cake
{
  /// <summary>
  ///
  /// </summary>
  public class AltCoverSettings
  {
    /// <summary>
    ///
    /// </summary>
    public CSApi.IPrepareParameters PreparationPhase { get; set; }

    /// <summary>
    ///
    /// </summary>
    public CSApi.ICollectParameters CollectionPhase { get; set; }

    /// <summary>
    ///
    /// </summary>
    public CSApi.ICLIOptions Control { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public Func<ProcessArgumentBuilder, ProcessArgumentBuilder> Customize()
    {
      return pabIn =>
      {
        var pabOut = new ProcessArgumentBuilder();
        if (pabIn != null)
        {
          pabIn.CopyTo(pabOut);
        }
        var args = CSApi.ToTestArgumentList(
                    this.PreparationPhase,
                    this.CollectionPhase,
            this.Control).ToArray();
        Array.Reverse(args);
        Array.ForEach(
            args,
            t => pabOut.Prepend(t));
        return pabOut;
      };
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="customIn"></param>
    /// <returns></returns>
    public Func<ProcessArgumentBuilder, ProcessArgumentBuilder> Concatenate(Func<ProcessArgumentBuilder, ProcessArgumentBuilder> customIn)
    {
      var altcover = Customize();
      if (customIn == null)
      {
        return altcover;
      }
      else
      {
        return args => altcover(customIn(args));
      }
    }
  }

  /// <summary>
  ///
  /// </summary>
  [CakeAliasCategory("DotNetCore")]
  public static class DotNet
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="context"></param>
    /// <param name="project"></param>
    /// <param name="settings"></param>
    /// <param name="altcover"></param>
    [CakeMethodAlias]
    [CakeAliasCategory("Test")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
"Gendarme.Rules.Maintainability", "AvoidUnnecessarySpecializationRule",
Justification = "AvoidSpeculativeGenerality too")]
    public static void DotNetCoreTest(
                this ICakeContext context,
                FilePath project,
                DotNetCoreTestSettings settings,
                AltCoverSettings altcover)
    {
      if (project == null) throw new ArgumentNullException(nameof(project));
      if (settings == null) throw new ArgumentNullException(nameof(settings));
      if (altcover == null) throw new ArgumentNullException(nameof(altcover));

      settings.ArgumentCustomization = altcover.Concatenate(settings.ArgumentCustomization);
      context.DotNetCoreTest(project.GetFilename().FullPath, settings);
    }
  }
}