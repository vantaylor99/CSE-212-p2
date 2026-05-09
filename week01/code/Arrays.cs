using Microsoft.VisualBasic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /// First, create an array the size of <param name="length -1"> called <param name="results"> 
        /// Next, create a while statement that will stop the function when the <param name="length"> is equal to the <param name="multiplesCount"> variable.
        /// Next, multiply the <param name="number"> variable by <param name="multiplesCount">
        /// In the same loop insert the answer into the associating <param name="multiplesCount" -1> into the <param name="results"> arary.

        var results = new double[length];
        var multiplesCount = 1;
        while (multiplesCount <= length)
        {
            results[multiplesCount - 1] = (number * multiplesCount);
            multiplesCount++;
        }

        return results; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        /// First, cut the list where the <param name="amount"> value is located and assign that to a variable named <param name="cut">
        /// Next, create a variable <param name="firstHalf"> and slice the data using the cut and assign it to this variable
        /// Next, use .RemoveRange to remove the firsthalf from the original list, and then use .AddRange to add the values in the variable firstHalf to the remaining slots of the list. 

        var cut = data.Count() - amount;
        var firsthalf = data.Slice(0, cut);

        data.RemoveRange(0, cut);
        data.AddRange(firsthalf);

    }
}
