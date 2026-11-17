using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

public class TestEditController
{
    #region Fields

    private readonly TestEditDal testOrderDAL;

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
        return this.testOrderDAL.getTestById(testCode);
    }
    public void UpdateOrderedTests(OrderedTest selectedTest)
    {
        this.testOrderDAL.updateOrderedTest(selectedTest.labOrderId, selectedTest.testCode, selectedTest.dateTimePreformed, selectedTest.testResult, selectedTest.isAbnormal);
    }
    #endregion
}