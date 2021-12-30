using System;

namespace WindowsFormsApp1
{
    public class Present
    {
        private Gift _gift;

        public Present(Random x)
        {
            isGifts(x);
        }

        private void isGifts(Random random)
        {
            var x = random.Next(0, 3);
            switch (x)
            {
                case 0:
                    _gift = Gift.Bag;
                    break;
                case 1:
                    _gift = Gift.Cap;
                    break;
                case 2:
                    _gift = Gift.Sweet;
                    break;
            }
        }

        public Gift IsGift()
        {
            if (_gift == Gift.Bag)
            {
                return Gift.Bag;
            }

            if (_gift == Gift.Cap)
            {
                return Gift.Cap;
            }
            else
            {
                return Gift.Sweet;
            }
        }

        public void  GetEmpty()
        {
            _gift = Gift.Empty;
        }
    }
}