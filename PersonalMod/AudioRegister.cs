using FMOD;
using FMODUnity;
using Nautilus.Handlers;
using Nautilus.Utility;
using UnityEngine;
using static uGUI_ResourceTracker;

namespace PersonalMod
{
    internal class AudioRegister
    {
        public const MODE kStreamSoundModes = MODE.DEFAULT | MODE._2D | MODE.ACCURATETIME;

        internal static void RegisterAudio(AssetBundle bundle)
        {
            AudioClip clip = bundle.LoadAsset<AudioClip>("BeyondTheSea");
            if (clip != null)
            {
                EndMusic(clip, "BeyondTheSea");
                Plugin.Logger.LogInfo("Audio clip 'BeyondTheSea' loaded successfully.");
            }
        }

        public static void EndMusic(AudioClip clip, string soundPath)
        {
            var sound = AudioUtils.CreateSound(clip, kStreamSoundModes);
            CustomSoundHandler.RegisterCustomSound(soundPath, sound, AudioUtils.BusPaths.Music);
        }
    }
}