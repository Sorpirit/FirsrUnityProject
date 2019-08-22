using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHpStats : HpStats
{

    [SerializeField] int HP_MAX;
    [SerializeField] GameObject visualEfect;

    private void Awake()
    {
        maxHp = HP_MAX;
        hp = maxHp;
    }

    public override void Heal(Heal heal)
    {
        hp += heal.amount;
        chekIfOverHealed();
    }

    public override void TakeDamage(Damage damage)
    {
        Debug.Log("TakeDam(" + hp + "  -  " + damage.amount + " )" );
        switch (damage.bodyPart)
        {
            case BodyPart.BODY:

                hp -= damage.amount;

                break;
            case BodyPart.HEAD:

                hp -= damage.amount * 1.5f;

                break;
            case BodyPart.ARM:

                hp -= damage.amount * 1.15f;

                break;
            default:

                Debug.LogWarning("No body part bechaviur atacht(" + damage.bodyPart + ")");

                break;
        }

        chekIfDead();
    }

    private void chekIfOverHealed()
    {
        if (hp > maxHp) hp = maxHp;
    }
    private void chekIfDead()
    {
        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        if (visualEfect != null) Instantiate(visualEfect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
