using DevFriend_API.DevFriend_API.BLL.Interface;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.DevFriend_API.BLL
{
    public class FileUploader: IFileUploader
    {
        public async Task<string> Upload()
        {
            try
            {
                // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
                var stream = File.Open(@"D:\Purpose.png", FileMode.Open);

                // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
                var task = new FirebaseStorage("dev-friend-ybkjvy")
                    //.Child("data")
                    //.Child("random")
                    .Child("Purpose.png")
                    .PutAsync(stream);

                // Track progress of the upload
                task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                // await the task to wait until upload completes and get the download url
                var downloadUrl = await task;
                return downloadUrl;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
