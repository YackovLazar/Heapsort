using System.Collections.ObjectModel;
using FluentAssertions;
using Heapsort;

namespace HeapsortTests
{
    public class UnitTest1
    {
        private BinaryTree<int> tree;

        public UnitTest1()
        {
            tree = new BinaryTree<int>(new Collection<int>
            { 1, 5, 2, 7, 3, 3, 4, 6, 8, 0 });
        }

        [Fact]
        public void HeapifyTest()
        {
            tree.Root!.Heapify();

            for (var root = tree.Root; root != null; root = root.NextNode())
            {
                root.Value.Should().BeGreaterOrEqualTo(root.Right?.Value ?? int.MinValue);
                root.Value.Should().BeGreaterOrEqualTo(root.Left?.Value ?? int.MinValue);
            }

            tree.Should().BeBalanced();
        }

        public static IEnumerable<object[]> TreeContents()
        {
            yield return new object[]{ new Collection<int> { 7, 2, 0, 5, 4, 3, 10 } };
            yield return new object[]{ new Collection<int> { 8, 2, 0, 5, 4, 3, 10, 11 } };
            yield return new object[]{ new Collection<int> { 9, 2, 0, 5, 4, 3, 10, 11, 12 } };
            yield return new object[]{ new Collection<int> { 4, 2, 0, 5 } };
            yield return new object[]{ new Collection<int> { 1}};
            yield return new object[]{ new Collection<int> { } };
        }

        [Theory]
        [MemberData(nameof(TreeContents))]
        public void TreeifyTest(Collection<int> treeContent)
        {
            tree = new BinaryTree<int>(treeContent);

            tree.Should().BeBalanced();
        }

        [Theory]
        [MemberData(nameof(TreeContents))]
        public void BinarySortTest(Collection<int> treeContent)
        {
            tree = new BinaryTree<int>(treeContent);

            var ordered = tree.BinarySort();

            tree.Should().BeBalanced();
            ordered.Should().BeInDescendingOrder();
        }
        
        
    }
}