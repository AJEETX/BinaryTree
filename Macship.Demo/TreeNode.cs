using System.Collections.Generic;

namespace Macship.Demo
{
    public interface ITreeNode<T>
    {
        ITreeNode<T> AddChild(T nodeData);
        bool Search(T value);
        List<ITreeNode<T>> Depth { get; }
        T Data { get; }
        List<ITreeNode<T>> Children { get; }
    }
    public class TreeNode<T>: ITreeNode<T>
    {
        private T _nodeData;
        private List<ITreeNode<T>> _childNodes;

        public TreeNode(T nodeData)
        {
            this._nodeData = nodeData;
            this._childNodes = new List<ITreeNode<T>>();
        }

        public T Data
        {
            get { return this._nodeData; }
        }

        public List<ITreeNode<T>> Children
        {
            get { return this._childNodes; }
        }

        public ITreeNode<T> AddChild(T nodeData)
        {
            var newNode = new TreeNode<T>(nodeData);
            this._childNodes.Add(newNode);
            return newNode;
        }

        public override string ToString()
        {
            return this._nodeData.ToString();
        }
        public bool Search(T value)
        {
            foreach (var node in Children)
            {
                var resultfound=Find(node, value);
                if (resultfound != null)
                    return true;//found the matching result
            }

            // if we reached here, we didn't find a matching node
            return false;
        }
        private ITreeNode<T> Find(ITreeNode<T> node, T value)
        {
            if (node.Data.ToString().Equals(value.ToString()))
                return node;

            foreach (var child in node.Children)
            {
                var result = Find(child, value);
                if (result != null)
                    return result;
            }

            return null;
        }
        public List<ITreeNode<T>> Depth
        {
            get
            {
                var path = new List<ITreeNode<T>>();
                foreach (var node in _childNodes)
                {
                    var tmp = node.Depth;
                    if (tmp.Count > path.Count)
                        path = tmp;
                }
                path.Insert(0, this);
                return path;
            }
        }
    }
}
