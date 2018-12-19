using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace web_api
{

    public class WrongPlayerLevelEx : Exception
    {
        public WrongPlayerLevelEx () { }

        public WrongPlayerLevelEx (string message) : base (message)
        {

        }

        public WrongPlayerLevelEx (string message, Exception inner) : base (message, inner)
        {

        }
    }
    public class WrongPlayerLevelException : ExceptionFilterAttribute
    {
        public override void OnException (ExceptionContext context)
        {
            if (context.Exception is WrongPlayerLevelEx)
            {
                context.Result = new BadRequestObjectResult ("Player level is too low for such item");
            }
        }
    }
}