using System.Net;

namespace Models.Exceptions
{
    public class NotFoundException : CustomException
    {
        private const string DataNotFoundMessage = "Data is not founded";

        public NotFoundException(string message = DataNotFoundMessage) : base(message , HttpStatusCode.NotFound) { }
    }
}
