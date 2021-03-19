using System;
using System.Collections.Generic;
using System.Text;

namespace Thrush.Services.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidUrl(this string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
