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
            var isHumanJackHappy = jack.IsHappy();
            Console.WriteLine($"Human {jack.Name} is happy? {isHumanJackHappy}, points of happiness: {jack.pointsOfHappiness}");

            // Create a fish, call  some methods from abstract base class and Fish's unique methods
            Fish nemo = new Fish(colour: "Orange", name: "Nemo", age: 2);
            nemo.Eat();
            nemo.Move();
            nemo.MakeBubbles();
            nemo.Play();
            var isFishNemoHappy = nemo.IsHappy();
            Console.WriteLine($"Fish {nemo.Name} is happy? {isFishNemoHappy}, points of happiness: {nemo.pointsOfHappiness}");
            Console.WriteLine($"Living beings in total: {LivingBeingAbstractClass.counterOfLivingBeings}");
        }
    }
}
