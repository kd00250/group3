using System.Text.RegularExpressions;
using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

public class ViewOrdersController
{
    private readonly ViewOrdersDal viewOrdersDal;
    public ViewOrdersController(ViewOrdersDal viewOrdersDal)
    {
        this.viewOrdersDal = viewOrdersDal;
    }
    public List<LabOrder> GetOrdersByVisitId(int visitId)
    {
        return this.viewOrdersDal.GetOrdersByVisitId(visitId);
    }

}