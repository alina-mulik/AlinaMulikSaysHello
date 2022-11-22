using System;

namespace Classes8._2
{
    public class HadronColliderClass
    {
        private int _timeOfParticlesCollisionMin;
        private int _numberOfParticlesForCollision;
        private int _temperatureOfCollider;

        public int TimeOfParticlesCollisionMin { get { return _timeOfParticlesCollisionMin; } set { _timeOfParticlesCollisionMin = value; } }
        public int NumberOfParticlesForCollision
        {
            get
            {
                return _numberOfParticlesForCollision;
            }
            set
            {
                try
                {
                    _numberOfParticlesForCollision = value;
                    if (_numberOfParticlesForCollision > 10000000 || _numberOfParticlesForCollision < 100)
                    {
                        throw new InvalidQuantityOfParticlesException();
                    }
                }
                catch (InvalidQuantityOfParticlesException e) when (LogException(e))
                {
                }
            }
        }

        public HadronColliderClass(int numberOfParticlesForCollision, int timeOfParticlesCollision)
        {
            Console.WriteLine("All systems of the Hadron Collider are turned on!");
            TimeOfParticlesCollisionMin = timeOfParticlesCollision;
            NumberOfParticlesForCollision = numberOfParticlesForCollision;
        }

        public void CollideParticles()
        {
            Console.WriteLine("To start the Collider you need to press the button.");
            Console.WriteLine("There are 2 buttons 'red' and 'green', enter the name of the button to press it:");
            var buttonPressed = Console.ReadLine();
            switch (buttonPressed.ToLower())
            {
                case "red":
                    Console.WriteLine("Red ALARM button has been pressed!");
                    EmergencyTurnOffColider();
                    break;
                case "green":
                    _temperatureOfCollider = 1000;
                    Console.WriteLine("Collider started the collision of particles....");
                    Console.WriteLine($"Collider temperature is {_temperatureOfCollider}");
                    Console.WriteLine($"Time {TimeOfParticlesCollisionMin} min of particles collision is almost finished.");
                    Console.WriteLine("Collider is finishing the collision of particles....");
                    GenerateExperimentReport();
                    TurnOffColider();
                    break;
                default:
                    throw new InvalidButtonException();
            }
        }

        public void GenerateExperimentReport()
        {
            _temperatureOfCollider = 0;
            Console.WriteLine("-------------------");
            Console.WriteLine($"Generating the report of the experiment.....");
            Console.WriteLine($"The report is generated!");
        }

        public void TurnOffColider()
        {
            _temperatureOfCollider = 0;
            Console.WriteLine("-------------------");
            Console.WriteLine("Turning Off all the systems of the Colider!");
            Console.WriteLine($"The temperature of the Colider is {_temperatureOfCollider} now!");
        }

        public void EmergencyTurnOffColider()
        {
            _temperatureOfCollider = 0;
            Console.WriteLine("-------------------");
            Console.WriteLine("Something went wrong");
            Console.WriteLine("Turning Off all the systems of the Colider!");
            Console.WriteLine($"The temperature of the Colider is {_temperatureOfCollider} now!");
            Console.WriteLine("-------------------");
        }

        private bool LogException(Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}
