using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcRouter
{
    public class InspectorService : Inspector.InspectorBase
    {
        private readonly ILogger<InspectorService> _logger;
        public InspectorService(ILogger<InspectorService> logger)
        {
            _logger = logger;
        }

        public override Task<Reply> SaveInspection(Inspection inspection, ServerCallContext context)
        {
            return Task.FromResult(new Reply
            {
                Message = "The retailer is " + inspection.Retailer
            });
        }
    }
}
