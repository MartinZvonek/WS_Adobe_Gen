using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Adobe_Gen.App_Class
{
    public class ResultStatus
    {
        public string Status_kod { get; set; }
        public string Status_text { get; set; }

        public ResultStatus(string _status_kod, string _status_text)
        {
            Status_kod = _status_kod;
            Status_text = _status_text;
        }

        public ResultStatus()
        {
            Status_kod = "";
            Status_text = "";
        }
    }

    /// <summary>
    /// Struktura pro informace o webove sluzbe
    /// </summary>
    public struct WS602Info
    {
        public string URL { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Certifikat { get; set; }
    }

    /// <summary>
    /// Struktura pro informace o webove sluzbe
    /// </summary>
    public struct ResultWSInfo
    {
        public WSInfo Info { get; set; }
        public ResultStatus Status { get; set; }
    }

    public class WSInfo
    {
        public string WS_verze { get; set; }
        public string IP_adresa { get; set; }
        public string ETR_Provoz { get; set; }
        public string DB_data { get; set; }
        public string DB_soubory { get; set; }
        public string WS_user { get; set; }
        public string URL_602_LTD { get; set; }
        
        public WSInfo(string _WS_verze, string _IP_adresa, string _ETR_verze, string _ETR_Provoz, string _DB_data, string _DB_soubory, string _WS_user, string _URL_602_LTD)
        {
            WS_verze = _WS_verze;
            IP_adresa = _IP_adresa;
            ETR_Provoz = _ETR_Provoz;
            DB_data = _DB_data;
            DB_soubory = _DB_soubory;
            WS_user = _WS_user;
            URL_602_LTD = _URL_602_LTD;
        }

        public WSInfo()
        {
            WS_verze = "";
            IP_adresa = "";
            ETR_Provoz = "";
            DB_data = "";
            DB_soubory = "";
            WS_user = "";
            URL_602_LTD = "";
        }
    }
}