using System.Text.RegularExpressions;
using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

public class NurseController
{
    #region Fields

    private const int MaxNameLength = 50;
    private const int MaxPasswordLength = 255;
    private const int MaxPhoneNumberLength = 20;
    private const int MaxStreetAddressLength = 100;
    private const int MaxZipCodeAndGenderLength = 10;

    private readonly NurseDal nurseDal;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="NurseController" /> class.
    /// </summary>
    /// <param name="nurseDal">The nurse dal.</param>
    public NurseController(NurseDal nurseDal)
    {
        this.nurseDal = nurseDal;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Adds a new nurse.
    /// </summary>
    public int AddNurse(Nurse nurse, NurseCredentials credentials)
    {
        this.ensureAdministrator();
        this.validateNurse(nurse);
        this.validateCredentials(credentials);

        return this.nurseDal.AddNurse(nurse, credentials);
    }

    /// <summary>
    ///     Retrieves all nurses.
    /// </summary>
    public IList<Nurse> GetAllNurses()
    {
        this.ensureAdministrator();

        return this.nurseDal.GetAllNurses();
    }

    ///// <summary>
    /////     Retrieves a nurse by their nurse ID.
    ///// </summary>
    //public Nurse? GetNurseById(int nurseId)
    //{
    //    this.ensureAdministrator();

    //    if (nurseId <= 0)
    //    {
    //        throw new ArgumentOutOfRangeException(nameof(nurseId));
    //    }

    //    return this.nurseDal.GetNurseById(nurseId);
    //}

    /// <summary>
    /// Updates an existing nurse.
    /// </summary>
    public bool UpdateNurse(Nurse nurse)
    {
        this.ensureAdministrator();
        this.validateNurse(nurse);

        if (nurse.NurseId <= 0)
        {
            throw new ArgumentException("A valid nurse ID is required.");
        }

        return this.nurseDal.UpdateNurse(nurse);
    }


    private void ensureAdministrator()
    {
        if (!SessionManager.IsAdmin)
        {
            throw new UnauthorizedAccessException("Only administrators can manage nurses.");
        }
    }

    /// <summary>
    ///     Validates nurse information before database operations.
    /// </summary>
    private void validateNurse(Nurse nurse)
    {
        ArgumentNullException.ThrowIfNull(nurse);

        this.validateStringField(nurse.FirstName, "First name", MaxNameLength);
        this.validateStringField(nurse.LastName, "Last name", MaxNameLength);
        this.validateStringField(nurse.Gender, "Gender", MaxZipCodeAndGenderLength);
        this.validateStringField(nurse.StreetAddress, "Street address", MaxStreetAddressLength);
        this.validateStringField(nurse.City, "City", MaxNameLength);
        this.validateStringField(nurse.State, "State", MaxNameLength);
        this.validateStringField(nurse.PhoneNumber, "Phone number", MaxPhoneNumberLength);

        this.validateZipCode(nurse.ZipCode);

        if (nurse.DateOfBirth == default || nurse.DateOfBirth.Date > DateTime.Today)
        {
            throw new ArgumentException("A valid date of birth is required.");
        }
    }

    private void validateZipCode(string? zipCode)
    {
        this.validateStringField(zipCode, "Zip code", MaxZipCodeAndGenderLength);

        if (string.IsNullOrWhiteSpace(zipCode))
        {
            throw new ArgumentException("Zip code is required.");
        }

        if (!Regex.IsMatch(zipCode, @"^[0-9]{5}(-[0-9]{4})?$"))
        {
            throw new ArgumentException("ZIP code must be ##### or #####-####.");
        }
    }

    private void validateStringField(string? value, string fieldName, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{fieldName} is required.");
        }

        if (value.Length > maxLength)
        {
            throw new ArgumentException(
                $"{fieldName} cannot exceed {maxLength} characters.");
        }
    }

    private void validateCredentials(NurseCredentials credentials)
    {
        ArgumentNullException.ThrowIfNull(credentials);

        if (string.IsNullOrWhiteSpace(credentials.Username))
        {
            throw new ArgumentException("Username is required.");
        }

        if (credentials.Username.Trim().Length > MaxNameLength)
        {
            throw new ArgumentException("Username cannot exceed 50 characters.");
        }

        if (string.IsNullOrWhiteSpace(credentials.Password))
        {
            throw new ArgumentException("Password is required.");
        }

        if (credentials.Password.Length > MaxPasswordLength)
        {
            throw new ArgumentException("Password cannot exceed 255 characters.");
        }
    }

    #endregion
}