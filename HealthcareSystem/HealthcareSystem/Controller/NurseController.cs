using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

public class NurseController
{
    #region Fields

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
    public int AddNurse(Nurse nurse)
    {
        this.ensureAdministrator();
        this.validateNurse(nurse);

        return this.nurseDal.AddNurse(nurse);
    }

    /// <summary>
    ///     Retrieves all nurses.
    /// </summary>
    public IList<Nurse> GetAllNurses()
    {
        this.ensureAdministrator();

        return this.nurseDal.GetAllNurses();
    }

    /// <summary>
    ///     Retrieves a nurse by their nurse ID.
    /// </summary>
    public Nurse? GetNurseById(int nurseId)
    {
        this.ensureAdministrator();

        if (nurseId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(nurseId));
        }

        return this.nurseDal.GetNurseById(nurseId);
    }

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

        this.validateStringField(nurse.FirstName, "First name", 50);
        this.validateStringField(nurse.LastName, "Last name", 50);
        this.validateStringField(nurse.Gender, "Gender", 10);
        this.validateStringField(nurse.StreetAddress, "Street address", 100);
        this.validateStringField(nurse.City, "City", 50);
        this.validateStringField(nurse.State, "State", 50);
        this.validateStringField(nurse.ZipCode, "Zip code", 10);
        this.validateStringField(nurse.PhoneNumber, "Phone number", 20);

        if (nurse.DateOfBirth == default || nurse.DateOfBirth.Date > DateTime.Today)
        {
            throw new ArgumentException("A valid date of birth is required.");
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

    #endregion
}