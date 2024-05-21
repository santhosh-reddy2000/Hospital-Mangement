
using HospitalManagement.Core.Common.Helpers;
using HospitalManagement.Core.Common.Models;
using HospitalManagement.DataProvider.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Dataprovider.Services
{
    public class HeadOfficeService : IHeadOfficeService
    {
        private IHospitalSQLRepository _hospitalSQLRepository;
        public HeadOfficeService(IHospitalSQLRepository hospitalSQLRepository) 
        {
            _hospitalSQLRepository = hospitalSQLRepository;
        }

        public APIResult<bool> AddHeadOffice(HeadOffice headOffice)
        {
            APIResult<bool> result = new APIResult<bool>();

            bool isAdded = _hospitalSQLRepository.Create<HeadOffice>(headOffice);

            if (isAdded)
            {
                result.Result = true;
                result.Message.Message = "Successfully added the headoffice";
            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("Failed to add headoffice", result);
            }
            return result;
        }

        public APIResult<bool> DeleteHeadOffice(Guid headOfficeId)
        {
            APIResult<bool> result = new APIResult<bool>();

            bool isAdded = _hospitalSQLRepository.DeleteHeadOffice(headOfficeId);

            if (isAdded)
            {
                result.Result = true;
                result.Message.Message = "Successfully deleted the headoffice";
            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("Failed to delete the headoffice", result);
            }
            return result;
        }

        public APIResult<HeadOffice> GetHeadOffice(Guid headOfficeId)
        {
            APIResult<HeadOffice> result = new APIResult<HeadOffice>();

            HeadOffice headOffice = _hospitalSQLRepository.GetHeadOffice(headOfficeId);

            if (headOffice != null)
            {
                result.Result = headOffice;
            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("No headoffice is found with the provided id", result);
            }
            return result;
        }

        public APIResult<List<HeadOffice>> GetAllHeadOffices()
        {
            APIResult<List<HeadOffice>> result = new APIResult<List<HeadOffice>>();

            List<HeadOffice> headOffices = _hospitalSQLRepository.GetAllHeadOffices();

            if (headOffices != null && headOffices.Any())
            {
                result.Result = headOffices;
            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("No headoffices were found", result);
            }
            return result;
        }

        public APIResult<bool> UpdateHeadoffice(HeadOffice headOffice)
        {
            APIResult<bool> result = new APIResult<bool>();

            bool isUpdated = _hospitalSQLRepository.UpdateHeadoffice(headOffice);

            if (isUpdated)
            {
                result.Result = true;
                result.Message.Message = "Headoffice Updated successfully";
            }
            else
            {
                result.Suceess = false;
                APIResultHelper.UpdateError("Failed to update the headoffice", result);
            }
            return result;
        }
    }
}
