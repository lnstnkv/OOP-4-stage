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
            if (index > 10 && index<100)
            {
                if (_human == null)
                {
                    _human = _map.FindHuman(coordinat);
                }

                if (_human != null)
                {
                    var position = _human.GetPoint();
                    coordinat = _targetMover.TargetMove(coordinat, position);
                    if (coordinat.X==position.X && coordinat.Y==position.Y)
                    {
                        GiveGift(_human, x);
                    }

                    _human = null;
                }
            }
            else
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
        }

        private void GiveGift(Human human, Random x)
        {
            var rnd = x.Next(0, _presents.Count);
            var giftHiman = _presents[rnd];
            if (giftHiman.IsGift() == Gift.Sweet)
            {
                human.satietly += 50;
            }

            if (giftHiman.IsGift() == Gift.Cap)
            {
                human.capacity += 1;
            }
            
            if (giftHiman.IsGift() == Gift.Bag)
            {
                human.capacity += 1;
            }

            if (giftHiman.IsGift() == Gift.Empty)
            {
                GiveGift(human,x);
            }
            _presents[rnd].GetEmpty();
            

        }

        private void MakeGifts(Random x)
        {
            if (_presents.Count < 10)
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