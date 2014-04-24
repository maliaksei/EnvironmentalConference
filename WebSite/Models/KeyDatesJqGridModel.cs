using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Trirand.Web.Mvc;

namespace WebSite.Models
{
    public class KeyDatesJqGridModel
    {
        public KeyDatesJqGridModel()
        {
            OrdersGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                                 {
                                     new JQGridColumn { DataField = "DateId", 
                                                        // always set PrimaryKey for Add,Edit,Delete operations
                                                        // if not set, the first column will be assumed as primary key
                                                        PrimaryKey = true,
                                                        Editable = false,
                                                        Width = 50 },
                                     new JQGridColumn { DataField = "StartDate", 
                                                        Editable = true,
                                                        Width = 100, 
                                                        DataFormatString = "{0:d}" },
                                     new JQGridColumn { DataField = "Description", 
                                                        Editable = true,
                                                        Width = 100 }                
                                 },
                Width = Unit.Pixel(640)
            };

            OrdersGrid.ToolBarSettings.ShowRefreshButton = true;
        }

        public JQGrid OrdersGrid { get; set; }
    }
}