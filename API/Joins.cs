﻿using System.Collections.Generic;

namespace ServiceProtocol
{
    //JOIN TABLE FOR SREVICELIST TO WORK WITH ENTITY FRAMEWORK CORE
    public partial class ServiceList { public ICollection<ServiceListService> ServiceListServices { get; set; } }
    public partial class Service { public ICollection<ServiceListService> ServiceListServices { get; set; } }
    public class ServiceListService
    {
        public int ServiceListId { get; set; }
        public ServiceList ServiceList { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////
    //  DON'T DO THIS!!!! DON'T BE LAZY!!!! NO NEED FOR PERSISTENCE, JUST MAKE THE HTML MANUALLY!!!
    //////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////
    ////JOIN TABLE FOR TRADEACTIONLIST TO WORK
    //////////////////////////////////////////////////////////////////////////////////////////////////
    //public partial class TradeAction { public List<TradeActionList_TradeAction> Joins { get; set; } }
    //public partial class TradeActionList { public List<TradeActionList_TradeAction> Joins { get; set; } }
    //public class TradeActionList_TradeAction
    //{
    //    public int TAL_Id { get; set; }
    //    public TradeActionList TradeActionList { get; set; }
    //    public int TA_Id { get; set; }
    //    public TradeAction TradeAction { get; set; }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////

}