namespace UserManagement.WebMS.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public ViewResult Index() => View();
}
