using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenAttacks : MonoBehaviour
{
    KrakenAggro aggro;

    private enum KrakenAttackNames
    {
        Smash,
        RockBoat,
        Swipe,
        Throw
    }

    KrakenAttackNames lastAttack;

    public bool doKrakenAttack                = false;
    public bool swipeSuccess                  = false;
    public bool attackReady                   = true;
    public bool drownPlayer                   = false;
    private bool attackMissed                 = false;

    private float krakenChanceToDrownPlayer   = 0f;

    public float krakenAttackWarning          = 0.5f;
    private float delayNextAttack              = 0.0f;
    public float krakenAttackForceMin         = 0.1f;
    public float krakenAttackForceMax         = 1.0f;

    public float krakenAttackForce;

    private int increaseKrakenAggroOnMiss     = 0;

    public int selectAttack;
    public int krakenAttackPlayerDamage;
    public int krakenAttackBoatDamage;
    
    private float krakenAttackSpeedMin        = 1.0f;
    private float krakenAttackSpeedMax        = 2.0f;
    private float krakenModifier = 0f;

    public float krakenAttackSpeedMultiplier;

    void Start()
    {
        aggro = GetComponent<KrakenAggro>();

        krakenAttackForce = krakenAttackForceMin;
        krakenAttackSpeedMultiplier = krakenAttackSpeedMin;
    }


    // pass true to this function to set the attack type and change the related variables.
    public void SetKrakenAttack(bool doAttack)
    {
        if (doAttack && attackReady)
        {
            selectAttack = Random.Range(1,100);

            if (KrakenAggro.krakenAggroLevel == KrakenAggro.AggroStates.Curious)
            {
                SmashAttack();
            }
            else if (KrakenAggro.krakenAggroLevel == KrakenAggro.AggroStates.Enraged)
            {
                if (selectAttack > 80)
                {
                    RockTheBoat();
                }
                else
                {
                    SmashAttack();
                }
            }
            else if (KrakenAggro.krakenAggroLevel == KrakenAggro.AggroStates.Frenzied)
            {
                if (selectAttack >= 81)
                {
                    SwipeAttack();
                }
                else if (RangeExtension.Between(selectAttack,71,80))
                {
                    RockTheBoat();
                }
                else
                {
                    SmashAttack();
                }
            }
        }
    }


    // if an attack hits a player/crew member, pass True to this. If it misses, pass False
    public void KrakenAttackSuccess(bool success)
    {
        if (success)
        {
            attackMissed = false;

            // did the attack Drown the player/crew member, killing them instantly?
            int checkIfDrowned = Random.Range(1,100);
            if (checkIfDrowned >= 96)
            {
                drownPlayer = true;
            }
            

            // call the ThrowAttack method if a Swipe attack was successful during the final AggroState "Wrathful"
            if (lastAttack == KrakenAttackNames.Swipe && KrakenAggro.krakenAggroLevel == KrakenAggro.AggroStates.Wrathful)
            {
                attackReady = true;

                int addThrow = Random.Range(1,100);
                if (addThrow >= 91)
                {
                    ThrowAttack();
                }
            }
        }
        else
        {
            // used to add Aggro to the Kraken whenever it misses certain attacks.
            attackMissed = true;
        }
    }

    private void KrakenModifier()
    {
        /// Increase maximum force based on krakenAggroLevel ///
        
        if (KrakenAggro.krakenAggroLevel == KrakenAggro.AggroStates.Frenzied)
        {
            krakenModifier = Random.Range(0.3f,0.7f);
        }
        else if (KrakenAggro.krakenAggroLevel == KrakenAggro.AggroStates.Wrathful)
        {
            krakenModifier = Random.Range(0.5f,0.9f);
        }
    }


    ///  Attacks defined here ///

    private void SmashAttack()
    {
        krakenAttackWarning         = 0.5f;
        krakenAttackPlayerDamage    = 15;
        krakenAttackBoatDamage      = 10;

        krakenAttackForce           = 0.1f;  //// currently not used for this attack

        increaseKrakenAggroOnMiss = 1;

        krakenAttackSpeedMultiplier = 1.0f + krakenModifier;
        krakenChanceToDrownPlayer   = 0f;    //// currently not used for this attack

        attackReady = false;
        delayNextAttack             = 1.0f;

        lastAttack = KrakenAttackNames.Smash;
    }

    private void RockTheBoat()
    {
        krakenAttackWarning = 2.0f;
        krakenAttackPlayerDamage = 5;
        krakenAttackBoatDamage = 20;
        
        /// start of AttackForce section ///
        krakenAttackForce = 0.1f + krakenModifier;
        Mathf.Clamp(krakenAttackForce, krakenAttackForceMin,krakenAttackForceMax);
        /// end of AttackForce section ///

        increaseKrakenAggroOnMiss = 0;  /// currently not used for this attack - assumed to never miss

        krakenAttackSpeedMultiplier = 1.0f;  //// currently not used for this attack

        //// We need to implement a bool from Player/NPC script "Player within range of edge of boat"  ////
        krakenChanceToDrownPlayer = 0.5f;    //// only if crew in danger zone!               

        attackReady = false;
        delayNextAttack = 3.0f;

        lastAttack = KrakenAttackNames.RockBoat;
    }

    private void SwipeAttack()
    {
        krakenAttackWarning = 1.0f;
        krakenAttackPlayerDamage = 10;
        krakenAttackBoatDamage = 5;

        krakenAttackForce = 0.1f;  //// currently not used for this attack

        increaseKrakenAggroOnMiss = 3;

        krakenAttackSpeedMultiplier = 1.0f;  //// currently not used for this attack
        krakenChanceToDrownPlayer = 0.05f;   

        attackReady = false;
        delayNextAttack = 4.0f;

        lastAttack = KrakenAttackNames.Swipe;
    }


    // only called if Swipe attack is successful 
    private void ThrowAttack()
    {
        krakenAttackWarning = 1.0f;
        krakenAttackPlayerDamage = 50;
        krakenAttackBoatDamage = 0;

        krakenAttackForce = 0.1f;  //// currently not used for this attack

        increaseKrakenAggroOnMiss = 0; //// currently not used for this attack

        krakenAttackSpeedMultiplier = 1.0f;  //// currently not used for this attack
        krakenChanceToDrownPlayer = 0.05f;   

        attackReady = false;
        delayNextAttack = 4.0f;

        lastAttack = KrakenAttackNames.Throw;
    }

    /// End of Attack definitions ///
    


    void Update()
    {
        // Check to see if Kraken is in the middle of its warning or delaying next attack.
        delayNextAttack -= Time.deltaTime;
        krakenAttackWarning -= Time.deltaTime;

        if (delayNextAttack <= 0f && krakenAttackWarning <= 0f)
        {
            attackReady = true;
            delayNextAttack = 0f;
            krakenAttackWarning = 0f;
        }

        // pass change in Aggro to KrakenAggro if attack misses
        if (attackMissed == true)
        {
            aggro.ChangeKrakenAggro(increaseKrakenAggroOnMiss);

            attackMissed = false;
        }

        drownPlayer = false;
        krakenChanceToDrownPlayer = 0f;
    }
}

/// <summary>
/*      
        1) SetKrakenAttack(bool doAttack)      pass True to this to trigger an attack
        2) KrakenAttackSuccess(bool success)   pass True to this if the attack hits a player/crew member.  Currently you  --MUST--  pass False to it if the attack misses!

       
        krakenAttackWarning                     time between triggering the attack and the actual attack. Pre-attack warning animation.
        krakenAttackPlayerDamage                damage to read out to the player/crew member if the attack succeeds.
        krakenAttackBoatDamage                  damage to read out to the boat if the attack succeeds

        krakenAttackForce                       from the GDD.  Kraken Rocking the Boat was proposed to send things flying with physics. This might be out of scope now?

        increaseKrakenAggroOnMiss               by passing False to KrakenAttackSuccess() , this will trigger a small increase to the Kraken's aggro. Kraken gets frustrated!

        krakenModifier                          increases   krakenAttackForce  and/or   krakenAttackSpeed  when KrakenAggro.krakenAggroStates is "Frenzied" or "Wrathful"
        krakenChanceToDrownPlayer               small chance to drown the player/crew member, killing them instantly.

        bool drownPlayer                        if this becomes true, the player/crew member should be drowned and killed instantly by the attack.

        attackReady                             set to True if the krakenAtackWarning and delayNextAttack countdowns are both at 0 seconds (or less)
        delayNextAttack                         delay between attacks for animations and The Player to take stock, prep actions, etc.
*/
/// </summary>