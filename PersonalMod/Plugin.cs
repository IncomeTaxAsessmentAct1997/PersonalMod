using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using UnityEngine;

namespace PersonalMod;

[BepInPlugin("com.incometaxassessmentact1997.personalmod", "PersonalMod", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    public new static ManualLogSource Logger { get; private set; }

    private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

    public static string AssetsFolderPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");

    private void Awake()
    {
        Logger = base.Logger;
        Harmony.CreateAndPatchAll(Assembly, "com.incometaxassessmentact1997.personalmod");
        Logger.LogInfo("Plugin com.incometaxassessmentact1997.personalmod is loaded!");

        try
        {
            string bundlePath = Path.Combine(AssetsFolderPath, "beyondthesea");
            AssetBundle bundle = AssetBundle.LoadFromFile(bundlePath);
            if (bundle == null)
            {
                Logger.LogError("Failed to load AssetBundle!");
            }
            else
            {
                Logger.LogInfo("AssetBundle loaded successfully.");
                AudioRegister.RegisterAudio(bundle);
            }
        }
        catch (System.Exception ex)
        {
            Logger.LogError($"Exception occurred while loading AssetBundle: {ex.Message}");
            Logger.LogError(ex.StackTrace);
        }
    }
}