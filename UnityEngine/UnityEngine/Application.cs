﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Application
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8FF7A2C-E4EE-4232-AB17-3FCABEC16496
// Assembly location: C:\Users\Blake\sandbox\unity\test-project\Library\UnityAssemblies\UnityEngine.dll

using System;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Access to application run-time data.</para>
  /// </summary>
  public sealed class Application
  {
    internal static Application.AdvertisingIdentifierCallback OnAdvertisingIdentifierCallback;
    private static Application.LogCallback s_LogCallbackHandler;
    private static Application.LogCallback s_LogCallbackHandlerThreaded;
    private static volatile Application.LogCallback s_RegisterLogCallbackDeprecated;

    /// <summary>
    ///   <para>Is some level being loaded? (Read Only)</para>
    /// </summary>
    [Obsolete("This property is deprecated, please use LoadLevelAsync to detect if a specific scene is currently loading.")]
    public static extern bool isLoadingLevel { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The total number of levels available (Read Only).</para>
    /// </summary>
    [Obsolete("Use SceneManager.sceneCountInBuildSettings")]
    public static extern int levelCount { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>How many bytes have we downloaded from the main unity web stream (Read Only).</para>
    /// </summary>
    public static extern int streamedBytes { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns true when in any kind of player (Read Only).</para>
    /// </summary>
    public static extern bool isPlaying { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Are we running inside the Unity editor? (Read Only)</para>
    /// </summary>
    public static extern bool isEditor { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Are we running inside a web player? (Read Only)</para>
    /// </summary>
    public static extern bool isWebPlayer { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns the platform the game is running on (Read Only).</para>
    /// </summary>
    public static extern RuntimePlatform platform { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Is the current Runtime platform a known mobile platform.</para>
    /// </summary>
    public static bool isMobilePlatform
    {
      get
      {
        switch (Application.platform)
        {
          case RuntimePlatform.IPhonePlayer:
          case RuntimePlatform.Android:
          case RuntimePlatform.MetroPlayerX86:
          case RuntimePlatform.MetroPlayerX64:
          case RuntimePlatform.MetroPlayerARM:
          case RuntimePlatform.WP8Player:
          case RuntimePlatform.BB10Player:
          case RuntimePlatform.TizenPlayer:
            return true;
          default:
            return false;
        }
      }
    }

    /// <summary>
    ///   <para>Is the current Runtime platform a known console platform.</para>
    /// </summary>
    public static bool isConsolePlatform
    {
      get
      {
        RuntimePlatform platform = Application.platform;
        switch (platform)
        {
          case RuntimePlatform.PS3:
          case RuntimePlatform.PS4:
          case RuntimePlatform.XBOX360:
            return true;
          default:
            return platform == RuntimePlatform.XboxOne;
        }
      }
    }

    /// <summary>
    ///   <para>Should the player be running when the application is in the background?</para>
    /// </summary>
    public static extern bool runInBackground { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("use Application.isEditor instead")]
    public static bool isPlayer
    {
      get
      {
        return !Application.isEditor;
      }
    }

    internal static extern bool isBatchmode { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal static extern bool isHumanControllingUs { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal static extern bool isRunningUnitTests { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Contains the path to the game data folder (Read Only).</para>
    /// </summary>
    public static extern string dataPath { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Contains the path to the StreamingAssets folder (Read Only).</para>
    /// </summary>
    public static extern string streamingAssetsPath { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Contains the path to a persistent data directory (Read Only).</para>
    /// </summary>
    [SecurityCritical]
    public static extern string persistentDataPath { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Contains the path to a temporary data / cache directory (Read Only).</para>
    /// </summary>
    public static extern string temporaryCachePath { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The path to the web player data file relative to the html file (Read Only).</para>
    /// </summary>
    public static extern string srcValue { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The absolute path to the web player data file (Read Only).</para>
    /// </summary>
    public static extern string absoluteURL { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The version of the Unity runtime used to play the content.</para>
    /// </summary>
    public static extern string unityVersion { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns application version number  (Read Only).</para>
    /// </summary>
    public static extern string version { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns application bundle identifier at runtime.</para>
    /// </summary>
    public static extern string bundleIdentifier { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns application install mode (Read Only).</para>
    /// </summary>
    public static extern ApplicationInstallMode installMode { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns application running in sandbox (Read Only).</para>
    /// </summary>
    public static extern ApplicationSandboxType sandboxType { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns application product name (Read Only).</para>
    /// </summary>
    public static extern string productName { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Return application company name (Read Only).</para>
    /// </summary>
    public static extern string companyName { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>A unique cloud project identifier. It is unique for every project (Read Only).</para>
    /// </summary>
    public static extern string cloudProjectId { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Indicates whether Unity's webplayer security model is enabled.</para>
    /// </summary>
    public static extern bool webSecurityEnabled { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public static extern string webSecurityHostUrl { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Instructs game to try to render at a specified frame rate.</para>
    /// </summary>
    public static extern int targetFrameRate { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The language the user's operating system is running in.</para>
    /// </summary>
    public static extern SystemLanguage systemLanguage { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Stack trace logging options. The default value is StackTraceLogType.ScriptOnly.</para>
    /// </summary>
    public static extern StackTraceLogType stackTraceLogType { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Priority of background loading thread.</para>
    /// </summary>
    public static extern ThreadPriority backgroundLoadingPriority { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Returns the type of Internet reachability currently possible on the device.</para>
    /// </summary>
    public static extern NetworkReachability internetReachability { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns false if application is altered in any way after it was built.</para>
    /// </summary>
    public static extern bool genuine { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns true if application integrity can be confirmed.</para>
    /// </summary>
    public static extern bool genuineCheckAvailable { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal static extern bool submitAnalytics { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Checks whether splash screen is being shown.</para>
    /// </summary>
    public static extern bool isShowingSplashScreen { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The level index that was last loaded (Read Only).</para>
    /// </summary>
    [Obsolete("Use SceneManager to determine what scenes have been loaded")]
    public static int loadedLevel
    {
      get
      {
        return SceneManager.GetActiveScene().buildIndex;
      }
    }

    /// <summary>
    ///   <para>The name of the level that was last loaded (Read Only).</para>
    /// </summary>
    [Obsolete("Use SceneManager to determine what scenes have been loaded")]
    public static string loadedLevelName
    {
      get
      {
        return SceneManager.GetActiveScene().name;
      }
    }

    [Obsolete("absoluteUrl is deprecated. Please use absoluteURL instead (UnityUpgradable) -> absoluteURL", true)]
    public static string absoluteUrl
    {
      get
      {
        return Application.absoluteURL;
      }
    }

    public static event Application.LogCallback logMessageReceived
    {
      add
      {
        Application.s_LogCallbackHandler += value;
        Application.SetLogCallbackDefined(true);
      }
      remove
      {
        Application.s_LogCallbackHandler -= value;
      }
    }

    public static event Application.LogCallback logMessageReceivedThreaded
    {
      add
      {
        Application.s_LogCallbackHandlerThreaded += value;
        Application.SetLogCallbackDefined(true);
      }
      remove
      {
        Application.s_LogCallbackHandlerThreaded -= value;
      }
    }

    /// <summary>
    ///   <para>Quits the player application.</para>
    /// </summary>
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Quit();

    /// <summary>
    ///   <para>Cancels quitting the application. This is useful for showing a splash screen at the end of a game.</para>
    /// </summary>
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CancelQuit();

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern float GetStreamProgressForLevelByName(string levelName);

    /// <summary>
    ///   <para>How far has the download progressed? [0...1].</para>
    /// </summary>
    /// <param name="levelIndex"></param>
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float GetStreamProgressForLevel(int levelIndex);

    /// <summary>
    ///   <para>How far has the download progressed? [0...1].</para>
    /// </summary>
    /// <param name="levelName"></param>
    public static float GetStreamProgressForLevel(string levelName)
    {
      return Application.GetStreamProgressForLevelByName(levelName);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool CanStreamedLevelBeLoadedByName(string levelName);

    /// <summary>
    ///   <para>Can the streamed level be loaded?</para>
    /// </summary>
    /// <param name="levelIndex"></param>
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool CanStreamedLevelBeLoaded(int levelIndex);

    /// <summary>
    ///   <para>Can the streamed level be loaded?</para>
    /// </summary>
    /// <param name="levelName"></param>
    public static bool CanStreamedLevelBeLoaded(string levelName)
    {
      return Application.CanStreamedLevelBeLoadedByName(levelName);
    }

    /// <summary>
    ///   <para>Captures a screenshot at path filename as a PNG file.</para>
    /// </summary>
    /// <param name="filename">Pathname to save the screenshot file to.</param>
    /// <param name="superSize">Factor by which to increase resolution.</param>
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CaptureScreenshot(string filename, [DefaultValue("0")] int superSize);

    /// <summary>
    ///   <para>Captures a screenshot at path filename as a PNG file.</para>
    /// </summary>
    /// <param name="filename">Pathname to save the screenshot file to.</param>
    /// <param name="superSize">Factor by which to increase resolution.</param>
    [ExcludeFromDocs]
    public static void CaptureScreenshot(string filename)
    {
      int superSize = 0;
      Application.CaptureScreenshot(filename, superSize);
    }

    /// <summary>
    ///   <para>Is Unity activated with the Pro license?</para>
    /// </summary>
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasProLicense();

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool HasAdvancedLicense();

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool HasARGV(string name);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetValueForARGV(string name);

    [Obsolete("Use Object.DontDestroyOnLoad instead")]
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DontDestroyOnLoad(Object mono);

    private static string ObjectToJSString(object o)
    {
      if (o == null)
        return "null";
      if (o is string)
        return 34.ToString() + o.ToString().Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r").Replace("\0", string.Empty).Replace("\x2028", string.Empty).Replace("\x2029", string.Empty) + (object) '"';
      if (o is int || o is short || (o is uint || o is ushort) || o is byte)
        return o.ToString();
      if (o is float)
      {
        NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
        return ((float) o).ToString((IFormatProvider) numberFormat);
      }
      if (o is double)
      {
        NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
        return ((double) o).ToString((IFormatProvider) numberFormat);
      }
      if (o is char)
      {
        if ((int) (char) o == 34)
          return "\"\\\"\"";
        return 34.ToString() + o.ToString() + (object) '"';
      }
      if (!(o is IList))
        return Application.ObjectToJSString((object) o.ToString());
      IList list = (IList) o;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("new Array(");
      int count = list.Count;
      for (int index = 0; index < count; ++index)
      {
        if (index != 0)
          stringBuilder.Append(", ");
        stringBuilder.Append(Application.ObjectToJSString(list[index]));
      }
      stringBuilder.Append(")");
      return stringBuilder.ToString();
    }

    /// <summary>
    ///   <para>Calls a function in the containing web page (Web Player only).</para>
    /// </summary>
    /// <param name="functionName"></param>
    /// <param name="args"></param>
    public static void ExternalCall(string functionName, params object[] args)
    {
      Application.Internal_ExternalCall(Application.BuildInvocationForArguments(functionName, args));
    }

    private static string BuildInvocationForArguments(string functionName, params object[] args)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(functionName);
      stringBuilder.Append('(');
      int length = args.Length;
      for (int index = 0; index < length; ++index)
      {
        if (index != 0)
          stringBuilder.Append(", ");
        stringBuilder.Append(Application.ObjectToJSString(args[index]));
      }
      stringBuilder.Append(')');
      stringBuilder.Append(';');
      return stringBuilder.ToString();
    }

    /// <summary>
    ///   <para>Evaluates script function in the containing web page.</para>
    /// </summary>
    /// <param name="script">The Javascript function to call.</param>
    public static void ExternalEval(string script)
    {
      if (script.Length > 0 && (int) script[script.Length - 1] != 59)
        script += (string) (object) ';';
      Application.Internal_ExternalCall(script);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_ExternalCall(string script);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int GetBuildUnityVersion();

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int GetNumericUnityVersion(string version);

    internal static void InvokeOnAdvertisingIdentifierCallback(string advertisingId, bool trackingEnabled)
    {
      if (Application.OnAdvertisingIdentifierCallback == null)
        return;
      Application.OnAdvertisingIdentifierCallback(advertisingId, trackingEnabled, string.Empty);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool RequestAdvertisingIdentifierAsync(Application.AdvertisingIdentifierCallback delegateMethod);

    /// <summary>
    ///   <para>Opens the url in a browser.</para>
    /// </summary>
    /// <param name="url"></param>
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void OpenURL(string url);

    [Obsolete("For internal use only")]
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void ForceCrash(int mode);

    [RequiredByNativeCode]
    private static void CallLogCallback(string logString, string stackTrace, LogType type, bool invokedOnMainThread)
    {
      if (invokedOnMainThread)
      {
        Application.LogCallback logCallbackHandler = Application.s_LogCallbackHandler;
        if (logCallbackHandler != null)
          logCallbackHandler(logString, stackTrace, type);
      }
      Application.LogCallback callbackHandlerThreaded = Application.s_LogCallbackHandlerThreaded;
      if (callbackHandlerThreaded == null)
        return;
      callbackHandlerThreaded(logString, stackTrace, type);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetLogCallbackDefined(bool defined);

    /// <summary>
    ///   <para>Request authorization to use the webcam or microphone in the Web Player.</para>
    /// </summary>
    /// <param name="mode"></param>
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern AsyncOperation RequestUserAuthorization(UserAuthorization mode);

    /// <summary>
    ///   <para>Check if the user has authorized use of the webcam or microphone in the Web Player.</para>
    /// </summary>
    /// <param name="mode"></param>
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasUserAuthorization(UserAuthorization mode);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ReplyToUserAuthorizationRequest(bool reply, [DefaultValue("false")] bool remember);

    [ExcludeFromDocs]
    internal static void ReplyToUserAuthorizationRequest(bool reply)
    {
      bool remember = false;
      Application.ReplyToUserAuthorizationRequest(reply, remember);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int GetUserAuthorizationRequestMode_Internal();

    internal static UserAuthorization GetUserAuthorizationRequestMode()
    {
      return (UserAuthorization) Application.GetUserAuthorizationRequestMode_Internal();
    }

    [Obsolete("Application.RegisterLogCallback is deprecated. Use Application.logMessageReceived instead.")]
    public static void RegisterLogCallback(Application.LogCallback handler)
    {
      Application.RegisterLogCallback(handler, false);
    }

    [Obsolete("Application.RegisterLogCallbackThreaded is deprecated. Use Application.logMessageReceivedThreaded instead.")]
    public static void RegisterLogCallbackThreaded(Application.LogCallback handler)
    {
      Application.RegisterLogCallback(handler, true);
    }

    private static void RegisterLogCallback(Application.LogCallback handler, bool threaded)
    {
      if (Application.s_RegisterLogCallbackDeprecated != null)
      {
        Application.logMessageReceived -= Application.s_RegisterLogCallbackDeprecated;
        Application.logMessageReceivedThreaded -= Application.s_RegisterLogCallbackDeprecated;
      }
      Application.s_RegisterLogCallbackDeprecated = handler;
      if (handler == null)
        return;
      if (threaded)
        Application.logMessageReceivedThreaded += handler;
      else
        Application.logMessageReceived += handler;
    }

    /// <summary>
    ///   <para>Loads the level by its name or index.</para>
    /// </summary>
    /// <param name="index">The level to load.</param>
    /// <param name="name">The name of the level to load.</param>
    [Obsolete("Use SceneManager.LoadScene")]
    public static void LoadLevel(int index)
    {
      SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    /// <summary>
    ///   <para>Loads the level by its name or index.</para>
    /// </summary>
    /// <param name="index">The level to load.</param>
    /// <param name="name">The name of the level to load.</param>
    [Obsolete("Use SceneManager.LoadScene")]
    public static void LoadLevel(string name)
    {
      SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    /// <summary>
    ///   <para>Loads a level additively.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="name"></param>
    [Obsolete("Use SceneManager.LoadScene")]
    public static void LoadLevelAdditive(int index)
    {
      SceneManager.LoadScene(index, LoadSceneMode.Additive);
    }

    /// <summary>
    ///   <para>Loads a level additively.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="name"></param>
    [Obsolete("Use SceneManager.LoadScene")]
    public static void LoadLevelAdditive(string name)
    {
      SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    /// <summary>
    ///   <para>Loads the level asynchronously in the background.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="levelName"></param>
    [Obsolete("Use SceneManager.LoadSceneAsync")]
    public static AsyncOperation LoadLevelAsync(int index)
    {
      return SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
    }

    /// <summary>
    ///   <para>Loads the level asynchronously in the background.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="levelName"></param>
    [Obsolete("Use SceneManager.LoadSceneAsync")]
    public static AsyncOperation LoadLevelAsync(string levelName)
    {
      return SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
    }

    /// <summary>
    ///   <para>Loads the level additively and asynchronously in the background.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="levelName"></param>
    [Obsolete("Use SceneManager.LoadSceneAsync")]
    public static AsyncOperation LoadLevelAdditiveAsync(int index)
    {
      return SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    }

    /// <summary>
    ///   <para>Loads the level additively and asynchronously in the background.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="levelName"></param>
    [Obsolete("Use SceneManager.LoadSceneAsync")]
    public static AsyncOperation LoadLevelAdditiveAsync(string levelName)
    {
      return SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
    }

    /// <summary>
    ///   <para>Unloads all GameObject associated with the given scene. Note that assets are currently not unloaded, in order to free up asset memory call Resources.UnloadAllUnusedAssets.</para>
    /// </summary>
    /// <param name="index">Index of the scene in the PlayerSettings to unload.</param>
    /// <param name="scenePath">Name of the scene to Unload.</param>
    /// <returns>
    ///   <para>Return true if the scene is unloaded.</para>
    /// </returns>
    [Obsolete("Use SceneManager.UnloadScene")]
    public static bool UnloadLevel(int index)
    {
      return SceneManager.UnloadScene(index);
    }

    /// <summary>
    ///   <para>Unloads all GameObject associated with the given scene. Note that assets are currently not unloaded, in order to free up asset memory call Resources.UnloadAllUnusedAssets.</para>
    /// </summary>
    /// <param name="index">Index of the scene in the PlayerSettings to unload.</param>
    /// <param name="scenePath">Name of the scene to Unload.</param>
    /// <returns>
    ///   <para>Return true if the scene is unloaded.</para>
    /// </returns>
    [Obsolete("Use SceneManager.UnloadScene")]
    public static bool UnloadLevel(string scenePath)
    {
      return SceneManager.UnloadScene(scenePath);
    }

    /// <summary>
    ///   <para>Delegate method for fetching advertising ID.</para>
    /// </summary>
    /// <param name="advertisingId">Advertising ID.</param>
    /// <param name="trackingEnabled">Indicates whether user has chosen to limit ad tracking.</param>
    /// <param name="errorMsg">Error message.</param>
    public delegate void AdvertisingIdentifierCallback(string advertisingId, bool trackingEnabled, string errorMsg);

    /// <summary>
    ///   <para>Use this delegate type with Application.logMessageReceived or Application.logMessageReceivedThreaded to monitor what gets logged.</para>
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="stackTrace"></param>
    /// <param name="type"></param>
    public delegate void LogCallback(string condition, string stackTrace, LogType type);
  }
}
