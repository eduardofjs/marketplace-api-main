
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IPoliticaPrivacidadexUsuarioRepository
    {
        PoliticaPrivacidadexUsuario InsertPoliticaPrivacidadexUsuario(PoliticaPrivacidadexUsuario objPoliticaPrivacidadexUsuario);
        bool UpdatePoliticaPrivacidadexUsuario(PoliticaPrivacidadexUsuario objPoliticaPrivacidadexUsuario);
        bool AtivarPoliticaPrivacidadexUsuario(int PVU_Id);
        bool DeletarPoliticaPrivacidadexUsuario(int PVU_Id);
        PoliticaPrivacidadexUsuario GetPoliticaPrivacidadexUsuarioById(int PVU_Id, bool join);
        IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<PoliticaPrivacidadexUsuario> GetAllPoliticaPrivacidadexUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
