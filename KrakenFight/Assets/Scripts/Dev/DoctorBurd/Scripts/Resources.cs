using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]

    [CreateAssetMenu(fileName = "New Resource",menuName = "Resource Item",order = 51)]
    public class Resources : ScriptableObject
    {
        [SerializeField]
        public string resourceName;
        [SerializeField]
        public int resourceBuyCost;
        [SerializeField]
        public int resourceSellCost;
        [SerializeField]
        public int maxInventoryStack;

        [SerializeField]
        public Sprite resourceIcon;
    }