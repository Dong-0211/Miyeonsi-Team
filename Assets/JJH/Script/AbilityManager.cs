using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability
{
    [SerializeField] private uint health;
    public uint Health { get { return health; } set { health = value; } }
    [SerializeField] private uint stress;
    [SerializeField] private uint appearance;
    [SerializeField] private uint sociAbility;
    [SerializeField] private uint morAlity;
    [SerializeField] private uint Intelligence;
    [SerializeField] private uint luck;

    [SerializeField] private uint money;
    public  uint Money { get { return money; } set { money = value; } }

    [SerializeField] private uint likeAbility_A;
    public uint LikeAbility_A { get { return likeAbility_A; } set { likeAbility_A = value; } }

    [SerializeField] private uint likeAbility_B;
    public uint LikeAbility_B { get { return likeAbility_B; } set { likeAbility_B = value; } }
}

[CreateAssetMenu(fileName = "Data", menuName = "Game/GameData")]
public class AbilityManager : ScriptableObject
{
   public Ability abilities = new Ability();
}