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
        this.orderTestDal.CompleteLabOrder(tests, visit_id);
    }
    #endregion
}