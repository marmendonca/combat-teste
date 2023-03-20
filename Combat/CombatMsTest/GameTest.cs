using CombatDomain.Domain;

namespace CombatMsTest;

[TestClass]
public class GameTest
{
    [TestMethod]
    public void ThrowExceptionWhenDealDemageWhenSamePlayers()
    {
        var target = new Character("teste 1");
        var attacker = new Character("teste 1");

        target.Range = MeleeFighter.Range;
        attacker.Range = RangedFighter.Range;

        var game = new Game(target, attacker);
        var exception = Assert.ThrowsException<InvalidOperationException>(() => game.DealDemage(100));

        Assert.AreEqual(exception.Message, "Não é possível causar danos ao mesmo personagem.");
    }

    [TestMethod]
    public void DealDemageWhenTargetLevelIsMoreThanAttacker()
    {
        var target = new Character("teste 1");
        target.SetLevel(6);

        var attacker = new Character("teste 2");

        target.Range = MeleeFighter.Range;
        attacker.Range = RangedFighter.Range;

        var game = new Game(target, attacker);
        var targetHealth = game.DealDemage(300);

        Assert.AreEqual(target.Health, targetHealth);
    }

    [TestMethod]
    public void DealDemageWhenTargetLevelIsLessThanAttacker()
    {
        var target = new Character("teste 1");
        target.SetLevel(4);

        var attacker = new Character("teste 2");
        attacker.SetLevel(5);

        target.Range = MeleeFighter.Range;
        attacker.Range = RangedFighter.Range;

        var game = new Game(target, attacker);
        var targetHealth = game.DealDemage(50);

        Assert.AreEqual(target.Health, targetHealth);
    }

    [TestMethod]
    public void DealDemageWhenPlayersIsTheSameLevel()
    {
        var target = new Character("teste 1");

        var attacker = new Character("teste 2");

        target.Range = MeleeFighter.Range;
        attacker.Range = RangedFighter.Range;

        var game = new Game(target, attacker);
        var targetHealth = game.DealDemage(50);

        Assert.AreEqual(target.Health, targetHealth);
    }

    [TestMethod]
    public void HealSamePlayer()
    {
        var target = new Character("teste 1");
        var attacker = new Character("teste 2");

        target.Range = MeleeFighter.Range;
        attacker.Range = RangedFighter.Range;

        var game1 = new Game(target, attacker);
        game1.DealDemage(50);

        var game2 = new Game(target);
        var targetHealth = game2.Heal(50, target);

        Assert.AreEqual(target.Health, targetHealth);
    }

    [TestMethod]
    public void DealDemageWhenTargetHasMoreRangelThanAttacker()
    {
        var target = new Character("teste 1");

        var attacker = new Character("teste 2");

        target.Range = RangedFighter.Range;
        attacker.Range = MeleeFighter.Range;

        var game = new Game(target, attacker);
        
        var exception = Assert.ThrowsException<InvalidOperationException>(() => game.DealDemage(100));

        Assert.AreEqual(exception.Message, "Ataque com alcance menor que o alvo.");
    }
}