using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Repository;

namespace GrpcRouter
{
    public class InspectorService : Inspector.InspectorBase
    {
        private readonly ILogger<InspectorService> _logger;
        public InspectorService(ILogger<InspectorService> logger)
        {
            _logger = logger;
        }

        public override Task<Reply> SaveInspection(InspectionRequest inspection, ServerCallContext context)
        {
            try
            {
                Database.saveInspection(inspection.Retailer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.FromResult(new Reply
            {
                Message = "The retailer is " + inspection.Retailer
            });
        }
    }
}
