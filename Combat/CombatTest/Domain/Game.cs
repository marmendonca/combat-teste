namespace CombatDomain.Domain;

public class Game
{
    private Character _target;
    private Character _attacker;

    public Game(Character target, Character attacker)
    {
        _target = target;
        _attacker = attacker;
    }

    public int DealDemage(int demage)
    {
        if (_target.Name == _attacker.Name)
            throw new InvalidOperationException("Não é possível causar danos ao mesmo personagem.");

        if (_target.Level > _attacker.Level)
            demage = demage / 2;

        if (_target.Level < _attacker.Level)
            demage += demage;

        _target.ReceiveDemage(demage);

        return _target.Health;
    }

    public int Heal(int heal)
    {
        if (_target.Name == _attacker.Name)
            _target.ReceiveHeal(heal);

        return _target.Health;
    }
}
