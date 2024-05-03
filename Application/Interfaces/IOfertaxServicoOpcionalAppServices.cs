using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IOfertaxServicoOpcionalAppServices
    {
        OfertaxServicoOpcional InsertOfertaxServicoOpcional(OfertaxServicoOpcional objOfertaxServicoOpcional);
        bool UpdateOfertaxServicoOpcional(OfertaxServicoOpcional objOfertaxServicoOpcional);
        bool AtivarOfertaxServicoOpcional(int OXS_Id);
        bool DeletarOfertaxServicoOpcional(int OXS_Id);
        OfertaxServicoOpcional GetOfertaxServicoOpcionalById(int OXS_Id, bool join);
        IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<OfertaxServicoOpcional> GetAllOfertaxServicoOpcionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
