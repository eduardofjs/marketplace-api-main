
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IPerfilServices
    {
        Perfil InsertPerfil(Perfil objPerfil);
        bool UpdatePerfil(Perfil objPerfil);
        bool AtivarPerfil(int PRF_Id);
        bool DeletarPerfil(int PRF_Id);
        Perfil GetPerfilById(int PRF_Id, bool join);
        IEnumerable<Perfil> GetAllPerfil(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Perfil> GetAllPerfilByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Perfil> GetAllPerfilByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
