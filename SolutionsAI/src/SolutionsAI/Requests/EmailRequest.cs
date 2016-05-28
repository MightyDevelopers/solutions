namespace SolutionsAI.Requests
{
    public class EmailRequest
    {
        public string Email { get; set; }

        public EmailRequest(string email)
        {
            Email = email;
        }
    }
}
