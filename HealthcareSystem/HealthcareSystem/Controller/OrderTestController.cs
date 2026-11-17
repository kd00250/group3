using System.Text.RegularExpressions;
using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

public class OrderTestController
{
    #region Fields

    private readonly OrderTestDal orderTestDal;

    #endregion
    
    #region Constructors

    public OrderTestController(OrderTestDal orderTestDAL)
    {
        this.orderTestDal = orderTestDAL;
    }

    #endregion

    #region Methods
    /// <summary>
    ///     Retrieves all tests.
    /// </summary>
    public IList<Test> GetAllTests()
    {
        return this.orderTestDal.GetAllTests();
    }

    public void ConfirmLabOrder(IList<Test> tests, int visit_id)
    {
        var alreadyOrdered = this.orderTestDal.GetOrderedTestCodesForVisit(visit_id);
        var duplicates = tests.Where(test => alreadyOrdered.Contains(test.TestCode)).ToList();

        if (duplicates.Count > 0)
        {
            var duplicateTestCodes = string.Join(", ", duplicates.Select(test => test.TestCode));
            throw new ArgumentException($"The following tests have already been ordered for this visit: {duplicateTestCodes}");
        }

        this.orderTestDal.CompleteLabOrder(tests, visit_id);
    }

    /// <summary>
    /// Gets the available tests that can still be ordered for the specified visit.
    /// </summary>
    /// <param name="visitId">The visit identifier.</param>
    /// <returns>The tests available for ordering.</returns>
    public IList<Test> GetAvailableTests(int visitId)
    {
        return this.orderTestDal.GetAvailableTestsForVisit(visitId);
    }

    #endregion
}