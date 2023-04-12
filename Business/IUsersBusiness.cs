using Business.ModelsContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [ServiceContract]
    public interface IUsersBusiness
    {

        [OperationContract]
        Task<List<UserBusinessModel>> GetUsersAsync();       
    }

}
