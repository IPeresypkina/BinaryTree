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
        
        [Test]
        public void SearchIntoBinTree()
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
        
        [Test]
        public void DeleteLeftValueIntoBinTree()
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

        [Test]
        public void DeleteSheetIntoBinTree() //удаление листа
        {
            BinaryTree<int> tree = new BinaryTree<int>(33, null);
            tree.add(5);
            tree.add(35);
            tree.add(1);
            tree.add(20);
            tree.add(99);
            tree.add(34);
            tree.remove(99); //удаление листа (правого)
            Assert.AreEqual(null, tree.search(99));
            tree.remove(1); //удаление листа (левого)
            Assert.AreEqual(null, tree.search(1));
        }
        
        [Test]
        public void DeleteNodeHasOneSubtreeIntoBinTree() //удаление узла имеющее одно поддерево
        {
            BinaryTree<int> tree = new BinaryTree<int>(33, null);
            tree.add(5);
            tree.add(88);
            tree.add(1);
            tree.add(20);
            tree.add(99);
            tree.add(70);
            tree.add(17);
            tree.add(18);
            tree.add(19);
            tree.add(60);
            tree.add(63);
            tree.add(65);
            tree.remove(20); //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            Assert.AreEqual(null, tree.search(20));
            tree.remove(17); //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            Assert.AreEqual(null, tree.search(17));
            tree.remove(70); //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            Assert.AreEqual(null, tree.search(70));
            tree.remove(60); //Удаление узла, имеющего правое поддерево(, но не имеющее левого поддерева
            Assert.AreEqual(null, tree.search(60));
        }
        
        [Test]
        public void DeleteNodeHasBouthSubtreeIntoBinTree() //удаление узла имеющее оба поддерева
        {
            BinaryTree<int> tree = new BinaryTree<int>(33, null);
            tree.add(5);
            tree.add(35);
            tree.add(1);
            tree.add(99);
            tree.add(97);
            tree.add(98);
            tree.add(31);
            tree.add(4);
            tree.add(34);
            tree.add(100);
            //Удаляем узел, имеющий поддеревья с обеих сторон
            //Первый случай (Правое поддерево имеет своих потомков.)
            tree.remove(35); 
            Assert.AreEqual(null, tree.search(35));
            //Второй случай (Правое поддерево не имеет потомка.)
            tree.remove(5); 
            Assert.AreEqual(null, tree.search(5));
        }
        
        [Test]
        public void DeleteNonexistentNodeIntoBinTree() //удаляем не существующий узел
        {
            BinaryTree<int> tree = new BinaryTree<int>(33, null);
            tree.add(5);
            tree.add(35);
            tree.add(1);
            Assert.AreEqual(false, tree.remove(2));
        }
        
        [Test]
        public void DeleteRootIntoBinTree() //удаляем корень
        {
            BinaryTree<int> tree = new BinaryTree<int>(33, null);
            tree.add(5);
            tree.add(1);
            tree.add(35);
            tree.remove(33); 
            Assert.AreEqual(null, tree.search(33));
            tree.remove(35); 
            Assert.AreEqual(null, tree.search(35));
        }
    }
}