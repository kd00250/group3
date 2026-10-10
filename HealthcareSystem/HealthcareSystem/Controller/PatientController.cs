using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

/// <summary>
/// Controller class for managing patient-related operations in the healthcare system.
/// </summary>
public class PatientController
{
    private readonly PatientDal patientDal;

    /// <summary>
    /// Initializes a new instance of the <see cref="PatientController"/> class.
    /// </summary>
    /// <param name="patientDal">The patient data access object.</param>
    public PatientController(PatientDal patientDal)
    {
        this.patientDal = patientDal;
    }

    /// <summary>
    /// Searches the patients by first and last name, date of birth, or both.
    /// </summary>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    /// <param name="dateOfBirth">The date of birth.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">
    /// The search criteria are invalid.
    /// Both first name and last name must be provided together, or a date of birth must be provided.
    /// The date of birth cannot be in the future.
    /// </exception>
    public List<Patient> SearchPatients(string? firstName, string? lastName, DateTime? dateOfBirth)
    {
        var hasFirstName = !string.IsNullOrWhiteSpace(firstName);
        var hasLastName = !string.IsNullOrWhiteSpace(lastName);

        if (hasFirstName != hasLastName)
        {
            throw new ArgumentException("Both first name and last name must be provided together.");
        }

        if (!hasFirstName && dateOfBirth == null)
        {
            throw new ArgumentException("Enter a first and last name, a date of birth, or both.");
        }

        if (dateOfBirth != null && dateOfBirth.Value.Date > DateTime.Today)
        {
            throw new ArgumentException("Date of birth cannot be in the future.");
        }

        return patientDal.Search(firstName, lastName, dateOfBirth);
    }

}