using System.Collections;
using UnityEngine;

public abstract class Weapon
{
    public WeaponModel weaponModel { get; protected set; }

    public abstract void Shoot(RaycastHit2D hitInfo);
    public abstract IEnumerator shootVisualEffects(RaycastHit2D hitInfo, Transform firePoint);

    public abstract void Reload();
    public abstract IEnumerator reloadVisualEffects(Transform position);

}
