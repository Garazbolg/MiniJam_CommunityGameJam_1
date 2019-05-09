using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public void SpawnParticle(GameObject particle)
    {
        GameObject obj = Instantiate<GameObject>(particle);
        obj.transform.position = this.transform.position;
    }
}
