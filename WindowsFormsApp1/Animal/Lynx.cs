using System;

namespace WindowsFormsApp1
{
    public class Lynx:CarnivoresAnimal
    {
        public Lynx(int x, int y, Map map, Random random,Land[,] land) : base(x, y, map, random,land)
        {
            Satiety = 250;
            MaxSatiety = 250;
            FreeMover = new NearBirthFreeMover(BirthPoint);
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
                Satiety = 250;
                HibernationForm = HibernationForm.Sleep;
            }
        }

        protected override CarnivoresAnimal NewAnimal(int x, int y, Map map, Random random, Land[,] land)
        {
            return new Lynx(x, y, _map, random, land);
        }
    }
}