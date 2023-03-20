using CombatDomain.Domain;

namespace CombatMsTest;

[TestClass]
public class CharacterTest
{
    [TestMethod]
    public void InitCharacterWithDefaultValues()
    {
        var character = new Character();

        Assert.AreEqual(character.Health, 1000);
        Assert.AreEqual(character.Alive, true);
        Assert.AreEqual(character.Level, 1);
    }

    [TestMethod]
    public void ReceiveExceedDemage()
    {
        var character = new Character();

        character.ReceiveDemage(1001);

        Assert.AreEqual(character.Alive, false);
        Assert.AreEqual(character.Health, 0);
    }

    [TestMethod]
    public void ReceiveValidDemage()
    {
        var character = new Character();

        character.ReceiveDemage(900);

        Assert.AreEqual(character.Alive, true);
        Assert.AreEqual(character.Health, 100);
    }

    [TestMethod]
    public void ReceiveHealWhenCharacterIsNotAlive()
    {
        var character = new Character();

        character.SetAlive(false);

        var exception = Assert.ThrowsException<InvalidOperationException>(() => character.ReceiveHeal(100));

        Assert.AreEqual(exception.Message, "Não é possível salvar personagem morto.");
    }

    [TestMethod]
    public void ReceiveHealWhenHealExceed1000()
    {
        var character = new Character();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => character.ReceiveHeal(1001));

        Assert.AreEqual(exception.Message, "Só é possível a cura até 1000.");
    }

    [TestMethod]
    public void ReceiveValidHeal()
    {
        var character = new Character();

        character.ReceiveHeal(500);

        Assert.AreEqual(character.Health, 1500);
    }
}