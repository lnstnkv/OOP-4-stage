﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Elf
    {
        protected TargetMover _targetMover;
        private List<Present> _presents;
        protected Map _map;
        protected Point coordinat;
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

        public virtual void Loop(Random x)
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
            var giftHiman = _presents[rnd];
            if (giftHiman.IsGift() == Gift.Sweet)
            {
                human.satietly = human.max_satietly;
            }

            if (giftHiman.IsGift() == Gift.Cap)
            {
                human.satietly += AdditionSatiety;
            }

            if (giftHiman.IsGift() == Gift.Bag)
            {
                human.capacity += AdditionParameter;
            }

            if (giftHiman.IsGift() == Gift.Tool)
            {
                human._tools.Add(new Tool());
            }

            if (giftHiman.IsGift() == Gift.Eat)
            {
                human._plant = new Plant(coordinat.X + Shift, coordinat.Y + Shift, _map, false, true);
            }

            if (giftHiman.IsGift() == Gift.Empty)
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