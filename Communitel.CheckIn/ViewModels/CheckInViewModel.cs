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
        public DelegateCommand OpenCameraCaptureCommand { get; set; }
        public DelegateCommand CloseCameraCommand { get; set; }
        [ImportingConstructor]
        public CheckInViewModel()
        {
            NextOrPreviousCommand = new DelegateCommand<string>(NextOrPreviousExecute);
            OpenAddPersonCommand = new DelegateCommand(OpenAddPersonExecute);
            OpenAddDocumentCommand = new DelegateCommand(OpenAddDocumentExecute);
            OpenAddBagCommand = new DelegateCommand(OpenAddBagExecute);
            LoadCameraCaptureCommand = new DelegateCommand(LoadCameraCaptureExecure);
            OpenCameraCaptureCommand = new DelegateCommand(OpenCameraCaptureExecute);
            CloseCameraCommand = new DelegateCommand(CloseCameraExecute);
            _documents = new ObservableCollection<Document>();
            _persons = new ObservableCollection<Person>();
            _bags = new ObservableCollection<Bag>();


            Documents.Add(new Document { DocumentType = "ID (Passport/DL)", Number = "123456" });
            Documents.Add(new Document { DocumentType = "Reservation/Boarding Pass", Number = "123456" });
            Documents.Add(new Document { DocumentType = "Reservation/Boarding Pass on phone", Number = "123456" });

            _persons.Add(new Person { GivenName = "Carlos", MiddleName = "Andres", SurName = "Visbal", SurName2 = "Rios" });
            _persons.Add(new Person { GivenName = "Julio", MiddleName = "", SurName = "Castro", SurName2 = "Rios" });
            _persons.Add(new Person { GivenName = "Andres", MiddleName = "Fernando", SurName = "Visbal", SurName2 = "Torres" });

            _bags.Add(new Bag { Length = "1", Weight = "50", Price = 20 });
            _bags.Add(new Bag { Length = "1", Weight = "20", Price = 15 });
            _bags.Add(new Bag { Length = "1", Weight = "15", Price = 15 });

            _document = new Document();
            _person = new Person();
            _bag = new Bag();
        }

        #region variables
        private ObservableCollection<Document> _documents;
        private ObservableCollection<Person> _persons;
        private ObservableCollection<Bag> _bags;
        private Document _document;
        private Person _person;
        private Bag _bag;
        /// <summary>
        /// List of media information device available.
        /// </summary>
        private IEnumerable<MediaInformation> _mediaDeviceList;
        private MediaInformation _selectedVideoDevice;
        /// <summary>
        /// Byte array of snapshot image.
        /// </summary>
        private Bitmap _snapshotBitmap;
        #endregion

        #region properties

        public Models.Document Docuemnt { get { return _document; } set { _document = value; NotifyPropertyChanged("Document"); } }
        public Models.Person Person { get { return _person; } set { _person = value; NotifyPropertyChanged("Person"); } }
        public Models.Bag Bag { get { return _bag; } set { _bag = value; NotifyPropertyChanged("Bag"); } }

        public ObservableCollection<Models.Document> Documents { get { return _documents; } set { _documents = value; NotifyPropertyChanged("Documents"); } }
        public ObservableCollection<Models.Person> Persons { get { return _persons; } set { _persons = value; NotifyPropertyChanged("Persons"); } }
        public ObservableCollection<Models.Bag> Bags { get { return _bags; } set { _bags = value; NotifyPropertyChanged("Bags"); } }
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
        #endregion

        private void LoadCameraCaptureExecure()
        {
            var filterVideoDeviceCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            this.MediaDeviceList = (from FilterInfo filterInfo in filterVideoDeviceCollection select new MediaInformation { DisplayName = filterInfo.Name, UsbId = filterInfo.MonikerString }).ToList();
            this.SelectedVideoDevice = this.MediaDeviceList != null ? this.MediaDeviceList.First() : null;
        }

        private void NextOrPreviousExecute(string view)
        {
            try
            {
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
                OpenPopupModal("Add Bag");
                RegionManager.RequestNavigate(RegionNames.ContentModalRegion, "/AddBagView");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void OpenCameraCaptureExecute()
        {
            try
            {
                OpenPopupModal("Camera");
                RegionManager.RequestNavigate(RegionNames.ContentModalRegion, "/CameraCaptureView");
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
                ClosePopupModal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        /// <summary>
        /// https://msdn.microsoft.com/en-us/windows/uwp/audio-video-camera/capture-photos-and-video-with-cameracaptureui
        /// https://blog.jsinh.in/preview-webcam-video-and-take-snapshot-in-wpf-using-aforge-and-mvvm/#.WHZoyBt97IU
        /// </summary>
        private async void StarCaptureExecute()
        {
            try
            {
                //var capture = new MediaCapture();
                //await capture.InitializeAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

    }
}
