using Code;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog {

public class AccountController : Controller {

    IAccountService mAccountService;
   
    public AccountController(IAccountService aAccountService) {
        mAccountService = aAccountService;
    }

    [AllowAnonymous]
    public ActionResult LogIn(string returnUrl) {
        ViewBag.ReturnUrl = returnUrl;
        ViewBag.Title = "Blog | Log In";
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult LogIn(string returnUrl, SignInViewModel aModel) {       
        if (ModelState.IsValid) {
            var user = mAccountService.GetAccount(aModel.Email, aModel.Password);
            if (user != null) {
                var userData = new UserData() { AccountId = user.AccountId, Email = user.Email };
                Request.SaveUserDataCookie(userData);

                if (returnUrl != null) {
                    return Redirect(returnUrl);
                }
                else {
                    return RedirectToAction("Index", "Home");
                }
            }
            else {
                ModelState.AddModelError("", "Invalid Email Or Password");
            }     
        }
        return View();
    }

    public ActionResult LogOut() {
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.ExpireCookie();

        return RedirectToAction("Index", "Home");
    }

    [AllowAnonymous]
    public ActionResult SignUp(string returnUrl) {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public ActionResult SignUp(string returnUrl, SignInViewModel aModel) {       
        if (ModelState.IsValid) {
            var account = new Account() { Email = aModel.Email, Password = aModel.Password };
            account = mAccountService.AddAccount(account);
            if (account != null) {
                var userData = new UserData() { AccountId = account.AccountId, Email = account.Email };
                Request.SaveUserDataCookie(userData);

                if (returnUrl != null) {
                    return Redirect(returnUrl);
                }
                else {
                    return RedirectToAction("Index", "Home");
                }
            }
            else {
                ModelState.AddModelError("", "Invalid Email Or Password");
            }
        }
        return View();
    }

}

} // namespace
