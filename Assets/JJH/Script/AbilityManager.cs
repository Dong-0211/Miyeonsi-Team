using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability
{
    //health, stress, appearance, morality, intelligence, luck, money, likeAbility_A, likeAbility_B, month, day
    [SerializeField] private uint health;
    public uint Health { get { return health; } set { health = value; } }
    [SerializeField] private uint stress;
    public uint Stress { get { return stress; } set { stress = value; } }
    [SerializeField] private uint appearance;
    public uint Appearance { get { return appearance; } }
    [SerializeField] private uint sociAbility;
    public uint SociAbility { get {  return sociAbility; } set {  sociAbility = value; } }
    [SerializeField] private uint morality;
    public uint Morality { get {  return morality; } set {  morality = value; } }
    [SerializeField] private uint intelligence;
    public uint Intelligence { get { return intelligence; } set { intelligence = value; } }
    [SerializeField] private uint luck;
    public uint Luck { get {  return luck; } set {  luck = value; } }

    [SerializeField] private float money;
    public  float Money { get { return money; } set { money = value; } }

    [SerializeField] private uint likeAbility_A;
    public uint LikeAbility_A { get { return likeAbility_A; } set { likeAbility_A = value; } }

    [SerializeField] private uint likeAbility_B;
    public uint LikeAbility_B { get { return likeAbility_B; } set { likeAbility_B = value; } }

    [SerializeField] private uint month;
    public uint Month { get { return month; } set { month = value; } }

    [SerializeField] private uint day;
    public uint Day { get { return day; } set { day = value; } }

    public void DateCalculation()
    {
        if ((month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) && (day == 31))
        {
            month += 1;
            day = 0;
        }
        else if (month == 4 || month == 6 || month == 9 || month == 11 && (day == 30))
        {
            month += 1;
            day = 0;
        }
        else if(month == 2 && (day == 28))
        {
            month += 1;
            day = 0;
        }
        day += 1;
    }
}

[CreateAssetMenu(fileName = "Data", menuName = "Game/GameData")]
public class AbilityManager : ScriptableObject
{
   public Ability abilities = new Ability();
}