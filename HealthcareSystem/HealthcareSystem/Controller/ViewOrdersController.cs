using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

public class ViewOrdersController
{
    private readonly ViewOrdersDal viewOrdersDal;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ViewOrdersController"/> class.
    /// </summary>
    /// <param name="viewOrdersDal">The view orders dal.</param>
    public ViewOrdersController(ViewOrdersDal viewOrdersDal)
    {
        this.viewOrdersDal = viewOrdersDal;
    }

    /// <summary>
    ///     Gets the orders by visit identifier.
    /// </summary>
    /// <param name="visitId">The visit identifier.</param>
    /// <returns></returns>
    public List<LabOrder> GetOrdersByVisitId(int visitId)
    {
        return this.viewOrdersDal.GetOrdersByVisitId(visitId);
    }

}