using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IOfertaServices
    {
        Oferta InsertOferta(Oferta objOferta);
        bool UpdateOferta(Oferta objOferta);
        bool AtivarOferta(int OFE_Id);
        bool DeletarOferta(int OFE_Id);
        Oferta GetOfertaById(int OFE_Id, bool join);
        Oferta GetOfertaEditarById(int OFE_Id, bool join);
        IEnumerable<Oferta> GetAllOferta(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Oferta> GetAllOfertaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Oferta> GetAllOfertaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        bool AprovarOferta(int OFE_Id);
        bool ReprovarOferta(int OFE_Id);

    }
}
