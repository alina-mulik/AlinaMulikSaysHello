using People;

namespace MainHospitalClass
{
    public class Hospital
    {
        private const int PerVisitPayment = 500;
        private string _name;
        private string[] _patients;
        private Doctor[] _doctors;
        private int _budget;

        public Hospital(string name, string[] patients, Doctor[] doctors, int budget = 1000000)
        {
            this._name = name;
            this._patients = patients;
            this._doctors = doctors;
            this._budget = budget;
        }

        public void OutPutAllPatientNames()
        {
            Console.WriteLine("List of Patients:");
            Console.WriteLine(String.Join(',', _patients));
            Console.WriteLine("------------------");
        }

        public void OutPutAllDoctorsNames()
        {
            Console.WriteLine("List of Doctors:");
            foreach (var doctor in _doctors)
            {
                Console.Write($"{doctor.GetDoctorName()},");
            }
            Console.WriteLine("\n------------------");
        }

        public int GetBudgetAfterPayingSalaryToDoctors()
        {
            foreach (var doctor in _doctors)
            {
                _budget -= doctor.GetSalary();
            }

            return _budget;
        }

        public int GetBudgetAfterPatientsPaymentsForVisits(int totalNumberOfVisits)
        {
            _budget += totalNumberOfVisits * PerVisitPayment;

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
