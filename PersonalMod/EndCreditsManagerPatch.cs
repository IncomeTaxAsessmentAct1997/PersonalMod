using HarmonyLib;
using UnityEngine;
using FMODUnity;
using Nautilus.Handlers;
using FMOD;
using UnityEngine.EventSystems;

namespace PersonalMod
{
    [HarmonyPatch(typeof(EndCreditsManager))]
    internal class EndCreditsManagerPatch
    {
        private static Channel customChannel;
        public FMOD_CustomEmitter endMusic;
        private static bool hasPlayed = false;
        public float scrollSpeed;

        [HarmonyPatch(nameof(EndCreditsManager.OnLateUpdate))]
        [HarmonyPrefix]
        public static bool OnLateUpdate_Prefix(EndCreditsManager __instance)
        {
            UnityEngine.Debug.Log("Patched method executed.");

            __instance.scrollSpeed = 105f;

            var eventInstance = __instance.endMusic.GetEventInstance();
            eventInstance.setVolume(0f);

            if (!hasPlayed)
            {
                CustomSoundHandler.TryPlayCustomSound("BeyondTheSea", out customChannel);
                hasPlayed = true;
            }

            if (__instance.phase == EndCreditsManager.Phase.End && customChannel.hasHandle())
            {
                customChannel.stop();
                hasPlayed = false;
            }

            return true;
        }

        [HarmonyPatch(nameof(EndCreditsManager.OnScroll))]
        [HarmonyPrefix]
        public static bool OnScroll_Prefix(PointerEventData eventData)
        {
            return false;
        }
    }
}
