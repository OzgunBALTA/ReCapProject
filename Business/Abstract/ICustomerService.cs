using Core.Utilities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<Customer> GetCustomerByCustomerId(int customerId);
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetCustomersByCompanyName(string companyName);
    }
}
