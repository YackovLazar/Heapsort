using FluentAssertions;
using Heapsort;

namespace HeapsortTests
{
    public class UnitTest1
    {
        private BinaryTree<int> tree;

        public UnitTest1()
        {
            tree = new BinaryTree<int>
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
                                Value = 8,
                                IsSet = true
                            }
                        },
                        Right = new Node<int>
                        {
                            Value = 3,
                            Left = new Node<int>
                            {
                                Value = 0,
                                IsSet = true
                            }
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
                }
            };

        }

        [Fact]
        public void HeapifyTest()
        {
            tree.Root!.Heapify();
            tree.Should();

            for (var root = tree.Root; root != null; root = root.NextNode())
            {
                root.Value.Should().BeGreaterOrEqualTo(root.Right?.Value ?? int.MinValue);
                root.Value.Should().BeGreaterOrEqualTo(root.Left?.Value ?? int.MinValue);
            }
        }
        
    }
}