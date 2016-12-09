﻿using Communitel.Common.Functions;
using Communitel.Common.Helpers;
using Communitel.Common.Messages;
using Communitel.Common.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Communitel.Product.ViewModels
{
    [Export(typeof(ProductViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ProductViewModel : BaseModel
    {
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand GetAllCommand { get; set; }
        public DelegateCommand OpenCreateCommand { get; set; }
        public DelegateCommand<string> NextPageCommand { get; set; }
        public DelegateCommand<dynamic> OpenEditCommand { get; set; }
        public DelegateCommand OpenSearchProductCommand { get; set; }
        [ImportingConstructor]
        public ProductViewModel()
        {
            SaveCommand = new DelegateCommand(SaveExecute);
            GetAllCommand = new DelegateCommand(GetAllExecute);
            OpenCreateCommand = new DelegateCommand(OpenCreateExecute);
            NextPageCommand = new DelegateCommand<string>(NextPageExecute);
            OpenEditCommand = new DelegateCommand<dynamic>(OpenEditExecute);
            OpenSearchProductCommand = new DelegateCommand(OpenSearchProductExecute);
            Product = new System.Dynamic.ExpandoObject();
            this.Product.id = 0;
        }

        #region variables
        private dynamic _product;
        private dynamic _products;
        private string _search = string.Empty;
        private int _page = 1;
        private string _sortBy = "id";
        private int _reverse = 0;
        #endregion

        #region property
        public dynamic Product { get { return _product; } set { _product = value; NotifyPropertyChanged("Product"); } }
        public dynamic Products { get { return _products; } set { _products = value; NotifyPropertyChanged("Products"); } }
        public string Search { get { return _search; } set { _search = value; NotifyPropertyChanged("Search"); } }
        public int Page { get { return _page; } set { _page = value; NotifyPropertyChanged("Page"); } }
        public string SortBy { get { return _sortBy; } set { _sortBy = value; NotifyPropertyChanged("SortBy"); } }
        public int Reverse { get { return _reverse; } set { _reverse = value; NotifyPropertyChanged("Reverse"); } }
        public List<Models.Status> Status
        {
            get
            {
                List<Models.Status> status = new List<Models.Status>();
                status.Add(new Models.Status { id = 0, name = "Off" });
                status.Add(new Models.Status { id = 1, name = "On" });
                return status;
            }
        }
        #endregion

        private async void SaveExecute()
        {
            try
            {
                ServiceRequest s = new ServiceRequest();
                OpenIndicator();
                string json = JsonConvert.SerializeObject(Product);

                if (Functions.IsPropertyExist(this.Product, "id") && this.Product.id > 0)
                {
                    dynamic obj = await s.PUT("/api/products/" + Product.id, json);
                    CloseIndicator();
                    Product = new System.Dynamic.ExpandoObject();
                    MessageBox.Show("The product has been updated!", "Products");
                }
                else
                {
                    dynamic obj = await s.POST("/api/products", json);
                    CloseIndicator();
                    Product = new System.Dynamic.ExpandoObject();
                    MessageBox.Show("A new product has been created!", "Products");
                }
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private async Task Get(string search, string sortBy = "id", int reverse = 0)
        {
            try
            {
                ServiceRequest s = new ServiceRequest();
                Dictionary<string, object> headers = new Dictionary<string, object>();
                headers.Add("pageSize", 2);
                headers.Add("sortBy", sortBy);
                headers.Add("reverse", reverse);
                var result = await s.GET($"/api/products?page={Page}&search={Search}", headers);
                this.Products = result.products;
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private async void GetAllExecute()
        {
            try
            {
                OpenIndicator();
                await Get(this.Search, this.SortBy, this.Reverse);
                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void OpenCreateExecute()
        {
            try
            {
                this.Product = new System.Dynamic.ExpandoObject();
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/ProductView");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private async void NextPageExecute(string option)
        {
            try
            {
                OpenIndicator();

                if (option == "next")
                {
                    if (Page < int.Parse(this.Products.last_page.ToString()))
                        Page++;
                }
                else
                {
                    if (Page > 1)
                        Page--;
                }

                await Get(this.Search, this.SortBy, this.Reverse);
                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private async void OpenEditExecute(dynamic product)
        {
            try
            {
                ServiceRequest s = new ServiceRequest();
                var result = await s.GET($"/api/products/{product.id}");
                this.Product = result.Product;
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/ProductView");
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void OpenSearchProductExecute()
        {
            try
            {
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/SearchProductView");
            }
            catch (Exception ex)
            {

            }
        }

    }
}
