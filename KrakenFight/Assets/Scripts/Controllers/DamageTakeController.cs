using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageTakeController : MonoBehaviour
{
    public UnityEvent OnDamageTake;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I took damage " + collision.gameObject.name);
        OnDamageTake?.Invoke();
    }
}
