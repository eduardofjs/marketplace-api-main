using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dto;

namespace Application.Interfaces
{
    public interface IDigitalTwinAppServices
    {
        Task<String> Login();

        void InsertCompany(DigitalTwinCompanyDto Company, string AccessToken = null);
        void UpdateCompany(DigitalTwinCompanyDto Company, string AccessToken = null);
        void InsertProduct(DigitalTwinProductDto Product, string AccessToken = null);
        void UpdateProduct(DigitalTwinProductDto Product, string AccessToken = null);
    }
}
