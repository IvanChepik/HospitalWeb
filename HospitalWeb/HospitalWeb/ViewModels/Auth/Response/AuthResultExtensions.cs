namespace HospitalWeb.ViewModels.Auth.Response
{
    public static class AuthResultExtensions
    {
        public static AuthResult<T> Success<T>(this AuthResult<T> authResult, T Payload, string message = null)
        {
            if (authResult == null) return null;
            authResult.Status = AuthStatus.Success;
            authResult.Payload = Payload;
            authResult.Message = message;
            return authResult;
        }

        public static AuthResult<T> Fail<T>(this AuthResult<T> authResult, T Payload, string message = null)
        {
            if (authResult == null) return null;
            authResult.Status = AuthStatus.Fail;
            authResult.Payload = Payload;
            authResult.Message = message;
            return authResult;
        }
    }
}