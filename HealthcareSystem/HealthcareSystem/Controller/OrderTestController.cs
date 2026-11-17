using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

/// <summary>
///     The order test controller class responsible for managing ordering tests.
/// </summary>
public class OrderTestController
{
    #region Fields

    private readonly OrderTestDal orderTestDal;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="OrderTestController"/> class.
    /// </summary>
    /// <param name="orderTestDAL">The order test dal.</param>
    public OrderTestController(OrderTestDal orderTestDAL)
    {
        this.orderTestDal = orderTestDAL;
    }

    #endregion

    #region Methods
    /// <summary>
    ///     Confirms the lab order.
    /// </summary>
    /// <param name="tests">The tests for a lab order.</param>
    /// <param name="visit_id">The visit identifier.</param>
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