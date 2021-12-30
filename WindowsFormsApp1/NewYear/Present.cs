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
            var x = random.Next(0, 5);
            switch (x)
            {
                case 0:
                    _gift = Gift.Bag;
                    break;
                case 1:
                    _gift = Gift.Sweet;
                    break;
                case 2:
                    _gift = Gift.Cap;
                    break;
                case 3:
                    _gift = Gift.Eat;
                    break;
                case 4:
                    _gift = Gift.Tool;
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
            if (_gift == Gift.Eat)
            {
                return Gift.Eat;
            }
            if (_gift == Gift.Tool)
            {
                return Gift.Tool;
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