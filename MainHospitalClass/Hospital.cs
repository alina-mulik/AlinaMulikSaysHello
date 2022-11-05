using People;

namespace MainHospitalClass
{
    public class Hospital
    {
        private const int perDiseasePayment = 500;
        private string name;
        private List<Patient> patients;
        private List<Doctor> doctors;
        private int budget;

        static void Main(string[] args)
        {
            // Add Patients with their diseases and meds prescribed
            Patient jack = new Patient(id: 1, name: "Jack Jackson", age: 40, patientGender: "male", insurance: true, drinking: true);
            jack.AddDiseaseToTheListOfDiseases("Arthritis");
            jack.AddDiseaseToTheListOfDiseases("Flu");
            jack.AddMedToTheListOfMeds("Coldrex Powder");
            Patient ann = new Patient(id: 2, name: "Ann Jackson", age: 35, patientGender: "female", insurance: true, smoking: true);
            ann.AddDiseaseToTheListOfDiseases("Allergy");
            ann.AddDiseaseToTheListOfDiseases("Flu");
            ann.AddMedToTheListOfMeds("Coldrex Powder");
            Patient kate = new Patient(id: 3, name: "Kate Hudson", age: 20, patientGender: "female", insurance: true);
            kate.AddDiseaseToTheListOfDiseases("Cavity");
            kate.AddDiseaseToTheListOfDiseases("Teeth inflamation");
            kate.AddMedToTheListOfMeds("Painkillers");
            kate.AddMedToTheListOfMeds("Antibiotics");
            Patient marcus = new Patient(id: 4, name: "Marcus Hudson", age: 27, patientGender: "male", insurance: true, smoking: true);
            marcus.AddDiseaseToTheListOfDiseases("Cavity");
            marcus.AddDiseaseToTheListOfDiseases("Headache");
            marcus.AddMedToTheListOfMeds("Painkillers");
            Patient july = new Patient(id: 5, name: "July Hudson", age: 9, patientGender: "female", insurance: true);
            july.AddDiseaseToTheListOfDiseases("Stomach Ache");
            july.AddDiseaseToTheListOfDiseases("Diarrhea");
            july.AddMedToTheListOfMeds("Smecta");

            // Just an example of work of OutputPatientInfo function
            july.OutputPatientInfo();

            // Add Doctors and assign patients to them
            Doctor gregory = new Doctor(id: 1, age: 53, name: "Gregory House", gender: "male", specialty: "diagnostician", yearsOfExperience: 20, hasPHD: true);
            gregory.AddPatientToDoctorProfile(jack);
            gregory.AddPatientToDoctorProfile(marcus);
            Doctor jane = new Doctor(id: 2, age: 27, name: "Jane Markle", gender: "female", specialty: "dentist", yearsOfExperience: 4, hasPHD: false);
            jane.AddPatientToDoctorProfile(kate);
            jane.AddPatientToDoctorProfile(marcus);
            Doctor cox = new Doctor(id: 3, age: 54, name: "Perry Cox", gender: "male", specialty: "physician", yearsOfExperience: 20, hasPHD: true);
            cox.AddPatientToDoctorProfile(july);
            cox.AddPatientToDoctorProfile(ann);
            cox.AddPatientToDoctorProfile(marcus);

            // Just an example of work of OutPutDoctorInfo function
            cox.OutPutDoctorInfo();

            // Create an instance of the Hospital class
            var patients = new List<Patient> { jack, ann, kate, marcus, july };
            var doctors = new List<Doctor> { gregory, jane, cox };
            Hospital stPaulHospital = new Hospital(name: "St. Paul Hospital", patients: patients, doctors: doctors);

            // Get St. Paul Hospital budget after Patients Payments for visits
            Console.WriteLine($"Hospital's Budget After Patients Payments For Visits: {stPaulHospital.GetBudgetAfterPatientsPaymentsForVisits()}");

            // Doctor heals patient's disease
            cox.HealPatientDisease(july, "Stomach Ache");
            Console.WriteLine($"List of {july.GetName()}'s diseases after the visit to Dr.{cox.GetName()}: {String.Join(',', july.GetListOfDiseases())}");

            // Get St. Paul Hospital budget after Paying Salary To Doctors
            Console.WriteLine($"Hospital's Budget After Paying Salary To Doctors: {stPaulHospital.GetBudgetAfterPayingSalaryToDoctors()}");

            // Get St. Paul Hospital General Info
            stPaulHospital.OutputHospitalInfo();

            // Output St. Paul Hospital all doctors names
            stPaulHospital.OutPutAllDoctorsNames();

            // Output St. Paul Hospital all patients' names
            stPaulHospital.OutPutAllPatientNames();
        }
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
                listOfPatientNames.Add(patient.GetName());
            }
            Console.WriteLine("List of Patients:");
            Console.WriteLine(String.Join(',', listOfPatientNames));
        }

        public void OutPutAllDoctorsNames()
        {
            var listOfDoctorsNames = new List<string> { };
            foreach (var doctor in doctors)
            {
                listOfDoctorsNames.Add(doctor.GetName());
            }
            Console.WriteLine("List of Doctors:");
            Console.WriteLine(String.Join(',', listOfDoctorsNames));
        }

        public int GetBudgetAfterPayingSalaryToDoctors()
        {
            foreach (var doctor in doctors)
            {
                budget -= doctor.GetSalary();
            }

            return budget;
        }

        public int GetBudgetAfterPatientsPaymentsForVisits()
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
            Console.WriteLine($"Number Of Doctors: {doctors.Count}, Total Number Of Patients: {patients.Count}");
        }
    }
}
