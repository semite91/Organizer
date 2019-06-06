using System.Collections.Generic;
using System.Linq;

using Organizer_Data.DAL;
using Organizer_Data.Models;
namespace Organizer_Data.DAL.Document
{
    public class DocumentModel : _Entity
    {
        public DocumentTypes Type { get; set; }

        public int? ContentId { get; set; }

        public int? FolderId { get; set; }

        public string FileName { get; set; }

        public bool IsImage { get; set; }

        public string Icon { get; set; }


        public DocumentModel()
        {

        }

        public DocumentModel(DocumentDocument document) : base(document)
        {
            ContentId = document.ContentId;
            FolderId = document.FolderId;

            FileName = document.FileName;
            Icon = SetIcon(FileName);

            IsImage = document.IsImage;
        }

        public string SetIcon(string fileName)
        {
            var icon = "file";
            
            if (!string.IsNullOrEmpty(fileName))
            {
                var extension = fileName.Substring(fileName.IndexOf(".") + 1, fileName.Length - fileName.IndexOf(".") - 1);

                if (extensions.ContainsKey(extension))
                    icon = "file-" + extensions[extension].ToString();
            }

            return icon;
        }

        #region Helpers
        private Dictionary<string, FileTypes> extensions = new Dictionary<string, FileTypes>() //extension, type
        {
            { "bmp", FileTypes.image },
            { "gif", FileTypes.image },
            { "jpg", FileTypes.image },
            { "jpeg", FileTypes.image },
            { "png", FileTypes.image },
            { "tiff", FileTypes.image },
            { "doc", FileTypes.word },
            { "docx", FileTypes.word },
            { "xls", FileTypes.excel },
            { "xlsx", FileTypes.excel },
            { "pdf", FileTypes.pdf },
            { "ppt", FileTypes.powerpoint },
            { "webpm", FileTypes.video },
            { "mpg", FileTypes.video },
            { "mp2", FileTypes.video },
            { "mpe", FileTypes.video },
            { "mpv", FileTypes.video },
            { "ogg", FileTypes.video },
            { "mp4", FileTypes.video },
            { "m4p", FileTypes.video },
            { "m4v", FileTypes.video },
            { "flv", FileTypes.video },
            { "mkv", FileTypes.video },
            { "avi", FileTypes.video },
            { "mp3", FileTypes.audio },
            { "m5a", FileTypes.audio },
            { "aac", FileTypes.audio },
            { "oga", FileTypes.audio },
            { "7zip", FileTypes.zip },
            { "rar", FileTypes.zip }
        };

        public enum FileTypes
        {
            image,
            word,
            excel,
            pdf,
            powerpoint,
            video,
            audio,
            code,
            zip
        };

        public enum DocumentTypes
        {
            Content = 0,
            File = 1
        }
        #endregion
    }
}
