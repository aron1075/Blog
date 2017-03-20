using System;
using System.Web;
using System.Web.Security;

namespace Blog {

    public static class HttpResponseBaseExtension {

    public static void ExpireCookie(this HttpResponseBase aHttpResponse) {
        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, string.Empty);
        cookie.Expires = DateTime.Now.AddDays(-1);
        aHttpResponse.Cookies.Add(cookie);
    }

}

} // namespace