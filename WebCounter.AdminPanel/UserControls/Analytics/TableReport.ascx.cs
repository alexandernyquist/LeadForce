﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using Telerik.Web.UI;
using WebCounter.BusinessLogicLayer;
using WebCounter.DataAccessLayer;

namespace WebCounter.AdminPanel.UserControls.Analytics
{
    public partial class TableReport : System.Web.UI.UserControl
    {
        protected DataManager dataManager = new DataManager();
        protected List<tbl_AnalyticAxis> AnalyticAxis = new List<tbl_AnalyticAxis>();
        protected tbl_AnalyticReport AnalyticReport = null;

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public Guid? AnalyticReportId
        {
            get { return (Guid?)ViewState["AnalyticReportId"]; }
            set { ViewState["AnalyticReportId"] = value; }
        }


        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public DataTable Data
        {
            get
            {                
                return (DataTable)ViewState["Data"];
            }
            set { ViewState["Data"] = value; }
        }



        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {                        
            AnalyticAxis = dataManager.AnalyticAxis.SelectAll().ToList();            

            rgData.Culture = new CultureInfo("ru-RU");

            if (!Page.IsPostBack)                            
                BindData();            
        }



        /// <summary>
        /// Binds the data.
        /// </summary>
        public void BindData()
        {
            rgData.DataSource = Data; 
            rgData.DataBind();
        }



        /// <summary>
        /// Handles the OnColumnCreated event of the rgData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.GridColumnCreatedEventArgs"/> instance containing the event data.</param>
        protected void rgData_OnColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            if (e.Column.UniqueName == "ExpandColumn")
                return;

            e.Column.Visible = true;

            if (AnalyticReportId.HasValue)
                AnalyticReport = dataManager.AnalyticReport.SelectById(CurrentUser.Instance.SiteID, (Guid)AnalyticReportId);

            if (AnalyticReport == null)
                return;

            if (AnalyticReport.tbl_AnalyticReportSystem.Any(o => o.tbl_AnalyticAxis.SystemName == e.Column.UniqueName))
            {
                var axis = AnalyticAxis.FirstOrDefault(o => o.SystemName == e.Column.UniqueName);
                if (axis != null)
                {
                    e.Column.HeaderText = axis.Title;
                    //e.Column.f.DataFormatString = "{0:MM/dd/yy}";
                }
            }
            else
            {
                e.Column.Visible = false;
            }
        }



        /// <summary>
        /// Handles the OnPageIndexChanged event of the rgData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.GridPageChangedEventArgs"/> instance containing the event data.</param>
        protected void rgData_OnPageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            BindData();
        }



        /// <summary>
        /// Handles the OnPageSizeChanged event of the rgData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.GridPageSizeChangedEventArgs"/> instance containing the event data.</param>
        protected void rgData_OnPageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            BindData();
        }



        /// <summary>
        /// Handles the OnItemDataBound event of the rgData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.GridItemEventArgs"/> instance containing the event data.</param>
        protected void rgData_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {                
                var header = (GridHeaderItem)e.Item;

                foreach (GridColumn column in rgData.MasterTableView.AutoGeneratedColumns)
                {
                    if (column.UniqueName == "ExpandColumn")
                        return;

                    column.Visible = true;

                    if (AnalyticReportId.HasValue)
                        AnalyticReport = dataManager.AnalyticReport.SelectById(CurrentUser.Instance.SiteID, (Guid)AnalyticReportId);

                    if (AnalyticReport == null)
                        return;

                    if (AnalyticReport.tbl_AnalyticReportSystem.Any(o => o.tbl_AnalyticAxis.SystemName == column.UniqueName))
                    {
                        var axis = AnalyticAxis.FirstOrDefault(o => o.SystemName == column.UniqueName);
                        if (axis != null)
                        {
                            
                            column.HeaderText = axis.Title;
                            header[column.UniqueName].Text = axis.Title;                            
                        }
                    }
                    else
                        column.Visible = false;                    
                }
            }
            else if (e.Item is GridDataItem && e.Item.OwnerTableView.GetColumnSafe("Period") != null)
            {                                
                if (e.Item.DataItem is DataRowView && ((DataRowView)e.Item.DataItem).Row["Period"] is DateTime)
                {
                    ((GridDataItem)e.Item)["Period"].Text = ((DateTime) ((DataRowView) e.Item.DataItem).Row["Period"]).ToString("dd.MM.yyyy");
                }
            }
        }
    }
}