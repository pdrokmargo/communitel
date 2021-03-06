﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Communitel.helpers;
using Communitel.CustomControls;
using Newtonsoft.Json;

namespace Communitel.Views
{
    /// <summary>
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class Configuration : UserControl
    {
        public Dashboard DashboardContainer { get; set; }
        dynamic Config;
        public Configuration()
        {
            InitializeComponent();
            ServiceRequest svc = new ServiceRequest();
            Config = svc.GET("/api/config");
            grdConfiguration.DataContext = Config;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DashboardContainer.closeCurrent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequest svc = new ServiceRequest();
            //string parsedContent = "tax_percent=" + txtTax.Text + "&expiry_days=" + txtExpiryDays.Text + "&red_price=" + txtRedPrice.Text + "&yellow_price=" + txtYellowPrice.Text + "&green_price=" + txtGreenPrice.Text;
            string json = JsonConvert.SerializeObject(Config);
            svc.PUT("/api/config/change", json);
            DashboardContainer.popupMessage("Content Updated", "Configuration updated successfully!");
        }
    }
}
