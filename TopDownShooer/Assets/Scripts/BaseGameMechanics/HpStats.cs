using UnityEngine;
public abstract class HpStats : MonoBehaviour
{
    public int maxHp { get; protected set; }
    public float hp { get; protected set; }

    public abstract void TakeDamage(Damage damage);
    public abstract void Heal(Heal heal);
}
