using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public string takeDamage;
    //public string healing;
    //public int unitLevel;

    public int damage;
    //public int heal;

    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int dmg = 10)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
