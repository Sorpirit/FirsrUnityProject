public struct Damage
{
    public float amount { get; private set;}
    public BodyPart bodyPart { get; private set;}

    public Damage(float amount, BodyPart bodyPart) : this()
    {
        this.amount = amount;
        this.bodyPart = bodyPart;
    }
}
