using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pagar
{
    public class card
    {
        public string id { get; set; } //Código do cartão. Formato card_XXXXXXXXXXXXXXXX.
        public string number { get; set; }
        public string cvv { get; set; }
        public string last_four_digits { get; set; }
        public string first_six_digits { get; set; }
        public string brand { get; set; } //Bandeira do cartão. Para cartões de crédito, temos como valores possíveis : Elo, Mastercard, Visa, Amex, JCB, Aura, Hipercard, Diners ou Discover.Para voucher, temos como valores possíveis VR, Sodexo ou Alelo.
        public string holder_name { get; set; } // Nome impresso no cartão.
        public string holder_document { get; set; } //CPF ou CNPJ do portador do cartão.
        public int exp_month { get; set; } //Mês de vencimento do cartão.
        public int exp_year { get; set; }//Ano de vencimento do cartão. Formatos: yy ou yyyy.
        public string status { get; set; } //Status do cartão. Valores possíveis: active, deleted ou expired.
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
        public DateTime deleted_at { get; set; }
        public address billing_address { get; set; }//Endereço de cobrança.
        public customers customer { get; set; }
        public bool private_label { get; set; } //Indica se é um cartão private label.
        public string type { get; set; } //Tipo do cartão. Valores possíveis: credit ou voucher.
        public metadata metadata { get; set; }
        public options options { get; set; }

    }

    public class options { 
        public bool verify_card { get; set; }
    }
}
