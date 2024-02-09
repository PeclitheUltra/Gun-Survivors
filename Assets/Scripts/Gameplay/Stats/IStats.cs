namespace Gameplay.Stats
{
    public interface IStats
    {
        public float Health { get; }
        public float MovementSpeed { get; }
        public float AttackTime { get; }
        public float AttackRange { get; }
        public float AttackDamage { get; }
    }
}