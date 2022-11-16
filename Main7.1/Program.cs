using Classes7._1;

namespace Main7._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a human, call  some methods from abstract base class and Human's unique methods
            Human jack = new Human(name: "Jack", age: 30, gender: "male");
            jack.Drink();
            jack.Eat();
            jack.Rest();
            var isHumanJackHappy = jack.IsLivingBeingHappy();
            Console.WriteLine($"Human {jack.LivingBeingName} is happy? {isHumanJackHappy}, points of happiness: {jack.OutputPointsOfHappiness()}");

            // Create a fish, call  some methods from abstract base class and Fish's unique methods
            Fish nemo = new Fish(colour: "Orange", name: "Nemo", age: 2);
            nemo.Eat();
            nemo.Move();
            nemo.MakeBubbles();
            nemo.Play();
            var isFishNemoHappy = nemo.IsLivingBeingHappy();
            Console.WriteLine($"Fish {nemo.LivingBeingName} is happy? {isFishNemoHappy}, points of happiness: {nemo.OutputPointsOfHappiness()}");
            Console.WriteLine($"Living beings in total: {LivingBeingAbstractClass.OutputCounterOfLivingBeings()}");
        }
    }
}
