using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class FruitingPlant:Plant
    {
        public void GiveFruit(Random x, Map map, Point position, bool isVirulence)
    {
        var probability = x.Next(200);
        if (probability > 0) return;
        var land = map.FindNearbyLand(position);
        var positionFruitX = 0;
        var positionFruitY = 0;
        if (land.Count > 0)
        {
            positionFruitX = land[x.Next(land.Count)].X;
            positionFruitY = land[x.Next(land.Count)].Y;
        }

        _map.AddFruit(new Fruit(positionFruitX,positionFruitY,_map,isVirulence));
    }

    public override void Start(Random x)
    {
        base.Start(x);
        if(Stage!= Stage.Increase) return;
    }

    protected override Plant NewSproutsPlant(int x, int y, Map map, bool isVirulence, bool isEat)
        {
            return new FruitingPlant(x, y, _map, isVirulence, isEat);
        }
    public FruitingPlant(int x, int y, Map map, bool isVirulence, bool isEat) : base(x, y, map, isVirulence, isEat)
    {
        
    }
    }
}