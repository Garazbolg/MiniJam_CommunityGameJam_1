using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]

    [CreateAssetMenu(fileName = "New Resource",menuName = "Resource Item",order = 51)]
    public class Resources : ScriptableObject
    {
        public string resourceName;
        public int resourceBuyCost;
        public int resourceSellCost;
        public int maxInventoryStack;

        public Sprite resourceIcon;
    }