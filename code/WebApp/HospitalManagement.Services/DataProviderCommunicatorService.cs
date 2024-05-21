using HospitalManagement.Core.Common.Interfaces;
using HospitalManagement.Core.Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public class DataProviderCommunicatorService : CommunicatorServiceBase, IDataProviderCommunicator
    {
        private ILogger logger;
        public DataProviderCommunicatorService(ILoggerFactory loggerFactory, DataProviderCommunicationInfo dataProviderCommunicationInfo) : base(loggerFactory)
        {
            URL = dataProviderCommunicationInfo.Address;
        }

        public override string URL { get; set; }
    }
}
