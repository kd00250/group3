using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

/// <summary>
/// Holds the rules for the test statistics.
/// </summary>
public class TestStatisticsController
{
    private readonly OrderTestDal orderTestDal;

    /// <summary>
    ///     Initializes a new instance of the <see cref="TestStatisticsController"/> class.
    /// </summary>
    /// <param name="orderTestDal">The order test dal.</param>
    public TestStatisticsController(OrderTestDal orderTestDal)
    {
        this.orderTestDal = orderTestDal;
    }

    /// <summary>
    /// Gets the statistics of the tests performed at least twice during the specified date range.
    /// </summary>
    /// <param name="startDate">The start date (inclusive).</param>
    /// <param name="endDate">The end date (inclusive).</param>
    /// <returns>The list of test statistics from most to least performed.</returns>
    /// <exception cref="System.ArgumentException">Start date cannot be after end date.</exception>
    public IList<TestStatistic> GetMostPerformedTestsDuringDates(DateTime startDate, DateTime endDate)
    {
        this.ensureAdministrator();

        if (startDate.Date > endDate.Date)
        {
            throw new ArgumentException("Start date cannot be after end date.");
        }

        return this.orderTestDal.GetMostPerformedTestsDuringDates(startDate.Date , endDate.Date);
    }

    private void ensureAdministrator()
    {
        if (!SessionManager.IsAdmin)
        {
            throw new UnauthorizedAccessException("User must be an administrator to access this functionality.");
        }
    }
}
