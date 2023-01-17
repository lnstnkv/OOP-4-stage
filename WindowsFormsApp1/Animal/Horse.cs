using System;

namespace WindowsFormsApp1
{
    public class Horse : HerbivoresAnimal
    {
        private const int MaximumSatiety = 150;
        public Horse(int x, int y, Map map, Random random,Land[,] land) : base(x, y, map, random,land)
        {
            Satiety = 150;
            MaxSatiety = 150;
            FreeMover = new RandomFreeMover();
            TargetMover = new TargetMoverEuclidean();
        }

        public override void Update(Random random)
        {
            if (_map.isWinter)
            {
                SetLifecycle(random);
            }
            else
            {
                Satiety = MaximumSatiety;
                HibernationForm = HibernationForm.Sleep;
            }
        }

        protected override HerbivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land)
        {
            return new Horse(x, y, _map, random, land);
        }
    }
}