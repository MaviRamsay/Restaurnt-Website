using Microsoft.AspNetCore.Http;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Services.Interfaces;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Implementations
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IUnitOfWork unitOfWork;

        public UploadFileService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Uploading file record to database
        /// </summary>
        /// <param name="file">File to upload</param>
        /// <returns>Uploaded file record</returns>
        public async Task<UploadedFile> UploadAsync(IFormFile file)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);

            string name = Path.GetRandomFileName();
            string absoluteName = Path.GetFileName(WebUtility.HtmlEncode(file.FileName));

            var dbFile = new UploadedFile { Content = ms.ToArray(), Name = name, AbsoluteName = absoluteName, ContentType = file.ContentType };
            await unitOfWork.UploadedFiles.InsertAsync(dbFile);

            return dbFile;
        }

        /// <summary>
        /// Deleting file record
        /// </summary>
        /// <param name="id">File id</param>
        /// <returns>True - file successfully deleted. False - file doesn't exists</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            if ((await unitOfWork.UploadedFiles.GetByIdAsync(id)) is null) {
                return false;
            }
            else {
                unitOfWork.UploadedFiles.Delete(id);

                return true;
            }
        }

        public async Task<UploadedFile> GetByIdAsync(int id)
        {
            return await unitOfWork.UploadedFiles.GetByIdAsync(id);
        }
    }
}
