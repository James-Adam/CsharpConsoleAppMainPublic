//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Runtime.CompilerServices;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;

//namespace AuthenticatedSchoolSystem.Controllers.BackEnd
//{
//    //file streaming api
//    [RoutePrefix("filestreaming")]
//    //[RequestModelValidator]
//    public class StreamFilesController : ApiController
//    {
//        /// <summary>
//        /// Get File meta data
//        /// </summary>
//        /// <param name="fileName">FileName value</param>
//        /// <returns>FileMeta data response</returns>
//        ///
//        [Route("getfilemetadata")]
//        // GET: StreamFiles
//        public HttpResponseMessage GetileMetaData(string fileName)
//        {
//            return new HttpResponseMessage(HttpStatusCode.OK);
//        }

// ///
// <summary>
// /// Asynchronous Download file ///
// </summary>
// ///
// <param name="fileName">FileName value</param>
// ///
// <returns>Tasked File stream response</returns>

// [Route("downloadAsync")] [HttpGet] public async Task<HttpResponseMessage>
// DownloadFileAsync(string fileName) { return await new TaskFactory().StartNew(() => { return
// DownloadFile(fileName); }); }

// ///
// <summary>
// /// Asynchronous Download file ///
// </summary>
// ///
// <param name="fileName">FileName value</param>
// ///
// <returns>Tasked File stream response</returns>
// /// [Route("download")] [HttpGet] public HttpResponseMessage DownloadFile(string fileName) {
// HttpResponseMessage response = Request.CreateResponse(); try { string filePath =
// string.Concat(this.GetDownloadPath(), "\\", fileName); FileInfo fileInfo = new
// FileInfo(filePath); FileMetaData metaData = new FileMetaData();

// if (!fileInfo.Exists) { metaData.FileResponseMessage.IsExists = false;
// metaData.FileResponseMessage.Content = string.Format("{0} file is not found!", fileName);
// response = Request.CreateResponse(HttpStatusCode.NotFound, metaData, new MediaTypeHeaderValue("text/json"));

// } else { response.Headers.AcceptRanges.Add("bytes"); response.StatusCode = HttpStatusCode.OK;
// response.Content = new StreamContent(fileInfo.ReadStream());
// response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("Attachment");
// response.Content.Headers.ContentDisposition.FileName = fileName;
// response.Content.Headers.ContentType = new MediaTypeHeaderValue("Application/octetstream");
// response.Content.Headers.ContentLength = fileInfo.Length;

// } } catch (Exception exception) { response =
// Request.CreateResponse(HttpStatusCode.InternalServerError, exception); } return response;

// }

// private object GetDownloadPath() { throw new NotImplementedException(); }

// /// <summary> /// Upload file /// </summary> /// <param name="overWrite">FileName value</param>
// /// <returns>Tasked File stream response</returns> /// [Route("upload")] [HttpPost] public
// HttpResponseMessage UploadFile(bool overWrite) { HttpResponseMessage response =
// Request.CreateResponse(); List<FileResponseMessage> fileResponseMessages = new
// List<FileResponseMessage>(); FileResponseMessage fileResponseMessage = new FileResponseMessage {
// IsExists = false, };

// try { if (!Request.Content.IsMimeMultipartContent()) { fileResponseMessage.Content = "Upload data
// request is not valid"; fileResponseMessage.Add(fileResponseMessage); response =
// Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, fileResponseMessages, new
// MediaTypeHeaderValue("text/jsnon")); ; } else { response = ProcessUploadRequest(overWrite); } }
// catch (Exception exception) { response =
// Request.CreateResponse(HttpStatusCode.InternalServerError, exception); } return response; }

// private HttpResponseMessage ProcessUploadRequest(bool overWrite) { List<FileResponseMessage>
// fileResponseMessages = new List<FileResponseMessage>();

// HttpResponseMessage response = null; FileResponseMessage fileResponseMessage = new FileResponseMessage();

// if (this.GetRequestContentLength() > WebApiApplication.MaxRequestlength) { int maxSixe =
// Convert.ToInt32(Math.Round(WebApiApplication.MaxRequestlength / 1024.0, 1));
// fileResponseMessage.Content = string.Format("Upload data content size is beyond maximum
// size({0}MD) allowed by the server!", maxSixe < 1 ? 1 : maxSixe);
// fileResponseMessage.Add(fileResponseMessage); response =
// Request.CreateResponse(HttpStatusCode.BadRequest, fileResponseMessage, new
// MediaTypeHeaderValue("")); } else { try { HttpRequestBase request = this.Request(); string
// uploadPath = this.GetUploadPath(); HttpFileCollectionBase files = request.Files;

// foreach (string file in files) { } } catch (Exception exception) { } } }

// /// <summary> /// Asynchronous Upload file /// </summary> /// <param name="overWrite">an
// indicator to overwrite a filr ig it exists in the server</param> /// <returns>Tasked Message
// response</returns> /// [Route("uploadasync")] [HttpPost] public async Task<HttpResponseMessage>
// UploadFileAsync(bool overWrite) { return await new TaskFactory().StartNew(() => { return
// UploadFile(overWrite); }); } }

//}

