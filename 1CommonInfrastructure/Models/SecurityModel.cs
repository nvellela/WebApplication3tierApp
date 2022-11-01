namespace _1CommonInfrastructure.Models
{
    public class SecurityModel
    {
        public int UserAccountID { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        //Collection Navigation Reference
        public List<string> SystemActionCodes { get; set; }
    }
}
