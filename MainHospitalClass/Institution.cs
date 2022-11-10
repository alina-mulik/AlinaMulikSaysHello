namespace MainHospitalClass
{
    public class Institution
    {
        private string _name;
        private int _budget;

        public Institution(string name, int budget)
        {
            _name = name;
            _budget = budget;
        }

        public virtual int GetBudget()
        {
            return _budget;
        }
    }
}
