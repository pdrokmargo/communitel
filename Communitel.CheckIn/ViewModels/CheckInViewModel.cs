using Communitel.Common.Messages;
using Communitel.Common.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communitel.CheckIn.Models;
using Communitel.Common.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using Newtonsoft.Json;
using Communitel.Common.Helpers;
using System.Net.Http;
using Communitel.Common.Enums;
using System.IO;

//using Windows.Media.Capture;
//using Windows.Storage;

namespace Communitel.CheckIn.ViewModels
{
    [Export(typeof(CheckInViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class CheckInViewModel : BaseModel
    {

        public DelegateCommand<string> NextOrPreviousCommand { get; set; }
        public DelegateCommand OpenAddPersonCommand { get; set; }
        public DelegateCommand OpenAddDocumentCommand { get; set; }
        public DelegateCommand OpenAddBagCommand { get; set; }
        public DelegateCommand LoadCameraCaptureCommand { get; set; }
        public DelegateCommand<string> OpenCameraCaptureCommand { get; set; }
        public DelegateCommand CloseCameraCommand { get; set; }
        //public DelegateCommand CloseCameraDocumentCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand LoadCheckInCommand { get; set; }
        public DelegateCommand NewOrderCommand { get; set; }
        public DelegateCommand<string> AddCommand { get; set; }
        public DelegateCommand OpenBrowserCommand { get; set; }
        public DelegateCommand<object> RemoveDocumentCommand { get; set; }
        public DelegateCommand<object> SelectPriceCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }
        [ImportingConstructor]
        public CheckInViewModel()
        {
            NextOrPreviousCommand = new DelegateCommand<string>(NextOrPreviousExecute);
            OpenAddPersonCommand = new DelegateCommand(OpenAddPersonExecute);
            OpenAddDocumentCommand = new DelegateCommand(OpenAddDocumentExecute);
            OpenAddBagCommand = new DelegateCommand(OpenAddBagExecute);
            LoadCameraCaptureCommand = new DelegateCommand(LoadCameraCaptureExecure);
            OpenCameraCaptureCommand = new DelegateCommand<string>(OpenCameraCaptureExecute);
            CloseCameraCommand = new DelegateCommand(CloseCameraExecute);
            //CloseCameraDocumentCommand = new DelegateCommand(CloseCameraDocumentExecute);
            SaveCommand = new DelegateCommand(SaveExecute);
            LoadCheckInCommand = new DelegateCommand(LoadCheckInExecute);
            NewOrderCommand = new DelegateCommand(NewOrderExecute);
            AddCommand = new DelegateCommand<string>(AddExecute);
            OpenBrowserCommand = new DelegateCommand(OpenBrowserExecute);
            RemoveDocumentCommand = new DelegateCommand<object>(RemoveDocumentExecute);
            SelectPriceCommand = new DelegateCommand<object>(SelectPriceExecute);
            CloseCommand = new DelegateCommand(CloseExecute);
            _checkin = new Models.CheckIn();


        }

        #region variables         
        private Attachment _attachment;

        /// <summary>
        /// List of media information device available.
        /// </summary>
        private IEnumerable<MediaInformation> _mediaDeviceList;
        private MediaInformation _selectedVideoDevice;
        /// <summary>
        /// Byte array of snapshot image.
        /// </summary>
        private Bitmap _snapshotBitmap;
        private Models.CheckIn _checkin;
        private List<DataLookup> _sexs;
        private List<DataLookup> _dodumentTypes;
        private bool _newOrder = false;
        private bool _noNewOrder = true;
        private string _option = string.Empty;
        private AutorizationPerson _autorizationPerson;
        private List<DataLookup> _lengthTypes;
        private OrderBagDetail _orderBagDetail;
        private List<DataLookup> _paymentTypes;
        #endregion

        #region properties

        public Models.Attachment Attachment { get { return _attachment; } set { _attachment = value; NotifyPropertyChanged("Attachment"); } }
        public Models.AutorizationPerson AutorizationPerson { get { return _autorizationPerson; } set { _autorizationPerson = value; NotifyPropertyChanged("AutorizationPerson"); } }
        public Models.OrderBagDetail OrderBagDetail { get { return _orderBagDetail; } set { _orderBagDetail = value; NotifyPropertyChanged("OrderBagDetail"); } }

        /// <summary>
        /// Gets or sets media device list.
        /// </summary>
        public IEnumerable<MediaInformation> MediaDeviceList { get { return this._mediaDeviceList; } set { this._mediaDeviceList = value; NotifyPropertyChanged("MediaDeviceList"); } }
        /// <summary>
        /// Gets or sets selected media video device.
        /// </summary>
        public MediaInformation SelectedVideoDevice { get { return this._selectedVideoDevice; } set { this._selectedVideoDevice = value; NotifyPropertyChanged("SelectedVideoDevice"); } }
        /// <summary>
        /// Gets or sets snapshot bitmap.
        /// </summary>
        public Bitmap SnapshotBitmap { get { return this._snapshotBitmap; } set { this._snapshotBitmap = value; NotifyPropertyChanged("SnapshotBitmap"); } }
        public Models.CheckIn CheckIn { get { return _checkin; } set { _checkin = value; NotifyPropertyChanged("CheckIn"); } }
        public List<DataLookup> Sexs { get { return _sexs; } set { _sexs = value; NotifyPropertyChanged("Sexs"); } }
        public List<DataLookup> DodumentTypes { get { return _dodumentTypes; } set { _dodumentTypes = value; NotifyPropertyChanged("DodumentTypes"); } }
        public List<DataLookup> LengthTypes { get { return _lengthTypes; } set { _lengthTypes = value; NotifyPropertyChanged("LengthTypes"); } }
        public List<DataLookup> PaymentTypes { get { return _paymentTypes; } set { _paymentTypes = value; NotifyPropertyChanged("PaymentTypes"); } }
        public bool NewOrder { get { return _newOrder; } set { _newOrder = value; NotifyPropertyChanged("NewOrder"); } }
        public bool NoNewOrder { get { return _noNewOrder; } set { _noNewOrder = value; NotifyPropertyChanged("NoNewOrder"); } }
        #endregion

        private void LoadCameraCaptureExecure()
        {
            var filterVideoDeviceCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            this.MediaDeviceList = (from FilterInfo filterInfo in filterVideoDeviceCollection select new MediaInformation { DisplayName = filterInfo.Name, UsbId = filterInfo.MonikerString }).ToList();
            this.SelectedVideoDevice = this.MediaDeviceList != null ? this.MediaDeviceList.First() : null;
        }

        private async void LoadCheckInExecute()
        {
            try
            {
                ServiceRequest s = new ServiceRequest();
                var result = await s.GET<Result<List<DataLookup>>>($"/api/data_lookups?lookup_id=2");
                Sexs = result.data;

                var result2 = await s.GET<Result<List<DataLookup>>>($"/api/data_lookups?lookup_id=3");
                DodumentTypes = result2.data;

                var result3 = await s.GET<Result<List<DataLookup>>>($"/api/data_lookups?lookup_id=4");
                LengthTypes = result3.data;

                var result4 = await s.GET<Result<List<DataLookup>>>($"/api/data_lookups?lookup_id=5");
                PaymentTypes = result4.data;

            }
            catch (Exception ex)
            {

            }
        }

        private void NextOrPreviousExecute(string view)
        {
            try
            {
                if (view == "CustomerPhotoView")
                {
                    if (string.IsNullOrEmpty(this.CheckIn.customer.id_number))
                    {
                        MessageBox.Show("Enter the id number", MessageBoxIconV.Warning);
                        return;
                    }
                    if (string.IsNullOrEmpty(this.CheckIn.customer.firstname))
                    {
                        MessageBox.Show("Enter the given name", MessageBoxIconV.Warning);
                        return;
                    }
                    if (string.IsNullOrEmpty(this.CheckIn.customer.lastname))
                    {
                        MessageBox.Show("Enter the surname", MessageBoxIconV.Warning);
                        return;
                    }
                }
                if (view == "CompleteCheckInView")
                {
                    if (CheckIn.order_detail.Count == 0)
                    {
                        MessageBox.Show("Please add detail", MessageBoxIconV.Warning);
                        return;
                    }
                    this.CheckIn.total = this.CheckIn.total;
                    this.CheckIn.quantity = this.CheckIn.quantity;
                    this.CheckIn.subtotal = this.CheckIn.subtotal;
                }
                RegionManager.RequestNavigate(RegionNames.ContentStep, $"/{view}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void OpenAddPersonExecute()
        {
            try
            {
                this.AutorizationPerson = new AutorizationPerson();
                OpenPopupModal("Add person");
                RegionManager.RequestNavigate(RegionNames.ContentModalRegion, "/AddPersonsView");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void OpenAddDocumentExecute()
        {
            try
            {
                Attachment = new Attachment();
                OpenPopupModal("Add Document");
                RegionManager.RequestNavigate(RegionNames.ContentModalRegion, "/AddDocumentView");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void OpenAddBagExecute()
        {
            try
            {
                OrderBagDetail = new OrderBagDetail();
                OpenPopupModal("Add Bag");
                RegionManager.RequestNavigate(RegionNames.ContentModalRegion, "/AddBagView");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void OpenCameraCaptureExecute(string option)
        {
            try
            {
                _option = option;
                OpenPopupModal2("Camera");
                RegionManager.RequestNavigate(RegionNames.ContentModal2Region, "/CameraCaptureView");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void OpenCameraCaptureDocumentExecute()
        {
            try
            {
                OpenPopupModal("Camera");
                RegionManager.RequestNavigate(RegionNames.ContentModalRegion, "/CameraCaptureDocumentView");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void CloseCameraExecute()
        {
            try
            {
                if (_option == "profilephoto")
                {
                    CheckIn.attachments[0].url_media = SnapshotBitmap;
                }
                else if (_option == "boardingpass")
                {
                    CheckIn.attachments[1].url_media = SnapshotBitmap;
                }
                else if (_option == "documents")
                {
                    Attachment.url_media = SnapshotBitmap;
                }
                ClosePopupModal2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void CloseCameraDocumentExecute()
        {
            try
            {
                CheckIn.attachments[1].url_media = SnapshotBitmap;
                ClosePopupModal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private async void NewOrderExecute()
        {
            try
            {
                ServiceRequest s = new ServiceRequest();
                OpenIndicator();
                var result = await s.GET<Result<int>>("/api/consecutive_order");
                CheckIn.order_bag.order_number = result.data.ToString();
                NewOrder = true;
                NoNewOrder = false;
                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private async void SaveExecute()
        {
            try
            {
                if (string.IsNullOrEmpty(this.CheckIn.payment.payment_method_id.ToString()))
                {
                    MessageBox.Show("Select the payment type", MessageBoxIconV.Warning);
                    return;
                }

                ServiceRequest s = new ServiceRequest();
                OpenIndicator();

                System.Net.Http.MultipartFormDataContent formData = new System.Net.Http.MultipartFormDataContent();

                formData.Add(new StringContent(CheckIn.customer.id.ToString()), "customer.id");
                formData.Add(new StringContent(CheckIn.customer.firstname), "customer_firstname");
                formData.Add(new StringContent(CheckIn.customer.lastname), "customer_lastname");
                formData.Add(new StringContent(CheckIn.customer.nationality), "customer_nationality");
                formData.Add(new StringContent(CheckIn.customer.id_number), "customer_id_number");
                formData.Add(new StringContent(CheckIn.customer.sex.ToString()), "customer_sex");
                formData.Add(new StringContent(CheckIn.customer.date_birth.ToString("yyyy-MM-dd")), "customer_date_birth");

                formData.Add(new StringContent(CheckIn.order_bag.order_number ?? ""), "order_bag_order_number");
                formData.Add(new StringContent(CheckIn.order_bag.balance.ToString()), "order_bag_balance");
                formData.Add(new StringContent(CheckIn.order_bag.tax.ToString()), "order_bag_tax");
                formData.Add(new StringContent(CheckIn.order_bag.discount.ToString()), "order_bag_discount");

                string authorized_persons = JsonConvert.SerializeObject(this.CheckIn.autorization_persons);
                string bags_details = JsonConvert.SerializeObject(this.CheckIn.order_detail);

                formData.Add(new StringContent(authorized_persons), "authorized_persons");
                formData.Add(new StringContent(bags_details), "bags_details");

                formData.Add(new StringContent(CheckIn.payment.payment_method_id.ToString()), "payment_payment_method_id");
                formData.Add(new StringContent(CheckIn.payment.value.ToString()), "payment_value");

                var files = new List<string>();
                foreach (var item in this.CheckIn.attachments)
                {
                    if (item.url_media != null)
                    {
                        var path = $@"{Path.GetTempPath()}{Guid.NewGuid()}.png";
                        item.url_media.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                        string fileName = Guid.NewGuid().ToString();
                        FileStream stream = new FileStream(path, FileMode.Open);
                        files.Add(path);
                        //formData.Add(new StreamContent(memoryStream), "attachments[]", $"{fileName}.png");
                        formData.Add(Common.Functions.Functions.CreateFileContent(stream, $"{fileName}.png", "attachments[]", "image/jpeg"));
                        formData.Add(new StringContent(item.attachtype_id.ToString()), "attachtype_ids[]");
                    }
                }

                dynamic obj = await s.POST("/api/checkin", formData);

                if (files.Count > 0)
                    foreach (var path in files)
                        if (File.Exists(path))
                            File.Delete(path);

                if (obj != null && Common.Functions.Functions.IsPropertyExist(obj, "data"))
                {
                    NewOrder = false;
                    NoNewOrder = true;
                    MessageBox.Show($"The order was generated with the number:{CheckIn.order_bag.order_number}");
                    CheckIn = new Models.CheckIn();
                    RegionManager.RequestNavigate(RegionNames.ContentStep, "/CustomerView");
                }

                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void AddExecute(string option)
        {
            try
            {

                if (option == "attachment")
                {
                    if (this.Attachment.url_media == null)
                    {
                        MessageBox.Show("Select the image", MessageBoxIconV.Warning);
                        return;
                    }
                    if (this.Attachment.attachtype_id == 0 || this.Attachment.attachtype_id == null)
                    {
                        MessageBox.Show("Select the attachment type", MessageBoxIconV.Warning);
                        return;
                    }
                    this.CheckIn.attachments.Add(Attachment);
                    Attachment = new Attachment();
                }
                else if (option == "autorize_person")
                {
                    if (string.IsNullOrEmpty(this.AutorizationPerson.customer.firstname))
                    {
                        MessageBox.Show("Enter the given name", MessageBoxIconV.Warning);
                        return;
                    }
                    if (string.IsNullOrEmpty(this.AutorizationPerson.customer.lastname))
                    {
                        MessageBox.Show("Enter the surname", MessageBoxIconV.Warning);
                        return;
                    }

                    this.CheckIn.autorization_persons.Add(this.AutorizationPerson);
                    this.AutorizationPerson = new AutorizationPerson();

                }
                else if (option == "bag")
                {
                    if (string.IsNullOrEmpty(OrderBagDetail.length_type.ToString()))
                    {
                        MessageBox.Show("Select the length type", MessageBoxIconV.Warning);
                        return;
                    }
                    if (string.IsNullOrEmpty(OrderBagDetail.weight.ToString()))
                    {
                        MessageBox.Show("Enter the weight", MessageBoxIconV.Warning);
                        return;
                    }
                    if (string.IsNullOrEmpty(OrderBagDetail.location_label))
                    {
                        MessageBox.Show("Enter the location", MessageBoxIconV.Warning);
                        return;
                    }
                    if (string.IsNullOrEmpty(OrderBagDetail.price.ToString()))
                    {
                        MessageBox.Show("Enter the price", MessageBoxIconV.Warning);
                        return;
                    }

                    this.CheckIn.order_detail.Add(this.OrderBagDetail);
                }
                ClosePopupModal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void RemoveDocumentExecute(object obj)
        {
            try
            {
                if (MessageBox.Show("Do you want to remove the selected record?", "Confimr", MessageBoxButtonsV.YesNo, MessageBoxIconV.Question, MessageBoxDefaultButtonV.Button1) == DialogResultV.Yes)
                    this.CheckIn.attachments.Remove((Models.Attachment)obj);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void OpenBrowserExecute()
        {
            try
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();

                ofd.Title = "Search image";
                ofd.FileName = "Images";
                ofd.Filter = "Images files|*.png;*.jpg;*jpeg";
                ofd.DefaultExt = ".png";
                var result = ofd.ShowDialog();

                if (result.Value)
                {
                    this.Attachment.url_media = new Bitmap(ofd.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private async void SelectPriceExecute(object value)
        {
            try
            {
                OpenIndicator();
                ServiceRequest s = new ServiceRequest();
                var Configuration = await s.GET<Common.Models.Configuration>("/api/config");

                switch ((int)value)
                {
                    case (int)Common.Enums.enDataLookUp.red:
                        this.OrderBagDetail.price = Configuration.red_price;
                        break;
                    case (int)Common.Enums.enDataLookUp.yellow:
                        this.OrderBagDetail.price = Configuration.yellow_price;
                        break;
                    case (int)Common.Enums.enDataLookUp.orange:
                        this.OrderBagDetail.price = Configuration.orange_price;
                        break;
                    case (int)Common.Enums.enDataLookUp.overorange:
                        this.OrderBagDetail.price = Configuration.overorange_price;
                        break;
                    default:
                        break;
                }

                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
            }
        }

        private void CloseExecute()
        {
            RegionManager.RequestNavigate(RegionNames.ContentStep, "/HomeView}");
        }

        /// <summary>
        /// https://msdn.microsoft.com/en-us/windows/uwp/audio-video-camera/capture-photos-and-video-with-cameracaptureui
        /// https://blog.jsinh.in/preview-webcam-video-and-take-snapshot-in-wpf-using-aforge-and-mvvm/#.WHZoyBt97IU
        /// </summary>


    }
}
