using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.DevFriend_API.BLL.Interface
{
    public interface IFileUploader
    {
        Task<string> Upload();
    }
}
