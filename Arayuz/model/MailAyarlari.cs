//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Arayuz.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MailAyarlari
    {
        public int Id { get; set; }
        public string GondericiBilgisi { get; set; }
        public string Smtp_server { get; set; }
        public string Smtp_port { get; set; }
        public string MailGonderici { get; set; }
        public string Eposta { get; set; }
        public string EpostaSifresi { get; set; }
    }
}