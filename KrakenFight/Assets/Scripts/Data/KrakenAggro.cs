using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenAggro : MonoBehaviour
{
    public enum AggroStates
    {
        Unseen,
        Nearby,
        Curious,
        Enraged,
        Frenzied,
        Wrathful
    }

    // How aggressive is the Kraken; can be changed by altering  int KrakenAggro.changeToKrakenAggro
    public static int krakenCurrentAggro            = 0;
    // string name from enum for different levels of Aggressiveness
    public static AggroStates krakenAggroLevel      = AggroStates.Unseen;

    public string showKrakenAggroLevel;

    // Ability to cooldown krakenAggro every X seconds
    // public float krakenAggroDecayTime               = 180.0f;
    // public bool krakenAggroDecayRunning             = true;

    private void Start()
    {
        // StartCoroutine(krakenAggroDecay(krakenAggroDecayTime));
    }

    // returns string name for different levels of Aggressiveness
    public void SetKrakenAggroLevel()
    {
        if (RangeExtension.Between(krakenCurrentAggro,0,9))
        {
            // HUD for Kraken Aggro - blank
            krakenAggroLevel = AggroStates.Unseen; 
        }        
        else if (RangeExtension.Between(krakenCurrentAggro,10,19))
        {
            // HUD for Kraken Aggro - 'Shadow'
            krakenAggroLevel = AggroStates.Nearby; 
        }      
        else if (RangeExtension.Between(krakenCurrentAggro,20,39))
        {
            // HUD for Kraken Aggro - Green & "peeking out" (i.e. top half)
            krakenAggroLevel = AggroStates.Curious; 
        }     
        else if (RangeExtension.Between(krakenCurrentAggro,40,59))
        {
            // HUD for Kraken Aggro - Green & fully visible
            krakenAggroLevel = AggroStates.Enraged; 
        }     
        else if (RangeExtension.Between(krakenCurrentAggro,60,89))
        {
            // HUD for Kraken Aggro - Orange
            krakenAggroLevel = AggroStates.Frenzied; 
        }    
        else if (RangeExtension.Between(krakenCurrentAggro,90,100))
        {
            // HUD for Kraken Aggro - Red
            krakenAggroLevel = AggroStates.Wrathful; 
        }

        Debug.Log("Kraken Aggro State = " + krakenAggroLevel);
    }


    // pass an Int value to this function to change the Kraken's Aggro
    public void ChangeKrakenAggro(int amount)
    {
        krakenCurrentAggro += amount;
        krakenCurrentAggro = Mathf.Clamp(krakenCurrentAggro,0,100);
    }

/*
    private IEnumerator krakenAggroDecay(float waitTime)
    {
        while (krakenAggroDecayRunning)
        {
            krakenCurrentAggro -= 1;
            yield return new WaitForSeconds(waitTime);
        }
    }
*/


    void Update()
    {
        ChangeKrakenAggro(0);
        SetKrakenAggroLevel();
    }
}
