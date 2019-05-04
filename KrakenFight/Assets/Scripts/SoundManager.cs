using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip PlayerAttackSE;
    public AudioClip PlayerAltAttackSE;
    public AudioClip PlayerUseSE;

    public void PlayPlayerAttack()
    {
        AS.clip = PlayerAttackSE;
        AS.Play();
    }
    public void PlayPlayerAltAttack()
    {
        AS.clip = PlayerAltAttackSE;
        AS.Play();
    }
    public void PlayPlayerUse()
    {
        AS.clip = PlayerUseSE;
        AS.Play();
    }

}
