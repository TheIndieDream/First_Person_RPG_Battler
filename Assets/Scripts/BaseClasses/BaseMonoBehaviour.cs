using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

/// <summary>
/// Classes that inherit from BaseMonoBehaviour nulls out all their references
/// when destroyed, which makes for more efficient garbage collection.
/// </summary>
public class BaseMonoBehaviour : MonoBehaviour
{
    private void OnDestroy()
    {
        foreach (FieldInfo field in GetType().GetFields(BindingFlags.Public |
            BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Type fieldType = field.FieldType;

            if (typeof(IList).IsAssignableFrom(fieldType))
            {
                if (field.GetValue(this) is IList list)
                {
                    list.Clear();
                }
            }

            if (typeof(IDictionary).IsAssignableFrom(fieldType))
            {
                if (field.GetValue(this) is IDictionary dictionary)
                {
                    dictionary.Clear();
                }
            }

            if (!fieldType.IsPrimitive)
            {
                field.SetValue(this, null);
            }
        }
    }
}
