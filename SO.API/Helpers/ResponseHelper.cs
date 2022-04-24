using System;
using System.Collections.Generic;
using System.Text;
using SO.API.ResponseExceptions;

namespace SO.API.Helpers
{
    public static class ResponseHelper
    {
        public static void ReturnNotFound(string errorMessage)
        {
            throw new NotFoundResponse(errorMessage);
        }

        public static void ReturnBadRequest(string errorMessage)
        {
            throw new BadRequestResponse(errorMessage);
        }
    }
}
