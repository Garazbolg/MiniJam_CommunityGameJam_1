using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class CannonBallController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private SendToPool sendToPool;

    [SerializeField] private float travelDistance;
    [SerializeField] private float startSize;
    [SerializeField] private float drag;
    private Collider2D ballCollider;
    private float distanceTravelled;
    private Vector3 lastPosition;

    public UnityEvent OnBallHitObject;
    public UnityEvent OnBallHitWater;
    private void Awake()
    {
        ballCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        lastPosition = this.transform.position;
    }

    private void OnEnable()
    {
        lastPosition = this.transform.position;
        distanceTravelled = 0;
    }

    public void LaunchBall(Vector2 force, Vector3 pos)
    {
        rb.AddForce(force);
        lastPosition = pos;
        this.transform.position = pos;
    }

    private void Update()
    {
        distanceTravelled += (lastPosition - this.transform.position).magnitude;

        if(distanceTravelled >= travelDistance)
        {
            OnBallHitWater?.Invoke();
            sendToPool.SendBackToPool();
        }
        rb.AddForce(rb.velocity * drag);
        this.transform.localScale = Vector3.one * ((travelDistance - distanceTravelled) / travelDistance) * startSize ;
        if(this.transform.localScale.magnitude < 0.2f)
        {
            ballCollider.enabled = false;
        }
        lastPosition = this.transform.position;
    }

    private void OnDisable()
    {
        this.transform.localScale = Vector3.one;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnBallHitObject?.Invoke();
        DamageTakeController dpCont = collision.GetComponent<DamageTakeController>();
        if (dpCont)
        {
            dpCont.DealDamage(1);
        }
        sendToPool.SendBackToPool();
    }
}
