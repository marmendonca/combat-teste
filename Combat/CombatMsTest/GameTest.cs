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

        var game = new Game(target, attacker);
        var targetHealth = game.DealDemage(50);

        Assert.AreEqual(target.Health, targetHealth);
    }

    [TestMethod]
    public void DealDemageWhenPlayersIsTheSameLevel()
    {
        var target = new Character("teste 1");

        var attacker = new Character("teste 2");

        var game = new Game(target, attacker);
        var targetHealth = game.DealDemage(50);

        Assert.AreEqual(target.Health, targetHealth);
    }

    [TestMethod]
    public void HealSamePlayer()
    {
        var target = new Character("teste 1");
        target.ReceiveDemage(50);
        var attacker = new Character("teste 1");

        var game = new Game(target, attacker);
        var targetHealth = game.Heal(50);

        Assert.AreEqual(target.Health, targetHealth);
    }
}