using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName = "New Crew Member",menuName = "Crew Member",order = 52)]
public class CrewMembers : ScriptableObject
{
    public string crewUniqueID;
    public string crewDisplayName;
    public bool crewIsUpgraded;
    public string crewUpgradesTo;
    public string crewUpgradesFrom;


    public int crewHealth;
    public int moveSpeed;
    public int maxHunger;
    public int maxThirst;
    public int maxMorale;
    public int maxScurvy;
    public int swordDamage;
    public int fixShipAmount;

    // decimal multipliers
    public float reactionSpeed;
    public float cannonAccuracy;
    // //

    public string crewSpecialAbilityOne;
    public string crewSpecialAbilityTwo;
}