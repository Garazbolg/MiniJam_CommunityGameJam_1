using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class IntEvent : UnityEvent<int> { }
public class DamageTakeController : MonoBehaviour
{
    public IntEvent OnDamageTake;
    public void DealDamage(int amount)
    {
        OnDamageTake?.Invoke(amount);
    }
}
