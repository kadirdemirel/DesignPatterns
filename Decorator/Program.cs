using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonelCar { Make = "BMW", Model = "3.20", HirePirce = 2500 };
            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            specialOffer.DiscountPercentage = 10;
            Console.WriteLine("Concrete : {0}", personelCar.HirePirce);
            Console.WriteLine("Special offer : {0}", specialOffer.HirePirce);
        }
    }
    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePirce { get; set; }
    }
    class PersonelCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePirce { get; set; }

    }
    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePirce { get; set; }
    }
    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;
        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }
    class SpecialOffer : CarDecoratorBase
    {

        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePirce
        {
            get
            {
                return _carBase.HirePirce - (_carBase.HirePirce * DiscountPercentage / 100);
            }
            set
            {

            }
        }
    }
}