
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IServicoAdicionalServices
    {
        ServicoAdicional InsertServicoAdicional(ServicoAdicional objServicoAdicional);
        bool UpdateServicoAdicional(ServicoAdicional objServicoAdicional);
        bool AtivarServicoAdicional(int SEA_Id);
        bool DeletarServicoAdicional(int SEA_Id);
        ServicoAdicional GetServicoAdicionalById(int SEA_Id, bool join);
        IEnumerable<ServicoAdicional> GetAllServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ServicoAdicional> GetAllServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ServicoAdicional> GetAllServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
