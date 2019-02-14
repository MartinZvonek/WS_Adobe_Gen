using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Xml;
using System.Text;
using WS_Adobe_Gen.App_Class;
using WS_Adobe_Gen.LTD;
//using WS_Adobe_Gen.konverze_DA;
//using WS_Adobe_Gen.etr_forms;
//using WS_Adobe_Gen.etr_konverze_pdfa;
//using WS_Adobe_Gen.konverze_DA;

namespace WS_Adobe_Gen
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebService(Namespace = "http://adobe.com/idp/services")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AdobeGenService : System.Web.Services.WebService
    {
        public LTDWebService service = new LTDWebService();
        public string nazev_souboru;
        public string cesta_souboru;
        public byte[] data_souboru = null;

        public string report = "";
        public string profiles = "";
        public string error = "";
        public byte[] output = null;

        public bool logovani = false;

        public int vysledek = 0;
        public WS602Info WS602Info = new WS602Info();


        private void SaveFileStream(String path, Stream stream) 
        {
            using (var filestream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(filestream);
            }
        }

        //[WebMethod]
        public string test2()
        {
            List<ConcatFile> pole = new List<ConcatFile>();

            ConcatOptions conOptions = new ConcatOptions();
            //[] seynam; = new ConcatFile[]();

            
            ConcatFile source = new ConcatFile();
            ConcatFile att = new ConcatFile();

            source.Data = System.IO.File.ReadAllBytes(@"C:\Users\mz311858\Documents\VSinventura.pdf"); ;
            source.Name = "VSinventura.pdf";

            att.Data = System.IO.File.ReadAllBytes(@"E:\Sdělení soudu o odvolání.TXT"); ;
            att.Name = "Sdělení soudu o odvolání.TXT";

            pole.Add(source);
            pole.Add(att);
            
            string StatusText = "";
           
            //public BLOB invoke() {
            AssemblerResult outAsembler = new AssemblerResult();

            BLOB outBlob = new BLOB();

            ConvertOptions ConvertOptions = new ConvertOptions();

            //dokumentu převedu do PDF
            //Je li tisk prosty, tak se přidá hlavička a patička
            //není li tisk, tak se vystup spoji se šablonou
            //Render_PDF_From_XML:<druh>A-D-69</druh> - actipn_upload_to_db.asp
            //Render_PDF_From_XML:<druh>D-A-69</druh> - prevedeni_dle_69
            //Render_PDF_From_XML:<druh>D-zmena-69</druh> - prevod_formatu

            
            //stavOUT = "";
            error = "";

            ConvertOptions.PdfFormat = PdfFormat.PDF;

            //ConvertOptions.


            service.Url = "http://10.85.68.11:8081/ltd/ltd.asmx";

            try
            {
                vysledek = service.Concat(pole.ToArray(), conOptions, ConvertOptions, out output, out report);
            }
            catch (Exception ddd)
            {
                StatusText = ddd.Message;
                return StatusText;
            }

            OperationContext context = OperationContext.Current;

            if (context != null && context.RequestContext != null)
            {

                //Message msg = context.RequestContext.RequestMessage;

                //string reqXML = msg.ToString();

            }

            if (vysledek == 0)
            {
                System.IO.File.WriteAllBytes(@"e:\602_out_1.pdf", output);
            }
            else
            {
                StatusText = report;

                return StatusText;
            }

            return StatusText;
        }

        //[WebMethod]
        public string test1()
        {
            byte[] xx_file_con = System.IO.File.ReadAllBytes(@"C:\Users\mz311858\Documents\VSinventura.pdf");
            string StatusText = "";
            string text_1 = "Prostý převod dokumentu z digitální do analogové podoby";
            string text_2 = "Vyhotovil: 30.01.2019 09:26:00 Martin Zvonek";
            string text_3 = "";

            int tisk_prosty = 1;
                        
            //public BLOB invoke() {
            AssemblerResult outAsembler = new AssemblerResult();
            
            BLOB outBlob = new BLOB();
            
            ConvertOptions ConvertOptions = new ConvertOptions();

            //dokumentu převedu do PDF
            //Je li tisk prosty, tak se přidá hlavička a patička
            //není li tisk, tak se vystup spoji se šablonou
            //Render_PDF_From_XML:<druh>A-D-69</druh> - actipn_upload_to_db.asp
            //Render_PDF_From_XML:<druh>D-A-69</druh> - prevedeni_dle_69
            //Render_PDF_From_XML:<druh>D-zmena-69</druh> - prevod_formatu

            if (tisk_prosty == 1)
            {
                //přidám k tomu hlavicku a paticku                    

                HF_Options hlavicka = new HF_Options();
                HF_Options paticka = new HF_Options();
                //hlavicka.

                hlavicka.HorizontalAlignment = HorizontalPosition.Center;
                hlavicka.Mode = PlacementMode.AllPages;
                hlavicka.VerticalAlignment = VerticalPosition.Top;
                hlavicka.Text = text_1 + "\n" + text_2 + "\n" + text_3;
                hlavicka.FontSize = 8;

                paticka.HorizontalAlignment = HorizontalPosition.Center;
                paticka.Mode = PlacementMode.AllPages;
                paticka.VerticalAlignment = VerticalPosition.Bottom;
                paticka.Text = text_1 + "\n" + text_2 + "\n" + text_3;
                paticka.FontSize = 9;
                ConvertOptions.Header = hlavicka;
                ConvertOptions.Footer = paticka;
            }
            else
            {
                //provedu sloučení 
                //docIN_orig - hlavni
                //docIN_form - přilepuju tuto šablonu
                //ConvertOptions.EnableMerge = true;
                //ConvertOptions.Merge = new PdfMerge();
                //ConvertOptions.Merge.Mode = MergeMode.End;




            }


            //stavOUT = "";
            error = "";

            ConvertOptions.PdfFormat = PdfFormat.PDF;

            //ConvertOptions.


            service.Url = "http://10.85.68.11:8081/ltd/ltd.asmx";

            try
            {
                vysledek = service.ConvertFileEx(xx_file_con, "VSinventura.pdf", ConvertOptions, "", out output, out report, out error);
            }
            catch (Exception ddd)
            {
                StatusText = ddd.Message;
                return StatusText;               
            }

            OperationContext context = OperationContext.Current;

            if (context != null && context.RequestContext != null)
            {

                //Message msg = context.RequestContext.RequestMessage;

                //string reqXML = msg.ToString();

            }

            if (vysledek == 0)
            {
                System.IO.File.WriteAllBytes(@"e:\602_out.pdf", output);
            }
            else
            {
                StatusText = report;
                
                return StatusText;
            }

            return StatusText;

        }

        

        [WebMethod]
        public BLOB etr_konverze_pdfa(BLOB docIN, int forms, [System.Xml.Serialization.XmlIgnoreAttribute()] bool formsSpecified, int podepsat, [System.Xml.Serialization.XmlIgnoreAttribute()] bool podepsatSpecified, string podpis_pole, TSPOptionSpec razitko, string typ, Credential znacka, out string StatusText, out string StatusKod, out BLOB docOUT, out bool isPDF, out BLOB log)
        {
            BLOB outBlob = new BLOB();

            if (podepsatSpecified == false) 
            { 
                podepsat = 1;
            }


            if (logovani)
            {
                XmlDocument xmlSoapRequest = new XmlDocument();

                // Get raw request body
                using (Stream receiveStream = HttpContext.Current.Request.InputStream)
                {
                    receiveStream.Position = 0;
                    using (StreamReader readStream =
                                           new StreamReader(receiveStream, System.Text.Encoding.UTF8))
                    {
                        xmlSoapRequest.Load(readStream);
                    }

                    xmlSoapRequest.Save(@"C:\Sluzby\602\etr_konverze_pdfa_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xml");
                }
            }

            //WS_Adobe_Gen.etr_konverze_pdfa.BLOB outBlob = new WS_Adobe_Gen.etr_konverze_pdfa.BLOB();
            
            docOUT = new BLOB();
            log = new BLOB();
            isPDF = true;                       
            
            try
            {
                WS602Info = Database.getWS602Info();
            }
            catch (Exception ddd) 
            { 
                StatusText = ddd.Message;
                StatusKod = "1111";
                return outBlob;
            }

            if (WS602Info.URL == "")
            {
                StatusText = "Není vyplněna URL adresa pro webovou službu Software602 LTD!";
                StatusKod = "2222";
                return outBlob;
            }

            if (WS602Info.Certifikat == "")
            {
                //StatusText = "Není cesta k podepisujícímu systémovému certifikátu (značce / pečeti)!";
                //StatusKod = "3333";
                //return outBlob;
            }
            
            StatusText = "";
            StatusKod = "0000";
            ConvertOptions ConvertOptions = new ConvertOptions();
            ConvertOptions.PdfFormat = PdfFormat.PDF_A_2b;


            if (podepsat == 1)
            {
                ConvertOptions.AddSignature = true;
                ConvertOptions.Signature = new PdfSignature();

                /*if (Database.getSetting("aplikace_provozovatel") == "VS")
                {
                    ConvertOptions.Signature.CertificateID = WS602Info.Certifikat;
                }
                else
                {
                    ConvertOptions.Signature.CertificateID = "PEMfile:" + WS602Info.Certifikat;
                }
                */

                ConvertOptions.Signature.CertificateID = WS602Info.Certifikat;

                ConvertOptions.Signature.AddTimeStamp = true;
            }

            service.Url = WS602Info.URL;

            try
            {
                vysledek = service.ConvertFileEx(docIN.binaryData, "test." + typ, ConvertOptions, "", out output, out report, out error);
            }
            catch (Exception ddd)
            {
                StatusText = ddd.Message+ " [Service URL: "+ service.Url + "]";
                StatusKod = "4444";
                return outBlob;
            }

            if (vysledek == 0)
            {
                outBlob.binaryData = output;
                outBlob.contentType = "application/pdf";

                docOUT = outBlob;
            }
            else
            {
                StatusText = report;
                StatusKod = "5555";
                return outBlob;
            }

            return outBlob;
        }

        [WebMethod]
        public BLOB Add_watermark(BLOB DocIn, string Watermark_text_1, string Watermark_text_2, out string err_txt)
        {
            if (logovani)
            {
                XmlDocument xmlSoapRequest = new XmlDocument();

                // Get raw request body
                using (Stream receiveStream = HttpContext.Current.Request.InputStream)
                {
                    receiveStream.Position = 0;
                    using (StreamReader readStream =
                                           new StreamReader(receiveStream, System.Text.Encoding.UTF8))
                    {
                        xmlSoapRequest.Load(readStream);
                    }

                    xmlSoapRequest.Save(@"C:\Sluzby\602\Add_watermark_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xml");
                }
            }

            BLOB outBlob = new BLOB();

            try
            {
                WS602Info = Database.getWS602Info();
            }
            catch (Exception ddd)
            {
                err_txt = ddd.Message;
                return outBlob;
            }

            if (WS602Info.URL == "")
            {
                err_txt = "Není vyplněna URL adresa pro webovou službu Software602 LTD!";
                return outBlob;
            }

            if (WS602Info.Certifikat == "")
            {
                //err_txt = "Není cesta k podepisujícímu systémovému certifikátu (značce / pečeti)!";
                //return outBlob;
            }

            //public BLOB invoke() {
            
            err_txt = "";
            ConvertOptions ConvertOptions = new ConvertOptions();

            ConvertOptions.PdfFormat = PdfFormat.PDF;
            ConvertOptions.AddWatermark = true;

            ConvertOptions.Watermark = new PdfWatermark();
            ConvertOptions.Watermark.Angle = 1;
            ConvertOptions.Watermark.FontSize = 20;
            ConvertOptions.Watermark.Text = Watermark_text_1 + Environment.NewLine + Watermark_text_2;

            service.Url = WS602Info.URL;

            try
            {
                vysledek = service.ConvertFileEx(DocIn.binaryData, "test.rtf", ConvertOptions, "", out output, out report, out error);
            }
            catch (Exception ddd)
            {
                err_txt = ddd.Message;
                return outBlob;
            }

            if (vysledek == 0)
            {
                outBlob.binaryData = output;
                outBlob.contentType = "application/pdf";
            }
            else 
            {
                err_txt = error;
                return outBlob;
            }
            
            //pridani vodoznaku
            return outBlob;
        }

        
        [WebMethod]
        public AssemblerResult konverze_DA(BLOB docIN_form, BLOB docIN_orig, string text_1, string text_2, string text_3, int tisk_prosty, [System.Xml.Serialization.XmlIgnoreAttribute()] bool tisk_prostySpecified, string typ, out string StatusKod, out string StatusText, out BLOB docOUT, out int muj_vystup)
        {
            if (logovani)
            {
                XmlDocument xmlSoapRequest = new XmlDocument();

                // Get raw request body
                using (Stream receiveStream = HttpContext.Current.Request.InputStream)
                {
                    receiveStream.Position = 0;
                    using (StreamReader readStream =
                                           new StreamReader(receiveStream, System.Text.Encoding.UTF8))
                    {
                        xmlSoapRequest.Load(readStream);
                    }

                    xmlSoapRequest.Save(@"C:\Sluzby\602\konverze_DA_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xml");
                }
            }

            //public BLOB invoke() {
            AssemblerResult outAsembler = new AssemblerResult();
            StatusText = "";
            docOUT = new BLOB(); 
            muj_vystup = 0;
            StatusKod = "0000";

            BLOB outBlob = new BLOB();

            try
            {
                WS602Info = Database.getWS602Info();
            }
            catch (Exception ddd)
            {
                StatusText = ddd.Message;
                StatusKod = "1111";
                return outAsembler;
            }

            if (WS602Info.URL == "")
            {
                StatusText = "Není vyplněna URL adresa pro webovou službu Software602 LTD!";
                StatusKod = "2222";
                return outAsembler;
            }

            if (WS602Info.Certifikat == "")
            {
                //StatusText = "Není cesta k podepisujícímu systémovému certifikátu (značce / pečeti)!";
                //StatusKod = "3333";
                //return outAsembler;
            }

            ConvertOptions ConvertOptions = new ConvertOptions();

            //dokumentu převedu do PDF
            //Je li tisk prosty, tak se přidá hlavička a patička
            //není li tisk, tak se vystup spoji se šablonou
            //Render_PDF_From_XML:<druh>A-D-69</druh> - actipn_upload_to_db.asp
            //Render_PDF_From_XML:<druh>D-A-69</druh> - prevedeni_dle_69
            //Render_PDF_From_XML:<druh>D-zmena-69</druh> - prevod_formatu

            if (tisk_prosty == 1)
            {
                //přidám k tomu hlavicku a paticku                    

                HF_Options hlavicka = new HF_Options();
                HF_Options paticka = new HF_Options();
                //hlavicka.

                hlavicka.HorizontalAlignment = HorizontalPosition.Center;
                hlavicka.Mode = PlacementMode.AllPages;
                hlavicka.VerticalAlignment = VerticalPosition.Top;
                hlavicka.Text = text_1 + "\n" + text_2 + "\n" + text_3;
                hlavicka.FontSize = 8;

                paticka.HorizontalAlignment = HorizontalPosition.Center;
                paticka.Mode = PlacementMode.AllPages;
                paticka.VerticalAlignment = VerticalPosition.Bottom;
                paticka.Text = text_1 + "\n" + text_2 + "\n" + text_3;
                paticka.FontSize = 8;

                ConvertOptions.Header = hlavicka;
                ConvertOptions.Footer = paticka;

                ConvertOptions.PdfFormat = PdfFormat.PDF;

                //ConvertOptions.


                service.Url = WS602Info.URL;

                try
                {
                    vysledek = service.ConvertFileEx(docIN_orig.binaryData, "test." + typ, ConvertOptions, "", out output, out report, out error);
                }
                catch (Exception ddd)
                {
                    StatusText = ddd.Message;
                    StatusKod = "4444";
                    return outAsembler;
                }
            }
            else
            {

                List<ConcatFile> pole = new List<ConcatFile>();

                ConcatOptions conOptions = new ConcatOptions();
                
                ConcatFile source = new ConcatFile();
                ConcatFile att = new ConcatFile();

                source.Data = docIN_orig.binaryData;
                source.Name = "original." + typ;

                att.Data = docIN_form.binaryData;
                att.Name = "sablona.rtf";

                pole.Add(source);
                pole.Add(att);

                    
                ConvertOptions.PdfFormat = PdfFormat.PDF;

                //ConvertOptions.


                service.Url = WS602Info.URL;

                try
                {
                    vysledek = service.Concat(pole.ToArray(), conOptions, ConvertOptions, out output, out report);
                }
                catch (Exception ddd)
                {
                    StatusText = ddd.Message;
                    StatusKod = "4555";
                    return outAsembler;
                }
            }

            error = "";           
            
            OperationContext context = OperationContext.Current;

            if (context != null && context.RequestContext != null)
            {

                //Message msg = context.RequestContext.RequestMessage;

                //string reqXML = msg.ToString();

            }

            if (vysledek == 0)
            {
                List<mapItem> itmMap = new List<mapItem>();
                mapItem itmmm = new mapItem();

                BLOB ret = new BLOB();
                ret.contentType = "application/pdf";
                ret.binaryData = output;

                List<mapItem> atributes = new List<mapItem>();
                
                mapItem attmmm = new mapItem();
                attmmm.key = (string)"basename";
                attmmm.value = (string)"DocumentOUT.pdf";
                atributes.Add(attmmm);

                attmmm.key = (string)"basename";
                attmmm.value = (string)"DocumentOUT.pdf";
                atributes.Add(attmmm);

                attmmm.key = (string)"file";
                attmmm.value = (string)"DocumentOUT.pdf";
                atributes.Add(attmmm);

                attmmm.key = (string)"wsfilename";
                attmmm.value = (string)"DocumentOUT.pdf";
                atributes.Add(attmmm);

                attmmm.key = (string)"ADOBE_SAVE_MODE_ATTRIBUTE";
                attmmm.value = (string)"INCREMENTAL";
                atributes.Add(attmmm);


                ret.attributes = atributes.ToArray();


                itmmm.key = (string)"DocumentOUT";
                itmmm.value = (BLOB)ret;
                //itmmm.
                itmMap.Add(itmmm);
                outAsembler.documents = itmMap.ToArray();
            }
            else
            {                
                StatusText = report;
                StatusKod = "5555";
                return outAsembler;
            }

            return outAsembler;
        }
        
        [WebMethod]
        public BLOB etr_forms(bool Archive, string Author, string Creator, bool Nahled, string Producer, string Subject, string Title, string Type, BLOB docIN, out string error, out string stavOUT)
        {
            BLOB outBlob = new BLOB();

            if (logovani)
            {
                XmlDocument xmlSoapRequest = new XmlDocument();

                // Get raw request body
                using (Stream receiveStream = HttpContext.Current.Request.InputStream)
                {
                    receiveStream.Position = 0;
                    using (StreamReader readStream =
                                           new StreamReader(receiveStream, System.Text.Encoding.UTF8))
                    {
                        xmlSoapRequest.Load(readStream);
                    }

                    xmlSoapRequest.Save(@"C:\Sluzby\602\etr_forms_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xml");
                }
            }

            try
            {
                WS602Info = Database.getWS602Info();
            }
            catch (Exception ddd)
            {
                stavOUT = "FALSE";
                error = ddd.Message;

                return outBlob;
            }

            if (WS602Info.URL == "")
            {
                stavOUT = "FALSE";
                error = "Není vyplněna URL adresa pro webovou službu Software602 LTD!";
                return outBlob;
            }

            if (WS602Info.Certifikat == "")
            {
                //stavOUT = "FALSE";
                //error = "Není cesta k podepisujícímu systémovému certifikátu (značce / pečeti)!";
                //return outBlob;
            }
                                  

            stavOUT = "";
            error = "";

            ConvertOptions ConvertOptions = new ConvertOptions();

            if (Archive)
            {
                ConvertOptions.PdfFormat = PdfFormat.PDF_A_2b;
                //ConvertOptions.PdfFormat = PdfFormat.PDF;
                //podepíšu:
                
                ConvertOptions.AddSignature = true;
                ConvertOptions.Signature = new PdfSignature();

                /*if (Database.getSetting("aplikace_provozovatel") == "VS")
                {
                    ConvertOptions.Signature.CertificateID = WS602Info.Certifikat;
                }
                else
                {
                    ConvertOptions.Signature.CertificateID = "PEMfile:" + WS602Info.Certifikat;
                }*/

                ConvertOptions.Signature.CertificateID = WS602Info.Certifikat;

                ConvertOptions.Signature.AddTimeStamp = true;
            }
            else 
            {
                ConvertOptions.PdfFormat = PdfFormat.PDF;
            }

            service.Url = WS602Info.URL;

            try
            {
                vysledek = service.ConvertFileEx(docIN.binaryData, "test." + Type, ConvertOptions, "", out output, out report, out error);
            }
            catch (Exception ddd)
            {
                error = ddd.Message;
            }

            if (vysledek == 0)
            {
                outBlob.binaryData = output;
                outBlob.contentType = "application/pdf";
            }
            else
            {
                error = report;
            }

            return outBlob;
        }

        /// <summary>
        /// Webová metoda pro získání informací o webové službě (+ spojení na DB a verzi IS ETŘ)
        /// </summary>
        [WebMethod]
        public ResultWSInfo WSInfo()
        {
            ResultWSInfo Resinfo = new ResultWSInfo();

            WSInfo info = new WSInfo();
            ResultStatus Xstatus = new ResultStatus("0000", "");

            string host = Dns.GetHostName();

            //USER:
            info.WS_user = System.Web.HttpContext.Current.User.Identity.Name;

            try
            {
                IPHostEntry ip = Dns.GetHostEntry(host);
                info.IP_adresa = ip.AddressList[1].ToString();
            }
            catch (Exception vs)
            {
                info.IP_adresa = "Chyba IPHostEntry, info: Status -> Status_text";

                Xstatus.Status_kod = "0110";
                Xstatus.Status_text = vs.Message;

                Resinfo.Status = Xstatus;
                return Resinfo;
            }

            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                info.WS_verze = assembly.GetName().Version.ToString();
            }
            catch (Exception ccc)
            {
                info.WS_verze = "Chyba Assembly, info:  Status -> Status_text";

                Xstatus.Status_kod = "0120";
                Xstatus.Status_text = ccc.Message;

                Resinfo.Status = Xstatus;
                return Resinfo;
            }

            try
            {
                info.DB_data = Database.test_db(Database.cnData);
            }
            catch (Exception aaa)
            {
                info.DB_data = "Chyba DB data, info: Status -> Status_text";

                Xstatus.Status_kod = "0130";
                Xstatus.Status_text = aaa.Message;

                Resinfo.Status = Xstatus;
                return Resinfo;
            }

            try
            {
                info.DB_soubory = Database.test_db(Database.cnSoubory);
            }
            catch (Exception aaa)
            {
                info.DB_soubory = "Chyba DB soubory, info: Status -> Status_text";

                Xstatus.Status_kod = "0140";
                Xstatus.Status_text = aaa.Message;

                Resinfo.Status = Xstatus;
                return Resinfo;
            }

            try
            {
                info.ETR_Provoz = Database.getSetting("ProvozETR");
            }
            
            catch (Exception aaa)
            {
                info.ETR_Provoz = "Chyba Provoz ETŘ, info: Status -> Status_text";

                Xstatus.Status_kod = "0150";
                Xstatus.Status_text = aaa.Message;

                Resinfo.Status = Xstatus;
                return Resinfo;
            }

            try
            {
                info.URL_602_LTD = Database.getSetting("WS_602LTD");
            }
            catch (Exception aaa)
            {
                info.ETR_Provoz = "Chyba WS 602LTD, info: Status -> Status_text";

                Xstatus.Status_kod = "0150";
                Xstatus.Status_text = aaa.Message;

                Resinfo.Status = Xstatus;
                return Resinfo;
            }

            Resinfo.Status = Xstatus;
            Resinfo.Info = info;

            return Resinfo;
        }
    }
}