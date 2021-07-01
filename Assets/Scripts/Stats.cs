public class Stats 
{
    public float health;
    public float maxHealth;

    public int level;
    public float attack;
    public float deffense;
    public float spirit;

    public Stats(int level, float maxHealth, float attack, float deffense, float spirit)
    {
        this.level = level;

        this.maxHealth = maxHealth;
        this.health = maxHealth;

        this.attack = attack;
        this.deffense = deffense;
        this.spirit = spirit;
    }

    public Stats Clone()
    {
        return new Stats(this.level, this.maxHealth, this.attack, this.deffense, this.spirit);
    }


}
