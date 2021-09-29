namespace Code
{
    public class Ship
    {
        private static float _hp;

        public Ship(float hp)
        {
            _hp = hp;
        }

        public void ChangeHp()
        {
            _hp--;
        }

        public float GetHp()
        {
            return _hp;
        }
    }
}