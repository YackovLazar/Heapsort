using System.Collections;

namespace Heapsort;

public class BinaryTree<T>
{
    public Node<T>? Root { get; set; }
    public Node<T>? Last;


    public Node<T>? FindLastEligible(Node<T>? node)
    {
        if (node == null || node.IsSet)
        {
            return null;
        }

        Console.WriteLine($"Node: {node.Value}");
        var right = node.Right?.Capacity ?? 0;
        Console.WriteLine($"Right: {right}");
        if (right % 2 != 0)
        {
            Console.WriteLine("RIGHT");
            return FindLastEligible(node.Right) ?? node;
        }

        var left = node.Left?.Capacity ?? 0;
        Console.WriteLine($"Left: {left}");
        if (left % 2 != 0)
        {
            Console.WriteLine("LEFT");
            return FindLastEligible(node.Left) ?? node;
        }

        if (left == right && !(node.Right?.IsSet ?? false))
        {
            Console.WriteLine("RIGHT");
            return FindLastEligible(node.Right) ?? node;
        }

        Console.WriteLine("LEFT");
        return FindLastEligible(node.Left) ?? node;
    }

    public Node<T>? FindNextEmptyNode(Node<T>? node)
    {
        if (node?.Capacity < 2)
        {
            return node;
        }

        var right = node?.Right?.Capacity ?? 0;
        if (right % 2 != 0)
        {
            return FindNextEmptyNode(node?.Right) ?? node;
        }

        var left = node?.Left?.Capacity ?? 0;
        if (left % 2 != 0)
        {
            return FindNextEmptyNode(node?.Left) ?? node;
        }

        if (left > right && (right - left) % 2 != 0)
        {
            return FindNextEmptyNode(node?.Right) ?? node;
        }

        return FindNextEmptyNode(node?.Left) ?? node;
    }

    public void BinarySort()
    {
        Node<T>? last = null;

        Root!.Heapify();
        while (!Root.IsSet)
        {

            Root.Heapify();
            Console.WriteLine($"Swap: {Root.Value} : {Last!.Value}");
            (Root.Value, Last!.Value) = (Last.Value, Root.Value);
            last ??= Last;
            Last!.IsSet = true;
            Console.WriteLine($"Set: {Last.Value}");
            Console.WriteLine("_______");

            Last = FindLastEligible(Root);
        }

        Root.Reset();

        Last = last;
        Console.WriteLine("_______");
        Console.WriteLine($"Last: {Last!.Value}");
        Console.WriteLine("DONE");
    }
}