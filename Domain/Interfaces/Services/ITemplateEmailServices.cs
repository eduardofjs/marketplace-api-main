
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface ITemplateEmailServices
    {
        TemplateEmail InsertTemplateEmail(TemplateEmail objTemplateEmail);
        bool UpdateTemplateEmail(TemplateEmail objTemplateEmail);
        bool AtivarTemplateEmail(int TME_Id);
        bool DeletarTemplateEmail(int TME_Id);
        TemplateEmail GetTemplateEmailById(int TME_Id, bool join);
        IEnumerable<TemplateEmail> GetAllTemplateEmail(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TemplateEmail> GetAllTemplateEmailByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TemplateEmail> GetAllTemplateEmailByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
