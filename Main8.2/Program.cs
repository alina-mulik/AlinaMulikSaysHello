using Classes8._2;

namespace Main8._2
{
    public class Program
    {
        static void Main(string[] args)
        {
            HadronColliderClass hadron = new HadronColliderClass(200, 100);
            Console.WriteLine($"Entered quantity of particles: {hadron.NumberOfParticlesForCollision}, time: {hadron.TimeOfParticlesCollisionMin}");
            hadron.CollideParticles();
        }
    }
}
