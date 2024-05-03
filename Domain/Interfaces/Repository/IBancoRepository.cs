
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IBancoRepository
    {
        Banco InsertBanco(Banco objBanco);
        bool UpdateBanco(Banco objBanco);
        bool AtivarBanco(int BAN_Id);
        bool DeletarBanco(int BAN_Id);
        Banco GetBancoById(int BAN_Id, bool join);
        IEnumerable<Banco> GetAllBanco(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Banco> GetAllBancoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Banco> GetAllBancoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
