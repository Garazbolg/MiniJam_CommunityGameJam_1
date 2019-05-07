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
    AggroStates krakenAggroLevel = (AggroStates)0;
    
    // Change in value to apply to krakenCurrentAggro during Update() - to be used by outside classes?
    public int changeToKrakenAggro          = 0;

 
    // returns string name for different levels of Aggressiveness
    public void CheckKrakenAggroLevel()
    {
        

        if (RangeExtension.Between(krakenCurrentAggro,0,9) == true) { krakenAggroLevel = (AggroStates)0; }        // HUD for Kraken Aggro - blank
        if (RangeExtension.Between(krakenCurrentAggro,10,19) == true) { krakenAggroLevel = (AggroStates)1; }      // HUD for Kraken Aggro - 'Shadow'
        if (RangeExtension.Between(krakenCurrentAggro,20,39) == true) { krakenAggroLevel = (AggroStates)2; }     // HUD for Kraken Aggro - Green & "peeking out" (i.e. top half)
        if (RangeExtension.Between(krakenCurrentAggro,40,59) == true) { krakenAggroLevel = (AggroStates)3; }     // HUD for Kraken Aggro - Green & fully visible
        if (RangeExtension.Between(krakenCurrentAggro,60,89) == true) { krakenAggroLevel = (AggroStates)4; }    // HUD for Kraken Aggro - Orange
        if (RangeExtension.Between(krakenCurrentAggro,90,100) == true) { krakenAggroLevel = (AggroStates)5; }   // HUD for Kraken Aggro - Red

        Debug.Log(krakenAggroLevel);
    }

    void Update()
    {
        krakenCurrentAggro += changeToKrakenAggro;
        krakenCurrentAggro = Mathf.Clamp(krakenCurrentAggro,0,100);

        Debug.Log(krakenCurrentAggro);
        CheckKrakenAggroLevel();
        Debug.Log(krakenAggroLevel);
    }
}
