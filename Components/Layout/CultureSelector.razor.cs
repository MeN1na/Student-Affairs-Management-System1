using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace BlazorAppServer.Components.Layout;

public partial class CultureSelector
{
    private CultureInfo[] cultures = new[]
    {
            new CultureInfo("en-US"),
            new CultureInfo("ar-EG")
        };

    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                CultureInfo.DefaultThreadCurrentCulture = value;
                CultureInfo.DefaultThreadCurrentUICulture = value;
                /*
                string cookieValue = CookieRequestCultureProvider.MakeCookieValue(requestCulture);
                HttpContextAccessor.HttpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    cookieValue,
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
                */
                RequestCulture requestCulture = new RequestCulture(value.Name);


                _navManager.NavigateTo(_navManager.Uri, forceLoad: true);
            }
        }
    }

}