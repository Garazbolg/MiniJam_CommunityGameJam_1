using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private GameObjectPool cannonBallPool;
    [SerializeField] private float force;

    private void Start()
    {
        ShootCannonBall();
    }

    public void ShootCannonBall()
    {
        GameObject cannonBallObj = cannonBallPool.Get();
        cannonBallObj.GetComponent<CannonBallController>().LaunchBall(this.transform.up * force, this.transform.position);
        cannonBallObj.SetActive(true);
    }
}
