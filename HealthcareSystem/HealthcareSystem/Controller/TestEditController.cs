using System.Text.RegularExpressions;
using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

public class TestEditController
{
    #region Fields

    private readonly TestEditDal testOrderDAL;

    #endregion
    
    #region Constructors

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