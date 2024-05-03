
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class TemplateEmailAppServices : ITemplateEmailAppServices
    {
        private readonly ITemplateEmailServices _TemplateEmailServices;
               

        public TemplateEmailAppServices(ITemplateEmailServices TemplateEmailServices        )
        {
            _TemplateEmailServices = TemplateEmailServices;
                 
        }

        public TemplateEmail InsertTemplateEmail(TemplateEmail objTemplateEmail)
        {
                   
            
            return _TemplateEmailServices.InsertTemplateEmail(objTemplateEmail);
        }

        public bool UpdateTemplateEmail(TemplateEmail objTemplateEmail)
        {            
                  
            return _TemplateEmailServices.UpdateTemplateEmail(objTemplateEmail);
        }

        public bool AtivarTemplateEmail(int TME_Id)
        {
            return _TemplateEmailServices.AtivarTemplateEmail(TME_Id);
        }

        public bool DeletarTemplateEmail(int TME_Id)
        {
            return _TemplateEmailServices.DeletarTemplateEmail(TME_Id);
        }

        public TemplateEmail GetTemplateEmailById(int TME_Id, bool join)
        {
            return _TemplateEmailServices.GetTemplateEmailById(TME_Id, join);
        }

        public IEnumerable<TemplateEmail> GetAllTemplateEmail(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TemplateEmailServices.GetAllTemplateEmail(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TemplateEmail> GetAllTemplateEmailByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TemplateEmailServices.GetAllTemplateEmailByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TemplateEmail> GetAllTemplateEmailByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TemplateEmailServices.GetAllTemplateEmailByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

