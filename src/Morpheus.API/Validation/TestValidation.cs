
using System;
using Microsoft.AspNetCore.Http;

public class TestValidation : IValidation
{
    public HttpContext Context {get; set;}
    
    bool IValidation.IsValid()
    {
        var test = DateTime.Now.Millisecond % 2;
        return test == 0;
    }
}