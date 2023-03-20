namespace CombatDomain.Domain;

public class Game
{
    private Character _target;
    private Character _attacker;
    private Character _characterToSave;

    public Game(Character characterToSave)
    {
        _characterToSave = characterToSave;
    }

    public Game(Character target, Character attacker)
    {
        _target = target;
        _attacker = attacker;
    }

    public int DealDemage(int demage)
    {
        ValidateSamePlayer();

        ValidateRange();

        ValidateLevel(demage);

        _target.ReceiveDemage(demage);

        return _target.Health;
    }

    private void ValidateSamePlayer()
    {
        if (_target.Name == _attacker.Name)
            throw new InvalidOperationException("Não é possível causar danos ao mesmo personagem.");
    }

    private void ValidateRange()
    {
        if (_target.Range > _attacker.Range)
            throw new InvalidOperationException("Ataque com alcance menor que o alvo.");
    }

    private void ValidateLevel(int demage)
    {
        if (_target.Level > _attacker.Level)
            demage = demage / 2;

        if (_target.Level < _attacker.Level)
            demage += demage;
    }

    public int Heal(int healQuantity, Character characterSaving)
    {
        if (characterSaving.Name == _characterToSave.Name)
            _characterToSave.ReceiveHeal(healQuantity);

        return _characterToSave.Health;
    }
}
