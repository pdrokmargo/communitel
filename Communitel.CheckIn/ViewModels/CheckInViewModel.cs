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
        [ImportingConstructor]
        public CheckInViewModel()
        {
            NextOrPreviousCommand = new DelegateCommand<string>(NextOrPreviousExecute);
            OpenAddPersonCommand = new DelegateCommand(OpenAddPersonExecute);
            OpenAddDocumentCommand = new DelegateCommand(OpenAddDocumentExecute);
            OpenAddBagCommand = new DelegateCommand(OpenAddBagExecute);
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
        #endregion

        #region properties

        public Models.Document Docuemnt { get { return _document; } set { _document = value; NotifyPropertyChanged("Document"); } }
        public Models.Person Person { get { return _person; } set { _person = value; NotifyPropertyChanged("Person"); } }
        public Models.Bag Bag { get { return _bag; } set { _bag = value; NotifyPropertyChanged("Bag"); } }

        public ObservableCollection<Models.Document> Documents { get { return _documents; } set { _documents = value; NotifyPropertyChanged("Documents"); } }
        public ObservableCollection<Models.Person> Persons { get { return _persons; } set { _persons = value; NotifyPropertyChanged("Persons"); } }
        public ObservableCollection<Models.Bag> Bags { get { return _bags; } set { _bags = value; NotifyPropertyChanged("Bags"); } }
        #endregion

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

        /// <summary>
        /// https://msdn.microsoft.com/en-us/windows/uwp/audio-video-camera/capture-photos-and-video-with-cameracaptureui
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
