using System.Drawing;

namespace WindowsFormsApp1
{
    public class Land
    {
        private Animal _isAnimalHere;
        private Plant _isPlantHere;
        private Fruit _isFruitHere;
        private Factory _isFactoryHere;
        private Animal _isHumanHere;
        private IsHere IsHere;
        private bool _isHouse;
        private FruitingPlant _isFruitingPlantHere;

        public Land()
        {
            _isHouse = false;
            _isAnimalHere = null;
            _isPlantHere = null;
            _isFruitHere = null;
            _isFactoryHere = null;
            _isHumanHere = null;
            IsHere = IsHere.Empty;
        }

        public void SetAnimal(Animal animal)
        {
            _isAnimalHere = animal;
            IsHere = IsHere.Animal;
        }

        public void SetPlant(Plant plant)
        {
            _isPlantHere = plant;
            IsHere = IsHere.Plant;
        }


        public void SetHouse()
        {
            _isHouse = true;
            IsHere = IsHere.House;
        }
        
        public Plant GetPlant()
        {
            return _isPlantHere;
        }

        public Animal GetAnimal()
        {
            return _isAnimalHere;
        }

        public void SetFruit(Fruit fruit)
        {
            _isFruitHere = fruit;
            IsHere = IsHere.Fruit;
        }

        public void SetMale(Animal human)
        {
            _isAnimalHere = human;
            IsHere = IsHere.Male;
        }

        public void SetFactory(Factory factory)
        {
            _isFactoryHere = factory;
            IsHere = IsHere.Factory;
        }

        public void SetFemale(Animal human)
        {
            _isAnimalHere = human;
            IsHere = IsHere.Female;
        }

        public bool IsEmpty()
        {
            if (IsHere == IsHere.Empty)
                return true;
            return false;
        }

        public void DeletePlant()
        {
            _isPlantHere = null;
            IsHere = IsHere.Empty;
        }

        public IsHere GetIsHere()
        {
            return IsHere;
        }
        public void DeleteAnimal()
        {
            _isAnimalHere = null;
            IsHere = IsHere.Empty;
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