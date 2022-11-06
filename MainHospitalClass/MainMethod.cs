using People;

namespace MainHospitalClass
{
    public class MainMethod
    {
        static void Main(string[] args)
        {
            // Add Patients with their diseases and meds prescribed
            string jack = "Jack Jackson";
            string july = "July Jackson";
            string monica = "Monica Hudson";
            string bob = "Bob Parkinson";
            string kate = "Kate Parkinson";
            string marcus = "Marcus Lourence";
            string laura = "Laura Robertson";
            string john = "John Brown";

            // Add Doctor and do not assign _patients to them - using the first constructor
            Doctor cox = new Doctor(id: 1, age: 54, name: "Perry Cox", gender: "male", specialty: "physician", yearsOfExperience: 20, hasPhd: true);
            var coxPatients = new string[] { monica, july };
            cox.AddPatientsToDoctorProfile(coxPatients);
            cox.OutPutDoctorInfo();
            cox.AddPatientToDoctorProfile(marcus);
            cox.OutPutDoctorPatients();

            // Add Doctor and assign _patients to them - using the second constructor
            var gregorysPatients = new string[] { jack, july, bob };
            Doctor gregory = new Doctor(id: 2, age: 53, name: "Gregory House", gender: "male", specialty: "diagnostician", yearsOfExperience: 20, hasPhd: true, patients: gregorysPatients);

            // Add 2 more patients to Gregory House
            var morePatientsForGregory = new string[] { laura, john };
            gregory.AddPatientsToDoctorProfile(morePatientsForGregory);
            gregory.OutPutDoctorInfo();

            // Create an instance of the Hospital class
            var patients = new string[] { jack, bob, kate, marcus, july, monica };
            var doctors = new Doctor[] { gregory, cox };
            Hospital stPaulHospital = new Hospital(name: "St. Paul Hospital", patients: patients, doctors: doctors);

            // Get St. Paul Hospital _budget after Patients Payments for visits
            Console.WriteLine($"Hospital's Budget After Patients Payments For Visits: {stPaulHospital.GetBudgetAfterPatientsPaymentsForVisits(8)}");

            // Get St. Paul Hospital _budget after Paying Salary To Doctors
            Console.WriteLine($"Hospital's Budget After Paying Salary To Doctors: {stPaulHospital.GetBudgetAfterPayingSalaryToDoctors()}");


            // Doctor heals patient's disease
            cox.CurePatientDisease(july, "Stomach Ache");
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
