namespace CombatDomain.Domain;

public class Character
{
    public int Range { get; set; }

    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Level { get; private set; }
    public bool Alive { get; private set; }

    public Character(string nome)
    {
        Name = nome;
        Health = 1000;
        Level = 1;
        Alive = true;
    }

    public void ReceiveDemage(int demage)
    {
        if (demage > Health)
        {
            Health = 0;
            Alive = false;
        }
        else
            Health -= demage;
    }

    public void ReceiveHeal(int heal)
    {
        if (!Alive)
            throw new InvalidOperationException("Não é possível salvar personagem morto.");

        Health += heal;

        if (Health > 1000)
            throw new InvalidOperationException("Só é possível a cura até 1000.");
    }

    public void SetAlive(bool isAlive) => Alive = isAlive;
    
    public void SetLevel(int level) => Level = level;
}