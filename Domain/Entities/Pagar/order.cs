using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pagar
{
    public class order
    {
        public string id { get; set; } //Código do pedido. Formato: or_XXXXXXXXXXXXXXXX
        public string currency { get; set; } //Moeda. Valor possível: BRL
        public string status { get; set; } //Status do pedido. Possíveis valores: Pending, Paid, Canceled, Failed.
        public string code { get; set; } //
        public customers customer { get; set; }        
        public List<item> items { get; set; }
        public List<payment> payments { get; set; }
        public bool closed { get; set; } //Indica se o pedido fechado. Valor padrão: true.
        public DateTime created_at { get; set; }
        public metadata metadata { get; set; }
        public List<Charges> charges { get; set; }
        //public int amount { get; set; } //valor 
        //public object shipping { get; set; } //Dados para entrega.
        //public object antifraud { get; set; } //Dados do serviço de antifraude.
    }

    //pedidos
    public class item
    {
        public string id { get; set; }
        public int amount { get; set; } //valor 
        public string description { get; set; }
        public int quantity { get; set; }
        public string code { get; set; }
        public string category { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        //public DateTime updated_at { get; set; }
        //public DateTime deleted_at { get; set; }
        public object order { get; set; }
    }
}
