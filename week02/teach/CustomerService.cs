using Microsoft.VisualBasic;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases
        // Test 1
        // Scenario: Add one customer serve one cusomer.
        // Expected Result: Customer gets added then removed from the queue with a size of 10. (queue size un-applicable)
        Console.WriteLine("Test 1");
        var service = new CustomerService(10);
        service.AddNewCustomer();
        service.ServeCustomer();
        // ResultL: Index was out of range



        // Defect(s) Found: we were removing the customer before assigning it to a variable which lead to removing where the customer used to be not where it was in the queue. 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers, then serve two customers
        // Expected Result: They get served in the correct order.
        Console.WriteLine("Test 2");
        service = new CustomerService(5);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.ServeCustomer();
        service.ServeCustomer();

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Add six customers to a queue that should only hold five.
        // Expected Result: I get an error saying the Queue is full. 
        Console.WriteLine("Test 3");
        service = new CustomerService(5);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();



        // Defect(s) Found: The queue was set to check if the queue was bigger than the max size when it should have been checking if they were equal. 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below



    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count == _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        Console.WriteLine(_queue.Count());
        var customer = _queue[0]; // this was happening after _queue.RemoveAt(0) which meant it was trying to remove a customer before saving it, so I would end up grabbing where the customer used to be but because there was only one customer, there was nothing there to grab. 
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}