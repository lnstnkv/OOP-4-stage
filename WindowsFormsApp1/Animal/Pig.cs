using System;

namespace WindowsFormsApp1
{
    public class Pig:OmnivoresAnimal
    {
        public Pig(int x, int y, Map map, Random random,Land[,] land) : base(x, y, map, random,land)
        {
            Satiety = 245;
            MaxSatiety = 245;
            FreeMover = new RandomFreeMover();
            TargetMover = new TargetMoverSavingDirection();
        }
        public override void Update(Random random)
        {
            if (_map.isWinter)
            {
                SetLifecycle(random);
            }
            else
            {
                Satiety = 245;
                HibernationForm = HibernationForm.Sleep;
            }
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land)
        {
            return new Pig(x, y, _map, random, land);
        }
    }
}