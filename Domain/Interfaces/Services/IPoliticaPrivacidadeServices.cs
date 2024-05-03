
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IPoliticaPrivacidadeServices
    {
        PoliticaPrivacidade InsertPoliticaPrivacidade(PoliticaPrivacidade objPoliticaPrivacidade);
        bool UpdatePoliticaPrivacidade(PoliticaPrivacidade objPoliticaPrivacidade);
        bool AtivarPoliticaPrivacidade(int PVD_Id);
        bool DeletarPoliticaPrivacidade(int PVD_Id);
        PoliticaPrivacidade GetPoliticaPrivacidadeById(int PVD_Id, bool join);
        IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<PoliticaPrivacidade> GetAllPoliticaPrivacidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
