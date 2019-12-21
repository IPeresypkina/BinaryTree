using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using BinTree;

namespace BinTree.TestBinary
{
    [TestFixture]
    public class TreeTest
    {
        [Test]
        public void CreateBinTree()
        {
            //Создадим дерево с корневым элементом 33
            BinaryTree<int> tree = new BinaryTree<int>(33, null);
            Assert.AreEqual(33, tree.val);
            Assert.True(tree.left == null); 
            Assert.True(tree.right == null); 
            Assert.True(tree.parent == null); 
        }
    }
}