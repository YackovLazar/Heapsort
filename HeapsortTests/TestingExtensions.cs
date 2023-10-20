using System.Collections.ObjectModel;
using Heapsort;

namespace HeapsortTests;

public static class TestingExtensions
{

    public static bool Balanced<T>(this BinaryTree<T> tree, Node<T> node)
    {
        var right = node.Right?.Capacity ?? 0;
        var left = node.Left?.Capacity ?? 0;

        if (left == 0)
        {
            return right == 0;
        }

        if (node.Right == null)
        {
            return left == 0;
        }

        return tree.Balanced(node.Left!) && (left % 2 == 0 || right % 2 == 0) && tree.Balanced(node.Right!);
    }

    public static TestAssertions<T> Should<T>(this BinaryTree<T> tree)
    {
        return new TestAssertions<T>(tree);
    }

    public static bool IsInOrder<T>(this Collection<T> collection)  where T : IComparable<T>
    {
        for (var i = 0; i < collection.Count - 1; i++)
        {
            if (collection[i].CompareTo(collection[i + 1]) < 0)
            {
                return false;
            }
        }

        return true;
    }
}