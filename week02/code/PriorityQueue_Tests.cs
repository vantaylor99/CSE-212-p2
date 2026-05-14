using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: send in 3 items with the following priorities: 1, 2, 3 and dequeue them in the order of the priority
    // Expected Result: Bill, Tom, Suzzy
    // Defect(s) Found: The dequeue method was not returning the item with the highest priority
    public void TestPriorityQueue_1()
    {
        var bill = new PriorityItem("Bill", 1);
        var tom = new PriorityItem("Tom", 2);
        var suzzy = new PriorityItem("Suzzy", 3);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bill.Value, bill.Priority);
        priorityQueue.Enqueue(tom.Value, tom.Priority);
        priorityQueue.Enqueue(suzzy.Value, suzzy.Priority);

        Debug.WriteLine(priorityQueue.Dequeue());
        Debug.WriteLine(priorityQueue.Dequeue());
        Debug.WriteLine(priorityQueue.Dequeue());

        string[] expectedResult = [suzzy.Value, tom.Value, bill.Value];
        Debug.WriteLine(string.Join(", ", expectedResult));
        Assert.AreEqual(priorityQueue.ToString(), string.Join(", ", priorityQueue.ToString()));
    }

    [TestMethod]
    // Scenario: send in 4 items with the following priorities: 1, 2, 3, 3 and dequeue them in the order of the priority
    // Expected Result: Stacy, Suzzy, Tom, Bill
    // Defect(s) Found: The dequeue method was not returning the item with the highest priority
    public void TestPriorityQueue_2()
    {
        var bill = new PriorityItem("Bill", 2);
        var tom = new PriorityItem("Tom", 1);
        var suzzy = new PriorityItem("Suzzy", 2);
        var stacy = new PriorityItem("Stacy", 3);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bill.Value, bill.Priority);
        priorityQueue.Enqueue(tom.Value, tom.Priority);
        priorityQueue.Enqueue(suzzy.Value, suzzy.Priority);
        priorityQueue.Enqueue(stacy.Value, stacy.Priority);


        string[] actualResult =
        [
        priorityQueue.Dequeue(),
        priorityQueue.Dequeue(),
        priorityQueue.Dequeue(),
        priorityQueue.Dequeue()
        ];



        string[] expectedResult =
        [
            stacy.Value,
            bill.Value,
            suzzy.Value,
            tom.Value
        ];

        Debug.WriteLine(string.Join(", ", expectedResult));
        CollectionAssert.AreEqual(expectedResult, actualResult);
    }
}