using System.Net;

namespace SolutionsAI.Response
{
    public class GenericResponse<T>
    {
        public T Result { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        internal HttpStatusCode StatusCode { get; set; }
    }
}
