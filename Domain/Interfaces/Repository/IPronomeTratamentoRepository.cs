
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IPronomeTratamentoRepository
    {
        PronomeTratamento InsertPronomeTratamento(PronomeTratamento objPronomeTratamento);
        bool UpdatePronomeTratamento(PronomeTratamento objPronomeTratamento);
        bool AtivarPronomeTratamento(int PRT_Id);
        bool DeletarPronomeTratamento(int PRT_Id);
        PronomeTratamento GetPronomeTratamentoById(int PRT_Id, bool join);
        IEnumerable<PronomeTratamento> GetAllPronomeTratamento(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<PronomeTratamento> GetAllPronomeTratamentoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<PronomeTratamento> GetAllPronomeTratamentoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
