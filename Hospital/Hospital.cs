using People;

namespace Hospital
{
    public class Hospital
    {
        private const int perDiseasePayment = 500;
        private string name;
        private List<Patient> patients;
        private List<Doctor> doctors;
        private int budget;

        public Hospital(string name, List<Patient> patients, List<Doctor> doctors, int budget = 1000000)
        {
            this.name = name;
            this.patients = patients;
            this.doctors = doctors;
            this.budget = budget;
        }

        public void AddPatient(Patient patient) { patients.Add(patient); }

        public void AddDoctor(Doctor doctor) { doctors.Add(doctor); }

        public void OutPutAllPatientNames()
        {
            var listOfPatientNames = new List<string> { };
            foreach (var patient in patients)
            {
                listOfPatientNames.Add(patient.Name);
            }
            Console.WriteLine(String.Join(',', listOfPatientNames));
        }

        public void OutPutAllDoctorsNames()
        {
            var listOfDoctorsNames = new List<string> { };
            foreach (var doctor in doctors)
            {
                listOfDoctorsNames.Add(doctor.Name);
            }
            Console.WriteLine(String.Join(',', listOfDoctorsNames));
        }

        public int GetBudgetAfterPayingSalaryToDoctors()
        {
            foreach (var doctor in doctors)
            {
                budget -= doctor.Salary;
            }

            return budget;
        }

        public int GetBudgetAfterPatientsPayments()
        {
            foreach (var patient in patients)
            {
                var numberOfPatientDiseases = patient.GetListOfDiseases().Count();
                budget += numberOfPatientDiseases * perDiseasePayment;
            }

            return budget;
        }

        public void OutputHospitalInfo()
        {
            Console.WriteLine("Hospital Info:");
            Console.WriteLine($"Name: {name}, Total Budget: {budget}");
            Console.WriteLine($"Nuvmber Of Doctors: {doctors.Count}, Total Number Of Patients: {patients.Count}");
        }
    }
}