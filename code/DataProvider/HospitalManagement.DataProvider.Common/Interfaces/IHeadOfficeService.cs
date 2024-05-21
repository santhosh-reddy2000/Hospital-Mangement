using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataProvider.Common.Interfaces
{
    public interface IHeadOfficeService
    {
        APIResult<bool> AddHeadOffice(HeadOffice headOffice);

        APIResult<HeadOffice> GetHeadOffice(Guid headOfficeId);

        APIResult<bool> UpdateHeadoffice(HeadOffice headOfficeId);

        APIResult<bool> DeleteHeadOffice(Guid headOfficeId);

        APIResult<List<HeadOffice>> GetAllHeadOffices();
    }
}
