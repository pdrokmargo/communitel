﻿using Communitel.Common.Enums;
using Communitel.Common.Functions;
using Communitel.Common.Helpers;
using Communitel.Common.Messages;
using Communitel.Common.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communitel.Product.Models;
using Communitel.Common.Extensions;

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
        public DelegateCommand OpenMoreFiltersCommand { get; set; }
        public DelegateCommand<object> RemoveCategoryCommand { get; set; }
        public DelegateCommand GetCategoriesCommand { get; set; }
        public DelegateCommand OpenCategoriesCommand { get; set; }
        public DelegateCommand AddCategoriesCommand { get; set; }
        public DelegateCommand GetCategoriesFiltersCommand { get; set; }
        public DelegateCommand SearchByFiltersCommand { get; set; }
        public DelegateCommand OpenAddCategoryCommand { get; set; }
        public DelegateCommand AddCategoryCommand { get; set; }
        [ImportingConstructor]
        public ProductViewModel()
        {
            SaveCommand = new DelegateCommand(SaveExecute);
            GetAllCommand = new DelegateCommand(GetAllExecute);
            OpenCreateCommand = new DelegateCommand(OpenCreateExecute);
            NextPageCommand = new DelegateCommand<string>(NextPageExecute);
            OpenEditCommand = new DelegateCommand<dynamic>(OpenEditExecute);
            OpenSearchProductCommand = new DelegateCommand(OpenSearchProductExecute);
            OpenMoreFiltersCommand = new DelegateCommand(OpenMoreFiltersExecute);
            RemoveCategoryCommand = new DelegateCommand<object>(RemoveCategoryExecute);
            GetCategoriesCommand = new DelegateCommand(GetCategoriesExecute);
            OpenCategoriesCommand = new DelegateCommand(OpenCategoriesExecute);
            AddCategoriesCommand = new DelegateCommand(AddCategoriesExecute);
            GetCategoriesFiltersCommand = new DelegateCommand(GetCategoriesFiltersExecute);
            SearchByFiltersCommand = new DelegateCommand(SearchByFiltersExecute);
            OpenAddCategoryCommand = new DelegateCommand(OpenAddCategoryExecute);
            AddCategoryCommand = new DelegateCommand(AddCategoryExecute);
            Product = new System.Dynamic.ExpandoObject();
            this.Product.id = 0;
            _category = new Models.Categories();
        }

        #region variables
        private dynamic _product;
        private dynamic _products;
       
        private ObservableCollection<Categories> _categories;
        private ObservableCollection<Models.Categories> _categoriesFilters;
        private bool _filters = false;
        private int _statusFilter = 2;
        private Categories _category;
        #endregion

        #region property
        public dynamic Product { get { return _product; } set { _product = value; NotifyPropertyChanged("Product"); } }
        public dynamic Products { get { return _products; } set { _products = value; NotifyPropertyChanged("Products"); } }
      
        public ObservableCollection<Models.Categories> Categories { get { return _categories; } set { _categories = value; NotifyPropertyChanged("Categories"); } }
        public ObservableCollection<Models.Categories> CategoriesFilters { get { return _categoriesFilters; } set { _categoriesFilters = value; NotifyPropertyChanged("CategoriesFilters"); } }
        public int StatusFilter { get { return _statusFilter; } set { _statusFilter = value; NotifyPropertyChanged("StatusFilter"); } }
        public Models.Categories Category { get { return _category; } set { _category = value; NotifyPropertyChanged("Category"); } }
        public List<Models.Status> Status
        {
            get
            {
                List<Models.Status> status = new List<Models.Status>();
                status.Add(new Models.Status { id = 0, name = "Off" });
                status.Add(new Models.Status { id = 1, name = "On" });
                status.Add(new Models.Status { id = 2, name = "All" });
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
                    MessageBox.Show("The product has been updated!", "Products");
                    Product = new System.Dynamic.ExpandoObject();
                    this.OpenSearchProductExecute();
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
                headers.Add("pageSize", 4);
                headers.Add("sortBy", sortBy);
                headers.Add("reverse", reverse);
                dynamic result;
                if (_filters)
                {
                    string categories = string.Empty;
                    foreach (var item in CategoriesFilters)
                    {
                        if (item.add)
                            categories += $"{item.id},";
                    }
                    result = await s.GET($"/api/products?page={Page}&categories={categories}&status={StatusFilter}", headers);
                }
                else
                {
                    result = await s.GET($"/api/products?page={Page}&search={Search}", headers);
                }

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
            _filters = false;
            await GetAll();
        }

        public async Task GetAll()
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

        private void OpenMoreFiltersExecute()
        {
            try
            {
                OpenPopupModal("Filters");
                RegionManager.RequestNavigate(RegionNames.ContentModalRegion, "/FilterView");
            }
            catch (Exception ex)
            {

            }
        }

        private async void SearchByFiltersExecute()
        {
            try
            {
                _filters = true;
                await GetAll();
                ClosePopupModal();
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void RemoveCategoryExecute(object category)
        {
            try
            {
                var resultDialog = MessageBox.Show("Do you want to remove the category?", "Confirm", MessageBoxButtonsV.YesNo, MessageBoxIconV.Question, MessageBoxDefaultButtonV.Button1);

                if (resultDialog == DialogResultV.Yes)
                {
                    var list = (Newtonsoft.Json.Linq.JArray)this.Product.categories;
                    var item = (Newtonsoft.Json.Linq.JToken)category;
                    list.Remove(item);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void GetCategoriesExecute()
        {
            try
            {
                this.Categories = new ObservableCollection<Models.Categories>();
                OpenIndicator();
                ServiceRequest s = new ServiceRequest();
                Dictionary<string, object> headers = new Dictionary<string, object>();
                headers.Add("sortBy", "description");
                headers.Add("reverse", 0);
                var result = await s.GET<Common.Models.Result<ObservableCollection<Categories>>>("/api/categories", headers);

                if (!Functions.IsPropertyExist(this.Product, "categories"))
                    this.Product.categories = new Newtonsoft.Json.Linq.JArray();

                if (!(this.Product.categories is Newtonsoft.Json.Linq.JArray))
                    this.Product.categories = new Newtonsoft.Json.Linq.JArray();

                List<int> categoriesid = new List<int>();

                foreach (var item in this.Product.categories)
                {
                    var id = Convert.ToInt32(item["id"]);
                    categoriesid.Add(id);
                }


                this.Categories = result.data.Where(a => !categoriesid.Contains(a.id)).ToObservableCollection();

                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, MessageBoxIconV.Error);
            }
        }

        private void OpenCategoriesExecute()
        {
            try
            {
                OpenPopupModal("Categories");
                RegionManager.RequestNavigate(RegionNames.ContentModalRegion, "/CategoriesView");
            }
            catch (Exception ex)
            {

            }
        }

        private void AddCategoriesExecute()
        {
            try
            {
                foreach (var category in this.Categories)
                {
                    if (category.add)
                    {

                        if (!Functions.IsPropertyExist(this.Product, "categories"))
                            this.Product.categories = new Newtonsoft.Json.Linq.JArray();

                        if (!(this.Product.categories is Newtonsoft.Json.Linq.JArray))
                            this.Product.categories = new Newtonsoft.Json.Linq.JArray();

                        var categorias = (Newtonsoft.Json.Linq.JArray)this.Product.categories;
                        var json = Newtonsoft.Json.Linq.JToken.FromObject(category);
                        categorias.Add(json);
                        ClosePopupModal();


                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void GetCategoriesFiltersExecute()
        {
            try
            {
                OpenIndicator();
                ServiceRequest s = new ServiceRequest();
                Dictionary<string, object> headers = new Dictionary<string, object>();
                headers.Add("sortBy", "description");
                headers.Add("reverse", 0);
                var result = await s.GET<Common.Models.Result<ObservableCollection<Categories>>>("/api/categories", headers);

                this.CategoriesFilters = result.data;

                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, MessageBoxIconV.Error);
            }
        }

        private  void OpenAddCategoryExecute()
        {
            try
            {
                OpenPopupModal2("Add New Category");
                RegionManager.RequestNavigate(RegionNames.ContentModal2Region, "/AddCategoryView");
            }
            catch (Exception ex)
            {              
                MessageBox.Show(ex.Message, MessageBoxIconV.Error);
            }
        }

        private async void AddCategoryExecute()
        {
            try
            {
                OpenIndicator();
                ServiceRequest s = new ServiceRequest();
                string json = JsonConvert.SerializeObject(Category);
                await s.POST("/api/categories", json);
                MessageBox.Show("A new product has been created!", "Products");
                CloseIndicator();
                ClosePopupModal2();
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, MessageBoxIconV.Error);
            }
        }

    }
}
