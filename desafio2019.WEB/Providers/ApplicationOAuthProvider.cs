using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace desafio2019.WEB.Providers
{
    public class ApplicationOAuthProvider
    {

        //public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        //{
        //    //if (context.ClientId == _publicClientId)
        //    //{
        //    //    Uri expectedRootUri = new Uri(context.Request.Uri, "Account/Login.aspx");

        //    //    if (expectedRootUri.AbsoluteUri == context.RedirectUri)
        //    //    {
        //    //        context.Validated();
        //    //    }
        //    //}

        //    return Task.FromResult<object>(null);
        //}

    }
}