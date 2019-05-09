using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfterTime : MonoBehaviour
{
    [SerializeField] private float killTime;
    private void Awake()
    {
        Destroy(this.gameObject, killTime);
    }
}
