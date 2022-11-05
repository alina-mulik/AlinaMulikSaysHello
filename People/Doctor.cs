namespace People
{
    public class Doctor: Person
    {
        private const int perPatientBonus = 100;
        private const int qualifiedDoctorPayment = 15000;
        private const int underQualifiedDoctorPayment = 1000;
        private string specialty;
        private int yearsOfExperience;
        private bool hasPHD;
        private int salary;
        private List<Patient> patientsList;

        public Doctor(string name, string gender, int age, int id, string specialty, int yearsOfExperience, bool hasPHD)
        {
            Name = name;
            Gender = gender.ToLower();
            Age = age;
            Id = id;
            this.specialty = specialty.ToLower();
            this.yearsOfExperience = yearsOfExperience;
            this.hasPHD = hasPHD;
            this.patientsList = new List<Patient>();
        }

        public int GetSalary()
        {
            if (hasPHD && yearsOfExperience > 5 || specialty == "surgeon" || specialty == "dentist")
            {
                salary = qualifiedDoctorPayment + (patientsList.Count * perPatientBonus);
            }
            else
            {
                salary = underQualifiedDoctorPayment * yearsOfExperience + (patientsList.Count * perPatientBonus);
            }

            return salary;
        }

        public void OutPutDoctorInfo()
        {
            var namesOfPatients = new List<string>();
            foreach (var patient in patientsList)
            {
                namesOfPatients.Add(patient.GetName());
            }
            Console.WriteLine("Doctor's Information:");
            Console.WriteLine($"{Id}, {Name}, {Age} years old, Salary: {this.GetSalary()}, {Gender}, Has PHD: {hasPHD}, \nYears Of Experience: {yearsOfExperience}, Specialization: {specialty}");
            Console.WriteLine($"List of Patients: {String.Join(',', namesOfPatients)}");
        }


        public List<Patient> GetListOfPatients() { return patientsList; }

        public void AddPatientToDoctorProfile(Patient patient)
        {
            patientsList.Add(patient);
        }

        public void HealPatientDisease(Patient patient, string disease)
        {
            if (this.patientsList.Contains(patient))
            {
                patient.RemoveDiseaseFromTheListOfDiseases(disease);
            }
        }
    }
}
