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

        [Test]
        public void InsertValuesIntoBinTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>(33, null);
            tree.add(5);
            tree.add(35);
            tree.add(1);
            tree.add(20);
            tree.add(99);
            tree.add(17);
            tree.add(18);
            tree.add(19);
            tree.add(31);
            tree.add(4);
            Assert.AreEqual(33, tree.val);
        }
        
        [Test]
        public void InsertThreeValuesIntoBinTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>(33, null);
            tree.add(5);
            tree.add(35);
            Assert.AreEqual(33, tree.val);
            Assert.AreEqual(5, tree.left.val);
            Assert.AreEqual(35, tree.right.val);
        }
        
        [Test]
        public void SearchValueIntoBinTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>(33, null);
            tree.add(5);
            tree.add(35);
            tree.add(1);
            tree.add(20);
            tree.add(99);
            tree.add(17);
            tree.add(18);
            tree.add(19);
            tree.add(31);
            tree.add(4);
            Assert.AreEqual(18, tree.search(18).val);
            Assert.AreEqual(null, tree.search(40));
        }
        
    }
}