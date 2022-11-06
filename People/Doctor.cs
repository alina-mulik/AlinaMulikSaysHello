namespace People
{
    public class Doctor
    {
        private const int PerPatientBonus = 100;
        private const int QualifiedDoctorPayment = 15000;
        private const int UnderQualifiedDoctorPayment = 1000;
        private string _name;
        private int _age;
        private int _id;
        private string _gender;
        private string _specialty;
        private int _yearsOfExperience;
        private bool _hasPhd;
        private int _salary;
        private string[] _patientsArray;

        public Doctor(string name, string gender, int age, int id, string specialty, int yearsOfExperience, bool hasPhd)
        {
            _name = name;
            _gender = gender.ToLower();
            _age = age;
            _id = id;
            _specialty = specialty.ToLower();
            _yearsOfExperience = yearsOfExperience;
            _hasPhd = hasPhd;
        }

        public Doctor(string name, string gender, int age, int id, string specialty, int yearsOfExperience, bool hasPhd, string[] patients) : this( name, gender, age, id, specialty, yearsOfExperience, hasPhd)
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
            Console.WriteLine($"{_id}, {_name}, {_age} years old, Salary: {GetSalary()}, {_gender}, Has PHD: {_hasPhd}, \nYears Of Experience: {_yearsOfExperience}, Specialization: {_specialty}");
            Console.WriteLine($"List of Patients: {String.Join(',', _patientsArray)}");
            Console.WriteLine("------------------");
        }

        public void OutPutDoctorPatients()
        {
            Console.WriteLine($"List of Patients of Dr.{_name}: {String.Join(',', _patientsArray)}");
            Console.WriteLine("------------------");
        }

        public string GetDoctorName() { return _name; }

        public string[] GetListOfPatients() { return _patientsArray; }

        public void AddPatientsToDoctorProfile(string[] patients)
        {
            if (_patientsArray != null)
            {
                foreach (string patient in patients)
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

        public void AddPatientToDoctorProfile(string patient)
        {
            var arrayLength = _patientsArray.Length + 1;
            Array.Resize( ref _patientsArray, arrayLength);
            _patientsArray.SetValue(patient, _patientsArray.Length - 1);
            Console.WriteLine($"Patient {patient} has been added to Dr.{GetDoctorName()} Patients.");
        }

        public void DeletePatientFromDoctorProfile(string patient)
        {
            for (int a = Array.IndexOf(_patientsArray, patient); a < _patientsArray.Length - 1; a++)
            {
                _patientsArray[a] = _patientsArray[a + 1];
            }
            Array.Resize(ref _patientsArray, _patientsArray.Length - 1);
            Console.WriteLine($"Patient {patient} has been removed from Dr.{GetDoctorName()} Patients.");
        }

        public void CurePatientDisease(string patient, string disease)
        {
            Console.WriteLine("--------At the Doctor's Office----------");
            Console.WriteLine($"{patient} came to the doctor's {this._name} office.");
            Console.WriteLine($"Doctor noticed patient's disease! It's {disease}!");
            Console.WriteLine($"Doctor is giving a cure to the {patient}!");
            Console.WriteLine($"Now the {patient} is healthy and can go home.");
            Console.WriteLine("------------------");
        }
    }
}
