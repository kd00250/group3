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
    ///     Retrieves all tests.
    /// </summary>
    public IList<Test> GetAllTests()
    {
        return this.testOrderDAL.GetAllTests();
    }

    public void ConfirmLabOrder(IList<Test> tests, int visit_id)
    {
        int orderId = this.testOrderDAL.LabOrder(DateTime.Now, visit_id);
        foreach (Test test in tests)
        {
            this.testOrderDAL.OrderTest(orderId, test.TestCode, null, null, false);
        }

    }
    #endregion
}