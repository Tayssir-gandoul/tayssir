using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickApp.Core.Models.Shop;

namespace QuickApp.Core.Services.Shop.Interfaces
{
    public interface IBillCalculationService
    {
        BillCalculationResult BillCalculation (BillCalculationModel model, int count);
    }
}




