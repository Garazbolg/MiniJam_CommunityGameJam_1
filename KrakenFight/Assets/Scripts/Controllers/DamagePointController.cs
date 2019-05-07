using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameObjectEvent: UnityEvent<GameObject> { }
public class DamagePointController : MonoBehaviour
{
    public GameObjectEvent OnHitDetected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHitDetected?.Invoke(collision.gameObject);
    }
}
