using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Isshi777
{
    /// <summary>
    /// バイブレーションの管理クラス
    /// </summary>
    public static class VibrationManager
    {
        /// <summary>
        /// バイブレーションのタイプ
        /// </summary>
        public enum VibrationType
        {
            VeryShort,
            Short,
            Medium,
            Long,
        }

        /// <summary>
        /// バイブレーション実行
        /// </summary>
        /// <param name="type">バイブレーションのタイプ</param>
        public static void PlayVibration(VibrationType type)
        {
#if UNITY_ANDROID && !UNITY_EDITOR

        long ms = VibrationTypeDic[type];
        vibrator.Call("vibrate", ms);

#elif UNITY_IOS && !UNITY_EDITOR

        int id = VibrationTypeDic[type];
        _playSystemSound(id);

#endif
        }

#if UNITY_ANDROID && !UNITY_EDITOR

        // ネイティブクラス
        public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

        //バイブレーションのタイプと時間（ミリ秒）
        private static readonly Dictionary<VibrationType, long> VibrationTypeDic = new Dictionary<VibrationType, long>()
        {
            { VibrationType.VeryShort,  100 },
            { VibrationType.Short,      300 },
            { VibrationType.Medium,     500 },
            { VibrationType.Long,       900 },
        };

#elif UNITY_IOS && !UNITY_EDITOR

        // DLL
        [DllImport ("__Internal")]
        static extern void _playSystemSound(int n);

        //バイブレーションのタイプとiOSのサウンドID
        private static readonly Dictionary<VibrationType, int> VibrationTypeDic = new Dictionary<VibrationType, int>()
        {
            { VibrationType.VeryShort,  1519 },
            { VibrationType.Short,      1519 },
            { VibrationType.Medium,     1520 },
            { VibrationType.Long,       1521 },
        };

#endif
    }
}