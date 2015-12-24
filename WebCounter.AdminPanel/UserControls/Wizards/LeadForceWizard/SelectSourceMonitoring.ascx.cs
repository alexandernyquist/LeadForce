﻿using System;
using Telerik.Web.UI;
using WebCounter.AdminPanel.UserControls.Wizards.Controls;

namespace WebCounter.AdminPanel.UserControls.Wizards.LeadForceWizard
{
    public partial class SelectSourceMonitoring : LeadForceWizardStep
    {        
        /// <summary>
        /// Binds the data.
        /// </summary>
        public override void BindData()
        {
            base.BindData();

            BindSourceMonitorings(CurrentSiteTemplate);
        }



        /// <summary>
        /// Binds the source monitorings.
        /// </summary>
        /// <param name="siteId">The site id.</param>
        private void BindSourceMonitorings(Guid siteId)
        {            
            rlbSource.DataSource = DataManager.SourceMonitoring.SelectAll(siteId);
            rlbSource.DataValueField = "ID";
            rlbSource.DataTextField = "Name";
            rlbSource.DataBind();
        }



        /// <summary>
        /// Handles the OnSelectedIndexChanged event of the ucSiteTemplateComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
        protected void ucSiteTemplateComboBox_OnSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            BindSourceMonitorings((Guid)ucSiteTemplateComboBox.SelectedValue);
        }



        /// <summary>
        /// Handles the OnItemCreated event of the rlbDestination control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadListBoxItemEventArgs"/> instance containing the event data.</param>
        protected void rlbDestination_OnItemCreated(object sender, RadListBoxItemEventArgs e)
        {
            e.Item.Text = string.Format("Мониторинг '{0}' из шаблона '{1}'", e.Item.Text, ucSiteTemplateComboBox.SelectedText);
            e.Item.Attributes.Add("SiteId", ucSiteTemplateComboBox.SelectedValue.ToString());
        }



        /// <summary>
        /// Handles the OnTransferring event of the rlbSource control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Telerik.Web.UI.RadListBoxTransferringEventArgs"/> instance containing the event data.</param>
        protected void rlbSource_OnTransferring(object sender, RadListBoxTransferringEventArgs e)
        {
            if (e.DestinationListBox.FindItemByValue(e.Items[0].Value) != null)
                e.Cancel = true;
        }
    }
}