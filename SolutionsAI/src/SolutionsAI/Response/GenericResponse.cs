namespace SolutionsAI.Response
{
    public class GenericResponse<T>: BaseResponse
    {
        public T Result { get; set; }
    }
}
