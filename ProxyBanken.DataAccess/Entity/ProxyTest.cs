﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProxyBanken.DataAccess.Entity
{
    public class ProxyTest : BaseEntity
    {
        [Display(Name = "Last Successful Test Date")]
        public virtual DateTime? LastSuccessDate { get; set; }
        public int ProxyTestUrlId { get; set; }
        public int ProxyId { get; set; }

        [ForeignKey("ProxyId")]
        public virtual Proxy Proxy { get; set; }

        [ForeignKey("ProxyTestUrlId")]
        public virtual ProxyTestUrl ProxyTestUrl { get; set; }

    }
}
