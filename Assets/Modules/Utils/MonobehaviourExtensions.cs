using UnityEngine;

namespace SpaceSumo.Utils
{
    public static class MonoBehaviourExtensions
    {
        public static void CheckFieldValue<T>(this MonoBehaviour target, string fieldName, T fieldValue)
        {
            if (fieldValue is null)
            {
                Debug.LogError($"У объекта {target.gameObject.name} поле {fieldName} не было заполнено в инспекторе.");
            }
        }
    }
}