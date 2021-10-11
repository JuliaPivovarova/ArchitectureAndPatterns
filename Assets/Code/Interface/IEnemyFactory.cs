namespace Code.Interface
{
    internal interface IEnemyFactory
    {
        Enemy.Enemy Create(Health hp);
    }
}