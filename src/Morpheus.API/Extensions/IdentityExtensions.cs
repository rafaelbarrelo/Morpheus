﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Morpheus.API.Extensions
{
    public static class IdentityExtensions
    {
		public static string GetEmail(this ClaimsPrincipal current)
		{
			return GetClaimValue(current, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
		}

		public static string GetName(this ClaimsPrincipal current)
		{
			return GetClaimValue(current, "name");
		}

		public static string GetUid(this ClaimsPrincipal current)
		{
			return GetClaimValue(current, "user_id");
		}

		public static string GetProfilePicture(this ClaimsPrincipal current)
		{
			return GetClaimValue(current, "picture");
		}

		public static DateTime GetExpirationDateTime(this ClaimsPrincipal current)
		{
			var timestamp = long.Parse(GetClaimValue(current, "exp"));
			var datetime = DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
			return datetime;
		}

		private static string GetClaimValue(ClaimsPrincipal principal, string type)
		{
			return principal.Claims.FirstOrDefault(c => c.Type.Equals(type)).Value;
		}
    }
}
