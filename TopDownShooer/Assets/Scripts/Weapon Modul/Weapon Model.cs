public struct WeaponModel
{
    public string name { get; }

    public float damage { get; }
    public float fireRate { get; }
    public float reloadTime { get; }
    public int clip { get; }

    public WeaponModel(string name, float damage, float fireRate, float reloadTime, int clip)
    {
        this.name = name;
        this.damage = damage;
        this.fireRate = fireRate;
        this.reloadTime = reloadTime;
        this.clip = clip;
    }

    
}
