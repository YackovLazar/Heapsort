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


BinaryTree<int> tree = new BinaryTree<int>
{
    Root = new Node<int>
    {
        Value = 1,
        Left = new Node<int>
        {
            Value = 5,
            Left = new Node<int>
            {
                Value = 7,
                Left = new Node<int>
                {
                    Value = 6
                },
                Right = new Node<int>
                {
                    Value = 8
                }
            },
            Right = new Node<int>
            {
                Value = 3,
                Left = last
            }
        },
        Right = new Node<int>
        {
            Value = 2,
            Left = new Node<int>
            {
                Value = 3
            },
            Right = new Node<int>
            {
                Value = 4,
            }
        }
    },
    Last = last
};

Console.WriteLine("_______");
Console.WriteLine(tree.FindLastEligible(tree.Root!)!.Value);
Console.WriteLine("_______");

tree.BinarySort();

Console.WriteLine("_______");