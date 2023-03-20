namespace CombatDomain.Domain;

public class Character
{
    public int Health { get; private set; }
    public int Level { get; private set; }
    public bool Alive { get; private set; }

    public Character()
    {
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
        else if (heal > 1000)
            throw new InvalidOperationException("Só é possível a cura até 1000.");

        Health += heal;
    }

    public void SetAlive(bool isAlive) => Alive = isAlive;
    
}