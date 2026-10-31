namespace HealthcareSystem.Model;

public class Test
{
    /// <summary>
    /// Gets or sets the test code.
    /// </summary>
    /// <value>
    /// The test code.
    /// </value>
    public string TestCode { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the name of the test.
    /// </summary>
    /// <value>
    /// The name of the test.
    /// </value>
    public string TestName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the name of the unit.
    /// </summary>
    /// <value>
    /// The name of the unit.
    /// </value>
    public string UnitName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the high value.
    /// </summary>
    /// <value>
    /// The high value.
    /// </value>
    public double HighValue { get; set; }
    /// <summary>
    /// Gets or sets the low value.
    /// </summary>
    /// <value>
    /// The low value.
    /// </value>
    public double LowValue { get; set; }

}