using System.IO;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Back_End.Lib.ActionResults
{
    public class FileActionResult : ActionResult
    {
        public FileActionResult(string filename, string path, string contentType)
        {
            _filename = filename;
            _path = path;
            _contentType = contentType;
        }

        public string _contentType { get; }
        public string _filename { get; }
        public string _path { get; }

        public override void ExecuteResult(ControllerContext context)
        {
            byte[] bytes = File.ReadAllBytes(context.HttpContext.Server.MapPath(_path + _filename));
            context.HttpContext.Response.ContentType = _contentType;
            context.HttpContext.Response.BinaryWrite(bytes);
        }
    }
}