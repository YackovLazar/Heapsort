using System.Collections.ObjectModel;
using Heapsort;

// for an array.
int[] array = { 1, 5, 2, 7, 3, 3, 4, 6, 8, 0 };
array.ArrayHeapSort();

for (int i = 0; i < array.Length; i++)
{
    Console.Write($"{array[i]} ");
}

Console.WriteLine("\n______");

// for a tree.
Node<int> last = new Node<int>(0);


BinaryTree<int> tree = new BinaryTree<int>(new Collection<int>
{ 1, 5, 2, 7, 3, 3, 4, 6, 8, 0 });

Console.WriteLine("_______");
Console.WriteLine(tree.FindLastEligible(tree.Root!)!.Value);
Console.WriteLine("_______");

var sorted = tree.BinarySort();

Console.WriteLine("_______");
sorted.ForEach(x => Console.Write($"{x} "));
Console.WriteLine("\n_______");