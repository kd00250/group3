using System.Text.RegularExpressions;
using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

public class OrderTestController
{
    private readonly IOrderTestDAL orderTestDAL;
    public OrderTestController(IOrderTestDAL orderTestDAL)
    {
        this.orderTestDAL = orderTestDAL;
    }
    public List<Test> GetAllTests()
    {
        return this.orderTestDAL.GetAllTests();
    }

    #region Fields

    private const int MaxtTestNameLength = 100;
    private const int MaxUnitNameLength = 30;

    private readonly OrderTestDal orderTestDal;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="OrderTestController" /> class.
    /// </summary>
    /// <param name="orderTestDal">The order test dal.</param>
    public OrderTestController(OrderTestDal orderTestDal)
    {
        this.orderTestDal = orderTestDal;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Adds a new test.
    /// </summary>
    public int AddTest(Test test)
    {
        this.ensureAdministrator();
        this.validateTest(test);

        return this.orderTestDal.AddTest(test);
    }

    /// <summary>
    ///     Retrieves all tests.
    /// </summary>
    public IList<Test> GetAllTests()
    {
        this.ensureAdministrator();

        return this.orderTestDal.GetAllTests();
    }

    /// <summary>
    ///     Updates an existing test.
    /// </summary>
    public bool UpdateTest(Test test)
    {
        this.ensureAdministrator();
        this.validateTest(test);

        if (test.TestId <= 0)
        {
            throw new ArgumentException("A valid test ID is required.");
        }

        return this.orderTestDal.UpdateTest(test);
    }

    private void ensureAdministrator()
    {
        if (!SessionManager.IsAdmin)
        {
            throw new UnauthorizedAccessException("Only administrators can manage tests.");
        }
    }


    /// <summary>
    ///     Retrieves all nurses.
    /// </summary>
    public IList<Nurse> GetAllNurses()
    {
        this.ensureAdministrator();

        return this.nurseDal.GetAllNurses();
    }
    #endregion
}