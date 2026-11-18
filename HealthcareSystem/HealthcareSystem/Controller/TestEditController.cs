using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

/// <summary>
///     The test edit controller class responsible for managing editting tests.
/// </summary>
public class TestEditController
{
    #region Fields

    private readonly TestEditDal testOrderDAL;
    private const decimal MaxResult = 99999999m;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="TestEditController"/> class.
    /// </summary>
    /// <param name="testOrderDAL">The test order dal.</param>
    public TestEditController(TestEditDal testOrderDAL)
    {
        this.testOrderDAL = testOrderDAL;
    }

    #endregion

    #region Methods
    /// <summary>
    ///     Retrieves all ordered tests.
    /// </summary>
    public IList<OrderedTest> GetAllOrderedTests(int labOrderId)
    {
        return this.testOrderDAL.GetAllOrderedTests(labOrderId);
    }

    /// <summary>
    ///     Gets the test by identifier.
    /// </summary>
    /// <param name="testCode">The test code.</param>
    /// <returns>The test that belongs to the test code id</returns>
    public Test getTestById(string testCode)
    {
        return this.testOrderDAL.getTestById(testCode) ?? throw new ArgumentException("Test not found.");
    }

    /// <summary>
    ///     Updates the ordered tests.
    /// </summary>
    /// <param name="selectedTest">The selected test.</param>
    public void UpdateOrderedTests(OrderedTest selectedTest)
    {
        this.testOrderDAL.updateOrderedTest(selectedTest.labOrderId, selectedTest.testCode, selectedTest.dateTimePreformed, selectedTest.testResult, selectedTest.isAbnormal);
    }

    /// <summary>
    /// Determines if a test result is abnormal.
    /// When the test has a low or high value defined, the result must be a non negative number.
    /// The result is then compared to the low and high values to determine if it is abnormal.
    /// A missing limit is skipped and when the test has neither a low or high value, the nurses choice is used.
    /// </summary>
    /// <param name="test">The test.</param>
    /// <param name="result">The result.</param>
    /// <param name="manualIsAbnormal">The nurses choice.</param>
    /// <returns>true if the result is abnormal; otherwise, false.</returns>
    /// <exception cref="ArgumentException">
    /// Result must be a valid number.
    /// or
    /// Result cannot be negative
    /// or
    /// Result is too large
    /// </exception>
    public bool DetermineAbnormal(Test test, string result, bool manualIsAbnormal)
    {
        if (string.IsNullOrWhiteSpace(result))
        {
            return false;
        }
        var lowValue = parseLimit(test.LowValue);
        var highValue = parseLimit(test.HighValue);

        if (lowValue == null && highValue == null)
        {
            return manualIsAbnormal;
        }

        if (!decimal.TryParse(result.Trim(), out var resultValue))
        {
            throw new ArgumentException("Result must be a valid number.");
        }

        if (resultValue < 0)
        {
            throw new ArgumentException("Result cannot be negative");
        }

        if (resultValue > MaxResult)
        {
            throw new ArgumentException($"Result is too large");
        }

        return (lowValue != null && resultValue < lowValue) || (highValue != null && resultValue > highValue);
    }

    /// <summary>
    /// Determines whether a test has a normal range meaning that abnormality can be determined automatically.
    /// </summary>
    /// <param name="test">The test.</param>
    /// <returns>
    ///   <c>true</c> if the tes has a low value, high value, or both; otherwise, <c>false</c>.
    /// </returns>
    public bool HasNormalRange(Test test)
    {
        return parseLimit(test.LowValue) != null || parseLimit(test.HighValue) != null;
    }

    private static decimal? parseLimit(string limit)
    {
        return decimal.TryParse(limit, out var value) ? value : null;
    }
    #endregion
}