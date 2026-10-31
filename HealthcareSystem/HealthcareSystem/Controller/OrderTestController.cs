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
        int orderId = this.orderTestDal.LabOrder(DateTime.Now, visit_id);
        foreach (Test test in tests)
        {
            this.orderTestDal.OrderTest(orderId, test.TestCode, null, null, false);
        }

    }
    #endregion
}