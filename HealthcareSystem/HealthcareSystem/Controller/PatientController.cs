using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;
using System.Text.RegularExpressions;

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

    /// <summary>
    /// Registers the patient.
    /// </summary>
    /// <param name="patient">The patient.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">
    /// First and last name are required.
    /// or
    /// Gender is required.
    /// or
    /// Date of birth cannot be in the future.
    /// or
    /// Zip code must be 5 digits (or ZIP+4).
    /// or
    /// Phone number must have at least 10 digits.
    /// </exception>
    public int RegisterPatient(Patient patient) {
        if (string.IsNullOrWhiteSpace(patient.FirstName) || string.IsNullOrWhiteSpace(patient.LastName))
            throw new ArgumentException("First and last name are required.");
        if (string.IsNullOrWhiteSpace(patient.Gender))
            throw new ArgumentException("Gender is required.");
        if (patient.DateOfBirth.Date > DateTime.Today)
            throw new ArgumentException("Date of birth cannot be in the future.");
        if (!string.IsNullOrWhiteSpace(patient.ZipCode) && !System.Text.RegularExpressions.Regex.IsMatch(patient.ZipCode.Trim(), @"^\d{5}(-\d{4})?$"))
            throw new ArgumentException("Zip code must be 5 digits (or ZIP+4).");
        if (!string.IsNullOrWhiteSpace(patient.PhoneNumber) &&
            !Regex.IsMatch(patient.PhoneNumber.Trim(), @"^[0-9]{3}-[0-9]{3}-[0-9]{4}$"))
            throw new ArgumentException("Phone number must be in the format xxx-xxx-xxxx.");
        if (!Regex.IsMatch(patient.FirstName.Trim(), @"^\p{L}[\p{L}\p{M} '’\-]*$") ||
            !Regex.IsMatch(patient.LastName.Trim(), @"^\p{L}[\p{L}\p{M} '’\-]*$"))
            throw new ArgumentException("Names may only contain letters, spaces, hyphens, and apostrophes.");
        if (!string.IsNullOrWhiteSpace(patient.City) &&
            !Regex.IsMatch(patient.City.Trim(), @"^\p{L}[\p{L}\p{M} '’\-\.]*$"))
            throw new ArgumentException("City may only contain letters, spaces, periods, hyphens, and apostrophes.");

        patient.FirstName = patient.FirstName.Trim();
        patient.LastName = patient.LastName.Trim();
        patient.StreetAddress = patient.StreetAddress?.Trim();
        patient.City = patient.City?.Trim();
        patient.State = patient.State?.Trim();
        patient.ZipCode = patient.ZipCode?.Trim();
        patient.PhoneNumber = patient.PhoneNumber?.Trim();

        return patientDal.Add(patient);
    }

}