namespace Heapsort;

public class Node<T>
{
    public T Value { get; set; } = default!;
    public Node<T>? Left { get; set; }
    public Node<T>? Right { get; set; }
    public bool IsSet { get; set; } = false;
    public int Capacity => (Left == null || Left.IsSet ? 0 : 1 + Left.Capacity) + (Right == null || Right.IsSet ? 0 : 1 + Right.Capacity);

    public Node(T value)
    {
        Value = value;
    }

    public Node()
    {
        
    }

    public void Reset()
    {
        IsSet = false;
        Right?.Reset();
        Left?.Reset();
    }

    public Node<T> AsNextNode(Node<T> next)
    {
        if (Left == null)
        {
            Left = next;
            return Left;
        }
        else if (Right == null)
        {
            Right = next;
            return Right;
        }

        throw new ArgumentException($"The node {this.Value} has a Right of {this.Right.Value} and a Left of {this.Left.Value}");
    }

    public Node<T> NextNode()
    {
        if (Left != null)
        {
            return Left;
        }
        else if (Right != null)
        {
            return Right;
        }
        else
        {
            return null;
        }
    }   

    public void Heapify()
    {
        if (Left is { IsSet: false })
        {
            Left.Heapify();
            if (Right is { IsSet: false })
            {
                Right.Heapify();
                if (Comparer<T>.Default.Compare(Left.Value, Right.Value) > 0)
                {
                    if (Comparer<T>.Default.Compare(Left.Value, Value) > 0)
                    {
                        (Value, Left.Value) = (Left.Value, Value);
                        Left.Heapify();
                    }
                }
                else
                {
                    if (Comparer<T>.Default.Compare(Right.Value, Value) > 0)
                    {
                        (Value, Right.Value) = (Right.Value, Value);
                        Right.Heapify();
                    }
                }
            }
            else
            {
                if (Comparer<T>.Default.Compare(Left.Value, Value) > 0)
                {
                    (Value, Left.Value) = (Left.Value, Value);
                    Left.Heapify();
                }
            }
        }
    }

    public string Print()
    {
        return $"{Value} {(Left != null ? Left.Print() : "")}{(Right != null ? Right.Print() : "")}\n";
    }
}