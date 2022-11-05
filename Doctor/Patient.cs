namespace People
{
    public class Patient : Person
    {
        private bool isSick;
        private bool isSmoking;
        private bool isDrinking;
        private bool hasInsurance;
        private List<string> takingMedsList;
        private List<string> diseasesList;
        public Patient(int id, string name, int age, string patientGender, bool insurance, bool sick = true, bool smoking = false, bool drinking = false)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.takingMedsList = new List<string>();
            this.diseasesList = new List<string>();
            this.Gender = patientGender.ToLower();
            this.isSick = sick;
            this.isSmoking = smoking;
            this.isDrinking = drinking;
            this.hasInsurance = insurance;
        }
        public void OutputPatientInfo()
        {
            Console.WriteLine("Patient's Information:");
            Console.WriteLine($"{Id}, {Name}, {Age} years old, {Gender}, Is sick: {isSick}, \nHas insurance:{hasInsurance}, Smoking: {isSmoking}, Drinking: {isDrinking}.");
            Console.WriteLine($"List of diseases: {String.Join(',', diseasesList)}. \nList of meds: {String.Join(',', takingMedsList)}");
        }

        public List<string> GetListOfDiseases() { return diseasesList; }

        public void AddDiseaseToTheListOfDiseases(string diseaseName) { diseasesList.Add(diseaseName.ToLower()); }

        public void RemoveDiseaseFromTheListOfDiseases(string diseaseName) { diseasesList.Remove(diseaseName.ToLower()); }

        public List<string> GetListOfMeds() { return takingMedsList; }

        public void AddMedToTheListOfMeds(string medName) { takingMedsList.Add(medName); }
    }
}
