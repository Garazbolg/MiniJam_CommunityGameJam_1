using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum eKrakenFightState { First, Second, Third, Last}
public class KrakenController : MonoBehaviour
{
    [SerializeField] private Animator krakenAnimator;

    [SerializeField] private float minAttackTime;
    [SerializeField] private float maxAttackTime;

    [SerializeField] private eKrakenFightState krakenFightState;

    private float timeLeftTillNextAttack = 0;

    private float timeLeftTillNextMove = 0;

    [SerializeField] private float minMoveTime;
    [SerializeField] private float maxMoveTime;
    [SerializeField] private Transform[] movePositions;
    private bool isMoving;

    [SerializeField] private float movementSpeed;

    public GameObjectEvent OnDamageDealt;
    public void DamageDealth(GameObject obj)
    {
        OnDamageDealt?.Invoke(obj);
    }

    private void Start()
    {
        timeLeftTillNextAttack = TimeTillNextAttack();
        timeLeftTillNextMove = TimeTillNextMove();

        isMoving = false;
    }

    private void Update()
    {
        timeLeftTillNextAttack -= Time.deltaTime;
        if (timeLeftTillNextAttack <= 0)
        {
            RandomAttack();
            timeLeftTillNextAttack = TimeTillNextAttack();
        }
        timeLeftTillNextMove -= Time.deltaTime;
        if (timeLeftTillNextMove <= 0)
        {
            RandomMove();
            timeLeftTillNextMove = TimeTillNextMove();
        }
    }

    private void RandomMove()
    {
        StartCoroutine("Move");
    }

    private IEnumerator Move()
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 targetPosition = movePositions[Random.Range(0, movePositions.Length)].position;

        Vector3 direction = (targetPosition - currentPosition).normalized;
        do
        {
            this.transform.position += direction * Time.deltaTime * movementSpeed;
            yield return new WaitForEndOfFrame();
        } while (Mathf.Pow(this.transform.position.x - targetPosition.x, 2) + 
                Mathf.Pow(this.transform.position.y - targetPosition.y, 2) > 0.1f);
    }

    private void RandomAttack()
    {
        int randomAttack = 0;
        switch (krakenFightState)
        {
            case eKrakenFightState.First:
                // Only does the first attack
                break;
            case eKrakenFightState.Second:
                // Only does the first 2 attacks
                randomAttack = UnityEngine.Random.Range(0, 2);
                break;
            case eKrakenFightState.Third:
                // Does 3 attacks
                randomAttack = UnityEngine.Random.Range(0, 3);
                break;
            case eKrakenFightState.Last:
                // Does only the last 2 attacks
                randomAttack = UnityEngine.Random.Range(1, 3);
                break;
            default:
                break;
        }

        switch (randomAttack)
        {
            case 0:
                Swipe();
                break;
            case 1:
                Smash();
                break;
            case 2:
                RockTheBoat();
                break;
            default:
                break;
        }
    }


    private float TimeTillNextMove()
    {
        return UnityEngine.Random.Range(minMoveTime, maxMoveTime);
    }
    private float TimeTillNextAttack()
    {
        return UnityEngine.Random.Range(minAttackTime, maxAttackTime);
    }

    public void Smash()
    {
        krakenAnimator.SetTrigger("Smash");
    }

    public void RockTheBoat()
    {
        krakenAnimator.SetTrigger("RockTheBoat");
    }

    public void Swipe()
    {
        krakenAnimator.SetTrigger("Swipe");
    }
}
