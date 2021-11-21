using System.Drawing;

namespace WindowsFormsApp1
{
    public class Land
    {
        private Animal isAnimalHere;
        private Plant isPlantHere;
        private Fruit isFruitHere;
        private Human isHumanHere;
        protected IsHere _isHere;
        private FruitingPlant isFruitingPlantHere;

        public Land()
        {
            isAnimalHere = null;
            isPlantHere = null;
            isFruitHere = null;
            isHumanHere = null;
            _isHere = IsHere.Empty;
        }

        public void SetAnimal(Animal animal)
        {
            isAnimalHere = animal;
            _isHere = IsHere.Animal;
        }

        public void SetPlant(Plant plant)
        {
            isPlantHere = plant;
            _isHere = IsHere.Plant;
        }

        public Human IsHumanHere()
        {
            return isHumanHere;
        }
        public Plant IsPlantHere()
        {
            return isPlantHere;
        }
        public Animal IsAnimalHere()
        {
            return isAnimalHere;
        }

        public void SetFruit(Fruit fruit)
        {
            isFruitHere = fruit;
            _isHere = IsHere.Fruit;
        }
        public void SetHuman(Human human)
        {
            isHumanHere = human;
            _isHere = IsHere.Human;
        }


        public bool IsEmpty()
        {
            if (_isHere == IsHere.Empty)
                return true;
            return false;
        }

        public void DeletePlant()
        {
            isPlantHere = null;
            _isHere = IsHere.Empty;
        }

        public IsHere GetIsHere()
        {
            return _isHere;
        }
        public void DeleteFruit()
        {
            isFruitHere = null;
            _isHere = IsHere.Empty;
        }

        public void DeleteAnimal()
        {
            isAnimalHere = null;
            _isHere = IsHere.Empty;
        }
        public Plant GetPlant()
        {
            return isPlantHere;
        }
        public Fruit GetFruit()
        {
            return isFruitHere;
        }
        
    }  public enum IsHere
             {
                 Animal,
                 Plant,
                 Fruit,
                 Human,
                 Empty
             }
    
}