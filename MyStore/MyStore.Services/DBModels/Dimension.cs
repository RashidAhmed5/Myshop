using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Services.DBModels
{
    public class Dimension
    {
        public int ID { get; set; }
        public int Width { get; set; }
        public int Profile { get; set; }
        public int RimSize { get; set; }
        public int SpeedRacing { get; set; }
        public string Name { get; set; }
    }
}
