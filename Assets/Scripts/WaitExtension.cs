using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Assets.Scripts
{
    public static class WaitExtension
    {
        #region Public methods

        public static void Wait(this MonoBehaviour mono, float delay, UnityAction action)
        {
            mono.StartCoroutine(ExecuteAlways(delay, action));
        }

        #endregion


        #region Private methods

        private static IEnumerator ExecuteAlways(float delay, UnityAction action)
        {
            yield return new WaitForSecondsRealtime(delay);
            action.Invoke();
            yield break;
        }

        #endregion
    }
}