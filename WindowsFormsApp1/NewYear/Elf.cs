using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Elf
    {
        private TargetMover _targetMover;
        private List<Present> _presents;
        private Map _map;
        private Point coordinat;
        private Human _human;
        private Factory _factory;
        private int index;
        private int countGift;
        private const int AdditionParameter = 1;
        private const int AdditionSatiety = 20;
        private const int Shift = 1;
        private const int MaximumIndexForGivePresent = 250;
        private const int MinimalGift = 10;
        private const int MinimumIndexForGivePresent = 20;
        private const int LeftRangePercentage = 0;


        public Elf(int x, int y, Random rnd, Map map)
        {
            _presents = new List<Present>();
            _targetMover = new TargetMoverSavingDirection();
            _map = map;
            _human = null;
            _factory = null;
            coordinat = new Point(x, y);
        }

        public virtual void Update(Random x)
        {
            index++;
            if (index > MinimumIndexForGivePresent && index < MaximumIndexForGivePresent)
            {
                if (_human == null)
                {
                    _human = _map.FindHuman(coordinat);
                }

                if (_human != null)
                {
                    var position = _human.GetPoint();
                    coordinat = _targetMover.TargetMove(coordinat, position);
                    if (coordinat.X == position.X && coordinat.Y == position.Y)
                    {
                        GiveGift(_human, x);
                    }

                    _human = null;
                }
            }
            else
            {
                GoFactory(x);
            }
        }

        private void GoFactory(Random x)
        {
            if (_factory == null)
            {
                _factory = _map.FindFactory(coordinat);
            }

            if (_factory != null)
            {
                coordinat = _targetMover.TargetMove(coordinat, _factory.GetPoint());
                MakeGifts(x);
            }
        }

        private void GiveGift(Human human, Random x)
        {
            var rnd = x.Next(LeftRangePercentage, _presents.Count);
            var giftHuman = _presents[rnd];
            if (giftHuman.GetGift() == Gift.Sweet)
            {
                human.Satiety = human.MaxSatiety;
            }

            if (giftHuman.GetGift() == Gift.Cap)
            {
                human.Satiety += AdditionSatiety;
            }

            if (giftHuman.GetGift() == Gift.Bag)
            {
                human.capacity += AdditionParameter;
            }

            if (giftHuman.GetGift() == Gift.Tool)
            {
                human.Tools.Add(new Tool());
            }

            if (giftHuman.GetGift() == Gift.Eat)
            {
                human._plant = new Plant(coordinat.X + Shift, coordinat.Y + Shift, _map, false, true);
            }

            if (giftHuman.GetGift() == Gift.Empty)
            {
                GiveGift(human, x);
                countGift++;
            }

            _presents[rnd].GetEmpty();

            if (countGift == _presents.Count)
            {
                GoFactory(x);
            }
        }

        private void MakeGifts(Random x)
        {
            if (_presents.Count < MinimalGift)
            {
                _presents.Add(new Present(x));
            }
        }

        public Point GetPoint()
        {
            return coordinat;
        }
    }
}