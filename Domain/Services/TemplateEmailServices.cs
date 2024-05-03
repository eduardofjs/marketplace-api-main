
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TemplateEmailServices : ITemplateEmailServices
    {
        private readonly ITemplateEmailRepository _TemplateEmailRepo;

        public TemplateEmailServices(ITemplateEmailRepository TemplateEmailRepo)
        {
            _TemplateEmailRepo = TemplateEmailRepo;
        }
		
        public TemplateEmail InsertTemplateEmail(TemplateEmail objTemplateEmail)
        {
            return _TemplateEmailRepo.InsertTemplateEmail(objTemplateEmail);
        }

        public bool UpdateTemplateEmail(TemplateEmail objTemplateEmail)
        {
            return _TemplateEmailRepo.UpdateTemplateEmail(objTemplateEmail);
        }

        public bool AtivarTemplateEmail(int TME_Id)
        {
            return _TemplateEmailRepo.AtivarTemplateEmail(TME_Id);
        }

        public bool DeletarTemplateEmail(int TME_Id)
        {
            return _TemplateEmailRepo.DeletarTemplateEmail(TME_Id);
        }
        
        public TemplateEmail GetTemplateEmailById(int TME_Id, bool join)
        {
            return _TemplateEmailRepo.GetTemplateEmailById(TME_Id, join);
        }

        public IEnumerable<TemplateEmail> GetAllTemplateEmail(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TemplateEmailRepo.GetAllTemplateEmail(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TemplateEmail> GetAllTemplateEmailByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TemplateEmailRepo.GetAllTemplateEmailByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TemplateEmail> GetAllTemplateEmailByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TemplateEmailRepo.GetAllTemplateEmailByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

