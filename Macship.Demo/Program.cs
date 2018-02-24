using System;
using BinaryTree.Core;
namespace BinaryTree.Demo
{
    class Program
    {
        ITreeNode<IEmployee> rootNode,child11,child12,child13,child21,child22,child31,child41,child42,child51,child52;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.run();
        }
        void run()
        {
            var owner = new Employee("owner");
            var president = new Employee("president");
            var cfo = new Employee("cfo");
            var coo = new Employee("coo");
            var ceo = new Employee("ceo");
            var hr = new Employee("hr");
            var it = new Employee("it");
            var admin = new Employee("admin");
            var mrkting = new Employee("mrkting");
            var vendor = new Employee("vendor");
            var contractor = new Employee("contractor");

            var external = new Employee("external");

            rootNode = new TreeNode<IEmployee>(owner);
            child11 = rootNode.AddChild(president);
            child12 = rootNode.AddChild(cfo);
            child13 = rootNode.AddChild(coo);
            child21 = child11.AddChild(ceo);
            child22 = child11.AddChild(hr);
            child31 = child21.AddChild(it);
            child41 = child31.AddChild(admin);
            child42 = child31.AddChild(mrkting);
            child51 = child42.AddChild(vendor);
            child52 = child42.AddChild(contractor);

            int depth = rootNode.Depth.Count;
            Console.WriteLine("The furthest depth in the tree is {0}", depth);
            var val = rootNode.Search(it);
            Console.WriteLine("The Searched item '{0}' is found in the tree:{1} ",it,val);
            val = rootNode.Search(external);
            Console.WriteLine("The Searched item '{0}' is found in the tree:{1} ", external, val);
            Console.ReadKey();
        }
    }
}
