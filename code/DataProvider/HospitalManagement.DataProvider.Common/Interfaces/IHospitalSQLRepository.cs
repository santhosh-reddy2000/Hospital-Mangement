using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataProvider.Common.Interfaces
{
    public interface IHospitalSQLRepository
    {
        bool Create<T>(T data) where T : class;

        HeadOffice GetHeadOffice(Guid headOfficeId);

        bool UpdateHeadoffice(HeadOffice headOfficeId);

        bool DeleteHeadOffice(Guid headOfficeId);

        List<HeadOffice> GetAllHeadOffices(); 
    }
}
