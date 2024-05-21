using HospitalManagement.Common.Interfaces;
using HospitalManagement.Core.Common.Constants;
using HospitalManagement.Core.Common.Constants.DataProviderRouteConstants.HeadOfficeRoutes;
using HospitalManagement.Core.Common.Interfaces;
using HospitalManagement.Core.Common.Models;

namespace HospitalManagement.Services
{
    public class HeadOfficeService : IHeadOfficeService
    {
        private readonly IDataProviderCommunicator _dataProviderCommunicator;

        public HeadOfficeService(IDataProviderCommunicator dataProviderCommunicator) 
        {
            _dataProviderCommunicator = dataProviderCommunicator;
        }

        public APIResult<bool> AddHeadOffice(HeadOffice headOffice)
        {
            return _dataProviderCommunicator.PostToServer<bool>($"{HeadOfficeRouteConstatnts.AddHeadOffice}", headOffice, "");
        }

        public APIResult<HeadOffice> GetHeadOffice(Guid headOfficeId)
        {
            return _dataProviderCommunicator.GetServerResponse<HeadOffice>($"{HeadOfficeRouteConstatnts.GetHeadOffice}?headOfficeId={headOfficeId}", "");
        }

        public APIResult<bool> UpdateHeadoffice(HeadOffice headOffice)
        {
            return _dataProviderCommunicator.PostToServer<bool>($"{HeadOfficeRouteConstatnts.UpdateHeadoffice}",headOffice, "");
        }

        public APIResult<bool> DeleteHeadOffice(Guid headOfficeId)
        {
            return _dataProviderCommunicator.GetServerResponse<bool>($"{HeadOfficeRouteConstatnts.DeleteHeadOffice}?headOfficeId={headOfficeId}", "");
        }

        public APIResult<List<HeadOffice>> GetAllHeadOffices()
        {
            return _dataProviderCommunicator.GetServerResponse<List<HeadOffice>>($"{HeadOfficeRouteConstatnts.GetHeadOfficeList}", "");
        }
    }
}
