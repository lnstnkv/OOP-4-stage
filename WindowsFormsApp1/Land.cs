using System.Drawing;

namespace WindowsFormsApp1
{
    public class Land
    {
        private Animal isAnimalHere;
        private Plant isPlantHere;
        private Fruit isFruitHere;
        private Factory isFactoryHere;
        private Animal isHumanHere;
        protected IsHere _isHere;
        private bool _isHouse;
        private FruitingPlant isFruitingPlantHere;

        public Land()
        {
            _isHouse = false;
            isAnimalHere = null;
            isPlantHere = null;
            isFruitHere = null;
            isFactoryHere = null;
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
       

        public void SetHouse()
        {
            _isHouse = true;
            _isHere = IsHere.House;
        }

        public Animal IsHumanHere()
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

        public void SetMale(Animal human)
        {
            isAnimalHere = human;
            _isHere = IsHere.Male;
        }

        public void SetFactory(Factory factory)
        {
            isFactoryHere = factory;
            _isHere = IsHere.Factory;
        }
        public void SetFemale(Animal human)
        {
            isAnimalHere = human;
            _isHere = IsHere.Female;
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
        public void DeleteFactory()
        {
            isFactoryHere = null;
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

       
    }

    public enum IsHere
    {
        Animal,
        Plant,
        Fruit,
        Male,
        Female,
        House,
        Factory,
        Empty
    }
}