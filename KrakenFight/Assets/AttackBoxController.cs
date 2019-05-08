using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxController : MonoBehaviour
{
    [SerializeField] private GameObject damagePoint;

    public void ActivateDamagePoint(int state)
    {
        damagePoint.SetActive(state==1);
    }
}
