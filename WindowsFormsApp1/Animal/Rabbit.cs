using System;

namespace WindowsFormsApp1
{
    public class Rabbit:HerbivoresAnimal
    {
       
        public Rabbit(int x, int y, Map map, Random rnd) : base(x, y, map, rnd)
        {
            satietly = 200;
            
            _freeMover = new NearBirthFreeMover(_birthPoint);
            _targetMover = new TargetMoverSavingDirection();
        }
    }
}