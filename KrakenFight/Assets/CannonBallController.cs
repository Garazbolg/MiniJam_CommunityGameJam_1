using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class CannonBallController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private SendToPool sendToPool;
    public UnityEvent OnBallHit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LaunchBall(Vector2 force)
    {
        rb.AddForce(force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnBallHit?.Invoke();
        sendToPool.SendBackToPool();
    }
}
