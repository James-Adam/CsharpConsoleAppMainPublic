using Microsoft.QueryStringDotNET;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Text;
using System.Threading.Tasks;
using UWP.Data;
using UWP.View;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.DataTransfer;
using Windows.Devices.Enumeration;
using Windows.Devices.Geolocation;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Media.SpeechRecognition;
using Windows.Security.Credentials.UI;
using Windows.Security.Cryptography;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Panel = Windows.Devices.Enumeration.Panel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, ITextEditProvider, IBackgroundTask
    {
        //speech recognition for long input
        private readonly StringBuilder sb = new StringBuilder();

        public MainPage()
        {
            InitializeComponent();

            //page navigation
            //btnPage1.Click += btnPage1_Click;
            //btnPage1_1.Click += btnPage1_1_Click;

            //text1.TextChanged += ChangedText();

            //Binding Data items and collections to layout
            MyViewModel = new DataViewModel();

            //identifying input devices
            MouseCapabilities mouse = new MouseCapabilities();
            KeyboardCapabilities keyboard = new KeyboardCapabilities();
            TouchCapabilities touch = new TouchCapabilities();

            //<!--touch events-->
            //touchTest.PointerPressed += touchTest_PointerPressed;
            //touchTest.PointerReleased += touchTest_PointerReleased;
            //touchTest.PointerExited += touchTest_PointerExited;
            //touchTest.ManipulationCompleted += touchTest_ManipulationCompleted;

            //mouse events
            //touchTest.PointerMoved += touchTest_PointerMoved;

            //Keyboard events
            //TestTextBox.KeyDown += TestTextBox_KeyDown;
            //TestTextBox.KeyUp += TestTextBox_KeyUp;

            //using access keys
            //TestBar.AccessKeyInvoked += TestBar_AccesKeyInvoked;
            //TestBar.AccessKeyDisplayRequested += TestBar_AccessKeyDisplayRequested;

            //making UI Respond to a virtual keyboard
            InputPane myPane = InputPane.GetForCurrentView();
            myPane.Showing += ShowThis;

            myPane.Hiding += HideThis;

            //controlling touchscreen keyboard
            //InputScope myScope = new InputScope();
            //myScope.Names.Add(new InputScopeName
            //{
            //    NameValue = InputScopeNameValue.EmailNameOrAddress
            //});
            //address1.InputScope = myScope;

            ////using inking pens
            //myInk.InkPresenter.InputDeviceTypes |= Windows.UI.Core.CoreInputDeviceTypes.Mouse;

            //recognising pen and shapes from input-->
            //myInkInput.InkPresenter.InputDeviceTypes |= Windows.UI.Core.CoreInputDeviceTypes.Mouse;

            //storing ink strokes-->
            //myInkInput1.InkPresenter.InputDeviceTypes |= Windows.UI.Core.CoreInputDeviceTypes.Mouse;

            //using InkToolBar
            //myInkInput2.InkPresenter.InputDeviceTypes |= Windows.UI.Core.CoreInputDeviceTypes.Mouse;

            //<!--using the speech synthesizer-->
            //TTS();
        }

        //Binding Data items and collections to layout
        public DataViewModel MyViewModel { get; set; }

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // Method intentionally left empty.
        }

        //Command bar
        private void CommandBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (((AppBarButton)sender).Label == "Attach")
            {
                //do something
            }
        }

        //Page Navigation
        private void btnPage1_Click(object sender, RoutedEventArgs e)
        {
            _ = Frame.Navigate(typeof(Page1));
        }

        private void btnPage1_1_Click(object sender, RoutedEventArgs e)
        {
            _ = Frame.Navigate(typeof(Page1));
        }

        //Master details navigation
        private void ListView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            object clickedItem = e.ClickedItem;

            _ = Frame.Navigate(typeof(Page1), clickedItem, new DrillInNavigationTransitionInfo());
        }

        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {
            // Method intentionally left empty.
        }

        //Back Button
        private void HandleBack(object sender, EventArgs e)
        {
            Frame frame = Frame;
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        //keyboard navigation
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            // Method intentionally left empty.
        }

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // Method intentionally left empty.
        }

        //tooltip
        public void SetToolTip()
        {
            // ToolTip toolTip = new ToolTip(); toolTip.Content = "Alternative Tool Tip for the red
            // box."; ToolTipService.SetToolTip(Redbox, toolTip);
        }

        //using the binding extention
        public string MyFunction(string inputData)
        {
            return string.Concat(inputData, ": ", MyViewModel.DefaultData.D3.ToString(@"yyyy-MM-dd"));
        }

        //building views
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyViewModel.AddData(new Data.Data("Added", 25, DateTime.Now));
        }

        //using dispatcher
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MyViewModel.UpdateButton(sender);
            //((Frame)Window.Current.Content).Navigate(typeof(MainPage));
        }

        //<!--touch events-->
        private void touchTest_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void touchTest_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void touchTest_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void touchTest_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        //mouse events
        private void touchTest_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            //PointerPoint mousePoint = e.GetCurrentPoint(touchTest);
            //if (mousePoint.PointerDevice.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
            //{
            //    if (mousePoint.Properties.IsLeftButtonPressed)
            //    {
            //    }
            //    if (mousePoint.Properties.IsMiddleButtonPressed)
            //    {
            //    }
            //    if (mousePoint.Properties.IsRightButtonPressed)
            //    {
            //    }
            //}
        }

        //Keyboard events
        private void TestTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case VirtualKey.None:
                    break;

                case VirtualKey.LeftButton:
                    break;

                case VirtualKey.RightButton:
                    break;

                case VirtualKey.Cancel:
                    break;

                case VirtualKey.MiddleButton:
                    break;

                case VirtualKey.XButton1:
                    break;

                case VirtualKey.XButton2:
                    break;

                case VirtualKey.Back:
                    break;

                case VirtualKey.Tab:
                    break;

                case VirtualKey.Clear:
                    break;

                case VirtualKey.Enter:
                    break;

                case VirtualKey.Shift:
                    break;

                case VirtualKey.Control:
                    break;

                case VirtualKey.Menu:
                    break;

                case VirtualKey.Pause:
                    break;

                case VirtualKey.CapitalLock:
                    break;

                case VirtualKey.Kana:
                    break;

                case VirtualKey.ImeOn:
                    break;

                case VirtualKey.Junja:
                    break;

                case VirtualKey.Final:
                    break;

                case VirtualKey.Hanja:
                    break;

                case VirtualKey.ImeOff:
                    break;

                case VirtualKey.Escape:
                    break;

                case VirtualKey.Convert:
                    break;

                case VirtualKey.NonConvert:
                    break;

                case VirtualKey.Accept:
                    break;

                case VirtualKey.ModeChange:
                    break;

                case VirtualKey.Space:
                    break;

                case VirtualKey.PageUp:
                    break;

                case VirtualKey.PageDown:
                    break;

                case VirtualKey.End:
                    break;

                case VirtualKey.Home:
                    break;

                case VirtualKey.Left:
                    break;

                case VirtualKey.Up:
                    break;

                case VirtualKey.Right:
                    break;

                case VirtualKey.Down:
                    break;

                case VirtualKey.Select:
                    break;

                case VirtualKey.Print:
                    break;

                case VirtualKey.Execute:
                    break;

                case VirtualKey.Snapshot:
                    break;

                case VirtualKey.Insert:
                    break;

                case VirtualKey.Delete:
                    break;

                case VirtualKey.Help:
                    break;

                case VirtualKey.Number0:
                    break;

                case VirtualKey.Number1:
                    break;

                case VirtualKey.Number2:
                    break;

                case VirtualKey.Number3:
                    break;

                case VirtualKey.Number4:
                    break;

                case VirtualKey.Number5:
                    break;

                case VirtualKey.Number6:
                    break;

                case VirtualKey.Number7:
                    break;

                case VirtualKey.Number8:
                    break;

                case VirtualKey.Number9:
                    break;

                case VirtualKey.A:
                    break;

                case VirtualKey.B:
                    break;

                case VirtualKey.C:
                    break;

                case VirtualKey.D:
                    break;

                case VirtualKey.E:
                    break;

                case VirtualKey.F:
                    break;

                case VirtualKey.G:
                    break;

                case VirtualKey.H:
                    break;

                case VirtualKey.I:
                    break;

                case VirtualKey.J:
                    break;

                case VirtualKey.K:
                    break;

                case VirtualKey.L:
                    break;

                case VirtualKey.M:
                    break;

                case VirtualKey.N:
                    break;

                case VirtualKey.O:
                    break;

                case VirtualKey.P:
                    break;

                case VirtualKey.Q:
                    break;

                case VirtualKey.R:
                    break;

                case VirtualKey.S:
                    break;

                case VirtualKey.T:
                    break;

                case VirtualKey.U:
                    break;

                case VirtualKey.V:
                    break;

                case VirtualKey.W:
                    break;

                case VirtualKey.X:
                    break;

                case VirtualKey.Y:
                    break;

                case VirtualKey.Z:
                    break;

                case VirtualKey.LeftWindows:
                    break;

                case VirtualKey.RightWindows:
                    break;

                case VirtualKey.Application:
                    break;

                case VirtualKey.Sleep:
                    break;

                case VirtualKey.NumberPad0:
                    break;

                case VirtualKey.NumberPad1:
                    break;

                case VirtualKey.NumberPad2:
                    break;

                case VirtualKey.NumberPad3:
                    break;

                case VirtualKey.NumberPad4:
                    break;

                case VirtualKey.NumberPad5:
                    break;

                case VirtualKey.NumberPad6:
                    break;

                case VirtualKey.NumberPad7:
                    break;

                case VirtualKey.NumberPad8:
                    break;

                case VirtualKey.NumberPad9:
                    break;

                case VirtualKey.Multiply:
                    break;

                case VirtualKey.Add:
                    break;

                case VirtualKey.Separator:
                    break;

                case VirtualKey.Subtract:
                    break;

                case VirtualKey.Decimal:
                    break;

                case VirtualKey.Divide:
                    break;

                case VirtualKey.F1:
                    break;

                case VirtualKey.F2:
                    break;

                case VirtualKey.F3:
                    break;

                case VirtualKey.F4:
                    break;

                case VirtualKey.F5:
                    break;

                case VirtualKey.F6:
                    break;

                case VirtualKey.F7:
                    break;

                case VirtualKey.F8:
                    break;

                case VirtualKey.F9:
                    break;

                case VirtualKey.F10:
                    break;

                case VirtualKey.F11:
                    break;

                case VirtualKey.F12:
                    break;

                case VirtualKey.F13:
                    break;

                case VirtualKey.F14:
                    break;

                case VirtualKey.F15:
                    break;

                case VirtualKey.F16:
                    break;

                case VirtualKey.F17:
                    break;

                case VirtualKey.F18:
                    break;

                case VirtualKey.F19:
                    break;

                case VirtualKey.F20:
                    break;

                case VirtualKey.F21:
                    break;

                case VirtualKey.F22:
                    break;

                case VirtualKey.F23:
                    break;

                case VirtualKey.F24:
                    break;

                case VirtualKey.NavigationView:
                    break;

                case VirtualKey.NavigationMenu:
                    break;

                case VirtualKey.NavigationUp:
                    break;

                case VirtualKey.NavigationDown:
                    break;

                case VirtualKey.NavigationLeft:
                    break;

                case VirtualKey.NavigationRight:
                    break;

                case VirtualKey.NavigationAccept:
                    break;

                case VirtualKey.NavigationCancel:
                    break;

                case VirtualKey.NumberKeyLock:
                    break;

                case VirtualKey.Scroll:
                    break;

                case VirtualKey.LeftShift:
                    break;

                case VirtualKey.RightShift:
                    break;

                case VirtualKey.LeftControl:
                    break;

                case VirtualKey.RightControl:
                    break;

                case VirtualKey.LeftMenu:
                    break;

                case VirtualKey.RightMenu:
                    break;

                case VirtualKey.GoBack:
                    break;

                case VirtualKey.GoForward:
                    break;

                case VirtualKey.Refresh:
                    break;

                case VirtualKey.Stop:
                    break;

                case VirtualKey.Search:
                    break;

                case VirtualKey.Favorites:
                    break;

                case VirtualKey.GoHome:
                    break;

                case VirtualKey.GamepadA:
                    break;

                case VirtualKey.GamepadB:
                    break;

                case VirtualKey.GamepadX:
                    break;

                case VirtualKey.GamepadY:
                    break;

                case VirtualKey.GamepadRightShoulder:
                    break;

                case VirtualKey.GamepadLeftShoulder:
                    break;

                case VirtualKey.GamepadLeftTrigger:
                    break;

                case VirtualKey.GamepadRightTrigger:
                    break;

                case VirtualKey.GamepadDPadUp:
                    break;

                case VirtualKey.GamepadDPadDown:
                    break;

                case VirtualKey.GamepadDPadLeft:
                    break;

                case VirtualKey.GamepadDPadRight:
                    break;

                case VirtualKey.GamepadMenu:
                    break;

                case VirtualKey.GamepadView:
                    break;

                case VirtualKey.GamepadLeftThumbstickButton:
                    break;

                case VirtualKey.GamepadRightThumbstickButton:
                    break;

                case VirtualKey.GamepadLeftThumbstickUp:
                    break;

                case VirtualKey.GamepadLeftThumbstickDown:
                    break;

                case VirtualKey.GamepadLeftThumbstickRight:
                    break;

                case VirtualKey.GamepadLeftThumbstickLeft:
                    break;

                case VirtualKey.GamepadRightThumbstickUp:
                    break;

                case VirtualKey.GamepadRightThumbstickDown:
                    break;

                case VirtualKey.GamepadRightThumbstickRight:
                    break;

                case VirtualKey.GamepadRightThumbstickLeft:
                    break;
            }
        }

        private void TestTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        //using access keys
        private void TestBar_AccessKeyDisplayRequested(UIElement sender, AccessKeyDisplayRequestedEventArgs args)
        {
            switch (args.PressedKeys)
            {
                case "A":
                    break;

                case "B":
                    break;

                case "C":
                    break;
            }
        }

        private void TestBar_AccesKeyInvoked(UIElement sender, AccessKeyInvokedEventArgs args)
        {
            if (args.Handled)
            {
                //code
            }
        }

        //Making UI Respond to a virtual keyboard
        private void ShowThis(InputPane sender, InputPaneVisibilityEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void HideThis(InputPane sender, InputPaneVisibilityEventArgs args)
        {
            throw new NotImplementedException();
        }

        //controlling touchscreen keyboard

        //
        //using Enterprise authentication
        public async void Verifier()
        {
            _ = await UserConsentVerifier.CheckAvailabilityAsync();
            _ = await UserConsentVerifier.RequestVerificationAsync("Use your Verifier device?");
        }

        //microphones
        public async void Microphone()
        {
            MediaCapture mc = new MediaCapture();
            await mc.InitializeAsync();
            mc.Failed += Mc_Failed;
            mc.RecordLimitationExceeded += Mc_RecordLimitationExceeded;

            StorageFolder fdr = ApplicationData.Current.LocalFolder;
            StorageFile f = await fdr.CreateFileAsync("microphone.mp3", CreationCollisionOption.GenerateUniqueName);
            LowLagMediaRecording mr =
                await mc.PrepareLowLagRecordToStorageFileAsync(
                    MediaEncodingProfile.CreateMp3(AudioEncodingQuality.High), f);
            await mr.StartAsync();
        }

        private void Mc_RecordLimitationExceeded(MediaCapture sender)
        {
            throw new NotImplementedException();
        }

        private void Mc_Failed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            throw new NotImplementedException();
        }

        //using location

        public async void Location()
        {
            GeolocationAccessStatus gas = await Geolocator.RequestAccessAsync();

            Geolocator gl = new Geolocator
            {
                DesiredAccuracyInMeters = 10
            };
            gl.StatusChanged += Gl_StatusChanged;
            Geoposition gp = await gl.GetGeopositionAsync();
        }

        private void Gl_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            throw new NotImplementedException();
        }

        //using inking pens

        //recognising pen and shapes from input-->
        //private async void ButtonPen_Click(object sender, RoutedEventArgs e)
        //{
        //    InkAnalyzer ia = new InkAnalyzer();
        //    IReadOnlyList<InkStroke> is1 = myInkInput.InkPresenter.StrokeContainer.GetStrokes();
        //    if(is1.Count > 0)
        //    {
        //        ia.AddDataForStroke(is1);
        //        InkAnalysisResult iar = await ia.AnalyzeAsync();

        // if(iar.Status == InkAnalysisStatus.Updated) { IReadOnlyList<InkAnalysisNode> iwns =
        // ia.AnalysisRoot.FindNodes(InkAnalysisNodeKind.InkWord); foreach (InkAnalysisInkWord iwn
        // in iwns ) { if (iwn.RecognizedText == "DELETE")
        // ia.RemoveDataForStrokes(iwn.GetStrokeIds()); }
        // myInkInput.InkPresenter.StrokeContainer.DeleteSelected(); }

        // }

        //}

        //storing ink strokes
        //public async void ButtonPen1_Click(object sender, RoutedEventArgs e)
        //{
        //    IReadOnlyList<InkStroke> is1 = myInkInput1.InkPresenter.StrokeContainer.GetStrokes();

        // if( is1.Count > 0) { StorageFile sf = await
        // StorageFile.GetFileFromPathAsync("myInkFile.gif");
        // Windows.Storage.CachedFileManager.DeferUpdates(sf); IRandomAccessStream iras = await sf.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

        // using(IOutputStream ios = iras.GetOutputStreamAt(0)) { await
        // myInk.InkPresenter.StrokeContainer.SaveAsync(ios); await ios.FlushAsync();

        //        }
        //        iras.Dispose();
        //        await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(sf);
        //    }
        //}

        //using inkToolbar

        //camera input with cameraCaptureUI
        public async void TakePicture()
        {
            CameraCaptureUI ccui = new CameraCaptureUI();
            ccui.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            ccui.PhotoSettings.CroppedSizeInPixels = new Size(500, 500);
            StorageFile media = await ccui.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (media == null)
            {
                //code
            }
        }

        //media capture for video, camera, and audio input
        public async void CameraProfile()
        {
            MediaCapture mc = new MediaCapture();
            MediaCaptureInitializationSettings mcis = new MediaCaptureInitializationSettings();

            DeviceInformationCollection devs = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            foreach (DeviceInformation dev in devs)
            {
                if (MediaCapture.IsVideoProfileSupported(dev.Id) &&
                    dev.EnclosureLocation.Panel == Panel.Back)
                {
                    mcis.VideoDeviceId = dev.Id;
                    break;
                }
            }

            await mc.InitializeAsync(mcis);
        }

        //preview camera
        //private async void CameraPreview()
        //{
        //    MediaCapture mc = new MediaCapture();
        //    await mc.InitializeAsync();
        //    mc.Failed += Mc_Failed;

        // DisplayRequest dr = new DisplayRequest(); dr.RequestActive();
        // DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;

        // myCameraPreview.Source = mc; await mc.StartPreviewAsync();

        // await mc.StopPreviewAsync(); myCameraPreview.Source = null; dr.RequestRelease(); mc.Dispose();

        //}

        //manual camera control
        public async void Exposure()
        {
            MediaCapture mc = new MediaCapture();
            await mc.InitializeAsync();
            mc.Failed += Mc_Failed;

            Windows.Media.Devices.ExposureControl ec = mc.VideoDeviceController.ExposureControl;
            if (ec.Supported)
            {
                await mc.VideoDeviceController.ExposureControl.SetValueAsync(ec.Max);
            }
        }

        //<!--using the speech synthesizer-->
        //public async void TTS()
        //{
        //    SpeechSynthesizer ss = new SpeechSynthesizer();
        //    SpeechSynthesisStream sss = await ss.SynthesizeTextToStreamAsync("My sample text.");

        // myMedia.SetSource(sss, sss.ContentType); myMedia.Play();

        //}

        //<!--speech synthesizer with SSML-->
        //public async void TTS()
        //{
        //    SpeechSynthesizer ss = new SpeechSynthesizer();
        //    String s = File.ReadAllText("SSML.ssml");
        //    SpeechSynthesisStream sss = await ss.SynthesizeSsmlToStreamAsync(s);

        // myMedia1.SetSource(sss, sss.ContentType); myMedia1.Play();

        //}

        // <!--speech recognition-->
        public async void SpeechRecognition()
        {
            SpeechRecognizer sr = new SpeechRecognizer();
            sr.StateChanged += Sr_StateChanged;

            SpeechRecognitionTopicConstraint srtc =
                new SpeechRecognitionTopicConstraint(SpeechRecognitionScenario.Dictation, "dictation");
            sr.Constraints.Add(srtc);
            SpeechRecognitionCompilationResult srcr = await sr.CompileConstraintsAsync();


            // if Speech Recognition Result Status is not success
            if (srcr.Status != SpeechRecognitionResultStatus.Success)
            {
                Console.WriteLine("Compilation Error");
            }

            sr.UIOptions.AudiblePrompt = "Please try dictation";
            SpeechRecognitionResult srr = await sr.RecognizeWithUIAsync();

            // if Speech Recognition Result Status is equal success
            if (srr.Status == SpeechRecognitionResultStatus.Success)
            {
                Console.WriteLine(srr.Text);
            }
        }

        private void Sr_StateChanged(SpeechRecognizer sender, SpeechRecognizerStateChangedEventArgs args)
        {
            _ = args.State == SpeechRecognizerState.Idle;
        }

        //using different grammmer and languagers
        public async void ChangeLanguage()
        {
            Language lang = SpeechRecognizer.SystemSpeechLanguage;
            SpeechRecognizer sr = new SpeechRecognizer(lang);
            lang = new Language("en-US");
            _ = new SpeechRecognizer(lang);

            StorageFile sf = await Package.Current.InstalledLocation.GetFileAsync("MainPage.xml");
            SpeechRecognitionGrammarFileConstraint gfc = new SpeechRecognitionGrammarFileConstraint(sf);
            sr.Constraints.Add(gfc);
            _ = await sr.CompileConstraintsAsync();
        }

        public void LongSR()
        {
            SpeechRecognizer sr = new SpeechRecognizer();
            sr.ContinuousRecognitionSession.ResultGenerated += ContinuousRecognitionSession_ResultGenerated;
        }

        private void ContinuousRecognitionSession_ResultGenerated(SpeechContinuousRecognitionSession sender,
            SpeechContinuousRecognitionResultGeneratedEventArgs args)
        {
            if (args.Result.Confidence == SpeechRecognitionConfidence.Medium ||
                args.Result.Confidence == SpeechRecognitionConfidence.High)
            {
                _ = sb.Append(args.Result.Text + " ");
            }
        }

        //sharing data with a share contract
        private void ButtonData_Click(object sender, EventArgs e)
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataRequested;
        }

        private void DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequest req = args.Request;

            req.Data.SetText("Set Content");
        }

        //Recieving data with a share contract
        public async void OnSharetargetActivated(ShareTargetActivatedEventArgs args)
        {
            Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation shareOperation = args.ShareOperation;
            if (shareOperation.Data.Contains(StandardDataFormats.Text))
            {
                _ = await shareOperation.Data.GetTextAsync();
            }
        }

        //sharing data with the clipboard
        private void ButtonClip_Click(object sender, RoutedEventArgs e)
        {
            //clipboard

            DataPackage dp = new DataPackage
            {
                RequestedOperation = DataPackageOperation.Copy //copy
            };
            dp.RequestedOperation = DataPackageOperation.Move; //cut and paste
            dp.RequestedOperation = DataPackageOperation.Link; //shortcut past
            dp.RequestedOperation = DataPackageOperation.None; //delay


            DataPackageView d = Clipboard.GetContent();
            if (d.RequestedOperation == DataPackageOperation.Move)
            {
                // do work
            }

            Clipboard.ContentChanged += async (x, y) =>
            {
                DataPackageView dx = Clipboard.GetContent();
                if (d.RequestedOperation == DataPackageOperation.Move)
                {
                    string movethis = await dx.GetTextAsync();
                }
            };
        }

        //recieving data through drag and drop
        private void DragMe(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        private async void DropMe(object semder, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                System.Collections.Generic.IReadOnlyList<IStorageItem> items = await e.DataView.GetStorageItemsAsync();
                if (items.Count > 0)
                {
                    _ = items[0] as StorageFile;
                }
                //Do work
            }
        }

        //using app extentions
        public async Task<bool> Invoke(ValueSet message)
        {
            try
            {
                using (AppServiceConnection connection = new AppServiceConnection())
                {
                    connection.AppServiceName = "MyExtention";
                    connection.PackageFamilyName = "FamilyName";
                    AppServiceConnectionStatus status = await connection.OpenAsync();
                    if (status == AppServiceConnectionStatus.Success)
                    {
                        AppServiceResponse result = await connection.SendMessageAsync(message);
                        if (result.Status == AppServiceResponseStatus.Success)
                        {
                            ValueSet myValue = result.Message;

                            return true;
                        }
                    }
                    //gracefully handle
                }
            }
            // if the app extention is not installed
            catch (Exception ex)
            {
                //gracefully handle
                Console.Write(ex.Message);
            }

            return false;
        }

        //Creating a file
        private async void ButtonFile_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder myFolder = ApplicationData.Current.LocalFolder;
            StorageFile test = await myFolder.CreateFileAsync("test.text",
                CreationCollisionOption.FailIfExists);

            await FileIO.WriteTextAsync(test, "Hello World");
        }

        //Writing a file
        private async void ButtonFile1_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder myFolder = ApplicationData.Current.LocalFolder;
            StorageFile test = await myFolder.CreateFileAsync("test.text",
                CreationCollisionOption.FailIfExists);

            await FileIO.WriteTextAsync(test, "Hello World");

            IBuffer buffer =
                CryptographicBuffer.ConvertStringToBinary(
                    "Hello Universe", BinaryStringEncoding.Utf8);

            await FileIO.WriteBufferAsync(test, buffer);
        }

        //Reading from a file
        private async void ButtonFile2_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder myFolder = ApplicationData.Current.LocalFolder;
            StorageFile test = await myFolder.CreateFileAsync("test.text");
            _ = await FileIO.ReadTextAsync(test);

            IBuffer bufferedFile = await FileIO.ReadBufferAsync(test);
            using (DataReader dr = DataReader.FromBuffer(bufferedFile))
            {
                string convertedContent = dr.ReadString(bufferedFile.Length);
            }
        }

        //Reading file properties
        private async void ButtonFile3_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = KnownFolders.DocumentsLibrary;
            Windows.Storage.Search.StorageFileQueryResult scan = folder.CreateFileQuery();
            System.Collections.Generic.IReadOnlyList<StorageFile> allFiles = await scan.GetFilesAsync();

            foreach (StorageFile file in allFiles)
            {
                _ = await file.GetBasicPropertiesAsync();
            }
        }

        //working with file pickers
        private async void ButtonFile4_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            picker.FileTypeFilter.Add(".docx");
            picker.FileTypeFilter.Add(".pdf");

            StorageFile file = await picker.PickSingleFileAsync(); //pickmultiplefilesasync
            if (file != null)
            {
                _ = file.Name;
            }
        }

        //using Roaming settings
        private void ButtonFile5_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.RoamingSettings;

            //itterate over key /pair
            foreach (System.Collections.Generic.KeyValuePair<string, object> s in settings.Values)
            {
                Console.Write(s.Key);
            }

            //call by name example
            _ = (DateTime)settings.Values["lastViewed"];
            settings.DeleteContainer("myTest");
        }

        //Using RoamingFolder
        private async void ButtonFile6_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder roam = ApplicationData.Current.RoamingFolder;

            StorageFile file = await roam.GetFileAsync("test.txt");
            _ = await FileIO.ReadTextAsync(file);
        }

        //creating a sending toast

        //generating xml Payload
        public ToastContent MakeToast()
        {
            ToastContent tc = new ToastContent
            {
                Launch = "action=MyLaunchAction&myItemId=123"
            };

            ToastVisual tv = new ToastVisual
            {
                BindingGeneric = new ToastBindingGeneric
                {
                    Children =
                    {
                        new AdaptiveText { Text = "my title" },

                        new AdaptiveText { Text = "my textual content" },
                        new AdaptiveImage { Source = "mytoastimage.jpg" }
                    },
                    AppLogoOverride = new ToastGenericAppLogo
                    { Source = "myLogo", HintCrop = ToastGenericAppLogoCrop.Circle }
                }
            };
            ToastActionsCustom tac = new ToastActionsCustom
            {
                Inputs = { new ToastTextBox("yourResponse") { PlaceholderContent = "Type your response" } },
                Buttons =
                {
                    new ToastButton("Reply",
                        new QueryString { { "action", "YourResponse" }, { "myItemId", "123" } }.ToString())
                    {
                        ActivationType = ToastActivationType.Background, ImageUri = "YourResponse.png",
                        TextBoxId = "yourResponse"
                    },
                    new ToastButton("Like",
                            new QueryString { { "action", "YourLike" }, { "myItemId", "123" } }.ToString())
                        { ActivationType = ToastActivationType.Background },
                    new ToastButton("View",
                        new QueryString { { "action", "YourView" }, { "myItemId", "123" } }.ToString())
                }
            };
            tc.Visual = tv;
            tc.Actions = tac;

            return tc;
        }

        //adaptive toast content
        public void MakeAdaptiveToast()
        {
            _ = new ToastVisual
            {
                BindingGeneric = new ToastBindingGeneric
                {
                    Children =
                    {
                        new AdaptiveGroup
                        {
                            Children =
                            {
                                new AdaptiveSubgroup
                                {
                                    Children =
                                    {
                                        new AdaptiveText
                                            { Text = "My Left Text 1", HintStyle = AdaptiveTextStyle.Base },
                                        new AdaptiveText
                                            { Text = "My Left Text 2", HintStyle = AdaptiveTextStyle.CaptionSubtle }
                                    }
                                },
                                new AdaptiveSubgroup
                                {
                                    Children =
                                    {
                                        new AdaptiveText
                                        {
                                            Text = "My Right Text 1", HintStyle = AdaptiveTextStyle.CaptionSubtle,
                                            HintAlign = AdaptiveTextAlign.Center
                                        },
                                        new AdaptiveText
                                        {
                                            Text = "My Right Text 2", HintStyle = AdaptiveTextStyle.CaptionSubtle,
                                            HintAlign = AdaptiveTextAlign.Center
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        //interactive toasts
        public void InteractiveToast()
        {
            _ = new ToastActionsCustom
            {
                Buttons =
                {
                    new ToastButton("My Button 1", "action=button1&myItemId=123")
                        { ActivationType = ToastActivationType.Foreground },

                    new ToastButton("My Button 2", "action=button1&myItemId=123")
                        { ActivationType = ToastActivationType.Foreground }
                }
            };
        }

        //Activation with toasts
        public void SendToast()
        {
            Toast toast = new Toast();
            ToastContent tc = toast.MakeToast();
            ToastNotification tn = new ToastNotification(tc.GetXml())
            {
                Group = "myGroup",
                Tag = "123"
            };

            ToastNotifier tnr = ToastNotificationManager.CreateToastNotifier("myApp");
            tnr.Show(tn);
        }

        //configuring a primary tile
        //using secondary tiles
        //adaptive tiles
        //sending notifications to local tiles
        //Badge Notifications

        //creating a background task
        public async void BackgroundTask()
        {
            BackgroundExecutionManager.RemoveAccess("myApp");
            _ = await BackgroundExecutionManager.RequestAccessAsync("myApp");

            BackgroundTaskBuilder btb = new BackgroundTaskBuilder
            {
                Name = "My Background Task Builder"
            };
            btb.SetTrigger(new TimeTrigger(5, false));
            _ = btb.Register();
        }

        //registering a background task
        public void RegisterBackground()
        {
            foreach (System.Collections.Generic.KeyValuePair<Guid, IBackgroundTaskRegistration> ibtr in BackgroundTaskRegistration.AllTasks)
            {
                if (ibtr.Value.Name == "my task name" && ibtr.Key.GetType() == Guid.Empty.GetType())
                {
                    // do something
                }
            }

            BackgroundTaskBuilder btb = new BackgroundTaskBuilder
            {
                Name = "my task name",
                TaskEntryPoint = "UWP.MainPage"
            };
            btb.SetTrigger(new TimeTrigger(10, true));
            BackgroundTaskRegistration btr = btb.Register();
        }

        //background taskApp trigger
        public async void AppTrigger()
        {
            ApplicationTrigger at = new ApplicationTrigger();
            SystemCondition sc = new SystemCondition(SystemConditionType.UserNotPresent);

            BackgroundTaskBuilder btb = new BackgroundTaskBuilder
            {
                Name = "my task name",
                TaskEntryPoint = "UWP.MainPage"
            };
            btb.AddCondition(sc);
            btb.SetTrigger(at);
            _ = btb.Register();
            _ = await at.RequestAsync();
        }

        //conditional background tasks
        public void Conditions()
        {
            SystemCondition sc1 = new SystemCondition(SystemConditionType.UserNotPresent);
            SystemCondition sc2 = new SystemCondition(SystemConditionType.InternetAvailable);

            BackgroundTaskBuilder btb = new BackgroundTaskBuilder
            {
                Name = "my task name",
                TaskEntryPoint = "UWP.MainPage"
            };
            btb.AddCondition(sc1);
            btb.AddCondition(sc2);
            _ = btb.Register();
        }

        public void Run1(IBackgroundTaskInstance taskInstance)
        {
            // Method intentionally left empty.
        }

        //monitoring progress
        public void TaskProgress()
        {
            BackgroundTaskBuilder btb = new BackgroundTaskBuilder
            {
                Name = "my task name",
                TaskEntryPoint = "UWP.MainPage"
            };

            BackgroundTaskRegistration btr = btb.Register();

            btr.Completed += Btr_Completed;
            btr.Progress += Btr_Progress;
        }

        private void Btr_Progress(BackgroundTaskRegistration sender, BackgroundTaskProgressEventArgs args)
        {
            if (args.Progress > 10)
            {
                // do something
            }
        }

        private void Btr_Completed(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
            try
            {
                args.CheckResult();
            }
            catch
            {
                // do something
            }
        }

        //background task event handling
        public void Run2(IBackgroundTaskInstance taskInstance)
        {
            taskInstance.Canceled += TaskInstance_Canceled;
        }

        private void TaskInstance_Canceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            if (reason == BackgroundTaskCancellationReason.Abort)
            {
                // do something
            }
        }

        //create an app service
        public async void CallApService()
        {
            AppServiceConnection myAppService = new AppServiceConnection
            {
                AppServiceName = "myUniqueAppServiceName",
                PackageFamilyName = Package.Current.Id.FamilyName
            };
            AppServiceConnectionStatus ascs = await myAppService.OpenAsync();
            if (ascs == AppServiceConnectionStatus.Success)
            {
                AppServiceResponse asr =
                    await myAppService.SendMessageAsync(new ValueSet());
                if (asr.Status == AppServiceResponseStatus.Success)
                {
                    _ = asr.Message["key"];
                }
            }
        }

        //intergrating runtime components
        public void L()
        {
            _ = new RuntimeComponent1.Class1
            {
                MyInt = 123
            };
            _ = RuntimeComponent1.Class1.GetString();
        }

        //webauthenticationbroker for user authentication
        public void M()
        {
            // Method intentionally left empty.
        }

        //connecting with sso
        public void N()
        {
            // Method intentionally left empty.
        }

        //azure active directory setup
        public void O()
        {
            // Method intentionally left empty.
        }

        //azure active directory authentication
        public void P()
        {
            // Method intentionally left empty.
        }

        //credntial locker
        public void Q()
        {
            // Method intentionally left empty.
        }

        //detecting windows hello in uwp app
        public void R()
        {
            // Method intentionally left empty.
        }

        //adding a windows hello login screen
        public void S()
        {
            // Method intentionally left empty.
        }

        //remembering user history
        public void T()
        {
            // Method intentionally left empty.
        }

        //registering users with windows hello
        public void U()
        {
            // Method intentionally left empty.
        }

        //creating server side windows hello service
        public void V()
        {
            // Method intentionally left empty.
        }

        //using client side logic for windows hello service
        public void W()
        {
            // Method intentionally left empty.
        }

        // dbcontext class
        public void dbContext()
        {
            // Method intentionally left empty.
        }

        #region //UI Automation

        public ITextRangeProvider GetActiveComposition()
        {
            throw new NotImplementedException();
        }

        public ITextRangeProvider GetConversionTarget()
        {
            throw new NotImplementedException();
        }

        public ITextRangeProvider[] GetSelection()
        {
            throw new NotImplementedException();
        }

        public ITextRangeProvider[] GetVisibleRanges()
        {
            throw new NotImplementedException();
        }

        public ITextRangeProvider RangeFromChild(IRawElementProviderSimple childElement)
        {
            throw new NotImplementedException();
        }

        public ITextRangeProvider RangeFromPoint(Point screenLocation)
        {
            throw new NotImplementedException();
        }

        public ITextRangeProvider DocumentRange => throw new NotImplementedException();

        public SupportedTextSelection SupportedTextSelection => throw new NotImplementedException();

        #endregion
    }

    #region code for creating an app service

    public sealed class Class1 : IBackgroundTask
    {
        private AppServiceConnection asc;
        private BackgroundTaskDeferral btd;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            btd = taskInstance.GetDeferral();
            taskInstance.Canceled += OnTaskCanceled;

            AppServiceTriggerDetails astd = (AppServiceTriggerDetails)taskInstance.TriggerDetails;
            asc = astd.AppServiceConnection;
            asc.RequestReceived += OnRequestRecieved;
        }

        private async void OnRequestRecieved(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            if (args.Request.Message.Count > 1)
            {
                _ = await args.Request.SendResponseAsync(new ValueSet());
            }
        }

        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            btd?.Complete();
        }
    }

    #endregion
}