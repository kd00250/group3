using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

public class PatientEditController
{
    /// <summary>
    ///     Edits the patient.
    /// </summary>
    /// <param name="patient">The patient to be edited.</param>
    /// <param name="attribute">The attribute to be edited.</param>
    /// <param name="value">The new value for the attribute.</param>
    public static void editPatient(Patient patient, String attribute, String value)
    {
        if (string.IsNullOrEmpty(attribute) || string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Please fill in all fields.");
        }

        switch (attribute)
        {
            case "First name":
                patient.FirstName = value;
                PatientDal.editPatient(patient);
                break;
            case "Last name":
                patient.LastName = value;
                PatientDal.editPatient(patient);
                break;
            case "Date of Birth":
                if (DateTime.TryParse(value, out DateTime dob))
                {
                    patient.DateOfBirth = dob;
                    PatientDal.editPatient(patient);
                }
                else
                {
                    throw new ArgumentException("Invalid date format. Please use MM/DD/YYYY.");
                }
                break;
            case "Gender":
                if (value != "Male" && value != "Female" && value != "Other")
                {
                    throw new ArgumentException("Invalid gender. Please enter 'Male', 'Female', or 'Other'.");
                }
                patient.Gender = value;
                PatientDal.editPatient(patient);
                break;
            case "Street":
                patient.StreetAddress = value;
                PatientDal.editPatient(patient);
                break;
            case "City":
                patient.City = value;
                PatientDal.editPatient(patient);
                break;
            case "State":
                patient.State = value;
                PatientDal.editPatient(patient);
                break;
            case "Zipcode":
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{5}$"))
                {
                    throw new ArgumentException("Invalid zipcode. Please enter a 5-digit number.");
                }
                patient.ZipCode = value;
                PatientDal.editPatient(patient);
                break;
            case "Phone number":
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{10}$"))
                {
                    throw new ArgumentException("Invalid phone number. Please enter a 10-digit number.");
                }
                patient.PhoneNumber = value;
                PatientDal.editPatient(patient);
                break;
            default:
                throw new ArgumentException("Invalid attribute selected.");

        }
    }
}