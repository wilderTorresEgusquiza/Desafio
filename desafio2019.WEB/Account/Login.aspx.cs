using System;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI;
using ASPSnippets.FaceBookAPI;
using Google.Apis.Discovery.v1;
using Google.Apis.Discovery.v1.Data;
using Google.Apis.Services;

namespace desafio2019.WEB.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            FaceBookConnect.API_Key = "2242043896069687";   //2242043896069687
            FaceBookConnect.API_Secret = "a9d7e59646b9d0f1a1c289f26adfb04d";    //4d893911bebc078d14578a765e685727
            if (!IsPostBack)
            {
                if (Request.QueryString["error"] == "access_denied")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
                    return;
                }

                string code = Request.QueryString["code"];
                if (!string.IsNullOrEmpty(code))
                {
                    string data = FaceBookConnect.Fetch(code, "me?fields=id,name,email");
                    FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                    faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                    pnlFaceBookUser.Visible = true;
                    lblId.Text = faceBookUser.Id;
                    lblUserName.Text = faceBookUser.UserName;
                    lblName.Text = faceBookUser.Name;
                    lblEmail.Text = faceBookUser.Email;
                    ProfileImage.ImageUrl = faceBookUser.PictureUrl;

                }
            }


        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //// Validar la contraseña del usuario
                //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                //// Esto no cuenta los errores de inicio de sesión hacia el bloqueo de cuenta
                //// Para habilitar los errores de contraseña para desencadenar el bloqueo, cambie a shouldLockout: true
                //var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                //switch (result)
                //{
                //    case SignInStatus.Success:
                //        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                //        break;
                //    case SignInStatus.LockedOut:
                //        Response.Redirect("/Account/Lockout");
                //        break;
                //    case SignInStatus.RequiresVerification:
                //        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                //                                        Request.QueryString["ReturnUrl"],
                //                                        RememberMe.Checked),
                //                          true);
                //        break;
                //    case SignInStatus.Failure:
                //    default:
                //        FailureText.Text = "Intento de inicio de sesión no válido";
                //        ErrorMessage.Visible = true;
                //        break;
                //}
            }
        }

        private async Task Run()
        {
            // Create the service.
            var service = new DiscoveryService(new BaseClientService.Initializer
            {
                ApplicationName = "564714434594-fo9o0s4cdisjkp6q5bugqj96hiuel9dt.apps.googleusercontent.com",
                ApiKey = "WDVy9ZzIthP-ZAJrVz_ZdShE",
            });


            var result = await service.Apis.List().ExecuteAsync();

            // Display the results.
            if (result.Items != null)
            {
                //foreach (DirectoryList.ItemsData api in result.Items)
                //{
                //    Console.WriteLine(api.Id + " - " + api.Title);
                //}
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Run().Wait();
        





            FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);

        }

        public class FaceBookUser
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string UserName { get; set; }
            public string PictureUrl { get; set; }
            public string Email { get; set; }
        }


    }
}