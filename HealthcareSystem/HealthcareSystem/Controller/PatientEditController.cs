using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;
using System.Text.RegularExpressions;

namespace HealthcareSystem.Controller;

public class PatientEditController
{
    /// <summary>
    ///     Edits the patient.
    /// </summary>
    /// <param name="patient">The patient to be edited.</param>
    /// <param name="firstName">The new first name for the patient.</param>
    /// <param name="lastName">The new last name for the patient.</param>
    /// <param name="gender">The new gender for the patient.</param>
    /// <param name="dateOfBirth">The new date of birth for the patient.</param>
    /// <param name="streetAddress">The new street address for the patient.</param>
    /// <param name="city">The new city for the patient.</param>
    /// <param name="state">The new state for the patient.</param>
    /// <param name="zipCode">The new zip code for the patient.</param>
    /// <param name="phoneNumber">The new phone number for the patient.</param>
    /// <param name="isActive">The new active status for the patient.</param>
    public static void editPatient(Patient patient, String firstName, String lastName, String gender, DateTime dateOfBirth, String? streetAddress, String? city, String? state, String? zipCode, String? phoneNumber, bool isActive)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(gender))
        {
            throw new ArgumentException("Please fill in first name, last name, and gender.");
        }
        if (!Regex.Match(firstName, @"^\p{L}[\p{L}\p{M} '’\-\.]*$").Success || !Regex.Match(lastName, @"^\p{L}[\p{L}\p{M} '’\-\.]*$").Success)
        {
            throw new ArgumentException("First name, last name, can only contain letters, spaces, and the following characters: '’-.");
        }
        if (string.IsNullOrWhiteSpace(streetAddress)) {
            streetAddress = null;
        }
        if (string.IsNullOrWhiteSpace(city))
        {
            city = null;
        } else if (!Regex.Match(city, @"^\p{L}[\p{L}\p{M} '’\-\.]*$").Success)
        {
            throw new ArgumentException("City can only contain letters, spaces, and the following characters: '’-.");
        }
        if (string.IsNullOrWhiteSpace(state))
        {
            state = null;
        } else if (!Regex.Match(state, @"^[A-Z]{2}$").Success)
        {
            state = null;
        }
        if (string.IsNullOrWhiteSpace(zipCode))
        {
            zipCode = null;
        } else if (!Regex.Match(zipCode, @"^\d{5}$").Success && !Regex.Match(zipCode, @"^\d{5}-\d{4}$").Success)
        {
            throw new ArgumentException("Zip code must be in the format XXXXX or XXXXX-XXXX. " +
                "If you want this field to be optional, please leave it blank.");
        }
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            phoneNumber = null;
        } else if (!Regex.Match(phoneNumber, @"^\d{3}-\d{3}-\d{4}$").Success)
        {
            throw new ArgumentException("Phone number must be in the format XXX-XXX-XXXX. " +
                "If you want this field to be optional, please leave it blank.");
        }

        if (dateOfBirth > DateTime.Now)
        {
            throw new ArgumentException("Date of birth cannot be in the future.");
        }
        if (gender != "Male" && gender != "Female" && gender != "Other")
        {
            throw new ArgumentException("Invalid gender. Please select Male, Female, or Other.");
        }
        patient.FirstName = firstName;
        patient.LastName = lastName;
        patient.Gender = gender;
        patient.DateOfBirth = dateOfBirth;
        patient.StreetAddress = streetAddress;
        patient.City = city;
        patient.State = state;
        patient.ZipCode = zipCode;
        patient.PhoneNumber = phoneNumber;
        patient.IsActive = isActive;
        PatientDal.editPatient(patient);
    }
}