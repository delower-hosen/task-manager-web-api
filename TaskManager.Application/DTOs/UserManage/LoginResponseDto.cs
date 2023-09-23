namespace TaskManager.Application.DTOs.UserManage
{
    public sealed class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public LoginResponseDto(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
