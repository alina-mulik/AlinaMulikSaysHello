namespace People
{
    public class Doctor : Person
    {
        private const int PerPatientBonus = 100;
        private const int QualifiedDoctorPayment = 15000;
        private const int UnderQualifiedDoctorPayment = 1000;
        private string _specialty;
        private int _yearsOfExperience;
        private bool _hasPhd;
        private int _salary;
        private Patient[] _patientsArray;

        public Doctor(string name, string gender, int age, int id, string specialty, int yearsOfExperience, bool hasPhd) : base(name, age, id, gender)
        {
            _specialty = specialty.ToLower();
            _yearsOfExperience = yearsOfExperience;
            _hasPhd = hasPhd;
        }

        public Doctor(string name, string gender, int age, int id, string specialty, int yearsOfExperience, bool hasPhd, Patient[] patients) : this( name, gender, age, id, specialty, yearsOfExperience, hasPhd)
        {
            _patientsArray = patients;
        }

        public int GetSalary()
        {
            if (_hasPhd && _yearsOfExperience > 5 || _specialty == "surgeon" || _specialty == "dentist")
            {
                _salary = QualifiedDoctorPayment + (_patientsArray.Length * PerPatientBonus);
            }
            else
            {
                _salary = UnderQualifiedDoctorPayment * _yearsOfExperience + (_patientsArray.Length * PerPatientBonus);
            }

            return _salary;
        }

        public void OutPutDoctorInfo()
        {
            Console.WriteLine("Doctor's Information:");
            Console.WriteLine($"{Id}, {Name}, {Age} years old, Gender: {Gender}, Salary: {GetSalary()}, Has PHD: {_hasPhd}, \nYears Of Experience: {_yearsOfExperience}, Specialization: {_specialty}");
            Console.WriteLine($"List of Patients: {String.Join(',', GetArrayOfNames(_patientsArray))}");
            Console.WriteLine("------------------");
        }

        public void OutPutDoctorPatients()
        {
            Console.WriteLine($"List of Patients of Dr.{Name}: {String.Join(',', GetArrayOfNames(_patientsArray))}");
            Console.WriteLine("------------------");
        }

        public new string GetName()
        {
            return "Dr. " + Name;
        }

        public void AddPatientsToDoctorProfile(Patient[] patients)
        {
            if (_patientsArray != null)
            {
                foreach (Person patient in patients)
                {
                    if (_patientsArray.Contains(patient))
                    {
                        continue;
                    }
                    else
                    {
                        var arrayLength = _patientsArray.Length + 1;
                        Array.Resize(ref _patientsArray, arrayLength);
                        _patientsArray.SetValue(patient, _patientsArray.Length - 1);
                    }
                }
            }
            else
            {
                _patientsArray = patients;
            }
        }

        public void AddPatientToDoctorProfile(Patient patient)
        {
            var arrayLength = _patientsArray.Length + 1;
            Array.Resize(ref _patientsArray, arrayLength);
            _patientsArray.SetValue(patient, _patientsArray.Length - 1);
            Console.WriteLine($"Patient {patient.GetName()} has been added to {GetName()} Patients.");
        }

        public void DeletePatientFromDoctorProfile(Patient patient)
        {
            for (int a = Array.IndexOf(_patientsArray, patient); a < _patientsArray.Length - 1; a++)
            {
                _patientsArray[a] = _patientsArray[a + 1];
            }
            Array.Resize(ref _patientsArray, _patientsArray.Length - 1);
            Console.WriteLine($"Patient {patient.GetName()} has been removed from {GetName()} Patients.");
        }

        public void CurePatientDiseases(Patient patient)
        {
            var patientName = patient.GetName();
            Console.WriteLine("--------At the Doctor's Office----------");
            Console.WriteLine($"{patientName} came to the {GetName()} office.");
            Console.WriteLine($"Doctor noticed patient's diseases! It's {patient.GetListOfDiseases()}!");
            Console.WriteLine($"Doctor is giving a {patient.GetListOfMeds()} to the {patientName}!");
            patient.RemoveFromThePatientArray(patient.DiseasesArray, "disease");
            Console.WriteLine($"Now the {patientName} is healthy and can go home.");
            Console.WriteLine("------------------");
        }
    }
}
