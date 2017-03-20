using Code;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Security;

namespace Blog {

public static class HttpRequestBaseExtension {

    public static UserData GetUserDataCookie(this HttpRequestBase aHttpRequest) {
        //--------------------------------------------| For unit testing get test user data
        if (aHttpRequest == null) {
            return null;
        }

        HttpCookie cookie = aHttpRequest.Cookies[FormsAuthentication.FormsCookieName];
        if (cookie != null) {
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            var userData = JsonConvert.DeserializeObject<UserData>(ticket.UserData);          
            //
            return userData;
        }
        return null;
    }

    public static void SaveUserDataCookie(this HttpRequestBase aHttpRequest, UserData aUser) {
        if (aHttpRequest.GetUserDataCookie() != null) return;
        //
        var expireDate = DateTime.Now.AddMinutes(60);      
        var userData = JsonConvert.SerializeObject(aUser);

        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1,
            aUser.Email,
            DateTime.Now,
            expireDate,
            true,
            userData,
            FormsAuthentication.FormsCookiePath);

        string encryptedTicket = FormsAuthentication.Encrypt(ticket);
        HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket));
    }

}

} // namespace