﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace InventoryService.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public string Action { get; }

        public AuthorizationAttribute(string Action)
        {
            this.Action = Action;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Claims.Any(c => c.Type == ClaimTypes.AuthorizationDecision && c.Value == Action))
            {
                context.Result = new ForbidResult(); 
            }
        }
    }
}
