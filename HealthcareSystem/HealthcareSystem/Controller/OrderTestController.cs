using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

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
    ///     Retrieves all tests.
    /// </summary>
    public IList<Test> GetAllTests()
    {
        return this.orderTestDal.GetAllTests();
    }

    /// <summary>
    ///     Confirms the lab order.
    /// </summary>
    /// <param name="tests">The tests for a lab order.</param>
    /// <param name="visit_id">The visit identifier.</param>
    public void ConfirmLabOrder(IList<Test> tests, int visit_id)
    {
        this.orderTestDal.CompleteLabOrder(tests, visit_id);
    }
    #endregion
}