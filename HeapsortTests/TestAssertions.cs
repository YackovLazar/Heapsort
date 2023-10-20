using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Heapsort;

namespace HeapsortTests;

public class TestAssertions<T> : ReferenceTypeAssertions<BinaryTree<T>, TestAssertions<T>>
{
    public TestAssertions(BinaryTree<T> subject) : base(subject)
    {
        
    }

    protected override string Identifier { get; } = "BinaryTree";

    [CustomAssertion]
    public AndConstraint<TestAssertions<T>> BeBalanced()
    {
        Execute.Assertion
            .ForCondition(Subject.Balanced<T>(Subject.Root ?? new Node<T>()))
            .FailWith($"Expected {Subject} to be balanced, but it was not.");

        return new AndConstraint<TestAssertions<T>>(this);
    }
}