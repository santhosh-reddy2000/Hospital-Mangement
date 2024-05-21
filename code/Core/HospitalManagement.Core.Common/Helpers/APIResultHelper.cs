using HospitalManagement.Core.Common.Enums;
using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Common.Helpers
{
    public static class APIResultHelper
    {
        public static APIResult<T> UpdateException<T>(Exception ex, APIResult<T> apiResult)
        {
            if (apiResult == null)
            {
                apiResult = new APIResult<T>();
            }

            apiResult.Message.MessageType = MessageTypeEnum.Critical;
            apiResult.Message.Message = ex.Message;
            apiResult.Suceess = false;

            return apiResult;
        }

        public static APIResult<T> UpdateError<T>(string errorMessage, APIResult<T> apiresult)
        {
            if (apiresult == null)
            {
                apiresult = new APIResult<T>();
            }

            apiresult.Message.MessageType = MessageTypeEnum.Critical;
            apiresult.Message.Message = errorMessage;

            return apiresult;
        }
    }
}
