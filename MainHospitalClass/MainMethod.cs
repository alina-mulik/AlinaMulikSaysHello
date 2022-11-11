using People;

namespace MainHospitalClass
{
    public class MainMethod
    {
        static void Main(string[] args)
        {
            // Add Patients with their diseases and meds prescribed
            var arrayOfMeds = new string[] {"Painkillers", "Smecta", "Coldrex", "Heparin"};
            var arrayOfDiseases = new string[] { "Allergy", "Cold", "Flu", "Diarrhea", "Headache", "Stomach Ache" };
            Person jack = new Patient(name: "Jack Jackson", id: 1, age: 32, gender: "male", insurance: true, smoking: true);
            Patient july = new Patient(name: "July Jackson", id: 1, age: 31, gender: "female", insurance: true, smoking: true);
            july.AddToThePatientArray(arrayOfDiseases[1], "disease");
            july.AddToThePatientArray(arrayOfMeds[2], "medication");
            july.AddToThePatientArray(arrayOfDiseases[0], "disease");
            july.AddToThePatientArray(arrayOfMeds[3], "medication");
            Patient monica = new Patient(name: "Monica Hudson", id: 1, age: 18, gender: "female", insurance: true);
            monica.AddToThePatientArray(arrayOfDiseases[0], "disease");
            monica.AddToThePatientArray(arrayOfMeds[3], "medication");
            Patient bob = new Patient(name: "Bob Parkinson", id: 1, age: 20, gender: "male", insurance: false, smoking: true);
            bob.AddToThePatientArray(arrayOfDiseases[0], "disease");
            bob.AddToThePatientArray(arrayOfMeds[3], "medication");
            Patient kate = new Patient(name: "Kate Parkinson", id: 1, age: 20, gender: "female", insurance: false);
            kate.AddToThePatientArray(arrayOfDiseases[3], "disease");
            kate.AddToThePatientArray(arrayOfMeds[1], "medication");
            Patient marcus = new Patient(name: "Marcus Lourence", id: 1, age: 25, gender: "male", insurance: true, drinking: true);
            marcus.AddToThePatientArray(arrayOfDiseases[4], "disease");
            marcus.AddToThePatientArray(arrayOfMeds[0], "medication");
            Patient laura = new Patient(name: "Laura Robertson", id: 1, age: 55, gender: "female", insurance: true);
            laura.AddToThePatientArray(arrayOfDiseases[4], "disease");
            laura.AddToThePatientArray(arrayOfMeds[0], "medication");
            Patient john = new Patient(name: "John Brown", id: 1, age: 70, gender: "male", insurance: true, drinking: true);
            john.AddToThePatientArray(arrayOfDiseases[4], "disease");
            john.AddToThePatientArray(arrayOfMeds[0], "medication");

            // Add Doctor and do not assign _patients to them - using the first constructor
            Doctor cox = new Doctor(id: 1, age: 54, name: "Perry Cox", gender: "male", specialty: "physician", yearsOfExperience: 20, hasPhd: true);
            var coxPatients = new Patient[] { (Patient)monica, july };
            cox.AddPatientsToDoctorProfile(coxPatients);
            cox.OutPutDoctorInfo();
            cox.AddPatientToDoctorProfile(marcus);
            cox.OutPutDoctorPatients();

            // Add Doctor and assign _patients to them - using the second constructor
            var gregorysPatients = new Patient[] { (Patient)jack, july, bob };
            Doctor gregory = new Doctor(id: 2, age: 53, name: "Gregory House", gender: "male", specialty: "diagnostician", yearsOfExperience: 20, hasPhd: true, patients: gregorysPatients);

            // Add 2 more patients to Gregory House
            var morePatientsForGregory = new Patient[] { laura, john };
            gregory.AddPatientsToDoctorProfile(morePatientsForGregory);
            gregory.OutPutDoctorInfo();

            // Add one more doctor
            var patients = new Patient[] { (Patient)jack, bob, kate, marcus, july, monica };
            var doctors = new Doctor[] { gregory, cox };

            // Create an instance of the Hospital class
            Hospital stPaulHospital = new Hospital(name: "St. Paul Hospital", budget: 1000000, patients: patients, doctors: doctors);

            // Get St. Paul Hospital _budget
            Console.WriteLine($"Hospital's Budget After Patients Payments For Visits: {stPaulHospital.GetBudget()}");


            // Doctor heals patient's disease
            cox.CurePatientDiseases(july);
            cox.DeletePatientFromDoctorProfile(july);
            cox.OutPutDoctorPatients();

            // Get St. Paul Hospital General Info
            stPaulHospital.OutputHospitalInfo();

            // Output St. Paul Hospital all _doctors names
            stPaulHospital.OutPutAllDoctorsNames();

            // Output St. Paul Hospital all _patients' names
            stPaulHospital.OutPutAllPatientNames();
        }
    }
}
