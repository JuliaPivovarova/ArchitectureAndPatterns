using System;

namespace Code.UI
{
    internal sealed class DisplayHp
    {
        private string _hptext;

        public DisplayHp()
        {
            _hptext = String.Empty;
        }

        public string Display(float hpMax, float hpValue)
        {
            _hptext = $"У вас {hpValue} из {hpMax}";
            return _hptext;
        }
    }
}