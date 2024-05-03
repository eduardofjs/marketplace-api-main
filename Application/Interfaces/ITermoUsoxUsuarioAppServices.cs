
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface ITermoUsoxUsuarioAppServices
    {
        TermoUsoxUsuario InsertTermoUsoxUsuario(TermoUsoxUsuario objTermoUsoxUsuario);
        bool UpdateTermoUsoxUsuario(TermoUsoxUsuario objTermoUsoxUsuario);
        bool AtivarTermoUsoxUsuario(int TXU_Id);
        bool DeletarTermoUsoxUsuario(int TXU_Id);
        TermoUsoxUsuario GetTermoUsoxUsuarioById(int TXU_Id, bool join);
        IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuario(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuarioByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TermoUsoxUsuario> GetAllTermoUsoxUsuarioByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
