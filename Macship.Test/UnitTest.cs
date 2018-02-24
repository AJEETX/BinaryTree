using BinaryTree.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Macship.Test
{
    [TestClass]
    public class UnitTest
    {
        ITreeNode<string> root;
        ITreeNode<string> child1;
        ITreeNode<string> child2;
        ITreeNode<string> child3;
        ITreeNode<string> child4;
        ITreeNode<string> child5;
        ITreeNode<string> child6;
        [TestInitialize]
        public void TestInitialize()
        {
            root = new TreeNode<string>("top");
            child1 = root.AddChild("child1");
            child2 = root.AddChild("child2");
            child3 = root.AddChild("child3");
            child4 = child3.AddChild("child4");
            child5 = child4.AddChild("child5");
            child6 = child5.AddChild("child6");
        }

        [TestCleanup]
        public void Cleanup()
        {
            root = null;
            child1 = null;
            child2 = null;
            child3 = null;
            child4 = null;
            child5 = null;
            child6 = null;
        }
        [TestMethod]
        public void unit_test_get_the_farthest_depth_of_tree_correctly()
        {
            //arrange
            int expectedDepth = 5;
            //act
            int actualDepth = root.Depth.Count;
            //assert
            Assert.IsTrue(expectedDepth.Equals(actualDepth));
        }
        [TestMethod]
        public void unit_test_get_the_farthest_depth_of_tree_incorrectly()
        {
            //arrange
            int expectedDepth = 5;
            child6.AddChild("child7");
            //act
            int actualDepth = root.Depth.Count;
            //assert
            Assert.IsFalse(expectedDepth.Equals(actualDepth));
        }
        [TestMethod]
        public void unit_test_the_searched_item_found()
        {
            //arrange
            var searchedItem = "child4";
            //act
            var ItemFound = root.Search(searchedItem);
            //assert
            Assert.IsTrue(ItemFound);
        }
        [TestMethod]
        public void unit_test_the_searched_item_not_found()
        {
            //arrange
            var searchedItem = "child10";
            //act
            var ItemFound = root.Search(searchedItem);
            //assert
            Assert.IsFalse(ItemFound);
        }
    }
}
