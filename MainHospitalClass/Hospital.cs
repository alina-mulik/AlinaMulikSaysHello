using People;

namespace MainHospitalClass
{
    public class Hospital : Institution
    {
        private const int PerVisitPayment = 500;
        private Patient[] _patients;
        private Doctor[] _doctors;

        public Hospital(string name, Patient[] patients, Doctor[] doctors, int budget) : base(name, budget)
        {
            _patients = patients;
            _doctors = doctors;
        }

        public void OutPutAllPatientNames()
        {
            Console.WriteLine("List of Patients:");
            Console.WriteLine(String.Join(',', Person.GetArrayOfNames(_patients)));
            Console.WriteLine("------------------");
        }

        public void OutPutAllDoctorsNames()
        {
            Console.WriteLine("List of Doctors:");
            foreach (var doctor in _doctors)
            {
                Console.Write($"{doctor.GetName()},");
            }
            Console.WriteLine("\n------------------");
        }

        public override int GetBudget()
        {
            foreach (var doctor in _doctors)
            {
                _budget -= doctor.GetSalary();
            }
            _budget += _patients.Length * PerVisitPayment;

            return _budget;
        }

        public void OutputHospitalInfo()
        {
            Console.WriteLine("Hospital Info:");
            Console.WriteLine($"Name: {_name}, Total Budget: {_budget}");
            Console.WriteLine($"Number Of Doctors: {_doctors.Length}, Total Number Of Patients: {_patients.Length}");
            Console.WriteLine("------------------");
        }
    }
}
