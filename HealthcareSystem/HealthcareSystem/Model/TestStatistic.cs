namespace HealthcareSystem.Model;

/// <summary>
/// One row of the test statistics report, containing information about a specific test and its performance statistics.
/// </summary>
public class TestStatistic
{
    /// <summary>
    /// Gets or sets the test code.
    /// </summary>
    public string TestCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the test.
    /// </summary>
    /// <value>
    /// The name of the test.
    /// </value>
    public string TestName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the times performed for the specific test.
    /// </summary>
    public int TimesPerformed { get; set; }

    /// <summary>
    /// Gets or sets the total tests performed.
    /// </summary>
    public int TotalTestsPerformed { get; set; }

    /// <summary>
    /// Gets or sets the percentage performed for a specific test compared to the total tests performed.
    /// </summary>
    public double PercentagePerformed { get; set; }

    /// <summary>
    /// Gets or sets the number of normal results.
    /// </summary>
    /// <value>
    /// The normal results.
    /// </value>
    public int NormalResults { get; set; }

    /// <summary>
    /// Gets or sets the number of abnormal results.
    /// </summary>
    public int AbnormalResults { get; set; }
}
