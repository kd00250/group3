namespace HealthcareSystem.Model;

public class OrderedTest
{
    /// <summary>
    /// Gets or sets the lab order identifier.
    /// </summary>
    /// <value>
    /// The lab order identifier.
    /// </value>
    public int labOrderId { get; set; }
    /// <summary>
    /// Gets or sets the test code.
    /// </summary>
    /// <value>
    /// The test code.
    /// </value>
    public string testCode { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the date and time the test was performed.
    /// </summary>
    /// <value>
    /// The date and time the test was performed.
    /// </value>
    public DateTime dateTimePreformed { get; set; }
    /// <summary>
    /// Gets or sets the test result.
    /// </summary>
    /// <value>
    /// The test result.
    /// </value>
    public double testResult { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the test result is abnormal.
    /// </summary>
    /// <value>
    /// true if the test result is abnormal; otherwise, false.
    /// </value>
    public bool isAbnormal { get; set; } = false;
}