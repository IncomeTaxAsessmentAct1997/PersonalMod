using FMOD;
using FMODUnity;
using Nautilus.Handlers;
using Nautilus.Utility;
using UnityEngine;

namespace PersonalMod
{
    internal class AudioRegister
    {
        public const MODE k2DSoundModes = MODE.DEFAULT | MODE._2D | MODE.ACCURATETIME;
        public const MODE kStreamSoundModes = k2DSoundModes | MODE.CREATESTREAM;

        private static Sound sound;

        internal static void RegisterAudio(AssetBundle bundle)
        {
            try
            {
                AudioClip clip = bundle.LoadAsset<AudioClip>("BeyondTheSea");
                if (clip != null)
                {
                    EndMusic(clip, "BeyondTheSea");
                    Plugin.Logger.LogInfo("Audio clip 'BeyondTheSea' loaded successfully.");
                }
            }
            catch (System.Exception ex)
            {
                Plugin.Logger.LogError($"Exception occurred while loading audio clip: {ex.Message}");
                Plugin.Logger.LogError(ex.StackTrace);
            }
        }
    }
}
