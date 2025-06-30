using SQLADO_3.Model;

namespace SQLADO_3.Services
{
    public interface IEmployee
    {
        List<EMPLOYMODEL> Get();
        EMPLOYMODEL CREATING(EMPLOYMODEL mPLOYMODEL);
    }
}
