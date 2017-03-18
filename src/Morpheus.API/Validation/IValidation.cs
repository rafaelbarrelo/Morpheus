using Microsoft.AspNetCore.Http;

public interface IValidation 
{
    HttpContext Context {get ;set; }
    bool IsValid();
}