using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IOfertaxServicoAdicionalRepository
    {
        OfertaxServicoAdicional InsertOfertaxServicoAdicional(OfertaxServicoAdicional objOfertaxServicoAdicional);
        bool UpdateOfertaxServicoAdicional(OfertaxServicoAdicional objOfertaxServicoAdicional);
        bool AtivarOfertaxServicoAdicional(int OXA_Id);
        bool DeletarOfertaxServicoAdicional(int OXA_Id);
        OfertaxServicoAdicional GetOfertaxServicoAdicionalById(int OXA_Id, bool join);
        IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaxServicoAdicional> GetAllOfertaxServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
