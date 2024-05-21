using HospitalManagement.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Common.Interfaces
{
    public interface ICommunicatorBase
    {
        string URL { get; }

        APIResult<T> PostToServer<T>(string url, object parameter, string token = "" );

        APIResult<T> GetServerResponse<T>(string url, string token = "");
    }
}
