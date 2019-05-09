using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenAggro : MonoBehaviour
{
    private enum AggroStates
    {
        Unseen,
        Nearby,
        Curious,
        Enraged,
        Frenzied,
        Wrathful
    };

    // How aggressive is the Kraken; can be changed by altering  int KrakenAggro.changeToKrakenAggro
    public static int krakenCurrentAggro    = 0;
    // string name from enum for different levels of Aggressiveness
    AggroStates krakenAggroLevel = AggroStates.Unseen;
    
    // returns string name for different levels of Aggressiveness
    public void SetKrakenAggroLevel()
    {
        if (RangeExtension.Between(krakenCurrentAggro,0,9))
        {
            krakenAggroLevel = AggroStates.Unseen; // HUD for Kraken Aggro - blank
        }        
        else if (RangeExtension.Between(krakenCurrentAggro,10,19))
        {
            krakenAggroLevel = AggroStates.Nearby; // HUD for Kraken Aggro - 'Shadow'
        }      
        else if (RangeExtension.Between(krakenCurrentAggro,20,39))
        {
            krakenAggroLevel = AggroStates.Curious; // HUD for Kraken Aggro - Green & "peeking out" (i.e. top half)
        }     
        else if (RangeExtension.Between(krakenCurrentAggro,40,59))
        {
            krakenAggroLevel = AggroStates.Enraged; // HUD for Kraken Aggro - Green & fully visible
        }     
        else if (RangeExtension.Between(krakenCurrentAggro,60,89))
        {
            krakenAggroLevel = AggroStates.Frenzied; // HUD for Kraken Aggro - Orange
        }    
        else if (RangeExtension.Between(krakenCurrentAggro,90,100))
        {
            krakenAggroLevel = AggroStates.Wrathful; // HUD for Kraken Aggro - Red
        }

        Debug.Log("Kraken Aggro State = " + krakenAggroLevel);
    }


    // pass an Int value to this function to change the Kraken's Aggro
    public void ChangeKrakenAggro(int amount)
    {
        krakenCurrentAggro += amount;
        krakenCurrentAggro = Mathf.Clamp(krakenCurrentAggro,0,100);
    }

    void Update()
    {
        ChangeKrakenAggro(0);
        SetKrakenAggroLevel();
    }
}
