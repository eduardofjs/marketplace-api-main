using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pagar
{

    public class payment
    {

        public string payment_method { get; set; } //Meio de pagamento. Valores possíveis: credit_card,debit_card, boleto, voucher, bank_transfer, safety_pay, checkout, cash, pix.
        public debit_card debit_card { get; set; }
        public credit_card credit_card { get; set; }
        public pix pix { get; set; }
        public metadata metadata { get; set; }
        //public string gateway_affiliation_id { get; set; }
        //public object voucher { get; set; }
        //public object boleto { get; set; }
        //public object bank_transfer { get; set; }
        //public object checkout { get; set; }
        //public object cash { get; set; }
        //
    }

    public class debit_card
    {
        public string statement_descriptor { get; set; }
        public card card { get; set; }
        public bool recurrence { get; set; } //Indica se é uma cobrança/pedido de recorrência. Valor padrão: false
        public authentication authentication { get; set; }//Objeto que indica se a transação de débito é autenticada ou não.
        //public metadata metadata { get; set; }
        //public int merchant_category_code { get; set; }//Código de classificação do ramo de atuação do lojista.
        //public object payload { get; set; }//Objeto de dados criptografados, tais como: GooglePay

    }

    public class credit_card
    {
        public int installments { get; set; } //Quantidade de parcelas. Valor padrão: 1.
        public string statement_descriptor { get; set; } //Texto exibido na fatura do cartão. Max: 13 caracteres para clientes PSP
        public string operation_type { get; set; } //Indica se a transação deve ser capturada auth_and_capture, autorizada auth_only, ou pré autorizada pre_auth. Valor padrão: auth_and_capture
        public card card { get; set; }
        public bool recurrence { get; set; } //Indica se é uma cobrança/pedido de recorrência. Valor padrão: false
        public metadata metadata { get; set; }
        public bool extended_limit_enabled { get; set; } //Indica se o super limite está habilitado (para cartões private label).
        public string extended_limit_code { get; set; } //Código do super limite (para cartões private label).
        public int merchant_category_code { get; set; }//Código de classificação do ramo de atuação do lojista.
        public authentication authentication { get; set; }//Objeto que indica se a transação de crédito é autenticada ou não.
        public bool auto_recovery { get; set; }//Possibilita que a retentativa offline seja desabilitada por requisição.
        public object payload { get; set; }//Objeto de dados criptografados, tais como: GooglePay

    }

    public class authentication
    {
        public string type { get; set; }
        public threed_secure threed_secure { get; set; }

    }

    public class threed_secure
    {
        public string mpi { get; set; }
        public string success_url { get; set; }

    }

    public class pix
    {
        public int expires_in { get; set; } //Data de expiração do Pix em segundos.
        //public DateTime expires_at { get; set; } //Data de expiração do Pix.        (Opcional | Mandatório caso não enviado o expires_in) [Formato: YYYY-MM-DDThh:mm:ss]
        public List<additional> additional_information { get; set; }
    }
    public class additional
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class chargeResponse
    {
        //public string id { get; set; }
        public string code { get; set; }
        public string amount { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Charges
    {
        public string id { get; set; }
        public string code { get; set; }
        public string gateway_id { get; set; }
        public int amount { get; set; }
        public string status { get; set; }
        public string currency { get; set; }
        public string payment_method { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public customers customer { get; set; }
        public LastTransaction last_transaction { get; set; }
    }


    public class AdditionalInformation
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class LastTransaction
    {
        public string id { get; set; }
        public string transaction_type { get; set; }
        public string gateway_id { get; set; }
        public int amount { get; set; }
        public string status { get; set; }
        public bool success { get; set; }
        public string qr_code { get; set; }
        public string qr_code_url { get; set; }
        public List<AdditionalInformation> additional_information { get; set; }
        public DateTime expires_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        //public GatewayResponse gateway_response { get; set; }
        //public AntifraudResponse antifraud_response { get; set; }
        public metadata metadata { get; set; }
    }

}
