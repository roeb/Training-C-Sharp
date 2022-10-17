using System;
abstract class Character
{
    public string CharacterType { get; private set;}
    
    protected Character(string characterType) => CharacterType = characterType;
    public abstract int DamagePoints(Character target);
    public virtual bool Vulnerable() => false;
    public override string ToString() => $"Character is a {CharacterType}";
}
class Warrior : Character
{
    private readonly int _damageDealtToVulnerableTarget = 10;
    private readonly int _damageDealtToNotVulnerableTarget = 6;
    public Warrior() : base("Warrior") 
    {
    }
    public override int DamagePoints(Character target) => target.Vulnerable() ? _damageDealtToVulnerableTarget : _damageDealtToNotVulnerableTarget;
}
class Wizard : Character
{
    private bool _hasPreparedSpell = default;
    private readonly int _damageDealtWhenHasPreparedSpell = 12;
    private readonly int _damageDealtWhenHasNotPreparedSpell = 3;
    public Wizard() : base("Wizard")
    {
    }
    public override bool Vulnerable() => !_hasPreparedSpell;
    public override int DamagePoints(Character target) 
    {
        int points = _hasPreparedSpell ? _damageDealtWhenHasPreparedSpell : _damageDealtWhenHasNotPreparedSpell;
        _hasPreparedSpell = false;
        return points;
    }
    public void PrepareSpell() => _hasPreparedSpell = true;
}