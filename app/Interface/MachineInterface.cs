using System;

namespace Interface
{
    public class MachineInterface
    {
        public int id { get; set; }
        public string patent { get; set; }
        public string type { get; set; }

        public MachineInterface(int id, string patent, string type)
        {
            this.id = id;
            this.patent = patent;
            this.type = type;
        }
    }
}
