namespace BinaryTree.Core
{
    public interface IEmployee
    {
        string Name { get; }
    }
    public class Employee:IEmployee
    {
        private string _name = null;

        public Employee(string name)
        {
            this._name = name;
        }
        
        public string Name
        {
            get { return this._name; }
        }

        public override string ToString()
        {
            return this._name;
        }
    }
}
