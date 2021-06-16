using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Isshi777
{
    /// <summary>
    /// �o�C�u���[�V�����̊Ǘ��N���X
    /// </summary>
    public static class VibrationManager
    {
        /// <summary>
        /// �o�C�u���[�V�����̃^�C�v
        /// </summary>
        public enum VibrationType
        {
            VeryShort,
            Short,
            Medium,
            Long,
        }

        /// <summary>
        /// �o�C�u���[�V�������s
        /// </summary>
        /// <param name="type">�o�C�u���[�V�����̃^�C�v</param>
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

        // �l�C�e�B�u�N���X
        public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

        //�o�C�u���[�V�����̃^�C�v�Ǝ��ԁi�~���b�j
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

        //�o�C�u���[�V�����̃^�C�v��iOS�̃T�E���hID
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