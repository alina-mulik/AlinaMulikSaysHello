namespace People
{
    public class Patient : Person
    {
        private bool isSick;
        private bool isSmoking;
        private bool isDrinking;
        private bool hasInsurance;
        private string[] _takingMedsArray;
        private string[] _diseasesArray;

        internal string[] DiseasesArray { get { return _diseasesArray; } set { _diseasesArray = value; } }

        internal string[] MedsArray { get { return _takingMedsArray; } set { _takingMedsArray = value; } }

        public Patient(string name, int id, int age,  string gender, bool insurance, bool sick = true, bool smoking = false, bool drinking = false): base(name, age, id, gender)
        {
            isSick = sick;
            isSmoking = smoking;
            isDrinking = drinking;
            hasInsurance = insurance;
            _diseasesArray = new string[0];
            _takingMedsArray = new string[0];
        }

        public void OutputPatientInfo()
        {
            Console.WriteLine("Patient's Information:");
            Console.WriteLine($"{Id}, {GetName()}, {Age} years old, {Gender}, Is sick: {isSick}, \nHas insurance:{hasInsurance}, Smoking: {isSmoking}, Drinking: {isDrinking}.");
            Console.WriteLine($"List of diseases: {String.Join(',', _diseasesArray)}. \nList of meds: {String.Join(',', _takingMedsArray)}");
        }

        public void AddToThePatientArray(string name, string arrayName)
        {
            if (arrayName.ToLower() == "disease")
            {
                var arrayLength = _diseasesArray.Length + 1;
                Array.Resize(ref _diseasesArray, arrayLength);
                _diseasesArray.SetValue(name, _diseasesArray.Length - 1);
            }
            else if (arrayName.ToLower() == "medication")
            {
                var arrayLength = _takingMedsArray.Length + 1;
                Array.Resize(ref _takingMedsArray, arrayLength);
                _takingMedsArray.SetValue(name, _takingMedsArray.Length - 1);
            }
            else
            {
                Console.WriteLine($"An array with the names {arrayName} hasn't been found.");
            }
            Console.WriteLine($"A {arrayName} {name} has been added to {GetName()} profile.");
        }

        public string GetListOfDiseases()
        {
            var listOfDiseases = String.Join(',', _diseasesArray);

            return listOfDiseases;
        }

        public string GetListOfMeds()
        {
            var listOfMeds = String.Join(',', _takingMedsArray);

            return listOfMeds;
        }

        public void RemoveFromThePatientArray(string[] names, string diseaseOrMedication)
        {
            switch (diseaseOrMedication)
            {
                case "disease":
                    foreach (var item in names)
                    {
                        for (int a = Array.IndexOf(_diseasesArray, item); a < _diseasesArray.Length - 1; a++)
                        {
                            _diseasesArray[a] = _diseasesArray[a + 1];
                        }
                        Array.Resize(ref _diseasesArray, _diseasesArray.Length - 1);
                        Console.WriteLine($"A {diseaseOrMedication} has been removed from patient's {GetName()} profile.");
                    }
                    break;
                case "medication":
                    foreach (var item in names)
                    {
                        for (int a = Array.IndexOf(_takingMedsArray, item); a < _takingMedsArray.Length - 1; a++)
                        {
                            _takingMedsArray[a] = _takingMedsArray[a + 1];
                        }
                        Array.Resize(ref _takingMedsArray, _takingMedsArray.Length - 1);
                    }
                    break;
                default:
                    Console.WriteLine($"An array with the names {diseaseOrMedication} hasn't been found.");
                    break;
            }
        }
    }
}
