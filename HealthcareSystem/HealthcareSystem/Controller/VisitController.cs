using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

/// <summary>
/// Business rules for viewing and editing visits.
/// </summary>
public class VisitController
{
    private const decimal MaxHeightOrWeight = 9999.99m;
    private const decimal MaxBodyTemperature = 999.9m;
    private const int MaxVitalInteger = 999;
    private readonly VisitDal visitDal;

    /// <summary>
    /// Initializes a new instance of the <see cref="VisitController"/> class.
    /// </summary>
    /// <param name="visitDal">The visit dal.</param>
    public VisitController(VisitDal visitDal)
    {
        this.visitDal = visitDal;
    }

    /// <summary>
    /// Gets all visits for the patient, newest first.
    /// </summary>
    /// <param name="patient">The patient.</param>
    /// <returns>The patient's visits.</returns>
    public List<Visit> GetVisitsForPatient(Patient patient)
    {
        return this.visitDal.GetVisitsForPatient(patient.PatientId);
    }

    /// <summary>
    /// Saves the visit information after validating it. The logged in nurse is recorded as the nurse for the visit,
    /// and the check date and time is set the first time the information is saved.
    /// </summary>
    /// <param name="visit">The visit to save.</param>
    /// <exception cref="ArgumentException">
    /// The visit is finalized.
    /// or
    /// The logged in user is not a nurse.
    /// or
    /// A vital sign is not a valid positive value.
    /// or
    /// The visit was not found or was finalized in the meantime.
    /// </exception>
    public void SaveVisit(Visit visit)
    {
        if (visit.IsFinalized)
        {
            throw new ArgumentException("This visit is finalized and can no longer be edited.");
        }

        validatePositive(visit.Height, MaxHeightOrWeight, "Height");
        validatePositive(visit.Weight, MaxHeightOrWeight, "Weight");
        validatePositive(visit.Systolic, MaxVitalInteger, "Systolic blood pressure");
        validatePositive(visit.Diastolic, MaxVitalInteger, "Diastolic blood pressure");
        validatePositive(visit.BodyTemperature, MaxBodyTemperature, "Body temperature");
        validatePositive(visit.Pulse, MaxVitalInteger, "Pulse");

        if (visit.Systolic.HasValue && visit.Diastolic.HasValue && visit.Diastolic >= visit.Systolic)
        {
            throw new ArgumentException("Diastolic blood pressure must be lower than systolic blood pressure.");
        }

        var user = SessionManager.CurrentUser;
        var nurseId = user == null ? null : this.visitDal.GetNurseIdByPersonId(user.PersonId);

        if (nurseId == null)
        {
            throw new ArgumentException("Only a nurse can save visit information.");
        }

        visit.NurseId = nurseId;
        visit.NurseName = user!.FullName;
        visit.CheckDateTime ??= DateTime.Now;

        if (!this.visitDal.Update(visit))
        {
            throw new ArgumentException("The visit could not be saved. It may have been finalized.");
        }
    }

    private static void validatePositive<T>(T? value, T max, string name) where T : struct, IComparable<T>
    {
        if (value == null)
        {
            return;
        }

        if (value.Value.CompareTo(default) <= 0 || value.Value.CompareTo(max) > 0)
        {
            throw new ArgumentException($"{name} must be greater than 0 and no more than {max}.");
        }
    }
}
