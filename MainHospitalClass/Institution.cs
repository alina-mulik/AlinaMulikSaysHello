namespace MainHospitalClass
{
    public class Institution
    {
        protected string _name;
        protected int _budget;

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
