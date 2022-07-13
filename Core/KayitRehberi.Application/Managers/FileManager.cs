using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace KayitRehberi.Application.Managers
{
    public static class FileManager
    {
      

        public static string GetUniqueNameAndSavePhotoToDisk( IFormFile pictureFile)
        {
            string uniqueFileName = default;

            if (pictureFile is not null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "-" + pictureFile.FileName;

                
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images",uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    pictureFile.CopyTo(fileStream);
                }
                
            }
            return uniqueFileName;
        }

    
    }
}
