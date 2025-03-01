using HarmonyLib;
using UnityEngine;
using System.Reflection;
using FMODUnity;
using System;

namespace PersonalMod
{
    [HarmonyPatch(typeof(EndCreditsManager))]
    internal class Patcher
    {
        public FMOD_CustomEmitter endMusic;

        [HarmonyPatch(nameof(EndCreditsManager.OnLateUpdate))]
        [HarmonyPrefix]
        public static bool OnLateUpdate_Prefix(EndCreditsManager __instance)
        {
            Debug.Log("Patched method executed.");
            __instance.endMusic.Stop();
            return true;
        }
    }
}