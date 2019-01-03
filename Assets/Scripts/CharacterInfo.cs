using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    //Will contain HP, movespeed (needs to be moved over), armor, money?
    //Will have methods for being hit, getting HP, etc
    // Start is called before the first frame update
    public float hp;
    public float maxHp;
    public float maxHpModifier = 1;
    public float armor;
    
    public void TakeHit(float amt)
    {
        //Armor calcs will be done here to reduce damage
        if (amt >= hp)
            Die();
        else
            hp -= amt - armor;
    }

    public void AddHp(float amt)
    {
        if (amt + hp > maxHp * maxHpModifier)
            hp = maxHp * maxHpModifier;
        else
            hp += amt;
    }

    public void Die()
    {
        //Idk yet, play an animation?
        Destroy(gameObject);
    }
}
