using UnityEngine;

namespace Misc
{
    public static class MonoBehaviourExtenstion
    {
        public static void Enable(this MonoBehaviour obj) =>
            obj.enabled = true;

        public static void Disable(this MonoBehaviour obj) =>
            obj.enabled = false;

        public static void TurnOn(this MonoBehaviour obj) =>
            obj.gameObject.SetActive(true);

        public static void TurnOff(this MonoBehaviour obj) =>
            obj.gameObject.SetActive(false);
    }
}