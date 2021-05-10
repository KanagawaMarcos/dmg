using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcRouter
{
    public class InspectionService : InspectionService.InspectionServiceBase
    {
        private readonly ILogger<InspectionService> _logger;
        public InspectionService(ILogger<InspectionService> logger)
        {
            _logger = logger;
        }

        public override Task<Reply> Inspect(Inspection inspection, ServerCallContext context)
        {
            return Task.FromResult(new Reply
            {
                Message = "The retailer is " + inspection.retail
            });
        }
    }
}
