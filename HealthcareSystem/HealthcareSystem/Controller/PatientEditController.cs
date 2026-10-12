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
    public static void editPatient(Patient patient, String firstName, String lastName, String gender, DateTime dateOfBirth, String streetAddress, String city, String state, String zipCode, String phoneNumber)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(streetAddress) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(zipCode) || string.IsNullOrEmpty(phoneNumber))
        {
            throw new ArgumentException("Please fill in all fields.");
        }

        if (dateOfBirth > DateTime.Now)
        {
            throw new ArgumentException("Date of birth cannot be in the future.");
        }
        if (!Regex.Match(phoneNumber, @"^\d{3}-\d{3}-\d{4}$").Success)
        {
            throw new ArgumentException("Invalid phone number format.");
        }
        if (!Regex.Match(zipCode, @"^\d{5}$").Success)
        {
            throw new ArgumentException("Invalid zip code format.");
        }
        if (gender != "Male" && gender != "Female" && gender != "Other")
        {
            throw new ArgumentException("Invalid gender. Please select Male, Female, or Other.");
        }
        if (!Regex.Match(state, @"^[A-Z]{2}$").Success)
        {
            throw new ArgumentException("Invalid state format. Please enter a valid two-letter state abbreviation.");
        }
        patient.FirstName = firstName;
        patient.LastName = lastName;
        patient.Gender = gender;
        patient.StreetAddress = streetAddress;
        patient.City = city;
        patient.State = state;
        patient.ZipCode = zipCode;
        patient.PhoneNumber = phoneNumber;
        PatientDal.editPatient(patient);
    }
}