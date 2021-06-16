using UnityEngine;

namespace Isshi777
{
    public class VibrationManagerSample : MonoBehaviour
    {
        public void OnclickVeryShort()
        {
            VibrationManager.PlayVibration(VibrationManager.VibrationType.VeryShort);
        }

        public void OnclickShort()
        {
            VibrationManager.PlayVibration(VibrationManager.VibrationType.Short);
        }

        public void OnclickMedium()
        {
            VibrationManager.PlayVibration(VibrationManager.VibrationType.Medium);
        }

        public void OnclickLong()
        {
            VibrationManager.PlayVibration(VibrationManager.VibrationType.Long);
        }

        public void OnclickUnity()
        {
            Handheld.Vibrate();
        }
    }
}
