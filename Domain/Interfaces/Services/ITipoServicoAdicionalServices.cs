
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface ITipoServicoAdicionalServices
    {
        TipoServicoAdicional InsertTipoServicoAdicional(TipoServicoAdicional objTipoServicoAdicional);
        bool UpdateTipoServicoAdicional(TipoServicoAdicional objTipoServicoAdicional);
        bool AtivarTipoServicoAdicional(int TSA_Id);
        bool DeletarTipoServicoAdicional(int TSA_Id);
        TipoServicoAdicional GetTipoServicoAdicionalById(int TSA_Id, bool join);
        IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoServicoAdicional> GetAllTipoServicoAdicionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
