using NomadLife.Shared.Interfaces;

namespace NomadLife.Web.Services;

public class CommonService : ICommonService
{
    public bool IsWeb => true;
    public bool IsMobile => false;
}
