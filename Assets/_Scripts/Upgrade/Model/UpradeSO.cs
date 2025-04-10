using System;
using UnityEngine;


public abstract class UpradeSO : ScriptableObject
{
    [field: SerializeField]
    public string upgradeName { get; set; }
    [field: SerializeField, TextArea]
    public string description { get; set; }
    [field: SerializeField]
    public Sprite upgradeIcon { get; set; }
    
}
