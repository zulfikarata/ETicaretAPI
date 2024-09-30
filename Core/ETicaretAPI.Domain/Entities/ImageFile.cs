using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class ImageFile:File
    {
        public bool Showcase { get; set; }
        public ICollection<File> Files { get; set; }
    }
}
